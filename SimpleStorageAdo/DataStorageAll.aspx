<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataStorageAll.aspx.cs" Inherits="SimpleStorageAdo.DataStorageAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <div style="width:100%">
     <a href="DataStorageApp.aspx" style="float:right">Search or Add</a>
    </div>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
