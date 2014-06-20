using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HIFI_WaveGenerator.Core.Streams
{

	public class ByteBufferGenerationStream : ReadOnlyStream, IDisposable
	{


		public ByteBufferGenerationStream(Func<ArraySegment<byte>[]> generationFactory, int minBufferSize)
		{
			_GenerationFactory = generationFactory;
			MinBufferSize = minBufferSize;

			AutoGenLoopingTask = Task.Factory.StartNew(
				o => AutoGenLooping(), cancel.Token, TaskCreationOptions.LongRunning);
		}
		System.Threading.AutoResetEvent _wait = new System.Threading.AutoResetEvent(false);


		Func<ArraySegment<byte>[]> _GenerationFactory;

		private Queue<ArraySegment<byte>> _Buffer = new Queue<ArraySegment<byte>>();
		private int _PeekOffset = 0;
		private int _BufferSize;


		public int MinBufferSize { get; private set; }


		public void Dispose()
		{
			cancel.Cancel();
			if (_wait != null)
			{
				_wait.Dispose();
			}
		}

		void AutoGenLooping()
		{
			while (true)
			{
				if (_BufferSize < MinBufferSize)
				{
					lock (_Buffer)
					{
						while (_BufferSize < MinBufferSize)
						{
							var segs = _GenerationFactory();

							foreach (var item in segs)
							{
								_Buffer.Enqueue(item);
								Interlocked.Add(ref _BufferSize, item.Count);
							}
						}							 
					}								 				
				}
				_wait.WaitOne(10000);
				//_wait.Reset();
			}
		}


		Task AutoGenLoopingTask;
		CancellationTokenSource cancel = new CancellationTokenSource();


		public override int Read(byte[] buffer, int offset, int count)
		{


			int todo = count;
			int total = 0;
			lock (_Buffer)
			{
				while (_Buffer.Count > 0 && todo > 0)
				{
					var current = _Buffer.Peek();
					var currentSize = current.Count - _PeekOffset;

					if (currentSize <= 0)
					{
						_Buffer.Dequeue();
						_PeekOffset = 0;
						continue;
					}

					var copysize = (todo < currentSize) ? todo : currentSize;


					Buffer.BlockCopy(current.Array, current.Offset + _PeekOffset, buffer, offset, copysize);
					offset = offset + copysize;
					_PeekOffset = _PeekOffset + copysize;
					todo = todo - copysize;
					total = total + copysize;
					Interlocked.Add(ref _BufferSize, -copysize);
				}
			}
			if (_BufferSize < MinBufferSize)
			{
				_wait.Set();
			}
			return total;

		}
	}


}
