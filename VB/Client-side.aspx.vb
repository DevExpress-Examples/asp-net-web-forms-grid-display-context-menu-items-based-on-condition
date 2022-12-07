Imports Microsoft.VisualBasic
Imports DevExpress.Web
Imports System.Collections.Generic
Imports System.Web.UI

Partial Public Class ClientSide
	Inherits Page
	Protected Sub Grid_FillContextMenuItems(ByVal sender As Object, ByVal e As ASPxGridViewContextMenuEventArgs)
		If e.MenuType = GridViewContextMenuType.Rows Then
			e.Items.Clear()
			e.Items.Add(e.CreateItem("Custom item for all rows", "AllRows"))
			e.Items.Add(e.CreateItem("Custom item for selected rows only", "OnlySelectedRows"))
			e.Items.Add(e.CreateItem("Custom item for selected rows with 'Discontinued=true' only", "OnlySelectedAndDiscontinuedRows"))
		End If
	End Sub
	Protected Sub Grid_CustomJSProperties(ByVal sender As Object, ByVal e As ASPxGridViewClientJSPropertiesEventArgs)
		Dim list As New List(Of Boolean)()
		For i As Integer = 0 To Grid.VisibleRowCount - 1
			list.Add(CBool(Grid.GetRowValues(i, "Discontinued")))
		Next i
		e.Properties("cpDiscontinued") = list
	End Sub
End Class