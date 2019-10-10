using System;

namespace Ascii_Combiner
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = new String[args.Length];

            for (int i=0; i< args.Length; i++)
            {
                try
                {
                    files[i] = System.IO.File.ReadAllText("TestData/" + args[i]);
                }catch(Exception ex)
                {
                    Console.WriteLine("File not found");
                }
            }
            Logic l = new Logic();
            Console.WriteLine(l.combine(files));

        }
    }
}
