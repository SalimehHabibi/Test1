using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationDegree.POL;
using System.Data;
using System.Data.SqlClient;
using System.Security; 

namespace EducationDegree.DALL
{
    public class HelperSearch
    {
        dataAccess dA = new dataAccess();
        EducationDegreeDataContext db = new EducationDegreeDataContext();
        public int checkUniqField(string fieldName)
        {
            DataTable objDatatable = new DataTable();
            try
            {
                dA.connect();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                SqlDataAdapter objDataAdapter1 = new SqlDataAdapter();
                objDatatable.Rows.Clear();
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = dA.con;
                objDataAdapter.SelectCommand.CommandText = "select fieldCode from fieldInfo where  fieldInfo.fieldName=N'" + fieldName + "' and (fieldInfo.deleted!=1 or fieldInfo.deleted is null)  ";

                objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                objDataAdapter.Fill(objDatatable);
                dA.disconnect();
                if (objDatatable.Rows.Count == 0)
                {
                    return 1;
                }
                else
                    return 2;


            }
            catch (Exception error)
            {
                if (dA.con.State == ConnectionState.Open)
                    dA.disconnect();
                return 0;
            }
        }

        public int checkUniqPost(string postName)
        {
            DataTable objDatatable = new DataTable();
            try
            {
                dA.connect();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                SqlDataAdapter objDataAdapter1 = new SqlDataAdapter();
                objDatatable.Rows.Clear();
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = dA.con;
                objDataAdapter.SelectCommand.CommandText = "select postCode from postInfo where  postInfo.postName=N'" + postName + "' and (postInfo.deleted!=1 or postInfo.deleted is null)  ";

                objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                objDataAdapter.Fill(objDatatable);
                dA.disconnect();
                if (objDatatable.Rows.Count == 0)
                {
                    return 1;
                }
                else
                    return 2;


            }
            catch (Exception error)
            {
                if (dA.con.State == ConnectionState.Open)
                    dA.disconnect();
                return 0;
            }
        }

        public int checkUniqGrade(string gradeName)
        {
            DataTable objDatatable = new DataTable();
            try
            {
                dA.connect();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                objDatatable.Rows.Clear();
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = dA.con;
                objDataAdapter.SelectCommand.CommandText = "select gradeCode from gradeInfo where  gradeInfo.gradeName=N'" + gradeName + "' and (gradeInfo.deleted!=1 or gradeInfo.deleted is null)";
                objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                objDataAdapter.Fill(objDatatable);
                dA.disconnect();
                if (objDatatable.Rows.Count == 0)
                {
                    return 1;
                }
                else
                    return 2;


            }
            catch (Exception error)
            {
                if (dA.con.State == ConnectionState.Open)
                    dA.disconnect();
                return 0;
            }
        }


