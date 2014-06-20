using HIFI_WaveGenerator.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core
{
	public class WaveOutputDescription : IWaveOutputDescription
	{

		public WaveOutputDescription(
				string name,
				int channelCount,
				SamplingDepth samplingDepth,
				SamplingRate samplingRate)
		{

			Name = name;
			ChannelCount = channelCount;
			SamplingDepth = samplingDepth;
			SamplingRate = samplingRate;

		}
		public int ChannelCount
		{
			get;
			private set;
		}

		public SamplingDepth SamplingDepth
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}

		public SamplingRate SamplingRate
		{
			get;
			private set;
		}
	}
}
