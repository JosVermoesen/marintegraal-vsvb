Public Class frmBalansKlantLeverancier
    Private Sub frmBalansKlantLeverancier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Drukken_Click(sender As Object, e As EventArgs) Handles Drukken.Click

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Friend Class BalansKL
'	Inherits System.Windows.Forms.Form
'	'UPGRADE_NOTE: DefInt A-Z statement was removed. Variables were explicitly declared as type Short. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92AFD3E3-440D-4D49-A8BF-580D74A8C9F2"'

'	Dim psTekst(5) As String

'	Dim RapportSelektie As String
'	Dim RapportTitel As String
'	Dim RapportDefinitie As String
'	Dim LijstNaam As String
'	Dim VeldTXT(20) As String
'	Dim FlPartij As Short
'	Dim DocTeller As Short

'	Dim dttot As Double
'	Dim dtbtw As Double
'	Dim dvtot As Double
'	Dim dTrb As Double

'	Dim TotaalBTW As Double
'	Dim TotaalGOED As Double
'	Dim TotaalALBETAALD As Double
'	Dim TotaalNOGTEBETALEN As Double
'	Dim TotaalVOOR As Double
'	Dim TotaalNA As Double

'	Dim PlGrensVan As New VB6.FixedLengthString(8)
'	Dim PlGrensTot As New VB6.FixedLengthString(8)

'	Dim BHDetailTekst(3) As String
'	Dim AantalBovenPeriode As Short
'	Dim AantalOnderPeriode As Short
'	Dim TotaalDokBovenPeriode As Double
'	Dim TotaalDokOnderPeriode As Double

'	Private Sub Annuleren_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Annuleren.Click

'		Me.Close()

'	End Sub

'	'UPGRADE_WARNING: Event cbLijstPrinterHier.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub cbLijstPrinterHier_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbLijstPrinterHier.SelectedIndexChanged
'		Dim Printer As New Printer

'		LijstPrinterNr = cbLijstPrinterHier.SelectedIndex
'		Printer = Printers(LijstPrinterNr)

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


'	'UPGRADE_WARNING: Event ChkFinancieelDetail.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub ChkFinancieelDetail_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ChkFinancieelDetail.CheckStateChanged

'		If ChkFinancieelDetail.CheckState = 0 Then
'			'Selektie(1).Enabled = False
'			Selektie(1).CheckState = False
'			Selektie(5).Enabled = False
'			Selektie(5).CheckState = False
'		Else
'			'Selektie(1).Enabled = True
'			Selektie(5).Enabled = True
'		End If

'	End Sub

'	Private Sub CmdBewaar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdBewaar.Click

'		BeWaarTekst("dokumentenBalans", "KontroleVervaldag", CStr(Selektie(0).CheckState))
'		BeWaarTekst("dokumentenBalans", "GeenBetalingHogerBoekjaar", CStr(Selektie(1).CheckState))
'		BeWaarTekst("dokumentenBalans", "PeriodeBegrenzen", CStr(Selektie(2).CheckState))
'		BeWaarTekst("dokumentenBalans", "EnkelNietBetaaldedokumenten", CStr(Selektie(3).CheckState))
'		BeWaarTekst("dokumentenBalans", "-dokumenten-1994Uitsluiten", CStr(Selektie(4).CheckState))
'		BeWaarTekst("dokumentenBalans", "BetalingsKontrole", CStr(Selektie(5).CheckState))
'		BeWaarTekst("dokumentenBalans", "FinancieelDetailViaJournaal", CStr(ChkFinancieelDetail.CheckState))
'		BeWaarTekst("dokumentenBalans", "AfdrukInRooster", CStr(chkAfdrukInVenster.CheckState))

'	End Sub


'	Private Sub cmdEuroCheck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEuroCheck.Click

'		Dim dBTW As Decimal
'		Dim dTOT As Decimal

'		Dim Teller As Short

'		Dim TotaalAantalBEF As Integer
'		Dim TotaalAantalEUR As Integer
'		Dim TotaalGewijzigd As Integer

'		Exit Sub

'		Msg = "Hierna kan U de totaalbedragen pér dokument terug"
'		Msg = Msg & vbCr & "hertotaliseren in BEF voor vorige boekjaren"
'		Msg = Msg & vbCr & "en vervolgens in EUR beschikbaar maken."
'		Msg = Msg & vbCr & vbCr
'		Msg = Msg & "Mag de herrekening gestart worden."
'		KtrlBox = MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
'		If KtrlBox = MsgBoxResult.No Then
'			Exit Sub
'		End If
'		bFirst(Fldokument, 1)
'		If Ktrl Then
'			MsgBox("stop")
'			Exit Sub
'		Else
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'			Me.Enabled = False
'			Do 
'				'UPGRADE_ISSUE: DoEvents does not return a value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8D115264-E27F-4472-A684-865A00B5E826"'
'				XDoEvents = System.Windows.Forms.Application.DoEvents()
'				RecordToVeld(Fldokument)
'				If DatumKtrl(vBibTekst(Fldokument, "#v035 #"), SleutelBoekjaar) = False Then
'					TotaalAantalBEF = TotaalAantalBEF + 1
'					Select Case VB.Left(vBibTekst(Fldokument, "#v034 #"), 1)
'						Case "K"
'							Select Case VB.Left(vBibTekst(Fldokument, "#v033 #"), 1)
'								Case "V"
'									dBTW = Val(vBibTekst(Fldokument, "#v064 #"))
'									dTOT = 0
'									For Teller = 55 To 63
'										dTOT = dTOT + Val(vBibTekst(Fldokument, "#v" & VB6.Format(Teller, "000") & " #"))
'									Next 
'									dTOT = dTOT + Val(vBibTekst(Fldokument, "#v089 #")) + dBTW
'								Case "Q"
'									dTOT = Val(vBibTekst(Fldokument, "#B010 #")) - Val(vBibTekst(Fldokument, "#B090 #")) - Val(vBibTekst(Fldokument, "#v065 #"))
'									dBTW = 0
'							End Select
'						Case "L"
'							dBTW = Val(vBibTekst(Fldokument, "#v045 #")) - Val(vBibTekst(Fldokument, "#v044 #")) - Val(vBibTekst(Fldokument, "#v043 #"))
'							If VB.Left(vBibTekst(Fldokument, "#v035 #"), 4) > "1992" Then
'								dBTW = dBTW - Val(vBibTekst(Fldokument, "#v042 #"))
'							End If
'							dTOT = 0
'							For Teller = 46 To 49
'								dTOT = dTOT + Val(vBibTekst(Fldokument, "#v" & VB6.Format(Teller, "000") & " #"))
'							Next 
'							dTOT = dTOT + dBTW
'					End Select
'					If System.Math.Round(dTOT / Euro, 2) <> Val(vBibTekst(Fldokument, "#v249 #")) Then
'						MsgBox(vBibTekst(Fldokument, "#v034 #") & ": " & System.Math.Round(dTOT / Euro, 2) & " <> " & Val(vBibTekst(Fldokument, "#v249 #")) & vbCr & " en zogezegd reeds betaald : " & Val(vBibTekst(Fldokument, "#v037 #")) & vbCr & vbCr & "Wordt bijgewerkt...", MsgBoxStyle.Information, "Bijwerking voor:")
'						If Val(vBibTekst(Fldokument, "#v249 #")) = Val(vBibTekst(Fldokument, "#v037 #")) Then
'							vBib(Fldokument, Str(System.Math.Round(dTOT / Euro, 2)), "v249")
'							vBib(Fldokument, Str(System.Math.Round(dTOT / Euro, 2)), "v037")
'						Else
'							vBib(Fldokument, Str(System.Math.Round(dTOT / Euro, 2)), "v249")
'							If Val(vBibTekst(Fldokument, "#v037 #")) = 0 Then
'							Else
'								MsgBox("Totaal betaald dient U manueel nog te verbeteren.  Staat nu op " & Val(vBibTekst(Fldokument, "#v037 #")), MsgBoxStyle.Exclamation, vBibTekst(Fldokument, "#v034 #"))
'							End If
'						End If
'						bUpdate(Fldokument, 1)
'						TotaalGewijzigd = TotaalGewijzigd + 1
'					ElseIf dTOT = Val(vBibTekst(Fldokument, "#v037 #")) Then 
'						'100 % zeker totaal BEF staat nog als betaald
'						SnelHelpPrint(vBibTekst(Fldokument, "#v033 #") & " was al volledig betaald in BEF voor " & Val(vBibTekst(Fldokument, "#v037 #")) & " Wordt nu als betaald geplaatst € " & System.Math.Round(dTOT / Euro, 2), blLogging)
'						vBib(Fldokument, Str(System.Math.Round(dTOT / Euro, 2)), "v037")
'						bUpdate(Fldokument, 1)
'					ElseIf Val(vBibTekst(Fldokument, "#v249 #")) = Val(vBibTekst(Fldokument, "#v037 #")) Then 
'						'100 % zeker totaal en betaald in EUR reeds aangeduid
'					ElseIf Val(vBibTekst(Fldokument, "#v037 #")) = 0 Then 
'						'nog geen betalingen, dus ok
'					ElseIf InStr(vBibTekst(Fldokument, "#v037 #"), ".") = 0 Then 
'						'een totaal bedrag betaald zonder aanwezigheid van decimaal punt
'						Msg = vBibTekst(Fldokument, "#v033 #") & " met totaal € " & Val(vBibTekst(Fldokument, "#v249 #")) & vbCr
'						Msg = Msg & "heeft een bedrag als betaling : " & Val(vBibTekst(Fldokument, "#v037 #")) & vbCr & vbCr
'						Msg = Msg & "mag omgewerkt worden als betaald € " & System.Math.Round(Val(vBibTekst(Fldokument, "#v037 #")) / Euro, 2) & vbCr & vbCr & vbCr
'						Msg = Msg & "AANDACHT: ENKEL WIJZIGEN INDIEN U 100 % ZEKER BENT !!!" & vbCr & vbCr
'						Msg = Msg & "Ja om te wijzigen, Nee om over te slaan"
'						KtrlBox = MsgBoxResult.Cancel
'						Do While KtrlBox = MsgBoxResult.Cancel
'							KtrlBox = MsgBox(Msg, MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton3 + MsgBoxStyle.Question)
'						Loop 
'						If KtrlBox = MsgBoxResult.Yes Then
'							vBib(Fldokument, Str(System.Math.Round(Val(vBibTekst(Fldokument, "#v037 #")) / Euro, 2)), "v037")
'							bUpdate(Fldokument, 1)
'						End If
'					Else
'						SnelHelpPrint("Vermoedelijk alles ok voor " & vBibTekst(Fldokument, "#v033 #"), blLogging)
'					End If
'				Else
'					TotaalAantalEUR = TotaalAantalEUR + 1
'				End If
'				bNext(Fldokument)
'				If Ktrl Then
'					Exit Do
'				End If
'			Loop 
'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal
'			Me.Enabled = True
'			Msg = "Totaal dokumenten in BEF " & TotaalAantalBEF
'			Msg = Msg & vbCr
'			Msg = Msg & "Totaal dokumenten in EUR " & TotaalAantalEUR
'			Msg = Msg & vbCr
'			Msg = Msg & "Totaal aantal gewijzigd " & TotaalGewijzigd
'			MsgBox(Msg, MsgBoxStyle.Information)
'		End If

