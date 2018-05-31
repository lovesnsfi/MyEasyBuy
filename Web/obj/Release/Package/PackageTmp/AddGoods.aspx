<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGoods.aspx.cs" Inherits="MyEasyBuy.AddGoods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加商品</title>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <link type="text/css" href="css/comm.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="title">商品管理--&gt;&gt;商品上架</div>
        <div class="form_box">

            <table>
                <tr>
                    <td width="25%" align="right">名称:</td>
                    <td>
                        <asp:TextBox ID="gname" runat="server" CssClass="txt" placeholder="请输入商品名称"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">分类:</td>
                    <td>
                        <asp:DropDownList ID="Dropcategory" CssClass="txt" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">单价:</td>
                    <td>
                        <asp:TextBox ID="price" runat="server" placeholder="请输入单价" CssClass="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">折扣:</td>
                    <td>
                        <asp:TextBox runat="server" ID="offset" CssClass="txt" placeholder="请输入折扣"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">库存:</td>
                    <td>
                        <asp:TextBox runat="server" ID="total" CssClass="txt" placeholder="请输入库存"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">图片</td>
                    <td>
                        <asp:FileUpload runat="server" ID="goodsimg" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" CssClass="btn" Text="添加" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hiddenGid" runat="server" Value="" />
            
</form>
</body>
</html>
