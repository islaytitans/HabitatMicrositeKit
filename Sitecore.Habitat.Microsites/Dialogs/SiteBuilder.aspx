<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteBuilder.aspx.cs" Inherits="Sitecore.Habitat.Microsites.Dialogs.SiteBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Site Properties</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
            <asp:Panel runat="server" ID="panelForm">
                <div>
                    <ul style="list-style: none">
                        <li>
                            <b>Site Properties for:
                            <asp:Label runat="server" ID="lblSite" />
                            </b>
                        </li>

                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtname">Site name: </asp:Label>
                            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtHostname">URL: </asp:Label>
                            <asp:TextBox ID="txtHostname" runat="server"></asp:TextBox>
                        </li>

                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtLanguage">Language: </asp:Label>
                            <asp:TextBox ID="txtLanguage" runat="server" Text="en"></asp:TextBox>
                        </li>

                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtBgColour">Background color:  </asp:Label>
                            <asp:TextBox ID="txtBgColour" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="txtTextColor">Text color:  </asp:Label>
                            <asp:TextBox ID="txtTextColor" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <asp:Button ID="btnCreateSite" runat="server" Text="Save Settings" OnClick="btnCreateSite_Click" />
                        </li>
                    </ul>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="panelUpdated" Visible="false">
                <div>
                    <ul style="list-style: none">
                        <li>Site Settings updated!!
                        </li>
                    </ul>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