'	End Sub

'	Private Sub CmdStandaard_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStandaard.Click

'		Selektie(0).CheckState = System.Windows.Forms.CheckState.Unchecked
'		PlGrensVan.Value = VB.Left(BoekjaarVanTot.Value, 8)
'		PlGrensTot.Value = VB.Right(BoekjaarVanTot.Value, 8)
'		TekstLijn(4).Text = fDatumText(VB.Left(BoekjaarVanTot.Value, 8)) & " - " & fDatumText(VB.Right(BoekjaarVanTot.Value, 8))
'		Selektie(2).CheckState = System.Windows.Forms.CheckState.Checked

'		Selektie(1).CheckState = System.Windows.Forms.CheckState.Checked
'		Selektie(3).CheckState = System.Windows.Forms.CheckState.Checked
'		ChkFinancieelDetail.CheckState = System.Windows.Forms.CheckState.Checked
'		Selektie(5).CheckState = System.Windows.Forms.CheckState.Checked
'		TekstLijn(0).Text = "Boekhoudcontrole " & TekstLijn(4).Text

'	End Sub

'	Private Sub CmdStandaardBetaling_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStandaardBetaling.Click

'		Selektie(0).CheckState = System.Windows.Forms.CheckState.Checked
'		Selektie(2).CheckState = System.Windows.Forms.CheckState.Unchecked

'		Selektie(1).CheckState = System.Windows.Forms.CheckState.Unchecked
'		Selektie(3).CheckState = System.Windows.Forms.CheckState.Checked
'		ChkFinancieelDetail.CheckState = System.Windows.Forms.CheckState.Unchecked
'		TekstLijn(1).Text = Rdt.Value
'		TekstLijn(0).Text = "Betalingscontrole"

'	End Sub

'	Private Sub Drukken_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drukken.Click
'		Dim Printer As New Printer
'		Dim BeginSleutel As New VB6.FixedLengthString(13)
'		Dim EindSleutel As New VB6.FixedLengthString(13)
'		Dim rdtemp As New VB6.FixedLengthString(8)
'		Dim syMasker As String
'		Dim KopBuf As String
'		Dim XX As Short
'		Dim Tel As Short
'		Dim Teller As Short
'		Dim ReedsMetBetalingen As Boolean
'		Dim TDS As String

'		Dim BetaaldBedrag As Double
'		Dim dBTW As Double
'		Dim dTOT As Double
'		Dim dnt As Double
'		Dim dTnt As Double
'		Dim drb As Double
'		Dim drbet As Double

'		Dim LengteSleutel As Short
'		Dim sleutelIndex As Short
'		Dim xOmgeving As Short
'		Dim MerkOp As Boolean

'		TotaalBTW = 0
'		TotaalGOED = 0
'		TotaalALBETAALD = 0
'		TotaalNOGTEBETALEN = 0
'		TotaalVOOR = 0
'		TotaalNA = 0
'		DocTeller = 0

'		dttot = 0
'		dtbtw = 0
'		dvtot = 0
'		dTrb = 0
'		dTnt = 0

'		BetalingenVoorNa(2).Items.Clear()
'		BetalingenVoorNa(3).Items.Clear()

'		Select Case FlPartij
'			Case FlLeverancier
'				BeginSleutel.Value = "L" & TekstLijn(2).Text
'				EindSleutel.Value = "L" & TekstLijn(3).Text
'			Case FlKlant
'				BeginSleutel.Value = "K" & TekstLijn(2).Text
'				EindSleutel.Value = "K" & TekstLijn(3).Text
'		End Select

'		rdtemp.Value = DatumKey(TekstLijn(1).Text)

'		psTekst(2) = Me.Text & " " & Mid(Mim.Text, InStr(Mim.Text, "["))
'		psTekst(0) = TekstLijn(1).Text
'		psTekst(3) = TekstLijn(0).Text
'		InitVelden()

