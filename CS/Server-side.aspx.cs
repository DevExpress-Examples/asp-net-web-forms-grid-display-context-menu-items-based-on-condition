using DevExpress.Web.ASPxGridView;
using System.Linq;
using System.Web.UI;

public partial class ServerSide : Page {
    protected void Grid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e) {
        if (e.MenuType == GridViewContextMenuType.Rows) {
            e.Items.Clear();
            e.Items.Add(e.CreateItem("Custom item for all rows", "AllRows"));
            e.Items.Add(e.CreateItem("Custom item for selected rows only", "OnlySelectedRows"));
            e.Items.Add(e.CreateItem("Custom item for selected rows with 'Discontinued=true' only", "OnlySelectedAndDiscontinuedRows"));
        }
    }
    protected void Grid_ContextMenuItemVisibility(object sender, ASPxGridViewContextMenuItemVisibilityEventArgs e) {
        if (e.MenuType == GridViewContextMenuType.Rows) {
            GridViewContextMenuItem menuItemSelected = e.Items.Find(item => item.Name == "OnlySelectedRows") as GridViewContextMenuItem;
            GridViewContextMenuItem menuItemSelectedAndDiscontinued = e.Items.Find(item => item.Name == "OnlySelectedAndDiscontinuedRows") as GridViewContextMenuItem;
            for (int i = 0; i < Grid.VisibleRowCount; i++) {
                e.SetVisible(menuItemSelected, i, Grid.Selection.IsRowSelected(i));
                e.SetEnabled(menuItemSelectedAndDiscontinued, i, Grid.Selection.IsRowSelected(i) && (bool)Grid.GetRowValues(i, "Discontinued"));
            }
        }
    }
}