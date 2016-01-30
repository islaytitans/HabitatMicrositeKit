<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteBuilder.aspx.cs" Inherits="Sitecore.Habitat.Microsites.Dialogs.SiteBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
        <asp:Panel runat="server" ID="panelForm">
            <h1>Configure "<asp:Label runat="server" ID="lblSite"/>"</h1>
            <fieldset>
                <legend>Site Properties</legend>
            <div>
                 <ul>
                    <li>
                        <b>Site Properties for: <asp:Label runat="server" ID="lblSite"/> </b>
                        </li>

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
                        <asp:Label runat="server" AssociatedControlID="txtContent"> content:  </asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </li>

                      <li>
                        <asp:Label runat="server" AssociatedControlID="txtBgColour"> background color:  </asp:Label>
                        <asp:TextBox ID="txtBgColour" runat="server"></asp:TextBox>
                    </li>
                      <li>
                        <asp:Label runat="server" AssociatedControlID="txtTextColor"> text color:  </asp:Label>
                        <asp:TextBox ID="txtTextColor" runat="server"></asp:TextBox>
                </div>
                <div>                
                        <asp:Button ID="btnCreateSite" runat="server" Text="Save Settings" OnClick="btnCreateSite_Click" />
            </div>
            </fieldset>
        </asp:Panel>
          <asp:Panel runat="server" ID="panelUpdated" Visible="false">
              Site Settings updated!!
          </asp:Panel>
        </div>
    </form>
</body>
</html>
