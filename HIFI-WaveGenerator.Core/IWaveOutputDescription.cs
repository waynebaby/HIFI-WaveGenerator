using System;
namespace HIFI_WaveGenerator.Core
{
	public interface IWaveOutputDescription
	{
		int Channels { get; set; }
		SamplingDepth Depth { get; set; }
		string Name { get; set; }
		SamplingRate Rate { get; set; }
	}
}
