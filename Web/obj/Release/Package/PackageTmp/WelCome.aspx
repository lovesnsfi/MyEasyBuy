<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelCome.aspx.cs" Inherits="MyEasyBuy.WelCome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>欢迎</title>
    <link type="text/css" href="css/easyui.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="js/jquery.fullcalendar.js"></script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
        <div region="center">
            <div class="easyui-fullCalendar" fit="true"></div>
        </div>
    </form>
</body>
</html>
