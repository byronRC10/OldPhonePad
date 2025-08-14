
namespace OldPhonePadC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start typing (ESC to exit):");

            string output = "";
            DateTime lastKeyTime = DateTime.Now;
            TimeSpan waitTime = TimeSpan.FromSeconds(1);

            while (true)
            {
                var keyInfo = Console.ReadKey(true); 

                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                DateTime now = DateTime.Now;

                if (now - lastKeyTime > waitTime)
                {
                    output += " ";
                    Console.Write(" ");
                }

                output += keyInfo.KeyChar;
                Console.Write(keyInfo.KeyChar); 
                lastKeyTime = now;
            }

            string processed = Functions.ProcessOldPhonePad(output);
            Console.WriteLine("Processed by Functions: " + processed);
        }// main

    }// class

}// namesp

