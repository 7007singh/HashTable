using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    internal class Program
    {
        public static void CountFrequencyOfWords()
        {
            //string paragraph = "To be or not to be";
            string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            MyMapNode<string, int> hashTable = new MyMapNode<string, int>(6);
            string[] words = paragraph.ToLower().Split(' ');

            foreach(string word in words)
            {
                if (hashTable.Exists(word))
                {
                    hashTable.Add(word, hashTable.Get(word) + 1);
                }
                else
                {
                    hashTable.Add(word, 1);
                }
                Console.WriteLine("Displaying after add operation");
                hashTable.Display();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hash Table operations");
            CountFrequencyOfWords();
            Console.ReadLine();
        }
    }
}
