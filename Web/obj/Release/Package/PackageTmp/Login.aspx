<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyEasyBuy.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MyEasyBuy后台商城管理系统</title>
    <style type="text/css">
        body
        {
            padding-top:100px;
            background-color:#026CAB;
        }
        .login1
        {
            width:960px;
            height:94px;
            background-image:url(images/login_1.jpg);
            margin:auto;
        }
        .login2
        {
            width:960px;
            height:49px;
            background-image:url(images/login_2.jpg);
            margin:auto;
        }
        .login3
        {
            width:960px;
            height:125px;
            background-image:url(images/login_3.jpg);
            margin:auto;
        }
        .login4
        {
            width:960px;
            height:91px;
            background-image:url(images/login_4.jpg);
            margin:auto;
        }
        .tablelogin
        {
            width:290px;
            margin:auto;
        }
        .txt
        {
            width:85%;
            padding:5px;
        }
        .btn
        {
            width:80%;
            border:none;
            height:28px;
            margin-left:10px;
            cursor:pointer;
        }
        .btn:hover
        {
            background-color:orange;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <div class="login1"></div>
         <div class="login2"></div>
         <div class="login3">
             <table class="tablelogin">
                 <tr>
                     <td><asp:TextBox ID="txtUserName" runat="server" CssClass="txt" placeholder="请输入用户名"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><asp:TextBox ID="txtPassWord" runat="server" CssClass="txt" TextMode="Password" placeholder="请输入密码"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><asp:Button runat="server" ID="btnLogin" Text="登陆" CssClass="btn" OnClick="btnLogin_Click" /></td>
                 </tr>
             </table>
         </div>
         <div class="login4"></div>
    </div>
    </form>
</body>
</html>
