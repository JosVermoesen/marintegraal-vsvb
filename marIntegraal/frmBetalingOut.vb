﻿Public Class frmBetalingOut
    Private Sub frmBetalingOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Friend Class frmOGM
'	Inherits System.Windows.Forms.Form

'	Dim psTekst(5) As String
'	Dim TotaalD As Integer
'	Dim TotaalC As Integer

'	Dim VeldTXT(17) As String

'	Dim TLijnen As Short

'	Private Sub InitVelden()
'		Dim T As Short

'		RapportVeld(0) = "Lijn"
'		RapportTab(0) = 2

'		RapportVeld(1) = "MemoDatum"
'		RapportTab(1) = 7

'		RapportVeld(2) = "    Bedrag"
'		RapportTab(2) = 18

'		RapportVeld(3) = "Munt"
'		RapportTab(3) = 29

'		RapportVeld(4) = "Begunstigde"
'		RapportTab(4) = 34

'		RapportVeld(5) = "Rekeningnr."
'		RapportTab(5) = 65

'		RapportVeld(6) = "OGM/Referte"
'		RapportTab(6) = 80

'		RapportVeld(7) = "DocumentID"
'		RapportTab(7) = 95

'		RapportTab(8) = 0

'		If chkAfdrukInVenster.CheckState Then
'			Me.Hide()
'			Xlog.Close()
'			Xlog.Hide()
'			Xlog.Text = "Betalingen"
'			Xlog.X.Cols = 7
'			Xlog.X.Row = 0
'			For T = 0 To 6
'				Xlog.X.Col = T
'				Xlog.X.Text = RapportVeld(T)
'			Next 
'			Me.Show()
'		End If

'	End Sub


'	Private Sub PrintTitel()
'		Dim Printer As New Printer
'		Dim T As Short

'		'On Local Error GoTo PrtHandler3

'		If chkAfdrukInVenster.CheckState Then Exit Sub

'		If usrLicentieInfo <> "" Then
'			Printer.CurrentX = 50
'			Printer.CurrentY = 50
'			Printer.Write(usrLicentieInfo)
'		End If
'		PaginaTeller = PaginaTeller + 1
'		Printer.CurrentY = 400
'		Printer.Write(TAB(1), psTekst(2), TAB(108), "Pagina : " & Dec(PaginaTeller, "##########"))

'		Printer.Write(TAB(108), "Datum  : " & psTekst(0) & vbCrLf & vbCrLf)
'		Printer.Write(TAB(1), UCase(psTekst(3)))

'		Printer.Print(vbCrLf & Lijntje.Value)

'		Do While RapportTab(T) <> 0
'			Printer.Print(TAB(RapportTab(T)))
'			Printer.Write(RapportVeld(T))
'			If RapportTab(T + 1) < RapportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 

'		Printer.Write(Lijntje.Value & vbCrLf & vbCrLf)

'		Exit Sub

'PrtHandler3: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub


'	Private Sub PrintVelden()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim aa As String

'		T = 0
'		aa = ""
'		Do While RapportTab(T) <> 0
'			If chkAfdrukInVenster.CheckState Then
'				aa = aa & VeldTXT(T) & vbTab
'			Else
'				Printer.Print(TAB(RapportTab(T)))
'				Printer.Write(VeldTXT(T))
'			End If
'			If RapportTab(T + 1) < RapportTab(T) Then
'				If chkAfdrukInVenster.CheckState Then
'				Else
'					Printer.Write(vbCrLf)
'				End If
'			End If
'			T = T + 1
'		Loop 
'		If chkAfdrukInVenster.CheckState Then
'		Else
'			Printer.Write(vbCrLf)
'		End If
'		If Printer.CurrentY >= Printer.Height - 1200 Then
'			On Error Resume Next
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			PrintTitel()
'		End If
'		If chkAfdrukInVenster.CheckState Then Xlog.X.AddItem(aa, Xlog.X.Rows - 1)

'	End Sub



'	Private Sub PrintTotaal()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim aa As Object

'		If grdDokumentDetail.Rows = 2 Then Exit Sub

'		If chkAfdrukInVenster.CheckState Then
'		Else
'			Printer.Print(vbCrLf & Lijntje.Value)
'		End If
'		For T = 0 To 6
'			VeldTXT(T) = ""
'		Next 

