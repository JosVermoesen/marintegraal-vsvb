﻿Public Class frmHistoriekRekeningen
    Private Sub frmHistoriekRekeningen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Friend Class HistoriekPrint
'	Inherits System.Windows.Forms.Form
'	'UPGRADE_NOTE: DefInt A-Z statement was removed. Variables were explicitly declared as type Short. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92AFD3E3-440D-4D49-A8BF-580D74A8C9F2"'

'	Dim ReportText(5) As String
'	Dim LFontSize(20) As Single
'	Dim LAantalL(20) As Short
'	Dim FontDefChanged As Short

'	Dim FieldText(20) As String

'	Dim SubTotaalD As Decimal
'	Dim SubTotaalC As Decimal
'	Dim TotalDebit As Decimal
'	Dim TotalCredit As Decimal
'	Dim AlgTotaalD As Decimal
'	Dim AlgTotaalC As Decimal

'	Dim Line As Integer
'	Dim SelectieVanTot As String


'	Sub AlgemeenEindTotaal()
'		Dim Printer As New Printer

'		Dim T As Short

'		For T = 0 To 8
'			FieldText(T) = ""
'		Next 

'		FieldText(2) = "Proef- en Saldi :"
'		FieldText(5) = Dec(AlgTotaalD, MaskEURBH)
'		FieldText(6) = Dec(System.Math.Abs(AlgTotaalC), MaskEURBH)

'		T = 0
'		Do While ReportTab(T) <> 0
'			Printer.Print(TAB(ReportTab(T)))
'			Printer.Write(FieldText(T))
'			If ReportTab(T + 1) < ReportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 

'	End Sub

'	Private Sub Annuleren_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Annuleren.Click

'		Me.Close()

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

'	Private Sub Drukken_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drukken.Click
'		Dim Printer As New Printer
'		Dim BeginSleutel As New VB6.FixedLengthString(15)
'		Dim EindSleutel As New VB6.FixedLengthString(15)
'		Dim SubTitelTekst As String
'		Dim VorigeSleutel As New VB6.FixedLengthString(15)
'		Dim DCBedrag As Decimal
'		Dim XX As Short

'		Line = 0
'		VorigeSleutel.Value = ""
'		BeginSleutel.Value = vSet(TekstLijn(2).Text, 7) & VB.Left(SelectieVanTot, 8)
'		EindSleutel.Value = vSet(TekstLijn(3).Text, 7) & VB.Right(SelectieVanTot, 8)

'		ReportText(2) = "Historieken " & Mid(Mim.Text, InStr(Mim.Text, "["))
'		ReportText(0) = TekstLijn(1).Text

'		InitializeFields()
'		bFirst(FlJournaal, 0)
'		bGetOrGreater(FlJournaal, 0, BeginSleutel.Value)
'		If Ktrl Then
'			Beep()
'			Exit Sub
'		End If

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'		PageCounter = 0
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
'				Printer.FontBold = True
'			End If
'		End If
'		VolgendePagina()

'		If DatumKtrl(VB.Right(KeyBuf(FlJournaal), 8), SleutelBoekjaar) Then
'			If VB.Left(KeyBuf(FlJournaal), 7) >= VB.Left(BeginSleutel.Value, 7) Then
'				'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'				GoSub InstalSubTitel
'				'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'				GoSub PrintInfo
'			End If
'		End If

'		Do 
'			bNext(FlJournaal)
'			If Ktrl Or vSet(KeyBuf(FlJournaal), 15) > EindSleutel.Value Then
'				Exit Do
'			End If
'			If VB.Left(VorigeSleutel.Value, 7) = VB.Left(KeyBuf(FlJournaal), 7) Then
'				If Not DatumKtrl(VB.Right(KeyBuf(FlJournaal), 8), SleutelBoekjaar) Then
'				ElseIf Mid(VorigeSleutel.Value, 12, 2) = Mid(KeyBuf(FlJournaal), 12, 2) Then 
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub PrintInfo
'				Else
'					PeriodiekTotaal()
'					If chkAfdrukInVenster.CheckState Then
'					Else
'						Printer.Write(vbCrLf)
'					End If
'					VorigeSleutel.Value = vSet(KeyBuf(FlJournaal), 15)
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub PrintInfo
'				End If
'			Else
'				If DatumKtrl(VB.Right(KeyBuf(FlJournaal), 8), SleutelBoekjaar) Then
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub InstalSubTitel
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub PrintInfo
'				End If
'			End If
'		Loop 
'		PeriodiekTotaal()
'		EindTotaal()
'		AlgemeenEindTotaal()
'		Printer.NewPage()
'		Printer.EndDoc()
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		Annuleren_Click(Annuleren, New System.EventArgs())
'		Exit Sub

