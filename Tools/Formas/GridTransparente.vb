
Imports System.ComponentModel

Public Class GridTransparent
    Inherits DataGridView

    Private _DGVHasTransparentBackground As Boolean

    <Category("Transparency"), _
      Description("Select whether the control has a Transparent Background.")> Public Property DGVHasTransparentBackground As Boolean
        Get
            Return _DGVHasTransparentBackground
        End Get
        Set(ByVal value As Boolean)
            _DGVHasTransparentBackground = value
            If _DGVHasTransparentBackground Then
                SetTransparentProperties(True)
            Else
                SetTransparentProperties(False)
            End If
        End Set
    End Property

    Public Sub New()
        DGVHasTransparentBackground = True
    End Sub

    Private Sub SetTransparentProperties(ByRef SetAsTransparent As Boolean)
        If SetAsTransparent Then
            MyBase.DoubleBuffered = True
            MyBase.EnableHeadersVisualStyles = False
            MyBase.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent
            MyBase.RowHeadersDefaultCellStyle.BackColor = Color.Transparent
            SetCellStyle(Color.Transparent)
        Else
            MyBase.DoubleBuffered = False
            MyBase.EnableHeadersVisualStyles = True
            MyBase.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control
            MyBase.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control
            SetCellStyle(Color.White)
        End If
    End Sub

    Protected Overrides Sub PaintBackground(ByVal graphics As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal gridBounds As System.Drawing.Rectangle)
        MyBase.PaintBackground(graphics, clipBounds, gridBounds)

        If _DGVHasTransparentBackground Then
            If Not IsNothing(MyBase.Parent.BackgroundImage) Then
                Dim rectSource As New Rectangle(MyBase.Location, MyBase.Size)
                Dim rectDest As New Rectangle(0, 0, rectSource.Width, rectSource.Height)

                Dim b As New Bitmap(Parent.ClientRectangle.Width, Parent.ClientRectangle.Height)
                graphics.FromImage(b).DrawImage(MyBase.Parent.BackgroundImage, Parent.ClientRectangle)
                graphics.DrawImage(b, rectDest, rectSource, GraphicsUnit.Pixel)
            Else
                Dim myBrush As New SolidBrush(MyBase.Parent.BackColor)
                Dim rectDest As New Region(New Rectangle(0, 0, MyBase.Width, MyBase.Height))
                graphics.FillRegion(myBrush, rectDest)
            End If
        End If
    End Sub

    Protected Overrides Sub OnColumnAdded(ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
        MyBase.OnColumnAdded(e)
        If _DGVHasTransparentBackground Then
            SetCellStyle(Color.Transparent)
        End If
    End Sub

    Private Sub SetCellStyle(ByVal cellColour As Color)
        For Each col As DataGridViewColumn In MyBase.Columns
            col.DefaultCellStyle.BackColor = cellColour
            col.DefaultCellStyle.SelectionBackColor = cellColour
        Next
    End Sub
End Class
