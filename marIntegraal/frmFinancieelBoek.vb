﻿Public Class frmFinancieelBoek
    Private Sub frmFinancieelBoek_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Friend Class FinancieelBoek
'	Inherits System.Windows.Forms.Form
'	'UPGRADE_NOTE: DefInt A-Z statement was removed. Variables were explicitly declared as type Short. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92AFD3E3-440D-4D49-A8BF-580D74A8C9F2"'

'	Dim psTekst(5) As String
'	Dim TotaalD As Decimal
'	Dim TotaalC As Decimal

'	Dim LFontSize(20) As Single
'	Dim LAantalL(20) As Short
'	Dim FontDefChanged As Short

'	Dim VeldTXT(17) As String

'	Dim RecNummer(9) As Short
'	'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
'	Dim RekeningNummer(9) As String*7

'	Dim PlGrensVan As New VB6.FixedLengthString(8)
'	Dim PlGrensTot As New VB6.FixedLengthString(8)

'	Dim ErrorMsg As String
'	Dim JournaalManueelVlag As Boolean

'	Sub DetailFinancieelStuk(ByRef DeString As String)
'		Dim A As String

'		InfoScherm.Close()
'		'UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
'		Load(InfoScherm)
'		InfoScherm.Text = InfoScherm.Text & ", Journaaldetail voor uittreksel : " & DeString
'		InfoScherm.X.Rows = 2
'		InfoScherm.X.Cols = 8
'		InfoScherm.X.Col = 0
'		InfoScherm.X.Row = 0
'		InfoScherm.X.Text = "Datum (v066)"
'		InfoScherm.X.set_ColAlignment(0, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.Col = 1
'		InfoScherm.X.Text = "Rekening (v019)"
'		InfoScherm.X.set_ColAlignment(1, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.Col = 2
'		InfoScherm.X.Text = "Naam (v020)"
'		InfoScherm.X.set_ColAlignment(2, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.Col = 3
'		InfoScherm.X.Text = "Bedrag (dece068)"
'		InfoScherm.X.set_ColAlignment(3, MSFlexGridLib.AlignmentSettings.flexAlignGeneral)
'		InfoScherm.X.Col = 4
'		InfoScherm.X.Text = "Boekingsomschrijving (v067)"
'		InfoScherm.X.set_ColAlignment(4, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.Col = 5
'		InfoScherm.X.Text = "AV Dokum. (v033)"
'		InfoScherm.X.set_ColAlignment(5, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.Col = 6
'		InfoScherm.X.Text = "TegenRek. (v069)"
'		InfoScherm.X.set_ColAlignment(6, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.Col = 7
'		InfoScherm.X.Text = "vsfRecord"

'		bGet(FlJournaal, 2, vSet(DeString, 8))
'		If Ktrl Then
'			Beep()
'			MsgBox("Geen journaallijnen voor " & DeString)
'			Exit Sub
'		Else
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub VolgendeLijn
'			Do 
'				bNext(FlJournaal)
'				If Ktrl Or KeyBuf(FlJournaal) <> DeString Then
'					Exit Do
'				Else
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub VolgendeLijn
'				End If
'			Loop 
'		End If
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal

'OpHetScherm: 
'		InfoScherm.X.Row = 1
'		InfoScherm.X.Col = 0

'		InfoScherm.X.set_ColWidth(0, 1005)
'		InfoScherm.X.set_ColWidth(1, 765)
'		InfoScherm.X.set_ColWidth(2, 2160)
'		InfoScherm.X.set_ColWidth(3, 750)
'		InfoScherm.X.set_ColWidth(4, 1950)
'		InfoScherm.X.set_ColWidth(5, 1150)
'		InfoScherm.X.set_ColWidth(6, 870)
'		InfoScherm.X.set_ColWidth(7, 6000)
'		InfoScherm.X.set_ColAlignment(0, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.set_ColAlignment(1, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.set_ColAlignment(2, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.set_ColAlignment(3, MSFlexGridLib.AlignmentSettings.flexAlignGeneral)
'		InfoScherm.X.set_ColAlignment(4, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.set_ColAlignment(5, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.set_ColAlignment(6, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)
'		InfoScherm.X.set_ColAlignment(7, MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter)

'XLogShow: 
'		InfoScherm.ShowDialog()
'		InfoScherm.Close()
'		Exit Sub