'InstalSubTitel: 
'		If Line <> 0 Then
'			PeriodiekTotaal()
'			EindTotaal()
'		End If
'		Line = 0
'		RecordToVeld(FlJournaal)
'		MsJetGet(FlLedgerAccount, 0, vSet(vBibTekst(FlJournaal, "#v019 #"), 7))
'		If Ktrl Then
'			SubTitelTekst = vSet(vBibTekst(FlJournaal, "#v019 #"), 7) & " rekening reeds vernietigd..."
'		Else
'			RecordToVeld(FlLedgerAccount)
'			SubTitelTekst = vBibTekst(FlLedgerAccount, "#v019 #") & " " & vBibTekst(FlLedgerAccount, "#v020 #")
'			SnelHelpPrint(SubTitelTekst, blLogging)
'			ReportText(3) = SubTitelTekst
'		End If
'		VorigeSleutel.Value = vSet(KeyBuf(FlJournaal), 15)
'		PrintTitel()
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'PrintInfo: 
'		RecordToVeld(FlJournaal)
'		Line = Line + 1
'		FieldText(0) = VB6.Format(Line, "00000")
'		FieldText(1) = FunctionDateText(vBibTekst(FlJournaal, "#v066 #"))
'		FieldText(2) = vBibTekst(FlJournaal, "#v067 #")
'		FieldText(3) = vBibTekst(FlJournaal, "#v033 #")
'		FieldText(4) = vBibTekst(FlJournaal, "#v038 #")
'		FieldText(7) = vBibTekst(FlJournaal, "#v069 #")
'		If RTrim(FieldText(3)) <> "" Then
'			MsJetGet(Fldokument, 0, FieldText(3))
'			If Ktrl Then
'				FieldText(8) = FieldText(3)
'			Else
'				FieldText(8) = ""
'			End If
'		Else
'			FieldText(8) = ""
'		End If

'		DCBedrag = Val(vBibTekst(FlJournaal, "#v068 #"))

'		Select Case DCBedrag
'			Case Is < 0
'				SubTotaalC = SubTotaalC + DCBedrag
'				TotalCredit = TotalCredit + DCBedrag
'				FieldText(5) = ""
'				FieldText(6) = Dec(System.Math.Abs(DCBedrag), MaskEURBH)
'			Case Else
'				SubTotaalD = SubTotaalD + DCBedrag
'				TotalDebit = TotalDebit + DCBedrag
'				FieldText(5) = Dec(DCBedrag, MaskEURBH)
'				FieldText(6) = ""
'		End Select

'		PrintVelden()
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'	End Sub

'	Private Sub EindTotaal()
'		Dim Printer As New Printer
'		Dim T As Short

'		For T = 0 To 8
'			FieldText(T) = ""
'		Next 

'		FieldText(2) = "Boekjaartotalen :"
'		FieldText(5) = Dec(TotalDebit, MaskEURBH)
'		FieldText(6) = Dec(System.Math.Abs(TotalCredit), MaskEURBH)

'		T = 0
'		Do While ReportTab(T) <> 0
'			Printer.Print(TAB(ReportTab(T)))
'			Printer.Write(FieldText(T))
'			If ReportTab(T + 1) < ReportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 
'		Printer.Write(vbCrLf)
'		If Printer.CurrentY >= Printer.Height - 1250 Then
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			VolgendePagina()
'			PrintTitel()
'		End If

'		Line = 0
'		SubTotaalD = 0
'		SubTotaalC = 0
'		TotalDebit = 0
'		TotalCredit = 0

'	End Sub

'	Private Sub HistoriekPrint_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
'		Dim Printer As New Printer

'		If Not Toegankelijk(Me) Then
'			Me.Close()
'			Exit Sub
'		End If

