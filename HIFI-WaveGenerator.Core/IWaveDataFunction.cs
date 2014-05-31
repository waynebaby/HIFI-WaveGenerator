using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core
{
	public interface IWaveDataFunction<TInput, TOutput>
	{
		TOutput[] ComputeValues(IEnumerable<TInput> inputs);
		ArraySegment<TOutput> ComputeValues(IEnumerable<TInput> inputs, TOutput[] target);
		void ComputeValues(IEnumerable<TInput> inputs, TOutput[] target, int startIndex);
		TOutput ComputeValue(TInput input);
		void ComputeValue(TInput input, ref TOutput output);
	}
}
