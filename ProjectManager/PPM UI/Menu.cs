using System;
 
namespace PPM.UI
{
    public class ProgramMenu
    {
        public int MainMenu()
        {
            int option;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------PROLIFICSPROJECTMANAGER----------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************************");
            Console.WriteLine("||       ---Enter the menu option---                ||");
            Console.WriteLine("||          1.Project Module                        ||");
            Console.WriteLine("||          2.Employee Module                       ||");
            Console.WriteLine("||          3.Role Module                           ||");
            Console.WriteLine("||          4.Quit                                  ||");
            Console.WriteLine("*****************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the required option:");
            option = int.Parse(Console.ReadLine());
 
            return option;
        }
 
        public int ProjectModuleMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************************");
            Console.WriteLine("||       ---Enter the Project Module option---      ||");
            Console.WriteLine("||          1. Add                                ||");
            Console.WriteLine("||          2. List All                           ||");
            Console.WriteLine("||          3. List By Id                         ||");
            Console.WriteLine("||          4. Delete                             ||");
            Console.WriteLine("||          5. Return to Main Menu                ||");
            Console.WriteLine("*****************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the required option:");
            int optionProj = int.Parse(Console.ReadLine());
 
            return optionProj;
        }
 
        public int EmployeeModuleMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************************");
            Console.WriteLine("||       ---Enter the Employee Module option---     ||");
            Console.WriteLine("||          1. Add                                ||");
            Console.WriteLine("||          2. List All                           ||");
            Console.WriteLine("||          3. List By Id                         ||");
            Console.WriteLine("||          4. Delete                             ||");
            Console.WriteLine("||          5. Return to Main Menu                ||");
            Console.WriteLine("*****************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the required option:");
            int optionEmp = int.Parse(Console.ReadLine());
 
            return optionEmp;
        }
 
        public int RoleModuleMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************************");
            Console.WriteLine("||       ---Enter the Role Module option---     ||");
            Console.WriteLine("||          1. Add                                ||");
            Console.WriteLine("||          2. List All                           ||");
            Console.WriteLine("||          3. List By Id                         ||");
            Console.WriteLine("||          4. Delete                             ||");
            Console.WriteLine("||          5. Return to Main Menu                ||");
            Console.WriteLine("*****************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the required option:");
            int optionRole = int.Parse(Console.ReadLine());
 
            return optionRole;
        }
    }
}