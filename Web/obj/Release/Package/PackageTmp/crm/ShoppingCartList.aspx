<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartList.aspx.cs" Inherits="MyEasyBuy.crm.ShoppingCartList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>购物车列表</title>
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

        .foot {
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

        .content {
            width: 100%;
            min-height: 180px;
            text-align: center;
        }

            .content .btn {
                width: 100px;
                height: 35px;
                font-size: 16pt;
                border: 2px solid #FFA500;
                color: #FFA500;
                background-color: white;
            }

        shoppingcartimg {
            position: relative;
            top: 25px;
        }

        #shoppingcart_table {
            width: 100%;
            border: 1px solid lightgray;
            font-size: 12pt;
        }

            #shoppingcart_table tr:hover {
                background-color: lightgray;
            }

        .paydiv {
            width: 100%;
            height: 40px;
            background-color: lightgray;
            margin-top: 5px;
            line-height: 40px;
        }

        #delChecked {
            text-decoration: none;
            color: black;
            float: left;
            font-size: 12pt;
            font-family: 微软雅黑;
            margin-left: 20px;
        }

        #btnPay {
            width: 110px;
            height: 40px;
            background-color: #F73E1C;
            color: white;
            border: none;
            position: relative;
            top: -4px;
            font-size: 16pt;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="head">
                <span class="spanleft" style="color: white">软帝科技</span>
                <div class="head_right">
                    <%if (Session["CrmUserInfo"] == null)
                      { %>
                    <span class="spanright"><a href="Regist.aspx">注册</a>| <a href="Login.aspx">登陆</a></span>
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
            <div class="content">
                <div id="emptyshoppintcart">
                    <img id="shoppingcartimg" src="../images/shoppingcart.png" alt="购物车" />
                    您的购物车是空的，您可以
                    <%if (Session["CrmUserInfo"] == null)
                      { %>
                    <input type="button" class="btn" value="立即登陆" onclick="javascript: window.location.href = 'login.aspx'" />
                    <%}
                      else
                      {%>
                    <input type="button" value="立即购物" class="btn" onclick="javascript: window.location.href = 'index.aspx'" />
                    <%} %>
                </div>
                <div id="goodslist">
                    <table id="shoppingcart_table" cellspacing="0">
                        <tr style="height: 30px; background-color: lightgray">
                            <th style="width: 80px;">
                                <input type="checkbox" id="checkAll" />全选</th>
                            <th style="width: 100px;"></th>
                            <th>商品信息</th>
                            <th style="width: 100px;">单价</th>
                            <th style="width: 100px">数量</th>
                            <th style="width: 100px">金额(元)</th>
                        </tr>
                        <asp:Repeater runat="server" ID="rp_ShoppingCartList">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <input type="checkbox" value='<%#Eval("sid") %>' name="ck" />
                                    </td>
                                    <td>
                                        <img src='<%#Eval("goodsimg") %>' alt="商品图片" width="70" height="70" />
                                    </td>
                                    <td align="left">
                                        <%#Maticsoft.Common.StringPlus.SubString(Eval("gname").ToString() ,20)%>
                                    </td>
                                    <td>
                                        <%#Eval("offsetPrice") %>
                                    </td>
                                    <td>
                                        <%#Eval("Count") %>
                                    </td>
                                    <td>
                                        <%#Eval("sumPay") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="paydiv">
                        <asp:LinkButton ID="delChecked" runat="server" Text="删除选中" OnClick="delChecked_Click"></asp:LinkButton>
                        <div style="float: right; width: 330px; height: 100%; text-align: right;">
                            <span style="font-size: 14pt;">合计：<label id="totalMoney" style="font-size: 22pt; color: red">￥0</label></span>
                            <asp:Button runat="server" ID="btnPay" Text="结算"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                var count = $("#shoppingcart_table tr").length;
                if (count <= 1) {
                    $("#goodslist").hide();
                    $("#emptyshoppintcart").show();
                }
                else {
                    $("#goodslist").show();
                    $("#emptyshoppintcart").hide();
                }
            </script>
            <div class="foot">
                <a href="#">关于易购</a>
                <a href="#">免现声明</a>
                <a href="#">合作伙伴</a>
                <a href="#">联系客服</a>
                &copy;softeem版权所有 &nbsp;2016
            </div>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                //全选与全不选
                $("#checkAll").click(function () {
                    $("input[name='ck']").each(function (index, element) {
                        $(element).attr("checked", $("#checkAll").attr("checked") == null ? false : true);
                    });
                });

                //删除选中值
                $("#delChecked").click(function () {
                    var flag = true;
                    var length = $("input[name='ck']:checked").length;
                    var sid = "";
                    if (length == null || length <= 0) {
                        alert("请选中要删除的数据");
                        flag = false;
                    }
                    else {
                        $("input[name='ck']:checked").each(function (index, element) {
                            sid += $(element).val() + ",";
                        });
                        if (sid.replace(",", "") == "") {
                            flag = false;
                        }
                    }
                    $("#hiddenSid").val(sid);
                    return flag;
                });

                $("input[name='ck']").click(function () {
                    CheckPayMoney();
                });
            });

            //计算应付金额
            function CheckPayMoney() {
                var sum = 0;
                $("input[name='ck']:checked").each(function (index, element) {
                    var money = $(element).parent().parent().children().eq(5).text().trim();
                    sum += parseFloat(money);
                });
                $("#totalMoney").text("￥" + sum);
            }

        </script>
        <asp:HiddenField ID="hiddenSid" runat="server" Value="" />
    </form>
</body>
</html>
