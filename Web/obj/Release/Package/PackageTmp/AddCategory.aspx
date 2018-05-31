<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="MyEasyBuy.AddCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品分类添加</title>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <style type="text/css">
        .main
        {

        }
        .title
        {
            height:40px;
            background-color:#E0366E;
            color:white;
            font-family:微软雅黑;
            font-size:12pt;
            line-height:40px;
            padding-left:20px;
        }
        .tablemain
        {
            width:600px;
            margin:auto;
        }
        .txt
        {
                width:90%;

        }
        .btn
        {
            width:79%;
            border-radius:10px;
            border:none;
            font-size:16pt;
            background-color:orange;
            margin-left:10px;
            cursor:pointer;
        }
        .btn:hover{
            background-color:pink;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {            
            //判断用户输入的内容为空
            $("#btnAdd").click(function () {
                var cname = $("#cname").val();
                var summary = $("#summary").val();
                var flag = true;
                if (cname==null||cname=="") {
                    alert("请输入分类名称");
                    flag = false;
                }
                else if (summary==null||summary=="") {
                    alert("分类描述不能为空");
                    flag = false;
                }
                return flag;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <div class="title">
           <asp:Label runat="server" ID="lbtitle">商品分类管理---->>分类添加</asp:Label> 
        </div>
        <div class="content">
            <table class="tablemain">
                <tr>
                    <td width="150" align="right">类别名</td>
                    <td width="450"><asp:TextBox ID="cname" CssClass="txt" runat="server" placeholder="请输入商品名"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">分类描述</td>
                    <td><asp:TextBox ID="summary" CssClass="txt" runat="server" TextMode="MultiLine" Height="  110"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="添加" OnClick="btnAdd_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
        <asp:HiddenField ID="hiddenCid" runat="server" Value="" />
    </form>
</body>
</html>
