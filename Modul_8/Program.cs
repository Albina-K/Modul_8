using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Modul_8
{
   /* internal class Program
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
            GetCatalogs(); //вызов метода для получения директорий
        }


        static void GetCatalogs()
        {
            string dirName = @"C:\\"; //прописываем путь к корневой директории
            if (Directory.Exists(dirName)) //проверим, что директория существует
            {
                Console.WriteLine("Папки");
                string[] dirs = Directory.GetDirectories(dirName); //получим все директории корневого каталога

                foreach (string dir in dirs) //выведем их все
                    Console.WriteLine(dir);

                Console.WriteLine();
                Console.WriteLine("Файлы");
                string[] files = Directory.GetFiles(dirName); // получим все файлы корневого каталога

                foreach (string file in files) //выведем их все
                    Console.WriteLine(file);

                try
                {
                    DirectoryInfo dirinfo = new DirectoryInfo(@"C:\\");
                    if (dirinfo.Exists)
                    {
                        Console.WriteLine(dirinfo.GetDirectories().Length + dirinfo.GetFiles().Length);
                    }
                    DirectoryInfo newDirectory = new DirectoryInfo(@"/newDirectory");
                    if (!newDirectory.Exists)
                        newDirectory.Create();
                    Console.WriteLine(dirinfo.GetDirectories().Length + dirinfo.GetFiles().Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                DirectoryInfo dirInfo = new DirectoryInfo(@"/User/Luft");
                if (!dirInfo.Exists)
                    dirInfo.Create();

                dirInfo.CreateSubdirectory("NewFolder");
                dirInfo.CreateSubdirectory("SkillFactory");

                DirectoryInfo dirInfo3 = new DirectoryInfo(@"/Users/Альбина/Desktop");
                if (!dirInfo3.Exists)
                    dirInfo3.Create();
                dirInfo3.CreateSubdirectory("testFolder");


                // получение информации о каталоге
                Console.WriteLine($"Название каталога: {dirInfo.Name}");
                Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
                Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
                Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
            }
            try //удаление папк со всем содержимым
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"/User/Luft/NewFolder");
                dirInfo.Delete(true);
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //перемещение каталога
            DirectoryInfo dirInfo2 = new DirectoryInfo("/User/Luft/SkillFactory");
            string newPath = "/User/Luft/SkillFactoryNew";
            if (dirInfo2.Exists && !Directory.Exists(newPath))
                dirInfo2.MoveTo(newPath);

            //перемещение в корзину
            try
            {
                DirectoryInfo dirInfo4 = new DirectoryInfo(@"/Users/Альбина/Desktop/testFolderNew");
                string trashPath = "/Users/Альбина/Trash/testFolderNew";
                dirInfo4.MoveTo(trashPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"/User/Luft/SkillFactory");
                dirInfo.Delete(true); //удаление со всем содержимым
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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


        class FaleWriter
        {
            public static void Main()
            {
                string filePath = @"/User/Luft/SkillFactory/Studints.txt"; //укажем путь
                if (!File.Exists(filePath)) //проверим существует ли файл по указанному пути
                {
                    //если не существует - создаем и записываем в строку
                    using (StreamWriter sw = File.CreateText(filePath)) //конструкция будет рассмотрена в следующих юнитах
                    {
                        sw.WriteLine("Олег");
                        sw.WriteLine("Дмитрий");
                        sw.WriteLine("Иван");
                    }
                }
                //откроем файл и прочитаем его содержимое
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null) //пока не кончатся строки - считывем из файла по одной и выводим в консоль
                    {
                        Console.WriteLine(str);
                    }
                }

                string tempFile = Path.GetTempFileName(); //исползуем генерацию имени файла
                var fileInfo = new FileInfo(tempFile); //создаем объект класса FileInfo

                //создаем файл и записываем в него
                using (StreamWriter sw = fileInfo.CreateText())
                {
                    sw.WriteLine("Игорь");
                    sw.WriteLine("Андрей");
                    sw.WriteLine("Сергей");
                }
                //открывавем файл и читаем из него
                using (StreamReader sr = fileInfo.OpenText())
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }
                try
                {
                    string tempFile2 = Path.GetTempFileName();
                    var fileInfo2 = new FileInfo(tempFile2);

                    //убедимся что файл назначения точно отсутствует
                    fileInfo2.Delete();

                    //копируем информация
                    fileInfo.CopyTo(tempFile2);
                    Console.WriteLine($"{tempFile} скопирован в файл {tempFile2}.");
                    //удаляем ранее созданный файл
                    fileInfo.Delete();
                    Console.WriteLine($"{tempFile} удален.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e}");
                }
            }
        }
    }*/

    /*class BinaryExperiment
    {
        const string SettingsFileName = "Settings.cfg";
        static void Main()
        {
            //пишем
            WriteValues();
            //считываем
            ReadValues();
        }
        static void WriteValues()
        {
            //создаем объект BinaryWriter и указываем, куда будет направлен поток данных
            using (BinaryWriter writer = new BinaryWriter(File.Open(SettingsFileName, FileMode.Create)))
            {
                //записываем данные в разном формате
                writer.Write(20.666F);
                writer.Write(@"Текстовая строка");
                writer.Write(55);
                writer.Write(false);
            }
        }

        static void ReadValues()
        {
            float FloatValue;
            string StringValue;
            int IntValue;
            bool BooleanValue;

            if (File.Exists(SettingsFileName))
            {
                //создаем объект BinaryReader и инициализируем его возвратом метода File.Open
                using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
                {
                    // применяем специализированные методы Read для считывания соответствующего типа данных
                    FloatValue = reader.ReadSingle();
                    StringValue = reader.ReadString();
                    IntValue = reader.ReadInt32();
                    BooleanValue = reader.ReadBoolean();
                }

                Console.WriteLine("Из файла считано: ");
                Console.WriteLine("Дробь: " + FloatValue);
                Console.WriteLine("Строка: " + StringValue);
                Console.WriteLine("Целое: " + IntValue);
                Console.WriteLine("Булевое значение: " + BooleanValue);
            }
        }

    }*/

        class Program
        {
            /*public static void Main()
            {
                // сохраняем путь к файлу
                string filePath = "/Users/Альбина/Desktop/BinaryFile.bin";
                //при запуске проверим, что файл существует
                if (File.Exists(filePath))
                {
                    //строковая переменная в которую будем считывать данные
                    string stringValue;

                    //считываем, после использования высвобождаем задействованный ресурс BinaryReader
                    using (BinaryReader reader =  new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        stringValue = reader.ReadString();
                    }

                    //вывод
                    Console.WriteLine("Из файла считано: ");
                    Console.WriteLine(stringValue);
                }
            }*/

            public static void Main ()
            {
                WriteValues();
                ReadValues();
            }
            static void WriteValues()
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open("/Users/Альбина/Desktop/BinaryFile.bin", FileMode.Open)))
                    writer.Write($"Фаил изменен {DateTime.Now} на компьютере с ОС {Environment.OSVersion}");

            }
            static void ReadValues()
            {
                string StringValue;
                if (File.Exists("Users/Альбина/Desktop/BinaryFile.bin"))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open("/Users/Альбина/Desktop/BinaryFile.bin", FileMode.Open)))
                    {
                        StringValue = reader.ReadString();
                    }
                    Console.WriteLine(StringValue);
                }
            }
        }
}
        
    








