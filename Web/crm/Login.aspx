<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyEasyBuy.crm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登陆MyEasyBuy购物商城</title>
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <style type="text/css">
        body
        {
            margin:0px;
            padding:0px;
        }
        .title
        {
            width:990px;
            margin:auto;
            height:80px;   
            line-height:80px; 
        }
        .logo
        {
            vertical-align:middle;
        }
        .nav
        {
            width:100%;
            background-color:#6c4eca;
            height:475px;
        }
        .bg
        {
            background-image:url(../images/LoginBg.jpg);
            width:990px;
            height:475px;
            margin:auto;
        }
        .loginbox
        {
            width:320px;
            height:330px;
            background-color:white;
            float:right;
            position:relative;
            top:40px;
            padding:20px;
        }
        .mt
        {
            font-family:微软雅黑;
        }
        .mt a,.a_forgetPwd
        {
            text-decoration:none;
            font-size:12pt;
            color:#b61d1d;
            float:right;
        }
        .login_tip
        {
            height:19px;
            width:309px;
            background-image:url(../images/pwd-icons-new.png);
            background-repeat:no-repeat;
            background-position:-100px -18px;
            background-color:#fff6d2;
            border:1px solid #ffe57d;
            font-size:10pt;
            line-height:19px;
            padding-top:5px;
            padding-bottom:5px;
            margin-top:10px;
            margin-bottom:10px;
        }
        .login_form
        {

        }
        .textdiv
        {
            width:309px;
            height:40px;
            line-height:40px;
            margin-top:10px;
            border:1px solid lightgray;
        }
        .lbusername
        {
            background-image:url(../images/pwd-icons-new.png);
            background-repeat:no-repeat;
            background-position:0px -2px;
            display:inline-block;
            width:40px;
            height:40px;
            vertical-align:middle;
        }
        .lbpassword
        {
            background-image:url(../images/pwd-icons-new.png);
            background-repeat:no-repeat;
            background-position:-48px -2px;
            display:inline-block;
            width:40px;
            height:40px;
            vertical-align:middle;
        }
        .txt
        {
            display:inline-block;
            font-size:14pt;
            margin-left:10px;
            border:none;
            outline:medium;
        }
        .btn
        {
            width:100%;
            height:40px;
            background-color:#cb2a2d;
            border:none;
            cursor:pointer;
            color:white;
            font-size:14pt;
            font-family:微软雅黑;
        }
         .foot
        {
            clear:both;
            width:100%;
            height:80px;
            text-align:center;
            line-height:80px;
        }
        .foot a
        {
            text-decoration:none;
            color:gray;
        }
    </style>

    <script type="text/javascript">
       
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtUserName").focus(function () {
                $(this).parent().css("border", "1px solid #3AA2E4");
                $(this).prev("label").css("background-position", "0px -50px");
            });
            $("#txtUserName").blur(function () {
                $(this).parent().css("border", "1px solid lightgray");
                $(this).prev("label").css("background-position", "0px -2px");
            });
            $("#txtPassword").focus(function () {
                $(this).parent().css("border", "1px solid #3AA2E4");
                $(this).prev("label").css("background-position", "-48px -50px");
            });
            $("#txtPassword").blur(function () {
                $(this).parent().css("border", "1px solid lightgray");
                $(this).prev("label").css("background-position", "-48px -2px");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title">
        <a href="index.aspx"><img class="logo" src="../images/logo1.png" alt="Logo" /></a> <span style="margin-left:10px;font-size:18pt;font-family:微软雅黑">MyEasyBuy购物商城</span>
    </div>
        <div class="nav">
            <div class="bg">
                <div class="loginbox">
                    <div class="mt">
                        <h3 style="margin:0px;display:inline-block;font-weight:normal">MyEasyBuy会员</h3>
                        <a href="Regist.aspx">立即注册</a>
                    </div>
                    <div class="login_tip">
                        <span style="margin-left:20px">公共场所不建议自动登录，以防账号丢失</span>
                    </div>
                    <div class="login_form">
                        <div class="textdiv">
                            <label class="lbusername"></label><asp:TextBox ID="txtUserName" runat="server" CssClass="txt" placeholder="请输入用户名"></asp:TextBox>
                        </div>
                        <div class="textdiv">
                            <label class="lbpassword"></label><asp:TextBox ID="txtPassword" CssClass="txt" runat="server" TextMode="Password" placeholder="请输入密码"></asp:TextBox>
                        </div>
                        <div class="textdiv" style="border:none">
                            <asp:CheckBox ID="ckSaveme" runat="server" Text="自动登陆"  style="font-size:11pt" />
                            <a href="#" class="a_forgetPwd" style="color:gray;font-size:11pt">忘记密码</a>
                        </div>
                        <div class="textdiv" style="border:none">
                            <asp:Button ID="btnLogin" runat="server" Text="登陆" CssClass="btn" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="foot">
                <a href="#">关于易购</a>
                <a href="#">免现声明</a>
                <a href="#">合作伙伴</a>
                <a href="#">联系客服</a>
                &copy;softeem版权所有 &nbsp;2016
            </div>
    </form>
</body>
</html>
