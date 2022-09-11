using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupConsoleApp
{
	class CopyDir
	{
		public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
		{
			Console.WriteLine("Введите путь к исходной папке");
			string sourcePath = Console.ReadLine();
			Console.WriteLine("Введите путь к целевой папке");
			string newTargetPath = Path.Combine(Console.ReadLine(), (DateTime.Now.ToString("dd.MM.yyyy HH-mm-ss")));


			DirectoryInfo newFolder = new DirectoryInfo(newTargetPath);
			newFolder.Create();

			foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
			{
				Directory.CreateDirectory(dirPath.Replace(sourcePath, newTargetPath));
			}

			//Скопировать все файлы и заменить файлы с таким же именем
			foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
			{
				File.Copy(newPath, newPath.Replace(sourcePath, newTargetPath), true);

			}

			foreach (string newFile in Directory.GetFiles(newTargetPath, "*.*", SearchOption.AllDirectories))
			{
				System.IO.File.Move(newFile, newFile + ".bak");
			}

		}
	}
}

