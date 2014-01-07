using System;

namespace H.Crawly
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawTemplate = "My name is @test and @test asdjkfaskldjf";

            string test = new Crawly.Content.TestContentTemplate(rawTemplate).Result();

            Console.WriteLine("Done @ {0}", DateTime.Now);
            Console.WriteLine("Press key to exit.");
            Console.ReadLine();
        }
    }
}