'		VeldTXT(1) = "Totaal BEF"
'		VeldTXT(2) = Dec(CDbl(lblBEF.Text), MaskerBEF)
'		T = 0
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		aa = ""
'		Do While T < 8
'			If chkAfdrukInVenster.CheckState Then
'				'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'				aa = aa + VeldTXT(T) + vbTab
'			Else
'				Printer.Print(TAB(RapportTab(T)))
'				Printer.Write(VeldTXT(T))
'			End If
'			If RapportTab(T + 1) < RapportTab(T) Then
'				If chkAfdrukInVenster.CheckState Then
'				Else
'					Printer.Write(vbCrLf)
'				End If
'			End If
'			T = T + 1
'		Loop 
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		If chkAfdrukInVenster.CheckState Then Xlog.X.AddItem(aa, Xlog.X.Rows - 1)

'		VeldTXT(1) = "Totaal EUR"
'		VeldTXT(2) = Dec(CDbl(lblEUR.Text), MaskerEUR)
'		T = 0
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		aa = ""
'		Do While T < 8
'			If chkAfdrukInVenster.CheckState Then
'				'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'				aa = aa + VeldTXT(T) + vbTab
'			Else
'				Printer.Print(TAB(RapportTab(T)))
'				Printer.Write(VeldTXT(T))
'			End If
'			If RapportTab(T + 1) < RapportTab(T) Then
'				If chkAfdrukInVenster.CheckState Then
'				Else
'					Printer.Write(vbCrLf)
'				End If
'			End If
'			T = T + 1
'		Loop 
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		If chkAfdrukInVenster.CheckState Then Xlog.X.AddItem(aa, Xlog.X.Rows - 1)

'		If chkAfdrukInVenster.CheckState Then
'			Xlog.X.Row = 1
'			Xlog.X.Col = 0
'			Xlog.X.set_ColWidth(0, 555)
'			Xlog.X.set_ColWidth(1, 1050)
'			Xlog.X.set_ColWidth(2, 1020)
'			Xlog.X.set_ColWidth(3, 495)
'			Xlog.X.set_ColWidth(4, 2370)
'			Xlog.X.set_ColWidth(5, 1275)
'			Xlog.X.set_ColWidth(6, 1410)
'			Xlog.WindowState = System.Windows.Forms.FormWindowState.Maximized

'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal
'			Xlog.WijzigenLijn.Visible = False
'			Xlog.Afsluiten.Enabled = False
'			Xlog.Afsluiten.TabStop = False
'			Xlog.cbAfbeelding.Visible = False
'			Xlog.SSTab1.TabPages.Item(1).Visible = False
'			XLogKey = ""
'			Xlog.ShowDialog()
'			Xlog.Close()
'		End If

'	End Sub


'	Function DosOGM() As Object

'		Dim boString As New VB6.FixedLengthString(128)
'		Dim goString1 As New VB6.FixedLengthString(128)
'		Dim goString2 As New VB6.FixedLengthString(128)
'		Dim eoString As New VB6.FixedLengthString(128)
'		Dim FlHier As Short

'		Dim volgNr As Short
'		Dim bdrgTotaal As Decimal
'		Dim bdrgBedrag As Decimal
'		Dim rekNummer As Double
'		Dim rekNummerTotaal As Double

'		boString.Value = "" : goString1.Value = "" : goString2.Value = "" : eoString.Value = ""
'		Mim.TekenSave.InitialDirectory = BedrijfsLokatie
'		Mim.TekenSave.FileName = ""
'		Mim.TekenSave.ShowDialog()
'		If Mim.TekenSave.FileName = "" Then Exit Function
'		FlHier = FreeFile
'		FileOpen(FlHier, Mim.TekenSave.FileName, OpenMode.Output)

'		Mid(boString.Value, 1, 1) = "0" 'beginopname
'		Mid(boString.Value, 4, 2) = "00" 'voorwerp van betaling
'		Mid(boString.Value, 6, 6) = VB6.Format(Now, "ddmmyy") 'datum opmaak
'		Mid(boString.Value, 12, 3) = VB.Left(cbBank.Text, 3) 'codenummer fin.instelling
'		Mid(boString.Value, 15, 2) = "01" 'toepassingscode 01= betaling 02=domicil 03=cheques
'		Mid(boString.Value, 17, 6) = Mid(boString.Value, 6, 6) 'gevraagde uitvoeringsdatum
'		Mid(boString.Value, 24, 3) = "000"
'		Mid(boString.Value, 27, 12) = Mid(cbBank.Text, InStr(cbBank.Text, "[") + 1, 12) 'rekeningnummer opdrachtgever
'		Mid(boString.Value, 39, 26) = String99(Lees, 46) 'Naam opdrachtgever
'		Mid(boString.Value, 65, 26) = String99(Lees, 47) 'Adres opdrachtgever
'		Mid(boString.Value, 91, 4) = String99(Lees, 48) 'Postnummer opdrachtgever
'		Mid(boString.Value, 95, 22) = Mid(String99(Lees, 48), 6) 'Lokaliteit opdrachtgever
'		Mid(boString.Value, 117, 1) = "1" 'Taalcode opdrachtgever
'		Mid(boString.Value, 128, 1) = "5" 'Versiecode 5=EUR, 3=BEF
'		Print(FlHier, boString.Value & vbNewLine)

