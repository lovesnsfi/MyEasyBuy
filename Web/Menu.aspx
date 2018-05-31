<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="MyEasyBuy.Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>菜单</title>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <style type="text/css">
        body
        {
            background-color:#808080;  /*设置网页的背景色*/
            margin:0px;
        }
        .menu
        {
            list-style:none;   /*去掉前面的小点点*/
            padding:0px;    /*去掉前面的空白部分*/
            margin:0px;
        }
        .menu li a
        {
            text-decoration:none; /*去掉下划线*/
            color:white;  /*设置字体的颜色*/
            font-size:18pt;  /*设置字体的大小*/
            width:200px;
            height:30px; 
            line-height:30px;  /*设置行高，呈现上下居中的效果*/
            display:block;   /*呈现块级显示*/
            text-align:center;  /*字体居中*/
            background-image:url(images/title.jpg);   /*设置背景图片*/
        }
        .submenu
        {
            list-style:none;  /*去掉的是子菜单前面的小点*/
            padding:0px;
            display:none;   /*首先应该隐藏子菜单*/
        }
        .submenu li a
        {
            font-size:14pt;
            background-image:none;
        }
        .submenu li a:hover   /*鼠标滑过子菜单以后的效果*/
        {
            background-color:white;
            color:black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <!--主菜单 -->
        <ul class="menu">
            <li><a href="#">商品管理</a>
                <ul class="submenu">
                    <li><a href="AddGoods.aspx" target="main">商品上架</a></li>
                    <li><a href="GoodsList.aspx" target="main">商品列表</a></li>
                </ul>
            </li>
            <li><a href="#">分类管理</a>
                <ul class="submenu">
                    <li><a href="AddCategory.aspx" target="main">分类添加</a></li>
                    <li><a href="CategoryList.aspx" target="main">分类管理</a></li>
                </ul>
            </li>
            <li><a href="#">订单管理</a>
                <ul class="submenu">
                    <li><a href="#">订单列表</a></li>
                </ul>
            </li>
            <li><a href="#">客户管理</a>
                <ul class="submenu">
                    <li><a href="#">客户列表</a></li>
                    <li><a href="#">权限设置</a></li>
                </ul>
            </li>
            <li><a href="#">系统管理</a>
                <ul class="submenu">
                    <li><a href="#">个人信息</a></li>
                    <li><a href="#">修改密码</a></li>
                    <li><a href="#">新增管理员</a></li>
                    <li><a href="#">管理员列表</a></li>
                    <li><a href="#">系统退出</a></li>
                </ul>
            </li>
        </ul>
    </div>
    </form>
    <script type="text/javascript">
        //在这里，写JavaScript代码
        $(document).ready(function () {
            $(".menu >li >a").click(function () {
                $(this).next(".submenu").slideToggle("fast");
                 return false;
            });
        });
    </script>
</body>
</html>
