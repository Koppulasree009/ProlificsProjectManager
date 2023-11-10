using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using PPM.Domain;
using PPM.Model;
 
namespace PPM.UI
{
    public class ReadWrite
    {
        ProjectRepo projObj = new();
        RoleRepo roleObj = new();
        Project projObject = new();
        EmployeeRepo empRepoObj = new();
 
        //-------------------------------------------------------------------------------------option 1.1 :
        public void AddProjectsRepo()
        {
            System.Console.WriteLine("Enter an option : \n 1. Add a new Project 2. Add Employees and Roles to the Existing Project");
            int option = int.Parse(Console.ReadLine());
 
            if (option == 1)
            {
                AddProjects();
            }
            else if (option == 2)
            {
                AddingEmployeeToProject();
            }
            else
            {
                Exception();
            }
        }
 
        public void AddProjects()
        {
            int projectId;
            DateTime endDate;
 
            while (true)
            {
                Console.WriteLine("Enter the Project Id : ");
                projectId = int.Parse(Console.ReadLine());
 
                bool checkProjId = projObj.IsValidProjId(projectId);
                if (checkProjId)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Project Id which you've entered is already exists");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    continue;
                }
                break;
            }
 
            Console.WriteLine("Enter the Project Name : ");
            string projectName = Console.ReadLine();
 
            Console.WriteLine("Enter the Project StartDate : ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
 
            while (true)
            {
                Console.WriteLine("Enter the Project EndDate : ");
                endDate = DateTime.Parse(Console.ReadLine());
 
                if (startDate > endDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter the correct End Date.....The End Date should be after the Project Start Date");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    continue;
                }
                break;
            }
            projObj.AddProjects(projectId, projectName, startDate, endDate);
        }
 
 
        public void AddingEmployeeToProject()
        {
            Console.WriteLine("Enter the Project Id : ");
            int projectId = int.Parse(Console.ReadLine());
 
            Console.WriteLine("Enter the Employee Id : ");
            int employeeId = int.Parse(Console.ReadLine());
 
            projObj.AddEmployeesToProject(projectId, employeeId);
        }
 
 
        //-------------------------------------------------------------------------------------option 1.2 :
        public void ViewProjectsRepo()
        {
            System.Console.WriteLine("Enter an option : \n 1. View Projects 2.View Project Details ");
            int option = int.Parse(Console.ReadLine());
 
            if (option == 1)
            {
                ViewProjects();
            }
            if (option == 2)
            {
                ViewProjectDetails();
            }
        }
 
