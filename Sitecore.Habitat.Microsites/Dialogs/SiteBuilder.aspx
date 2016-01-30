<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteBuilder.aspx.cs" Inherits="Sitecore.Habitat.Microsites.Dialogs.SiteBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        name: <asp:TextBox ID="txtname" runat="server"></asp:TextBox>

         hostname: <asp:TextBox ID="txtHostname" runat="server"></asp:TextBox>

         rootPath: <asp:TextBox ID="txtRootPath" runat="server"></asp:TextBox>

        startItem: <asp:TextBox ID="txtStartItem" runat="server"></asp:TextBox>

         language: <asp:TextBox ID="txxtLanguage" runat="server"></asp:TextBox>

        database: <asp:TextBox ID="txtDatabase" runat="server"></asp:TextBox>

        content: <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
        
        <asp:Button ID="btnCreateSite" runat="server" Text="Button" OnClick="btnCreateSite_Click" />
    
    </div>
    </form>
</body>
</html>
