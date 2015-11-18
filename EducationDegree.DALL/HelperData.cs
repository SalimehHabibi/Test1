using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using EducationDegree.POL;

namespace EducationDegree.DALL
{
  public class HelperData
    {
        EducationDegreeDataContext db = new EducationDegreeDataContext();
        public int AddFieldInfo(fieldInfo fi)
        {
           HelperSearch h = new HelperSearch();
            try
            {
                if (h.checkUniqField(fi.fieldName)==1)
                {
                    db.fieldInfos.InsertOnSubmit(fi);
                    db.SubmitChanges();
                    return fi.fieldCode;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        public int AddPostInfo(postInfo pi)
        {
            HelperSearch h = new HelperSearch();
            try
            {
                if (h.checkUniqPost(pi.postName) == 1)
                {
                    db.postInfos.InsertOnSubmit(pi);
                    db.SubmitChanges();
                    return pi.postCode;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 3;
            }
        }

        public bool AddTendency(List<tendencyInfo> rgr, int fieldCode)
        {
            try
            {
                foreach (tendencyInfo r in rgr)
                {
                    r.fieldCode = fieldCode;
                    r.deleted = false;
                    db.tendencyInfos.InsertOnSubmit(r);
                    db.SubmitChanges();
                }
                return true;

            }
            catch (Exception error)
            {
                return false;
            }
        }

        public int AddpostFieldInfo(postFieldInfo pfi)
        {
            try
            {
                db.postFieldInfos.InsertOnSubmit(pfi);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception error)
            {
                return 3;
            }
        }

       
       
        //Delete Tables
        public int DeleteField(int code)
        {
            try
            {
                var v = from i in db.fieldInfos
                        where i.fieldCode == code
                        select i;
                fieldInfo newfield = v.FirstOrDefault();
                if (newfield != null)
                {
                    newfield.deleted = true;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;//not found
            }
            catch (Exception error)
            {
                return -1;
            }
        }


        public int AddPostInfo1(List<postFieldInfo> pfr)
        {
            try{
            foreach (postFieldInfo r in pfr)
            {
                
                r.deleted = false;
                db.postFieldInfos.InsertOnSubmit(r);
                db.SubmitChanges();
                
            }
                return 1;
            }
            catch{
                return 0;
            }
        }

        public int EditPostInfo(postInfo pi)
        {
            try
            {
                var v = from i in db.postInfos
                        where i.postCode == pi.postCode
                        select i;
                postInfo newPost = v.FirstOrDefault();
                if (newPost != null)
                {
                    newPost.postCode = pi.postCode;
                    newPost.postName = pi.postName;
                    newPost.raster = pi.raster;
                    newPost.description = pi.description;
             //       newPost.dateInsert = pi.dateInsert;

                    newPost.deleted = false;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;//not found

            }
            catch (Exception error)
            {
                return -1;
            }
        }

        public int EditFieldInfo(fieldInfo rn)
        {
            try
            {
                var v = from i in db.fieldInfos
                        where i.fieldCode == rn.fieldCode
                        select i;
                fieldInfo newPost = v.FirstOrDefault();
                if (newPost != null)
                {
                    newPost.fieldCode = rn.fieldCode;
                    newPost.fieldName = rn.fieldName;
                   // newPost.dateInsert = rn.dateInsert;
                    newPost.deleted = false;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;//not found

            }
            catch (Exception error)
            {
                return -1;
            }
        }

        public int EditTendency(int fieldCode, List<tendencyInfo> rgr)
        {
            try
            {
                var v = from i in db.tendencyInfos
                        where i.fieldCode == fieldCode
                        select i;
                foreach (tendencyInfo r in v)
                {
                    
                    r.deleted = true;
                    db.tendencyInfos.DeleteOnSubmit(r);
                    db.SubmitChanges();
                }

            
                foreach (tendencyInfo r in rgr)
                {
                    r.fieldCode = fieldCode;
                    r.deleted = false;
                    db.tendencyInfos.InsertOnSubmit(r);
                    db.SubmitChanges();
                }

                return 1;

            }
            catch (Exception error)
            {
                return -1;
            }
        }

        public int EditPostFieldInfo(postFieldInfo rn)
        {
            try
            {
                var v = from i in db.postFieldInfos
                        where i.postFieldCode == rn.postFieldCode
                        select i;
                postFieldInfo newPost = v.FirstOrDefault();
                if (newPost != null)
                {
                    newPost.fieldCode = rn.fieldCode;
                    newPost.postCode = rn.postCode;
                    newPost.gradeCode = rn.gradeCode;
                    newPost.tendencyCode = rn.tendencyCode;
                    newPost.deleted = false;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;//not found

            }
            catch (Exception error)
            {
                return -1;
            }
        }

        public int deletePostInfo(int postCode)
        {
            try
            {
                var v = from i in db.postInfos
                        where i.postCode == postCode
                        select i;
                postInfo newuser = v.FirstOrDefault();
                if (newuser != null)
                {
                    newuser.deleted = true;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;//not found
            }
            catch (Exception error)
            {
                return -1;
            }
        }

        public int deleteFieldInfo(int fieldCode)
        {
            try
            {
                var v = from i in db.fieldInfos
                        where i.fieldCode == fieldCode
                        select i;
                fieldInfo newuser = v.FirstOrDefault();
                if (newuser != null)
                {
                    newuser.deleted = true;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;//not found
            }
            catch (Exception error)
            {
                return -1;
            }
        }

        public int DeleteTendencyInfo(int fieldCode)
        {
            try
            {
                var v = from i in db.tendencyInfos
                        where i.fieldCode == fieldCode
                        select i;
               
                foreach (tendencyInfo vu in v)
                {
                    vu.deleted = true;
                    db.SubmitChanges();

                }
                return 1;

            }
            catch (Exception error)
            {
                return -1;
            }
        }

        public short AddUserInfo(userInfo rn)
        {
            try
            {
                db.userInfos.InsertOnSubmit(rn);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception error)
            {
                return 3;
            }
        }

        public int deleteUserInfo(int userCode)
        {
            try
            {
                var v = from i in db.userInfos
                        where i.userCode == userCode
                        select i;
                userInfo newuser = v.FirstOrDefault();
                if (newuser != null)
                {
                    newuser.deleted = true;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;//not found
            }
            catch (Exception error)
            {
                return -1;
            }
        }

        public string changePass(string oldPass, string newPass, int userCode)
        {
            try
            {
                var ur = from i in db.userInfos
                         where i.userCode == userCode && i.pass == oldPass
                         select i;
                userInfo ui = ur.FirstOrDefault();
                if (ui != null)
                {
                    ui.pass = newPass;
                    db.SubmitChanges();
                    return "1";
                }
                else
                {
                    return "0";
                }

            }
            catch (Exception error)
            {
                return (error.Message);
            }
        }

        public int AddGradeInfo(gradeInfo gr)
        {
            HelperSearch h = new HelperSearch();
            try
            {
                if (h.checkUniqGrade(gr.gradeName) == 1)
                {
                    gr.deleted = false;
                    db.gradeInfos.InsertOnSubmit(gr);
                    db.SubmitChanges();
                    return gr.gradeCode;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception error)
            {
                return 3;
            }
        }

        public int deleteGradeInfo(int gradeCode)
        {
            try
            {
                var v = from i in db.gradeInfos
                        where i.gradeCode == gradeCode
                        select i;
                gradeInfo
                    
                    
                    newuser = v.FirstOrDefault();
                if (newuser != null)
                {
                    newuser.deleted = true;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;//not found
            }
            catch (Exception error)
            {
                return -1;
            }
        }
    }
}
