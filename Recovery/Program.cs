using System;
using System.IO;

namespace Recovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("Step 2");
            Console.WriteLine("Revert");
            var tmp = Console.ReadLine();
            _ = int.TryParse(tmp, out int select);

            while (true)
            {
                try
                {
                    switch (select)
                    {
                        case 1:
                            try
                            {
                                Switch();
                            }
                            catch(Exception e)
                            {
                                Console.Write(e);
                            }
                            break;
                        case 2:
                            try
                            {

                            }
                            catch (Exception e)
                            {
                                Console.Write(e);
                            }
                            break;
                        case 3:
                            try
                            {

                            }
                            catch (Exception e)
                            {
                                Console.Write(e);
                            }
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Sorry chump thats not a vailid input");
                }
            }
        }
        public static void Switch()
        {
            try
            {
                if (File.Exists("C:\\Windows\\System32\\cmd.exe"))
                {

                    Console.Write("Finished");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void ChangeMenu()
        {

        }
    }
}
