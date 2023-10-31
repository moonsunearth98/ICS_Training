<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Store Application</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Hey! Welcome to Prachi's Store</h1>
        <asp:DropDownList ID="ddlItems" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged">
            <asp:ListItem Text="Select an item" Value="" />
            <asp:ListItem Text="Bracelet" Value="bracelet.jpg" />
            <asp:ListItem Text="Earring" Value="earring.jpg"/>
            <asp:ListItem Text="Necklace" Value="necklace.jpg" />
            <asp:ListItem Text="Sunglass" Value="sunglass.jpg" />

        </asp:DropDownList>

        <br />
        <asp:Button ID="btnShowCost" runat="server" Text="Show Cost" OnClick="btnShowCost_Click" />
        <br />
        <asp:Image ID="imgItem" runat="server" Width="300px" Height="300px"/>

        <br />
        <asp:Label ID="lblCost" runat="server" Text="" />
    </form>
</body>
</html>
