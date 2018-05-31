<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="MyEasyBuy.CategoryList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品列表</title>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <link type="text/css" rel="stylesheet" href="css/comm.css" />
    <style>
        table tr {
            height: 30px;
            color: #000000;
        }

            table tr:hover {
                background-color: #96AAC8;
                color: #ffffff;
                font-weight: bold;
            }

        table {
            text-align: center;
            border-collapse: collapse;
        }
         .div_pagelist
        {
            text-align:center;
            font-size:14pt;
            font-family:微软雅黑;
            
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="title">商品管理--&gt;&gt;商品列表</div>
        <div class="form_box">

                <table>
                    <tr>
                        <th>编号</th>
                        <th>分类名称</th>
                        <th>分类描述</th>
                        <th>操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_category">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("cid") %></td>
                                <td><%#Eval("cname") %></td>
                                <td><%#Eval("summary") %></td>
                                <td>
                            <a href='AddCategory.aspx?cid=<%#Eval("cid") %>'>
                                <img border="0" title="编辑" src="images/update.png" /></a>
                            &nbsp;&nbsp;
							<a href="">
                                <img border="0" title="详情" src="images/info.png" /></a>
                            &nbsp;&nbsp;
							<a href="#" class="del" cid='<%#Eval("cid") %>'>
                                <img border="0" title="删除" src="images/delete.png" /></a>
                        </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
             <div class="div_pagelist">
                当前第<asp:Label runat="server" ID="lbPageIndex"></asp:Label>页，共<asp:Label runat="server" ID="lbSumPage"></asp:Label>页&nbsp;
                <asp:LinkButton ID="LbuttonPrePage" runat="server" Text="上一页" OnClick="LbuttonPrePage_Click"></asp:LinkButton>/<asp:LinkButton ID="LbuttonNextPage" runat="server" Text="下一页" OnClick="LbuttonNextPage_Click"></asp:LinkButton>
            </div>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $(".del").click(function () {
                    //获取到我点击的是那一条记录，获取它的cid
                    var cid = $(this).attr("cid");
                    //开始向后台去提交数据
                    $.post("/ashx/CategoryHandler.ashx", {cid:cid}, function (data,status) {
                        if (data=="1") {
                            alert("恭喜你，删除成功");
                            window.location.reload();
                        }
                        else {
                            alert("删除失败");
                        }
                    });
                });
            });
        </script>
        <asp:HiddenField ID="hiddenPageIndex" runat="server" Value="1" />
    </form>
</body>
</html>
