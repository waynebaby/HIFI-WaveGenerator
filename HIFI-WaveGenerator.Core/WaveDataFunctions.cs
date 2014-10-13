using HIFI_WaveGenerator.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core
{
	public class SinWaveDataFunctions : IWaveDataFunction
	{
		public double ComputeValue(TimeSpan input)
		{
			var sec = input.TotalSeconds;
			var delta = sec % 1;
			return Math.Sign(delta * 2 * Math.PI);
		}

		public TimeSpan LoopLength
		{
			get { return TimeSpan.FromSeconds(1); }
		}
	}



	public class RetangleDataFunctions : IWaveDataFunction
	{
		public double ComputeValue(TimeSpan input)
		{
			var x = input.TotalSeconds;

			return ((((x % 1) > 0.5) ? 1 : 0) - .5) * 2;
		}

		public TimeSpan LoopLength
		{
			get { return TimeSpan.FromSeconds(1); }
		}
	}



	public class TrangleDataFunctions : IWaveDataFunction
	{
		public double ComputeValue(TimeSpan input)
		{

			var x = input.TotalSeconds;
			return ((x % .5 * 2) - 0.5) * (((x % 1 - .5) > 0 ? 1 : -1));
		}

		public TimeSpan LoopLength
		{
			get { return TimeSpan.FromSeconds(1); }
		}
	}


	public class TestScanWaveDataFunctions : IWaveDataFunction
	{
		public double ComputeValue(TimeSpan input)
		{

			var x1 = input.TotalSeconds / 40;
			var feq = ((x1 % .5 * 2) - 0.5) * (((x1 % 1 - .5) > 0 ? 1 : -1)) * (20000 - 20);
			return Math.Sin(input.TotalSeconds * (20 + feq));
		}

		public TimeSpan LoopLength
		{
			get { return TimeSpan.FromSeconds(1); }
		}
	}
}