'		TDS = "Geen journalen voor : " & vbCrLf
'		bGetOrGreater(Fldokument, 1, BeginSleutel.Value)
'		If Ktrl Or UCase(vSet(KeyBuf(Fldokument), 13)) > UCase(EindSleutel.Value) Then
'			Beep()
'			Exit Sub
'		ElseIf VB.Left(KeyBuf(Fldokument), 1) <> VB.Left(BeginSleutel.Value, 1) Then 
'			Beep()
'			Exit Sub
'		Else
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'			Me.Enabled = False
'			PaginaTeller = 0
'			If chkAfdrukInVenster.CheckState = 0 Then
'				If Printer.Width > 12000 Then
'					Printer.FontSize = 10
'					Printer.FontName = "Courier New"
'					Printer.Print(" ")
'					Printer.FontSize = 10
'				Else
'					On Error Resume Next
'					Printer.FontSize = 7.2
'					Printer.FontName = "Courier New"
'					Printer.Print(" ")
'					Printer.FontSize = 7.2
'					Printer.FontBold = True
'				End If
'			End If
'			PrintTitel()
'		End If

'		MerkOp = False
'		If PlGrensVan.Value = VB.Left(BoekjaarVanTot.Value, 8) And PlGrensTot.Value = VB.Right(BoekjaarVanTot.Value, 8) Then
'			If VB.Left(PlGrensVan.Value, 4) = VB.Left(PlGrensTot.Value, 4) Then
'				MerkOp = True
'			End If
'		End If


'		Do 
'			'UPGRADE_ISSUE: DoEvents does not return a value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8D115264-E27F-4472-A684-865A00B5E826"'
'			XDoEvents = System.Windows.Forms.Application.DoEvents()
'			RecordToVeld(Fldokument)
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub KontroleVoorwaarden
'			bNext(Fldokument)
'			If Ktrl Or UCase(vSet(KeyBuf(Fldokument), 13)) > UCase(EindSleutel.Value) Then
'				Exit Do
'			End If
'		Loop 
'		TotaalNOGTEBETALEN = TotaalGOED - TotaalALBETAALD
'		EindTotaal()
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		Me.Enabled = True
'		If chkAfdrukInVenster.CheckState Then
'		Else
'			Printer.NewPage()
'			Printer.EndDoc()
'		End If
'		If Len(TDS) = 24 Then
'		Else
'			TDS = TDS & vbCrLf
'			TDS = TDS & "De betalingen voor bovenvermelde dokumenten kunnen dus niet" & vbCrLf
'			TDS = TDS & "in detail weergegeven worden.  Enkel het algemeen totaal" & vbCrLf
'			TDS = TDS & "van het dokument en laatste financieel uittreksel..."
'			MsgBox(TDS)
'			Msg = "Mededeling eveneens op papier ?"
'			KtrlBox = MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
'			If KtrlBox = MsgBoxResult.Yes Then
'				Printer.Print(TDS)
'				Printer.NewPage()
'				Printer.EndDoc()
'			End If
'		End If
'		Me.Activate()
'		If BetalingenVoorNa(0).Items.Count + BetalingenVoorNa(1).Items.Count + BetalingenVoorNa(2).Items.Count + BetalingenVoorNa(3).Items.Count <> 0 Then
'			Msg = "Betalingsdetail dokumenten lagere/hogere boekjaren..." & vbCrLf
'			Msg = Msg & "Op papier ?"
'			KtrlBox = MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1)
'			If KtrlBox = MsgBoxResult.Yes Then
'				BHDetailTekst(0) = "Detail betalingen dokumenten van lagere boekjaren in dit boekjaar" & vbCrLf & vbCrLf
'				BHDetailTekst(1) = "Detail betalingen dokumenten van hogere boekjaren in dit boekjaar" & vbCrLf & vbCrLf
'				BHDetailTekst(2) = "Detail betalingen dokumenten van dit boekjaar in lagere boekjaren" & vbCrLf & vbCrLf
'				BHDetailTekst(3) = "Detail betalingen dokumenten van dit boekjaar in hogere boekjaren" & vbCrLf & vbCrLf
'				For Tel = 0 To 3
'					If BetalingenVoorNa(Tel).Items.Count <> 0 Then
'						Printer.Print(BHDetailTekst(Tel))
'						For Teller = 0 To BetalingenVoorNa(Tel).Items.Count - 1
'							Printer.Write(VB6.GetItemString(BetalingenVoorNa(Tel), Teller) & vbCrLf)
'						Next 
'						Printer.Write(vbCrLf & vbCrLf)
'						If Tel = 0 Then
'							Printer.Print("Totaal financiële bewegingen: " & VB6.Format(TotaalDokOnderPeriode, Masker2002.Value))
'						ElseIf Tel = 1 Then 
'							Printer.Print("Totaal financiële bewegingen: " & VB6.Format(TotaalDokBovenPeriode, Masker2002.Value))
'						ElseIf Tel = 2 Then 
'							Printer.Print("Totaal financiële bewegingen: " & VB6.Format(TotaalVOOR, Masker2002.Value))
'						ElseIf Tel = 3 Then 
'							Printer.Print("Totaal financiële bewegingen: " & VB6.Format(TotaalNA, Masker2002.Value))
'						End If
'						Printer.NewPage()
'					End If
'				Next 
'				Printer.EndDoc()
'			End If
'		End If
'		SnelHelpPrint("Klaar", blLogging)
'		Me.Close()
'		Exit Sub

'KontroleVoorwaarden: 
'		If Selektie(0).CheckState = 1 Then
'			'vervaldag
'			If vBibTekst(Fldokument, "#v036 #") > rdtemp.Value Then
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 
'			End If
'		End If

'		If Selektie(4).CheckState = 1 Then
'			'-1994 dokumenten uitsluiten
'			If VB.Left(vBibTekst(Fldokument, "#v035 #"), 4) < "1994" Then
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 
'			End If
'		End If

'		If Selektie(2).CheckState = 1 Then
'			'dokumenten enkel van deze periode
'			If MerkOp = True Then
'				If VB.Left(vBibTekst(Fldokument, "#v035 #"), 4) <> Mid(vBibTekst(Fldokument, "#v033 #"), 3, 4) Then
'					MsgBox("Opgelet, noteer/controleer a.u.b.:" & vbCrLf & "Datum document: " & vBibTekst(Fldokument, "#v035 #") & " onlogisch voor document nummer " & vBibTekst(Fldokument, "#v033 #"), MsgBoxStyle.Exclamation)
'				End If
'			End If
'			If vBibTekst(Fldokument, "#v035 #") < PlGrensVan.Value Or vBibTekst(Fldokument, "#v035 #") > PlGrensTot.Value Then
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 
'			End If
'		End If

'		If Selektie(5).CheckState = 1 And FlPartij = FlLeverancier Then
'			bGet(FlJournaal, 1, vBibTekst(Fldokument, "#v033 #"))
'			If Ktrl Then
'				'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'				Return 
'			Else
'				RecordToVeld(FlJournaal)
'				If vBibTekst(FlJournaal, "#v035 #") < PlGrensVan.Value Or vBibTekst(Fldokument, "#v035 #") > PlGrensTot.Value Then
'					MsgBox("dokumentdatum (" & vBibTekst(Fldokument, "#v035 #") & ") <> boekdatum journaal (" & vBibTekst(FlJournaal, "#v035 #") & ")" & vbCr & vbCr & "Wordt uit boekhoudcontrole geweerd.  Kontroleer eventueel manueel", MsgBoxStyle.Information, vBibTekst(Fldokument, "#v033 #"))
'					'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'					Return 
'				End If
'			End If
'		End If

'		dTOT = Val(vBibTekst(Fldokument, "#v249 #"))
'		If XisEuroWisBEF = True Then
'			dTOT = System.Math.Round(dTOT * Euro)
'		End If

'		syMasker = MaskerEUR
'		If Mid(vBibTekst(Fldokument, "#v033 #"), 2, 1) = "1" Then
'			dTOT = -dTOT
'			drb = -Val(vBibTekst(Fldokument, "#v037 #"))
'			If XisEuroWisBEF = True Then
'				drb = System.Math.Round(-Val(vBibTekst(Fldokument, "#v037 #")) * Euro)
'			Else
'				drb = -Val(vBibTekst(Fldokument, "#v037 #"))
'			End If
'		Else
'			If XisEuroWisBEF = True Then
'				drb = System.Math.Round(Val(vBibTekst(Fldokument, "#v037 #")) * Euro)
'			Else
'				drb = Val(vBibTekst(Fldokument, "#v037 #"))
'			End If
'		End If

