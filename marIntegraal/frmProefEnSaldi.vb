Public Class frmProefEnSaldi
    Private Sub frmProefEnSaldi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Friend Class ProefEnSaldi
'	Inherits System.Windows.Forms.Form
'	'UPGRADE_NOTE: DefInt A-Z statement was removed. Variables were explicitly declared as type Short. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92AFD3E3-440D-4D49-A8BF-580D74A8C9F2"'

'	Dim psTekst(5) As String 'Koptekstinfo
'	Dim ErrorTekst As String

'	Dim VeldTXT(20) As String

'	Dim Lijn As Integer

'	Dim SubTotaalD As Decimal
'	Dim SubTotaalC As Decimal

'	Dim CumTotaalD As Decimal
'	Dim CumTotaalC As Decimal

'	Dim TotaalD As Decimal
'	Dim TotaalC As Decimal

'	Dim LFontSize(20) As Single
'	Dim LAantalL(20) As Short
'	Dim FontDefChanged As Short

'	Dim PlGrensVan As New VB6.FixedLengthString(8)
'	Dim PlGrensTot As New VB6.FixedLengthString(8)

'	Dim SaldiKontrole As Boolean
'	Dim KontroleLijst As String
'	Dim aa As String

'	'Msg = "ALTER TABLE Journalen ADD COLUMN v248 CURRENCY;"
'	'Msg = "ALTER TABLE Journalen DROP COLUMN v248"
'	'Msg = "UPDATE Journalen SET v248=Str$(Cdbl(Format(Val(v068)/40.3399," + Chr$(34) + "0.0000" + Chr$(34) + "))) WHERE v066 <= '" + Right(BoekjaarVanTot, 8) + "';"
'	'adntDB.Execute Msg, AantalRecordsHier
'	'If Err Then
'	'    MsgBox "Foutmelding bron: " & Err.Source & vbCrLf & "Foutkodenummer: " & Err.Number & vbCrLf & vbCrLf & "Foutmelding omschrijving:" & vbCrLf & Err.Description
'	'End If


'	Sub DetailJournaalDrukken()
'		Dim Printer As New Printer
'		Dim SubTitelTekst As String
'		Dim BeginSleutel As New VB6.FixedLengthString(8)
'		Dim EindSleutel As New VB6.FixedLengthString(8)
'		Dim DCBedrag As Integer

'		Dim DCKontrole As Decimal
'		Dim DCDatum As New VB6.FixedLengthString(8)

'		'On Local Error GoTo PrtHandler2

'		ErrorTekst = ""
'		Lijn = 0
'		KontroleLijst = ""
'		BeginSleutel.Value = PlGrensVan.Value
'		EindSleutel.Value = PlGrensTot.Value

'		psTekst(2) = "Algemeen Journaal (Systeem OT) " & Mid(Mim.Text, InStr(Mim.Text, "["))
'		psTekst(0) = txtTekstLijn(1).Text
'		psTekst(3) = "Boekjaar aanvang : " & VB.Left(BoekjaarVanTot.Value, 4) & ", " & txtTekstLijn(0).Text
'		InitVelden()

'		bFirst(FlJournaal, 4)
'		bGetOrGreater(FlJournaal, 4, BeginSleutel.Value)
'		If Ktrl Then
'			Beep()
'			Exit Sub
'		End If
'		Me.Enabled = False
'		PaginaTeller = Val(TxtVolgNummer.Text)
'		If chkAfdrukInVenster.CheckState = 0 Then
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
'		TotaalD = 0
'		TotaalC = 0

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'		Do 
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub PrintInfo
'			bNext(FlJournaal)
'			'UPGRADE_ISSUE: DoEvents does not return a value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8D115264-E27F-4472-A684-865A00B5E826"'
'			XDoEvents = System.Windows.Forms.Application.DoEvents()
'			If Ktrl Or KeyBuf(FlJournaal) > EindSleutel.Value Then
'				Exit Do
'			End If
'		Loop 
'		EindTotaal()
'		If chkAfdrukInVenster.CheckState Then
'		Else
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'		End If
'		If chkAfdrukInVenster.CheckState Then
'		Else
'			Printer.EndDoc()
'		End If
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		Me.Enabled = True
'		cmdSluiten_Click(cmdSluiten, New System.EventArgs())
'		Exit Sub

