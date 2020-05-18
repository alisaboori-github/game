using System;
using System.Collections.Generic;
namespace game
{
    public class easy
    {
        #region add word
        private List<string> words = new List<string>();
        public List<string> Words
        {
            get { return words; }
            set { words = value; }
        }
        private string word;
        public string Word 
        {
            get { return Word; }
            set
            {
                if (value.Length>5)
                {
                    Console.WriteLine("*** If you want to add word upto 5 letter cahnge your mode to hard or just geuss ***");
                }
                else
                {
                    if (value.Contains("0")|| value.Contains("1")|| value.Contains("2")|| value.Contains("3")|| value.Contains("4")|| value.Contains("5")|| value.Contains("6")|| value.Contains("7")|| value.Contains("8")|| value.Contains("9"))
                    {
                        Console.WriteLine("*** Words can't have numbers in it ***");
                    }
                    else
                    {
                        word = value;
                    }
                }
            }
        } 
        public int Addword(string Sword)
        {
            Word = Sword;
            Words.Add(Word);
            return 0;
        }

        #endregion

        #region show game
        Random rand = new Random();
        public void ShowWord() 
        {
            // identify parametrs
            List<string> temp = words;
            int listLength = temp.Count;
            Stack<string> wordstack = new Stack<string>();
            //put list's items randomly in stack 
            for (int i = listLength; i > 0; i--)
            {
                int tempNum = rand.Next(0, i);
                wordstack.Push(temp[tempNum]);
                temp.RemoveAt(tempNum);
            }
            //change place of tempstcak by wordstack to remove part of shown string
            string[] temparry = new string[wordstack.Count];
            string[] temparry2 = new string[wordstack.Count];
            wordstack.CopyTo(temparry, 0);
            wordstack.CopyTo(temparry2, 0);
            Stack<string> tempstack = new Stack<string>(temparry2);
            //remove part of shown string
            for (int i = temparry.Length-1; i >= 0; i--)
            {
                int[] randNums = new int[3]; 
                string tempstr = temparry[i];
                char[] tempchar = new char[tempstr.Length]; 
                tempstr.CopyTo(0, tempchar, 0, tempstr.Length);
                foreach (var a in randNums)
                {
                    randNums[a] = rand.Next(0, tempstr.Length); 
                    tempchar[randNums[a]] = '_';
                }
                tempstr = new string(tempchar);
                tempstack.Push(tempstr);
            }
            wordstack = tempstack;

            //show stack's items & check the answer
            for (int i = listLength; i > 0; i--)
            {
                string shownStr = wordstack.Pop();
                string keeper = shownStr;
                char[] tempchar = new char[shownStr.Length];
                char[] tempchar2 = new char[shownStr.Length];
                shownStr.CopyTo(0, tempchar, 0, shownStr.Length);
                shownStr.CopyTo(0, tempchar2, 0, shownStr.Length);
                Console.WriteLine(shownStr);
                Console.WriteLine("-------------------\nenter your answer");
                for (int time = 3; time > 0; time--)
                {
                    string answer = Console.ReadLine();
                    for (int j = 0, z = 0; j < shownStr.Length; j++)
                    {
                        if (shownStr[j] == '_')
                        {
                            try
                            {
                                tempchar[j] = answer[z];
                                z++;
                            }
                            catch (SystemException)
                            {
                                Console.WriteLine("your answer is not complite try again");
                                break;
                            }

                        }
                    }
                    keeper = new string(tempchar);
                    bool check = false;
                    for (int x = 0; x < temparry2.Length; x++)
                    {
                        if (keeper == temparry2[x])
                        {
                            check = true;
                            break;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    if (check == true)
                    {
                        Console.WriteLine("correct");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("you're worng \t you have"+$"{ time - 1}" +"chance left");
                        tempchar = tempchar2;
                    }
                }
                Console.WriteLine("*** Do you want to continue? ***\n1-yes\t\t2-no");
                if (Console.ReadLine()=="1")
                {

                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("*** You riched to END of game ***");

        }
        #endregion

    }
}
