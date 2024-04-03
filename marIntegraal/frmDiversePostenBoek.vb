Option Strict Off
Option Explicit On
Imports IDEALSoftware.VpeStandard
Imports System.IO
Imports System.ComponentModel

Public Class frmDiversePostenBoek
    Dim Lijn
    Dim postenRS As ADODB.Recordset
    Dim pdfY As Double
    Dim psTekst(5) As String
    Dim TotaalD As Double
    Dim TotaalC As Double
    Dim VeldTXT(17) As String
    Dim TLijnen As Short
    Dim aa As String
    Dim PlGrensVan As String = "        "
    Dim PlGrensTot As String = "        "
    Dim pdfRapportTitel As String

    Private Sub frmDiversePostenBoek_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TotaalD = 0
        TotaalC = 0
        vantotTextBox.Text = frmBJPERDAT.PeriodeBoekjaar.Text
        DateTimePicker.Text = Rdt
        PlGrensVan = Mid(PeriodeVanTot, 1, 8)
        PlGrensTot = Mid(PeriodeVanTot, 9)
    End Sub

    Private Sub checkRecordSet()

        Dim sSQL As String
        sSQL = "SELECT Journalen.v066, Journalen.v019, Rekeningen.v020, Journalen.v067, Journalen.v033, Journalen.dece068, Journalen.v069 FROM Journalen, Rekeningen WHERE  Journalen.v019=Rekeningen.v019 AND Journalen.v033 Like 'D0%' AND Journalen.v066 >= '" & PlGrensVan & "' AND Journalen.v066 <= '" & PlGrensTot & "' ORDER BY Journalen.rvID" 'Journalen.v066"
        ' Create a recordset using the provided collection
        postenRS = New ADODB.Recordset
        postenRS.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        postenRS.Open(sSQL, adntDB, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        If postenRS.RecordCount <= 0 Then
            'MsgBox("Geen diverse posten binnen deze selectie", vbInformation)
            afdrukButton.Enabled = False
            aantalrecordsTextBox.Text = "0"
            Exit Sub
        Else
            afdrukButton.Enabled = True
            aantalrecordsTextBox.Text = postenRS.RecordCount
        End If

    End Sub
    Private Sub vpePrintKop()

        With Mim.Report
            .SelectFont("Courier New", 7.2)
            .TextBold = True
            .TextColor = ColorTranslator.FromOle(0) 'zwart

            .nTopMargin = 1
            .nBottomMargin = 29
            .nLeftMargin = 0.5
            .nRightMargin = 0.5
            .PenSize = 0.01
        End With

        PaginaTeller = PaginaTeller + 1
        pdfY = Mim.Report.Print(1, 1, psTekst(2))
        pdfY = Mim.Report.Print(17.3, 1, "Pagina : " & Dec(PaginaTeller, "##########") & vbCrLf)
        pdfY = Mim.Report.Print(17.3, pdfY, "Datum  : " & psTekst(0) & vbCrLf & vbCrLf)
        pdfY = Mim.Report.Print(1, pdfY, UCase(psTekst(3)) & vbCrLf)
        pdfY = Mim.Report.Print(1, pdfY, Lijntje & vbCrLf)
        pdfY = Mim.Report.Print(1, pdfY, pdfRapportTitel & vbCrLf)
        pdfY = Mim.Report.Print(1, pdfY, Lijntje & vbCrLf & vbCrLf)
    End Sub
    Private Sub InitVelden()

        Dim T As Integer
        RapportVeld(0) = "Lijn"
        RapportTab(0) = 1 'was 2
        RapportVeld(1) = "Datum"
        RapportTab(1) = 6 'was 7
        RapportVeld(2) = "Nummer"
        RapportTab(2) = 17 'was 18
        RapportVeld(3) = "Naam Rekening"
        RapportTab(3) = 25 ' was 26
        RapportVeld(4) = "Betreft"
        RapportTab(4) = 62 'was 63
        RapportVeld(5) = "       Debet"
        RapportTab(5) = 93 ' was 94
        RapportVeld(6) = "      Credit"
        RapportTab(6) = 105 'was 106
        RapportVeld(7) = "T.Rekening"
        RapportTab(7) = 118 ' was 119
        pdfRapportTitel = Space(128)
        For T = 0 To 7
            Mid(pdfRapportTitel, RapportTab(T)) = RapportVeld(T)
        Next

    End Sub
    Private Sub vpePrintLijn()

        Dim pdfLijn As String = Space(128)
        Dim DCBedrag As Double

        Lijn = Lijn + 1
        mid(pdfLijn, RapportTab(0)) = Format(Lijn, "0000") 'lijn
        Mid(pdfLijn, RapportTab(1)) = fDatumText(oWaarde((postenRS.Fields("v066").Value))) 'datum
        Mid(pdfLijn, RapportTab(2)) = postenRS.Fields("v019").Value 'nummer
        Mid(pdfLijn, RapportTab(3)) = Mid(postenRS.Fields("v020").Value, 1, 36) 'naam rekening
        Mid(pdfLijn, RapportTab(4)) = postenRS.Fields("v067").Value 'betreft

        DCBedrag = oWaarde((postenRS.Fields("dece068").Value))
        Select Case DCBedrag
            Case Is < 0
                TotaalC = TotaalC + DCBedrag
                Mid(pdfLijn, RapportTab(6)) = Dec(System.Math.Abs(DCBedrag), MaskerEURBH) 'bedrag credit
            Case Else
                TotaalD = TotaalD + DCBedrag
                mid(pdfLijn, RapportTab(5)) = Dec(DCBedrag, MaskerEURBH) 'bedrag debet
        End Select
        Mid(pdfLijn, RapportTab(7)) = postenRS.Fields("v069").Value 'tegenrekening
        pdfY = Mim.Report.Print(1, pdfY, pdfLijn & vbCrLf)
        If pdfY > 27.5 Then
            Mim.Report.PageBreak()
            vpePrintKop()
        End If
        'hier nog checken wanneer nieuw blad te nemen


    End Sub
    Private Sub PrintTotaal()
        Dim pdfLijn As String = Space(128)
        mid(pdfLijn, RapportTab(4)) = "Periodiek totaal :"
        mid(pdfLijn, RapportTab(5)) = Dec(Math.Abs(TotaalD), MaskerEURBH)
        mid(pdfLijn, RapportTab(6)) = Dec(Math.Abs(TotaalC), MaskerEURBH)
        pdfY = Mim.Report.Print(1, pdfY, vbCrLf & Lijntje & vbCrLf & pdfLijn)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim block, s, full_path As String
        Dim stream As StreamReader

        full_path = Application.StartupPath
        block = ""
        full_path = full_path + "\DEF\pdfDDEF121.txt"
        If Dir(full_path) = "" Then
            MsgBox(full_path & vbCrLf & "Source file not found.")
            Exit Sub
        End If

        stream = New StreamReader(full_path)
        'MenuItemAutoBreak.Enabled = False
        While stream.Peek() > -1    ' not EOF
            s = stream.ReadLine()
            block = block + Chr(10) + s
        End While
        stream.Close()

        MsgBox("We loaded the file ""Form1.vb"" into VB using the slow ""ReadLine"" method." + Chr(10) + "NOW we call VPE and create a document from the data." + Chr(13) + "VPE will create the page breaks itself. This will work very fast!")

        AutoPageBreak.OpenDoc()
        AutoPageBreak.SelectFont("Courier New", 8)

        ' Set the bottom margin, so the report will fit
        ' onto A4 as well as onto US-Letter paper:
        ' =============================================
        'AutoPageBreak.SetOutRect(2, 2, 19, 26.5)
        AutoPageBreak.SetOutRect(2, 2, 19, 26.5)

        ' Header will be placed outside default output rectangle:
        AutoPageBreak.NoPen()
        AutoPageBreak.TextUnderline = True
        AutoPageBreak.DefineHeader(1, 1, -7, -0.5, "Auto Text Break Demo - Page @PAGE")

        ' On every intial page:
        ' VLEFT   = VLEFTMARGIN
        ' VTOP    = VTOPMARGIN
        ' VRIGHT  = VRIGHTMARGIN
        ' VBOTTOM = VTOPMARGIN !!!!!!!!!!
        AutoPageBreak.TextUnderline = False
        AutoPageBreak.SetPen(0.03, PenStyle.Solid, Color.Black)
        AutoPageBreak.WriteBox(AutoPageBreak.nLeft, AutoPageBreak.nBottom, AutoPageBreak.nRight, AutoPageBreak.nFree, "[N TO BC LtGray CE S 12 B]Start Diverse Postenboek")
        AutoPageBreak.WriteBox(AutoPageBreak.nLeft, AutoPageBreak.nBottom, AutoPageBreak.nRight, AutoPageBreak.nFree, block)
        AutoPageBreak.WriteBox(AutoPageBreak.nLeft, AutoPageBreak.nBottom, AutoPageBreak.nRight, AutoPageBreak.nFree, "[N TO BC LtGray CE S 12 B]Einde Diverse Postenboek")

        AutoPageBreak.Preview()

        'ExportDocument("Auto Break.pdf", AutoPageBreak)

    End Sub
    Private Sub vantotTextBox_Leave(sender As Object, e As EventArgs) Handles vantotTextBox.Leave
        If DatumFout(Mid(vantotTextBox.Text, 14, 10)) Then
            MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !", MsgBoxStyle.Information)
            vantotTextBox.Text = frmBJPERDAT.PeriodeBoekjaar.Text
            afdrukButton.Enabled = False
            aantalrecordsTextBox.Text = "0"
            Exit Sub
        ElseIf Len(vantotTextBox.Text) <> 23 Then
            MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !", MsgBoxStyle.Information)
            vantotTextBox.Text = frmBJPERDAT.PeriodeBoekjaar.Text
            afdrukButton.Enabled = False
            aantalrecordsTextBox.Text = "0"
            Exit Sub
        Else
            PlGrensVan = Mid(vantotTextBox.Text, 7, 4) & Mid(vantotTextBox.Text, 4, 2) & Mid(vantotTextBox.Text, 1, 2)
            PlGrensTot = Mid(vantotTextBox.Text, 20, 4) & Mid(vantotTextBox.Text, 17, 2) & Mid(vantotTextBox.Text, 14, 2)
            checkRecordSet()
        End If
    End Sub
    Private Sub afdrukButton_Click(sender As Object, e As EventArgs) Handles afdrukButton.Click

        With Mim.Report
            .CloseDoc()
            .OpenDoc()
            .Author = "marIntegraal"
            .GUILanguage = 3 'Nederlands
            .Title = "Diverse Postenboek"
        End With
        psTekst(2) = "Diverse Postenboek " & Mid(Mim.Text, InStr(Mim.Text, "["))
        psTekst(0) = DateTimePicker.Value
        psTekst(3) = vantotTextBox.Text
        InitVelden()
        vpePrintKop()
        Lijn = 0
        postenRS.MoveFirst()
        Do While Not postenRS.EOF
            vpePrintLijn()
            postenRS.MoveNext()
        Loop
        PrintTotaal()
        With Mim.Report
            .WriteDoc(BedrijfsLokatie & Format(Now, "YYYYMMDDHHMMSS") & "-diverseposten.pdf")
            .MailSubject = "Diverse Posten bedrijfx"
            .MailText = "diverseposten bedrijf ix in bijlage."
        End With

        Dim VMAIL_TO As Integer
        VMAIL_TO = 1
        Mim.Report.AddMailReceiver(mailTextBox.Text, VMAIL_TO)
        Mim.Report.Preview()


        'Mim.Report.CloseDoc()

    End Sub
    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Close()
    End Sub
    Private Sub frmDiversePostenBoek_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim hierCancel As Boolean = e.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = CloseReason.ApplicationExitCall
        If Mim.Report.IsOpen = True Then
            MsgBox("Sluit eerst het PDF venster a.u.b.", MsgBoxStyle.Information)
            hierCancel = True
        Else
            Mim.DiversePostenboekToolStripMenuItem.Enabled = True
        End If
        e.Cancel = hierCancel
    End Sub
End Class