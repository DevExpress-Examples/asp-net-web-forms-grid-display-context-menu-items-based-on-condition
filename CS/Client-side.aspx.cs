using DevExpress.Web.ASPxGridView;
using System.Collections.Generic;
using System.Web.UI;

public partial class ClientSide : Page {
    protected void Grid_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e) {
        if (e.MenuType == GridViewContextMenuType.Rows) {
            e.Items.Clear();
            e.Items.Add(e.CreateItem("Custom item for all rows", "AllRows"));
            e.Items.Add(e.CreateItem("Custom item for selected rows only", "OnlySelectedRows"));
            e.Items.Add(e.CreateItem("Custom item for selected rows with 'Discontinued=true' only", "OnlySelectedAndDiscontinuedRows"));
        }
    }
    protected void Grid_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e) {
        List<bool> list = new List<bool>();
        for (int i = 0; i < Grid.VisibleRowCount; i++)
            list.Add((bool)Grid.GetRowValues(i, "Discontinued"));
        e.Properties["cpDiscontinued"] = list;
    }
}