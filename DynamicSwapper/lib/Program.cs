using DynamicSwapper.lib.Core;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DynamicSwapper
{
    internal class Program
    {
        static HexMemory memory = new HexMemory();
        static void Main(string[] args)
        {
            Console.WriteLine($@"
   _____ _                       _       _____                              _           _    _____                                    
  / ____| |                     ( )     |  __ \                            (_)         | |  / ____|                                   
 | (___ | |_ ___  _ __ _ __ ___ |/ ___  | |  | |_   _ _ __   __ _ _ __ ___  _  ___ __ _| | | (_____      ____ _ _ __  _ __   ___ _ __ 
  \___ \| __/ _ \| '__| '_ ` _ \  / __| | |  | | | | | '_ \ / _` | '_ ` _ \| |/ __/ _` | |  \___ \ \ /\ / / _` | '_ \| '_ \ / _ \ '__|
  ____) | || (_) | |  | | | | | | \__ \ | |__| | |_| | | | | (_| | | | | | | | (_| (_| | |  ____) \ V  V / (_| | |_) | |_) |  __/ |   
 |_____/ \__\___/|_|  |_| |_| |_| |___/ |_____/ \__, |_| |_|\__,_|_| |_| |_|_|\___\__,_|_| |_____/ \_/\_/ \__,_| .__/| .__/ \___|_|   
                                                 __/ |                                                         | |   | |              
                                                |___/                                                          |_|   |_|              
");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("All swaps will be written in memory now, please be patient.");

            foreach (var json in Directory.GetFiles(Environment.CurrentDirectory + "\\Swaps"))
            {
                memory.WriteHex(GetResult(json, "hexCode1"), GetResult(json, "file1"), int.Parse(GetResult(json, "offset")));
                memory.WriteHex(GetResult(json, "hexCode2"), GetResult(json, "file2"), int.Parse(GetResult(json, "offset2")));
                memory.WriteHex(GetResult(json, "hexCode3"), GetResult(json, "file3"), int.Parse(GetResult(json, "offset3")));
                Console.ForegroundColor = ConsoleColor.Green;
                FileInfo file = new FileInfo(json);
                Console.WriteLine("\n[+] Swapped " + file.FullName);
            }
            Console.WriteLine("Memory has been released and the dynamical swapper can be closed now.");
            Console.ReadLine();

        }

        public static string GetResult(string fileStr, string str)
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(fileStr));

            return $"{jsonFile[str]}";
        }
    }
}
