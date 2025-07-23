Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.Utils.Drawing

Namespace WindowsApplication1
    Public Class MyGridPainter
        Inherits GridPainter

        Private _IsCustomPainting As Boolean
        Public Property IsCustomPainting() As Boolean
            Get
                Return _IsCustomPainting
            End Get
            Set(ByVal value As Boolean)
                _IsCustomPainting = value
            End Set
        End Property
        Public Sub New(ByVal view As GridView)
            MyBase.New(view)
        End Sub
        Public Sub DrawMergedCell(ByVal cell As MyMergedCell, ByVal e As PaintEventArgs)
            Try
                Dim delta As Integer = cell.Column1.VisibleIndex - cell.Column2.VisibleIndex
                If Math.Abs(delta) > 1 Then
                    Return
                End If
                Dim vi As GridViewInfo = TryCast(View.GetViewInfo(), GridViewInfo)
                Dim gridCellInfo1 As GridCellInfo = vi.GetGridCellInfo(cell.RowHandle, cell.Column1)
                Dim gridCellInfo2 As GridCellInfo = vi.GetGridCellInfo(cell.RowHandle, cell.Column2)
                If gridCellInfo1 Is Nothing OrElse gridCellInfo2 Is Nothing Then
                    Return
                End If
                Dim targetRect As Rectangle = Rectangle.Union(gridCellInfo1.Bounds, gridCellInfo2.Bounds)
                gridCellInfo1.Bounds = targetRect
                gridCellInfo1.CellValueRect = targetRect
                gridCellInfo2.Bounds = targetRect
                gridCellInfo2.CellValueRect = targetRect
                If delta < 0 Then
                    gridCellInfo1 = gridCellInfo2
                End If
                Dim bounds As Rectangle = gridCellInfo1.ViewInfo.Bounds
                bounds.Width = targetRect.Width
                bounds.Height = targetRect.Height
                gridCellInfo1.ViewInfo.Bounds = bounds
                gridCellInfo1.ViewInfo.CalcViewInfo(e.Graphics)
                IsCustomPainting = True
                Using cache As New GraphicsCache(e.Graphics)
                    gridCellInfo1.Appearance.FillRectangle(cache, gridCellInfo1.Bounds)
                    gridCellInfo1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    DrawRowCell(New GridViewDrawArgs(cache, vi, vi.ViewRects.Bounds), gridCellInfo1)
                End Using

                IsCustomPainting = False
            Catch ex As Exception

            End Try

        End Sub

    End Class

End Namespace
