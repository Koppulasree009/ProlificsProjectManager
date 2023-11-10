using System;
using System.Collections;
using PPM.UI;
using PPM.Domain;
 
namespace PPM.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            int option;
            ProgramMenu MenuObj = new();
            ReadWrite rwObj = new();
           
            while(true)
            {
                option = MenuObj.MainMenu();
 
                switch (option)
                {
                    case 1:
                        ProjectMenu();
                        break;
                    case 2:
                        EmployeeMenu();
                        break;
                    case 3:
                        RoleMenu();
                        break;
                    case 4:
                        rwObj.ExitingStatement();
                        return;
                    default:
                        rwObj.Exception();
                        break;
                }
            }
        }
 
        public static void ProjectMenu()
        {
            int optionProj;
            ProgramMenu MenuObj = new();
            ReadWrite rwObj = new();
            while(true)
            {
                optionProj = MenuObj.ProjectModuleMenu();
                switch (optionProj)
                {
                    case 1:
                        rwObj.AddProjectsRepo();
                        break;
                    case 2:
                        rwObj.ViewProjectsRepo();
                        break;
                    case 3:
                        rwObj.ViewProjectsByIdRepo();
                        break;
                    case 4:
                        rwObj.DeleteProjectRepo();
                        break;  
                    case 5:
                        return;
                    default:
                        rwObj.Exception();
                        break;
                }
            }
        }
 
        public static void EmployeeMenu()
        {
            int optionEmp;
            ReadWrite rwObj = new();
            ProgramMenu MenuObj = new();
            while(true)
            {
                optionEmp = MenuObj.EmployeeModuleMenu();
                switch (optionEmp)
                {
                    case 1:
                        rwObj.AddingEmployees();
                        break;
                    case 2:
                        rwObj.ViewEmployeesRepo();
                        break;
                    case 3:
                        rwObj.ViewEmployeesByIdRepo();
                        break;
                    case 4:
                        rwObj.DeleteEmployeeRepo();
                        break;
                    case 5:
                        rwObj.ExitingStatement();
                        return;
                    default:
                        rwObj.Exception();
                        break;
                }
            }
        }
 
        public static void RoleMenu()
        {
            int optionRole;
            ProgramMenu MenuObj = new();
            ReadWrite rwObj = new();
            while(true)
            {
                optionRole = MenuObj.RoleModuleMenu();
                switch (optionRole)
                {
                    case 1:
                        rwObj.AddRolesRepo();
                        break;
                    case 2:
                        rwObj.ViewRolesRepo();
                        break;
                    case 3:
                        rwObj.ViewRolesByIdRepo();
                        break;
                    case 4:
                        rwObj.DeleteRoleRepo();
                        break;
                    case 5:
                        return;        
                    default:
                        rwObj.Exception();
                        break;
                }
            }
        }
    }
}
 