'PrintInfo: 
'		RecordToVeld(FlJournaal)
'		If vBibTekst(FlJournaal, "#v066 #") >= PlGrensVan.Value And vBibTekst(FlJournaal, "#v066 #") <= PlGrensTot.Value Then
'			Lijn = Lijn + 1
'			If DCDatum.Value <> vBibTekst(FlJournaal, "#v066 #") Then
'				DCDatum.Value = vBibTekst(FlJournaal, "#v066 #")
'				If ErrorTekst = "j" Then
'				Else
'					If TotaalD - TotaalC <> 0 Then
'						ErrorTekst = "j"
'						Msg = "DC ongelijkheid vanaf laatste dag vóór : " & ErrorTekst & vBibTekst(FlJournaal, "#v066 #")
'						MsgBox(Msg)
'					End If
'				End If
'			End If

'			bGet(FlRekening, 0, vSet(vBibTekst(FlJournaal, "#v019 #"), 7))
'			If Ktrl Then
'				VeldTXT(3) = "-"
'			Else
'				RecordToVeld(FlRekening)
'				VeldTXT(3) = vBibTekst(FlRekening, "#v020 #")
'				SnelHelpPrint(vBibTekst(FlRekening, "#v019 #") & " " & vBibTekst(FlRekening, "#v020 #") & " " & VeldTXT(3), blLogging)
'			End If
'			VeldTXT(0) = VB6.Format(Lijn, "00000")
'			VeldTXT(1) = fDatumText(vBibTekst(FlJournaal, "#v066 #"))
'			VeldTXT(2) = vBibTekst(FlJournaal, "#v019 #")
'			VeldTXT(4) = vBibTekst(FlJournaal, "#v067 #")

'			Select Case rsMAR(FlJournaal).Fields("dece068").Value
'				Case Is < 0
'					VeldTXT(5) = ""
'					VeldTXT(6) = Dec(System.Math.Abs(rsMAR(FlJournaal).Fields("dece068").Value), Masker2002.Value)
'					TotaalC = TotaalC + Val(VeldTXT(6))
'				Case Else
'					VeldTXT(5) = Dec((rsMAR(FlJournaal).Fields("dece068").Value), Masker2002.Value)
'					VeldTXT(6) = ""
'					TotaalD = TotaalD + Val(VeldTXT(5))
'			End Select

'			VeldTXT(7) = vBibTekst(FlJournaal, "#v033 #")
'			PrintVelden()
'		End If
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'	End Sub

'	Sub ProefEnSaldiDrukken()
'		Dim Printer As New Printer
'		Dim SubTitelTekst As String
'		Dim BeginSleutel As New VB6.FixedLengthString(15)
'		Dim EindSleutel As New VB6.FixedLengthString(15)
'		Dim VorigeSleutel As New VB6.FixedLengthString(15)
'		Dim DCBedrag As Decimal
'		Dim recVeldje As String
'		Dim rkVeldje As String

'		'On Local Error GoTo PrtHandler2

'		Lijn = 0
'		VorigeSleutel.Value = ""
'		KontroleLijst = ""
'		BeginSleutel.Value = vSet(txtTekstLijn(2).Text, 7) & PlGrensVan.Value
'		EindSleutel.Value = vSet(txtTekstLijn(3).Text, 7) & PlGrensTot.Value

'		psTekst(2) = "Proef- en Saldibalans " & Mid(Mim.Text, InStr(Mim.Text, "["))
'		psTekst(0) = txtTekstLijn(1).Text
'		psTekst(3) = "Boekjaar aanvang : " & VB.Left(BoekjaarVanTot.Value, 4) & ", " & txtTekstLijn(0).Text
'		InitVelden()