'VolgendeLijn: 
'		RecordToVeld(FlJournaal)
'		If vSet(vBibTekst(FlJournaal, "#v019 #"), 7) = VB.Left(KeuzeInfo(0).Text, 7) Then
'			'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'			Return 
'		ElseIf fDatumText(vBibTekst(FlJournaal, "#v066 #")) <> Mid(UittrekselsLijst.Text, 12, 10) Then 
'			If Not JournaalManueelVlag Then
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 
'			End If
'		ElseIf RTrim(vBibTekst(FlJournaal, "#v019 #")) <> "" Then 
'			If vSet(vBibTekst(FlJournaal, "#v069 #"), 7) <> VB.Left(KeuzeInfo(0).Text, 7) Then
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 
'			End If
'		End If
'		A = fDatumText(vBibTekst(FlJournaal, "#v066 #")) & vbTab
'		A = A & vBibTekst(FlJournaal, "#v019 #") & vbTab
'		bGet(FlRekening, 0, vSet(vBibTekst(FlJournaal, "#v019 #"), 7))
'		If Ktrl Then
'			A = A & "//" & vbTab
'		Else
'			RecordToVeld(FlRekening)
'			A = A & vBibTekst(FlRekening, "#v020 #") & vbTab
'		End If
'		A = A & rsMAR(FlJournaal).Fields("v068").Value & vbTab
'		A = A & rsMAR(FlJournaal).Fields("v067").Value & vbTab
'		A = A & rsMAR(FlJournaal).Fields("v033").Value & vbTab
'		A = A & rsMAR(FlJournaal).Fields("v069").Value & vbTab
'		A = A & TLBRecord(FlJournaal)
'		InfoScherm.X.AddItem(A, InfoScherm.X.Rows - 1)
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'	End Sub

'	Private Sub Annuleren_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Annuleren.Click

'		Me.Close()

'	End Sub

'	Private Sub CumulPrint()
'		Dim Printer As New Printer
'		Dim RekeningNaam As New VB6.FixedLengthString(30)
'		Dim Tabul As Short

'		On Error GoTo PrtHandler

'		If chkAfdrukInVenster.CheckState Then
'		Else
'			On Error Resume Next
'			Printer.EndDoc()
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
'			Err.Clear()
'			On Error Resume Next
'			If Err.Number - 480 > 0 Then Exit Sub
'			PrintTitel()
'			PrintTotaal()
'		End If
'		Printer.Print()
'		Printer.Print(TAB(2), "** CENTRALISATIE **")
'		Printer.Print("")

'		bClose(FlDummy)
'		bFirst(FlDummy, 0)
'		RecordToVeld(FlDummy)
'		bGet(FlRekening, 0, VB.Left(FVT(FlDummy, 0), 7))
'		If Ktrl Then
'			RekeningNaam.Value = "Rekening reeds vernietigd !!!"
'		Else
'			RecordToVeld(FlRekening)
'			RekeningNaam.Value = vBibTekst(FlRekening, "#v020 #")
'		End If
'		Tabul = 0
'		Printer.Write(TAB(Tabul + 2), Dec(Val(vBibTekst(FlDummy, "#v013 #")), "####") & " x " & vSet(vBibTekst(FlDummy, "#v089 #"), 7) & " " & RekeningNaam.Value & " " & Dec(Val(vBibTekst(FlDummy, "#v068 #")), MaskerEURBH))

'		Do 
'			bNext(FlDummy)
'			If Ktrl Then
'				Exit Do
'			End If
'			RecordToVeld(FlDummy)
'			bGet(FlRekening, 0, VB.Left(FVT(FlDummy, 0), 7))
'			If Ktrl Then
'				RekeningNaam.Value = "Rekening reeds vernietigd !!!"
'			Else
'				RecordToVeld(FlRekening)
'				RekeningNaam.Value = vBibTekst(FlRekening, "#v020 #")
'			End If
'			If Tabul = 0 Then
'				Tabul = 59
'				Printer.Write(TAB(Tabul + 2), Dec(Val(vBibTekst(FlDummy, "#v013 #")), "####") & " x " & vSet(vBibTekst(FlDummy, "#v089 #"), 7) & " " & RekeningNaam.Value & " " & Dec(Val(vBibTekst(FlDummy, "#v068 #")), MaskerEURBH) & vbCrLf)
'			Else
'				Tabul = 0
'				Printer.Write(TAB(Tabul + 2), Dec(Val(vBibTekst(FlDummy, "#v013 #")), "####") & " x " & vSet(vBibTekst(FlDummy, "#v089 #"), 7) & " " & RekeningNaam.Value & " " & Dec(Val(vBibTekst(FlDummy, "#v068 #")), MaskerEURBH))
'			End If
'		Loop 
'		Exit Sub

