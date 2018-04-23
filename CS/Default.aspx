<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to change certain context menu items' visibility or their enabled state depending on both whether a corresponding row is selected and a part of its data</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            There are two pages in example that demonstrates both the client-side and the server-side approaches.
			<br />
            <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Server-side solution" NavigateUrl="Server-side.aspx">
            </dx:ASPxHyperLink>
            <br />
            <dx:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="Client-side solution" NavigateUrl="Client-side.aspx">
            </dx:ASPxHyperLink>
        </div>
    </form>
</body>
</html>
