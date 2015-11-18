<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Main.Master" AutoEventWireup="true" CodeBehind="GradeInfo.aspx.cs" Inherits="EducationDegree.UI.GradeInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
        #postManage .modal-dialog {
        width:35%;
        }
    </style>
 <%-----------------------------------------------------Functions----------------------------------------------------------%>
    <script type="text/javascript">
        function readReferencesCountForSearch() {
            return $(document).data("countTotal");
        }

        function GradeReq(firstRow) {
           
            $('#TblGrade').empty();
            try {
                $.ajax({
                    type: "POST",
                    url: "GradeInfo.aspx/GradeReq",
                    data: JSON.stringify({ firstRow: firstRow }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (response.d == null) {
                            $('#TblGrade').append('<tr><td colspan="6"> یافت نشد.</td></tr>');
                        }
                        else {
                            var count = 0;
                            var color;
                            var result = $.parseJSON(response.d);
                            $.each(result.Value, function (index, c) {
                                count += 1;
                                if (count % 2 == 0) {
                                    color = '#eaf6fd ';
                                }
                                else {
                                    color = ' #f2f2f2';
                                }
                                if (c.cnt == null)
                                    $('#TblGrade').append('<tr style="background-color: ' + color + '" id="row_' + c.gradeCode + '"><td id="1col_' + c.gradeCode + '" style="text-align:center;width:20px">' +
                                        c.RowNo + '</td>' +
                                        '<td id="2col_' + c.gradeCode + '" style="text-align:center">' + c.gradeName + '</td>' +
                                        '<td id="2col_' + c.gradeCode + '" style="text-align:center">' + c.description + '</td>' +

                                       '<td class="edit-remove"><i  class="delete fa fa-times " style="cursor: pointer" id="delete' + c.gradeCode
                                       + '" </i></td>');
                                $(document).data("countTotal", c.cnt);

                            });
                        }

                    },
                    error: function (response) {
                        alert('اشکال در خواندن اطلاعات');
                    }
                });
            }
            catch (err) {
            }

        };

        function CreateReqGrade() {
            var gradeReq = {};
            gradeReq.gradeName = $('#txtGradeName').val();
            gradeReq.description = $('#txtDescription').val();

            //save in DB
            try {
                $.ajax({
                    type: "POST",
                    url: "GradeInfo.aspx/saveReqGrade",
                    data: JSON.stringify({ gr: gradeReq }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        if (result.IsSuccessfull) {
                            alert("ثبت اطلاعات با موفقیت انجام شد.");
                            $("#gradeManage").modal("hide");
                            loadGrid('TblGrade', readReferencesCountForSearch, GradeReq);

                        }
                        else {
                            alert(result.Message);
                        }
                    },
                    failure: function (response) {
                        $('#lblMessage').text('ارتباط با سرور برقرار نشد-خطای شماره 7');
                    }
                })
            }

            catch (e) {
                alert("اشکال در خواندن اطلاعات");

            }
        };

        function emptyElements(container) {
            var strContainer = '#' + container;
            $('input[type=text]', strContainer).each(function (element) {
                $(this).val('');
            });
            $('select', strContainer).each(function (element) {
                $(this).find('option:selected').val("0");
            });
        };

        function deleteGrade(id) {
            var gradeCode = id;
            $.ajax({
                type: "POST",
                url: "GradeInfo.aspx/deleteGrade",
                data: JSON.stringify({ gradeCode: gradeCode }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    try {

                        alert("رکورد مورد نظر با موفقیت حذف شد.");
                        loadGrid('TblGrade', readReferencesCountForSearch, GradeReq);

                    }
                    catch (err) {
                    }
                },
                error: function (response) {
                    alert('اشکال در خواندن اطلاعات');
                }
            });


        };

        function SearchByGradeName(firstRow) {
            $('#TblGrade').empty();
            var arr = $(document).data('arrData');
            $.ajax({
                type: "POST",
                url: "GradeInfo.aspx/SearchByGradeName",
                data: JSON.stringify({ gradeName: arr[0], firstRow: firstRow }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    try {

                        if (response.d == null) {
                            $('#TblGrade').append('<tr><td colspan="6"> یافت نشد.</td></tr>');
                        }
                        else {
                            var count = 0;
                            var color;
                            var result = $.parseJSON(response.d);
                            $.each(result.Value, function (index, c) {
                                count += 1;
                                if (count % 2 == 0) {
                                    color = '#eaf6fd ';
                                }
                                else {
                                    color = ' #f2f2f2';
                                }
                                if (c.cnt == null)
                                    $('#TblGrade').append('<tr style="background-color: ' + color + '" id="row_' + c.gradeCode + '"><td id="1col_' + c.gradeCode + '" style="text-align:center;width:20px">' +
                                       c.RowNo + '</td>' +
                                       '<td id="2col_' + c.gradeCode + '" style="text-align:center">' + c.gradeName + '</td>' +
                                       '<td id="2col_' + c.gradeCode + '" style="text-align:center">' + c.description + '</td>' +
                                       '<td class="edit-remove"><i  class="delete fa fa-times " style="cursor: pointer" id="delete' + c.gradeCode
                                      + '" </i></td>');
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

    </script>
 <%-------------------------------------------------------Document Ready -------------------------------------------------%>
    <script >
        $(document).ready(function () {
            alert('test2');
            alert('test3');
            $(document).data("countTotal", 0);
            bindPager('RequestPager');
            var id;
            checkLenght();
            changeValid();
            loadGrid('TblGrade', readReferencesCountForSearch, GradeReq);
            $('#txtGradeName').data('lenght', '30');
            $('#txtDescription').data('lenght', '100');

            $('#btnSave').click(function () {
                if (valid('postManage') == true) {
                    CreateReqGrade();
                }
            });


            $("#TblGrade").on('click', 'i.delete', function () {
                id = $(this).attr("id").replace("delete", "");
                var e = confirm("آیا مطمئن هستید؟");
                if (e == true) {
                    deleteGrade(id);

                }
            });

            $('#btnSearchGrade').click(function () {
                var gradeName = $('#txtGrade').val();
                var data = [gradeName];
                $(document).data('arrData', data);
                loadGrid('TblGrade', readReferencesCountForSearch, SearchByGradeName);

            });
        });
    </script>
<%------------------------------------------------------------End Script---------------------------------------------------------%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-title"><span><i class="fa fa-sitemap"></i>&nbsp;اطلاعات مربوط به مقاطع تحصیلی</span>
        </div>
        <div class="panel-body back-right-box">
                  <div class="row">
                 <div class="col-md-4">
                    <div class="form-group">
                        <div class="input-group row-fluid">
                            <span class="input-group-addon">مقطع تحصیلی</span>
                           <input type="text" class="form-control" id="txtGrade" aria-describedby="basic-addon1" />
                            <span class="input-group-btn"><button type="button" id="btnSearchGrade" class="btn btn-success"><i class="fa fa-search"></i></button></span>
                        </div>
                    </div> 
                <div class="form-group">
                      <button type="button" class="btn btn-success" data-toggle="modal" data-target="#gradeManage" id="btnAdd" data-target=".bs-example-modal-md""><i class="fa fa-plus"></i>&nbsp; عنوان جدید</button>
                </div>
                 </div>
                 <div class="col-md-8">
                 <table id="example" class="table table-hover table-bordered">
                    <thead>
                        <tr>
                            <th class="head-title">ردیف</th>
                            <th class="head-title"> مقطع تحصیلی</th>
                             <th class="head-title"> توضیحات</th>
                            <th class="head-title edit-remove">حذف</th>
                        </tr>
                    </thead>
                    <tbody id="TblGrade">
                        <tr>
                        </tr>
                    </tbody>
                </table>
                    <div id="RequestPager">
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
                                    <input style="width:70px; text-align:center" id="TxtPager" name="TxtPager" type="text" readonly="readonly" />
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
<%---------------------------------------------------------------------------------Modal--------------------------------------------------------------------------------------%>
     <div class="modal fade bs-example-modal-md" id="gradeManage" tabindex="-1" role="dialog" aria-labelledby="gridSystemModalLabel">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="gridSystemModalLabel"><i class="fa fa-sitemap"></i>&nbsp;تعریف عنوان شغلی</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div style="padding-right:50px" class="col-md-12">
                                <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon">نام مقطع</span>
                                        <input type="text" class="form-control  required lenght" id="txtGradeName" aria-disabled="true" placeholder="" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                          
                                <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="vertical-align: top;">توضیحات</span>
                                        <input type="text" id="txtDescription" class="form-control  lenght" aria-disabled="true" placeholder="" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                   
                    <button type="button" id="btnSave" class="btn btn-success">ذخیره اطلاعات</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">انصراف</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>