'PrtHandler: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

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


'	Private Sub CmdJournaalManueel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdJournaalManueel.Click
'		Dim KtrlInput As String

'InputVanFinancieelStuk: 
'		KtrlInput = InputBox("Geef nummer van het financieel stuk (8 tekens !)", "Financieel journaal kontrole ")
'		If KtrlInput = "" Then
'			Exit Sub
'		ElseIf Len(KtrlInput) <> 8 Then 
'			Msg = "dokumentnummer bestaat uit 8 tekens !" & vbCrLf & vbCrLf
'			Msg = Msg & "Voorbeeld:" & vbCrLf
'			Msg = Msg & "Rekening 'GB', werkelijk jaar 19'98'," & vbCrLf
'			Msg = Msg & "uittreksel 124, geeft als dokumentnummer:" & vbCrLf & vbCrLf
'			Msg = Msg & "GB980124"
'			MsgBox(Msg)
'			Exit Sub
'		End If
'		JournaalManueelVlag = True
'		DetailFinancieelStuk(KtrlInput)
'		JournaalManueelVlag = False

'	End Sub

'	Private Sub Drukken_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drukken.Click
'		Dim Printer As New Printer
'		Dim bModDummy As Short
'		Dim TelUittreksel As Short
'		Dim DCBedrag As Decimal
'		Dim HetBedrag As Decimal
'		Dim XX As Short

'		Dim FinRekening As New VB6.FixedLengthString(7)
'		Dim DeRekening As New VB6.FixedLengthString(7)

'		On Error GoTo PrtHandler9

'		psTekst(2) = "Financiëel Boek " & Mid(Mim.Text, InStr(Mim.Text, "["))
'		psTekst(0) = TekstLijn(1).Text
'		psTekst(3) = VB.Right(KeuzeInfo(0).Text, 40) & " " & TekstLijn(0).Text

'		ErrorMsg = ""
'		TotaalD = 0
'		TotaalC = 0
'		PaginaTeller = 0

'		If UittrekselsLijst.Items.Count = 0 Then
'			Exit Sub
'		Else
'			InitVelden()
'			bClose(FlDummy)
'			ClearFlDummy()
'			Ktrl = bOpen(FlDummy)

'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'			If chkAfdrukInVenster.CheckState = 0 Then
'				If Printer.Width > 12000 Then
'					Printer.FontSize = 10
'					Printer.FontName = "Courier New"
'					Printer.Print(" ")
'					Printer.FontSize = 10
'				Else
'					Printer.FontSize = 7.2
'					Printer.FontName = "Courier New"
'					Printer.Print(" ")
'					Printer.FontSize = 7.2
'					Printer.FontBold = True
'				End If
'			End If
'			PrintTitel()
'		End If

'		For TelUittreksel = 0 To UittrekselsLijst.Items.Count - 1
'			UittrekselsLijst.SelectedIndex = TelUittreksel
'			VeldTXT(0) = Mid(UittrekselsLijst.Text, 12, 10)
'			VeldTXT(1) = VB.Left(KeuzeInfo(0).Text, 7)
'			FinRekening.Value = VeldTXT(1)
'			VeldTXT(2) = Mid(UittrekselsLijst.Text, 25, 30)
'			VeldTXT(3) = "DS/CS Saldo van het uittreksel"

