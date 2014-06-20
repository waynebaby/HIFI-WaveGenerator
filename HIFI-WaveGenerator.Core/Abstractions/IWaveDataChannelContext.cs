using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core.Abstractions
{
	public interface IWaveDataChannelContext
	{
		string Name { get; }
		TimeSpan StartDelta { get; set; }
		TimeSpan CurrentPosition { get; set; }
		Double SpeedRate { get; set; }

		IWaveDataFunction WaveDataFunction { get; set; }
	}
}
