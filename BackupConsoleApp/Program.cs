using System;
using System.IO;

namespace BackupConsoleApp
{
	class Program : CopyDir
	{
		private static DirectoryInfo newTargetPath { get; set; }

		public static DirectoryInfo sourcePath { get; set; }

		static void Main(string[] args)
		{
			CopyAll(sourcePath, newTargetPath);

			Console.ReadKey();
		}
	}
}