'			VeldTXT(4) = Mid(UittrekselsLijst.Text, 56, 12)
'			VeldTXT(5) = Mid(UittrekselsLijst.Text, 69, 12)
'			VeldTXT(6) = VB.Left(UittrekselsLijst.Text, 8)
'			DeRekening.Value = VeldTXT(1)
'			HetBedrag = -Val(VeldTXT(5)) + Val(VeldTXT(4))
'			Select Case HetBedrag
'				Case Is < 0
'					TotaalC = TotaalC + HetBedrag
'				Case Else
'					TotaalD = TotaalD + HetBedrag
'			End Select
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub DetailCumul
'			PrintVelden()
'			If TelUittreksel = UittrekselsLijst.Items.Count - 1 Then
'				'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'				GoSub DetailPrintJournaal
'			ElseIf VB.Left(VB6.GetItemString(UittrekselsLijst, TelUittreksel), 21) = VB.Left(VB6.GetItemString(UittrekselsLijst, TelUittreksel + 1), 21) Then 
'				ErrorMsg = ErrorMsg & VB.Left(VB6.GetItemString(UittrekselsLijst, TelUittreksel), 21) & " / " & VB.Left(VB6.GetItemString(UittrekselsLijst, TelUittreksel + 1), 21) & " onlogica." & vbCrLf
'			Else
'				'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'				GoSub DetailPrintJournaal
'			End If
'		Next 
'		PrintTotaal()
'		CumulPrint()
'		If VeldTXT(4) = VeldTXT(5) Then
'			If ErrorMsg <> "" Then
'				ErrorMsg = vbCrLf & vbCrLf & "Er zijn uittreksel onjuist ingebracht.  De boekhouding blijft gelukkig correct" & vbCrLf & vbCrLf & ErrorMsg
'			End If
'		Else
'			ErrorMsg = ErrorMsg & "DEBET<>CREDIT : de boekhoudDATABASE instabiel ?  Dient geRESTORED te worden !!!" & vbCrLf & vbCrLf
'		End If

'		If ErrorMsg <> "" Then
'			Printer.Write(vbCrLf & vbCrLf)
'			Printer.Write(ErrorMsg & vbCrLf & vbCrLf)
'			Printer.Write("De gebruiker doet er goed aan steeds te kontroleren :" & vbCrLf)
'			Printer.Write("* Eén Bankuittreksels pér UITTREKSELDATUM !" & vbCrLf)
'			Printer.Write("* Steeds datum kontroleren vooraleer weg te schrijven !!!" & vbCrLf & vbCrLf)
'			Printer.Print("Indien DEBET=CREDIT is de boekhouding toch correct bijgewerkt en hoeft U voor huidige onregelmatigheden")
'			Printer.Print("niets recht te zetten")
'		End If
'		Printer.EndDoc()
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		Annuleren_Click(Annuleren, New System.EventArgs())
'		Exit Sub

'DetailPrintJournaal: 
'		bGet(FlJournaal, 2, VB.Left(UittrekselsLijst.Text, 8))
'		If Ktrl Or KeyBuf(FlJournaal) <> VB.Left(UittrekselsLijst.Text, 8) Then
'			Beep()
'			MsgBox("onlogische situatie")
'			Exit Sub
'		Else
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub PrintInfo
'		End If
'		Do 
'			bNext(FlJournaal)
'			If Ktrl Or KeyBuf(FlJournaal) <> VB.Left(UittrekselsLijst.Text, 8) Then
'				Exit Do
'			Else
'				'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'				GoSub PrintInfo
'			End If
'		Loop 
'		Printer.Write(vbCrLf)
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'PrintInfo: 
'		RecordToVeld(FlJournaal)
'		If vSet(vBibTekst(FlJournaal, "#v019 #"), 7) = VB.Left(KeuzeInfo(0).Text, 7) Then
'			'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'			Return 
'		ElseIf fDatumText(vBibTekst(FlJournaal, "#v066 #")) <> Mid(UittrekselsLijst.Text, 12, 10) Then 
'			'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'			Return 
'		ElseIf RTrim(vBibTekst(FlJournaal, "#v019 #")) <> "" Then 
'			If vSet(vBibTekst(FlJournaal, "#v069 #"), 7) <> VB.Left(KeuzeInfo(0).Text, 7) Then
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 
'			End If
'		End If

