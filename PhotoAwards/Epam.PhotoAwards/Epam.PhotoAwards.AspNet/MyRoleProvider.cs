using Epam.PhotoAwards.DAL.Interfaces;
using Epam.PhotoAwards.DependencyResolver;
using Epam.PhotoAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.PhotoAwards.AspNet
{
    public class MyRoleProvider : RoleProvider
    {
        private IUserDal userDal = DependencyResolver.DependencyResolver.UsersDal;
        public override string[] GetRolesForUser(string username)
        {
            User user = userDal.GetUserByEmail(username);
            if (user != null)
            {
                string[] roles = new string[1];
                roles[0] = user.Role.ToString();
                return roles;
            }
            return new string[0];
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            User user = userDal.GetUserByEmail(username);
            if (user != null && user.Role.ToString().Equals(roleName))
            {              
                return true;
            }
            return false;
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }        

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}