'		bFirst(FlJournaal, 0)
'		bGetOrGreater(FlJournaal, 0, BeginSleutel.Value)
'		If Ktrl Then
'			Beep()
'			Exit Sub
'		End If
'		Me.Enabled = False
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
'				Printer.FontBold = True
'			End If
'		End If
'		PrintTitel()

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'		If VB.Right(KeyBuf(FlJournaal), 8) >= PlGrensVan.Value And VB.Right(KeyBuf(FlJournaal), 8) <= PlGrensTot.Value Then
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub PrintInfo
'		End If

'		Do 
'			bNext(FlJournaal)
'			'UPGRADE_ISSUE: DoEvents does not return a value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8D115264-E27F-4472-A684-865A00B5E826"'
'			XDoEvents = System.Windows.Forms.Application.DoEvents()
'			If Ktrl Then
'				Exit Do
'			ElseIf VB.Right(KeyBuf(FlJournaal), 8) >= PlGrensVan.Value And VB.Right(KeyBuf(FlJournaal), 8) <= PlGrensTot.Value Then 
'				If VorigeSleutel.Value = Space(15) Then
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub PrintInfo
'				ElseIf VB.Left(VorigeSleutel.Value, 7) = VB.Left(KeyBuf(FlJournaal), 7) Then 
'					If Mid(VorigeSleutel.Value, 12, 2) <> Mid(KeyBuf(FlJournaal), 12, 2) Then
'						RekeningTotaal()
'						'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'						GoSub PrintInfo
'					Else
'						'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'						GoSub PrintInfo
'					End If
'				Else
'					RekeningTotaal()
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub PrintInfo
'				End If
'			End If
'		Loop 
'		'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'		GoSub RekSaldoKTRL
'		RekeningTotaal()
'		EindTotaal()
'		If chkAfdrukInVenster.CheckState Then
'		Else
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'		End If
'		If KontroleLijst <> "" Then
'			Printer.CurrentY = 400
'			Printer.Print(KontroleLijst)
'			Printer.EndDoc()
'		ElseIf chkAfdrukInVenster.CheckState Then 
'		Else
'			Printer.EndDoc()
'		End If
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		Me.Enabled = True
'		cmdSluiten_Click(cmdSluiten, New System.EventArgs())
'		Exit Sub

'PrintInfo: 
'		RecordToVeld(FlJournaal)
'		If VB.Left(VorigeSleutel.Value, 7) <> VB.Left(KeyBuf(FlJournaal), 7) Then
'			If VorigeSleutel.Value = Space(15) Then
'			ElseIf SaldiKontrole = True Then 
'				'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'				GoSub RekSaldoKTRL
'			End If

'			CumTotaalD = 0
'			CumTotaalC = 0
'			bGet(FlRekening, 0, vSet(vBibTekst(FlJournaal, "#v019 #"), 7))
'			VeldTXT(0) = vBibTekst(FlJournaal, "#v019 #")
'			If Ktrl Then
'				VeldTXT(1) = "Rekening reeds vernietigd..."
'				VeldTXT(2) = ""
'			Else
'				RecordToVeld(FlRekening)
'				VeldTXT(1) = vBibTekst(FlRekening, "#v020 #")

'				If bhEuro Then
'					rkVeldje = "#e" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000") & " #"
'				Else
'					rkVeldje = "#v" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000") & " #"
'				End If

'				VeldTXT(2) = Str(Val(vBibTekst(FlRekening, rkVeldje)))
'				Select Case Val(VeldTXT(2))
'					Case Is < 0
'						VeldTXT(2) = "CS:" & Dec(System.Math.Abs(Val(VeldTXT(2))), Masker2002.Value)
'					Case Else
'						VeldTXT(2) = "DS:" & Dec(Val(VeldTXT(2)), Masker2002.Value)
'				End Select
'			End If
'		End If
'		VorigeSleutel.Value = KeyBuf(FlJournaal)
'		VeldTXT(3) = MaandTekst(Val(Mid(KeyBuf(FlJournaal), 12, 2)))
'		SnelHelpPrint(vBibTekst(FlRekening, "#v019 #") & " " & vBibTekst(FlRekening, "#v020 #") & " " & Trim(VeldTXT(3)) & " " & Mid(KeyBuf(FlJournaal), 8, 4), blLogging)

