<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchPost.aspx.cs" Inherits="EducationDegree.UI.searchPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>searchPost</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <%-- -----Style CSS----------------------------------------%>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap-rtl.css" rel="stylesheet" />
    <link href="../Content/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
   <%-- <link href="../Content/css/styles-menu.css" rel="stylesheet" />--%>
    <link href="../Content/css/bootstrap-select.css" rel="stylesheet" />
    <link href="../Content/css/style.css" rel="stylesheet" />
    <link href="../Content/css/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" />
    <link href="../Content/css/jquery.dataTables.min.css" rel="stylesheet" />
    <%-- -----Jquery----------------------------------------%>
    <script src="../Content/js/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script src="../Content/js/bootstrap.min.js" type="text/javascript"></script>
    <%--<script src="../Content/js/script-menu.js" type="text/javascript"></script>--%>
    <script src="../Content/js/bootstrap-select.js" type="text/javascript"></script>
    <script src="../Scripts/scripts.js"></script>
    <script src="../Content/js/jquery.dataTables.min.js"></script>
    <script src="../Content/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="../Scripts/validation.js"></script>
    <script src="../Scripts/GridPager.js"></script>
<%--------------------------------------------------------------------Functions ---------------------------------------------------------------%>
    <script type="text/javascript">
        function readReferencesCountForSearch() {
            return $(document).data("countTotal");
        }

        function SearchInTable(firstRow) {
            $('#mainDiv').removeClass("hidden");
           
            $('#panel').show();
            $('#panel1').show();
            $('#tbPostInfo').empty();
            var arr = $(document).data('arrData');
            $.ajax({
                type: "POST",
                url: "search.aspx/SearchInTable",
                // data: JSON.stringify({ fieldName: fieldName, tendencyName: tendencyName, gardeName: gardeName }),
                data: JSON.stringify({ fieldName: arr[0], tendencyName: arr[1], gardeName: arr[2], firstRow: firstRow }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    try {

                        if (response.d == null) {
                            $('#tbPostInfo').append('<tr><td colspan="6"> یافت نشد.</td></tr>');
                        }
                        else {
                            var count = 0;
                            var color;
                            var result = $.parseJSON(response.d);
                            $.each(result.Value, function (index, c) {
                                count += 1;
                                if (count % 2 == 0) {
                                    color = '#AAFFAA ';
                                }
                                else {
                                    color = ' #f2f2f2';
                                }
                                if (c.cnt == null)
                                    $('#tbPostInfo').append('<tr style="background-color: ' + color + '" id="row_' + c.postFieldCode + '"><td id="1col_' + c.postCode + '" style="text-align:center">' +
                                         c.RowNo + '</td>' +
                                        '<td id="2col_' + c.postCode + '" style="text-align:center">' + c.postName + '</td>' +
                                        '<td id="3col_' + c.postCode + '" style="text-align:center">' + c.raster + '</td>' +
                                        '<td id="4col_' + c.postFieldCode + '" style="text-align:center">' + c.fieldName + '</td>' +
                                        '<td id="5col_' + c.postFieldCode + '" style="text-align:center">' + c.tendencyName + '</td>' +
                                        '<td id="6col_' + c.postFieldCode + '" style="text-align:center">' + c.gradeName + '</td>' +

                                       + '" </i></td></tr>');
                                $(document).data("countTotal", c.cnt);
                            });
                        }
                    }
                    catch (err) {
                    }
                },
                error: function (response) {
                    alert('اشکال در خواندن اطلاعات');
                }
            });
        };

       
        function Search() {
            
            var fieldName = $('#txtField').val();
            var tendencyName = $('#txtTendency').val();
            var GradeName = $('#ddlGrade').find('option:selected').text();
            var data = [fieldName, tendencyName, GradeName];
            $(document).data('arrData', data);
            loadGrid('tbPostInfo', readReferencesCountForSearch, SearchInTable);
        };

        function FillCmbGrade() {
            $('#ddlGrade').empty();
            $('#ddlGrade').append(' <option value="">انتخاب کنید</option>');
            try {
                $.ajax({
                    type: "POST",
                    url: "manageInfo.aspx/FillCmbGrade",
                    data: "{}",//read only az db
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        $.each(result.Value, function (index, c) {
                            $('<option value="' + c.gradeCode + '">' + c.gradeName + '</option>').appendTo("#ddlGrade");
                            //alert(c.gradeName);

                        });


                    },
                    failure: function (response) {
                        alert("اشکال در خواندن اطلاعات");
                    }
                })
            }

            catch (e) {
                alert("اشکال در خواندن اطلاعات");
            }
        };

    
    </script>
    <%--///////////////////////////////////////////////////////Document Ready ////////////////////////////////////////////////////--%>
    <script>
        $(document).ready(function () {
            //PostFieldReq();
            bindPager('RequestPager');

            FillCmbGrade();

            $(document).data('countTotal', '0');

            $('#btnSearchFieldName').click(function () {
                Search();
            });
            $('#btnSearchTendencyName').click(function () {
                Search();
            });
            $('#btnSearchGradeName').click(function () {
                Search();
            });
            
            $('#btnSearch').click(function () {
                Search();
            });
            $('#txtField').keydown(function (e) {
                if (e.keyCode == 13) {
                    $('#btnSearchFieldName').focus();
                }
            });

            $('#txtTendency').keydown(function (e) {
                if (e.keyCode == 13) {
                    $('#btnSearchTendencyName').focus();
                }
            });

            $('#txtGrade').keydown(function (e) {
                if (e.keyCode == 13) {
                    $('#btnSearchGradeName').focus();
                }
            });
           


        });
    </script>
    <%--/////////////////////////////////////////////////////////End Script ///////////////////////////////////////////////////////--%>
