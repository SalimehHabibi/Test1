using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EducationDegree.POL;
using EducationDegree.BLL;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Security;

namespace EducationDegree.UI
{

    public partial class search : System.Web.UI.Page
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
        public static string SearchInTable(string fieldName, string tendencyName, string gardeName,int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.SearchInTable(fieldName, tendencyName, gardeName, firstRow));
        }
        
        [WebMethod(EnableSession = true)]
        public static string PostFieldReq()
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.PostFieldReq1());
        }
    }
}