'		For volgNr = 1 To grdDokumentDetail.Rows - 1

'			If Len(grdDokumentDetail.get_TextMatrix(volgNr, 3)) <> 10 Then
'				Exit For
'			End If

'			'Gegevensopname 1
'			Mid(goString1.Value, 1, 1) = "1" 'Identificatie opname
'			Mid(goString1.Value, 2, 4) = VB6.Format(volgNr, "0000")
'			Mid(goString1.Value, 6, 8) = VB6.Format(grdDokumentDetail.get_TextMatrix(volgNr, 8), "00000000") 'Refertenummer opdrachtgever

'			rekNummer = Val(grdDokumentDetail.get_TextMatrix(volgNr, 6))
'			rekNummerTotaal = rekNummerTotaal + rekNummer
'			Mid(goString1.Value, 24, 12) = grdDokumentDetail.get_TextMatrix(volgNr, 6) 'Rekeningnummer begunstigde

'			'VeldTXT(1) = grdDokumentDetail.TextMatrix(Teller, 3)

'			bdrgBedrag = CDec(grdDokumentDetail.get_TextMatrix(volgNr, 5))
'			bdrgTotaal = bdrgTotaal + bdrgBedrag
'			Mid(goString1.Value, 36, 12) = VB6.Format(bdrgBedrag * 100, "000000000000") 'Bedrag
'			Mid(goString1.Value, 48, 26) = grdDokumentDetail.get_TextMatrix(volgNr, 1)
'			Mid(goString1.Value, 74, 1) = "1" 'taalcode begunstigde
'			Mid(goString1.Value, 75, 12) = grdDokumentDetail.get_TextMatrix(volgNr, 7) 'Begin van de mededeling
'			Mid(goString1.Value, 87, 41) = "" 'eerste vervolg gewone mededeling

'			If VB6.Format(Val(grdDokumentDetail.get_TextMatrix(volgNr, 7)), "000000000000") <> grdDokumentDetail.get_TextMatrix(volgNr, 7) Then
'				Mid(goString1.Value, 128, 1) = "3" 'Aardcode 8= gestruct. mededeling anders 3
'			Else
'				If BankOk(VB.Left(grdDokumentDetail.get_TextMatrix(volgNr, 7), 12)) Then
'					Mid(goString1.Value, 128, 1) = "8" 'Aardcode 8= gestruct. mededeling anders 3
'				Else
'					Mid(goString1.Value, 128, 1) = "3" 'Aardcode 8= gestruct. mededeling anders 3
'				End If
'			End If
'			Print(FlHier, goString1.Value & vbNewLine)

'			'Gegevensopname 2
'			Mid(goString2.Value, 1, 1) = "2" 'Identificatie opname
'			Mid(goString2.Value, 2, 4) = VB6.Format(volgNr, "0000")
'			Mid(goString2.Value, 6, 1) = "0" 'code aanspreking begunstigde
'			Mid(goString2.Value, 7, 26) = "" 'adres begunstigde
'			Mid(goString2.Value, 33, 4) = "" 'postcode begunstigde
'			Mid(goString2.Value, 37, 22) = "" 'Lokaliteit begunstigde
'			Mid(goString2.Value, 59, 53) = "" 'mededeling: tweede vervolg
'			Mid(goString2.Value, 112, 1) = "0" 'code chequekost 1= opdrgever, 2= begunstig.
'			Print(FlHier, goString2.Value & vbNewLine)
'			goString1.Value = "" : goString2.Value = ""
'			bGet(Fldokument, 0, grdDokumentDetail.get_TextMatrix(volgNr, 2))
'			RecordToVeld(Fldokument)
'			vBib(Fldokument, "0", "rvDM")
'			bUpdate(Fldokument, 0)
'		Next 

