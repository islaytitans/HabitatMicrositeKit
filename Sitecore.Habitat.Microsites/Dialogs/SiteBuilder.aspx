<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteBuilder.aspx.cs" Inherits="Sitecore.Habitat.Microsites.Dialogs.SiteBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="/assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
<link href="/assets/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" />
<link href="/assets/plugins/animate/animate.min.css" rel="stylesheet" />
<link href="/assets/Sitecore.Foundation.Theming.css" rel="stylesheet" />
<link href="/Content/Media/ekko-lightbox.min.css" rel="stylesheet" />
<style>
    body { padding: 25px; }
    label { width: 150px;}
    fieldset { margin-bottom: 50px;}
</style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="panelForm">
            <h1>Configure "<asp:Label runat="server" ID="lblSite"/>"</h1>
            <fieldset>
                <legend>Site Properties</legend>
                <div>
                    <asp:Label runat="server" AssociatedControlID="txtHostname">hostname</asp:Label>
                    <asp:TextBox ID="txtHostname" runat="server"></asp:TextBox>
                </div>
                <div>     
                    <asp:Label runat="server" AssociatedControlID="txtLanguage">language</asp:Label>
                    <asp:TextBox ID="txtLanguage" runat="server"></asp:TextBox>
                </div>
                <div>            
                    <asp:Label runat="server" AssociatedControlID="txtDatabase">database</asp:Label>
                    <asp:TextBox ID="txtDatabase" runat="server"></asp:TextBox>
                </div>
            </fieldset>
            <fieldset>
                <legend>Theming</legend>
                <div>           
                    <asp:Label runat="server" AssociatedControlID="txtBgColour">background color</asp:Label>
                    <asp:TextBox ID="txtBgColour" runat="server"></asp:TextBox>
                </div>
                <div>               
                    <asp:Label runat="server" AssociatedControlID="txtTextColor">text color</asp:Label>
                    <asp:TextBox ID="txtTextColor" runat="server"></asp:TextBox>
                </div>
                <div>                
                   <asp:Button ID="btnCreateSite" runat="server" Text="Save Settings" OnClick="btnCreateSite_Click" />
                </div>
            </fieldset>
        </asp:Panel>
          <asp:Panel runat="server" ID="panelUpdated" Visible="false">
              <h1>Site Settings updated!!</h1>
          </asp:Panel>
    </form>
</body>
</html>