'		PageCounter = 0
'		AlgTotaalD = 0
'		AlgTotaalC = 0
'		SubTotaalD = 0
'		SubTotaalC = 0
'		TotalDebit = 0
'		TotalCredit = 0

'		SelectieVanTot = BoekjaarVanTot.Value
'		TxtPeriodeVanTot.Text = FunctionDateText(VB.Left(SelectieVanTot, 8)) & " - " & FunctionDateText(VB.Right(SelectieVanTot, 8))
'		TekstLijn(1).Text = MimGlobalDate.Value
'		TekstLijn(2).Text = CStr(10)
'		TekstLijn(3).Text = "7999999"

'		Printer = Printers(LijstPrinterNr)
'		On Error Resume Next
'		'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		Printer.PaperBin = LaadTekst(My.Application.Info.Title, "LIJSTPRINTER")
'		If Printer.Orientation = PrinterObjectConstants.vbPRORLandscape Then
'			chkAfdrukLiggend.CheckState = System.Windows.Forms.CheckState.Checked
'		Else
'			chkAfdrukLiggend.CheckState = System.Windows.Forms.CheckState.Unchecked
'		End If
'		chkAfdrukLiggend_CheckStateChanged(chkAfdrukLiggend, New System.EventArgs())

'	End Sub

'	Private Sub InitializeFields()

'		ReportField(0) = "Line"
'		ReportTab(0) = 2

'		ReportField(1) = "Datum"
'		ReportTab(1) = 9

'		ReportField(2) = "Omschrijving"
'		ReportTab(2) = 22

'		ReportField(3) = "dokument"
'		ReportTab(3) = 53

'		ReportField(4) = "Fin.Dok."
'		ReportTab(4) = 67

'		ReportField(5) = "       Debet"
'		ReportTab(5) = 76

'		ReportField(6) = "      Credit"
'		ReportTab(6) = 89

'		ReportField(7) = "T.Reken"
'		ReportTab(7) = 103

'		ReportField(8) = "VSF.Kode"
'		ReportTab(8) = 111

'		ReportTab(9) = 0

'	End Sub

'	Private Sub PeriodiekTotaal()
'		Dim Printer As New Printer
'		Dim T As Short

'		On Error GoTo PrtHandler5

'		For T = 0 To 8
'			FieldText(T) = ""
'		Next 

'		FieldText(2) = "Periodiek totaal :"
'		FieldText(5) = Dec(SubTotaalD, MaskEURBH)
'		FieldText(6) = Dec(System.Math.Abs(SubTotaalC), MaskEURBH)

'		AlgTotaalD = AlgTotaalD + SubTotaalD
'		AlgTotaalC = AlgTotaalC + SubTotaalC
'		If cbPeriodiekeTotalen.CheckState <> 0 Then
'		Else
'			SubTotaalD = 0
'			SubTotaalC = 0
'			Exit Sub
'		End If

'		T = 0
'		Printer.Write(vbCrLf)
'		Do While ReportTab(T) <> 0
'			Printer.Print(TAB(ReportTab(T)))
'			Printer.Write(FieldText(T))
'			If ReportTab(T + 1) < ReportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 

'		'Printer.Print vbCrLf;
'		SubTotaalD = 0
'		SubTotaalC = 0
'		If Printer.CurrentY >= Printer.Height - 1250 Then
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			VolgendePagina()
'			PrintTitel()
'		End If
'		Exit Sub

'PrtHandler5: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub

'	Private Sub PrintTitel()
'		Dim Printer As New Printer
'		Dim T As Short

'		On Error GoTo PrtHandler1

'		If chkAfdrukInVenster.CheckState Then Exit Sub

'		Printer.Write(TAB(1), ReportText(3) & vbCrLf)
'		Printer.Write(FullLine.Value & vbCrLf)

'		Do While ReportTab(T) <> 0
'			Printer.Print(TAB(ReportTab(T)))
'			Printer.Write(ReportField(T))
'			If ReportTab(T + 1) < ReportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 

'		Printer.Write(FullLine.Value & vbCrLf)
'		If Printer.CurrentY >= Printer.Height - 1250 Then
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			VolgendePagina()
'			PrintTitel()
'		End If
'		Exit Sub

'PrtHandler1: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub

'	Private Sub PrintVelden()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim VeldTekst As String