'		'Eindopname
'		Mid(eoString.Value, 1, 1) = "9" 'Identificatie opname
'		Mid(eoString.Value, 2, 4) = VB6.Format((volgNr - 1) * 2, "0000")
'		Mid(eoString.Value, 6, 4) = VB6.Format(volgNr - 1, "0000")
'		Mid(eoString.Value, 10, 12) = VB6.Format(bdrgTotaal * 100, "000000000000") 'Totaal Bedragen
'		Mid(eoString.Value, 22, 15) = VB6.Format(rekNummerTotaal, "000000000000000") 'Totaal Rekeningnummers
'		Mid(eoString.Value, 37, 11) = "00" & Mid(String99(Lees, 51), 1, 3) & Mid(String99(Lees, 51), 5, 3) & Mid(String99(Lees, 51), 9, 3) 'Identificatie afgever
'		Print(FlHier, eoString.Value)
'		FileClose(FlHier)
'		MsgBox(Mim.TekenSave.FileName & vbCrLf & vbCrLf & "staat klaar voor IMPORT door uw banksoftware.", MsgBoxStyle.Information)

'	End Function



'	Sub Herreken()

'		Dim TotaalBedraginBef As Decimal
'		Dim Teller As Short

'		TotaalBedraginBef = 0
'		For Teller = 1 To grdDokumentDetail.Rows - 1
'			If grdDokumentDetail.get_TextMatrix(Teller, 4) = "EUR" Then
'				TotaalBedraginBef = TotaalBedraginBef + (CDbl(grdDokumentDetail.get_TextMatrix(Teller, 5)) * Euro)
'			ElseIf grdDokumentDetail.get_TextMatrix(Teller, 4) = "BEF" Then 
'				TotaalBedraginBef = TotaalBedraginBef + CDbl(grdDokumentDetail.get_TextMatrix(Teller, 5))
'			Else
'				'Stop
'			End If
'		Next 
'		lblBEF.Text = VB6.Format(System.Math.Round(TotaalBedraginBef, 0), "#,###")
'		lblEUR.Text = VB6.Format(System.Math.Round(TotaalBedraginBef / Euro, 2), "#,###.00")

'	End Sub

'	Private Sub CmdEmailNBB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEmailNBB.Click

'		Me.DosOGM()

'	End Sub

'	Private Sub cmdSluiten_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSluiten.Click

'		Me.Close()

'	End Sub

'	Private Sub Drukken_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drukken.Click
'		Dim Printer As New Printer
'		Dim Teller As Short

'		psTekst(2) = "Lijst Overschrijvingen " & Mid(Mim.Text, InStr(Mim.Text, "["))
'		psTekst(0) = Rdt.Value
'		psTekst(3) = "Bank " & cbBank.Text

'		InitVelden()
'		PaginaTeller = 0
'		If chkAfdrukInVenster.CheckState = 0 Then
'			Printer = Printers(LijstPrinterNr)
'			On Error Resume Next
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			Printer.PaperBin = LaadTekst(My.Application.Info.Title, "LIJSTPRINTER")
'			If Printer.Width > 12000 Then
'				Printer.FontSize = 10
'				Printer.FontName = "Courier New"
'				Printer.Print(" ")
'				Printer.FontSize = 10
'			Else
'				Printer.FontSize = 7.2
'				Printer.FontName = "Courier New"
'				Printer.Print(" ")
'				Printer.FontSize = 7.2
'			End If
'		End If
'		PrintTitel()
'		For Teller = 1 To grdDokumentDetail.Rows - 1
'			If Len(grdDokumentDetail.get_TextMatrix(Teller, 3)) <> 10 Then
'				Exit For
'			End If
'			VeldTXT(0) = VB6.Format(Teller, "000")
'			VeldTXT(1) = grdDokumentDetail.get_TextMatrix(Teller, 3)
'			VeldTXT(3) = grdDokumentDetail.get_TextMatrix(Teller, 4)
'			If VeldTXT(3) = "BEF" Then
'				VeldTXT(2) = Dec(CDbl(grdDokumentDetail.get_TextMatrix(Teller, 5)), MaskerBEF)
'			Else
'				VeldTXT(2) = Dec(CDbl(grdDokumentDetail.get_TextMatrix(Teller, 5)), MaskerEUR)
'			End If
'			VeldTXT(4) = VB.Left(grdDokumentDetail.get_TextMatrix(Teller, 1), 30)
'			VeldTXT(5) = grdDokumentDetail.get_TextMatrix(Teller, 6)
'			VeldTXT(6) = grdDokumentDetail.get_TextMatrix(Teller, 7)
'			VeldTXT(7) = grdDokumentDetail.get_TextMatrix(Teller, 8)
'			PrintVelden()
'		Next 
'		PrintTotaal()
'		If chkAfdrukInVenster.CheckState = 0 Then Printer.EndDoc()
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal

'	End Sub

'	Private Sub dtpMemoDatum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dtpMemoDatum.Leave

