<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="MyEasyBuy.crm.Regist" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>欢迎注册</title>
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../js/RegistJs.js"></script>
    <style type="text/css">
        body {
            margin: 0px;
        }

        .main {
            width: 100%;
        }

        .top {
            height: 110px;
            width: 100%;
            background-image: url(../images/headbg.jpg);
            background-repeat: repeat-x;
            background-position: left bottom;
            font-size: 22pt;
            font-family: 微软雅黑;
            line-height: 100px;
        }

            .top img {
                vertical-align: middle;
            }

        .left {
            width: 500px;
            display: inline-block;
        }

        .right {
            display: inline-block;
            width: 200px;
            font-size: 16pt;
            color: gray;
            float: right;
        }

            .right a {
                text-decoration: none;
                color: black;
            }

        .regist_box {
            clear: both;
            width: 1100px;
            margin: auto;
        }

        .regist_box_left {
            width: 600px;
            float: left;
            border-right: 1px solid #ddd;
        }

        .regist_box_rigth {
            width: 490px;
            float: left;
        }

        .textdiv {
            width: 400px;
            margin: auto;
            height: 33px;
            border: 1px solid #ddd;
            line-height: 33px;
            padding: 10px;
            padding-left: 15px;
            margin-top: 10px;
        }

            .textdiv label {
                display: inline-block;
                width: 100px;
            }

        .txt {
            width: 270px;
            border: none;
            font-size: 16pt;
            outline: medium;
        }

        #btnRegist, #btnAccept {
            width: 100%;
            height: 100%;
            background-color: #EE2222;
            border: none;
            color: white;
            cursor: pointer;
            font-size: 14pt;
        }

        #div_bg {
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0px;
            left: 0px;
            background-color: black;
            filter: alpha(opacity=30);
            -moz-opacity: 0.3;
            -khtml-opacity: 0.3;
            opacity: 0.3;
            z-index: 99;
            display: none;
        }

        #RegistRole {
            width: 950px; /*宽度*/
            height: 610px; /*高度*/
            position: fixed;
            left: 50%;
            top: 50%;
            margin-left: -475px;
            margin-top: -305px;
            background-color: white;
            border: 5px solid gray;
            z-index: 100;
            display: none;
        }

        .RegistRoleTitle {
            height: 40px;
            background-color: #F3F3F3;
            width: 100%;
            line-height: 40px; /*设置行高*/
        }

        .RegistRoleContent {
            width: 100%;
            height: 490px;
            overflow-y: scroll; /*溢出*/
        }

        .RegistRoleBottom {
            width: 100%;
            height: 80px;
            background-color: white;
            text-align: center;
            line-height: 80px;
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
        $(document).ready(function () {
            $("#img_regist_close").click(function () {
                //关闭效果
                $("#RegistRole,#div_bg").slideUp("fast");

            });
            $("#btnAccept").click(function () {
                //关闭效果
                $("#RegistRole,#div_bg").slideUp("fast");
            });
            $("#a_RegistRole").click(function () {
                //展开效果
                $("#RegistRole,#div_bg").slideDown("fast");
            });
            $("#RegistRole,#div_bg").bind("contextmenu", function (e) {
                return false;
            });
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="top">
                <div class="left">
                    <a href="index.aspx" title="MyEasyBuy购物商城">
                        <img src="../images/logo1.png" alt="logo" /></a>
                    |
                欢迎注册
                </div>
                <div class="right">
                    已有账号，<a href="Login.aspx">请登陆</a>
                </div>
            </div>
            <div class="regist_box">
                <div class="regist_box_left">
                    <div class="textdiv">
                        <label>用  户  名</label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="txt" placeholder="您的账号或登陆名"></asp:TextBox>
                    </div>
                    <div class="textdiv">
                        <label>密&nbsp;&nbsp;码</label>
                        <asp:TextBox ID="txtPwd" runat="server" CssClass="txt" placeholder="您的密码" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="textdiv">
                        <label>确认密码</label>
                        <asp:TextBox ID="txtSecondPwd" runat="server" CssClass="txt" placeholder="您的确认密码" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="textdiv">
                        <label>性&nbsp;&nbsp;别</label>
                        <asp:DropDownList ID="dropSex" runat="server" CssClass="txt" Style="-moz-appearance: none; appearance: none; -moz-appearance: none; -webkit-appearance: none">
                            <asp:ListItem Value="男">男</asp:ListItem>
                            <asp:ListItem Value="女">女</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="textdiv">
                        <label>生&nbsp;&nbsp;日</label>
                        <input type="text" id="txtBirthday" runat="server" class="txt" placeholder="点击选择日期" readonly="readonly" onclick="WdatePicker()" />
                    </div>
                    <div class="textdiv">
                        <label>手  机  号</label>
                        <asp:TextBox ID="txtTelephone" runat="server" CssClass="txt" placeholder="您的手机号码"></asp:TextBox>
                    </div>
                    <div class="textdiv">
                        <label>邮&nbsp;&nbsp;箱</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" placeholder="您的邮箱地址"></asp:TextBox>
                    </div>
                    <div class="textdiv">
                        <label>验  证  码</label>
                        <asp:TextBox ID="txtValidateCode" runat="server" CssClass="txt" placeholder="验证码" Style="width: 163px; line-height: 33px;"></asp:TextBox>
                        <img id="imgValidateCode" src="ValidateCode.aspx" alt="注册码" style="width: 117px; height: 33px; vertical-align: middle; cursor: pointer" />
                    </div>
                    <div class="textdiv" style="border: none">
                        <asp:CheckBox ID="ckAccept" runat="server" Text="" Checked="true" />我已阅读并同意<a id="a_RegistRole" href="#" style="text-decoration: none">《MyEasyBuy用户注册协议》</a>
                    </div>
                    <div style="width: 400px; height: 43px; margin: auto">
                        <asp:Button ID="btnRegist" runat="server" Text="立即注册" OnClick="btnRegist_Click"></asp:Button>
                    </div>
                </div>
                <div class="regist_box_rigth">
                    <img src="../images/IMG_0586.JPG" alt="登陆图片" style="width: 400px;" />
                </div>
            </div>
            <div class="foot">
                <a href="#">关于易购</a>
                <a href="#">免现声明</a>
                <a href="#">合作伙伴</a>
                <a href="#">联系客服</a>
                &copy;softeem版权所有 &nbsp;2016
            </div>
        </div>
        <!--背景遮幕 -->
        <div id="div_bg"></div>
        <!-- 注册 服务条款 -->
        <div id="RegistRole">
            <div class="RegistRoleTitle">
                <span style="float: left; font-family: 微软雅黑; font-weight: bold; margin-left: 20px">MyEasyBuy用户注册协议</span>
                <img id="img_regist_close" style="float: right; position: relative; top: 10px; cursor: pointer; margin-right: 10px" src="../images/close1.png" alt="关闭" />
            </div>
            <div class="RegistRoleContent">
            </div>
            <div class="RegistRoleBottom">
                <input type="button" name="btnAccept" id="btnAccept" value="同意并继续" style="width: 400px; height: 53px" />
            </div>
        </div>
    </form>
    <script type="text/javascript">
        $.get("/Log/RegistRoleText.txt", function (data) {
            $(".RegistRoleContent").html(data);
        })
    </script>
</body>
</html>
