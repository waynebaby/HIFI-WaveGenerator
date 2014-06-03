using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIFI_WaveGenerator.Core.Abstractions
{
	public class Header
	{

		#region 04H~07H 4 长整数 从下个地址开始到文件尾的总字节数

		/// <summary>
		/// 04H~07H 4 长整数 从下个地址开始到文件尾的总字节数 
		/// </summary>
		public Int32 TotalStreamLength
		{
			get { return BitConverter.ToInt32(_instanceHeader, 0x4); }
			set { BitConverter.GetBytes(value).CopyTo(_instanceHeader, 0x4); }
		}
		#endregion

		#region 16H~17H 2 整数 通道数，单声道为1，双声道为2

		/// <summary>
		/// 16H~17H 2 整数 通道数，单声道为1，双声道为2 
		/// </summary>
		public Int16 Channels
		{
			get { return BitConverter.ToInt16(_instanceHeader, 0x16); }
			set
			{
				BitConverter.GetBytes(value).CopyTo(_instanceHeader, 0x16);
				RefreshBytesPerSecond();
			}
		}

		#endregion

		#region 18H~1BH 4 长整数 采样频率
		/// <summary>
		/// 18H~1BH 4 长整数 采样频率
		/// </summary>
		public int SamplingFrequency
		{
			get { return BitConverter.ToInt32(_instanceHeader, 0x18); }
			set
			{
				BitConverter.GetBytes(value).CopyTo(_instanceHeader, 0x18);
				RefreshBytesPerSecond();
			}
		}

		#endregion

		#region 1CH~1FH 4 长整数 波形数据传输速率（每秒平均字节数）

		/// <summary>
		/// 1CH~1FH 4 长整数 波形数据传输速率（每秒平均字节数）
		/// </summary>
		public int BytesPerSecond
		{
			get { return BitConverter.ToInt32(_instanceHeader, 0x1c); }
			private set { BitConverter.GetBytes(value).CopyTo(_instanceHeader, 0x1c); }
		}

		#endregion

		#region 20H~21H 2 整数 数据的调整数（按字节计算）
		/// <summary>
		/// 20H~21H 2 整数 数据的调整数（按字节计算）
		/// </summary>
		public Int16 DataAlterive
		{
			get { return BitConverter.ToInt16(_instanceHeader, 0x20); }
			set { BitConverter.GetBytes(value).CopyTo(_instanceHeader, 0x20); }
		}
		#endregion

		#region 22H~23H 2 整数 样本数据位数
		/// <summary>
		/// 22H~23H 2 整数 样本数据位数 
		/// </summary>
		public Int16 SamplingDepth
		{
			get { return BitConverter.ToInt16(_instanceHeader, 0x22); }
			set
			{
				BitConverter.GetBytes(value).CopyTo(_instanceHeader, 0x22);
				RefreshBytesPerSecond();
			}
		}
		#endregion

		private void RefreshBytesPerSecond()
		{
			BytesPerSecond = SamplingDepth * SamplingFrequency * Channels / 8;
		}

		byte[] _instanceHeader = headerBufferTemplate.ToArray();

		public byte[] InstanceHeader
		{
			get { return _instanceHeader; }

		}




		static byte[] headerBufferTemplate = new byte[] 
        { 
            0x52,
            0x49,
            0x46,
            0x46,
            0x24,
            0xCD,
            0x01,
            0x00,
           
            0x57,
            0x41,
            0x56,
            0x45,
            0x66,
            0x6d,
            0x74,
            0x20,
           
            0x10,
            0x00,
            0x00,
            0x00,
            0x01,
            0x00,
            0x02,
            0x00,
           
            0x44,
            0xac,
            0x00,
            0x00,
            0x10,
            0xb1,
            0x02,
            0x00,
           
            0x04,
            0x00,
            0x10,
            0x00,
            0x64,
            0x61,
            0x74,
            0x61,

            0x00,
            0xcd,
            0x01,
            0x00
        };


	}
}
