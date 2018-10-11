<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm9.aspx.cs" Inherits="AdoDemo.WebForm9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Student ID"></asp:Label>
&nbsp;
            <asp:TextBox ID="Txt_StudentID" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Btn_LoadStudentID" runat="server" Text="Load" OnClick="Btn_LoadStudentID_Click" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="Txt_StudentName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="Ddl_Gender" runat="server">
                <asp:ListItem Text="Select Gender" Value="-1"></asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Total Marks"></asp:Label>
&nbsp;<asp:TextBox ID="Txt_TotalMarks" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Btn_Update" runat="server" Text="Update" OnClick="Btn_Update_Click" />
&nbsp;&nbsp;
            <asp:Label ID="Lbl_Message" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>
