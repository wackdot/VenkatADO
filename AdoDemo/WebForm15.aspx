<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm15.aspx.cs" Inherits="AdoDemo.WebForm15" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Btn_BulkTransfer" runat="server" OnClick="Btn_BulkTransfer_Click" Text="Start Bulk Transfer" />
            <br />
            <br />
            <asp:Label ID="Lbl_ProgressStatus" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