'		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
'		If IsDbNull(rsMAR(FlJournaal).Fields("dece068").Value) Then
'			DCBedrag = 0
'		Else
'			DCBedrag = rsMAR(FlJournaal).Fields("dece068").Value
'		End If
'		Select Case DCBedrag
'			Case Is < 0
'				SubTotaalC = SubTotaalC + DCBedrag
'				CumTotaalC = CumTotaalC + DCBedrag
'				TotaalC = TotaalC + DCBedrag
'			Case Else
'				SubTotaalD = SubTotaalD + DCBedrag
'				CumTotaalD = CumTotaalD + DCBedrag
'				TotaalD = TotaalD + DCBedrag
'		End Select
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'RekSaldoKTRL: 
'		If bhEuro Then
'			rkVeldje = "#e" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000") & " #"
'		Else
'			rkVeldje = "#v" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000") & " #"
'		End If
'		If System.Math.Abs(CumTotaalD + CumTotaalC) - System.Math.Abs(Val(vBibTekst(FlRekening, rkVeldje))) = 0 Then
'		Else
'			Msg = "KontroleStop bijwerking rekeningsaldo !!" & vbCrLf & vbCrLf
'			Msg = Msg & "Rekening : " & KeyBuf(FlRekening) & vbCrLf
'			If bhEuro Then
'				Msg = Msg & Str(CumTotaalD + CumTotaalC) & " <> " & Str(Val(vBibTekst(FlRekening, "#e" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000") & " #")))
'			Else
'				Msg = Msg & Str(CumTotaalD + CumTotaalC) & " <> " & Str(Val(vBibTekst(FlRekening, "#v" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000") & " #")))
'			End If
'			MsgBox(Msg & vbCrLf & vbCrLf & "Na deze P&S, nogmaals opnieuw P&S a.u.b. samenstellen", MsgBoxStyle.Exclamation)

'			KontroleLijst = KontroleLijst & vBibTekst(FlRekening, "#v020 #") & " " & Dec(CumTotaalD + CumTotaalC, "#########.00") & " " & Dec(Val(vBibTekst(FlRekening, "#v" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000") & " #")), "#########.00") & vbCrLf
'			If bhEuro Then
'				vBib(FlRekening, Str(CumTotaalD + CumTotaalC), "e" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000"))
'				rsMAR(FlRekening).Fields("dece" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000")).Value = CumTotaalD + CumTotaalC
'			Else
'				vBib(FlRekening, Str(CumTotaalD + CumTotaalC), "v" & VB6.Format(22 + BJPERDAT.Boekjaar.SelectedIndex, "000"))
'			End If
'			bUpdate(FlRekening, 0)
'		End If
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'PrtHandler2: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub


'	Private Sub cbDocumentPrinterHier_Change()

'	End Sub


'	'UPGRADE_WARNING: Event cbLijstPrinterHier.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub cbLijstPrinterHier_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbLijstPrinterHier.SelectedIndexChanged

'		LijstPrinterNr = cbLijstPrinterHier.SelectedIndex

'	End Sub


'	Private Sub cbTogglePrinter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbTogglePrinter.Click

'		Me.cbLijstPrinterHier.Enabled = Not Me.cbLijstPrinterHier.Enabled

'	End Sub

'	'UPGRADE_WARNING: Event chkAfdrukLiggend.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub chkAfdrukLiggend_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAfdrukLiggend.CheckStateChanged
'		Dim Printer As New Printer

'		Printer = Printers(LijstPrinterNr)
'		On Error Resume Next
'		'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		Printer.PaperBin = LaadTekst(My.Application.Info.Title, "LIJSTPRINTER")
'		If chkAfdrukLiggend.CheckState = 1 Then
'			Printer.Orientation = PrinterObjectConstants.vbPRORLandscape
'		Else
'			Printer.Orientation = PrinterObjectConstants.vbPRORPortrait
'		End If

