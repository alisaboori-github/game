using System;
using System.IO;
namespace game
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            easy newEGame = new easy();
            string allWords = File.ReadAllText("../../../text.txt");
            string[] words = allWords.Split(' ');
            foreach (var word in words)
            {
                newEGame.Words.Add(word.ToLower());
            }
            while (true)
            {
                Console.WriteLine("*** Choose any monde *** \n1-Start\t\t2-Exit");
                string mode = Console.ReadLine();

                if (mode == "1" || mode == "2")
                {
                    if (mode == "1")
                    {
                        newEGame.ShowWord();
                    }
                    if (mode == "2") { Console.WriteLine("*** Good bye ***"); break; }
                }
                else
                {
                    Console.WriteLine("*** Just enter number of mode ***");

                }

                //Console.ReadKey();
            }
        }
    }
}
