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
    public partial class PostManage : System.Web.UI.Page
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
        public static string PostReq(int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.PostReqSe(firstRow));
        }
        
        [WebMethod(EnableSession = true)]
        public static string saveReqPost(postInfo pr)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.saveReqPost(pr));
        }
        [WebMethod(EnableSession = true)]
        public static string PostReqSeByID(int postCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.PostReqSeByID(postCode));
        }
        
        [WebMethod(EnableSession = true)]
        public static string UpdateReqPost(postInfo rn)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.UpdateReqPost(rn));
        }
        
        [WebMethod(EnableSession = true)]
        public static string SearchByPostName(string postName, int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.SearchByPostName1(postName, firstRow));
        }
        [WebMethod(EnableSession = true)]
        public static string deletePost(int postCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.deletePost(postCode));
        }
    }
}