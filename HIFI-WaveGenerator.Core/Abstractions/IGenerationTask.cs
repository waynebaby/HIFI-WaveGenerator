﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core.Abstractions
{
	public interface IGenerationTask
	{
		/// <summary>
		/// 输出的格式描述
		/// </summary>
		IWaveOutputDescription WaveOutputDescription { get; }

		/// <summary>
		/// 输出的实际声道
		/// </summary>
		IList<IWaveDataChannelContext> Channels { get; }

		///// <summary>
		///// 根据时间产生数据
		///// </summary>
		///// <param name="start">开始时间</param>
		///// <param name="Duration">时长</param>
		///// <returns><数据/returns>
		//byte[] Render(TimeSpan start, TimeSpan Duration);

		Stream OutputStream { get; }
	
		TimeSpan MinBufferSize { get;}

		TimeSpan CurrentBufferSize { get;  }

	}


}
