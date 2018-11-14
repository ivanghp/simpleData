<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataStorageApp.aspx.cs" Inherits="SimpleStorageAdo.StorageApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="scripts.webforms.bootstrap.min.js" />
</head>
<body>
    <div style="width:100%">
     <a href="DataStorageAll.aspx" style="float:right">See All</a>
    </div>
    <form id="form1" runat="server">
        <div>
            <div class="col-sm-6">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
            <%--<br />--%>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            <%--<br />--%>
            </div>
            <div class="col-sm-6">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            </div>
            <h2>add new item</h2>
            <text>Item Name</text><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <text>Unit</text><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <text>Quantity</text><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
            <%--<asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>--%>
                <%-- <asp:GridView ID="GridView3" runat="server"></asp:GridView>--%>
                <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            <%--<asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>--%>
        </div>
    </form>
    
</body>
</html>