'		VeldTXT(1) = vBibTekst(Fldokument, "#v033 #")
'		VeldTXT(2) = fDatumText(vBibTekst(Fldokument, "#v035 #"))
'		VeldTXT(3) = vBibTekst(Fldokument, "#vs03 #")
'		VeldTXT(4) = Dec(dTOT / Val(vBibTekst(Fldokument, "#v040 #")), syMasker)
'		VeldTXT(5) = "" 'Dec$((dBtw), Masker2002)
'		VeldTXT(9) = fDatumText(vBibTekst(Fldokument, "#v036 #"))

'		If Trim(vBibTekst(Fldokument, "#v034 #")) <> KopBuf Then
'			dTnt = 0
'			bGet(aIndex, 0, vSet(Mid(vBibTekst(Fldokument, "#v034 #"), 2, 12), 12))
'			KopBuf = Trim(vBibTekst(Fldokument, "#v034 #"))
'			VeldTXT(0) = RTrim(Mid(vBibTekst(Fldokument, "#v034 #"), 2, 12))
'			If Ktrl Then
'				VeldTXT(0) = VeldTXT(0) & " * niet meer aanwezig *"
'			Else
'				RecordToVeld(aIndex)
'				VeldTXT(0) = VB.Left(VeldTXT(0) & " " & RTrim(vBibTekst(aIndex, "#A100 #")) & " " & RTrim(vBibTekst(aIndex, "#A101 #")), 27)
'			End If
'			SnelHelpPrint(VeldTXT(0), blLogging)
'		End If

'		bGet(FlJournaal, 1, vBibTekst(Fldokument, "#v033 #"))
'		If Ktrl Or ChkFinancieelDetail.CheckState = 0 Then
'			'Er zijn geen journalen voor dit dokument !
'			'Verwittigen via afdruk laatste blz.
'			If ChkFinancieelDetail.CheckState Then
'				TDS = TDS & vBibTekst(Fldokument, "#v033 #") & "  ...  " & vBibTekst(FlPartij, "#A110 #") & " " & vBibTekst(FlPartij, "#A100 #") & vbCrLf
'			End If
'			If dTOT = drb And Selektie(3).CheckState = 1 Then
'			Else
'				If InStr(VeldTXT(0), Mid(vBibTekst(Fldokument, "#v034 #"), 2)) = 1 Then
'					If chkAfdrukInVenster.CheckState = 0 Then
'						Printer.Write(vbCrLf)
'						If Printer.CurrentY >= Printer.Height - 1200 Then
'							On Error Resume Next
'							Printer.NewPage()
'							Printer.FontSize = Printer.FontSize
'							Printer.Print(" ")
'							Printer.FontSize = Printer.FontSize
'							PrintTitel()
'						End If
'					End If
'				End If

'				dTnt = dTnt + dTOT - drb 'Algemeen Totaal Cumul te betalen
'				VeldTXT(6) = Dec(drb, Masker2002.Value)
'				VeldTXT(7) = vBibTekst(Fldokument, "#v038 #")
'				VeldTXT(8) = "" 'Dec$((dTot - drb), Masker2002)
'				VeldTXT(10) = Dec(dTnt, Masker2002.Value)

'				'TotaalBTW = TotaalBTW + dBtw
'				TotaalGOED = TotaalGOED + dTOT '- dBtw
'				TotaalALBETAALD = TotaalALBETAALD + drb
'				PrintVelden()
'				VeldTXT(0) = ""
'			End If
'		Else
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub AfdrukDetailReedsBetaald
'		End If
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'AfdrukDetailReedsBetaald: 
'		'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'		GoSub TotaalBETAALD
'		If System.Math.Round(dTOT, 2) = System.Math.Round(drb, 2) And Selektie(3).CheckState = 1 Then
'			'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'			Return 
'		Else
'			bGet(FlJournaal, 1, vBibTekst(Fldokument, "#v033 #"))
'		End If
'		dTnt = dTnt + dTOT
'		ReedsMetBetalingen = False

'		drb = 0
'		Do 
'			RecordToVeld(FlJournaal)
'			If Trim(vBibTekst(FlJournaal, "#v038 #")) <> "" Then
'				If VB.Left(vBibTekst(FlJournaal, "#v019 #"), 1) <> "4" Then
'				Else
'					ReedsMetBetalingen = True
'					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'					GoSub BetalingErBij
'				End If
'			End If
'			bNext(FlJournaal)
'			If Ktrl Or Trim(KeyBuf(FlJournaal)) <> Trim(vBibTekst(Fldokument, "#v033 #")) Then
'				Exit Do
'			End If
'		Loop 
'		If Not ReedsMetBetalingen Then
'			drb = 0
'			vBib(FlJournaal, "0", "v068")
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub BetalingErBij
'		End If
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'BetalingErBij: 
'		BetaaldBedrag = Val(vBibTekst(FlJournaal, "#v068 #"))
'		If FlPartij = FlKlant Then
'			BetaaldBedrag = -BetaaldBedrag
'		End If
'		If Selektie(1).CheckState = 1 Then
'			'Betalingen buiten periode uitsluiten
'			If vBibTekst(FlJournaal, "#v066 #") < PlGrensVan.Value Then
'				TotaalVOOR = TotaalVOOR + BetaaldBedrag
'				Msg = vSet(Mid(vBibTekst(Fldokument, "#v034 #"), 2), 12) & " "
'				Msg = Msg & vSet(vBibTekst(FlJournaal, "#v067 #"), 20) & " "
'				Msg = Msg & fDatumText(vBibTekst(Fldokument, "#v035 #")) & " "
'				Msg = Msg & vBibTekst(Fldokument, "#v033 #") & " "
'				Msg = Msg & Dec(BetaaldBedrag, Masker2002.Value) & " "
'				Msg = Msg & vSet(vBibTekst(FlJournaal, "#v019 #"), 7) & " "
'				Msg = Msg & fDatumText(vBibTekst(FlJournaal, "#v066 #")) & " "
'				Msg = Msg & vBibTekst(FlJournaal, "#v038 #") & " "
'				Msg = Msg & vBibTekst(FlJournaal, "#v069 #")
'				BetalingenVoorNa(2).Items.Add(Msg)
'				BetaaldBedrag = 0
'			ElseIf vBibTekst(FlJournaal, "#v066 #") > PlGrensTot.Value Then 
'				TotaalNA = TotaalNA + BetaaldBedrag
'				Msg = vSet(Mid(vBibTekst(Fldokument, "#v034 #"), 2), 12) & " "
'				Msg = Msg & vSet(vBibTekst(FlJournaal, "#v067 #"), 20) & " "
'				Msg = Msg & fDatumText(vBibTekst(Fldokument, "#v035 #")) & " "
'				Msg = Msg & vBibTekst(Fldokument, "#v033 #") & " "
'				Msg = Msg & Dec(BetaaldBedrag, Masker2002.Value) & " "
'				Msg = Msg & vSet(vBibTekst(FlJournaal, "#v019 #"), 7) & " "
'				Msg = Msg & fDatumText(vBibTekst(FlJournaal, "#v066 #")) & " "
'				Msg = Msg & vBibTekst(FlJournaal, "#v038 #") & " "
'				Msg = Msg & vBibTekst(FlJournaal, "#v069 #")
'				BetalingenVoorNa(3).Items.Add(Msg)
'				BetaaldBedrag = 0
'			End If
'		End If

