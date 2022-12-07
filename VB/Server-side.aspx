<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Server-side.aspx.vb" Inherits="ServerSide" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Server-side approach</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            There are three items in the context menu. 
			<br />
            The first of them is always visible and enabled, the second is always enabled, but visible only for selected rows, 
            and the third one is always visible, but enabled only for the selected rows that have corresponding "Discontinued" field value "true". 
			<br />
            <dx:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" DataSourceID="Source" KeyFieldName="ProductID"
                OnFillContextMenuItems="Grid_FillContextMenuItems" OnContextMenuItemVisibility="Grid_ContextMenuItemVisibility">
                <Columns>
                    <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="3">
                    </dx:GridViewDataCheckColumn>
                </Columns>
                <SettingsContextMenu Enabled="true" />
                <SettingsBehavior ProcessSelectionChangedOnServer="true" />
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="Source" runat="server"
                ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                SelectCommand="SELECT [ProductID], [ProductName], [Discontinued] FROM [Products]"></asp:SqlDataSource>
			<dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Home" NavigateUrl="Default.aspx">
            </dx:ASPxHyperLink>
            <br />
            <dx:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="Client-side solution" NavigateUrl="Client-side.aspx">
            </dx:ASPxHyperLink>
        </div>
    </form>
</body>
</html>
