using System;
namespace HIFI_WaveGenerator.Core
{
	public interface IWaveOutputDescription
	{
		/// <summary>
		/// 声道数量
		/// </summary>
		int ChannelCount { get; set; }
		/// <summary>
		/// 采样深度
		/// </summary>
		SamplingDepth SamplingDepth { get; set; }
		/// <summary>
		/// 输出类型名
		/// </summary>
		string Name { get; set; }
		/// <summary>
		/// 输出采样率
		/// </summary>
		SamplingRate SamplingRate { get; set; }
	}
}
