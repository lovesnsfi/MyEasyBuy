<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsInfo.aspx.cs" Inherits="MyEasyBuy.crm.GoodsInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品详细</title>
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <style type="text/css">
        .main {
            width: 900px;
            margin: auto;
        }

        .head {
            height: 30px;
            background-color: #FFA500;
            line-height: 30px;
            padding-right: 10px;
            padding-left: 10px;
        }

        .spanleft {
            float: left;
        }

        .spanright {
            margin-left: 10px;
        }

            .spanleft a, .spanright a {
                text-decoration: none;
                color: black;
                font-size: 10pt;
                font-weight: bold;
            }

        .head_right {
            display: inline-block;
            float: right;
        }

        .logo {
            float: left;
        }

        .goods_content {
            width: 100%;
        }

        .goods_left {
            float: left;
            width: 300px;
        }

        .goods_right {
            float: left;
            width: 600px;
        }

        .btn {
            height: 30px;
            width: 100px;
            font-weight: bold;
            color: white;
            background-color: #FFA500;
            border: none;
            cursor: pointer;
        }

        .goods_right ul {
            list-style: none;
            font-size: 16pt;
        }

            .goods_right ul li {
                height: 30px;
                line-height: 30px;
                padding: 10px;
            }

        .goods_name {
            font-size: 20pt;
            font-weight: bold;
        }

        .goods_price {
            color: red;
            font-size: 18pt;
        }

        .goods_num {
            width: 50px;
            height: 21px;
            text-align: center;
        }

        .foot {
            margin-top: 10px;
            clear: both;
            height: 30px;
            background-color: #FFA500;
            line-height: 30px;
            text-align: center;
        }

            .foot a {
                text-decoration: none;
                font-weight: bold;
                color: black;
                font-size: 11pt;
                margin-left: 3px;
            }

        #jia, #jian {
            width: 30px;
            height: 30px;
            position: relative;
            top: 10px;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#jia").click(function () {
                //先要获取原来的值是多少
                var str = $("#buyCount").val();
                var num = parseInt(str);
                $("#buyCount").val(++num);
            });

            $("#jian").click(function () {
                var str = $("#buyCount").val();
                var num = parseInt(str);
                num--;
                if (num <= 0) {
                    num = 1;
                }
                $("#buyCount").val(num);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="head">
                <span class="spanleft" style="color: white">软帝科技</span>
                <div class="head_right">
                     <%if (Session["CrmUserInfo"] == null)
                      { %>
                    <span class="spanright"><a href="#">注册</a>| <a href="Login.aspx">登陆</a></span>
                    <%}
                      else
                      { %>
                    <span class="spanright"><%=(Session["CrmUserInfo"] as MyEasyBuy.Model.eb_customer).UserName %><asp:LinkButton runat="server" ID="lbLogOut" Text="安全退出" OnClick="lbLogOut_Click"></asp:LinkButton></span>
                    <%} %>
                    <span class="spanright"><a href="#">我的订单</a></span>
                    <span class="spanright"><a href="ShoppingCartList.aspx">购物车</a></span>
                </div>
            </div>
            <div class="logodiv">
                <img class="logo" src="../images/logo1.png" alt="logo">
            </div>
            <hr width="100%" color="#FFA500">
            <div class="goods_content">
                <div class="goods_left">
                    <asp:Image runat="server" ID="goodsimg" Width="300" Height="320" />
                </div>
                <div class="goods_right">
                    <ul>
                        <li><span class="goods_name">
                            <asp:Label runat="server" ID="lbgname"></asp:Label></span></li>
                        <li>价格：<span class="goods_price">￥<asp:Label runat="server" ID="lbOffsetPrice"></asp:Label></span><strike style="margin-left: 15px">原价：<asp:Label runat="server" ID="lbprice"></asp:Label></strike></li>
                        <li>库存：<asp:Label runat="server" ID="lbtotal"></asp:Label></li>
                        <li>购买：
					<img src="../images/jian.png" alt="减" id="jian" />
                            <input id="buyCount" type="text" class="goods_num" value="1" readonly="readonly" />
                            <img src="../images/jia.jpg" alt="加" id="jia" />
                        </li>
                        <li>
                            <input type="button" class="btn" value="立即购买" />
                            <input type="button" id="btnShopCart" class="btn" value="加入购物车" />
                        </li>
                    </ul>
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
        <asp:HiddenField runat="server" ID="hiddenGid" Value="" />
        <div class="bgDiv"></div>
        <!-- 登陆的Div-->
        <div class="loginDiv">
            <table cellspacing="0" border="0" style="width: 85%; margin: auto; margin-top: 30px;">
                <caption style="font-family: 微软雅黑; font-size: 18pt;">请登陆购物系统</caption>
                <tr>
                    <td align="right">用户名：</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">密&nbsp;码：</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPwd" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" Text="登陆" runat="server" OnClick="btnLogin_Click" />
                        &nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="取消" />
                    </td>
                </tr>
            </table>
        </div>
        <style type="text/css">
            .loginDiv {
                width: 300px;
                height: 200px;
                position: fixed;
                top: 50%;
                left: 50%;
                margin-left: -150px;
                margin-top: -100px;
                border: 1px solid black;
                z-index: 100;
                background-color: white;
                display: none;
                border-radius: 5px;
            }

            .bgDiv {
                position: fixed;
                width: 100%;
                height: 100%;
                top: 0px;
                left: 0px;
                z-index: 99;
                background-color: black;
                opacity: 0.3; /*设置半透明值*/
                display: none;
            }
        </style>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#btnShopCart").click(function () {
                    //检查你有没有登陆
                    $.post("/ashx/CrmInfo.ashx?action=CheckCrmSession", function (data) {
                        if (data == "0") {
                            //用户没有登陆
                            $(".loginDiv").slideDown("fast");
                            $(".bgDiv").slideDown("fast");
                        }
                        else {
                            //用户已经登陆
                            //向数据库添加数据
                            var gid = $("#hiddenGid").val();
                            var count = $("#buyCount").val();
                            $.post("/ashx/CrmInfo.ashx?action=AddShoppingCart",
                                {
                                    gid: gid,
                                    count: count
                                }, function (data) {
                                    if (data == "1") {
                                        alert("添加购物车成功");
                                    }
                                    else {
                                        alert("添加购物车失败，请联系管理员或重试");
                                    }
                                });
                        }
                    });

                });
                $("#btnReset").click(function () {
                    $(".loginDiv").slideUp("fast");
                    $(".bgDiv").slideUp("fast");
                    return false;
                });
            });
        </script>
    </form>
</body>
</html>
