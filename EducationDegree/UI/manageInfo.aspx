<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Main.Master" AutoEventWireup="true" CodeBehind="manageInfo.aspx.cs" Inherits="EducationDegree.UI.manageInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #manageInfo .modal-dialog {
            width: 65%;
        }
    </style>
    <%--////////////////////////////////////////////////////////////Functions///////////////////////////////////////////////////////////--%>
    <script type="text/javascript">


        function readReferencesCountForSearch() {
            return $(document).data("countTotal");
        }

//---------------------------------------------------------------------------------------------------------
        function FillCmbField() {
            $('#ddlField').empty();
            $('#ddlField').append(' <option value="">انتخاب کنید</option>');
            try {
                $.ajax({
                    type: "POST",
                    url: "manageInfo.aspx/FillCmbField",
                    data: "{}",//read only az db
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async:false,
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        $.each(result.Value, function (index, c) {
                            $('<option value="' + c.fieldCode + '">' + c.fieldName + '</option>').appendTo("#ddlField");

                            //alert(c.fieldName);
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

        function FillCmbTendency() {
            $('#ddlTendency').empty();
            $('#ddlTendency').append(' <option value="">انتخاب کنید</option>');
            var fieldCode = $('#ddlField').find('option:selected').val();

            try {
                $.ajax({
                    type: "POST",
                    url: "manageInfo.aspx/FillCmbTendency",
                    data: JSON.stringify({ fieldCode: fieldCode }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        $.each(result.Value, function (index, c) {
                            $('<option value="' + c.tendencyCode + '">' + c.tendencyName + '</option>').appendTo("#ddlTendency");


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

        function FillCmbTendency1() {
            $('#ddlTendency').empty();
            $('#ddlTendency').append(' <option value="">انتخاب کنید</option>');
          

            try {
                $.ajax({
                    type: "POST",
                    url: "manageInfo.aspx/FillCmbTendency1",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        $.each(result.Value, function (index, c) {
                            $('<option value="' + c.tendencyCode + '">' + c.tendencyName + '</option>').appendTo("#ddlTendency");

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

        function FillCmbPost() {
            $('#ddlPostName').empty();
            $('#ddlPostName').append(' <option value="">انتخاب کنید</option>');
            try {
                $.ajax({
                    type: "POST",
                    url: "manageInfo.aspx/FillCmbPost",
                    data: "{}",//read only az db
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        $.each(result.Value, function (index, c) {
                            $('<option value="' + c.postCode + '">' + c.postName + '</option>').appendTo("#ddlPostName");
                        });


                    },
                    failure: function (response) {
                        alert("اشکال در خواندن اطلاعات20");
                    }
                   
                })
               
            }

            catch (e) {
                alert("اشکال در خواندن اطلاعات");
            }
        };
//------------------------------------------------------------------------------------------------------------------------------------

        function PostFieldReq(firstRow) {
            $(document).data('countTotal', '0');
            $('#tbPostInfo').empty();
            $.ajax({
                type: "POST",
                url: "manageInfo.aspx/PostFieldReq",
                data: JSON.stringify({ firstRow: firstRow }),
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
                                    color = '#eaf6fd ';
                                }
                                else {
                                    color = ' #f2f2f2';
                                }
                                if (c.cnt == null)
                                $('#tbPostInfo').append('<tr style="background-color: ' + color + '" id="row_' + c.postFieldCode + '"><td id="1col_' + c.postCode + '" style="text-align:center">' +
                                    c.RowNum + '</td>' +
                                    '<td id="2col_' + c.postCode + '" style="text-align:center">' + c.postName + '</td>' +
                                    '<td id="3col_' + c.postCode + '" style="text-align:center">' + c.raster + '</td>' +
                                    //'<td id="4col_' + c.postFieldCode + '" style="text-align:center">' + c.fieldName + '</td>' +
                                    //'<td id="5col_' + c.postFieldCode + '" style="text-align:center">' + c.tendencyName + '</td>' +
                                    //'<td id="6col_' + c.postFieldCode + '" style="text-align:center">' + c.gradeName + '</td>' +
                                   '<td class="edit-remove"><i class="detail fa fa-book " style="cursor: pointer" id="detail' + c.postCode + '" </i></td>' +
                                   // '<td class="edit-remove"><i class="edit fa fa-edit " style="cursor: pointer" id="edit' + c.postCode + '" </i></td>' +
                                   '<td class="edit-remove"><i  class="delete fa fa-times " style="cursor: pointer" id="delete' + c.postCode
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

        function SearchByPostName(firstRow) {
            $(document).data('countTotal', '0');
            $('#tbPostInfo').empty();
            var arr = $(document).data('arrData');
            $.ajax({
                type: "POST",
                url: "manageInfo.aspx/SearchByPostName",
              //  data: JSON.stringify({ postName: postName }),
                data: JSON.stringify({ postName: arr[0], firstRow: firstRow }),
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
                                    color = '#eaf6fd ';
                                }
                                else {
                                    color = ' #f2f2f2';
                                }
                                if (c.cnt == null)
                                $('#tbPostInfo').append('<tr style="background-color: ' + color + '" id="row_' + c.postCode + '"><td id="1col_' + c.postCode + '" style="text-align:center">' +
                                     c.RowNum + '</td>' +
                                    '<td id="2col_' + c.postCode + '" style="text-align:center">' + c.postName + '</td>' +
                                    '<td id="3col_' + c.postCode + '" style="text-align:center">' + c.raster + '</td>' +
                                    //'<td id="4col_' + c.postCode + '" style="text-align:center">' + c.fieldName + '</td>' +
                                    //'<td id="5col_' + c.postCode + '" style="text-align:center">' + c.tendencyName + '</td>' +
                                    //'<td id="6col_' + c.postCode + '" style="text-align:center">' + c.gradeName + '</td>' +
                                   '<td class="edit-remove"><i class="detail fa fa-book" style="cursor: pointer" id="detail' + c.postCode + '" </i></td>' +
                                   // '<td class="edit-remove"><i class="edit fa fa-edit " style="cursor: pointer" id="edit' + c.postCode + '" </i></td>'+
                                   '<td class="edit-remove"><i  class="delete fa fa-times " style="cursor: pointer" id="delete' + c.postCode
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

        function fillModal(id) {
            //FillCmbTendency1();
            //FillCmbGrade();
            //FillCmbField();
            //FillCmbPost();
            var postFieldCode = id;

            $.ajax({
                type: "POST",
                url: "manageInfo.aspx/searchpostFieldForEdit",
                data: JSON.stringify({ postFieldCode: postFieldCode }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    try {

                        if (response.d == null) {
                            $('#tbPostInfo').append('<tr><td colspan="6"> یافت نشد.</td></tr>');
                        }
                        else {
                            var result = $.parseJSON(response.d);
                            $.each(result.Value, function (index, c) {
                                $('#txtDescription').val(c.description);
                                $('#txtRaster').val(c.raster);
                                $('#ddlGrade').val(c.gradeCode);
                                $('#ddlPostName').val(c.postCode);
                                $('#ddlField').val(c.fieldCode);
                                $('#ddlTendency').val(c.tendencyCode);



                            });
                        }
                        $('#txtDescription').attr("disabled", true);
                        $('#txtRaster').attr("disabled", true);
                        $('#ddlPostName').attr("disabled", true);
                    }
                    catch (err) {
                    }
                },
                error: function (response) {
                    alert('اشکال در خواندن اطلاعات');
                }
            });
        };

        function deletePostField(id) {
            var postCode = id;
            $.ajax({
                type: "POST",
                url: "manageInfo.aspx/deletePostField",
                data: JSON.stringify({ postCode: postCode }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    try {

                        alert("رکورد مورد نظر با موفقیت حذف شد.");

                    }
                    catch (err) {
                    }
                },
                error: function (response) {
                    alert('اشکال در خواندن اطلاعات');
                }
            });
        };

        function AddToFieldTable() {
            var i2 = 0;
            $.each($('#tblTendency tr'), function (index) {
                i2++;
            });
            if (i2 == 0)
                var i = $(document).data('i');
            else
                var i = i2;
            i++;
            var color = '';
            if (i % 2 == 0) {
                color = '#eaf6fd';
            }
            else {
                color = ' #f2f2f2';
            }


            var fieldName = $('#ddlField').find('option:selected').text();
            var fieldCode = $('#ddlField').find('option:selected').val();
            var raster = $('#txtRaster').val();
            var postCode = $('#ddlPostName').find('option:selected').val();
            var postName = $('#ddlPostName').find('option:selected').text();
            var tendencyCode = $('#ddlTendency').find('option:selected').val();
            var tendencyName = $('#ddlTendency').find('option:selected').text();
            if (tendencyName == "انتخاب کنید") {
                tendencyName = "__";
                tendencyCode = 0;
            }

            var gradeName = $('#ddlGrade').find('option:selected').text();
            var gradeCode = $('#ddlGrade').find('option:selected').val();
            $('#tdField').append('<tr class="addItem" style="background-color: ' + color + '" id="ROW_' + i + '">' +
                               '<td id="1col_' + i + '" style="text-align:center">' + i + '</td>' +
                               '<td id="2col_' + i + '" style="text-align:center">' + postName + '</td>' +
                               '<td id="3col_' + i + '" style="text-align:center">' + raster + '</td>' +
                               '<td id="4col_' + i + '" style="text-align:center">' + fieldName + '</td>' +
                               '<td id="5col_' + i + '" style="text-align:center">' + tendencyName + '</td>' +
                               '<td id="6col_' + i + '" style="text-align:center">' + gradeName + '</td>' +
                               '<td class="hidden" id="7col_' + i + '" style="text-align:center">' + tendencyCode + '</td>' +
                               '<td class="hidden" id="8col_' + i + '" style="text-align:center">' + fieldCode + '</td>' +
                               '<td class="hidden" id="9col_' + i + '" style="text-align:center">' + gradeCode + '</td>' +
                               '<td class="hidden" id="10col_' + i + '" style="text-align:center">' + postCode + '</td>' +
                               '<td class="edit-remove"><i  class="delete fa fa-times " style="cursor: pointer" id="delete' + i
                               + '" </i></td>');

            $(document).data('i', i);
        };

        function CreateReqPostField() {
            var arrType = new Array();
            var j = 1;
            $.each($('#tdField tr'), function (index) {
                var postFieldType = {};
                postFieldType.fieldCode = $('#ROW_' + j + ' td:nth-child(8)').text();
                postFieldType.tendencyCode = $('#ROW_' + j + ' td:nth-child(7)').text();
                postFieldType.gradeCode = $('#ROW_' + j + ' td:nth-child(9)').text();
                postFieldType.postCode = $('#ROW_' + j + ' td:nth-child(10)').text();
                arrType.push(postFieldType);
                j++;
            });

            //save in DB
            try {
                $.ajax({
                    type: "POST",
                    url: "manageInfo.aspx/saveReqPostField",
                    data: JSON.stringify({ pfr: arrType }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        if (result.IsSuccessfull) {
                            $("#manageInfo").modal("hide");
                            alert("ثبت اطلاعات با موفقیت انجام شد.");
                            loadGrid('tbPostInfo', readReferencesCountForSearch, PostFieldReq);
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
        }

        function UpdateReq(postFieldCode) {
            
            var request = {};
            request.postFieldCode = postFieldCode;
            request.gradeCode = $('#ddlGrade').find('option:selected').val();
            request.tendencyCode = $('#ddlTendency').find('option:selected').val();
            request.fieldCode = $('#ddlField').find('option:selected').val();
            request.postCode = $('#ddlPostName').find('option:selected').val();
            

            try {
                $.ajax({
                    type: "POST",
                    url: "manageInfo.aspx/UpdateReq",
                    data: JSON.stringify({ rn: request }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        if (result.IsSuccessfull) {
                            // $('#lblMessage').text('ثبت اطلاعات با موفقیت انجام شد');
                            alert('ویرایش اطلاعات با موفقیت انجام شد');
                            $('#manageInfo').modal('hide');
                            loadGrid('tbPostInfo', readReferencesCountForSearch, PostFieldReq);

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

        function FillPostSection(postCode) {

            $.ajax({
                type: "POST",
                url: "manageInfo.aspx/FillPostSection",
                data: JSON.stringify({ postCode: postCode }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    try {

                        if (response.d == null) {

                        }
                        else {
                            var result = $.parseJSON(response.d);
                            $.each(result.Value, function (index, c) {
                                $('#txtDescription').val(c.description);
                                $('#txtRaster').val(c.raster);
                                $('#txtRaster').attr("disabled", true);
                                $('#txtDescription').attr("disabled", true);
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

        function emptyElements(container) {
            var strContainer = '#' + container;
            $('input[type=text]', 'textarea', strContainer).each(function (element) {
                $(this).val('');
            });
            $('select', strContainer).each(function (element) {
                $(this).val("");
            });
        };

        function readListFields(reqCode) {

            try {
                $.ajax({
                    type: "POST",
                    url: "manageInfo.aspx/showFieldDetail",
                    data: JSON.stringify({ reqCode: reqCode }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = $.parseJSON(response.d);
                        if (result.Value != "") {
                            var count = 0;
                            var color;
                            $.each(result.Value, function (index, i) {
                                count += 1;
                                if (count % 2 == 0) {
                                    color = '#eaf6fd';
                                }
                                else {
                                    color = ' #f2f2f2';
                                }
                                $('#TbllstFields' + reqCode).append('<tr style="background-color: ' + color + '"id="' + i.postFieldCode + '" ><td>' + i.fieldName + '</td><td>' + i.tendencyName + '</td><td>' + i.gradeName + '</td><td class="edit-remove"><i class="edit fa fa-edit " style="cursor: pointer" id="edit' + i.postFieldCode + '" </i></td></tr>');
                            });
                        }
                    },
                    failure: function (response) {
                        alert('ارتباط با سرور برقرار نشد-خطای شماره 65');
                    }
                })
            }

            catch (e) {
                alert('ارتباط با سرور برقرار نشد-خطای شماره 66');

            }
        };

    </script>
    <%--/////////////////////////////////////////////////////////////Document Ready ////////////////////////////////////////////////////--%>
    <script type="text/javascript">
        $(document).ready(function () {
            var id = 0;
            var id1 = 0;
            checkLenght();
            changeValid();
            loadGrid('tbPostInfo', readReferencesCountForSearch, PostFieldReq);

            bindPager('RequestPager');

            FillCmbField();
            FillCmbGrade();
            FillCmbPost();
            FillCmbTendency1();
           
            $("#btnAdd").click(function () {
                $("#fieldModal").addClass('hidden');
                $("#btnEdit").hide();
                $("#btnSave").show();
                $('#ddlPostName').attr("disabled", false);
                
                $('#tdField').empty();
                $("#txtRaster").val("");
                $('#txtDescription').val('');
                $('#btnAddField').show();
                //FillCmbField();
                //FillCmbGrade();
                //FillCmbPost();
                validBack('manageInfo');
                $(document).data('i', '0');
                emptyElements('manageInfo');
            });

            $("#ddlPostName").change(function () {
                if ($('#ddlPostName').find('option:selected').val() != "") {
                    var postCode = $('#ddlPostName').find('option:selected').val();
                    FillPostSection(postCode);
                }

            });

            $("#ddlField").change(function () {
                if ($('#ddlField').find('option:selected').val() != "") {
                    FillCmbTendency();
                }

            });

            $('#btnSearchPostName').click(function () {
                var postName = $('#txtPostName').val();
                var data = [postName];
                $(document).data('arrData', data);
                loadGrid('tbPostInfo', readReferencesCountForSearch, SearchByPostName);
            });

            $('#txtPostName').keydown(function (e) {
                if (e.keyCode == 13) {
                    $('#btnSearchPostName').focus();
                }
            });

            $('#tbPostInfo').on('click', 'i.edit', function () {
                id1 = $(this).attr("id").replace("edit", "");
                $('#fieldModal').show();
                $("#manageInfo").modal("show");
                $("#fieldModal").hide();
                $('#btnAddField').hide();
                $("#btnEdit").show();
                $("#btnSave").hide();
                fillModal(id1);
                validBack('manageInfo');
                $(document).data('i', '0');

            });

            $("#tdField").on('click', 'i.delete', function () {
                id = $(this).attr("id").replace("delete", "");
                $('#ROW_' + id).remove();
                var len = $('#tdField tr').length;
                if (len > 0) {
                    var n = 0;
                    $.each($('#tdField tr'), function (index) {
                        n++;
                        $(this).attr('id', 'ROW_' + n)
                        $(this).find("td").eq(0).text(n);
                        $(this).children().children('.delete').attr('id', 'delete' + n);
                    });
                    $(document).data('i', n);
                }
                else {
                    $(document).data('i', 0);
                }

            });

            $('#btnAddField').click(function () {
                $("#fieldModal").removeClass('hidden');
                if (valid('manageInfo') == true) {
                    AddToFieldTable();
                }
            });

            $("#btnEdit").click(function () {
                if (valid('manageInfo') == true) {
                    UpdateReq(id1);
                }
            });

            $('#btnSave').click(function () {
                if (valid('manageInfo') == true) {
                    CreateReqPostField();
                }
            });

            $("#tbPostInfo").on('click', 'i.detail', function () {
                id = $(this).attr("id").replace("detail", "");
                var idNextRow = $(this).closest('tr').next('tr').attr('id');
                if (idNextRow != ('newRow' + id) || idNextRow == undefined) {
                    var currentRow = $(this).parent().parent();
                    var newRow;
                    newRow = '<tr id="newRow' + id + '" ><td colspan="100%" >' +
                    ' <div class="col-md-12"><div class="form-group"><div class="table-responsive"><table class="table table-hover table-bordered tbl-sub-header"><thead><tr><th class="sub-header">رشته تحصیلی</th><th class="sub-header">گرایش</th><th class="sub-header">مقطع</th><th class="sub-header edit-remove">ویرایش</th></tr></thead>' +
                    '<tbody id="TbllstFields' + id + '" ></tbody></table></div></div></div></div></td></tr>';
                    console.log(newRow);
                    currentRow.after(newRow);
                    //read
                    readListFields(id);

                }
                if (idNextRow == 'newRow' + id) {
                    $('#newRow' + id).toggle();
                }

            });
        });
    </script>
    <%--//////////////////////////////////////////////////////////////End Script////////////////////////////////////////////////////////--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panel-title"><span><i class="fa fa-pencil-square-o"></i>&nbsp;ثبت اطلاعات شغلی</span></div>
        <div class="panel-body">
            <div class="back-top-box">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon">عنوان شغلی</span>
                                <input type="text" class="form-control" id="txtPostName" placeholder="" aria-describedby="basic-addon1" />
                                <span class="input-group-btn">
                                    <button type="button" id="btnSearchPostName" class="btn btn-success"><i class="fa fa-search"></i></button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-6">
                        <div class="btn-group pull-left" role="group" aria-label="basic-addon1">
                            <button type="button" class="btn btn-success" id="btnAdd" data-toggle="modal" data-target="#manageInfo" data-target=".bs-example-modal-md">&nbsp;&nbsp;<i class="fa fa-plus"></i>&nbsp;&nbsp;جـدیـد&nbsp;&nbsp;</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                    <div class="table-responsive">
                        <table class="table table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th class="head-title">#</th>
                                    <th class="head-title">عنوان شغلی</th>
                                    <th class="head-title">رسته</th>

                                    <th class="head-title edit-remove">جزییات</th>
                                    <th class="head-title edit-remove">حذف</th>
                                </tr>
                            </thead>
                            <tbody id="tbPostInfo">
                            </tbody>
                        </table>
                    </div>
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
    <%--//////////////////////////////////////////////////////////////////Modal/////////////////////////////////////////////////////////--%>
    <div class="modal fade bs-example-modal-md" id="manageInfo" tabindex="-1" role="dialog" aria-labelledby="gridSystemModalLabel">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="gridSystemModalLabel"><i class="fa fa-pencil-square-o"></i>&nbsp;ثبت اطلاعات شغلی</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6" style="padding-top: 15px;">
                                <div class="form-group col-md-12">
                                    <div class="input-group col-md-11">
                                        <span class="input-group-addon">عنوان شغلی</span>
                                        <select
                                              class="form-control required" id="ddlPostName" data-width="75%">
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <div class="input-group">
                                        <span class="input-group-addon">رسته</span>
                                        <input type="text" class="form-control" id="txtRaster" aria-disabled="true" placeholder="" aria-describedby="basic-addon1" />
                                    </div>
                                </div>
                                <div class="form-group col-md-12">
                                    <div class="input-group">
                                        <span class="input-group-addon" style="vertical-align: top;">توضیحات</span>
                                        <textarea class="form-control" rows="5" id="txtDescription"></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 alert-success" style="padding: 15px 25px 0 15px;">
                                <div class="form-group">
                                    <div class="input-group col-md-12">
                                        <span class="input-group-addon">نام رشته</span>
                                        <select  class="form-control required" id="ddlField" data-width="75%">
                                        </select>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="input-group col-md-12">
                                        <span class="input-group-addon">گرایش</span>
                                        <select  class="form-control required" id="ddlTendency" data-width="75%">
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group col-md-12">
                                        <span class="input-group-addon">مقطع تحصیلی</span>
                                        <select  class="form-control required" id="ddlGrade" data-width="75%">
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="btn-group pull-left" style="padding-top: 15px;" role="group" aria-label="basic-addon1">
                                        <button type="button" id="btnAddField" class="btn btn-success"><i class="fa fa-plus"></i>&nbsp;&nbsp;اضافه کردن رشته تحصیلی</button>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                     <div>
                        <div class="panel hidden" id="fieldModal">
                            <div class="panel-title"><span><i class="fa fa-graduation-cap"></i>&nbsp;رشته های تحصیلی وارد شده</span></div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="table-responsive">
                                        <table class="table table-hover table-bordered">
                                            <tr>
                                                <th class="head-title">#</th>
                                                <th class="head-title">عنوان شغلی</th>
                                                <th class="head-title">رسته</th>
                                                <th class="head-title">رشته</th>
                                                <th class="head-title">گرایش</th>
                                                <th class="head-title">مدرک تحصیلی</th>
                                                <th class="head-title edit-remove">حذف</th>
                                            </tr>
                                            <tbody id="tdField">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                         </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnEdit" class="btn btn-success">ویرایش اطلاعات</button>
                    <button type="button" id="btnSave" class="btn btn-success">ذخیره اطلاعات</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">انصراف</button>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
