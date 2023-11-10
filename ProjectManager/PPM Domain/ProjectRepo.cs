using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using PPM.Model;
 
namespace PPM.Domain
{
    public class ProjectRepo : IProject
    {
        Project ProjObj = new Project();
        EmployeeRepo empRepoObj = new();
        public static List<Project> projectsList = new List<Project>();
        public void AddProjects(int projectId, string projectName, DateTime startDate, DateTime endDate)
        {
            ProjObj.ProjectId = projectId;
            ProjObj.ProjectName = projectName;
            ProjObj.StartDate = startDate;
            ProjObj.EndDate = endDate;
            projectsList.Add(ProjObj);
        }
 
        public bool IsValidProjId(int projectId)
        {
            bool result1 = projectsList.Exists(item => item.ProjectId == projectId);
            return result1;
        }
 
 
        public void AddEmployeesToProject(int projectId, int employeeId)
        {
            bool checkProject = IsValidProjId(projectId);
            bool checkEmployee = empRepoObj.IsValidEmpId(employeeId);
            bool checkProjEmpList = false;
            if (checkProject)
            {
                if (checkEmployee)
                {
                    foreach (var item1 in projectsList)
                    {
                        foreach (var item2 in item1.ProjectEmployeeList)
                        {
                            if (item2 == employeeId)
                            {
                                checkProjEmpList = true;
                            }
                        }
                    }
                    if (checkProjEmpList)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("        Employee already exist in this Project        ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        foreach (var item in projectsList)
                        {
                            if (item.ProjectId == projectId)
                            {
                                item.ProjectEmployeeList.Add(employeeId);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("        Employee added successfully.......          ");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Employee not found");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Project not found");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
        }
 
        public void RemoveEmployeesFromProject(int projectId, int employeeId)
        {
            bool checkProject = IsValidProjId(projectId);
            if (checkProject)
            {
                bool checkEmployee = empRepoObj.IsValidEmpId(employeeId);
                if (checkEmployee)
                {
                    bool checkProjEmpList = false;
                    foreach (var item1 in projectsList)
                    {
                        foreach (var item2 in item1.ProjectEmployeeList)
                        {
                            if (item2 == employeeId)
                            {
                                checkProjEmpList = true;
                            }
                        }
                    }
                    if (checkProjEmpList)
                    {
                        foreach (var item in projectsList)
                        {
                            if (item.ProjectId == projectId)
                            {
                                item.ProjectEmployeeList.Remove(employeeId);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("        Employee removed successfully.......          ");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Employee not found");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Project not found");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
        }
    }
}