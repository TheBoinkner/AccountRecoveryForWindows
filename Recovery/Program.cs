using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Threading;

namespace Recovery
{
    class Program
    {
        static void Main(string[] args)
        {
            string welcome = "This Application is used to recover a user or data without having to be logged in. You will need to use the \"switch\" at least once in the boot terminal for this to work";
            Console.WriteLine(welcome);
            Menu();
        }
        public static void Menu()
        {
            Console.WriteLine("To display \"Help\" type /help");
            Console.WriteLine("1. Switch/Revert");
            Console.WriteLine("2. Change Password or Create an Account");
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
                                Console.Clear();
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
                                Process.Start("cmd.exe", $"/c shutdown /r /t0");
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
                Process.Start("cmd.exe", "/c net user");
                Thread.Sleep(100);
                Console.WriteLine("Enter User you would like to change password");
                Console.WriteLine("To ADD a user \"add {USER}\"");
                Console.WriteLine("To Delete a user \"delete {USER}\"");
                Console.Write("> ");
                string input = Console.ReadLine();
                Commands.SearchDic(input);
                string[] inarray = new string[2];
                inarray = input.Split(' ');
                if (inarray[0].ToLower() == "add")
                {
                    Process.Start("cmd.exe", $"/c net user {inarray[1]} /add");
                }
                if (inarray[0].ToLower() == "delete")
                {
                    Process.Start("cmd.exe", $"/c net user {inarray[1]} /delete");
                }
                if (inarray.Length == 1)
                {
                    SecureString securePwd = new SecureString();
                    SecureString securePwd2 = new SecureString();
                    ConsoleKeyInfo key;

                    Console.Write("Enter password: ");
                    do
                    {
                        key = Console.ReadKey(true);
                        // Ignore any key out of range.
                        if (((int)key.Key) >= 65 && ((int)key.Key <= 90))
                        {
                            // Append the character to the password.
                            securePwd.AppendChar(key.KeyChar);
                            Console.Write("*");
                        }
                        // Exit if Enter key is pressed.
                    } while (key.Key != ConsoleKey.Enter);
                    
                    Console.Write("Confirm password: ");
                    do
                    {
                        key = Console.ReadKey(true);
                        // Ignore any key out of range.
                        if (((int)key.Key) >= 65 && ((int)key.Key <= 90))
                        {
                            // Append the character to the password.
                            securePwd.AppendChar(key.KeyChar);
                            Console.Write("*");
                        }
                        // Exit if Enter key is pressed.
                    } while (key.Key != ConsoleKey.Enter);
                    if (securePwd == securePwd2)
                    {
                        Process.Start("cmd.exe", $"/c net user {securePwd}");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry chump thats not a vailid input");
                    Console.ReadKey();
                    Password();
                }
                Console.WriteLine("Finished");
                Console.ReadKey();
                Password();
                Console.Clear();
            }
            catch (Exception e)
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
                Process.Start("cmd.exe", "/c net user");
                Thread.Sleep(100);
                Console.WriteLine("Type {USER} {ENABLE\\DISABLE}");
                Console.Write("> ");
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
                DisEnable();
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
