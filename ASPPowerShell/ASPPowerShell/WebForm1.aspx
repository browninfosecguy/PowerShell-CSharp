<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPPowerShell.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
            <asp:listitem text="Select" value="0"></asp:listitem>
            <asp:listitem text="Get-ChildItem" value="1"></asp:listitem>
            <asp:listitem text="Get-Process" value="2"></asp:listitem>
            <asp:listitem text="Get-Service" value="3"></asp:listitem>
            <asp:listitem text="Get-ComputerInfo" value="4"></asp:listitem>
        </asp:DropDownList>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
    </form>
</body>
</html>