'		VeldTXT(0) = ""
'		VeldTXT(1) = vBibTekst(FlJournaal, "#v019 #")
'		bGet(FlRekening, 0, vSet(VeldTXT(1), 7))
'		If Ktrl Then
'			VeldTXT(2) = "Reeds vernietigd..."
'		Else
'			RecordToVeld(FlRekening)
'			VeldTXT(2) = vBibTekst(FlRekening, "#v020 #")
'		End If
'		VeldTXT(3) = vBibTekst(FlJournaal, "#v067 #")
'		DCBedrag = Val(vBibTekst(FlJournaal, "#v068 #"))
'		Select Case DCBedrag
'			Case Is < 0
'				TotaalC = TotaalC + DCBedrag
'				VeldTXT(4) = ""
'				VeldTXT(5) = Dec(System.Math.Abs(DCBedrag), MaskerEURBH)
'			Case Else
'				TotaalD = TotaalD + DCBedrag
'				VeldTXT(4) = Dec(DCBedrag, MaskerEURBH)
'				VeldTXT(5) = ""
'		End Select
'		VeldTXT(6) = vBibTekst(FlJournaal, "#v033 #")
'		DeRekening.Value = VeldTXT(1)
'		HetBedrag = DCBedrag
'		'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'		GoSub DetailCumul
'		PrintVelden()
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'PrtHandler9: 
'		MsgBox("Kontroleer de printer.")
'		Printer.KillDoc()
'		Me.Close()
'		Exit Sub
'		Resume 

'DetailCumul: 
'StartPunt: 
'		bGet(FlDummy, 0, vSet(DeRekening.Value, 20))
'		If Ktrl Then
'			TLBRecord(FlDummy) = ""
'			vBib(FlDummy, DeRekening.Value, "v089")
'			vBib(FlDummy, "0", "v013")
'			vBib(FlDummy, "0", "v068")
'			bInsert(FlDummy, 0)
'			GoTo StartPunt
'		Else
'			RecordToVeld(FlDummy)
'			vBib(FlDummy, Str(Val(vBibTekst(FlDummy, "#v013 #")) + 1), "v013")
'			vBib(FlDummy, Str(Val(vBibTekst(FlDummy, "#v068 #")) + HetBedrag), "v068")
'			bUpdate(FlDummy, 0)
'		End If
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'	End Sub

'	Private Sub FinancieelBoek_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
'		Dim Printer As New Printer

'		If Not Toegankelijk(Me) Then
'			Me.Close()
'			Exit Sub
'		End If

'		Dim T As Short
'		Dim A As String
'		Dim TempbModus As Short

'		JournaalManueelVlag = False
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

'		TekstLijn(0).Text = fDatumText(VB.Left(BoekjaarVanTot.Value, 8)) & " - " & fDatumText(VB.Right(BoekjaarVanTot.Value, 8))
'		TekstLijn(1).Text = Rdt.Value
'		PlGrensVan.Value = VB.Left(BoekjaarVanTot.Value, 8)
'		PlGrensTot.Value = VB.Right(BoekjaarVanTot.Value, 8)

'		RecNummer(0) = 31
'		RekeningNummer(0) = String99(Lees, 41)

'		RecNummer(1) = 32
'		RekeningNummer(1) = String99(Lees, 42)

'		RecNummer(2) = 33
'		RekeningNummer(2) = String99(Lees, 43)

'		RecNummer(3) = 34
'		RekeningNummer(3) = String99(Lees, 44)

'		RecNummer(4) = 35
'		RekeningNummer(4) = String99(Lees, 45)

'		RecNummer(5) = 38
'		RekeningNummer(5) = String99(Lees, 39)

'		RecNummer(6) = 215
'		RekeningNummer(6) = String99(Lees, 211)

'		RecNummer(7) = 216
'		RekeningNummer(7) = String99(Lees, 212)

'		RecNummer(8) = 217
'		RekeningNummer(8) = String99(Lees, 213)

'		RecNummer(9) = 218
'		RekeningNummer(9) = String99(Lees, 214)

'		bClose(FlJournaal)
'		For T = 0 To 9
'			bGet(FlRekening, 0, RekeningNummer(T))
'			If Ktrl Then
'				A = RekeningNummer(T) & Chr(124) & "Niet aanwezig. Setup Boekjaar!"
'			Else
'				RecordToVeld(FlRekening)
'				A = RekeningNummer(T) & Chr(124) & RTrim(vBibTekst(FlRekening, "#v020 #"))
'			End If
'			bFirst(FlJournaal, 0)
'			bGetOrGreater(FlJournaal, 0, RekeningNummer(T) & PlGrensVan.Value)
'			If Ktrl Then
'			Else
'				If KeyBuf(FlJournaal) > RekeningNummer(T) & PlGrensTot.Value Then
'				Else
'					KeuzeInfo(0).Items.Add(A)
'				End If
'			End If
'		Next 
'		If KeuzeInfo(0).Items.Count Then KeuzeInfo(0).SelectedIndex = 0

