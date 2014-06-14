using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core
{
	public abstract class ReadOnlyStream : Stream
	{
		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override void Flush()
		{
			throw new NotImplementedException();
		}

		public override long Length
		{
			get { return -1; }
		}

		public override long Position
		{
			get
			{
				return -1;
			}
			set
			{

			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}




		public override abstract int Read(byte[] buffer, int offset, int count);

	}
}
