<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="AdoDemo.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Employee Name:
            <asp:TextBox ID="Txt_EmployeeName" runat="server"></asp:TextBox>
            <br />
            Gender:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Ddl_Gender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <br />
            Salary:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Txt_Salary" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Btn_AddEmployee" runat="server" OnClick="Btn_AddEmployee_Click" Text="Add Employee" />
            <br />
            <br />
            <asp:Label ID="Lbl_Message" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
