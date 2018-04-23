Imports Microsoft.VisualBasic
Imports DevExpress.Web.ASPxGridView
Imports System.Linq
Imports System.Web.UI

Partial Public Class ServerSide
	Inherits Page
	Protected Sub Grid_FillContextMenuItems(ByVal sender As Object, ByVal e As ASPxGridViewContextMenuEventArgs)
		If e.MenuType = GridViewContextMenuType.Rows Then
			e.Items.Clear()
			e.Items.Add(e.CreateItem("Custom item for all rows", "AllRows"))
			e.Items.Add(e.CreateItem("Custom item for selected rows only", "OnlySelectedRows"))
			e.Items.Add(e.CreateItem("Custom item for selected rows with 'Discontinued=true' only", "OnlySelectedAndDiscontinuedRows"))
		End If
	End Sub
	Protected Sub Grid_ContextMenuItemVisibility(ByVal sender As Object, ByVal e As ASPxGridViewContextMenuItemVisibilityEventArgs)
		If e.MenuType = GridViewContextMenuType.Rows Then
			Dim menuItemSelected As GridViewContextMenuItem = TryCast(e.Items.Find(Function(item) item.Name = "OnlySelectedRows"), GridViewContextMenuItem)
			Dim menuItemSelectedAndDiscontinued As GridViewContextMenuItem = TryCast(e.Items.Find(Function(item) item.Name = "OnlySelectedAndDiscontinuedRows"), GridViewContextMenuItem)
			For i As Integer = 0 To Grid.VisibleRowCount - 1
				e.SetVisible(menuItemSelected, i, Grid.Selection.IsRowSelected(i))
				e.SetEnabled(menuItemSelectedAndDiscontinued, i, Grid.Selection.IsRowSelected(i) AndAlso CBool(Grid.GetRowValues(i, "Discontinued")))
			Next i
		End If
	End Sub
End Class