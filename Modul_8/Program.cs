using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modul_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();
            //пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives) 
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }
            GetCatalog();
        }
    }

    static void GetCatalogs()
    {
        string dirName = @"C:\\"; //прописываем путь к корневой директории
        if (Directory.Exists(dirName) ) //проверим, что директория существует
        {

        }
    }

    public class Drive
    {
        public Drive(string name, long totalSpace, long freeSpace) 
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }
        public string Name { get; set; }
        public long TotalSpace { get; set; }
        public long FreeSpace { get; set; }

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

        public void CreateFolder(string name)
        {
            Folders.Add(name, new Folder());
        }
        public class Folder
        {
            public List<string> Files { get; set; } = new List<string>();
        }
    }


}