'		grdDokumentDetail.set_TextMatrix(grdDokumentDetail.Row, 3, VB6.Format(dtpMemoDatum._Value, "dd/mm/yyyy"))

'	End Sub

'	Private Sub frmOGM_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

'		If Not Toegankelijk(Me) Then
'			Me.Close()
'			Exit Sub
'		End If

'		dtpMemoDatum.MinDate = Now

'		bGetOrGreater(FlAllerlei, 1, "28")
'		If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "28" Then
'			MsgBox("Eerst financiële instelling parameters inbrengen via 'Diverse Gebruikersfiches' a.u.b.", MsgBoxStyle.Information)
'			Me.Close()
'			Exit Sub
'		Else
'			Do 
'				RecordToVeld(FlAllerlei)
'				cbBank.Items.Add(vBibTekst(FlAllerlei, "#v231 #") & ": " & vBibTekst(FlAllerlei, "#v232 #") & " [" & vBibTekst(FlAllerlei, "#v236 #") & "]")
'				bNext(FlAllerlei)
'				If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "28" Then
'					Exit Do
'				End If
'			Loop 
'		End If

'		cbBank.SelectedIndex = 0
'		Datum.Value = Rdt.Value

'		TekstLijn(2).Text = "0"
'		TekstLijn(3).Text = New String("z", 12)
'		grdDokumentDetail.Rows = 2
'		grdDokumentDetail.Cols = 9
'		grdDokumentDetail.Col = 0
'		grdDokumentDetail.Row = 0
'		grdDokumentDetail.Text = "ID Kode"
'		grdDokumentDetail.Col = 1
'		grdDokumentDetail.Text = "Naam"
'		grdDokumentDetail.Col = 2
'		grdDokumentDetail.Text = "document"
'		grdDokumentDetail.Col = 3
'		grdDokumentDetail.Text = "Memodatum"
'		grdDokumentDetail.Col = 4
'		grdDokumentDetail.Text = "Munt"
'		grdDokumentDetail.Col = 5
'		grdDokumentDetail.Text = "Bedrag"
'		grdDokumentDetail.Col = 6
'		grdDokumentDetail.Text = "Rekening Nr."
'		grdDokumentDetail.Col = 7
'		grdDokumentDetail.Text = "(OGM)Referte"
'		grdDokumentDetail.Col = 8
'		grdDokumentDetail.Text = "docID"

'		grdDokumentDetail.set_ColWidth(0, 1125)
'		grdDokumentDetail.set_ColWidth(1, 1695)
'		grdDokumentDetail.set_ColWidth(2, 1155)
'		grdDokumentDetail.set_ColWidth(3, 975)
'		grdDokumentDetail.set_ColWidth(4, 450)
'		grdDokumentDetail.set_ColWidth(5, 960)
'		grdDokumentDetail.set_ColWidth(6, 1200)
'		grdDokumentDetail.set_ColWidth(7, 1380)
'		grdDokumentDetail.set_ColWidth(8, 960)

'	End Sub


'	Private Sub KTRLBalans(ByRef Fl As Short)
'		Dim Cumul As Double
'		Dim dTotaal As Double
'		Dim dBetaald As Double
'		Dim dBTW As Double
'		Dim T As Short
'		Dim VoorLetter As New VB6.FixedLengthString(1)
'		Dim ktrlMemoDatum As String

'		Dim TeVerbeteren As Short
'		Dim GeenRekening As Short
'		Dim ZwareFout As Short

'		Dim AlgemeenTotaal As Decimal

'		Dim aa As Object

'		If Fl = FlLeverancier Then
'			VoorLetter.Value = "L"
'		Else
'			VoorLetter.Value = "K"
'		End If

'		ktrlMemoDatum = VB6.Format(Now, "yyyymmdd")

'		T = 0
'		bGetOrGreater(Fldokument, 1, VoorLetter.Value & TekstLijn(2).Text)
'		If Ktrl Or KeyBuf(Fldokument) > VoorLetter.Value & TekstLijn(3).Text Then
'			Beep()
'			MsgBox("Selectie buiten mogelijke documenten")
'			Exit Sub
'		End If
'		If VoorLetter.Value & TekstLijn(2).Text = VoorLetter.Value & TekstLijn(3).Text Then
'			If KeyBuf(Fldokument) <> VoorLetter.Value & Trim(TekstLijn(2).Text) Then
'				Beep()
'				MsgBox("Geen documenten voor " & vBibTekst(Fl, "#A100 #"))
'				Exit Sub
'			End If
'		End If
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'		If grdDokumentDetail.Rows = 2 Then
'		Else
'			KtrlBox = MsgBox("Verrichtingen reeds aanwezig behouden.", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
'			If KtrlBox = MsgBoxResult.No Then
'				GridSchoon(grdDokumentDetail)
'			End If
'		End If
'		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
'		grdDokumentDetail.CtlRefresh()
'		Do 
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub VolgendeLijn
'			bNext(Fldokument)
'			If Ktrl Or KeyBuf(Fldokument) > "L" & TekstLijn(3).Text Then
'				Exit Do
'			End If
'		Loop 

