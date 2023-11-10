namespace PPM.Model
{
    public interface IRole
    {
        public void AddRoles(int roleId, string roleName);
        public bool IsValidRoleId(int roleId);
 
 
    }
}