'	End Sub


'	Private Sub InitVelden()

'		RapportVeld(0) = "Datum"
'		RapportTab(0) = 2

'		RapportVeld(1) = "Rek.Nm."
'		RapportTab(1) = 13

'		RapportVeld(2) = "Naam/Omschrijving"
'		RapportTab(2) = 21

'		RapportVeld(3) = "Betreft"
'		RapportTab(3) = 62

'		RapportVeld(4) = "       Debet"
'		RapportTab(4) = 93

'		RapportVeld(5) = "      Credit"
'		RapportTab(5) = 105

'		RapportVeld(6) = "dokument"
'		RapportTab(6) = 118

'		RapportTab(7) = 0

'	End Sub

'	'UPGRADE_WARNING: Event KeuzeInfo.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub KeuzeInfo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles KeuzeInfo.SelectedIndexChanged
'		Dim Index As Short = KeuzeInfo.GetIndex(eventSender)
'		Dim DummyText As String
'		Dim DCBedrag As Double

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'		Select Case Index
'			Case 0
'				UittrekselsLijst.Visible = False
'				UittrekselsLijst.Items.Clear()
'				bFirst(FlJournaal, 0)
'				bGetOrGreater(FlJournaal, 0, VB.Left(KeuzeInfo(0).Text, 7) & PlGrensVan.Value)
'				If Ktrl Or KeyBuf(FlJournaal) > VB.Left(KeuzeInfo(0).Text, 7) & PlGrensTot.Value Then
'					MsgBox("onlogische situatie")
'					GoTo EindeClick
'				Else
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub VoegErBij
'				End If

'				Do 
'					bNext(FlJournaal)
'					If Ktrl Or KeyBuf(FlJournaal) > VB.Left(KeuzeInfo(0).Text, 7) & PlGrensTot.Value Then
'						Exit Do
'					Else
'						'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'						GoSub VoegErBij
'					End If
'				Loop 
'				If UittrekselsLijst.Items.Count Then UittrekselsLijst.SelectedIndex = 0
'				UittrekselsLijst.Visible = True
'			Case Else
'		End Select

'EindeClick: 
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		On Error Resume Next
'		'UittrekselsLijst.SetFocus
'		Exit Sub

'VoegErBij: 
'		RecordToVeld(FlJournaal)
'		If Len(vBibTekst(FlJournaal, "#v038 #")) <> 8 Then
'			'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'			Return 
'			'DummyText = vBibTekst(FlJournaal, "#v033 #") + " " + Chr$(124) + " "
'		Else
'			DummyText = vBibTekst(FlJournaal, "#v038 #") & " " & Chr(124) & " "
'		End If
'		DummyText = DummyText & fDatumText(vBibTekst(FlJournaal, "#v066 #")) & " " & Chr(124) & " "
'		DummyText = DummyText & vSet(vBibTekst(FlJournaal, "#v067 #"), 30) & Chr(124)
'		DCBedrag = Val(vBibTekst(FlJournaal, "#v068 #"))
'		Select Case DCBedrag
'			Case Is < 0
'				DummyText = DummyText & Dec(0, MaskerEURBH) & Chr(124) & Dec(System.Math.Abs(DCBedrag), MaskerEURBH)
'			Case Else
'				DummyText = DummyText & Dec(System.Math.Abs(DCBedrag), MaskerEURBH) & Chr(124) & Dec(0, MaskerEURBH)
'		End Select
'		UittrekselsLijst.Items.Add(DummyText)
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'	End Sub

'	Private Sub PrintTitel()
'		Dim Printer As New Printer
'		Dim T As Short

'		On Error GoTo PrtHandler3

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

'	Private Sub PrintTotaal()
'		Dim Printer As New Printer
'		Dim T As Short

'		On Error GoTo PrtHandler4

'		For T = 0 To 6
'			VeldTXT(T) = ""
'		Next 
'		VeldTXT(3) = "Periodiek totaal :"
'		VeldTXT(4) = Dec(System.Math.Abs(TotaalD), MaskerEURBH)
'		VeldTXT(5) = Dec(System.Math.Abs(TotaalC), MaskerEURBH)

