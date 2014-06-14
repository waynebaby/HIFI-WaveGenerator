using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingConsole
{
	class Program
	{
		static void Main(string[] args)
		{

			var bffs = Enumerable.Range(0, 256).Select(x => (byte)x)
				.ToArray();

			var stm = new HIFI_WaveGenerator.Core.ByteBufferGenerationStream(() => new[] { new ArraySegment<byte>(bffs, 0, 256) }, 1024);


			var s = new StreamReader(stm);

			while (true)
			{
				var x = s.ReadLine();
				Console.WriteLine(x);
				Console.ReadLine();
			}
		
		}
	}
}
