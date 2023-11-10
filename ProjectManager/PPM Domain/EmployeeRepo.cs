using System;
using PPM.Model;
 
namespace PPM.Domain
{
    public class EmployeeRepo : IEmployee
    {
        Employee EmpObj = new Employee();
 
        public static List<Employee> employeesList = new List<Employee>();
        public void AddEmployees(int employeeId,string firstName,string lastName,string email,string mobileNo,string address,int roleId)
        {
            EmpObj.EmployeeId = employeeId;
            EmpObj.FirstName = firstName;
            EmpObj.LastName = lastName;
            EmpObj.Email = email;
            EmpObj.MobileNo = mobileNo;
            EmpObj.Address = address;
            EmpObj.RoleId = roleId;
            employeesList.Add(EmpObj);
        }
       
        public bool IsValidEmpId(int employeeId)
        {
            bool result2 = employeesList.Exists(item => item.EmployeeId == employeeId);
            return result2;
        }
    }
}