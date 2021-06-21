using System;
using System.Collections.Generic;
using System.IO;

namespace DictionaryVotesEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> candidateVotes = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int votes = int.Parse(line[1]);
                        if (candidateVotes.ContainsKey(name))
                        {
                            candidateVotes[name] += votes;
                        }
                        else
                        {
                            candidateVotes[name] = votes;
                        }
                    }

                    foreach (KeyValuePair<string, int> item in candidateVotes)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