'	End Sub

'	'UPGRADE_WARNING: Event chkDetailJournaal.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub chkDetailJournaal_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDetailJournaal.CheckStateChanged

'		If chkDetailJournaal.CheckState Then
'			LblVolgNummer.Visible = True
'			TxtVolgNummer.Visible = True
'			txtTekstLijn(0).Text = CType(BJPERDAT.Controls("PeriodeBoekjaar"), Object).Text
'		Else
'			LblVolgNummer.Visible = False
'			TxtVolgNummer.Visible = False
'			txtTekstLijn(0).Text = VB.Left(VB6.GetItemString(CType(BJPERDAT.Controls("PeriodeBoekjaar"), Object), 0), 10) & " - " & VB.Right(VB6.GetItemString(CType(BJPERDAT.Controls("PeriodeBoekjaar"), Object), BJPERDAT.PeriodeBoekjaar.Items.Count - 1), 10)
'		End If
'		If chkDetailJournaal.CheckState Then
'			BeginPlaySound(9)
'			Msg = "Sinds 1993 zijn er aanbevelingen om na elk boek "
'			Msg = Msg & "een centralisatieblad af te drukken en te bewaren "
'			Msg = Msg & "in een grootboek.  Dit heeft de voorkeur boven het "
'			Msg = Msg & "omslachtig en papierverslindend systeem van algemeen "
'			Msg = Msg & "journaal afdrukken welke U zopas hebt gekozen..." & vbCr & vbCr
'			Msg = Msg & "U KAN OOK voor detailjournaal kiezen om kontroles uit te voeren.  "
'			Msg = Msg & "Laat dan best in venster afdrukken (bvb. vaststelling "
'			Msg = Msg & "van Debet <> Credit verschil de juiste dag van feiten "
'			Msg = Msg & "op te zoeken"
'			MsgBox(Msg)
'		End If

'	End Sub

'	Private Sub cmdSluiten_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSluiten.Click

'		Me.Close()

'	End Sub


'	Private Sub Drukken_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drukken.Click

'		Dim lTeller As Integer

'		If PlGrensVan.Value = VB.Left(BoekjaarVanTot.Value, 8) And PlGrensTot.Value = VB.Right(BoekjaarVanTot.Value, 8) Then
'			SaldiKontrole = True
'		Else
'			SaldiKontrole = False
'		End If

'		If chkDetailJournaal.CheckState Then
'			DetailJournaalDrukken()
'		Else
'			ProefEnSaldiDrukken()
'		End If

'	End Sub

'	Private Sub EindTotaal()
'		Dim Printer As New Printer
'		Dim T As Short

'		'On Local Error GoTo PrtHandler3

'		For T = 0 To 7
'			VeldTXT(T) = ""
'		Next 
'		VeldTXT(1) = "Totalen :"
'		If chkDetailJournaal.CheckState Then
'			VeldTXT(5) = Dec(TotaalD, Masker2002.Value)
'			VeldTXT(6) = Dec(System.Math.Abs(TotaalC), Masker2002.Value)
'		Else
'			VeldTXT(4) = Dec(TotaalD, Masker2002.Value)
'			VeldTXT(5) = Dec(System.Math.Abs(TotaalC), Masker2002.Value)
'		End If
'		T = 0
'		If chkAfdrukInVenster.CheckState Then
'		Else
'			Printer.Print(vbCrLf & Lijntje.Value)
'		End If

'		aa = ""
'		Do While RapportTab(T) <> 0
'			If chkAfdrukInVenster.CheckState Then
'				aa = aa & VeldTXT(T) & vbTab
'			Else
'				Printer.Print(TAB(RapportTab(T)))
'				Printer.Write(VeldTXT(T))
'			End If
'			If RapportTab(T + 1) < RapportTab(T) Then
'				If chkAfdrukInVenster.CheckState = 0 Then
'					Printer.Write(vbCrLf)
'				End If
'			End If
'			T = T + 1
'		Loop 
'		If chkAfdrukInVenster.CheckState Then
'			Xlog.X.AddItem(aa, Xlog.X.Rows - 1)
'		End If