'		If InStr(VeldTXT(0), Mid(vBibTekst(Fldokument, "#v034 #"), 2)) = 1 Then
'			dTnt = dTOT : drb = 0
'			If chkAfdrukInVenster.CheckState = 0 Then
'				Printer.Write(vbCrLf)
'				If Printer.CurrentY >= Printer.Height - 1200 Then
'					On Error Resume Next
'					Printer.NewPage()
'					Printer.FontSize = Printer.FontSize
'					Printer.Print(" ")
'					Printer.FontSize = Printer.FontSize
'					PrintTitel()
'				End If
'			End If
'		End If

'		drb = drb + BetaaldBedrag
'		dTnt = dTnt - BetaaldBedrag
'		dTrb = dTrb + drb 'Totaal al betaald
'		dttot = dttot + dTOT - dBTW 'Totaal excl. btw
'		dtbtw = dtbtw + dBTW 'Totaal btw aftrekbaar

'		VeldTXT(6) = Dec(BetaaldBedrag, Masker2002.Value)
'		VeldTXT(7) = vBibTekst(FlJournaal, "#v038 #")
'		VeldTXT(8) = Dec(dTOT - drb, Masker2002.Value)
'		VeldTXT(10) = Dec(dTnt, Masker2002.Value)

'		If Val(VeldTXT(4)) + Val(VeldTXT(5)) <> 0 Then
'			'TotaalBTW = TotaalBTW + dBtw
'			TotaalGOED = TotaalGOED + dTOT '- dBtw
'			TotaalNOGTEBETALEN = TotaalNOGTEBETALEN + dTOT
'		End If
'		TotaalALBETAALD = TotaalALBETAALD + BetaaldBedrag
'		PrintVelden()

'		VeldTXT(0) = ""
'		VeldTXT(1) = ""
'		VeldTXT(2) = ""
'		VeldTXT(3) = ""
'		VeldTXT(4) = ""
'		VeldTXT(5) = ""
'		VeldTXT(9) = ""
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'TotaalBETAALD: 
'		drb = 0
'		bGet(FlJournaal, 1, vBibTekst(Fldokument, "#v033 #"))
'		If Ktrl Then
'			MsgBox("onlogische situatie")
'		Else
'			Do 
'				RecordToVeld(FlJournaal)
'				If Trim(vBibTekst(FlJournaal, "#v038 #")) <> "" Then
'					If VB.Left(vBibTekst(FlJournaal, "#v019 #"), 1) <> "4" Then
'					Else
'						BetaaldBedrag = Val(vBibTekst(FlJournaal, "#v068 #"))
'						If FlPartij = FlKlant Then
'							BetaaldBedrag = -BetaaldBedrag
'						End If
'						If XisEuroWisBEF = True Then
'							If vBibTekst(FlJournaal, "#v066 #") > VB.Right(BoekjaarVanTot.Value, 8) Then
'								BetaaldBedrag = System.Math.Round(BetaaldBedrag * Euro)
'							End If
'						End If
'						If Selektie(1).CheckState = 1 Then
'							'Betalingen buiten periode uitsluiten
'							If vBibTekst(FlJournaal, "#v066 #") < PlGrensVan.Value Or vBibTekst(FlJournaal, "#v066 #") > PlGrensTot.Value Then
'							Else
'								drb = drb + BetaaldBedrag
'							End If
'						Else
'							drb = drb + BetaaldBedrag
'						End If
'					End If
'					'ElseIf FlPartij = FlKlant Then
'					'    If vBibTekst(FlJournaal, "#v033 #") = "Q0800286" Then
'					'        Stop
'					'    End If
'				End If
'				bNext(FlJournaal)
'				If Ktrl Or Trim(KeyBuf(FlJournaal)) <> Trim(vBibTekst(Fldokument, "#v033 #")) Then
'					Exit Do
'				End If
'			Loop 
'		End If
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'PrtHandler: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'	End Sub

'	Private Sub EindTotaal()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim aa As String

'JumpEindTotaal: 
'		For T = 0 To 10
'			VeldTXT(T) = ""
'		Next 
'		VeldTXT(0) = "Totalen :"
'		VeldTXT(4) = Dec(TotaalGOED, Masker2002.Value)
'		VeldTXT(5) = "" 'Dec$((TotaalBTW), Masker2002)
'		VeldTXT(6) = Dec(TotaalALBETAALD, Masker2002.Value)
'		VeldTXT(10) = Dec(TotaalNOGTEBETALEN, Masker2002.Value)
'		If chkAfdrukInVenster.CheckState = 0 Then Printer.Write(vbCrLf & Lijntje.Value & vbCrLf)

'		T = 0
'		aa = ""
'		Do While T < 12
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
'		If chkAfdrukInVenster.CheckState Then mdiXlog.X.AddItem(aa, mdiXlog.X.Rows - 1)

'		Dim GroepSelektie As String
'		Dim TotaalBedragGroep As Double
'		Dim AantalInGroep As Short
'		Dim BedragZonderdokument As Double
'		Dim AantalZonderdokument As Short
'		Dim BetaaldBedragBB As Double
'		Dim GroepRekening4 As String

'		If Selektie(5).CheckState = 1 Then
'			If chkAfdrukInVenster.CheckState Then
'			Else
'				If Printer.CurrentY >= Printer.Height - 1500 Then
'					On Error Resume Next
'					Printer.NewPage()
'					Printer.FontSize = Printer.FontSize
'					Printer.Print(" ")
'					Printer.FontSize = Printer.FontSize
'					PrintTitel()
'					GoTo JumpEindTotaal
'				End If
'			End If

'			If TotaalVOOR <> 0 Then
'				For T = 0 To 10
'					VeldTXT(T) = ""
'				Next 
'				VeldTXT(0) = "Dok. reeds betaald voor :"
'				VeldTXT(2) = VB.Left(TekstLijn(4).Text, 10)
'				VeldTXT(6) = Dec(TotaalVOOR, Masker2002.Value)
'				T = 0
'				aa = ""
'				Do While T < 12
'					If chkAfdrukInVenster.CheckState Then
'						aa = aa & VeldTXT(T) & vbTab
'					Else
'						Printer.Print(TAB(RapportTab(T)))
'						Printer.Write(VeldTXT(T))
'					End If
'					If RapportTab(T + 1) < RapportTab(T) Then
'						If chkAfdrukInVenster.CheckState Then
'						Else
'							Printer.Write(vbCrLf)
'						End If
'					End If
'					T = T + 1
'				Loop 
'				If chkAfdrukInVenster.CheckState Then mdiXlog.X.AddItem(aa, mdiXlog.X.Rows - 1)
'			End If
'			If TotaalNA <> 0 Then
'				For T = 0 To 10
'					VeldTXT(T) = ""
'				Next 
'				VeldTXT(0) = "Dok. reeds betaald na :"
'				VeldTXT(2) = VB.Right(TekstLijn(4).Text, 10)
'				VeldTXT(6) = Dec(TotaalNA, Masker2002.Value)
'				T = 0
'				aa = ""
'				Do While T < 12
'					If chkAfdrukInVenster.CheckState Then
'						aa = aa & VeldTXT(T) & vbTab
'					Else
'						Printer.Print(TAB(RapportTab(T)))
'						Printer.Write(VeldTXT(T))
'					End If
'					If RapportTab(T + 1) < RapportTab(T) Then
'						If chkAfdrukInVenster.CheckState Then
'						Else
'							Printer.Write(vbCrLf)
'						End If
'					End If
'					T = T + 1
'				Loop 
'				If chkAfdrukInVenster.CheckState Then mdiXlog.X.AddItem(aa, mdiXlog.X.Rows - 1)
'			End If

'			If chkAfdrukInVenster.CheckState = 0 Then Printer.Write(vbCrLf & Lijntje.Value & vbCrLf)
'			TotaalBedragGroep = 0
'			AantalInGroep = 0
'			BedragZonderdokument = 0
'			AantalZonderdokument = 0
'			AantalBovenPeriode = 0
'			AantalOnderPeriode = 0
'			TotaalDokBovenPeriode = 0
'			TotaalDokOnderPeriode = 0