        public List<Project> ViewProjects()
        {
            List<Project> projListObj = new();
            bool isEmpty = !ProjectRepo.projectsList.Any();
            if (isEmpty)
            {
                System.Console.WriteLine("The Project List is empty");
                return projListObj;
            }
            else
            {
                foreach (Project proj in ProjectRepo.projectsList)
                {
                    System.Console.WriteLine($"ProjectId : {proj.ProjectId}, ProjectName : {proj.ProjectName}, StartDate : {proj.StartDate}, EndDate : {proj.EndDate}");
                    projListObj.Add(proj);
                }
                return projListObj;
            }
        }
 
 
        public List<Project> ViewProjectDetails()
        {
            List<Project> viewProjList = new();
            foreach (Project proj in ProjectRepo.projectsList)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                System.Console.WriteLine($"-----Project Details : -----\n ProjectId : {proj.ProjectId}, ProjectName : {proj.ProjectName}, StartDate : {proj.StartDate}, EndDate : {proj.EndDate}");
                var query = from employee in EmployeeRepo.employeesList
                            group employee by employee.RoleId into employeeGroups
                            select employeeGroups;
                foreach (var group in query)
                {
                    var key = RoleRepo.rolesList.FirstOrDefault(i => i.RoleId == group.Key);
                    var rolequery = key.RoleName;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("         Employees working under Role Id : {0}, Role Name : {1}        ", group.Key, rolequery);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
 
                    foreach (Employee employee in group)
                    {
                        if (proj.ProjectEmployeeList.Exists(id => id == employee.EmployeeId))
                        {
                            System.Console.WriteLine($"Employee Id : {employee.EmployeeId}, Employee FirstName : {employee.FirstName}, Employee LastName : {employee.LastName}");
                        }
                    }
                    viewProjList.Add(proj);
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            return viewProjList;
        }
 
 
        //-------------------------------------------------------------------------------------option 1.3 :
 
        public void ViewProjectsByIdRepo()
        {
            System.Console.WriteLine("Enter the Project Id you want to display :  ");
            int projectId = int.Parse(Console.ReadLine());
 
            bool isEmpty = !ProjectRepo.projectsList.Any();
            if (isEmpty)
            {
                System.Console.WriteLine("The Project List is empty");
            }
            else
            {
                bool isValidId = projObj.IsValidProjId(projectId);
                if (isValidId)
                {
                    var key = ProjectRepo.projectsList.FirstOrDefault(i => i.ProjectId == projectId);
                    System.Console.WriteLine($"ProjectId : {key.ProjectId}, ProjectName : {key.ProjectName}, StartDate : {key.StartDate}, EndDate : {key.EndDate}");
                }
                else
                {
                    System.Console.WriteLine("The Project Id which you've entered in invalid");
                }
            }
        }
 
        //-------------------------------------------------------------------------------------option 1.4 :
        public void DeleteProjectRepo()
        {
            System.Console.WriteLine("Enter an option : \n 1. Delete Project 2.Delete Employee from Project ");
            int option = int.Parse(Console.ReadLine());
 
            if (option == 1)
            {
                DeleteProject();
            }
            if (option == 2)
            {
                RemovingEmployeesFromProject();
            }
        }
        public void DeleteProject()
        {
            System.Console.WriteLine("Enter the Project Id which you want to delete :  ");
            int projectId = int.Parse(Console.ReadLine());
 
            bool isEmpty = !ProjectRepo.projectsList.Any();
            if (isEmpty)
            {
                System.Console.WriteLine("The Roles List is empty");
            }
            else
            {
                bool isValidProjId = projObj.IsValidProjId(projectId);
                if (isValidProjId)
                {
                    var proj = ProjectRepo.projectsList.FirstOrDefault(p => p.ProjectId == projectId);
                    ProjectRepo.projectsList.Remove(proj);
                    System.Console.WriteLine("The Project removed successfully......");
                }
                else
                {
                    System.Console.WriteLine("The Project Id which you've entered doesn't exist in the list");
                }
            }
        }
 
        public void RemovingEmployeesFromProject()
        {
            Console.WriteLine("Enter the Project Id : ");
            int projectId = int.Parse(Console.ReadLine());
 
            Console.WriteLine("Enter the Employee Id : ");
            int employeeId = int.Parse(Console.ReadLine());
 
            projObj.RemoveEmployeesFromProject(projectId, employeeId);
        }
 
 
        //-------------------------------------------------------------------------------------option 2.1 :
        public void AddingEmployees()
        {
            if (RoleRepo.rolesList.Count == 0)
            {
                System.Console.WriteLine("---Please enter role info---");
                AddRolesRepo();
                AddEmployeesRepo();
            }
            else
            {
                AddEmployeesRepo();
            }
        }
 
        public void AddEmployeesRepo()
        {
            int employeeId, roleId;
            string email, mobileNo;
            while (true)
            {
                Console.WriteLine("Enter the Employee Id : ");
                employeeId = int.Parse(Console.ReadLine());
 
                bool checkEmpId = empRepoObj.IsValidEmpId(employeeId);
                if (checkEmpId)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Employee Id which you've entered is already exists");
                    Console.WriteLine("Please enter new Employee Id");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    continue;
                }
                break;
            }
 
            Console.WriteLine("Enter the Employee First Name : ");
            string firstName = Console.ReadLine()!;
 
            Console.WriteLine("Enter the Employee Last Name : ");
            string lastName = Console.ReadLine();
 
            while (true)
            {
                Console.WriteLine("Enter the Email : ");
                email = Console.ReadLine();
 
                if (email != null)
                {
                    string emailExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    bool email1 = Regex.IsMatch(email, emailExpression);
                    if (email1 == false)
                    {
                        Console.WriteLine("Please enter the correct email");
                        continue;
                    }
                    break;
                }
            }
 
            while (true)
            {
                Console.WriteLine("Enter the Phone No. : ");
                mobileNo = Console.ReadLine();
 
                if (mobileNo != null)
                {
                    string phoneExpression = @"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$";
                    bool mobileNo1 = Regex.IsMatch(mobileNo, phoneExpression);
                    if (mobileNo1 == false)
                    {
                        Console.WriteLine("Please enter the correct MobileNo");
                        continue;
                    }
                    break;
                }
            }
 
            Console.WriteLine("Enter the Address : ");
            string address = Console.ReadLine();
 
            while (true)
            {
                Console.WriteLine("Enter the Role Id : ");
                roleId = int.Parse(Console.ReadLine());
 
                bool checkRoleById = roleObj.IsValidRoleId(roleId);
                if (checkRoleById == false)
                {
                    System.Console.WriteLine("---Please enter the valid Role Id---");
                    continue;
                }
                break;
            }
            empRepoObj.AddEmployees(employeeId, firstName, lastName, email, mobileNo, address, roleId);
        }
 
 
        //-------------------------------------------------------------------------------------option 2.2 :
        public List<Employee> ViewEmployeesRepo()
        {
            List<Employee> empListObj = new();
            bool isEmpty = !EmployeeRepo.employeesList.Any();
            if (isEmpty)
            {
                System.Console.WriteLine("The Employee List is empty");
                return empListObj;
            }
            else
            {
                foreach (Employee emp in EmployeeRepo.employeesList)
                {
                    var key = RoleRepo.rolesList.FirstOrDefault(i => i.RoleId == emp.RoleId);
                    var rol = key.RoleName;
                    System.Console.WriteLine($"EmployeeId : {emp.EmployeeId}, EmployeeFirstName : {emp.FirstName}, EmployeeLastName : {emp.LastName}, Email : {emp.Email}, MobileNo : {emp.MobileNo}, Address : {emp.Address}, RoleId = {emp.RoleId}. Role Name : {rol}");
                    empListObj.Add(emp);
                }
                return empListObj;
 
            }
        }
 
