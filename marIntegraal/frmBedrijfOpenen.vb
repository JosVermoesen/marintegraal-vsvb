﻿Option Strict Off
Option Explicit On
Public Class frmBedrijfOpenen
    Dim flgVerwijderen As Boolean
    Dim strDataLocatie As String

    Private Sub frmBedrijfOpenen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        flgVerwijderen = False

        Top = 0
        Left = 0

        bedrijvenListView.Columns.Add("Benaming", 400, HorizontalAlignment.Left)
        bedrijvenListView.Columns.Add("Map", -2, HorizontalAlignment.Right)
        bedrijvenListView.View = View.Details

        strDataLocatie = LaadTekst("BedrijfOpenen", "DataDefault")
        If Trim(strDataLocatie) = "" Then
            strDataLocatie = "lokaal"
        End If
        If strDataLocatie = "server" Then
            serverdataRadioButton.Checked = True
        Else
            localdataRadioButton.Checked = True
        End If

        vsfPro = False
        Err.Clear()
        On Error Resume Next
        'dlbFolder.path = Lokatie
        If Err.Number Then
            MsgBox("Lokatie bedrijven onvindbaar.  Kontroleer manueel a.u.b.", MsgBoxStyle.Critical)
        Else
            KeuzeLijstVullen()
        End If
    End Sub

    Private Sub sluitenButton_Click(sender As Object, e As EventArgs) Handles sluitenButton.Click
        Mim.BedrijfOpenenToolStripMenuItem.Enabled = True
        Mim.NieuwBedrijfToolStripMenuItem.Enabled = True
        Close()
    End Sub
    Private Sub locatieButton_Click(sender As Object, e As EventArgs) Handles locatieButton.Click
        locatieTextBox.Enabled = Not locatieTextBox.Enabled
        If locatieTextBox.Enabled = True Then
            locatieTextBox.Focus()
        Else
            If localdataRadioButton.Checked = True Then
                If locatieTextBox.Text <> LaadTekst(My.Application.Info.Title, "Bedrijfsinhoudsopgave") Then
                    KtrlBox = MsgBox(locatieTextBox.Text & vbCrLf & vbCrLf & "Wordt dit de nieuwe 'lokale' opstartinhoudsopgave ?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo)
                    If KtrlBox = MsgBoxResult.Yes Then
                        BeWaarTekst(My.Application.Info.Title, "Bedrijfsinhoudsopgave", locatieTextBox.Text)
                        MsgBox("Hierna wordt er afgesloten.  Start het programma opnieuw op")
                        End
                    Else
                        locatieTextBox.Text = LaadTekst(My.Application.Info.Title, "Bedrijfsinhoudsopgave")
                    End If
                End If
            Else
                If locatieTextBox.Text <> LaadTekst(My.Application.Info.Title, "ServerBedrijfsinhoudsopgave") Then
                    KtrlBox = MsgBox(locatieTextBox.Text & vbCrLf & vbCrLf & "Wordt dit de nieuwe 'server' opstartinhoudsopgave ?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo)
                    If KtrlBox = MsgBoxResult.Yes Then
                        BeWaarTekst(My.Application.Info.Title, "ServerBedrijfsinhoudsopgave", locatieTextBox.Text)
                        MsgBox("Hierna wordt er afgesloten.  Start het programma opnieuw op")
                        End
                    Else
                        locatieTextBox.Text = LaadTekst(My.Application.Info.Title, "ServerBedrijfsinhoudsopgave")
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub localdataRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles localdataRadioButton.CheckedChanged

        If serverdataRadioButton.Checked = True Then
            locatieTextBox.Text = LaadTekst(My.Application.Info.Title, "ServerBedrijfsinhoudsopgave") 'Server anders
            BeWaarTekst("BedrijfOpenen", "DataDefault", "server")
            compactdatabaseButton.Enabled = False
            verwijderenButton.Enabled = False
            onedriveButton.Enabled = False
        Else
            locatieTextBox.Text = LaadTekst(My.Application.Info.Title, "Bedrijfsinhoudsopgave") 'Lokaal is standaard
            BeWaarTekst("BedrijfOpenen", "DataDefault", "lokaal")
            compactdatabaseButton.Enabled = True
            verwijderenButton.Enabled = True
            onedriveButton.Enabled = True
        End If
        Lokatie = locatieTextBox.Text & "\"
        'TODO: KeuzeLijstVullen()
    End Sub

    Private Sub serverdataRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles serverdataRadioButton.CheckedChanged
        If serverdataRadioButton.Checked = True Then
            locatieTextBox.Text = LaadTekst(My.Application.Info.Title, "ServerBedrijfsinhoudsopgave") 'Server anders
            BeWaarTekst("BedrijfOpenen", "DataDefault", "server")
            compactdatabaseButton.Enabled = False
            verwijderenButton.Enabled = False
            onedriveButton.Enabled = False
        Else
            locatieTextBox.Text = LaadTekst(My.Application.Info.Title, "Bedrijfsinhoudsopgave") 'Lokaal is standaard
            BeWaarTekst("BedrijfOpenen", "DataDefault", "lokaal")
            compactdatabaseButton.Enabled = True
            verwijderenButton.Enabled = True
            onedriveButton.Enabled = True
        End If
        Lokatie = locatieTextBox.Text & "\"
        KeuzeLijstVullen()
    End Sub

    Sub KeuzeLijstVullen()
        Dim FlTemp As Short

        Dim A As String
        Dim NaamDetail As String

        Dim MyPath As String
        Dim MyName As String


        bedrijvenListView.Items.Clear()

        MyPath = locatieTextBox.Text & "\" 'Lokatie ' Set the path.

        Err.Clear()
        On Error Resume Next
        'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        MyName = Dir(MyPath, FileAttribute.Directory) ' Retrieve the first entry.
        If Err.Number Then Exit Sub
        Do While MyName <> "" ' Start the loop.
            ' Ignore the current directory and the encompassing directory.
            If MyName <> "." And MyName <> ".." Then
                ' Use bitwise comparison to make sure MyName is a directory.
                If (GetAttr(MyPath & MyName) And FileAttribute.Directory) = FileAttribute.Directory Then
                    On Error Resume Next
                    Err.Clear()
                    FlTemp = FreeFile()
                    FileOpen(FlTemp, MyPath & MyName & "\marnt.txt", OpenMode.Input)
                    If Err.Number Then
                    Else
                        A = LineInput(FlTemp)
                        FileClose(FlTemp)
                        NaamDetail = A
                        ' Add a ListItem object.
                        Dim itemHier As New ListViewItem(NaamDetail)
                        itemHier.SubItems.Add(MyName)
                        bedrijvenListView.Items.Add(itemHier)
                    End If
                End If ' it represents a directory.
            End If
            'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            MyName = Dir() ' Get next entry.
        Loop

    End Sub



    Private Sub bedrijvenListView_Click(sender As Object, e As EventArgs) Handles bedrijvenListView.Click

        StartAutoLoad()

    End Sub

    Private Sub bedrijvenListView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bedrijvenListView.KeyPress

        If e.KeyChar = vbCr Then
            StartAutoLoad()
        End If

    End Sub

    Private Sub StartAutoLoad()

        BedrijfsLokatie = Lokatie & bedrijvenListView.FocusedItem.SubItems.Item(1).Text & "\"
        marVersion = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        Mim.Text = "marIntegraal.NET " & marVersion & " - [" & Trim(bedrijvenListView.FocusedItem.Text) & "]"

        AutoLoadBedrijf(BJPERDAT:=frmBJPERDAT)
        sluitenButton.PerformClick()

    End Sub

End Class