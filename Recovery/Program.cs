using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Recovery
{
    class Program
    {
        //Need to add commands to allow users to go back to menu at any time
        //Maybe redo how I handle changing passwords
        static void Main(string[] args)
        {
            string welcome = "This Application is used to recover a user or data without having to be logged in. You will need to use the \"switch\" at least once in the boot terminal for this to work";
            Console.WriteLine(welcome);
            Menu();
        }
        public static void Menu()
        {
            Console.WriteLine("1. Switch/Revert");
            Console.WriteLine("2. Change Password");
            Console.WriteLine("3. Activate/Deactivate Accounts");
            Console.WriteLine("4. Reboot");
            Console.Write("> ");
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
                                SwitchVert();
                            }
                            catch (Exception e)
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
                                DisEnable();
                            }
                            catch (Exception e)
                            {
                                Console.Write(e);
                            }
                            break;
                        case 4:
                            try
                            {
                                Process.Start("cmd.exe", $"/c shutdown /r");
                                break;
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
                    Console.Clear();
                    Console.WriteLine("Sorry chump thats not a vailid input"); 
                    Console.ReadKey();
                    Menu();
                }
            }
        }
        public static void SwitchVert()
        {
            try
            {
                if (File.Exists("C\\Windows\\System32\\utilman1.exe"))
                {
                    File.Copy("C:\\Windows\\System32\\utilman1.exe", "C:\\Windows\\System32\\utilman.exe");
                    File.Delete("C:\\Windows\\System32\\utilman1.exe");
                }
                if (File.Exists("C:\\Windows\\System32\\cmd.exe") && File.Exists("C:\\Windows\\System32\\utilman.exe"))
                {
                    File.Copy("C:\\Windows\\System32\\utilman.exe", "C:\\Windows\\System32\\utilman1.exe");
                    File.Delete("C:\\Windows\\System32\\utilman.exe");
                    File.Copy("C:\\Windows\\System32\\cmd.exe", "C:\\Windows\\System32\\utilman.exe");
                    Console.WriteLine("Finished");
                    Console.Write("To be able to change passwords you will need to reboot Windows and click the \"ease of access\" button (bottom right of the screen) " +
                        "and either in cmd navigate to the drive and execute this program again to automatically change stuff or do it directly in cmd");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Files are either not named correctly or are missing.");
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write(e);
                Console.ReadKey();
                Menu();
            }
        }
        public static void Password()
        {
            try
            {
                Console.Write("Current Users:");
                Process.Start("cmd.exe", "/c net user");
                Thread.Sleep(100);
                Console.WriteLine("Enter user you want to change password");
                Console.Write(">");
                string user = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string pass = Console.ReadLine();
                Process.Start("cmd.exe", $"/c net user {user} {pass}");
                Console.WriteLine("Finished");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.Write(e);
                Console.ReadKey();
                Menu();
            }
        }
        public static void DisEnable()
        {
            try
            {
                Console.Write("Current Users:");
                Process.Start("cmd.exe", "/c net user");
                Thread.Sleep(100);
                Console.WriteLine("Type {USER} {ENABLE\\DISABLE}");
                Console.Write(">");
                string endis = Console.ReadLine();
                string[] myarray = new string[2];
                myarray = endis.Split(' ');
                if (myarray[1].ToLower() == "enable")
                {
                    Process.Start("cmd.exe", $"/c net user {myarray[0]} /active:yes");
                }
                if (myarray[1].ToLower() == "disable")
                {
                    Process.Start("cmd.exe", $"/c net user {myarray[0]} /active:no");
                }
                Console.WriteLine("Finished");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write(e);
                Console.ReadKey();
                Menu();
            }
        }
    }
}
