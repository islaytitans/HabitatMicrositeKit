<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteBuilder.aspx.cs" Inherits="Sitecore.Habitat.Microsites.Dialogs.SiteBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li>
                    <asp:Label runat="server" AssociatedControlID="txtname">name: </asp:Label>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                </li>
                <li>
                    <asp:Label runat="server" AssociatedControlID="txtHostname"> hostname: </asp:Label>
                    <asp:TextBox ID="txtHostname" runat="server"></asp:TextBox>
                </li>
                <li>
                    <asp:Label runat="server" AssociatedControlID="txtRootPath"> rootPath:</asp:Label>
                    <asp:TextBox ID="txtRootPath" runat="server"></asp:TextBox>
                </li>
                <li>
                    <asp:Label runat="server" AssociatedControlID="txtStartItem"> startItem:</asp:Label>
                    <asp:TextBox ID="txtStartItem" runat="server"></asp:TextBox>
                </li>

                <li>
                    <asp:Label runat="server" AssociatedControlID="txtLanguage"> language: </asp:Label>
                    <asp:TextBox ID="txtLanguage" runat="server"></asp:TextBox>
                </li>
                <li>
                    <asp:Label runat="server" AssociatedControlID="txtDatabase"> database: </asp:Label>
                    <asp:TextBox ID="txtDatabase" runat="server"></asp:TextBox>
                </li>
                <li>
                    <asp:Label runat="server" AssociatedControlID="txtContent"> content:  </asp:Label>
                    <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
                </li>
                <li>
                    <asp:Button ID="btnCreateSite" runat="server" Text="Save Settings" OnClick="btnCreateSite_Click" />
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
