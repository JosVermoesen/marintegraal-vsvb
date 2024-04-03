Public Class frmDokHistoriek
    Private Sub frmDokHistoriek_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dim X As Boolean
        X = InstellingenBewaard(Me)
    End Sub
    Private Sub frmDokHistoriek_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LaadInstellingen(Me)
    End Sub
End Class