'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		If GeenRekening Then
'			Me.CmdEmailNBB.Enabled = False
'			Msg = "Er zijn " & Str(GeenRekening) & " verrichtingen zonder rekeningnummer" & vbCrLf
'			Msg = Msg & "Mogen deze verwijderd worden" & vbCrLf & vbCrLf
'			Msg = Msg & "(zonder verwijdering enkel afdruk op papier mogelijk)"
'			KtrlBox = MsgBox(Msg, MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo)
'			If KtrlBox = MsgBoxResult.Yes Then
'				TelTot = 1
'				CmdEmailNBB.Enabled = True
'				Do While TelTot < grdDokumentDetail.Rows - 1
'					Debug.Print(grdDokumentDetail.get_TextMatrix(TelTot, 6))
'					If Mid(grdDokumentDetail.get_TextMatrix(TelTot, 6), 1, 2) = "!!" Then
'						grdDokumentDetail.RemoveItem(TelTot)
'					Else
'						TelTot = TelTot + 1
'					End If
'				Loop 
'			End If
'		Else
'			Me.CmdEmailNBB.Enabled = True
'		End If
'		If TeVerbeteren Then
'			MsgBox("Er zijn " & Str(TeVerbeteren) & " rekeningnummers onjuist", MsgBoxStyle.Information)
'		End If
'		If ZwareFout Then
'			MsgBox("Er zijn voor " & Str(ZwareFout) & " identiteitsgegevens verdwenen", MsgBoxStyle.Critical, "Zware fout !!!")
'		End If

'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		If aa = "" Then
'			Beep()
'			MsgBox("Selectie buiten mogelijke documenten")
'			Exit Sub
'		End If

'		MsgBox("stop voor enkel leveranciers")
'		Exit Sub

'VolgendeLijn: 
'		RecordToVeld(Fldokument)
'		dBetaald = Val(vBibTekst(Fldokument, "#v037 #"))
'		dTotaal = Val(vBibTekst(Fldokument, "#v249 #"))
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		If System.Math.Round(dBetaald) = System.Math.Round(dTotaal) Then Return 
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		If vBibTekst(Fldokument, "#rvDM #") = "0" And Me.Selektie(1).CheckState = System.Windows.Forms.CheckState.Checked Then Return 

'		'TO DO creditnota's leveranciers, facturen klanten en kwitanties klanten uitsluiten !!
'		Select Case Mid(vBibTekst(Fldokument, "#v033 #"), 1, 2)
'			Case "V0", "A1" 'Verkoopfactuur of Creditnota Aankoop
'				'If Mid(vBibTekst(Fldokument, "#v033 #"), 2, 1) = "1" Then
'				'Return
'				'End If
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 

'			Case "Q0" 'kwijting nog te betalen
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				If dTotaal > 0 Then Return 
'			Case Else
'				'Stop
'		End Select

'		'Selektie(0) = vervaldagcontrole
'		'TODO !

'		'Selektie(2)= enkel dit boekjaar
'		If Selektie(2).CheckState = 1 Then
'			If rsMAR(Fldokument).Fields("v035").Value >= VB.Left(BoekjaarVanTot.Value, 8) And rsMAR(Fldokument).Fields("v035").Value <= VB.Right(BoekjaarVanTot.Value, 8) Then
'			Else
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 
'			End If
'		End If

