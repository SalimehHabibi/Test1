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
    public partial class FieldManage : System.Web.UI.Page
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
        public static string FieldReq(int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.FieldReqSe(firstRow));
        }
        [WebMethod(EnableSession = true)]
        public static string creatReq(fieldInfo rn,List<tendencyInfo> rgr)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.creatReq(rn, rgr));
        }
        
        [WebMethod(EnableSession = true)]
        public static string TendencyReq(int fieldCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.TendencyReq(fieldCode));
        }
        
        [WebMethod(EnableSession = true)]
        public static string FieldReqSeByID(int fieldCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.FieldReqSeByID(fieldCode));
        }
        
        [WebMethod(EnableSession = true)]
        public static string UpdateReqField(fieldInfo rn, List<tendencyInfo> rgr, int fieldCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.UpdateReqField(rn, rgr, fieldCode));
        }
        
        [WebMethod(EnableSession = true)]
        public static string UpdateTendency(List<tendencyInfo> rgr, int fieldCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.UpdateReqField(rgr, fieldCode));
        }

        [WebMethod(EnableSession = true)]
        public static string SearchByFieldName(string fieldName, int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.SearchByFieldName(fieldName, firstRow));
        }
        [WebMethod(EnableSession = true)]
        public static string deleteField(int fieldCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.deleteField(fieldCode));
        }
    }
}