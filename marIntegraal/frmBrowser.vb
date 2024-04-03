Option Strict Off
Option Explicit On
Imports System.ComponentModel

Public Class Browser
    Public StartingAddress As String
    Dim mbDontNavigateNow As Boolean

    Private Sub frmBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If StartingAddress = "" Then
        Else
            ToolStripTextBox1.Text = StartingAddress
            goButton.PerformClick
        End If

    End Sub

    ' Navigates to the URL in the address box when 
    ' the ENTER key is pressed while the ToolStripTextBox has focus.
    Private Sub toolStripTextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles toolStripTextBox1.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            Navigate(toolStripTextBox1.Text)
        End If

    End Sub

    ' Navigates to the given URL if it is valid.
    Private Sub Navigate(ByVal address As String)

        If String.IsNullOrEmpty(address) Then Return
        If address.Equals("about:blank") Then Return
        If Not address.StartsWith("http://") And Not address.StartsWith("https://") Then
            address = "http://" & address
        End If

        Try
            webBrowser1.Navigate(New Uri(address))
        Catch ex As System.UriFormatException
            Return
        End Try

    End Sub

    ' Updates the URL in TextBoxAddress upon navigation.
    Private Sub webBrowser1_Navigated(ByVal sender As Object, ByVal e As WebBrowserNavigatedEventArgs) Handles webBrowser1.Navigated

        toolStripTextBox1.Text = webBrowser1.Url.ToString()

    End Sub

    Private Sub cmdSluiten_Click(sender As Object, e As EventArgs) Handles cmdSluiten.Click

        Msg = "Internet ExplorerVenster Sluiten.  Bent U zeker"
        If MsgBox(Msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then
            Me.Close()
        End If

    End Sub

    ' Navigates to the URL in the address box when 
    ' the Go button is clicked.
    Private Sub goButton_Click(sender As Object, e As EventArgs) Handles goButton.Click

        Navigate(toolStripTextBox1.Text)

    End Sub

    Private Sub Browser_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Select Case Text
            Case "Hosting"
                Mim.HostingToolStripMenuItem.Enabled=True 

            Case "SmarterMail"
                Mim.SmartermailToolStripMenuItem.Enabled=True 

            Case "marIntegraal"
                Mim.marIntegraalToolStripMenuItem.Enabled=True 
        End Select

    End Sub
End Class
