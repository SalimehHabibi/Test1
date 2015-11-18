using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EducationDegree.BLL;
using EducationDegree.POL;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Security;


namespace EducationDegree.UI
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["Name"].ToString() == "")
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (Exception)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        [WebMethod(EnableSession = true)]
        public static string creatReqUser(userInfo rn)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.creatReqUser(rn));
        }

        [WebMethod]
        public static string checkUserName(string userName)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.checkUserName(userName));
        }

        [WebMethod]
        public static string UserReq()
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.UserReq());
        }

        [WebMethod(EnableSession = true)]
        public static string deleteUser(int userCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.deleteUser(userCode));
        }

        [WebMethod]
        public static string logOut()
        {
          
            System.Web.HttpContext.Current.Session["Name"] = null;
            System.Web.HttpContext.Current.Session.Clear();
            return "";
        }
        
        [WebMethod]
        public static string ChangePass(string oldPass, string newPass)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.changePass(oldPass, newPass));
        }
    }
}