'			GroepSelektie = String99(Lees, FlPartij + 296)
'			If Trim(GroepSelektie) = "" Then
'				GroepSelektie = VB.Left(String99(Lees, FlPartij + 8), 4) & "999"
'			End If
'			If Len(GroepSelektie) > 7 Then
'				MsgBox("Groep bestaat uit meer dan 7 tekens: " & GroepSelektie, MsgBoxStyle.Exclamation)
'				GroepSelektie = VB.Left(GroepSelektie, 7)
'			ElseIf Len(GroepSelektie) <> 7 Then 
'				GroepSelektie = GroepSelektie & New String("9", 7 - Len(GroepSelektie))
'			End If
'			BetalingenVoorNa(0).Items.Clear()
'			BetalingenVoorNa(1).Items.Clear()
'			bGetOrGreater(FlRekening, 0, vSet(String99(Lees, FlPartij + 8), 7))
'			If Ktrl Then
'				MsgBox("onlogika")
'			Else
'				RecordToVeld(FlRekening)
'				Do While KeyBuf(FlRekening) <= GroepSelektie
'					GroepRekening4 = KeyBuf(FlRekening)
'					SnelHelpPrint("Journalen boekjaar voor rek. " & KeyBuf(FlRekening) & " worden gekontroleerd.  Ogenblik a.u.b.", blLogging)
'					AantalInGroep = AantalInGroep + 1
'					If bhEuro Then
'						TotaalBedragGroep = TotaalBedragGroep + Val(vBibTekst(FlRekening, "#e" & VB6.Format(22 + AktiefBoekjaar, "000") & " #"))
'					Else
'						TotaalBedragGroep = TotaalBedragGroep + Val(vBibTekst(FlRekening, "#v" & VB6.Format(22 + AktiefBoekjaar, "000") & " #"))
'					End If
'					bGetOrGreater(FlJournaal, 0, vSet(KeyBuf(FlRekening), 7) & PlGrensVan.Value)
'					If Ktrl Then
'						MsgBox("Geen journalen voor deze periode...")
'					Else
'						RecordToVeld(FlJournaal)
'						If VB.Left(KeyBuf(FlJournaal), 7) <= GroepSelektie Then
'						Else
'							Exit Do
'						End If
'						Do While VB.Right(KeyBuf(FlJournaal), 8) <= PlGrensTot.Value
'							SnelHelpPrint("Alle journalen voor rekening " & KeyBuf(FlRekening) & " worden gekontroleerd.  Bezig aan :" & VB.Right(KeyBuf(FlJournaal), 8), blLogging)
'							'UPGRADE_ISSUE: DoEvents does not return a value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8D115264-E27F-4472-A684-865A00B5E826"'
'							XDoEvents = System.Windows.Forms.Application.DoEvents()
'							If Trim(vBibTekst(FlJournaal, "#v033 #")) = "" Or VB.Left(vBibTekst(FlJournaal, "#v033 #"), 1) = "D" Then
'								Debug.Print(VB6.TabLayout(rsMAR(FlJournaal).Fields("v033").Value, Val(rsMAR(FlJournaal).Fields("v068").Value), rsMAR(FlJournaal).Fields("v067").Value, rsMAR(FlJournaal).Fields("v019").Value))
'								AantalZonderdokument = AantalZonderdokument + 1

'								BedragZonderdokument = BedragZonderdokument + Val(vBibTekst(FlJournaal, "#v068 #"))
'							ElseIf RTrim(vBibTekst(FlJournaal, "#v038 #")) <> "" Then 
'								bGet(Fldokument, 0, vBibTekst(FlJournaal, "#v033 #"))
'								If Ktrl Then
'								Else
'									RecordToVeld(Fldokument)
'									If vBibTekst(Fldokument, "#v035 #") < PlGrensVan.Value Then
'										BetaaldBedragBB = Val(vBibTekst(FlJournaal, "#v068 #"))
'										If FlPartij = FlKlant Then
'											BetaaldBedragBB = -BetaaldBedragBB
'										End If
'										If XisEuroWisBEF = True Then
'											If vBibTekst(FlJournaal, "#v066 #") > VB.Right(BoekjaarVanTot.Value, 8) Then
'												BetaaldBedragBB = System.Math.Round(BetaaldBedragBB * Euro)
'											End If
'										End If

'										TotaalDokOnderPeriode = TotaalDokOnderPeriode + BetaaldBedragBB
'										AantalOnderPeriode = AantalOnderPeriode + 1
'										Msg = vSet(Mid(vBibTekst(Fldokument, "#v034 #"), 2), 12) & " "
'										Msg = Msg & vSet(vBibTekst(FlJournaal, "#v067 #"), 20) & " "
'										Msg = Msg & fDatumText(vBibTekst(Fldokument, "#v035 #")) & " "
'										Msg = Msg & vBibTekst(Fldokument, "#v033 #") & " "
'										Msg = Msg & Dec(BetaaldBedragBB, Masker2002.Value) & " "
'										Msg = Msg & vSet(vBibTekst(FlJournaal, "#v019 #"), 7) & " "
'										Msg = Msg & fDatumText(vBibTekst(FlJournaal, "#v066 #")) & " "
'										Msg = Msg & vBibTekst(FlJournaal, "#v038 #") & " "
'										Msg = Msg & vBibTekst(FlJournaal, "#v069 #")
'										BetalingenVoorNa(0).Items.Add(Msg)
'									ElseIf vBibTekst(Fldokument, "#v035 #") > PlGrensTot.Value Then 
'										BetaaldBedragBB = Val(vBibTekst(FlJournaal, "#v068 #"))
'										If FlPartij = FlKlant Then
'											BetaaldBedragBB = -BetaaldBedragBB
'										End If
'										If XisEuroWisBEF = True Then
'											If vBibTekst(FlJournaal, "#v066 #") > VB.Right(BoekjaarVanTot.Value, 8) Then
'												BetaaldBedragBB = System.Math.Round(BetaaldBedragBB * Euro)
'											End If
'										End If

'										TotaalDokBovenPeriode = TotaalDokBovenPeriode + BetaaldBedragBB
'										AantalBovenPeriode = AantalBovenPeriode + 1
'										Msg = vSet(Mid(vBibTekst(Fldokument, "#v034 #"), 2), 12) & " "
'										Msg = Msg & vSet(vBibTekst(FlJournaal, "#v067 #"), 20) & " "
'										Msg = Msg & fDatumText(vBibTekst(Fldokument, "#v035 #")) & " "
'										Msg = Msg & vBibTekst(Fldokument, "#v033 #") & " "
'										Msg = Msg & Dec(BetaaldBedragBB, Masker2002.Value) & " "
'										Msg = Msg & vSet(vBibTekst(FlJournaal, "#v019 #"), 7) & " "
'										Msg = Msg & fDatumText(vBibTekst(FlJournaal, "#v066 #")) & " "
'										Msg = Msg & vBibTekst(FlJournaal, "#v038 #") & " "
'										Msg = Msg & vBibTekst(FlJournaal, "#v069 #")
'										BetalingenVoorNa(1).Items.Add(Msg)
'									End If
'								End If
'							End If
'							bNext(FlJournaal)
'							If Ktrl Or KeyBuf(FlJournaal) > GroepRekening4 & PlGrensTot.Value Then
'								Exit Do
'							Else
'								RecordToVeld(FlJournaal)
'							End If
'						Loop 
'					End If
'					bNext(FlRekening)
'					If Ktrl Or KeyBuf(FlRekening) > GroepSelektie Then
'						Exit Do
'					Else
'						RecordToVeld(FlRekening)
'					End If
'				Loop 
'			End If

