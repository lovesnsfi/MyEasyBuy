<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="MyEasyBuy.GoodsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品列表</title>
    <link type="text/css" href="css/comm.css" rel="stylesheet" />
    <style>
        table tr {
            height: 30px;
            color: #000000;
        }

            table tr:hover {
                background-color: #96AAC8;
                color: #ffffff;
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
                    <th>名称</th>
                    <th>单价</th>
                    <th>分类</th>
                    <th>库存</th>
                    <th>折扣</th>
                    <th>操作</th>
                </tr>
                <asp:Repeater runat="server" ID="rp_goodsList">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("gid") %></td>
                            <td style="text-align:left"><%#Eval("gname") %></td>
                            <td><%#Eval("price") %></td>
                            <td><%# MyEasyBuy.BLL.eb_goods.GetCnameByCid(int.Parse(Eval("cid").ToString()))%></td>
                            <td><%#Eval("total") %></td>
                            <td><%#Eval("offset") %></td>
                            <td>
                                <a href="">
                                    <img border="0" title="编辑" src="images/update.png" /></a>
                                &nbsp;&nbsp;
							<a href="">
                                <img border="0" title="详情" src="images/info.png" /></a>
                                &nbsp;&nbsp;
							<a href="">
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
        <asp:HiddenField ID="hiddenPageIndex" Value="1" runat="server" />
    </form>
</body>
</html>