</head>
<body>
    <div class="line-blue"></div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-7">
                <div class="logo-page"></div>
            </div>
            <div class="col-md-5">
                <br />
                <div class="date-box pull-left">
                    <div class="item-link-top pull-left"><i class="fa fa-question green"></i></div>
                    <div class="date-time"><span><i class="fa fa-calendar-o"></i>&nbsp;&nbsp;امـروز :  <span runat="server" id="txtDate"></span></span></div>
                    
                </div>
            </div>
        </div>
        <div  class="row back-box-post back-right-box ">
            <div class="col-md-12" style="padding:15px;">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">نام رشته</span>
                            <input type="text" class="form-control" id="txtField" placeholder="" aria-describedby="basic-addon1" />
                            <span class="input-group-btn">
                                <button type="button" id="btnSearchFieldName" class="btn btn-success"><i class="fa fa-search"></i></button>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">نام گرایش</span>
                            <input type="text" class="form-control" id="txtTendency" placeholder="" aria-describedby="basic-addon1" />
                            <span class="input-group-btn">
                                <button type="button" id="btnSearchTendencyName" class="btn btn-success"><i class="fa fa-search"></i></button>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                             <span class="input-group-addon">مقطع تحصیلی</span>
                                        <select  class="form-control required" id="ddlGrade" data-width="75%">
                                        </select>
                            <span class="input-group-btn">
                                <button type="button" id="btnSearchGradeName" class="btn btn-success"><i class="fa fa-search"></i></button>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="btn-group pull-left" role="group" aria-label="basic-addon1">
                            <button type="button" id="btnSearch" class="btn btn-success">جستجو&nbsp;<i class="fa fa-search"></i></button>
                        </div>
                    </div>
                </div>
                <div id="mainDiv" class="col-md-9 hidden" style="padding-right:45px;">
                    <div class="panel panel-primary">
                        <div class="panel-title"><span><i class="fa fa-search"></i>&nbsp;تمامی شغل های مرتبط با جستجو</span></div>
                        <div class="panel-body">
                                <div class="table-responsive">
                                    <table class="table table-hover table-bordered">
                                        <tr>
                                            <th class="head-title">#</th>
                                            <th class="head-title">عنوان شغلی</th>
                                            <th class="head-title">رستر</th>
                                            <th class="head-title">نام رشته</th>
                                            <th class="head-title">نام گرایش</th>
                                            <th class="head-title">مدرک تحصیلی</th>
                                        </tr>
                                        <tbody id="tbPostInfo"></tbody>
                                    </table>
                                </div>
                    <div id="RequestPager" class="form-group">
                        <nav class="pull-right">
                            <ul class="pagination">
                                <li>
                                    <a href="#">
                                    <input id="BtnFirst" name="BtnFirst" type="button" value="اولین" />
                                        <i class="fa fa-fast-forward"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                    <input id="BtnPrevius" name="BtnPrevius" type="button" value="قبلی" />
                                         <i class="fa fa-forward"></i>
                                        </a>
                                </li>
                               <li>
                                    <a href="#">
                                    <input style="width:70px;text-align:center" id="TxtPager" name="TxtPager" type="text" readonly="readonly" />
                                     </a>
                                </li>
                                <li>
                                    <a href="#">
                                    <input id="BtnNext" name="BtnNext" type="button" value="بعدی" />
                                         <i class="fa fa-backward"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                    <input id="BtnLast" name="BtnLast" type="button" value="آخرین" />
                                        <i class="fa fa-fast-backward"></i>
                                    </a>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div> 
                    </div>
                </div>
            </div>
        </div>
        <div class="back-box-bottom"></div>
        <div class="row">
            <div class="col-md-6 kmu-footer">
                <span class="logo-kmu-footer">
                    <img src="../Content/images/logo-kmu.ac.png" style="display: inline-block; background-position: right;" />
                    کلیه حقوق این سامانه متعلق به مدیریت آمار و فناوری اطلاعات دانشگاه علوم پزشکی کرمان می باشد.</span>
            </div>
            <div class="col-md-6">
                <div class="copy-right">
                    <a href="http://kmu.ac.ir/">Copyright  &copy; 2015
                <script>new Date().getFullYear() > 2015 && document.write("-" + new Date().getFullYear());</script>
                        ,
                 kmu.ac.ir, All rights reserved.  </a>
                    <br />
                    <a href="http://padidar.com/">power by padidar co,
                    </a>
                </div>
            </div>
        </div>
    </div>
    <%-- ----------------------------------------------------------Modal--------------------------------------------------------------------------------------------------%>
</body>
</html>
