using HIFI_WaveGenerator.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core
{
	public class GenerationTask : IGenerationTask
	{
		//public GenerationTask(Abstractions.IGenerationTask generationTask, TimeSpan bufferFillStep, int minBufferSize)
		////:base(null,minBufferSize)
		//{

		//}

		////public Abstractions.IGenerationTask GenerationTask { get; private set; }




		public IWaveOutputDescription WaveOutputDescription
		{
			get { throw new NotImplementedException(); }
		}

		public IList<IWaveDataChannelContext> Channels
		{
			get { throw new NotImplementedException(); }
		}

		public Stream OutputStream
		{
			get { throw new NotImplementedException(); }
		}

		public TimeSpan MinBufferSize
		{
			get { throw new NotImplementedException(); }
		}

		public TimeSpan CurrentBufferSize
		{
			get { throw new NotImplementedException(); }
		}
	}
}
