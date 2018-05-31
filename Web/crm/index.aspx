<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MyEasyBuy.crm.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎光临MyEasyBuy商城</title>
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <style type="text/css">
		.main
		{
			width: 900px;
			margin: auto;
		}
		.head
		{
			height: 30px;
			background-color: #FFA500;
			line-height: 30px;
			padding-right:10px;
			padding-left: 10px;
		}
		.spanleft
		{
			float: left;
		}
		.spanright
		{
			margin-left: 10px;
		}
		.spanleft a,.spanright a
		{
			text-decoration: none;
			color: black;
			font-size: 10pt;
			font-weight: bold;
		}
		.head_right
		{
			display: inline-block;
			float: right;
		}
		.logo
		{
			float: left;
		}
		
		.divbb
		{
			width: 80px;
			height: 30px;
			background-color: #FFA500;
			text-align: center;
			font-weight: bold;
			color: white;
			line-height: 30px;
			display: inline-block;
			position: relative;
			top: 2px;
		}
		.txt
		{
			height: 24px;
			border: 2px solid #FFA500;
			width: 380px;
		}   
		.btn
		{
			height: 30px;
			width: 100px;
			font-weight: bold;
			color: white;
			background-color: #FFA500;
			border: none;
			cursor: pointer;
		}
		.divsearch
		{
			height: 76px;
			line-height: 76px;
			float: left;
			width: 720px;
			text-align: center;
		}
		.divfenlei
		{
			clear: both;
			height: 30px;
			line-height: 30px;
			border-top: 1px solid #FFA500;
			border-bottom: 1px solid #FFA500;
         
		}
		.divfenlei a
		{
			text-decoration: none;
			font-weight: bold;
			color: black;
			margin-left: 10px;
		}
		.contentDiv
		{
			margin-top: 5px;
			width: 100%;
			min-height: 600px;
			
		}
		.gooddiv
		{
			width: 220px;
			height: 290px;
			float: left;
			text-align: center;
			cursor: pointer;
		}
		.goodname
		{
			font-weight: bold;
			font-size: 11pt;

		}
		.gooddiv_bottom
		{
			list-style: none;
			width: 200px;
			padding: 0px;
			margin: 0px;
		}
		.gooddiv_bottom li
		{
			display: block;
			float: left;
			width: 100px;
			font-weight: bold;
		}
		.foot
		{
		    margin-top: 10px;
			clear: both;
			height: 30px;
			background-color: #FFA500;
			line-height: 30px;
			text-align: center;
		}
		.foot a
		{
			text-decoration: none;
			font-weight: bold;
			color: black;
			font-size: 11pt;
			margin-left: 3px;
		}
        #div_pagelist
        {
            text-align:center;
            
        }
        #div_pagelist a
        {
            font-size:16pt;
            color:black;
            display:inline-block;
            width:30px;
            height:30px;
            text-align:center;
            line-height:30px;
            border:1px solid black;
            text-decoration:none;
            margin-left:10px;
        }
	</style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".gooddiv").hover(function () {
                $(this).css("height", "288px");
                $(this).css("border", "1px solid #FFA500");
            }, function () {
                $(this).css("border", "none");
                $(this).css("height", "290px");
            });

            $("#div_pagelist >a ").click(function () {
                $(this).css("background-color", "orange");
                $(this).siblings().css("background-color", "");
            });


            $(".gooddiv").click(function () {
                //第一步：获取gid的值
                var gid = $(this).attr("yangbiao");
                window.open("GoodsInfo.aspx?gid=" + gid);
            });
        });
	</script>
</head>
<body>
    <form id="form1" runat="server">
<div class="main">
		<div class="head">
			<span class="spanleft" style="color:white">****科技</span>
			<div class="head_right">
                <%if(Session["CrmUserInfo"]==null){ %>
				<span class="spanright"><a href="Regist.aspx">注册</a>| <a href="Login.aspx">登陆</a></span>
                <%} else{ %>
                <span class="spanright"><%=(Session["CrmUserInfo"] as MyEasyBuy.Model.eb_customer).UserName %><asp:LinkButton runat="server" ID="lbLogOut" Text="安全退出" OnClick="lbLogOut_Click"></asp:LinkButton></span>
                <%} %>
				<span class="spanright"><a href="#">我的订单</a></span>
				<span class="spanright"><a href="ShoppingCartList.aspx">购物车</a></span>
			</div>
		</div>
		<div class="logodiv">
			<img class="logo" src="../images/logo1.png" alt="logo" />
			<div class="divsearch">
				<div class="divbb">
					搜宝贝
				</div>
                <asp:TextBox runat="server" CssClass="txt" ID="txtQuery"></asp:TextBox>
                <asp:Button ID="btnQuery" runat="server" CssClass="btn" Text="易购搜索" OnClick="btnQuery_Click" />
			</div>
		</div>
		<div class="divfenlei">
			<asp:LinkButton runat="server" Text="全部分类" CommandArgument="0" OnClick="Category_Click"></asp:LinkButton>
            <asp:Repeater runat="server" ID="rp_Category">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text='<%#Eval("cname") %>' CommandArgument='<%#Eval("cid") %>' OnClick="Category_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
		</div>
		<div class="contentDiv">
            <asp:Repeater runat="server" ID="rp_goods">
                <ItemTemplate>
                    <div class="gooddiv" yangbiao='<%#Eval("gid") %>'>
                        <asp:Image runat="server" ImageUrl='<%#Eval("goodsimg") %>' Width="200" Height="220" AlternateText="商品图片" />
				        <div class="goodname">
                            <%#Eval("gname") %>
				        </div>
				        <div>
					        <ul class="gooddiv_bottom">
						        <li style="color:red">￥<%#Eval("price") %></li>
						        <li>库存：<%#Eval("total") %></li>
					        </ul>
				        </div>
			        </div>
                </ItemTemplate>
            </asp:Repeater>
		</div>
    <!-- 这里，应该放一个分页的功能-->
    <div id="div_pagelist">
        <asp:Repeater runat="server" id="rp_pagelist">
           <ItemTemplate>
               <asp:LinkButton runat="server" CommandArgument='<%#Eval("value") %>' Text='<%#Eval("text") %>' OnClick="PageList_Click"></asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>
    </div>
		<div class="foot">
			<a href="#">关于易购</a>
			<a href="#">免现声明</a>
			<a href="#">合作伙伴</a>
			<a href="#">联系客服</a>
			&copy;softeem版权所有 &nbsp;2016
		</div>
	</div>
    </form>
</body>
</html>
