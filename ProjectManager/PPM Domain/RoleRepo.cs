using System;
using PPM.Model;
 
namespace PPM.Domain
{
    public class RoleRepo : IRole
    {
        Role RoleObj = new Role();
        public static List<Role> rolesList = new List<Role>();
        public void AddRoles(int roleId,string roleName)
        {
            RoleObj.RoleId = roleId;
            RoleObj.RoleName = roleName;
            rolesList.Add(RoleObj);
        }
       
        public bool IsValidRoleId(int roleId)
        {
            bool result3 = rolesList.Exists(item => item.RoleId == roleId);
            return result3;
        }
    }
}