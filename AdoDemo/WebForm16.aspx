<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm16.aspx.cs" Inherits="AdoDemo.WebForm16" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="text-align: left; color: white; background-color: darkred">
                <tr>
                    <th>Account Number</th>
                    <td><asp:Label ID="Lbl_AccountNo1" runat="server"></asp:Label></td>
                    <td><asp:Label ID="Lbl_AccountNo2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>Customer Name</th>
                    <td><asp:Label ID="Lbl_CustName1" runat="server"></asp:Label></td>
                    <td><asp:Label ID="Lbl_CustName2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>Balance</th>
                    <td><asp:Label ID="Lbl_Balance1" runat="server"></asp:Label></td>
                    <td><asp:Label ID="Lbl_Balance2" runat="server"></asp:Label></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="Btn_Transfer" runat="server" Text="Transfer $10 from A1 to A2" OnClick="Btn_Transfer_Click" />
            <br />
            <br />
            <asp:Label ID="Lbl_Message" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
