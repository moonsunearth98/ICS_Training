<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="UserInfo.Validator" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="Name">Name:</label>
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            <br />
            <label for="FamilyName">Family Name:</label>
            <asp:TextBox ID="FamilyName" runat="server"></asp:TextBox>
            <br />
            <label for="Address">Address:</label>
            <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            <br />
            <label for="City">City:</label>
            <asp:TextBox ID="City" runat="server"></asp:TextBox>
            <br />
            <label for="ZipCode">Zip Code:</label>
            <asp:TextBox ID="ZipCode" runat="server"></asp:TextBox>
            <br />
            <label for="Phone">Phone:</label>
            <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            <br />
            <label for="Email">E-mail address:</label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="CheckButton" runat="server" Text="Check" OnClick="CheckButton_Click" />
            <br />
            <asp:Literal ID="ValidationSummary" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
