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

            var fileName = Path.Combine(directory.FullName,"data.txt");
            using (var reader = new StreamReader(fileName))
            {
                Console.SetIn(reader);
                Console.WriteLine(Console.ReadLine());
            }
        }
    }
}