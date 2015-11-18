using EducationDegree.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace EducationDegree.UI
{
    public partial class searchPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.InnerHtml = setDate();
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
        public string setDate()
        {
            PersianCalendar pdate = new PersianCalendar();
            DateTime nT = new DateTime();
            nT = DateTime.Now;
            string mounth = "";
            if (pdate.GetMonth(nT).ToString().Length == 1)
                mounth = "0" + pdate.GetMonth(nT).ToString();
            else
                mounth = pdate.GetMonth(nT).ToString();
            string day = "";
            if (pdate.GetDayOfMonth(nT).ToString().Length == 1)
                day = "0" + pdate.GetDayOfMonth(nT).ToString();
            else
                day = pdate.GetDayOfMonth(nT).ToString();
            string date = String.Format("{0}/{1}/{2}", pdate.GetYear(nT), mounth, day);
            return date;
        }
    }
}