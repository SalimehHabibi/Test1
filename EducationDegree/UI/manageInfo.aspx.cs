using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using EducationDegree.POL;
using EducationDegree.BLL;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Security;


namespace EducationDegree.UI
{
    public partial class manageInfo : System.Web.UI.Page
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
        public static string FillCmbField()
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.FillCmbField());
        }
        
        [WebMethod(EnableSession = true)]
        public static string FillCmbPost()
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.FillCmbPost());
        }
        [WebMethod(EnableSession = true)]
        public static string FillCmbGrade()
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.FillCmbGrade());
        }
       
        [WebMethod(EnableSession = true)]
        public static string FillCmbTendency(int fieldCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.FillCmbTendency(fieldCode));
        }

        [WebMethod(EnableSession = true)]
        public static string FillCmbTendency1()
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.FillCmbTendency1());
        }

        [WebMethod(EnableSession = true)]
        public static string PostFieldReq(int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.PostFieldReq(firstRow));
        }
       
        [WebMethod(EnableSession = true)]
        public static string SearchByPostName(string postName, int firstRow)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.SearchByPostName(postName, firstRow));
        }
        
        [WebMethod(EnableSession = true)]
        public static string searchpostFieldForEdit(int postFieldCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.searchpostFieldForEdit(postFieldCode));
        }
        
        [WebMethod(EnableSession = true)]
        public static string saveReqPostField(List<postFieldInfo> pfr)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.saveReqPostField(pfr));
        }
        [WebMethod(EnableSession = true)]
        public static string FillPostSection(int postCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.FillPostSection(postCode));
        }
       
        [WebMethod(EnableSession = true)]
        public static string UpdateReq(postFieldInfo rn)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.UpdateReq(rn));
        }
        
       [WebMethod(EnableSession = true)]
        public static string showFieldDetail(int reqCode)
        {
            manageBLL mb = new manageBLL();
            return JsonConvert.SerializeObject(mb.showFieldDetail(reqCode));
        }
    }
}