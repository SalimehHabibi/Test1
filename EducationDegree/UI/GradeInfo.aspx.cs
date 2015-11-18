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
    public partial class GradeInfo : System.Web.UI.Page
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
        public static string GradeReq(int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.GradeReq(firstRow));
        }
        
        [WebMethod(EnableSession = true)]
        public static string saveReqGrade(gradeInfo gr)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.saveReqGrade(gr));
        }
        
        [WebMethod(EnableSession = true)]
        public static string deleteGrade(int gradeCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.deleteGrade(gradeCode));
        }
        
        [WebMethod(EnableSession = true)]
        public static string SearchByGradeName(string gradeName, int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.SearchByGradeName(gradeName, firstRow));
        }
    }

}