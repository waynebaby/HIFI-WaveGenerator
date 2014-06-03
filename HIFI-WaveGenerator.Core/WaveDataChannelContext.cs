using HIFI_WaveGenerator.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core
{
	public class WaveDataChannelContext : IWaveDataChannelContext
	{
		public string Name
		{
			get;
			private set;
		}

		public TimeSpan StartDelta
		{
			get;
			set;
		}

		public TimeSpan CurrentPosition
		{

			get;
			set;
		}

		public double SpeedRate
		{
			get;
			set;
		}

		public IWaveDataFunction<TimeSpan, object> DataFunction
		{
			get;
			set;
		}
	}
}
