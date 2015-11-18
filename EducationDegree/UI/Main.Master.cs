using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace EducationDegree.UI
{
    public partial class Main : System.Web.UI.MasterPage
    {
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
        public string setTime()
        {
            PersianCalendar pdate = new PersianCalendar();
            DateTime nT = new DateTime();
            nT = DateTime.Now;
            string time = "";
            time = pdate.GetHour(nT) + ":" + pdate.GetMinute(nT);
            return time;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                txtUsername.InnerText = System.Web.HttpContext.Current.Session["Name"].ToString();
                txtDate.InnerHtml = setDate();
                // txthour.InnerHtml = setTime();
            }
           
                catch(Exception)
            {
               
            }
           
        }
    }
}