'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		aa = vBibTekst(Fldokument, "#v034 #") & vbTab
'		bGet(Fl, 0, Mid(vBibTekst(Fldokument, "#v034 #"), 2))
'		If Ktrl Then
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & "Is verwijderd" & vbTab
'			ZwareFout = ZwareFout + 1
'		Else
'			RecordToVeld(Fl)
'			Select Case vBibTekst(Fl, "#vs03 #")
'				Case "EUR"
'				Case Else
'					'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'					Return 
'			End Select
'			'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & oWaarde(rsMAR(Fl).Fields("A100")) & vbTab
'		End If
'		'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		aa = aa & oWaarde(rsMAR(Fldokument).Fields("v033")) & vbTab
'		'vervaldag < memodatum?
'		'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(rsMAR(Fldokument)(v036)). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		If ktrlMemoDatum > oWaarde(rsMAR(Fldokument).Fields("v036")) Then
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & fDatumText(ktrlMemoDatum) & vbTab
'		Else
'			'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & fDatumText(oWaarde(rsMAR(Fldokument).Fields("v036"))) & vbTab
'		End If
'		'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		aa = aa & oWaarde(rsMAR(Fl).Fields("vs03")) & vbTab
'		'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(rsMAR(Fl)(vs03)). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		If oWaarde(rsMAR(Fl).Fields("vs03")) = "EUR" And bhEuro = False Then
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & System.Math.Round((dTotaal - dBetaald) / Euro, 2) & vbTab
'			'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(rsMAR(Fl)(vs03)). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		ElseIf oWaarde(rsMAR(Fl).Fields("vs03")) = "BEF" And bhEuro = True Then 
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & System.Math.Round((dTotaal - dBetaald) * Euro, 0) & vbTab
'		ElseIf bhEuro = True Then 
'			'MsgBox "kontrolestop"
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & System.Math.Round(dTotaal - dBetaald, 2) & vbTab
'		ElseIf bhEuro = False Then 
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & System.Math.Round(dTotaal - dBetaald, 0) & vbTab
'		Else
'			MsgBox("onlogische situatie")
'		End If
'		'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		If Len(Trim(oWaarde(rsMAR(Fl).Fields("A170")))) = 14 Then
'			'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			If BankOk(oWaarde(rsMAR(Fl).Fields("A170"))) Then
'				'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'				'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'				aa = aa & Mid(oWaarde(rsMAR(Fl).Fields("A170")), 1, 3) & Mid(oWaarde(rsMAR(Fl).Fields("A170")), 5, 7) & Mid(oWaarde(rsMAR(Fl).Fields("A170")), 13, 2) & vbTab
'			Else
'				'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'				aa = aa & "!!" & vBibTekst(Fl, "#A170 #") & vbTab
'				TeVerbeteren = TeVerbeteren + 1
'			End If
'		Else
'			'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			aa = aa & "!! ..." & vbTab
'			GeenRekening = GeenRekening + 1
'		End If
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		aa = aa & vBibTekst(Fldokument, "#v039 #") & vbTab
'		On Error Resume Next
'		'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		aa = aa & oWaarde(rsMAR(Fldokument).Fields("rvID"))
'		'UPGRADE_WARNING: Couldn't resolve default property of object aa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		grdDokumentDetail.AddItem(aa, grdDokumentDetail.Rows - 1)
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'SluitAf: 
'		Xlog.Close()
'		Exit Sub

'	End Sub

'	Private Sub GrddokumentDetail_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GrddokumentDetail.ClickEvent

'		If grdDokumentDetail.Row = grdDokumentDetail.Rows - 1 Then
'			mebRekening.Enabled = False
'			dtpMemoDatum.Enabled = False
'			tbBedrag.Enabled = False
'		Else
'			bGet(FlLeverancier, 0, Mid(grdDokumentDetail.get_TextMatrix(grdDokumentDetail.Row, 0), 2))
'			If Ktrl Then
'				MsgBox("Breng leverancier opnieuw in via fiches a.u.b.", MsgBoxStyle.Critical)
'			Else
'				If Len(grdDokumentDetail.get_TextMatrix(grdDokumentDetail.Row, 6)) <> 12 Then
'					MsgBox("Breng eerst 'juiste' rekeningnummer in a.u.b. voor " & vbCr & vbCr & grdDokumentDetail.get_TextMatrix(grdDokumentDetail.Row, 1), MsgBoxStyle.Information)
'				End If
'				RecordToVeld(FlLeverancier)

'				If vBibTekst(FlLeverancier, "#v017 #") = "1" Then
'					'UPGRADE_ISSUE: MSMask.MaskEdBox property mebRekening.AutoTab was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
'					mebRekening.AutoTab = True
'					'UPGRADE_WARNING: MSMask.MaskEdBox property mebRekening.ClipMode has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'					mebRekening.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals
'					mebRekening.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
'					mebRekening.Mask = "+++###/####/#####+++"

