using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationDegree.POL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EducationDegree.DALL
{
    class dataAccess
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        string location = System.AppDomain.CurrentDomain.BaseDirectory;
        public SqlTransaction trans;

        public dataAccess()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
            cmd.Connection = con;
        }
        //********************************************************
        /// <summary>
        /// connet to DB
        /// </summary>
        public void connect()
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["post"].ConnectionString;
               //con.ConnectionString = "Data Source=localhost;Initial Catalog=educationDegree;Integrated Security=True;";
               
                


                con.Open();
            }
            catch (Exception error)
            {
                // MessageBox.Show("اتصال با پایگاه داده برقرار نشد/خطای شماره1", "خطا");
                // MessageBox.Show(error.Message); to see what kind of error occurred
            }
        }
        //***********************************************************
        /// <summary>
        /// disconnet from DB
        /// </summary>
        public void disconnect()
        {
            con.Close();
        }
        //*************************************************************
        /// <summary>
        /// Excute query
        /// </summary>
        /// <param name="sql"></param>
        public void docommand(string sql)
        {
            cmd.CommandText = sql;
            da.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
        }
        //*************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable select(string sql)
        {
            cmd.CommandText = sql;
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void backupDB()
        {
            try
            {
                System.IO.File.Delete(@"" + location + @"database\gymDBBackFile.bak");

                //MessageBox.Show("لطفا تا اتمام عملیات صبور باشید.", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                string qry1;
                qry1 = "Backup Database AHP To Disk='" + @"" + location + @"database\AHPBackFile.bak" + "'";


                connect();
                SqlCommand com = new SqlCommand(qry1, con);
                com.ExecuteNonQuery();
                con.Close();
                // MessageBox.Show("عملیات گرفتن نسخه پشتیبان با موفقیت انجام شد.", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                // Application.Restart();
            }
            catch (Exception error)
            {
                //MessageBox.Show("عملیات ناموفق بود. ", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                //  MessageBox.Show(error.Message);
            }
        }

        public void restoreDB()
        {

            try
            {
                connect();
                // MessageBox.Show("لطفا تا اتمام عملیات صبور باشید.", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                string cmmnd = "USE MASTER RESTORE DATABASE AHP FROM DISK =   '" + location + @"database\AHPBackFile.bak" + "' WITH REPLACE";
                SqlCommand cmd2 = new SqlCommand(cmmnd, con);

                cmd2.ExecuteNonQuery();
                con.Close();

                // MessageBox.Show("عملیات بازیابی اطلاعات با موفقیت انجام شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                //this.Close();
                //Application.Restart();
            }
            catch (Exception error)
            {

                //MessageBox.Show("عملیات بازیابی ناموفق بود ", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                // MessageBox.Show(error.Message);
            }
        }
    }
}