        //-------------------------------------------------------------------------------------option 2.3 :
        public void ViewEmployeesByIdRepo()
        {
            System.Console.WriteLine("Enter the Employee Id you want to display :  ");
            int employeeId = int.Parse(Console.ReadLine());
 
            bool isEmpty = !EmployeeRepo.employeesList.Any();
            if (isEmpty)
            {
                System.Console.WriteLine("The Employee List is empty");
            }
            else
            {
                bool isValidId = empRepoObj.IsValidEmpId(employeeId);
                if (isValidId)
                {
                    var emp = EmployeeRepo.employeesList.FirstOrDefault(e => e.EmployeeId == employeeId);
                    var key = RoleRepo.rolesList.FirstOrDefault(i => i.RoleId == emp.RoleId);
                    var rol = key.RoleName;
                    System.Console.WriteLine($"EmployeeId : {emp.EmployeeId}, EmployeeFirstName : {emp.FirstName}, EmployeeLastName : {emp.LastName}, Email : {emp.Email}, MobileNo : {emp.MobileNo}, Address : {emp.Address}, RoleId = {emp.RoleId}. Role Name : {rol}");
                }
                else
                {
                    System.Console.WriteLine("The Employee Id which you've entered in invalid");
                }
            }
        }
 
        //-------------------------------------------------------------------------------------option 2.4 :
        public int DeleteEmployeeRepo()
        {
            System.Console.WriteLine("Enter the Employee Id  which you want to delete :  ");
            int employeeId = int.Parse(Console.ReadLine());
 
            bool isEmpty = !EmployeeRepo.employeesList.Any();
            if (isEmpty)
            {
                System.Console.WriteLine("The Employees List is empty");
            }
            else
            {
                bool checkEmpId = false;
                bool isValidEmpId = empRepoObj.IsValidEmpId(employeeId);
                if (isValidEmpId)
                {
                    foreach (var item in ProjectRepo.projectsList)
                    {
                        foreach (var emp in item.ProjectEmployeeList)
                        {
                            if (emp == employeeId)
                            {
                                checkEmpId = true;
                                if (checkEmpId)
                                {
                                    System.Console.WriteLine("The Employee is assigned to the Project \n Employee cannot be deleted........");
                                    System.Console.WriteLine("If you still want to Delete the employee....Press 1 or else Press 0");
                                    int res = int.Parse(Console.ReadLine());
                                    if (res == 1)
                                    {
                                        var result = EmployeeRepo.employeesList.FirstOrDefault(e => e.EmployeeId == employeeId);
                                        EmployeeRepo.employeesList.Remove(result);
                                        System.Console.WriteLine("The Employee removed successfully......");
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Quit Delete Employee from Project");
                                    }
                                }
                                else
                                {
                                    var result = EmployeeRepo.employeesList.FirstOrDefault(e => e.EmployeeId == employeeId);
                                    EmployeeRepo.employeesList.Remove(result);
                                    System.Console.WriteLine("The Employee removed successfully......");
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("The Employee Id which you've entered doesn't exist in the list");
                }
            }
            return employeeId;
        }
 
        //-------------------------------------------------------------------------------------option 3.1 :
        public void AddRolesRepo()
        {
            int roleId;
            RoleRepo AddRole = new();
 
            while(true)
            {
                Console.WriteLine("Enter the Role Id : ");
                roleId = int.Parse(Console.ReadLine());
 
                bool checkRoleId = roleObj.IsValidRoleId(roleId);
 
                if (checkRoleId)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("---The Role Id which you've entered is already exists---");
                    Console.WriteLine("---Please enter new Role Id---");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    continue;
                }
                break;
            }
 
            Console.WriteLine("Enter the Role Name : ");
            string roleName = Console.ReadLine();
 
            AddRole.AddRoles(roleId, roleName);
        }
 
        //-------------------------------------------------------------------------------------option 3.2 :
        public List<Role> ViewRolesRepo()
        {
            List<Role> roleListObj = new();
            bool isEmpty = !RoleRepo.rolesList.Any();
 
            if (isEmpty)
            {
                System.Console.WriteLine("The Roles List is empty");
                return roleListObj;
            }
            else
            {
                foreach (Role role in RoleRepo.rolesList)
                {
                    System.Console.WriteLine($"RoleId : {role.RoleId}, RoleName : {role.RoleName}");
                    roleListObj.Add(role);
                }
                return roleListObj;
            }
        }
 
        //-------------------------------------------------------------------------------------option 3.3 :
        public void ViewRolesByIdRepo()
        {
            System.Console.WriteLine("Enter the Role Id you want to display :  ");
            int roleId = int.Parse(Console.ReadLine());
 
            bool isEmpty = !RoleRepo.rolesList.Any();
            if (isEmpty)
            {
                System.Console.WriteLine("The Roles List is empty");
            }
            else
            {
                bool isValidId = roleObj.IsValidRoleId(roleId);
                if (isValidId)
                {
                    var role = RoleRepo.rolesList.FirstOrDefault(r => r.RoleId == roleId);
                    System.Console.WriteLine($"RoleId : {role.RoleId}, RoleName : {role.RoleName}");
                }
                else
                {
                    System.Console.WriteLine("The Role Id which you've entered in invalid");
                }
            }
        }
 
        //-------------------------------------------------------------------------------------option 3.4 :
        public void DeleteRoleRepo()
        {
            System.Console.WriteLine("Enter the Role Id you want to delete :  ");
            int roleId = int.Parse(Console.ReadLine());
 
            bool isEmpty = !RoleRepo.rolesList.Any();
            if (isEmpty)
            {
                System.Console.WriteLine("The Roles List is empty");
            }
            else
            {
                bool checkRoleId = false;
                bool isValidRoleId = roleObj.IsValidRoleId(roleId);
                if (isValidRoleId)
                {
                    foreach (var role in projObject.ProjectEmployeeList)
                    {
                        if (role == roleId)
                        {
                            checkRoleId = true;
                            if (checkRoleId)
                            {
                                System.Console.WriteLine("The Role is assigned to the Project \n Role cannot be deleted........");
                                System.Console.WriteLine("If you still want to delete the Role....Press 1 or else Press 0");
                                int res = int.Parse(Console.ReadLine());
                                if (res == 1)
                                {
                                    var result = RoleRepo.rolesList.FirstOrDefault(r => r.RoleId == roleId);
                                    RoleRepo.rolesList.Remove(result);
                                    System.Console.WriteLine("The Role removed successfully......");
                                }
                                else
                                {
                                    System.Console.WriteLine("Quit Delete Role from Project");
                                }
                            }
                            else
                            {
                                var result = RoleRepo.rolesList.FirstOrDefault(r => r.RoleId == roleId);
                                RoleRepo.rolesList.Remove(result);
                                System.Console.WriteLine("The Role removed successfully......");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("The Role Id which you've entered doesn't exist in the list");
                        }
                    }
                }
            }
        }
 
        public void ExitingStatement()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("        ---Thank you for using the Application---           ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        public void Exception()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("         ---Please enter the correct option---         ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
    }
}