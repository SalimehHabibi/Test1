<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Main.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="EducationDegree.UI.UserManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        #UserManage .modal-dialog {
            width:30%;
        }
    </style>
    <%--////////////////////////////////////////////////////////////////////Functions///////////////////////////////////////////////////////////////////////--%>
    <script>

        function createReq() {
            var request = {};

            request.fName = $('#txtName').val();
            request.lName = $('#txtlName').val();
            request.userName = $('#txtUserName').val();
            request.pass = $('#txtPass').val();
            request.email = $('#txtEmail').val();
            request.mobile = $('#txtMobile').val();
           
            try {
                $.ajax({
                    type: "POST",
                    url: "UserManage.aspx/creatReqUser",
                    data: JSON.stringify({ rn: request}),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        if (result.IsSuccessfull) {
                            // $('#lblMessage').text('ثبت اطلاعات با موفقیت انجام شد');
                            alert('ثبت اطلاعات با موفقیت انجام شد');
                            $('#UserManage').modal("hide");
                            UserReq();

                        }
                        else {
                            alert(result.Message);
                        }
                    },
                    failure: function (response) {
                        $('#lblMessage').text('ارتباط با سرور برقرار نشد-خطای شماره 3');
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
        }

        function checkUserName(userName) {

            $.ajax({
                type: "POST",
                url: "userManage.aspx/checkUserName",
                data: JSON.stringify({ userName: userName }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    try {
                        var result = $.parseJSON(response.d);
                        if (!result.IsSuccessfull) {
                            alert("نام کاربری تکراری است");
                            $("#UserName").val('');
                        }

                    }
                    catch (err) {
                    }
                },
                error: function (response) {

                }
            });
        };

        function UserReq() {
            $('#TblUser').empty();
            try {
                $.ajax({
                    type: "POST",
                    url: "UserManage.aspx/UserReq",
                    data: {},
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == null) {
                            $('#TblUser').append('<tr><td colspan="6"> یافت نشد.</td></tr>');
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
                                $('#TblUser').append('<tr style="background-color: ' + color + '" id="row_' + c.userCode + '"><td id="1col_' + c.userCode + '" style="text-align:center">' +
                                    count + '</td>' +
                                    '<td id="2col_' + c.userCode + '" style="text-align:center">' + c.fName + " " + c.lName + '</td>' +
                                    '<td id="2col_' + c.userCode + '" style="text-align:center">' + c.userName + '</td>' +
                                //   '<td class="edit-remove"><i class="edit fa fa-edit " style="cursor: pointer" id="edit' + c.userCode + '" </i></td>' +
                                   '<td class="edit-remove"><i  class="delete fa fa-times " style="cursor: pointer" id="delete' + c.userCode
                                   + '" </i></td>');
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

        function deleteUser(id) {
            var userCode = id;
            $.ajax({
                type: "POST",
                url: "UserManage.aspx/deleteUser",
                data: JSON.stringify({ userCode: userCode }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    try {

                        alert("رکورد مورد نظر با موفقیت حذف شد.");
                        UserReq();

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
    <%--/////////////////////////////////////////////////////////////Document.Ready//////////////////////////////////////--%>
    <script>
        $(document).ready(function () {
            checkLenght();
            changeValid();
            UserReq();
            var id;

            $('#btnSave').click(function () {
                if (valid('UserManage') == true) {
                    createReq();
                }
            })

            $("#btnAdd").click(function () {
                emptyElements('UserManage');
                $('#btnUpdate').hide();
                $('#btnSave').show();
                validBack('UserManage');
            });

            $("#txtUserName").change(function () {
                checkUserName($("#txtUserName").val());
            });

            $("#txtRePass").change(function () {
                if ($("#txtPass").val() != $("#txtRePass").val()) {
                    alert("کلمه عبور با مقدار وارد شده ی قبلی مطابقت ندارد");
                    $("#txtRePass").val('');
                }
            });

            $("#TblUser").on('click', 'i.delete', function () {
                id = $(this).attr("id").replace("delete", "");
                var e = confirm("آیا مطمئن هستید؟");
                if (e == true) {
                    deleteUser(id)
                    // loadGrid('TblPost', readReferencesCountForSearch, PostReq);

                }
            });

        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-title"><span><i class="fa fa-user-plus"></i>&nbsp;اطلاعات مربوط به کاربران</span>
        </div>
        <div class="panel-body">
                  <div class="row">
                 
                 <div class="col-md-12">
                     <div class="form-group pull-left">
                      <button type="button" class="btn btn-success" data-toggle="modal" data-target="#UserManage" id="btnAdd" data-target=".bs-example-modal-md""><i class="fa fa-plus"></i>&nbsp; کاربر جدید</button>
                </div>
                     <div class="clearfix"></div>
                <div class="form-group">
                 <table id="example" class="table table-hover table-bordered">
                    <thead>
                        <tr>
                            <th class="head-title">ردیف</th>
                            <th class="head-title"> نام و نام خانوادگی</th>
                            <th class="head-title"> نام کاربری</th>
                         <%-- <th class="head-title edit-remove">ویرایش</th>--%>
                            <th class="head-title edit-remove">حذف</th>
                        </tr>
                    </thead>
                    <tbody id="TblUser">
                        <tr>
                        </tr>
                    </tbody>
                </table>
                 </div>
              </div>      
                 
             </div>  
        </div>
    </div>
<%---------------------------------------------------------------------------------Modal--------------------------------------------------------------------------------------%>
     <div class="modal fade bs-example-modal-md" id="UserManage" tabindex="-1" role="dialog" aria-labelledby="gridSystemModalLabel">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="gridSystemModalLabel"><i class="fa fa-user-plus"></i>&nbsp;تعریف کاربران</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div style="padding-right:50px" class="col-md-12">
                                <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon">نام </span>
                                        <input type="text" class="form-control  required lenght" id="txtName" aria-disabled="true" placeholder="" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="vertical-align: top;">نام خانوادگی</span>
                                        <input type="text" id="txtlName" class="form-control  required lenght" aria-disabled="true" placeholder="" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="vertical-align: top;">نام کاربری</span>
                                        <input type="text" id="txtUserName" class="form-control  required" aria-disabled="true" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="vertical-align: top;">رمزعبور</span>
                                        <input type="password" id="txtPass" class="form-control  required" aria-disabled="true" placeholder="" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="vertical-align: top;">تکرار رمز عبور</span>
                                        <input type="password" id="txtRePass" class="form-control" aria-disabled="true" placeholder="" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                                  <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="vertical-align: top;">شماره موبایل</span>
                                        <input type="text" id="txtMobile" class="form-control " aria-disabled="true" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                                   <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="vertical-align: top;">ایمیل</span>
                                        <input type="text" id="txtEmail" class="form-control " aria-disabled="true" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnUpdate" class="btn btn-success">ویرایش اطلاعات</button>
                    <button type="button" id="btnSave" class="btn btn-success">ذخیره اطلاعات</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">انصراف</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
