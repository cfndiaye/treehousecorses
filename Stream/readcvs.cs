namespace treehouse
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class ReadCsv
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
                    /*
                    var fileContent = ReadFile(fileName);
                    string[] fileLines = fileContent.Split(new char[]{'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in fileLines){
                    Console.WriteLine(line);
                    }
                    */
                    var fileContent = ReadResults(fileName);
                    foreach(var content in fileContent)
                    {
                        for(int i = 0; i < content.Length; i++)
                        {
                          Console.Write(content[i] + " | ");
                        }
                        Console.WriteLine(" ");
                    }
                    
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

        public static List<string[]> ReadResults(string fileName)
        {
            var results = new List<string[]>();

            using( var reader = new StreamReader(fileName))
                {
                    string line = "";
                    reader.ReadLine();
                    while((line =reader.ReadLine()) != null){
                        var gameResult = new GameResult();
                        string[] values = line.Split(',');
                        
                        DateTime gameDate;
                        if(DateTime.TryParse(values[0], out gameDate))
                        {
                            gameResult.GameDate = gameDate;
                        }
                        string teamName = values[1];
                        gameResult.TeamName = teamName;

                        HomeOrAway homeOrAway;
                        if(Enum.TryParse(values[2], out homeOrAway))
                        {
                            gameResult.HomeOrAway = homeOrAway;
                        }

                        int goals;
                        if(int.TryParse(values[3], out goals))
                        {
                            gameResult.Goals = goals;
                        }

                        int goalAttemps;
                        if(int.TryParse(values[4], out goalAttemps))
                        {
                            gameResult.GoalAttemps = goalAttemps;
                        }
                        int shotsOnGoal;
                        if(int.TryParse(values[5], out shotsOnGoal))
                        {
                            gameResult.ShotsOnGoal = shotsOnGoal;
                        }

                        int shotsOffGoal;
                        if(int.TryParse(values[6], out shotsOffGoal))
                        {
                            gameResult.ShotsOffGoal = shotsOffGoal;
                        }

                        double possessionPercent;
                        if(double.TryParse(values[6], out possessionPercent))
                        {
                            gameResult.PossessionPercent = possessionPercent;
                        }



                        
                        results.Add(values);
                    }
                }
            
            return results;
        }

        public class GameResult
        {
            public DateTime GameDate { get; set;}
            public string TeamName {get; set;}
            public HomeOrAway HomeOrAway{get; set;}
            public int Goals {get; set;}
            public int GoalAttemps { get; set;}
            public int ShotsOnGoal {get; set;}
            public int ShotsOffGoal {get; set;}
            public double PossessionPercent {get; set;}
            public double ConversionRate {
                get{
                    return (double)Goals/GoalAttemps;
                }
            
            }

           
        }
         public enum HomeOrAway
            {
                Home,Away
            }
    }
}