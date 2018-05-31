<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginBak.aspx.cs" Inherits="MyEasyBuy.crm.LoginBak" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎登陆MyEasyBuy购物商城</title>
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <style type="text/css">
		body
		{
			padding-top: 30px;
		}
		.main
		{
			width: 940px;
			height: 480px;
			margin: auto;
			background-image: url(../images/a09.jpg);
		}
		#tableLogin
		{
			width: 560px;
			font-family: 微软雅黑;
			position: relative;
			top: 225px;
			left: 30px;
		}
		.txt
		{
			padding: 5px;
			width: 300px;
			height: 28px;
		}
		.btn
		{
			width: 130px;
			height: 38px; 	
			background-image: url(../images/a03.gif);
			border: none;
			cursor: pointer;
			color: white;
			font-size: 14pt;
		}
		.title
		{
			position: relative;
			top: 220px;
			font-size: 22pt;
			font-family: 微软雅黑;
			left: 150px;
			margin: 0px;
		}
	</style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnReset").click(function () {
                $("#txtUserName").val("");
                $("#txtPwd").val("");
                return false;
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
<div class="main">
	<p class="title">MyEasyBuy用户登陆</p>
		<table id="tableLogin" cellspacing="0" cellpadding="5">
			<tr>
				<td align="center" width="170px">
					账&nbsp;号(Account)
				</td>
				<td width="390px">
                    <asp:TextBox runat="server" CssClass="txt" ID="txtUserName"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td align="center">
					密&nbsp;码(Password)
				</td>
				<td>
                    <asp:TextBox runat="server" TextMode="Password" CssClass="txt" ID="txtPwd"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td align="center">
                    <asp:CheckBox ID="saveme" runat="server" Text="保存(Save)" />
				</td>
				<td>
                    <asp:Button CssClass="btn" Text="登陆(Login)" runat="server" ID="btnLogin" OnClick="btnLogin_Click" />
					&nbsp;&nbsp;
                    <asp:Button CssClass="btn" runat="server" Text="重置(Reset)" ID="btnReset"/>
				</td>
			</tr>
            <tr>
                <td colspan="2" align="center"><p style="clear:both">还没有账号，我要去<a href="Regist.aspx">注册</a></p></td>
            </tr>
		</table>
    
	</div>
    </form>
</body>
</html>
