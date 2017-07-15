namespace treehouse
{
    using System.IO;
    using System;
    class Stream
    {
        public static void Main()
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Current directory: " + CurrentDirectory);
            
            DirectoryInfo directory = new DirectoryInfo(CurrentDirectory);

            var Files = directory.GetFiles();
            foreach (var file in Files)
            {
                Console.WriteLine(file.Name);
            }

            var fileName = Path.Combine(directory.FullName,"data.csv");
            var fileToRead = new FileInfo(fileName);
            if(fileToRead.Exists)
                {
                    var fileContent = ReadFile(fileName);
                    Console.WriteLine(fileContent);
                }
                else
                {
                    Console.WriteLine("File not found!");
                }
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                
               return reader.ReadToEnd();
            }
        }
    }
}