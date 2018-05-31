<%@ Register TagPrefix="uc1" TagName="CopyRight" Src="../../Controls/copyright.ascx" %>

<%@ Page Language="c#" Codebehind="treelist.aspx.cs" AutoEventWireup="True" Inherits="Maticsoft.Web.SysManage.treelist" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="../../Controls/CheckRight.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="LtpPageControl" Assembly="LtpPageControl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>treelist</title>
    <link href="../../style.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <br>
        <table cellspacing="0" cellpadding="5" width="90%" align="center" border="0">
            <tr>
                <td width="100" height="15" style="height: 15px">
                    <div align="right">
                        父类：</div>
                </td>
                <td height="15">
                    <asp:DropDownList ID="listTarget" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="listTarget_SelectedIndexChanged">
                        <asp:ListItem Value="0" Selected="True">根目录</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
        <cc1:Page01 ID="Page011" runat="server" Page_Index="treelist.aspx" Page_Add="add.aspx"
            Page_Makesql="makesql.aspx"></cc1:Page01>
        <table cellspacing="0" cellpadding="5" width="90%" align="center" border="0">
            <tr>
                <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                    <asp:DataGrid ID="grid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        Width="100%" DataKeyField="NodeID" PageSize="15">
                        <Columns>
                            <asp:BoundColumn DataField="NodeID" ReadOnly="True" HeaderText="编号">
                                <HeaderStyle Width="30px"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="OrderID" HeaderText="同类排序">
                                <HeaderStyle Width="55px"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Text" ReadOnly="True" HeaderText="名称">
                                <HeaderStyle Width="120px"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="comment" ReadOnly="True" HeaderText="描述"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Url" ReadOnly="True" HeaderText="链接"></asp:BoundColumn>
                            <asp:HyperLinkColumn Text="详细" DataNavigateUrlField="NodeID" DataNavigateUrlFormatString="show.aspx?id={0}"
                                HeaderText="详细">
                                <HeaderStyle Width="30px"></HeaderStyle>
                            </asp:HyperLinkColumn>
                            <asp:HyperLinkColumn Text="修改" DataNavigateUrlField="NodeID" DataNavigateUrlFormatString="modify.aspx?id={0}"
                                HeaderText="修改">
                                <HeaderStyle Width="30px"></HeaderStyle>
                            </asp:HyperLinkColumn>
                            <asp:HyperLinkColumn Text="删除" DataNavigateUrlField="NodeID" DataNavigateUrlFormatString="delete.aspx?id={0}"
                                HeaderText="删除">
                                <HeaderStyle Width="30px"></HeaderStyle>
                            </asp:HyperLinkColumn>
                        </Columns>
                        <PagerStyle Visible="False"></PagerStyle>
                    </asp:DataGrid></td>
            </tr>
        </table>
        <cc1:Page02 ID="Page021" runat="server" Page_Index="treelist.aspx"></cc1:Page02>
        <uc1:CopyRight ID="CopyRight1" runat="server"></uc1:CopyRight>
        <uc1:CheckRight ID="CheckRight1" runat="server" PermissionID="2"></uc1:CheckRight>
    </form>
</body>
</html>