'		Do While ReportTab(T) <> 0
'			Printer.Print(TAB(ReportTab(T)))
'			Printer.Write(FieldText(T))
'			If ReportTab(T + 1) < ReportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 
'		If Printer.CurrentY >= Printer.Height - 1250 Then
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			VolgendePagina()
'			PrintTitel()
'		End If
'		Exit Sub

'	End Sub

'	Private Sub TekstLijn_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Enter
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		TekstLijn(Index).SelectionStart = 0
'		TekstLijn(Index).SelectionLength = Len(TekstLijn(Index).Text)

'		Select Case Index
'			Case 2, 3
'				SnelHelpPrint("[Ctrl] voor geïndexeerd zoeken", blLogging)
'		End Select

'	End Sub

'	Private Sub TekstLijn_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TekstLijn.KeyDown
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		On Error Resume Next
'		If KeyCode = 13 Then System.Windows.Forms.SendKeys.SendWait("{TAB}") : Exit Sub
'		Select Case Index
'			Case 2, 3
'				Select Case KeyCode
'					Case 17
'						aIndex = 0
'						SharedFl = FlLedgerAccount
'						GridText = TekstLijn(Index).Text
'						SqlSearch.ShowDialog()
'						If Ktrl = 0 Then
'							TekstLijn(Index).Text = vBibTekst(FlLedgerAccount, "#v019 #")
'							SnelHelpPrint(vBibTekst(FlLedgerAccount, "#v020 #"), blLogging)
'						End If
'				End Select
'		End Select

'	End Sub

'	Private Sub TekstLijn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Leave
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		Select Case Index
'			Case 1
'				If DateWrongFormat(TekstLijn(1).Text) Then
'					Beep()
'					TekstLijn(1).Text = MimGlobalDate.Value
'					TekstLijn(1).Focus()
'				End If
'			Case 2
'				bGetOrGreater(FlLedgerAccount, 0, vSet(TekstLijn(2).Text, 7))
'				If Ktrl Then
'				Else
'					RecordToVeld(FlLedgerAccount)
'					TekstLijn(2).Text = vBibTekst(FlLedgerAccount, "#v019 #")
'					SnelHelpPrint(vBibTekst(FlLedgerAccount, "#v020 #"), blLogging)
'				End If
'		End Select

'	End Sub

'	Private Sub VolgendePagina()
'		Dim Printer As New Printer

'		PageCounter = PageCounter + 1
'		Printer.CurrentY = 400
'		Printer.Write(TAB(1), ReportText(2), TAB(108), "Pagina : " & Dec(PageCounter, "##########") & vbCrLf)
'		Printer.Write(TAB(108), "Datum  : " & ReportText(0) & vbCrLf & vbCrLf)

'	End Sub

'	Private Sub TxtPeriodeVanTot_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtPeriodeVanTot.Enter

'		TxtPeriodeVanTot.SelectionStart = 0
'		TxtPeriodeVanTot.SelectionLength = Len(TxtPeriodeVanTot.Text)

'	End Sub

'	Private Sub TxtPeriodeVanTot_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtPeriodeVanTot.Leave

'		If DateWrongFormat(VB.Right(TxtPeriodeVanTot.Text, 10)) Then
'			MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !")
'			TxtPeriodeVanTot.Text = FunctionDateText(VB.Left(BoekjaarVanTot.Value, 8)) & " - " & FunctionDateText(VB.Right(BoekjaarVanTot.Value, 8))
'			SelectieVanTot = BoekjaarVanTot.Value
'			TxtPeriodeVanTot.Focus()
'			Exit Sub
'		ElseIf Len(TxtPeriodeVanTot.Text) <> 23 Then 
'			MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !")
'			TxtPeriodeVanTot.Text = FunctionDateText(VB.Left(BoekjaarVanTot.Value, 8)) & " - " & FunctionDateText(VB.Right(BoekjaarVanTot.Value, 8))
'			TxtPeriodeVanTot.Focus()
'			SelectieVanTot = BoekjaarVanTot.Value
'			Exit Sub
'		Else
'			SelectieVanTot = DatumKey(VB.Left(TxtPeriodeVanTot.Text, 10)) & DatumKey(VB.Right(TxtPeriodeVanTot.Text, 10))
'		End If

'	End Sub
'End Class