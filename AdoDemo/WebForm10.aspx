<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm10.aspx.cs" Inherits="AdoDemo.WebForm10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Btn_GetData" runat="server" Text="Get Data from Database" OnClick="Btn_GetData_Click" />
            <asp:Button ID="Btn_DisplayRowState" runat="server" OnClick="Btn_DisplayRowState_Click" Text="Display RowState" />
            <asp:Button ID="Btn_UndoRowState" runat="server" Text="Undo RowState" OnClick="Btn_UndoRowState_Click" />
            <asp:Button ID="Btn_AcceptRowStateChanges" runat="server" OnClick="Btn_AcceptRowStateChanges_Click" Text="Accept RowState Changes" />
            <br />
            <br />
            <asp:GridView ID="Gvw_Students" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCancelingEdit="Gvw_Students_RowCancelingEdit" OnRowDeleting="Gvw_Students_RowDeleting" OnRowEditing="Gvw_Students_RowEditing" OnRowUpdating="Gvw_Students_RowUpdating">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" SortExpression="TotalMarks" />
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
            <br />
            <asp:Button ID="Btn_UpdateDatabase" runat="server" Text="Update Database Table" OnClick="Btn_UpdateDatabase_Click" />
            <br />
&nbsp;
            <asp:Label ID="Lbl_Message" Font-Bold="true" runat="server"></asp:Label>
            <br />
            <br />
            <%--            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" DeleteCommand="DELETE FROM [Students] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Students] ([Name], [Gender], [TotalMarks]) VALUES (@Name, @Gender, @TotalMarks)" SelectCommand="SELECT * FROM [Students]" UpdateCommand="UPDATE [Students] SET [Name] = @Name, [Gender] = @Gender, [TotalMarks] = @TotalMarks WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Gender" Type="String" />
                    <asp:Parameter Name="TotalMarks" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Gender" Type="String" />
                    <asp:Parameter Name="TotalMarks" Type="Int32" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>--%>
        </div>
    </form>
</body>
</html>
