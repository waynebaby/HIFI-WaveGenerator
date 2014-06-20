﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core.Abstractions
{
	public interface IWaveDataFunction
	{
		double ComputeValue(TimeSpan input);

		TimeSpan LoopLength { get; }

	}


}