'		If System.Math.Round(TotaalD, 2) + System.Math.Round(TotaalC, 2) Then
'			KontroleLijst = KontroleLijst & vbCrLf & vbCrLf & "Katastrofale fout : Algemene cumul Debet <> cumul credit.  Kontakteer ons 053/21.59.25 !" & vbCrLf & "Indien U niet beschikt over veiligheidskopij dient recuperatie van bestanden door ons te gebeuren."
'		End If

'		Lijn = 0
'		SubTotaalD = 0
'		SubTotaalC = 0
'		TotaalD = 0
'		TotaalC = 0

'		If chkAfdrukInVenster.CheckState Then
'			Xlog.X.Row = 1
'			Xlog.X.Col = 0
'			If chkDetailJournaal.CheckState Then
'				With Xlog.X
'					.set_ColWidth(0, 705)
'					.set_ColWidth(1, 990)
'					.set_ColWidth(2, 750)
'					.set_ColWidth(3, 2865)
'					.set_ColWidth(4, 1830)
'					.set_ColWidth(5, 915)
'					.set_ColWidth(6, 915)
'					.set_ColWidth(7, 1140)
'				End With
'				Xlog.WindowState = System.Windows.Forms.FormWindowState.Maximized
'			Else
'				With Xlog.X
'					.set_ColWidth(0, 700)
'					.set_ColWidth(1, 2955)
'					.set_ColWidth(2, 1250)
'					.set_ColAlignment(2, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'					.set_ColWidth(3, 855)
'					.set_ColWidth(4, 1200)
'					.set_ColAlignment(4, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'					.set_ColWidth(5, 1200)
'					.set_ColAlignment(5, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'					.set_ColWidth(6, 1200)
'					.set_ColAlignment(6, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'					.set_ColWidth(7, 1200)
'					.set_ColAlignment(7, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'				End With
'				Xlog.WindowState = System.Windows.Forms.FormWindowState.Maximized
'			End If
'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal

'			Xlog.WijzigenLijn.Visible = False
'			Xlog.Afsluiten.Enabled = False
'			Xlog.Afsluiten.TabStop = False
'			Xlog.cbAfbeelding.Visible = False
'			XLogKey = ""
'			Xlog.SSTab1.TabPages.Item(1).Visible = False
'			Xlog.ShowDialog()
'			Xlog.Close()
'		End If
'		Exit Sub

'PrtHandler3: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub

'	Private Sub ProefEnSaldi_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
'		Dim Printer As New Printer

'		Dim PrinterTekst As String

'		If Not Toegankelijk(Me) Then
'			Me.Close()
'			Exit Sub
'		End If

'		cbLijstPrinterHier.Items.Clear()
'		If Printers.Count = 0 Then MsgBox("Installeer eerst een printerdriver a.u.b. (ook al beschikt U nog over geen printer.  Bij blijvende problemen in netwerk gelieve op te starten met het command '/P=FALSE' en uw netwerkbeheerder te informeren)", MsgBoxStyle.Exclamation) : End
'		For TelTot = 0 To Printers.Count - 1
'			'UPGRADE_ISSUE: Printer property Printers.Port was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
'			PrinterTekst = Printers(TelTot).Port & " " & Printers(TelTot).DeviceName
'			Me.cbLijstPrinterHier.Items.Add(PrinterTekst)
'		Next 
'		cbLijstPrinterHier.SelectedIndex = LijstPrinterNr

'		Dim TempbModus As Short

'		SubTotaalD = 0
'		SubTotaalC = 0
'		TotaalD = 0
'		TotaalC = 0

