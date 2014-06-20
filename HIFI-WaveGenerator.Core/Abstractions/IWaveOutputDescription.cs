using System;
namespace HIFI_WaveGenerator.Core.Abstractions
{
	public interface IWaveOutputDescription
	{
		/// <summary>
		/// 声道数量
		/// </summary>
		int ChannelCount { get; }
		/// <summary>
		/// 采样深度
		/// </summary>
		SamplingDepth SamplingDepth { get; }
		/// <summary>
		/// 输出类型名
		/// </summary>
		string Name { get; }
		/// <summary>
		/// 输出采样率
		/// </summary>
		SamplingRate SamplingRate { get;}
	}
}
