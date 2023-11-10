namespace PPM.Model
{
    public interface IProject
    {
        public void AddProjects(int projectId, string projectName, DateTime startDate, DateTime endDate);
        public bool IsValidProjId(int projectId);
        public void AddEmployeesToProject(int projectId, int employeeId);
        public void RemoveEmployeesFromProject(int projectId, int employeeId);
 
    }
}