'		Printer.Print(vbCrLf & Lijntje.Value)

'		T = 0
'		Do While T < 8
'			Printer.Print(TAB(RapportTab(T)))
'			Printer.Write(VeldTXT(T))
'			If RapportTab(T + 1) < RapportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 
'		Exit Sub

'PrtHandler4: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub

'	Private Sub PrintVelden()
'		Dim Printer As New Printer
'		Dim T As Short

'		On Error GoTo PrtHandler2

'		T = 0
'		Do While RapportTab(T) <> 0
'			Printer.Print(TAB(RapportTab(T)))
'			Printer.Write(VeldTXT(T))
'			If RapportTab(T + 1) < RapportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 
'		If Printer.CurrentY >= Printer.Height - 1200 Then
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			PrintTitel()
'		End If
'		Exit Sub

'PrtHandler2: 
'		MsgBox("Kontroleer de printer.")
'		Printer.KillDoc()
'		Me.Close()
'		Resume 

'	End Sub

'	Private Sub TekstLijn_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Enter
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		TekstLijn(Index).SelectionLength = Len(TekstLijn(Index).Text)

'	End Sub

'	Private Sub TekstLijn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Leave
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)
'		Dim T As Short
'		Dim A As String

'		Select Case Index
'			Case 0
'				If DatumFout(VB.Right(TekstLijn(0).Text, 10)) Then
'					MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !")
'					TekstLijn(0).Text = BJPERDAT.PeriodeBoekjaar.Text
'					TekstLijn(0).Focus()
'					Exit Sub
'				ElseIf Len(TekstLijn(0).Text) <> 23 Then 
'					MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !")
'					TekstLijn(0).Text = BJPERDAT.PeriodeBoekjaar.Text
'					TekstLijn(0).Focus()
'					Exit Sub
'				Else
'					PlGrensVan.Value = Mid(TekstLijn(0).Text, 7, 4) & Mid(TekstLijn(0).Text, 4, 2) & Mid(TekstLijn(0).Text, 1, 2)
'					PlGrensTot.Value = Mid(TekstLijn(0).Text, 20, 4) & Mid(TekstLijn(0).Text, 17, 2) & Mid(TekstLijn(0).Text, 14, 2)
'					KeuzeInfo(0).Items.Clear()
'					For T = 0 To 9
'						bGet(FlRekening, 0, RekeningNummer(T))
'						If Ktrl Then
'							A = RekeningNummer(T) & Chr(124) & "Niet aanwezig. Setup Boekjaar!"
'						Else
'							RecordToVeld(FlRekening)
'							A = RekeningNummer(T) & Chr(124) & RTrim(vBibTekst(FlRekening, "#v020 #"))
'						End If
'						bFirst(FlJournaal, 0)
'						bGetOrGreater(FlJournaal, 0, RekeningNummer(T) & PlGrensVan.Value)
'						If Ktrl Then
'						Else
'							If KeyBuf(FlJournaal) > RekeningNummer(T) & PlGrensTot.Value Then
'							Else
'								KeuzeInfo(0).Items.Add(A)
'							End If
'						End If
'					Next 
'					If KeuzeInfo(0).Items.Count Then KeuzeInfo(0).SelectedIndex = 0
'				End If

'			Case 1
'				If DatumFout(TekstLijn(1).Text) Then
'					Beep()
'					TekstLijn(1).Text = Rdt.Value
'					TekstLijn(1).Focus()
'				End If
'			Case 3
'				TekstLijn(3).Text = VB6.Format(Val(TekstLijn(3).Text), "00000")
'		End Select

'	End Sub

'	Private Sub UittrekselsLijst_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles UittrekselsLijst.DoubleClick

'		DetailFinancieelStuk(Mid(UittrekselsLijst.Text, 1, 8))

'	End Sub

'	Private Sub UittrekselsLijst_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles UittrekselsLijst.Enter

'		SnelHelpPrint("[Enter] of dubbelklikken voor detail.", blLogging)

'	End Sub


'	Private Sub UittrekselsLijst_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles UittrekselsLijst.KeyDown
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000

'		If KeyCode = 13 Then DetailFinancieelStuk(Mid(UittrekselsLijst.Text, 1, 8))

'	End Sub
'End Class