'		txtTekstLijn(0).Text = VB.Left(VB6.GetItemString(BJPERDAT.PeriodeBoekjaar, 0), 10) & " - " & VB.Right(VB6.GetItemString(BJPERDAT.PeriodeBoekjaar, BJPERDAT.PeriodeBoekjaar.Items.Count - 1), 10)
'		PlGrensVan.Value = Mid(txtTekstLijn(0).Text, 7, 4) & Mid(txtTekstLijn(0).Text, 4, 2) & Mid(txtTekstLijn(0).Text, 1, 2)
'		PlGrensTot.Value = Mid(txtTekstLijn(0).Text, 20, 4) & Mid(txtTekstLijn(0).Text, 17, 2) & Mid(txtTekstLijn(0).Text, 14, 2)
'		txtTekstLijn(1).Text = Rdt.Value
'		Text = Text & " " & VB.Left(BoekjaarVanTot.Value, 4)

'		Printer = Printers(LijstPrinterNr)
'		On Error Resume Next
'		'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		Printer.PaperBin = LaadTekst(My.Application.Info.Title, "LIJSTPRINTER")

'	End Sub


'	Private Sub InitVelden()
'		Dim T As Short
'		Dim VolgTab As Short

'		If chkDetailJournaal.CheckState Then
'			RapportVeld(0) = "Nr.Ln"
'			RapportTab(0) = 2

'			RapportVeld(1) = "Datum"
'			RapportTab(1) = 8

'			RapportVeld(2) = "RNummer"
'			RapportTab(2) = 19

'			RapportVeld(3) = "Naam Rekening"
'			RapportTab(3) = 27

'			RapportVeld(4) = "Boekingsomschrijving"
'			RapportTab(4) = 68

'			RapportVeld(5) = "    Debet"
'			RapportTab(5) = 104

'			RapportVeld(6) = "   Credit"
'			RapportTab(6) = 115

'			RapportVeld(7) = "dokument"
'			RapportTab(7) = 126
'		Else
'			RapportVeld(0) = "Nummer"
'			RapportTab(0) = 2

'			RapportVeld(1) = "Omschrijving Rekening"
'			RapportTab(1) = 10

'			RapportVeld(2) = "Saldo"
'			RapportTab(2) = 51

'			RapportVeld(3) = "Maand"
'			RapportTab(3) = 65

'			RapportVeld(4) = "     Debet"
'			RapportTab(4) = 76

'			RapportVeld(5) = "    Credit"
'			RapportTab(5) = 87

'			RapportVeld(6) = "Mnd Saldo"
'			RapportTab(6) = 98

'			RapportVeld(7) = "D/C Cumul"
'			RapportTab(7) = 111
'		End If
'		RapportTab(8) = 0

'		If chkAfdrukInVenster.CheckState Then
'			Me.Hide()
'			Xlog.Close()
'			Xlog.Hide()
'			Xlog.Text = "Proef- en Saldibalans"
'			Xlog.X.Cols = 8
'			Xlog.X.Row = 0
'			For T = 0 To 7
'				Xlog.X.Col = T
'				Xlog.X.Text = RapportVeld(T)
'			Next 
'			Me.Show()
'		End If


'	End Sub

'	Private Sub PrintTitel()
'		Dim Printer As New Printer
'		Dim T As Short

'		'On Local Error GoTo PrtHandler1

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

'PrtHandler1: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub

'	Private Sub PrintVelden()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim VeldTekst As String

'		On Error GoTo PrtHandler4

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

'		If chkAfdrukInVenster.CheckState Then Xlog.X.AddItem(aa, Xlog.X.Rows - 1) : Exit Sub

'		If Printer.CurrentY >= Printer.Height - 1200 Then
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			PrintTitel()
'		End If
'		Exit Sub

'PrtHandler4: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub

'	Private Sub RekeningTotaal()
'		Dim Printer As New Printer
'		Dim T As Short

'		'On Local Error GoTo PrtHandler5
'		Dim TotaalDC As Double
'		Dim CumTotaalDC As Double