        public DataTable searchPostField(int firstRow,int lastRow,string fieldName = "", string tendency = "", string grade="")
        {
            DataTable objDatatable = new DataTable();
            try
            {
                dA.connect();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                objDatatable.Rows.Clear();
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = dA.con;

                if (grade != "انتخاب کنید" && fieldName != "" && tendency =="")
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and fieldInfo.fieldName like  N'%" + fieldName + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and fieldInfo.fieldName like  N'%" + fieldName + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                 
                 }
                else if (grade != "انتخاب کنید" && fieldName == "" && tendency == "")
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                
                
                }
                else if (grade != "انتخاب کنید" && fieldName != "" && tendency != "")
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and fieldInfo.fieldName like  N'%" + fieldName + "%' and tendencyInfo.tendencyName like N'%" + tendency + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and fieldInfo.fieldName like  N'%" + fieldName + "%' and tendencyInfo.tendencyName like N'%" + tendency + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                
                
                }
                else if (grade == "انتخاب کنید" && fieldName != "" && tendency != "")
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where  fieldInfo.fieldName like  N'%" + fieldName + "%' and tendencyInfo.tendencyName like N'%" + tendency + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where   fieldInfo.fieldName like  N'%" + fieldName + "%' and tendencyInfo.tendencyName like N'%" + tendency + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);


                }

                else if (fieldName != "")
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from fieldInfo inner join postFieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where fieldInfo.fieldName like  N'%" + fieldName + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from fieldInfo inner join postFieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where fieldInfo.fieldName like  N'%" + fieldName + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                
                }
                else  if (tendency != "" )
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from fieldInfo inner join postFieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode  inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where fieldInfo.fieldName like  N'%" + fieldName + "%' and tendencyInfo.tendencyName like N'%" + tendency + "%' and(fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from fieldInfo inner join postFieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode  inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where fieldInfo.fieldName like  N'%" + fieldName + "%' and tendencyInfo.tendencyName like N'%" + tendency + "%' and(fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                
                
                }
                else if (grade != "انتخاب کنید" && fieldName != "" && tendency == "")
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and fieldInfo.fieldName like  N'%" + fieldName + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and fieldInfo.fieldName like  N'%" + fieldName + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                 
                 }
                else if (grade != "انتخاب کنید" && fieldName == "" && tendency == "")
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                
                
                }
                else if (grade != "انتخاب کنید" && fieldName != "" && tendency != "")
                {
                    objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postFieldCode) as RowNo, postName,postInfo.postCode,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and fieldInfo.fieldName like  N'%" + fieldName + "%' and tendencyInfo.tendencyName like N'%" + tendency + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                    objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where gradeInfo.gradeName=  N'" + grade + "' and fieldInfo.fieldName like  N'%" + fieldName + "%' and tendencyInfo.tendencyName like N'%" + tendency + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
                    objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    objDataAdapter.Fill(objDatatable);
                
                
                }

                dA.disconnect();
                return objDatatable;
            }
            catch (Exception error)
            {
                if (dA.con.State == ConnectionState.Open)
                    dA.disconnect();
                return objDatatable;
            }

        }


       public DataTable fillCombo(string table, string ValueMemberField, string DisplayMemberField)
        {
            DataTable objDatatable = new DataTable();
            try
            {
                dA.connect();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                objDatatable.Rows.Clear();
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = dA.con;

               
                objDataAdapter.SelectCommand.CommandText = "select " + ValueMemberField + ", " + DisplayMemberField + " from " + table + " where "+ table +".deleted != 1 or "+ table+".deleted is null";


                objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                objDataAdapter.Fill(objDatatable);
                dA.disconnect();
                return objDatatable;

            }
            catch (Exception error)
            {
                if (dA.con.State == ConnectionState.Open)
                    dA.disconnect();
                return objDatatable;
            }
        }

       public DataTable fillComboTendency(int fieldCode)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;


               objDataAdapter.SelectCommand.CommandText = "select tendencyCode,tendencyName from tendencyInfo  where tendencyInfo.fieldCode =" + fieldCode + " and(tendencyInfo.deleted!=1 or tendencyInfo.deleted is null) ";


               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;

           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable searchPostFieldReq(int firstRow,int lastRow)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;


             //  objDataAdapter.SelectCommand.CommandText = "select postFieldCode,postFieldInfo.postCode,postName,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null)";
               objDataAdapter.SelectCommand.CommandText = "with temp as(select distinct Row_Number() over (order by postInfo.postCode desc)as RowNum, postInfo.postCode,postName,raster from postInfo inner join postFieldInfo on postFieldInfo.postCode = postInfo.postCode where (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null) group by postInfo.postCode,postName,raster)select * from temp where RowNum between " + firstRow + " and " + lastRow;
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               objDataAdapter.SelectCommand.CommandText = " select count(distinct postInfo.postCode) as cnt  from postInfo inner join postFieldInfo on postFieldInfo.postCode = postInfo.postCode where (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

 
             dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable SearchByPostName(string postName, int firstRow, int lastRow)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "with temp as(select distinct Row_Number() over (order by postInfo.postCode)as RowNum, postInfo.postCode,postName,raster from postFieldInfo inner join postInfo on postFieldInfo.postCode = postInfo.postCode where postInfo.postName like N'%" + postName + "%' and (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null)group by postInfo.postCode,postName,raster)select * from temp where RowNum between " + firstRow + " and " + lastRow;
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               objDataAdapter.SelectCommand.CommandText = " select count(distinct postInfo.postCode) as cnt from postFieldInfo inner join postInfo on postFieldInfo.postCode = postInfo.postCode where postInfo.postName like N'%" + postName + "%' and (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable searchpostFieldByPostCode(int postCode)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "select postName,raster,postFieldInfo.fieldCode,tendencyName,postFieldInfo.tendencyCode,gradeCode,description from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode  where postFieldInfo.postCode=" + postCode + " and (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null)";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable searchpostFieldForEdit(int postFieldCode)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "select postName,raster,postFieldInfo.fieldCode as 'fieldCode',postFieldInfo.postCode as 'postCode',tendencyName,postFieldInfo.tendencyCode as 'tendencyCode',gradeCode,description from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode  where postFieldInfo.postFieldCode=" + postFieldCode + " and (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null)";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable PostReqSe(int firstRow, int lastRow)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;

               objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postCode desc) as RowNo, postCode,postName,raster from postInfo where (postInfo.deleted != 1 or postInfo.deleted is null))select * from temp where  RowNo between " + firstRow + " and " + lastRow;
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postInfo where (postInfo.deleted != 1 or postInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable searchPost(int postCode)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "select * from postInfo where postCode=" + postCode + " and (postInfo.deleted!=1 or postInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable FieldReqSe(int firstRow, int lastRow)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by fieldCode desc) as RowNo, fieldCode,fieldName from fieldInfo where (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt  from fieldInfo where (fieldInfo.deleted != 1 or fieldInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable TendencyReqSe(int fieldCode)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "select tendencyCode,tendencyName  from tendencyInfo where tendencyInfo.fieldCode =" + fieldCode + " and (tendencyInfo.deleted != 1 or tendencyInfo.deleted is null)";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable FieldReqSe(int fieldCode)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "select fieldCode,fieldName,dateInsert from fieldInfo where fieldInfo.fieldCode=" + fieldCode + " and (fieldInfo.deleted != 1 or fieldInfo.deleted is null)";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable SearchByFieldName(string fieldName, int firstRow, int lastRow)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by fieldCode) as RowNo, fieldCode,fieldName from fieldInfo  where fieldInfo.fieldName like N'%" + fieldName + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from fieldInfo  where fieldInfo.fieldName like N'%" + fieldName + "%' and (fieldInfo.deleted != 1 or fieldInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable SearchByPostName1(int firstRow ,int lastRow,string postName)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by postCode) as RowNo, postCode,postName,raster from postInfo where postInfo.postName like N'%" + postName + "%' and (postInfo.deleted != 1 or postInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow ;
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from postInfo where postInfo.postName like N'%" + postName + "%' and (postInfo.deleted != 1 or postInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable showFieldDetail(int reqCode)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "select fieldName,tendencyName,gradeName,postFieldCode from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode = gradeInfo.gradeCode  where postFieldInfo.postCode=" + reqCode + " and (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null)";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable searchPostFieldReq1()
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;


               objDataAdapter.SelectCommand.CommandText = "select postFieldCode,postFieldInfo.postCode,postName,raster,fieldName,tendencyName,gradeName from postFieldInfo inner join fieldInfo on postFieldInfo.fieldCode = fieldInfo.fieldCode inner join postInfo on postFieldInfo.postCode = postInfo.postCode inner join tendencyInfo on postFieldInfo.tendencyCode = tendencyInfo.tendencyCode inner join gradeInfo on postFieldInfo.gradeCode=gradeInfo.gradeCode where (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null)";
              // objDataAdapter.SelectCommand.CommandText = "select distinct postInfo.postCode,postName,raster from postInfo inner join postFieldInfo on postFieldInfo.postCode = postInfo.postCode where (postFieldInfo.deleted != 1 or postFieldInfo.deleted is null)";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public Results<userInfo> checkUserPass(string userName, string pass)
       {
           Results<userInfo> result = new Results<userInfo>();
           try
           {
               var u = from i in db.userInfos
                       where i.userName == userName && i.pass == pass
                       select i;
               userInfo ui = u.FirstOrDefault();
               if (ui != null)
               {
                   result.Value = ui;
                   result.Message = "";
                   result.IsSuccessfull = true;
               }
               else
               {
                   result.Value = ui;
                   result.Message = "نام کاربری یا رمز عبور اشتباه است";
                   result.IsSuccessfull = false;
               }
               return result;

           }
           catch (Exception error)
           {
               result.Message = error.ToString();
               result.IsSuccessfull = false;
               return result;
           }
       }

       public int checkUniqUser(string userName)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               SqlDataAdapter objDataAdapter1 = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "select userCode from userInfo where  userInfo.userName='" + userName + "' and (userInfo.deleted!=1 or userInfo.deleted is null)  ";

               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               if (objDatatable.Rows.Count == 0)
               {
                   return 1;
               }
               else
                   return 2;


           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return 0;
           }
       }

       public DataTable UserReq()
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "select * from userInfo where (userInfo.deleted != 1 or userInfo.deleted is null)";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable GradeReq(int firstRow, int lastRow)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;

               objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by gradeCode desc) as RowNo, gradeCode,gradeName,description from gradeInfo where (gradeInfo.deleted != 1 or gradeInfo.deleted is null))select * from temp where  RowNo between " + firstRow + " and " + lastRow;
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from gradeInfo where (gradeInfo.deleted != 1 or gradeInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }

       public DataTable SearchByGradeName(int firstRow, int lastRow, string gradeName)
       {
           DataTable objDatatable = new DataTable();
           try
           {
               dA.connect();
               SqlDataAdapter objDataAdapter = new SqlDataAdapter();
               objDatatable.Rows.Clear();
               objDataAdapter.SelectCommand = new SqlCommand();
               objDataAdapter.SelectCommand.Connection = dA.con;
               objDataAdapter.SelectCommand.CommandText = "with temp as (select Row_Number() over (order by gradeCode) as RowNo, gradeCode,gradeName,description from gradeInfo where gradeInfo.gradeName like N'%" + gradeName + "%' and (gradeInfo.deleted != 1 or gradeInfo.deleted is null))select * from temp where RowNo between " + firstRow + " and " + lastRow;
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);

               objDataAdapter.SelectCommand.CommandText = " select count(*) as cnt from gradeInfo where gradeInfo.gradeName like N'%" + gradeName + "%' and (gradeInfo.deleted != 1 or gradeInfo.deleted is null) ";
               objDataAdapter.SelectCommand.CommandType = CommandType.Text;
               objDataAdapter.Fill(objDatatable);
               dA.disconnect();
               return objDatatable;
           }
           catch (Exception error)
           {
               if (dA.con.State == ConnectionState.Open)
                   dA.disconnect();
               return objDatatable;
           }
       }
    }
    
}
