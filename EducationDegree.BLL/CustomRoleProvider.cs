using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using EducationDegree.POL;

namespace Ticketing.BLL
{
    public class CustomRoleProvider : System.Web.Security.SqlRoleProvider
    {
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
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
        public override string[] GetRolesForUser(string username)
        {
            return GetFormsIdentity().Ticket.UserData.Split('-');
        }
        public override string ApplicationName
        {
            get
            {
                return "reservation";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            if (Array.Find<string>(GetRolesForUser(username), s => s.Equals(roleName))=="")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        private static FormsIdentity GetFormsIdentity()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            FormsIdentity identity = new FormsIdentity(ticket);
            return identity;
        }
    }
}
