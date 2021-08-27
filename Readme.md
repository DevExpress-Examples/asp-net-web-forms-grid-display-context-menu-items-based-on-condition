<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128533088/14.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T120218)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Client-side.aspx](./CS/Client-side.aspx) (VB: [Client-side.aspx](./VB/Client-side.aspx))
* [Client-side.aspx.cs](./CS/Client-side.aspx.cs) (VB: [Client-side.aspx.vb](./VB/Client-side.aspx.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [Server-side.aspx](./CS/Server-side.aspx) (VB: [Server-side.aspx](./VB/Server-side.aspx))
* [Server-side.aspx.cs](./CS/Server-side.aspx.cs) (VB: [Server-side.aspx.vb](./VB/Server-side.aspx.vb))
<!-- default file list end -->
# ASPxGridView - Change visibility or disable context menu items based on selected row data
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t120218/)**
<!-- run online end -->


<p>There are two general approaches: server-side and client-side. In both cases, firstly, it's necessary to create all of the menu items using the <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxGridViewASPxGridView_FillContextMenuItemstopic.aspx">ASPxGridView.FillContextMenuItems</a> event. After that, some of menu items can be made invisible or disabled depending on certain conditions. </p>
<p><br /><strong><em>Server-side solution.<br /></em></strong>Handle the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_ContextMenuItemVisibilitytopic">ASPxGridView.ContextMenuItemVisibility</a> event and use its <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridViewContextMenuItemVisibilityEventArgs_SetVisibletopic">e.SetVisible</a> and <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridViewContextMenuItemVisibilityEventArgs_SetEnabledtopic">e.SetEnabled</a> methods to show/hide or enable/disable items respectively.</p>
<p>Note that these methods have overloaded versions that allow one to change visibility or enabled state for a specific row or a specific column.<br />It's very important to set the <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxGridViewASPxGridViewBehaviorSettings_ProcessSelectionChangedOnServertopic.aspx">ASPxGridViewBehaviorSettings.ProcessSelectionChangedOnServer</a> property value to <strong>true</strong>. In this case, each time a row is selected or unselected, a callback will be sent to the server and context menu items will be recalculated. If this property value is set to <strong>false</strong>, the context menu won't be updated after selecting or unselecting a row on the client side.<br />So, this approach requires callbacks to be sent to the server each time the end-user selects or unselects a row. This is why the server-side approach is less preferable than the client-side one.<br /><br /><strong><em>Client-side solution.<br /></em></strong>Since the grid's data isn't available on the client side, to hide or disable rows depending on certain data, we need to analyze that data on the server side to determine whether or not a row must be made invisible or disabled and pass this information to the client side. A good way to achieve this is to create a <strong>List<bool></strong> object that would contain required information and pass it to the client side as a <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_JSPropertiestopic">custom JavaScript property</a>.<br />Then handle the <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_ContextMenutopic.aspx">ASPxClientGridView.ContextMenu</a> event and use the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridViewContextMenuEventArgs_menutopic">e.menu</a> property to get the <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxMenuScriptsASPxClientPopupMenutopic">ASPxClientPopupMenu</a> object that represents the context menu. After that, you can use the <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxMenuScriptsASPxClientMenuBase_GetItemByNametopic.aspx">e.menu.GetItemByName</a> method to get a menu item and then the <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxMenuScriptsASPxClientMenuItem_SetEnabledtopic.aspx">SetEnabled</a> and <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxMenuScriptsASPxClientMenuItem_SetVisibletopic.aspx">SetVisible</a> methods to enable/disable or show/hide items respectively.</p>
<p><br />In the example, there are three items in the context menu. The first of them is always visible and enabled; the second is always enabled, but visible only for selected rows; and the third one is always visible, but enabled only for selected rows that have a corresponding <strong>"Discontinued"</strong> field value set to <strong>"true"</strong>. There are two pages in the example that demonstrate both the client-side and the server-side approaches.</p>

<br/>