'			For T = 0 To 10
'				VeldTXT(T) = ""
'			Next 
'			VeldTXT(0) = "Stand " & VB6.Format(AantalInGroep, "00") & " " & GroepSelektie & "-rekeningen"
'			VeldTXT(6) = Dec(TotaalBedragGroep, Masker2002.Value)
'			T = 0
'			aa = ""
'			Do While T < 12
'				If chkAfdrukInVenster.CheckState Then
'					aa = aa & VeldTXT(T) & vbTab
'				Else
'					Printer.Print(TAB(RapportTab(T)))
'					Printer.Write(VeldTXT(T))
'				End If
'				If RapportTab(T + 1) < RapportTab(T) Then
'					If chkAfdrukInVenster.CheckState Then
'					Else
'						Printer.Write(vbCrLf)
'					End If
'				End If
'				T = T + 1
'			Loop 
'			If chkAfdrukInVenster.CheckState Then mdiXlog.X.AddItem(aa, mdiXlog.X.Rows - 1)

'			For T = 0 To 10
'				VeldTXT(T) = ""
'			Next 
'			VeldTXT(0) = VB6.Format(AantalZonderdokument, "00") & " verr. zonder dokument"
'			VeldTXT(6) = Dec(BedragZonderdokument, Masker2002.Value)
'			T = 0
'			aa = ""
'			Do While T < 12
'				If chkAfdrukInVenster.CheckState Then
'					aa = aa & VeldTXT(T) & vbTab
'				Else
'					Printer.Print(TAB(RapportTab(T)))
'					Printer.Write(VeldTXT(T))
'				End If
'				If RapportTab(T + 1) < RapportTab(T) Then
'					If chkAfdrukInVenster.CheckState Then
'					Else
'						Printer.Write(vbCrLf)
'					End If
'				End If
'				T = T + 1
'			Loop 
'			If chkAfdrukInVenster.CheckState Then mdiXlog.X.AddItem(aa, mdiXlog.X.Rows - 1)

'			For T = 0 To 10
'				VeldTXT(T) = ""
'			Next 
'			VeldTXT(0) = VB6.Format(AantalOnderPeriode, "#") & " betalingen dok. < boekjaar"
'			VeldTXT(6) = Dec(TotaalDokOnderPeriode, Masker2002.Value)
'			T = 0
'			aa = ""
'			Do While T < 12
'				If chkAfdrukInVenster.CheckState Then
'					aa = aa & VeldTXT(T) & vbTab
'				Else
'					Printer.Print(TAB(RapportTab(T)))
'					Printer.Write(VeldTXT(T))
'				End If
'				If RapportTab(T + 1) < RapportTab(T) Then
'					If chkAfdrukInVenster.CheckState Then
'					Else
'						Printer.Write(vbCrLf)
'					End If
'				End If
'				T = T + 1
'			Loop 
'			If chkAfdrukInVenster.CheckState Then mdiXlog.X.AddItem(aa, mdiXlog.X.Rows - 1)

'			For T = 0 To 10
'				VeldTXT(T) = ""
'			Next 
'			VeldTXT(0) = VB6.Format(AantalBovenPeriode, "#") & " betalingen dok. > boekjaar"
'			VeldTXT(6) = Dec(TotaalDokBovenPeriode, Masker2002.Value)
'			T = 0
'			aa = ""
'			Do While T < 12
'				If chkAfdrukInVenster.CheckState Then
'					aa = aa & VeldTXT(T) & vbTab
'				Else
'					Printer.Print(TAB(RapportTab(T)))
'					Printer.Write(VeldTXT(T))
'				End If
'				If RapportTab(T + 1) < RapportTab(T) Then
'					If chkAfdrukInVenster.CheckState Then
'					Else
'						Printer.Write(vbCrLf)
'					End If
'				End If
'				T = T + 1
'			Loop 
'			If chkAfdrukInVenster.CheckState Then mdiXlog.X.AddItem(aa, mdiXlog.X.Rows - 1)
'		End If

'		If chkAfdrukInVenster.CheckState Then
'			'mdiXlog!Kopie(1).Checked = True
'			mdiXlog.X.Row = 1
'			mdiXlog.X.Col = 0
'			mdiXlog.X.set_ColWidth(0, 2385)
'			mdiXlog.X.set_ColWidth(1, 1185)
'			mdiXlog.X.set_ColWidth(2, 990)
'			mdiXlog.X.set_ColWidth(3, 390)
'			mdiXlog.X.set_ColWidth(4, 945)
'			mdiXlog.X.set_ColWidth(5, 855)
'			mdiXlog.X.set_ColWidth(6, 855)
'			mdiXlog.X.set_ColWidth(7, 855)
'			mdiXlog.X.set_ColWidth(8, 915)
'			mdiXlog.X.set_ColWidth(9, 975)
'			mdiXlog.X.set_ColWidth(10, 960)
'			'mdiXlog.WindowState = 2

