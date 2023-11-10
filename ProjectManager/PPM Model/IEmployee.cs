namespace PPM.Model
{
    public interface IEmployee
    {
        public void AddEmployees(int employeeId,string firstName,string lastName,string email,string mobileNo,string address,int roleId);
        public bool IsValidEmpId(int employeeId);
    }
}