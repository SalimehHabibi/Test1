using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationDegree.DALL;
using EducationDegree.POL;
using System.Data;
using System.Globalization;

namespace EducationDegree.BLL
{
    public class manageBLL
    {
       
        public object FillCmbField()
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {
                HelperSearch sHelper = new HelperSearch();
                list = sHelper.fillCombo("fieldInfo", "fieldCode", "fieldName");
                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object FillCmbGrade()
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {
                HelperSearch sHelper = new HelperSearch();
                list = sHelper.fillCombo("gradeInfo", "gradeCode", "gradeName");
                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object FillCmbTendency(int fieldCode)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {
                HelperSearch sHelper = new HelperSearch();
                list = sHelper.fillComboTendency(fieldCode);
                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object PostFieldReq(int firstRow)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.searchPostFieldReq(firstRow, firstRow +6 -1);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object SearchByPostName(string postName, int firstRow)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.SearchByPostName(postName, firstRow, firstRow+6-1);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object postFieldSeByPostCode(int postCode)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.searchpostFieldByPostCode(postCode);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }
        public object searchpostFieldForEdit(int postFieldCode)
           {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.searchpostFieldForEdit(postFieldCode);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }
        

        //public object deletePostField(int postCode)
        //{
        //    Results<DataTable> result = new Results<DataTable>();
        //    try
        //    {

        //        HelperData sHelper = new HelperData();
        //        int list = sHelper.Delete(userCode);


        //        if (list == 1)
        //        {
        //            result.Message = "";
        //            result.IsSuccessfull = true;
        //            sHelper.DeleteVahedUser(userCode);
        //        }
        //        else
        //        {

        //            result.IsSuccessfull = false;
        //        }
        //        return result;
        //    }
        //    catch
        //    {
        //        return result;
        //    }
        //}

        public object saveReqPostField(List<postFieldInfo> pfr)
        {
            Results<string> result = new Results<string>();

            try
            {
                   HelperData h = new HelperData();
                            int i = h.AddPostInfo1(pfr);
                            if (i != 0)
                            {
                                result.IsSuccessfull = true;
                            }
            }
            catch (Exception error)
            {
                result.IsSuccessfull = false;
                result.Message = error.Message;
            }
            return result;
        }

        public object SearchInTable(string fieldName, string tendencyName, string gardeName, int firstRow)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.searchPostField(firstRow, firstRow + 6 - 1, fieldName, tendencyName, gardeName);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        //public object UpdateReq(postFieldInfo rn, postInfo pr)
        //{
        //    Results<string> result = new Results<string>();
        //    try
        //    {
        //        HelperData h = new HelperData();
        //        rn.deleted = false;
        //        pr.deleted = false;

        //        int postCode = h.EditUserInfo(rn);
        //        if (t == 1)
        //        {
        //            result.IsSuccessfull = true;
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        result.IsSuccessfull = false;
        //        result.Message = error.Message;
        //    }
        //    return result;
        //}

        public object PostReqSe(int firstRow)
        {

            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.PostReqSe(firstRow, firstRow + 6 - 1);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object saveReqPost(postInfo pr)
        {
            Results<string> result = new Results<string>();

            try
            {
                HelperData h = new HelperData();
                pr.deleted = false;
                int postCode = h.AddPostInfo(pr);
                if (postCode != 0)
                {
                        result.IsSuccessfull = true;
                }
            }
            catch (Exception error)
            {
                result.IsSuccessfull = false;
                result.Message = error.Message;
                // reservDB.Transaction.Rollback();
            }
            return result;
        }

        public object PostReqSeByID(int postCode)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.searchPost(postCode);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object UpdateReqPost(postInfo rn)
        {
            Results<string> result = new Results<string>();
            try
            {
                HelperData h = new HelperData();
                int t = h.EditPostInfo(rn);
                if (t == 1)
                {
                    result.IsSuccessfull = true;
                }
            }
            catch (Exception error)
            {
                result.IsSuccessfull = false;
                result.Message = error.Message;
            }
            return result;
        }

        public object FieldReqSe(int firstRow)
        {

            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.FieldReqSe(firstRow, firstRow + 6 - 1);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object creatReq(fieldInfo rn, List<tendencyInfo> rgr)
        {
            Results<string> result = new Results<string>();

            try
            {
                HelperData h = new HelperData();
              //  db.Connection.Open();
              //  using (db.Transaction = db.Connection.BeginTransaction())
                rn.deleted = false;
                int t = h.AddFieldInfo(rn);
                if (t != 0)
                {
                    bool s = h.AddTendency(rgr, t);
                    if (s)
                    {
                        //  db.Transaction.Commit();
                        result.IsSuccessfull = true;
                    }
                }

            }
            catch (Exception error)
            {
              //  db.Transaction.Rollback();
                result.IsSuccessfull = false;
                result.Message = error.Message;
            }
            return result;
        }

        public object TendencyReq(int fieldCode)
        {

            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.TendencyReqSe(fieldCode);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object FieldReqSeByID(int fieldCode)
        {

            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.FieldReqSe(fieldCode);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object UpdateReqField(fieldInfo rn, List<tendencyInfo> rgr, int fieldCode)
        {
            Results<string> result = new Results<string>();
            try
            {
                HelperData h = new HelperData();
                int t = h.EditFieldInfo(rn);
                if (t == 1)
                {
                    int a = h.EditTendency(fieldCode, rgr);
                    if (a == 1)
                    {
                        result.IsSuccessfull = true;
                    }
                }
            }
            catch (Exception error)
            {
                result.IsSuccessfull = false;
                result.Message = error.Message;
            }
            return result;
        }

        public object UpdateReqField(List<tendencyInfo> rgr, int fieldCode)
        {
            Results<string> result = new Results<string>();
            try
            {
                HelperData h = new HelperData();

                int t = h.EditTendency(fieldCode, rgr);
                if (t == 1)
                {
                    result.IsSuccessfull = true;
                }
            }
            catch (Exception error)
            {
                result.IsSuccessfull = false;
                result.Message = error.Message;
            }
            return result;
        }

        public object SearchByFieldName(string fieldName, int firstRow)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.SearchByFieldName(fieldName,firstRow, firstRow + 6 - 1);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object SearchByPostName1(string postName, int firstRow)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.SearchByPostName1(firstRow, firstRow + 6 - 1,postName);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object FillCmbPost()
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {
                HelperSearch sHelper = new HelperSearch();
                list = sHelper.fillCombo("postInfo", "postCode", "postName");
                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object FillPostSection(int postCode)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.searchPost(postCode);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object UpdateReq(postFieldInfo rn)
        {
            Results<string> result = new Results<string>();
            try
            {
                HelperData h = new HelperData();
                int t = h.EditPostFieldInfo(rn);
                if (t == 1)
                {
                    result.IsSuccessfull = true;
                }
            }
            catch (Exception error)
            {
                result.IsSuccessfull = false;
                result.Message = error.Message;
            }
            return result;
        }

        public object FillCmbTendency1()
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {
                HelperSearch sHelper = new HelperSearch();
                list = sHelper.fillCombo("tendencyInfo", "tendencyCode", "tendencyName");
                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object showFieldDetail(int reqCode)
        {

            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.showFieldDetail(reqCode);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object PostFieldReq1()
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.searchPostFieldReq1();


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object deletePost(int postCode)
        {
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperData sHelper = new HelperData();
                int list = sHelper.deletePostInfo(postCode);


                if (list == 1)
                {
                    result.Message = "";
                    result.IsSuccessfull = true;
                    
                }
                else
                {

                    result.IsSuccessfull = false;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object deleteField(int fieldCode)
        {
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperData sHelper = new HelperData();
                int list = sHelper.deleteFieldInfo(fieldCode);


                if (list == 1)
                {
                    result.Message = "";
                   int s = sHelper.DeleteTendencyInfo(fieldCode);
                    if(s==1)
                    result.IsSuccessfull = true;

                }
                else
                {

                    result.IsSuccessfull = false;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object creatReqUser(userInfo rn)
        {
            Results<string> result = new Results<string>();
           
            try
            {
                HelperData h = new HelperData();
                rn.pass = new CustomMembershipProvider().EncryptPassword(rn.pass);
                rn.deleted = false;
                
                Int16 t = h.AddUserInfo(rn);
                if (t!=0)
                {
                        result.IsSuccessfull = true;
                    
                }
            }
            catch (Exception error)
            {
               
                result.IsSuccessfull = false;
                result.Message = error.Message;
            }
            return result;
        }

        public object checkUserName(string userName)
        {

            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch h = new HelperSearch();
                int list = h.checkUniqUser(userName);


                if (list == 1)
                {
                    result.Message = "";
                    result.IsSuccessfull = true;
                }
                else if (list == 2)
                {
                    result.Message = "نام کاربری تکراری است.";
                    result.IsSuccessfull = false;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object UserReq()
        {

            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.UserReq();


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object deleteUser(int userCode)
        {
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperData sHelper = new HelperData();
                int list = sHelper.deleteUserInfo(userCode);


                if (list == 1)
                {
                    result.Message = "";
                    result.IsSuccessfull = true;

                }
                else
                {

                    result.IsSuccessfull = false;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public object changePass(string oldPass, string newPass)
        {

            Results<string> result = new Results<string>();
            HelperData h = new HelperData();

            try
            {
                newPass = new CustomMembershipProvider().EncryptPassword(newPass);
                oldPass = new CustomMembershipProvider().EncryptPassword(oldPass);
                result.Value = h.changePass(oldPass, newPass, Convert.ToInt32(System.Web.HttpContext.Current.Session["userCode"]));
                if (result.Value == "1")
                {
                    result.IsSuccessfull = true;
                }
                else if (result.Value == "0")
                {
                    result.IsSuccessfull = false;
                    result.Message = "رمز عبور فعلی، اشتباه وارد شده است";
                }
                else
                {
                    result.IsSuccessfull = false;
                    result.Message = "امکان ویرایش اطلاعات نمیباشد/ خطای شماره 100";
                }
                return result;
            }
            catch (Exception error)
            {
                result.Message = error.Message;
                result.IsSuccessfull = false;
                return result;
            }
        }

       
            public object GradeReq(int firstRow)
        {
            DataTable list = new DataTable();
            Results<DataTable> result = new Results<DataTable>();
            try
            {

                HelperSearch sHelper = new HelperSearch();
                list = sHelper.GradeReq(firstRow, firstRow + 6 - 1);


                if (list.Rows.Count == 0)
                {
                    result.Message = "";
                    result.IsSuccessfull = false;
                }
                else
                {
                    result.Value = list;
                    result.IsSuccessfull = true;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }


            public object saveReqGrade(gradeInfo gr)
            {
                Results<string> result = new Results<string>();

                try
                {
                    HelperData h = new HelperData();
                    gr.deleted = false;
                    int postCode = h.AddGradeInfo(gr);
                    if (postCode != 0)
                    {
                        result.IsSuccessfull = true;
                    }
                    else
                    {
                        result.Message = "خطا!  فیلدی با این مشخصات قبلا ثبت شده است.";
                    }
                }
                catch (Exception error)
                {
                    result.IsSuccessfull = false;
                    result.Message = error.Message;
                    // reservDB.Transaction.Rollback();
                }
                return result;
            }

            public object deleteGrade(int gradeCode)
            {
                Results<DataTable> result = new Results<DataTable>();
                try
                {

                    HelperData sHelper = new HelperData();
                    int list = sHelper.deleteGradeInfo(gradeCode);


                    if (list == 1)
                    {
                        result.Message = "";
                        result.IsSuccessfull = true;

                    }
                    else
                    {

                        result.IsSuccessfull = false;
                    }
                    return result;
                }
                catch
                {
                    return result;
                }
            }

            public object SearchByGradeName(string gradeName, int firstRow)
            {
                DataTable list = new DataTable();
                Results<DataTable> result = new Results<DataTable>();
                try
                {

                    HelperSearch sHelper = new HelperSearch();
                    list = sHelper.SearchByGradeName(firstRow, firstRow + 6 - 1, gradeName);


                    if (list.Rows.Count == 0)
                    {
                        result.Message = "";
                        result.IsSuccessfull = false;
                    }
                    else
                    {
                        result.Value = list;
                        result.IsSuccessfull = true;
                    }
                    return result;
                }
                catch
                {
                    return result;
                }
            }
    }
}