'				Else
'					'UPGRADE_ISSUE: MSMask.MaskEdBox property mebRekening.AutoTab was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
'					mebRekening.AutoTab = False
'					'UPGRADE_WARNING: MSMask.MaskEdBox property mebRekening.ClipMode has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'					mebRekening.CutCopyMaskFormat = MaskFormat.IncludeLiterals
'					mebRekening.TextMaskFormat = MaskFormat.IncludePrompt
'					mebRekening.Mask = ""
'				End If
'				mebRekening.Enabled = True
'				dtpMemoDatum.Enabled = True
'				tbBedrag.Enabled = True
'			End If
'		End If
'		mebRekening.Text = grdDokumentDetail.get_TextMatrix(grdDokumentDetail.Row, 7)
'		tbBedrag.Text = grdDokumentDetail.get_TextMatrix(grdDokumentDetail.Row, 5)
'		On Error Resume Next
'		dtpMemoDatum.Value = grdDokumentDetail.get_TextMatrix(grdDokumentDetail.Row, 3)

'	End Sub

'	Private Sub grddokumentDetail_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles grddokumentDetail.Enter

'		mebRekening.Enabled = False
'		dtpMemoDatum.Enabled = False
'		tbBedrag.Enabled = False

'	End Sub


'	Private Sub GrddokumentDetail_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxMSFlexGridLib.DMSFlexGridEvents_KeyDownEvent) Handles GrddokumentDetail.KeyDownEvent

'		Select Case eventArgs.KeyCode
'			Case 45 'Insert
'				MsgBox(eventArgs.KeyCode)

'			Case 46 'Delete
'				If grdDokumentDetail.Row > 0 And grdDokumentDetail.Row < grdDokumentDetail.Rows - 1 Then
'					grdDokumentDetail.RemoveItem(grdDokumentDetail.Row)
'				End If
'				grdDokumentDetail.Focus()
'				Herreken()

'		End Select

'	End Sub

'	Private Sub grdDokumentDetail_RowColChange(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles grdDokumentDetail.RowColChange

'		If grdDokumentDetail.Rows = 2 Then
'		Else
'			GrddokumentDetail_ClickEvent(GrddokumentDetail, New System.EventArgs())
'		End If

'	End Sub

'	Private Sub mebRekening_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mebRekening.Leave

'		If mebRekening.Mask = "" Then
'			grdDokumentDetail.set_TextMatrix(grdDokumentDetail.Row, 7, mebRekening.Text)
'		ElseIf BankOk(mebRekening.Text) Then 
'			grdDokumentDetail.set_TextMatrix(grdDokumentDetail.Row, 7, mebRekening.Text)
'		Else
'			mebRekening.Text = grdDokumentDetail.get_TextMatrix(grdDokumentDetail.Row, 7)
'		End If

'	End Sub

'	Private Sub Samenstellen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Samenstellen.Click

'		KTRLBalans(FlLeverancier)

'		grdDokumentDetail.Row = 1
'		grdDokumentDetail.Col = 0
'		Herreken()
'		grdDokumentDetail.Focus()

'	End Sub






'	Private Sub tbBedrag_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tbBedrag.Leave

'		If grdDokumentDetail.get_TextMatrix(grdDokumentDetail.Row, 5) = tbBedrag.Text Then
'		Else
'			grdDokumentDetail.set_TextMatrix(grdDokumentDetail.Row, 5, tbBedrag.Text)
'			Herreken()
'		End If

'	End Sub

'	Private Sub TekstLijn_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Enter
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		TekstLijn(Index).SelectionLength = Len(TekstLijn(Index).Text)
'		Select Case Index
'			Case 0
'				VB6.SetDefault(Samenstellen, False)
'			Case 2, 3
'				SnelHelpPrint("Dubbelklikken of [Ctrl] voor geïndexeerd zoeken", blLogging)
'				VB6.SetDefault(Samenstellen, True)
'		End Select

'	End Sub

'	Private Sub TekstLijn_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TekstLijn.KeyDown
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		Select Case Index
'			Case 2, 3
'				Select Case KeyCode
'					Case 17
'						aIndex = 0
'						SharedFl = FlLeverancier
'						GridText = TekstLijn(Index).Text
'						SqlSearch.ShowDialog()
'						If Ktrl = 0 Then
'							TekstLijn(Index).Text = vBibTekst(FlLeverancier, "#A110 #")
'							If Index = 2 Then
'								TekstLijn(3).Text = TekstLijn(2).Text
'							End If
'						End If
'				End Select
'		End Select

'	End Sub

'	Private Sub TekstLijn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Leave
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)
'		Dim FlTemp As Short

'		Select Case Index
'			Case 1
'				VB6.SetDefault(Samenstellen, False)
'				If DatumFout(TekstLijn(1).Text) Then
'					Beep()
'					TekstLijn(1).Text = Rdt.Value
'					TekstLijn(1).Focus()
'				End If
'			Case 2, 3
'				VB6.SetDefault(Samenstellen, False)
'		End Select

'	End Sub
'End Class