'			mdiXlog.X.set_ColAlignment(4, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'			mdiXlog.X.set_ColAlignment(5, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'			mdiXlog.X.set_ColAlignment(6, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'			mdiXlog.X.set_ColAlignment(8, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'			mdiXlog.X.set_ColAlignment(10, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)

'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal
'			mdiXlog.Show() '1
'			'mdiXlog.WindowState = 0
'			'Unload mdiXlog
'		End If

'	End Sub
'	Private Sub BalansKL_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
'		Dim Printer As New Printer

'		If Not Toegankelijk(Me) Then
'			Me.Close()
'			Exit Sub
'		End If

'		If bhEuro Then
'			cmdEuroCheck.Visible = True
'		Else
'			cmdEuroCheck.Visible = False
'		End If

'		Dim TempbModus As Short

'		PlGrensVan.Value = VB.Left(BoekjaarVanTot.Value, 8)
'		PlGrensTot.Value = VB.Right(BoekjaarVanTot.Value, 8)

'		cbLijstPrinterHier.Items.Clear()
'		If Printers.Count = 0 Then MsgBox("Installeer eerst minstens één printerdriver a.u.b. (bvb. cutePDF)", MsgBoxStyle.Exclamation) : End
'		For TelTot = 0 To Printers.Count - 1
'			'UPGRADE_ISSUE: Printer property Printers.Port was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
'			Me.cbLijstPrinterHier.Items.Add(Printers(TelTot).Port & " " & Printers(TelTot).DeviceName)
'		Next 
'		cbLijstPrinterHier.SelectedIndex = LijstPrinterNr
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

'		On Error Resume Next
'		Err.Clear()
'		'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(dokumentenBalans, BetalingsKontrole). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		Selektie(5).CheckState = LaadTekst("dokumentenBalans", "BetalingsKontrole")
'		If Err.Number Then
'		Else
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(dokumentenBalans, KontroleVervaldag). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			Selektie(0).CheckState = LaadTekst("dokumentenBalans", "KontroleVervaldag")
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(dokumentenBalans, GeenBetalingHogerBoekjaar). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			Selektie(1).CheckState = LaadTekst("dokumentenBalans", "GeenBetalingHogerBoekjaar")
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(dokumentenBalans, PeriodeBegrenzen). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			Selektie(2).CheckState = LaadTekst("dokumentenBalans", "PeriodeBegrenzen")
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(dokumentenBalans, EnkelNietBetaaldedokumenten). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			Selektie(3).CheckState = LaadTekst("dokumentenBalans", "EnkelNietBetaaldedokumenten")
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(dokumentenBalans, -dokumenten-1994Uitsluiten). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			Selektie(4).CheckState = LaadTekst("dokumentenBalans", "-dokumenten-1994Uitsluiten")
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			ChkFinancieelDetail.CheckState = LaadTekst("dokumentenBalans", "FinancieelDetailViaJournaal")
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			chkAfdrukInVenster.CheckState = LaadTekst("dokumentenBalans", "AfdrukInRooster")
'		End If
'		TekstLijn(1).Text = Rdt.Value
'		TekstLijn(4).Text = fDatumText(VB.Left(BoekjaarVanTot.Value, 8)) & " - " & fDatumText(VB.Right(BoekjaarVanTot.Value, 8))

'		Select Case aIndex
'			Case FlLeverancier
'				LijstNaam = "Balans Leveranciers"
'				FlPartij = FlLeverancier
'			Case FlKlant
'				LijstNaam = "Balans Klanten"
'				FlPartij = FlKlant
'			Case Else
'				MsgBox("stop balans partijen!")
'		End Select

'		If XisEuroWisBEF = True Then
'			LijstNaam = LijstNaam & " (Speciale modus: Alle cijfers in BEF !)"
'		End If
'		Me.Text = LijstNaam

'		TekstLijn(2).Text = "0"
'		TekstLijn(3).Text = New String("z", 12)

'	End Sub


'	Private Sub InitVelden()
'		Dim T As Short
'		Dim VolgTab As Short

'		RapportVeld(0) = "Identiteit"
'		RapportTab(0) = 1

'		RapportVeld(1) = "Document"
'		RapportTab(1) = 29

'		RapportVeld(2) = "Datum"
'		RapportTab(2) = 41

'		RapportVeld(3) = "Mdoc"
'		RapportTab(3) = 52

'		If XisEuroWisBEF = True Then
'			RapportVeld(4) = " Goed(BEF)"
'		Else
'			If bhEuro Then
'				RapportVeld(4) = " Goed(EUR)"
'			Else
'				RapportVeld(4) = " Goed(BEF)"
'			End If
'		End If
'		RapportTab(4) = 56

'		If XisEuroWisBEF = True Then
'			RapportVeld(5) = "  BTW(BEF)"
'		Else
'			If bhEuro Then
'				RapportVeld(5) = "  BTW(EUR)"
'			Else
'				RapportVeld(5) = "  BTW(BEF)"
'			End If
'		End If
'		RapportTab(5) = 67

'		RapportVeld(6) = "   Betaald"
'		RapportTab(6) = 78

'		RapportVeld(7) = "Fin.stuk"
'		RapportTab(7) = 89

'		RapportVeld(8) = "      Rest"
'		RapportTab(8) = 98

'		RapportVeld(9) = "Vervaldag"
'		RapportTab(9) = 109

'		If XisEuroWisBEF = True Then
'			RapportVeld(10) = " Cum.(BEF)"
'		Else
'			If bhEuro Then
'				RapportVeld(10) = " Cum.(EUR)"
'			Else
'				RapportVeld(10) = " Cum.(BEF)"
'			End If
'		End If
'		RapportTab(10) = 119

'		RapportTab(11) = 0

'		If chkAfdrukInVenster.CheckState Then
'			Me.Hide()
'			mdiXlog.Close()
'			mdiXlog.Hide()
'			mdiXlog.Text = "dokumentenBalans"
'			mdiXlog.X.Cols = 11
'			mdiXlog.X.Row = 0
'			For T = 0 To 10
'				mdiXlog.X.Col = T
'				mdiXlog.X.Text = RapportVeld(T)
'			Next 
'			Me.Show()
'		End If

'	End Sub

'	Private Sub PrintTitel()
'		Dim Printer As New Printer
'		Dim T As Short

'		If chkAfdrukInVenster.CheckState Then Exit Sub

'		If usrLicentieInfo <> "" Then
'			Printer.CurrentX = 50
'			Printer.CurrentY = 50
'			Printer.Write(usrLicentieInfo)
'		End If
'		PaginaTeller = PaginaTeller + 1
'		Printer.CurrentY = 400
'		Printer.Write(TAB(1), psTekst(2))
'		Printer.Write(TAB(108), "Pagina : " & Dec(PaginaTeller, "##########") & vbCrLf)
'		Printer.Write(TAB(108), "Datum  : " & psTekst(0) & vbCrLf & vbCrLf)
'		Printer.Write(TAB(1), UCase(psTekst(3)) & vbCrLf)

'		Printer.Write(TAB(1), Lijntje.Value & vbCrLf)

'		Do While RapportTab(T) <> 0
'			Printer.Write(TAB(RapportTab(T)), RapportVeld(T))
'			If RapportTab(T + 1) < RapportTab(T) Then
'				Printer.Write(vbCrLf)
'			End If
'			T = T + 1
'		Loop 

'		Printer.Write(TAB(1), Lijntje.Value & vbCrLf & vbCrLf)

'	End Sub

'	Private Sub PrintVelden()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim VeldTekst As String
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
'		If Printer.CurrentY >= Printer.Height - 1200 Then
'			On Error Resume Next
'			Printer.NewPage()
'			Printer.FontSize = Printer.FontSize
'			Printer.Print(" ")
'			Printer.FontSize = Printer.FontSize
'			PrintTitel()
'		End If

'		If chkAfdrukInVenster.CheckState Then mdiXlog.X.AddItem(aa, mdiXlog.X.Rows - 1)

'	End Sub

'	'UPGRADE_WARNING: Event Selektie.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub Selektie_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Selektie.CheckStateChanged
'		Dim Index As Short = Selektie.GetIndex(eventSender)

'		Select Case Index
'			Case 0
'				If Selektie(Index).CheckState = 1 Then
'					TekstLijn(1).Text = fDatumText(VB.Right(BoekjaarVanTot.Value, 8))
'				Else
'					TekstLijn(1).Text = Rdt.Value
'				End If
'			Case 4
'				If Selektie(4).CheckState = 1 Then
'					BeginPlaySound(9)
'					MsgBox("Schakel uitsluitend aan indien U problemen ondervindt met sommige geimporteerde DOS-dokumenten van voor 1994 (o.a. BTW 33 %, 8 % luxetaks)." & vbCrLf & vbCrLf & "Indien U alle mogelijkheden van marIntegraal Windows versie met uw oude data wenst te benutten, gelieve ons pér bedrijf een veiligheidskopij te bezorgen." & vbCrLf & vbCrLf & "Binnen uw servicekontrakt werken wij deze kosteloos om in onze lokalen.")
'				End If
'		End Select

'	End Sub

'	Private Sub TekstLijn_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Enter
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		TekstLijn(Index).SelectionLength = Len(TekstLijn(Index).Text)

'	End Sub

'	Private Sub TekstLijn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Leave
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		Select Case Index
'			Case 1
'				If DatumFout(TekstLijn(1).Text) Then
'					Beep()
'					TekstLijn(1).Text = Rdt.Value
'				End If
'			Case 4
'				If DatumFout(VB.Right(TekstLijn(4).Text, 10)) Then
'					MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !")
'					TekstLijn(4).Text = fDatumText(VB.Left(BoekjaarVanTot.Value, 8)) & " - " & fDatumText(VB.Right(BoekjaarVanTot.Value, 8))
'					TekstLijn(4).Focus()
'					Exit Sub
'				ElseIf Len(TekstLijn(4).Text) <> 23 Then 
'					MsgBox("Respecteer : " & vbCrLf & vbCrLf & "DD/MM/EEJJ - DD/MM/EEJJ a.u.b. !")
'					TekstLijn(4).Text = fDatumText(VB.Left(BoekjaarVanTot.Value, 8)) & " - " & fDatumText(VB.Right(BoekjaarVanTot.Value, 8))
'					TekstLijn(4).Focus()
'					Exit Sub
'				Else
'					PlGrensVan.Value = Mid(TekstLijn(4).Text, 7, 4) & Mid(TekstLijn(4).Text, 4, 2) & Mid(TekstLijn(4).Text, 1, 2)
'					PlGrensTot.Value = Mid(TekstLijn(4).Text, 20, 4) & Mid(TekstLijn(4).Text, 17, 2) & Mid(TekstLijn(4).Text, 14, 2)
'					If BoekjaarVanTot.Value = PlGrensVan.Value & PlGrensTot.Value Then
'						Selektie(5).CheckState = System.Windows.Forms.CheckState.Checked
'						Selektie(5).Visible = True
'					Else
'						Selektie(5).CheckState = System.Windows.Forms.CheckState.Unchecked
'						Selektie(5).Visible = False
'					End If
'				End If
'		End Select

'	End Sub
'End Class