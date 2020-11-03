using System;

namespace Acrom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a few words with spaces");
            string input = Console.ReadLine();
            string[] words = input.Split();
            foreach (var word in words)
            {
                string key = $"{word[0]}";
                // Console.Write(key);
                string upper = key.ToUpper();
                Console.Write(upper);
            }
        }
    }
}
