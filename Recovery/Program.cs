using System;
using System.IO;

namespace Recovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Menu();
        }
        public static void Menu()
        {
            Console.WriteLine("Switch cmd with ease of access");
            Console.WriteLine("Change Password(s)");
            Console.WriteLine("Activate/Deactivate Accounts");
            Console.WriteLine("Revert");
            Console.WriteLine("Reboot");
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
                                Password();
                            }
                            catch (Exception e)
                            {
                                Console.Write(e);
                            }
                            break;
                        case 3:
                            try
                            {
                                Account();
                            }
                            catch (Exception e)
                            {
                                Console.Write(e);
                            }
                            break;
                        case 4:
                            try
                            {
                                Revert();
                            }
                            catch (Exception e)
                            {
                                Console.Write(e);
                            }
                            break;
                        case 5:
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
                if (File.Exists("C:\\Windows\\System32\\cmd.exe") && File.Exists("C:\\Windows\\System32\\utilman.exe"))
                {
                    File.Copy("C:\\Windows\\System32\\utilman.exe", "C:\\Windows\\System32\\utilman1.exe");
                    File.Delete("C:\\Windows\\System32\\Utilman.exe");
                    File.Copy("C:\\Windows\\System32\\cmd.exe", "C:\\Windows\\System32\\utilman.exe");
                    Console.WriteLine("Finished");
                    Console.Write("To be able to change passwords you will need to reboot Windows and click the \"ease of access\" button (bottom right of the screen) " +
                        "and either navigate to the drive and execute this program again to automatically change stuff or do it directly in cmd");
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
        public static void Password()
        {

        }
        public static void Account()
        {

        }
        public static void Revert()
        {

        }
    }
}