'		VeldTXT(4) = Dec(SubTotaalD, Masker2002.Value)
'		VeldTXT(5) = Dec(System.Math.Abs(SubTotaalC), Masker2002.Value)
'		'VeldTXT(6) = Dec$((CumTotaalD), MaskerSy(0))
'		TotaalDC = SubTotaalD + SubTotaalC
'		If TotaalDC < 0 Then
'			VeldTXT(6) = "C:" & Dec(System.Math.Abs(TotaalDC), Masker2002.Value)
'		ElseIf TotaalDC > 0 Then 
'			VeldTXT(6) = "D:" & Dec(TotaalDC, Masker2002.Value)
'		Else
'			VeldTXT(6) = "  " & Dec(TotaalDC, Masker2002.Value)
'		End If

'		CumTotaalDC = CumTotaalD + CumTotaalC
'		If CumTotaalDC < 0 Then
'			VeldTXT(7) = "C:" & Dec(System.Math.Abs(CumTotaalDC), Masker2002.Value)
'		ElseIf CumTotaalDC > 0 Then 
'			VeldTXT(7) = "D:" & Dec(CumTotaalDC, Masker2002.Value)
'		Else
'			VeldTXT(7) = "  " & Dec(CumTotaalDC, Masker2002.Value)
'		End If

'		T = 0
'		aa = ""
'		Do While RapportTab(T) <> 0
'			If chkAfdrukInVenster.CheckState Then
'				aa = aa & VeldTXT(T) & vbTab
'			Else
'				Printer.Print(TAB(RapportTab(T)))
'				Printer.Write(VeldTXT(T))
'				If RapportTab(T + 1) < RapportTab(T) Then
'					Printer.Write(vbCrLf)
'				End If
'			End If
'			T = T + 1
'		Loop 

'		SubTotaalD = 0
'		SubTotaalC = 0

'		If chkAfdrukInVenster.CheckState Then
'			Xlog.X.AddItem(aa, Xlog.X.Rows - 1)
'		ElseIf Printer.CurrentY >= Printer.Height - 1200 Then 
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			PrintTitel()
'		End If

'		For T = 0 To 7
'			VeldTXT(T) = ""
'		Next 
'		Exit Sub

'PrtHandler5: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub



'	Private Sub txtTekstLijn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTekstLijn.Leave
'		Dim Index As Short = txtTekstLijn.GetIndex(eventSender)

'		Select Case Index
'			Case 0
'				If DatumFout(VB.Right(txtTekstLijn(0).Text, 10)) Then
'					MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !")
'					txtTekstLijn(0).Text = BJPERDAT.PeriodeBoekjaar.Text
'					txtTekstLijn(0).Focus()
'					Exit Sub
'				ElseIf Len(txtTekstLijn(0).Text) <> 23 Then 
'					MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !")
'					txtTekstLijn(0).Text = BJPERDAT.PeriodeBoekjaar.Text
'					txtTekstLijn(0).Focus()
'					Exit Sub
'				Else
'					PlGrensVan.Value = Mid(txtTekstLijn(0).Text, 7, 4) & Mid(txtTekstLijn(0).Text, 4, 2) & Mid(txtTekstLijn(0).Text, 1, 2)
'					PlGrensTot.Value = Mid(txtTekstLijn(0).Text, 20, 4) & Mid(txtTekstLijn(0).Text, 17, 2) & Mid(txtTekstLijn(0).Text, 14, 2)
'					If PlGrensVan.Value < VB.Left(BoekjaarVanTot.Value, 8) Or PlGrensTot.Value > VB.Right(BoekjaarVanTot.Value, 8) Then
'						'MsgBox "Geen selectie BUITEN het boekjaar a.u.b. !"
'						'txtTekstLijn(0).Text = BJPERDAT.PeriodeBoekjaar.Text
'						'txtTekstLijn(0).SetFocus
'					End If
'				End If

'			Case 1
'				If DatumFout(txtTekstLijn(1).Text) Then
'					Beep()
'					txtTekstLijn(1).Text = Rdt.Value
'					txtTekstLijn(1).Focus()
'				End If
'		End Select

'	End Sub
'End Class