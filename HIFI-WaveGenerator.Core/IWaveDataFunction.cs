using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core
{
	public interface IWaveDataFunction< TInput, out  TOutput>
	{
		TOutput ComputeValue(TInput input);

		TInput LoopLength { get; }

	}
}
