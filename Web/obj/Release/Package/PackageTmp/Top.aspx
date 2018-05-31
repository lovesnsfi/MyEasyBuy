<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="MyEasyBuy.Top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>头部</title>
    <style type="text/css">
        body
        {
            background-color:#112435;
            margin:0px;
        }
        .main
        {
            height:110px;
        }
        .logo
        {
            position:absolute;   /*绝对定位*/
            top:0px;   /*距离左边的距离*/
            left:0px;  /*距离右边的距离*/
        }
        .title
        {
            height:110px;
            width:100%;
            color:white;
            font-size:30pt;   /*字体大小*/
            text-align:center;   /*左右居中*/
            line-height:110px;  /*上下居中*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <img src="images/logo.png" alt="logo" class="logo" />
        <div class="title">
            MyEasyBuy商城后台管理
        </div>
    </div>
    </form>
</body>
</html>
