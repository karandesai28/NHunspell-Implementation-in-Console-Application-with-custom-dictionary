using NHunspell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a word:");
            string word = Console.ReadLine();
            bool check=CheckSpell(word);
            Console.WriteLine(check.ToString());
            Console.Read();
        }
               

        static bool CheckSpell(string word)
        {
            using (Hunspell hunspell = new Hunspell())
            {
                var affpath = Path.GetFullPath(@"..\..\Dictionaries\demo.aff");               
                string dicpath = Path.GetFullPath(@"..\..\Dictionaries\Dictionary.dic");
                hunspell.Load(affpath,dicpath);
                //Can add new words directly using this command: hunspell.Add(Word);

                var suggestions=hunspell.Suggest(word);
                int count = suggestions.Count();
                Console.WriteLine("Did you mean:");
                for (var i = 0; i < count; i++)
                {
                    Console.WriteLine(suggestions[i]);
                }
                return hunspell.Spell(word);
            }
        }
    }
}
