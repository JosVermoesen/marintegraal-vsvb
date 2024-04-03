Option Strict Off
Option Explicit On
Imports System.ComponentModel

Public Class frmAankoopVerrichtingen
    Private Sub frmAankoopVerrichtingen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Top = 0
        Left = 0
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        If lbAankoopDetail.Items.Count Then
            Msg = "Aangeduide verrichtingen negeren." & vbCrLf & vbCrLf & "Bent U zeker ?"
            Ktrl = MsgBox(Msg, 292, "Voortijdig stoppen...")
            If Ktrl = 6 Then
            Else
                Exit Sub
            End If
        Else
            Close
        End If

    End Sub

    Private Sub frmAankoopVerrichtingen_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Mim.AankoopToolStripMenuItem.Enabled = True

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Friend Class DirekteAankoop
'	Inherits System.Windows.Forms.Form
'	'UPGRADE_NOTE: DefInt A-Z statement was removed. Variables were explicitly declared as type Short. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92AFD3E3-440D-4D49-A8BF-580D74A8C9F2"'

'	Dim AankoopDetailTitel(8) As String
'	Dim lvLeverancier As String
'	Dim GeScanBestand As String


'	Dim dokumentSleutel As New VB6.FixedLengthString(11)
'	Dim PriveRekening As New VB6.FixedLengthString(7)
'	Dim LeverancierRekening As New VB6.FixedLengthString(7)
'	'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
'	Dim GrensDetail(3) As String*14

'	Dim AankoopFlg As Short
'	'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
'	Dim rbtwVAK(10) As String*7
'	Dim sMuntLever As New VB6.FixedLengthString(3)
'	Dim sIsIntraFlg As New VB6.FixedLengthString(1)

'	Dim StartBlad As Boolean

'	Dim Ar As Short

'	Dim VeldRekening As New VB6.FixedLengthString(7)
'	Dim VeldNaam As New VB6.FixedLengthString(40)
'	Dim VeldBedrag As New VB6.FixedLengthString(10)

'	Private Sub Aankoopdetail_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Aankoopdetail.DoubleClick

'		If AankoopDetail.SelectedIndex = -1 Then
'			AankoopDetail_KeyPress(AankoopDetail, New System.Windows.Forms.KeyPressEventArgs(Chr(43)))
'		Else
'			AankoopDetail_KeyPress(AankoopDetail, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
'		End If

'	End Sub

'	Private Sub AankoopDetail_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AankoopDetail.Enter

'		SnelHelpPrint("[Insert] lijn bijvoegen, [Delete] lijn verwijderen, [spatie],[Enter] om te wijzigen", blLogging)
'		If AankoopDetail.Items.Count Then
'			AankoopDetail.SelectedIndex = AankoopDetail.Items.Count - 1
'		End If
'		VB6.SetDefault(Kontrole, False)

'	End Sub

'	Private Sub AankoopDetail_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles AankoopDetail.KeyDown
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000
'		Dim Positie As Short
'		Dim X As Short

'		Positie = AankoopDetail.SelectedIndex
'		Select Case KeyCode
'			Case 45, 107
'				GridText = ""
'				Wijzigen.ShowDialog()
'				If GridText = "" Then
'				Else
'					If RekeningOK(VB.Left(GridText, 7)) Then
'						AankoopDetail.Items.Insert(Positie + 1, GridText)
'						X = InvestKtrl()
'					End If
'				End If
'			Case 46
'				If Positie < 0 Then
'					MsgBox("Eerst een lijn selekteren !", 0, "Lijn wijzigen")
'					Exit Sub
'				End If
'				Msg = "Lijn verwijderen !  Bent U zeker ?"
'				Ktrl = MsgBox(Msg, 292)
'				If Ktrl = 6 Then
'					AankoopDetail.Items.RemoveAt(Positie)
'				End If
'		End Select
'		Me.AankoopDetail.Focus()

'	End Sub

'	Private Sub AankoopDetail_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles AankoopDetail.KeyPress
'		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
'		Dim Positie As Short
'		Dim X As Short

'		On Error Resume Next
'		Positie = AankoopDetail.SelectedIndex
'		Select Case KeyAscii
'			Case 13
'				If Positie < 0 Then
'					MsgBox("Eerst een lijn selekteren !", 0, "Lijn wijzigen")
'					GoTo EventExitSub
'				End If
'				GridText = AankoopDetail.Text
'				Wijzigen.ShowDialog()
'				If GridText = "" Then
'				Else
'					If RekeningOK(VB.Left(GridText, 7)) Then
'						AankoopDetail.Items.RemoveAt(Positie)
'						AankoopDetail.Items.Insert(Positie, GridText)
'						X = InvestKtrl()
'					End If
'				End If
'		End Select
'		Me.AankoopDetail.Focus()

'EventExitSub: 
'		eventArgs.KeyChar = Chr(KeyAscii)
'		If KeyAscii = 0 Then
'			eventArgs.Handled = True
'		End If
'	End Sub


'	'UPGRADE_WARNING: Event AankoopOptie.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub AankoopOptie_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AankoopOptie.CheckedChanged
'		If eventSender.Checked Then
'			Dim Index As Short = AankoopOptie.GetIndex(eventSender)

'Jumper: 
'			Select Case Index
'				Case 0
'					Ar = 1
'					dokumentSleutel.Value = SleutelDok(Ar)

'				Case 1
'					Ar = 3
'					dokumentSleutel.Value = SleutelDok(Ar)

'				Case 2
'					'MsgBox Now & " beschikbaar eerstvolgende versie(s) (ijdele hoop...  Euro gaat voor!)", vbInformation
'					AankoopOptie(0).Checked = True
'			End Select
'			Me.Text = "Ctrl+F1 Direkte aankoopverrichting (" & dokumentSleutel.Value & ")"
'			bGet(Fldokument, 0, dokumentSleutel.Value)
'			If Ktrl = 0 Then
'				MsgBox("Document " & dokumentSleutel.Value & " is reeds aanwezig..." & vbCr & vbCr & "Controleer eventueel uw tellerbestand voor het active boekjaar.  Indien U zopas wisselde van boekjaar met het aankoopvenster open, mag U (na controle) deze melding negeren..." & vbCr & vbCr & "NIET BOEKJAAR GEWISSELD ZOPAS ?  EERST UW TELLEBESTAND + PROEF- SALDI BALANS CONTROLEREN !!!", MsgBoxStyle.Exclamation)
'			End If

'		End If
'	End Sub

'	Private Sub Afsluiten_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Afsluiten.Click
'		Dim A As String
'		Dim aa As New VB6.FixedLengthString(30)
'		Dim dTTwb As Double
'		Dim DummySleutel As String

'		If AankoopDetail.Items.Count = 0 Then Exit Sub
'		If bhEuro And cmdSwitch.Text = "Ingave in EUR" Then
'			'ok VOOR EUR boekhouding
'		ElseIf Not bhEuro And cmdSwitch.Text = "Ingave in BEF" Then 
'			'ok VOOR BEF boekhouding
'		Else
'			MsgBox("Uw boekjaar draait in de andere munt.  De Toggle is er enkel informatief.  Eerst de Toggle terugplaatsen op munt van de boekhouding a.u.b.", MsgBoxStyle.Information)
'			Exit Sub
'		End If

'		If Not DatumKtrl(TekstInfo(0).Text, TekstPeriode) Then
'			Beep()
'			On Error Resume Next
'			TekstInfo(0).Focus()
'			Exit Sub
'		End If

'		If dokumentSleutel.Value <> SleutelDok(Ar) Then
'			Msg = dokumentSleutel.Value & " <> " & SleutelDok(Ar) & vbCrLf & vbCrLf
'			Msg = Msg & "MOGELIJKHEID 1: Teller is identiek, boekjaar is hoger/lager." & vbCrLf
'			Msg = Msg & "U hebt dus het actief boekjaar of periode gewijzigd tijdens de aanmaak van dit dokument.  Probeer nogmaals NA KONTROLE." & vbCrLf & vbCrLf
'			Msg = Msg & "MOGELIJKHEID 2: Boekjaar is identiek, teller is hoger/lager." & vbCrLf
'			Msg = Msg & "Een andere gebruiker heeft ondertussen een dokument verwerkt." & vbCrLf & vbCrLf
'			Msg = Msg & "Kontroleer eerst eens vooraleer de boeking nogmaals uit te voeren a.u.b. !!!"
'			MsgBox(Msg)
'			dokumentSleutel.Value = SleutelDok(Ar)
'			Me.Text = "Ctrl+F1 Direkte aankoopverrichting (" & dokumentSleutel.Value & ")"
'			Exit Sub
'		End If

'		Msg = "Document wegschrijven, boekhouding bijwerken."
'		Ktrl = MsgBox(Msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, dokumentSleutel.Value & " verwerken.")
'		Select Case Ktrl
'			Case 7
'				Exit Sub
'		End Select

'		Ktrl = bOpen(FlRekening)
'		Ktrl = bOpen(FlJournaal)
'		Ktrl = bOpen(Fldokument)
'		bBegin()
'		If WegBoekFout() Then
'			bAbort()
'			Me.Activate()
'			Exit Sub
'		Else
'			bEnd()
'			If Ktrl Then
'				bAbort()
'				Exit Sub
'			End If
'			If AankoopFlg = 1 And sIsIntraFlg.Value = "1" Then
'				Fl = FlLeverancier
'				aIndex = 19
'				dTTwb = Val(vBibTekst(Fldokument, "#v048 #")) + Val(vBibTekst(Fldokument, "#v047 #")) + Val(vBibTekst(Fldokument, "#v046 #")) + Val(vBibTekst(Fldokument, "#v049 #"))
'				GridText = Dec(dTTwb, MaskerSy(0)) & vbTab
'				Intrastat.ShowDialog()
'			End If
'			SS99(VB.Right(dokumentSleutel.Value, 5), Ar) 's001 of s003
'			dokumentSleutel.Value = SleutelDok(Ar)
'			Me.Text = "Ctrl+F1 Direkte aankoopverrichting (" & dokumentSleutel.Value & ")"
'			SchoonVegen_Click(SchoonVegen, New System.EventArgs())
'			SSTab1.Focus()
'		End If

'	End Sub

'	Private Sub Afsluiten_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Afsluiten.Leave

'		Kontrole.Visible = True
'		Afsluiten.Visible = False

'	End Sub

'	Private Sub Annuleren_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Annuleren.Click

'		If AankoopDetail.Items.Count = 0 Then
'		Else
'			Msg = "Aanwezige bewerkingen negeren !  Bent U zeker ?"
'			Ktrl = MsgBox(Msg, 292, "Aankoopverrichtingen sluiten")
'			If Ktrl <> 6 Then
'				Exit Sub
'			End If
'		End If
'		Me.Close()

'	End Sub


'	Private Sub cbAfbeelding_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbAfbeelding.Click

'		Dim FlHier As Short
'		Dim BestandHier As String

'		'Dim miDoc As MODIctl.Document
'		'Set miDoc = New MODIctl.Document

'		'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(dnnInstellingen, PostvakIO). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		If LaadTekst("dnnInstellingen", "PostvakIO") = "" Then
'			MsgBox("Nieuwe PC of nog geen instellingen voor PDF Postvak In.  Aanbevolen in te te stellen a.u.b. via submenu DotNetNuke.", MsgBoxStyle.Information)
'			Mim.TekenOpen.InitialDirectory = BedrijfsLokatie
'		Else
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(dnnInstellingen, PostvakIO). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			Mim.TekenOpen.InitialDirectory = LaadTekst("dnnInstellingen", "PostvakIO")
'		End If
'		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Mim.TekenOpen.Filter = "Acrobat bestanden (*.pdf)|*.pdf"
'		Mim.TekenOpen.FileName = ""
'		Mim.TekenOpen.ShowDialog()
'		BestandHier = LCase(Mim.TekenOpen.FileName)
'		If BestandHier = "" Then
'			Exit Sub
'		Else
'			If VB.Right(BestandHier, 3) <> "pdf" Then
'				MsgBox("Enkel *.pdf bestanden zijn toegelaten", MsgBoxStyle.Exclamation)
'				Exit Sub
'			End If
'		End If
'		GeScanBestand = Mim.TekenOpen.FileName
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'		On Error Resume Next
'		'UPGRADE_ISSUE: Ole method OLE1.CreateEmbed was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
'		OLE1.CreateEmbed(GeScanBestand)
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal

'	End Sub


'	'UPGRADE_WARNING: Event cbBank.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub cbBank_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBank.CheckStateChanged

'		Select Case cbBank.CheckState
'			Case System.Windows.Forms.CheckState.Checked
'				TekstInfo(11).Enabled = True
'				TekstInfo(11).Focus()

'			Case Else
'				TekstInfo(11).Enabled = False

'		End Select

'	End Sub

'	Private Sub cbUpdateLeverancier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbUpdateLeverancier.Click

'		If Len(TekstInfo(11).Text) <> 14 Then
'			MsgBox("LogicaStop lengte rekeningnummer")
'		Else
'			'controle of de leverancier (nog) actief is en daarna wegschrijven
'			bGet(FlLeverancier, 0, VB.Left(LeverancierInfo.Text, 12))
'			If Ktrl Then
'				MsgBox("LogicaStop zoeken leveranciersfiche")
'			Else
'				RecordToVeld(FlLeverancier)
'				vBib(FlLeverancier, TekstInfo(11).Text, "A170")
'				bUpdate(FlLeverancier, 0)
'				If Ktrl Then
'					MsgBox("Onverwacht situatie")
'				Else
'					Me.cbBank.CheckState = System.Windows.Forms.CheckState.Unchecked
'					Me.cbUpdateLeverancier.Visible = False
'				End If
'			End If
'		End If

'	End Sub

'	Private Sub cmdSQLInfo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSQLInfo.Click

'		bGet(FlLeverancier, 0, VB.Left(LeverancierInfo.Text, 12))
'		If Ktrl Then
'			MsgBox("Onlogica.")
'			cmdSQLInfo.Visible = False
'		Else
'			RecordToVeld(FlLeverancier)
'			If vBibTekst(FlLeverancier, "#v254 #") <> "" Then
'				KtrlBox = SQLPopUp(vBibTekst(FlLeverancier, "#v254 #"), bstNaam(FlLeverancier), "A110", vBibTekst(FlLeverancier, "#A110 #"))
'			Else
'				cmdSQLInfo.Visible = False
'			End If
'		End If

'	End Sub


'	Private Sub cmdSwitch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSwitch.Click
'		Dim TempoTel As Short
'		Dim TempoVar As Object

'		If sMuntLever.Value = "BEF" Or sMuntLever.Value = "EUR" Then
'		Else
'			MsgBox("Switch niet mogelijk voor leveranciers buiten de E.U.  en enkel mogelijk indien leverancier met BEF of EUR code", MsgBoxStyle.Information)
'			Exit Sub
'		End If

'		'Stap 1: overschakeling cijfers van BEF naar EUR
'		TekstInfo(5).Text = ""
'		TekstInfo(7).Text = ""
'		TekstInfo(8).Text = ""
'		If cmdSwitch.Text = "Ingave in EUR" Then
'			TekstInfo(6).Text = Dec(Val(TekstInfo(6).Text) * Euro, MaskerSy(0))
'			cmdSwitch.Text = "Ingave in BEF"
'			'Stap 2: de nodige schermopmaak voor BEF
'			If bhEuro Then
'				'EUR boekhouding
'				dMuntL = 1 / Euro
'				For TelTot = 0 To AankoopDetail.Items.Count - 1
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					TempoVar = VB6.GetItemString(AankoopDetail, TelTot)
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					Mid(TempoVar, 50, 12) = Dec(System.Math.Round(Val(Mid(TempoVar, 50, 12)) * Euro, 0), MaskerEURBH)
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					VB6.SetItemString(AankoopDetail, TelTot, TempoVar)
'				Next 
'			Else
'				'BEF boekhouding
'				dMuntL = 1
'				For TelTot = 0 To AankoopDetail.Items.Count - 1
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					TempoVar = VB6.GetItemString(AankoopDetail, TelTot)
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					Mid(TempoVar, 50, 12) = Dec(System.Math.Round(Val(Mid(TempoVar, 50, 12)) * Euro, 0), MaskerEURBH)
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					VB6.SetItemString(AankoopDetail, TelTot, TempoVar)
'				Next 
'			End If
'		Else
'			TekstInfo(6).Text = Dec(Val(TekstInfo(6).Text) / Euro, MaskerEURBH)
'			cmdSwitch.Text = "Ingave in EUR"
'			'Stap 2: de nodige schermopmaak voor EUR
'			If bhEuro Then
'				'EUR boekhouding
'				dMuntL = 1
'				For TelTot = 0 To AankoopDetail.Items.Count - 1
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					TempoVar = VB6.GetItemString(AankoopDetail, TelTot)
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					Mid(TempoVar, 50, 12) = Dec(System.Math.Round(Val(Mid(TempoVar, 50, 12)) / Euro, 2), MaskerEURBH)
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					VB6.SetItemString(AankoopDetail, TelTot, TempoVar)
'				Next 
'			Else
'				'BEF boekhouding
'				dMuntL = 1 / Euro
'				For TelTot = 0 To AankoopDetail.Items.Count - 1
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					TempoVar = VB6.GetItemString(AankoopDetail, TelTot)
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					Mid(TempoVar, 50, 12) = Dec(System.Math.Round(Val(Mid(TempoVar, 50, 12)) / Euro, 2), MaskerEURBH)
'					'UPGRADE_WARNING: Couldn't resolve default property of object TempoVar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					VB6.SetItemString(AankoopDetail, TelTot, TempoVar)
'				Next 
'			End If
'		End If
'		TekstInfo(9).Text = Dec(dMuntL, "##0.########")
'		VernieuwDirecteAankoopEUR()
'		TekstInfo(6).Focus()

'	End Sub

'	Sub VernieuwDirecteAankoopEUR()

'		'    MsgBox "Stop"

'	End Sub





'	Private Sub DirekteAankoop_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

'		If Not Toegankelijk(Me) Then
'			Me.Close()
'			Exit Sub
'		End If

'		'rsMAR(Fldokument).Close
'		Ktrl = ktrlBLOBRecord
'		If Ktrl = False Then
'			AutoUnloadBedrijf()
'			Exit Sub
'		End If

'		If bhEuro Then
'			cmdSwitch.Text = "Ingave in EUR"
'		Else
'			cmdSwitch.Text = "Ingave in BEF"
'		End If

'		Dim Tel As Short

'		' Add ColumnHeaders. The width of the columns is
'		' the width of the control divided by the number of
'		' ColumnHeader objects.
'		ListView1.Columns.Add("", "Naam", CInt(VB6.TwipsToPixelsX(3270)))
'		ListView1.Columns.Add("", "IdCode", CInt(VB6.TwipsToPixelsX(930)))

'		' Set View property to Report.
'		ListView1.View = System.Windows.Forms.View.Details

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'		Top = 0
'		Left = 0

'		For Tel = 16 To 19
'			rbtwVAK(Tel - 16) = String99(Lees, Tel)
'			rbtwVAK(Tel - 12) = String99(Lees, Tel + 6)
'		Next 

'		LeverancierRekening.Value = String99(Lees, 10)
'		sIsIntraFlg.Value = String99(Lees, 200)


'		PriveRekening.Value = String99(Lees, 145)

'		GrensDetail(0) = ""
'		Fl99Record = String99(Lees, 148)
'		Mid(GrensDetail(0), 1, 7) = VB.Left(Fl99Record, 7)
'		Fl99Record = String99(Lees, 149)
'		Mid(GrensDetail(0), 8, 7) = VB.Left(Fl99Record, 7)

'		GrensDetail(1) = ""
'		Fl99Record = String99(Lees, 146)
'		Mid(GrensDetail(1), 1, 7) = VB.Left(Fl99Record, 7)
'		Fl99Record = String99(Lees, 147)
'		Mid(GrensDetail(1), 8, 7) = VB.Left(Fl99Record, 7)

'		GrensDetail(2) = ""
'		Fl99Record = String99(Lees, 150)
'		Mid(GrensDetail(2), 1, 7) = VB.Left(Fl99Record, 7)
'		Fl99Record = String99(Lees, 151)
'		Mid(GrensDetail(2), 8, 7) = VB.Left(Fl99Record, 7)

'		GrensDetail(3) = ""
'		Fl99Record = String99(Lees, 152)
'		Mid(GrensDetail(3), 1, 7) = VB.Left(Fl99Record, 7)
'		Fl99Record = String99(Lees, 153)
'		Mid(GrensDetail(3), 8, 7) = VB.Left(Fl99Record, 7)

'		'InstalleerRecenteCrediteuren
'		'UPGRADE_WARNING: Couldn't resolve default property of object LaadTekst(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		Msg = LaadTekst("DirekteAankoop", "startBlad")
'		If Msg = "" Then Msg = "True"
'		StartBlad = CBool(Msg)
'		Schoon()
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal

'	End Sub

'	'UPGRADE_WARNING: Event DirekteAankoop.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub DirekteAankoop_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize

'		AankoopDetail.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 250)

'	End Sub


'	Private Sub InstalLeverancier()
'		Dim Lever As String
'		Dim T As Short
'		Dim X As Short

'		AankoopDetail.Enabled = True
'		'InvoerLijn.Enabled = True

'		Lever = vbCrLf & vBibTekst(FlLeverancier, "#A100 #") & vbCrLf & vBibTekst(FlLeverancier, "#A125 #") & vbCrLf & vBibTekst(FlLeverancier, "#A104 #") & vbCrLf & vBibTekst(FlLeverancier, "#A109 #") & " " & vBibTekst(FlLeverancier, "#A107 #") & " " & vBibTekst(FlLeverancier, "#A108 #")
'		Schoonvegen.Enabled = True
'		'ReturnRooster.Enabled = True

'		If vBibTekst(FlLeverancier, "#v149 #") = "" Then
'			MsgBox("Landnummer is verplicht !")
'			Exit Sub
'		ElseIf vBibTekst(FlLeverancier, "#v149 #") = "002" Then 
'			LeverancierInfo.Text = vSet(vBibTekst(FlLeverancier, "#A110 #"), 12) & "* Binnenland * " & Lever
'			AankoopFlg = 0
'			Medekontraktant.Enabled = True
'			TekstInfo(7).Visible = False
'			TekstInfo(8).Visible = False
'			TekstInfo(7).Text = TekstInfo(5).Text
'			TekstInfo(8).Text = "0"
'			Label1(12).Visible = False
'			Label1(13).Visible = False
'		ElseIf InStr(SISO, vBibTekst(FlLeverancier, "#v149 #")) Then 
'			LeverancierInfo.Text = vSet(vBibTekst(FlLeverancier, "#A110 #"), 12) & "* E.U. Verschuldigde BTW * " & Lever
'			AankoopFlg = 1
'			Medekontraktant.Enabled = False
'			TekstInfo(7).Visible = True
'			TekstInfo(8).Visible = True
'			TekstInfo(7).Text = "0"
'			TekstInfo(8).Text = "0"
'			Label1(12).Visible = True
'			Label1(13).Visible = True
'		Else
'			LeverancierInfo.Text = vSet(vBibTekst(FlLeverancier, "#A110 #"), 12) & "* Niet E.U. + BTW ! *" & Lever
'			AankoopFlg = 2
'			Medekontraktant.Enabled = False
'			TekstInfo(7).Visible = True
'			TekstInfo(8).Visible = True
'			TekstInfo(7).Text = "0"
'			TekstInfo(8).Text = "0"
'			Label1(12).Visible = True
'			Label1(13).Visible = True
'		End If

'		For T = 0 To 7
'			TekstInfo(T).Enabled = True
'		Next 

'		sMuntLever.Value = UCase(vBibTekst(FlLeverancier, "#vs03 #"))
'		bGet(FlAllerlei, 1, vSet("10" & sMuntLever.Value, 20))
'		If Ktrl Then
'			MsgBox("Dagkoers voor muntkode " & sMuntLever.Value & " niet te vinden !  Eerst aanmaken via gebruikersfiches a.u.b.")
'			If bhEuro Then
'				sMuntLever.Value = "EUR"
'			Else
'				sMuntLever.Value = "BEF"
'			End If
'			TekstInfo(9).Text = Dec(1, "###.########")
'		Else
'			RecordToVeld(FlAllerlei)
'			TekstInfo(9).Text = Dec(Val(vBibTekst(FlAllerlei, "#v040 #")), "###.########")
'		End If

'		If bhEuro Then
'			If sMuntLever.Value = "BEF" Then
'				cmdSwitch.Text = "Ingave in BEF"
'				cmdSwitch.Enabled = True
'				TekstInfo(9).Text = Dec(1 / Euro, "##0.########")
'			ElseIf sMuntLever.Value = "EUR" Then 
'				cmdSwitch.Text = "Ingave in EUR"
'				cmdSwitch.Enabled = True
'				TekstInfo(9).Text = Dec(1, "##0.########")
'			Else
'				cmdSwitch.Text = "Ingave in EUR"
'				cmdSwitch.Enabled = False
'				TekstInfo(9).Text = Dec(1, "##0.########")
'			End If
'		Else
'			If sMuntLever.Value = "EUR" Then
'				cmdSwitch.Text = "Ingave in EUR"
'				cmdSwitch.Enabled = True
'				TekstInfo(9).Text = Dec(1 / Euro, "##0.########")
'			ElseIf sMuntLever.Value = "BEF" Then 
'				cmdSwitch.Text = "Ingave in BEF"
'				cmdSwitch.Enabled = True
'				TekstInfo(9).Text = Dec(1, "##0.########")
'			Else
'				cmdSwitch.Text = "Ingave in BEF"
'				cmdSwitch.Enabled = False
'				'TekstInfo(9).Text = Dec$(1, "##0.########")
'			End If
'		End If
'		dMuntL = Val(TekstInfo(9).Text)

'		If vBibTekst(FlLeverancier, "#v151 #") = "1" Then
'			Medekontraktant.CheckState = System.Windows.Forms.CheckState.Checked
'		Else
'			Medekontraktant.CheckState = System.Windows.Forms.CheckState.Unchecked
'		End If
'		If vBibTekst(FlLeverancier, "#v163 #") = "1" Then
'			StockBeheer.CheckState = System.Windows.Forms.CheckState.Checked
'		Else
'			StockBeheer.CheckState = System.Windows.Forms.CheckState.Unchecked
'		End If

'		Err.Clear()
'		On Error Resume Next
'		TekstInfo(11).Text = vBibTekst(FlLeverancier, "#A170 #")

'		If vSet(vBibTekst(FlLeverancier, "#v016 #"), 7) <> Space(7) Then
'			If AankoopDetail.Items.Count = 0 Then
'				RasterSchoon()
'				VeldRekening.Value = vBibTekst(FlLeverancier, "#v016 #")
'				VeldNaam.Value = ""
'				VeldBedrag.Value = ""
'				GridText = VeldRekening.Value & Chr(124) & VeldNaam.Value & Chr(124) & VeldBedrag.Value & Chr(124)
'				Wijzigen.ShowDialog()
'				If GridText = "" Then
'				Else
'					If RekeningOK(VB.Left(GridText, 7)) Then
'						AankoopDetail.Items.Add(GridText)
'						X = InvestKtrl()
'					End If
'				End If
'			End If
'		End If

'		If VB.Left(vBibTekst(FlLeverancier, "#v162 #"), 3) = "440" Then
'			TekstInfo(3).Text = vBibTekst(FlLeverancier, "#v162 #")
'			bGet(FlRekening, 0, vSet(vBibTekst(FlLeverancier, "#v162 #"), 7))
'			If Ktrl Then
'				Beep()
'				TekstInfo(3).Text = LeverancierRekening.Value
'			End If
'		Else
'			TekstInfo(3).Text = LeverancierRekening.Value
'		End If
'		TekstInfo(10).Enabled = True

'		TekstInfo(2).Text = VValdag(TekstInfo(0).Text, vBibTekst(FlLeverancier, "#vs04 #"))
'		If vBibTekst(FlLeverancier, "#v017 #") = "1" Then
'			'UPGRADE_ISSUE: MSMask.MaskEdBox property TekstInfo.AutoTab was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
'			TekstInfo(4).AutoTab = True
'			'UPGRADE_WARNING: MSMask.MaskEdBox property TekstInfo.ClipMode has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			TekstInfo(4).CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals
'			TekstInfo(4).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
'			TekstInfo(4).Mask = "+++###/####/#####+++"
'		Else
'			'UPGRADE_ISSUE: MSMask.MaskEdBox property TekstInfo.AutoTab was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
'			TekstInfo(4).AutoTab = False
'			'UPGRADE_WARNING: MSMask.MaskEdBox property TekstInfo.ClipMode has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			TekstInfo(4).CutCopyMaskFormat = MaskFormat.IncludeLiterals
'			TekstInfo(4).TextMaskFormat = MaskFormat.IncludePrompt
'			TekstInfo(4).Mask = ""
'			TekstInfo(4).Text = ""
'		End If
'		If vBibTekst(FlLeverancier, "#v254 #") <> "" Then
'			cmdSQLInfo.Visible = True
'		End If
'		Me.AankoopDetail.Focus()

'	End Sub

'	Private Function InvestKtrl() As Short
'		Dim fRekNum As New VB6.FixedLengthString(7)

'		fRekNum.Value = VB.Left(GridText, 7)
'		If fRekNum.Value < VB.Left(GrensDetail(0), 7) Or fRekNum.Value > VB.Right(GrensDetail(0), 7) Then
'		Else
'			GridText = TekstInfo(0).Text & Dec(Val(Mid(GridText, 50, 12)), MaskerEURBH)
'			InvesteringsFiche.ShowDialog()
'		End If

'	End Function

'	Private Sub DirekteAankoop_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

'		'Me.MiDocView1.filename = ""

'	End Sub

'	Private Sub Kontrole_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Kontrole.Click
'		Dim T As Short
'		Dim BedragTotaal As Decimal
'		Dim BedragBtwAftrekbaas As Decimal

'		Dim BedragTot As Decimal
'		Dim BedragBtw5 As Decimal
'		Dim BedragBtw6 As Decimal
'		Dim BedragBtw7 As Decimal
'		Dim BedragBtw8 As Decimal

'		If DatumKey(TekstInfo(1).Text) < VB.Left(BoekjaarVanTot.Value, 8) Or DatumKey(TekstInfo(1).Text) > VB.Right(BoekjaarVanTot.Value, 8) Then
'			Msg = "Datum aankoopdocument valt BUITEN het actieve boekjaar." & vbCr
'			Msg = Msg & "De optie 'boekhoudcontrole' in balans leveranciers zal" & vbCr
'			Msg = Msg & "mogelijk niet goed functioneren." & vbCr & vbCr
'			Msg = Msg & "Controleer eventueel."
'			MsgBox(Msg, MsgBoxStyle.Exclamation)
'		End If

'		VB6.SetDefault(Kontrole, True)
'		For T = 0 To AankoopDetail.Items.Count - 1
'			BedragTot = Val(Mid(VB6.GetItemString(AankoopDetail, T), 50, 12))
'			If bhEuro Then
'				BedragTotaal = BedragTotaal + BedragTot
'			Else
'				BedragTotaal = BedragTotaal + BedragTot
'			End If
'		Next 
'		BedragBtw5 = Val(TekstInfo(5).Text)
'		BedragBtw6 = Val(TekstInfo(6).Text)
'		BedragBtw7 = Val(TekstInfo(7).Text)
'		BedragBtw8 = Val(TekstInfo(8).Text)
'		BedragTotaal = BedragTotaal + BedragBtw5 - BedragBtw7 + BedragBtw8
'		If BedragTotaal <> BedragBtw6 Then
'			MsgBox("U geeft totaal dokument " & BedragBtw6 & vbCr & "en volgens berekening is het " & BedragTotaal & vbCr & vbCr & "  Kontroleer a.u.b.!", 0, "Totaalkontrole")
'			TekstInfo(6).Focus()
'			Exit Sub
'		Else
'			Afsluiten.Visible = True
'			Afsluiten.Enabled = True
'			Kontrole.Visible = False
'			Afsluiten.Focus()
'		End If

'	End Sub



'	Private Sub ListView1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ListView1.Click

'		If ListView1.Items.Count Then
'			'UPGRADE_WARNING: Lower bound of collection ListView1.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
'			lvLeverancier = ListView1.FocusedItem.SubItems(1).Text
'			SSTab1.SelectedIndex = 0
'			bGet(FlLeverancier, 0, lvLeverancier)
'			If Ktrl Then
'				MsgBox("stop")
'			Else
'				RecordToVeld(FlLeverancier)
'				InstalLeverancier()
'			End If
'		Else
'			KtrlBox = MsgBox("Historiek van reeds bestaande leveranciers tonen", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
'			If KtrlBox = MsgBoxResult.Yes Then
'				InstalleerRecenteCrediteuren()
'			End If
'		End If

'	End Sub

'	Private Sub ListView1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000

'		If KeyCode = 13 Then ListView1_Click(ListView1, New System.EventArgs())

'	End Sub


'	'UPGRADE_WARNING: Event Medekontraktant.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub Medekontraktant_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Medekontraktant.CheckStateChanged

'		If Medekontraktant.CheckState = 1 Then
'			TekstInfo(7).Visible = True
'			TekstInfo(8).Visible = True
'			TekstInfo(5).Text = "0"
'			TekstInfo(6).Text = "0"
'			TekstInfo(7).Text = "0" 'TekstInfo(5).Text
'			TekstInfo(8).Text = "0"
'			Label1(12).Visible = True
'			Label1(13).Visible = True
'		Else
'			TekstInfo(7).Visible = False
'			TekstInfo(8).Visible = False
'			TekstInfo(5).Text = "0"
'			TekstInfo(6).Text = "0"
'			TekstInfo(7).Text = "0"
'			TekstInfo(8).Text = "0"
'			Label1(12).Visible = False
'			Label1(13).Visible = False
'		End If


'	End Sub

'	Private Sub RasterSchoon()

'		AankoopDetail.Items.Clear()

'	End Sub

'	Private Function RekeningOK(ByRef fRekeningNummer As String) As Short
'		Dim T As Short
'		Dim TFlag As Short

'		TFlag = False
'		For T = 0 To 3
'			If fRekeningNummer >= VB.Left(GrensDetail(T), 7) And fRekeningNummer <= VB.Right(GrensDetail(T), 7) Then
'				TFlag = True
'				Exit For
'			End If
'		Next 
'		If TFlag = False Then
'			Msg = "Uw rekening : " & fRekeningNummer & " past niet in de begrenzing." & vbCrLf & vbCrLf
'			Msg = Msg & "Investeringen  : vanaf " & VB.Left(GrensDetail(0), 7) & " tot " & VB.Right(GrensDetail(0), 7) & vbCrLf
'			Msg = Msg & "Schulden/privé : vanaf " & VB.Left(GrensDetail(1), 7) & " tot " & VB.Right(GrensDetail(1), 7) & vbCrLf
'			Msg = Msg & "Handelsgoed    : vanaf " & VB.Left(GrensDetail(2), 7) & " tot " & VB.Right(GrensDetail(2), 7) & vbCrLf
'			Msg = Msg & "Diverse kosten : vanaf " & VB.Left(GrensDetail(3), 7) & " tot " & VB.Right(GrensDetail(3), 7)
'			MsgBox(Msg)
'			RekeningOK = False
'			Exit Function
'		Else
'			RekeningOK = True
'		End If

'	End Function

'	Private Sub Schoon()
'		Dim T As Short

'		GeScanBestand = ""
'		If StartBlad = True Then
'			SSTab2.SelectedIndex = 0
'			Me.obTAB(0).Checked = True
'		Else
'			SSTab2.SelectedIndex = 1
'			Me.obTAB(1).Checked = True
'		End If

'		'Me.MiDocView1.filename = ""

'		lvLeverancier = ""
'		VB6.SetDefault(Kontrole, False)
'		Kontrole.Visible = True
'		AankoopDetail.Enabled = False
'		'InvoerLijn.Enabled = False
'		LeverancierInfo.Text = ""
'		Afsluiten.Visible = False
'		Schoonvegen.Enabled = False
'		cmdSwitch.Enabled = False
'		'ReturnRooster.Enabled = False
'		'UPGRADE_ISSUE: MSMask.MaskEdBox property TekstInfo.AutoTab was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
'		TekstInfo(4).AutoTab = False
'		'UPGRADE_WARNING: MSMask.MaskEdBox property TekstInfo.ClipMode has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		TekstInfo(4).CutCopyMaskFormat = MaskFormat.IncludeLiterals
'		TekstInfo(4).TextMaskFormat = MaskFormat.IncludePrompt
'		TekstInfo(4).Mask = ""

'		TekstInfo(11).Mask = ""
'		TekstInfo(11).Text = ""
'		TekstInfo(11).Mask = "###-#######-##"
'		'UPGRADE_ISSUE: MSMask.MaskEdBox property TekstInfo.AutoTab was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
'		TekstInfo(11).AutoTab = True
'		'UPGRADE_WARNING: MSMask.MaskEdBox property TekstInfo.ClipMode has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		TekstInfo(11).CutCopyMaskFormat = MaskFormat.IncludeLiterals
'		TekstInfo(11).TextMaskFormat = MaskFormat.IncludePrompt

'		Err.Clear()
'		On Error Resume Next
'		For T = 0 To 2
'			TekstInfo(T).Enabled = False
'			TekstInfo(T).Mask = ""
'			TekstInfo(T).Mask = "##/##/####"
'			TekstInfo(T).Text = Rdt.Value
'			If Err.Number Then MsgBox("Landinstellingen voor België voorzien a.u.b.  Het programma wordt hierna beëindigd.", MsgBoxStyle.Critical) : End
'		Next 
'		On Error GoTo 0
'		For T = 3 To 10
'			TekstInfo(T).Enabled = False
'			TekstInfo(T).Text = ""
'		Next 
'		TekstInfo(3).Text = LeverancierRekening.Value
'		TekstInfo(10).Text = rbtwVAK(4)
'		RasterSchoon()
'		If Me.Visible Then
'			SSTab1.SelectedIndex = 0
'		End If
'		If Me.obTAB(0).Checked = True Then
'			SSTab2.SelectedIndex = 0
'		Else
'			SSTab2.SelectedIndex = 1
'		End If
'		Me.AankoopOptie(0).Checked = True

'	End Sub

'	'UPGRADE_WARNING: Event obTAB.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub obTAB_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obTAB.CheckedChanged
'		If eventSender.Checked Then
'			Dim Index As Short = obTAB.GetIndex(eventSender)

'			BeWaarTekst("DirekteAankoop", "startBlad", Str(obTAB(0).Checked))

'		End If
'	End Sub


'	Private Sub SchoonVegen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SchoonVegen.Click

'		RasterSchoon()
'		Schoon()
'		SSTab1.Focus()

'	End Sub

'	Function SQLZoekLeverancier() As Short

'		If LeverancierInfo.Text <> "" Then
'			KtrlBox = MsgBox("Andere leverancier aanduiden.  Bent U zeker", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
'			If KtrlBox = MsgBoxResult.No Then
'				AankoopDetail.Focus()
'				Exit Function
'			End If
'		End If
'		aIndex = 1
'		SharedFl = FlLeverancier
'		GridText = ""
'		SqlSearch.ShowDialog()
'		If Ktrl = 0 Then
'			InstalLeverancier()
'		Else
'			Schoon()
'		End If

'	End Function

'	Private Sub SSTab1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles SSTab1.KeyDown
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000

'		If SSTab1.SelectedIndex = 1 Then
'			If ListView1.Items.Count Then
'			ElseIf KeyCode = 13 Then 
'				KtrlBox = MsgBox("Historiek van reeds bestaande leveranciers tonen", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
'				If KtrlBox = MsgBoxResult.Yes Then
'					InstalleerRecenteCrediteuren()
'				End If
'			End If
'		ElseIf KeyCode = 18 Or KeyCode = 13 Then 
'			SQLZoekLeverancier()
'		End If

'	End Sub


'	'UPGRADE_WARNING: Event StockBeheer.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub StockBeheer_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles StockBeheer.CheckStateChanged

'		On Error Resume Next
'		AankoopDetail.Focus()

'	End Sub

'	Private Sub TekstInfo_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstInfo.TextChanged
'		Dim Index As Short = TekstInfo.GetIndex(eventSender)

'		Select Case Index
'			Case 5
'				TekstInfo(8).Text = ""
'				If Medekontraktant.CheckState Then
'					TekstInfo(7).Text = TekstInfo(5).Text
'				End If
'			Case 7
'				If TekstInfo(8).Visible = False Then
'				Else
'					TekstInfo(8).Text = Str(Val(TekstInfo(7).Text) - Val(TekstInfo(5).Text))
'				End If
'		End Select

'	End Sub


'	Private Sub TekstInfo_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstInfo.Enter
'		Dim Index As Short = TekstInfo.GetIndex(eventSender)

'		TekstInfo(Index).SelectionStart = 0
'		TekstInfo(Index).SelectionLength = Len(TekstInfo(Index).Text)
'		Select Case Index
'			Case 0, 1, 2
'				TekstInfo(Index).SelectionLength = 5
'			Case 6
'				VB6.SetDefault(Kontrole, True)
'		End Select

'	End Sub

'	Private Sub TekstInfo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TekstInfo.KeyDown
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000
'		Dim Index As Short = TekstInfo.GetIndex(eventSender)

'		On Error Resume Next
'		If KeyCode = 13 Then
'			System.Windows.Forms.SendKeys.SendWait("{TAB}")
'			Exit Sub
'		End If

'		Select Case Index
'			Case 3, 10
'				If KeyCode = 17 Then
'					aIndex = 0
'					SharedFl = FlRekening
'					GridText = Trim(TekstInfo(Index).Text)
'					SqlSearch.ShowDialog()
'					If Ktrl = 0 Then
'						TekstInfo(Index).Text = vBibTekst(FlRekening, "#v019 #")
'					End If
'				End If
'		End Select

'	End Sub

'	Private Sub TekstInfo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TekstInfo.KeyPress
'		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
'		Dim Index As Short = TekstInfo.GetIndex(eventSender)

'		If Index = 3 Or Index = 10 Then KeyAscii = 0


'		eventArgs.KeyChar = Chr(KeyAscii)
'		If KeyAscii = 0 Then
'			eventArgs.Handled = True
'		End If
'	End Sub

'	Private Sub TekstInfo_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TekstInfo.KeyUp
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000
'		Dim Index As Short = TekstInfo.GetIndex(eventSender)
'		Dim RekenHier As Object

'		If Index = 5 Then
'			Select Case KeyCode
'				Case 106, 107, 109, 111
'					If Len(TekstInfo(Index).Text) = 1 Then
'						Exit Sub
'					End If
'					'UPGRADE_WARNING: Couldn't resolve default property of object EenLijnRekenen(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					'UPGRADE_WARNING: Couldn't resolve default property of object RekenHier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					RekenHier = EenLijnRekenen(TekstInfo(5).Text)
'					'UPGRADE_WARNING: Couldn't resolve default property of object RekenHier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					If RekenHier Then
'						'UPGRADE_WARNING: Couldn't resolve default property of object RekenHier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'						TekstInfo(5).Text = Str(System.Math.Round(RekenHier, 2))
'					End If
'			End Select
'		End If

'	End Sub

'	Private Sub TekstInfo_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstInfo.Leave
'		Dim Index As Short = TekstInfo.GetIndex(eventSender)

'		Select Case Index
'			Case 0
'				If DatumFout(TekstInfo(0).Text) Then
'					TekstInfo(0).Text = Rdt.Value
'					TekstInfo(0).Focus()
'				ElseIf Not DatumKtrl(TekstInfo(0).Text, TekstPeriode) Then 
'					BJPERDAT.WindowState = System.Windows.Forms.FormWindowState.Normal
'					BJPERDAT.PeriodeBoekjaar.Focus()
'				End If

'			Case 1
'				If DatumFout(TekstInfo(1).Text) Then
'					TekstInfo(1).Text = Rdt.Value
'					TekstInfo(1).Focus()
'				Else
'					TekstInfo(2).Text = VValdag(TekstInfo(1).Text, vBibTekst(FlLeverancier, "#vs04 #"))
'					TekstInfo(0).Text = Rdt.Value
'				End If
'				If DatumKey(TekstInfo(1).Text) < VB.Left(BoekjaarVanTot.Value, 8) Or DatumKey(TekstInfo(1).Text) > VB.Right(BoekjaarVanTot.Value, 8) Then
'					Msg = "Datum aankoopdocument valt BUITEN het actieve boekjaar." & vbCr
'					Msg = Msg & "De optie 'boekhoudcontrole' in balans leveranciers zal" & vbCr
'					Msg = Msg & "mogelijk niet goed functioneren." & vbCr & vbCr
'					Msg = Msg & "Controleer eventueel."
'					MsgBox(Msg, MsgBoxStyle.Exclamation)
'				End If

'			Case 2
'				If DatumFout(TekstInfo(2).Text) Then
'					TekstInfo(2).Text = VValdag(TekstInfo(1).Text, vBibTekst(FlLeverancier, "#vs04 #"))
'					TekstInfo(2).Focus()
'				End If

'			Case 3
'				If VB.Left(TekstInfo(Index).Text, 3) <> "440" Then
'					TekstInfo(Index).Text = LeverancierRekening.Value
'					Beep()
'					TekstInfo(Index).Focus()
'					Exit Sub
'				End If
'				bGet(FlRekening, 0, vSet(TekstInfo(Index).Text, 7))
'				If Ktrl Then
'					Beep()
'					TekstInfo(Index).Text = LeverancierRekening.Value
'					TekstInfo(Index).Focus()
'				End If

'			Case 10
'				If VB.Left(TekstInfo(Index).Text, 6) <> VB.Left(rbtwVAK(4), 6) Then
'					TekstInfo(Index).Text = rbtwVAK(4)
'					Beep()
'					TekstInfo(Index).Focus()
'					Exit Sub
'				End If
'				bGet(FlRekening, 0, vSet(TekstInfo(Index).Text, 7))
'				If Ktrl Then
'					Beep()
'					TekstInfo(Index).Text = rbtwVAK(4)
'					TekstInfo(Index).Focus()
'				End If

'			Case 4
'				If vBibTekst(FlLeverancier, "#v017 #") = "1" Then
'					If BankOk(TekstInfo(4).Text) Then
'					Else
'						Beep()
'						On Error Resume Next
'						SnelHelpPrint("Gestructureerde betaalreferte onjuist !", blLogging)
'						TekstInfo(4).Text = "OGM onjuist"
'						On Error GoTo 0
'						Exit Sub
'					End If
'				End If
'			Case 5
'				If AankoopFlg = 1 And AankoopOptie(1).Checked = True Then
'					If Val(TekstInfo(5).Text) <> 0 Then
'						KtrlBox = MsgBox("De aanbeveling door meeste BTW-diensten om bij creditnota E.U. géén B.T.W op te nemen negeren", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1)
'						If KtrlBox = MsgBoxResult.Yes Then
'							TekstInfo(5).Text = "0"
'						End If
'					End If
'				ElseIf AankoopFlg = 1 And AankoopOptie(1).Checked = False Then 
'					If Val(TekstInfo(5).Text) = 0 Then
'						MsgBox("Respecteer de aanbeveling door de BTW-diensten om bij factuur E.U. de B.T.W. zelf uit te rekenen en zowel AFTREKBAAR als VERSCHULDIGD (0-operatie dus...) het toepasbaar B.T.W. bedrag mee te delen !", MsgBoxStyle.Exclamation)
'						TekstInfo(5).Focus()
'						Exit Sub
'					Else
'						TekstInfo(7).Text = TekstInfo(5).Text
'					End If
'				End If

'			Case 11
'				Me.cbUpdateLeverancier.Visible = False
'				If TekstInfo(11).Text = "" Then
'					Stop
'				End If
'				If Not BankOk(TekstInfo(11).Text) Then
'					TekstInfo(11).Mask = ""
'					TekstInfo(11).Text = ""
'					TekstInfo(11).Mask = "###-#######-##"
'				Else
'					Me.cbUpdateLeverancier.Visible = True
'				End If

'		End Select

'	End Sub

'	Private Function WegBoekFout() As Short

'		Dim TotaalBedrag As Decimal
'		Dim Bedrag As Decimal
'		Dim dInvest As Decimal
'		Dim dPrive As Decimal
'		Dim dAlKost As Decimal
'		Dim dHandel As Decimal

'		Dim AantalStuks As Single
'		Dim T As Short

'		Dim DVT99 As String
'		Dim LokRekening As New VB6.FixedLengthString(7)

'		bGet(FlLeverancier, 0, VB.Left(LeverancierInfo.Text, 12))
'		If Ktrl Then
'			WegBoekFout = True
'			Exit Function
'		Else
'			RecordToVeld(FlLeverancier)
'			dMuntL = Val(TekstInfo(9).Text)
'		End If

'		'gewijzigd voor scanning
'		WegBoekFout = False
'		dKtrlCumul = 0 : dKtrlBEF = 0 : dKtrlEUR = 0
'		frmBoeking.Close()
'		frmBoeking.Hide()
'		TLBRecord(FlJournaal) = ""
'		TLBRecord(Fldokument) = ""
'		'bijgevoegd voor scanning
'		If rsMAR(Fldokument).State = ADODB.ObjectStateEnum.adStateClosed Then
'			Ktrl = bOpen(Fldokument)
'		End If
'		rsMAR(Fldokument).AddNew()

'		vBib(FlJournaal, "L" & vBibTekst(FlLeverancier, "#A110 #"), "v034")
'		'19
'		vBib(FlJournaal, DatumKey(TekstInfo(0).Text), "v066")
'		vBib(FlJournaal, dokumentSleutel.Value, "v033")
'		vBib(FlJournaal, DatumKey(TekstInfo(1).Text), "v035")
'		vBib(FlJournaal, (TekstInfo(3).Text), "v069")

'		vBib(Fldokument, dokumentSleutel.Value, "v033")
'		vBib(Fldokument, "L" & vBibTekst(FlLeverancier, "#A110 #"), "v034")
'		vBib(Fldokument, DatumKey(TekstInfo(1).Text), "v035")
'		vBib(Fldokument, DatumKey(TekstInfo(2).Text), "v036")
'		vBib(Fldokument, (TekstInfo(4).Text), "v039")
'		vBib(Fldokument, Dec(dMuntL, "###.##########"), "v040")
'		vBib(Fldokument, vBibTekst(FlLeverancier, "#vs03 #"), "vs03")
'		vBib(FlJournaal, vBibTekst(FlLeverancier, "#A100 #"), "v067")
'		For T = 0 To AankoopDetail.Items.Count - 1
'			AankoopDetail.SelectedIndex = T
'			LokRekening.Value = VB.Left(AankoopDetail.Text, 7)
'			vBib(FlJournaal, LokRekening.Value, "v019")
'			bGet(FlRekening, 0, LokRekening.Value)
'			If Ktrl Then
'				WegBoekFout = True
'				Exit Function
'			End If
'			Bedrag = Val(Mid(AankoopDetail.Text, 50, 12))
'			TotaalBedrag = TotaalBedrag + Bedrag
'			If AankoopOptie(0).Checked = True Then
'				'factuur
'				vBib(FlJournaal, Dec(Bedrag, MaskerEURBH), "v068")
'			ElseIf AankoopOptie(1).Checked = True Then 
'				'creditnota
'				vBib(FlJournaal, Dec(-Bedrag, MaskerEURBH), "v068")
'			Else
'				MsgBox("logicafout")
'			End If

'			vBib(FlJournaal, "", "v102")
'			If Len(AankoopDetail.Text) > 62 Then

'				bGet(FlProdukt, 0, Mid(AankoopDetail.Text, 63, 13))
'				If Ktrl Then
'					MsgBox("Onverwacht situatie")
'					WegBoekFout = True
'					Exit Function
'				Else
'					RecordToVeld(FlProdukt)
'					vBib(FlJournaal, Mid(AankoopDetail.Text, 77, 30), "v067")
'					vBib(FlJournaal, Mid(AankoopDetail.Text, 63, 13), "v102")
'					AantalStuks = Val(Mid(AankoopDetail.Text, 77 + 41, 10))
'					If AankoopOptie(0).Checked = True Then
'						'IseenFactuur
'						'AankoopPrijs
'						vBib(FlProdukt, Str(Bedrag / AantalStuks), "e113")
'						'Leveranciernummer
'						vBib(FlProdukt, FVT(FlLeverancier, 0), "v124")
'						'Aantal stuks aankoop bijvoegen
'						vBib(FlProdukt, Str(AantalStuks + Val(vBibTekst(FlProdukt, "#v119 #"))), "v119")
'						'Totaal bedrag bijtellen
'						vBib(FlProdukt, Str(Bedrag + Val(vBibTekst(FlProdukt, "#e121 #"))), "e121")
'						'Laatste kostenrekening onthouden
'						vBib(FlProdukt, LokRekening.Value, "v116")
'					ElseIf AankoopOptie(1).Checked = True Then 
'						'IsCreditnota
'						'Aantal stuks aankoop aftrekken
'						vBib(FlProdukt, Str(-AantalStuks + Val(vBibTekst(FlProdukt, "#v119 #"))), "v119")
'						'Totaal bedrag aftrekken
'						vBib(FlProdukt, Str(-Bedrag + Val(vBibTekst(FlProdukt, "#e121 #"))), "e121")
'					Else
'						MsgBox("logicafout")
'					End If
'					bUpdate(FlProdukt, 0)
'					If Ktrl Then
'						MsgBox("Onverwacht situatie")
'						WegBoekFout = True
'						Exit Function
'					End If
'				End If
'			End If

'			'grens 0
'			If LokRekening.Value >= VB.Left(GrensDetail(0), 7) And LokRekening.Value <= VB.Right(GrensDetail(0), 7) Then
'				dInvest = dInvest + Bedrag

'				'grens 1
'			ElseIf LokRekening.Value >= VB.Left(GrensDetail(1), 7) And LokRekening.Value <= VB.Right(GrensDetail(1), 7) Then 
'				dPrive = dPrive + Bedrag

'				'grens 2
'			ElseIf LokRekening.Value >= VB.Left(GrensDetail(2), 7) And LokRekening.Value <= VB.Right(GrensDetail(2), 7) Then 
'				dHandel = dHandel + Bedrag

'				'grens 3
'			ElseIf LokRekening.Value >= VB.Left(GrensDetail(3), 7) And LokRekening.Value <= VB.Right(GrensDetail(3), 7) Then 
'				dAlKost = dAlKost + Bedrag
'			Else
'				MsgBox("Stop in begrenzing")
'			End If
'			'1310 IF Left(svkf(1),2)="ON"THEN 1525
'			bInsert(FlJournaal, 0)
'			If Ktrl Then
'				WegBoekFout = True
'				Exit Function
'			End If
'		Next 
'		vBib(FlJournaal, vBibTekst(FlLeverancier, "#A100 #"), "v067")

'		vBib(Fldokument, (TekstInfo(5).Text), "v045")
'		'If Ar = 3 Then
'		'    vBib Fldokument, "0", "v048"
'		'    vBib Fldokument, "0", "v049"
'		'    vBib Fldokument, "0", "v046"
'		'    vBib Fldokument, "0", "v047"
'		'Else
'		vBib(Fldokument, Str(dInvest), "v048")
'		vBib(Fldokument, Str(dPrive + Val(TekstInfo(8).Text)), "v049")
'		vBib(Fldokument, Str(dHandel), "v046")
'		vBib(Fldokument, Str(dAlKost), "v047")
'		'End If
'		DVT99 = Str(dInvest + dAlKost + dHandel + dPrive)

'		If Medekontraktant.CheckState Then
'			vBib(Fldokument, (TekstInfo(7).Text), "v043")
'			If Ar = 1 Then
'				vBib(Fldokument, DVT99, "v053")
'			Else
'				vBib(Fldokument, DVT99, "v051")
'			End If
'		Else
'			If Medekontraktant.CheckState = 0 And AankoopFlg = 0 Then
'				If Ar = 3 Then
'					vBib(Fldokument, DVT99, "v051")
'				End If
'			End If
'		End If
'		If AankoopFlg = 1 Then
'			vBib(Fldokument, (TekstInfo(7).Text), "v042")
'			If Ar = 1 Then
'				vBib(Fldokument, DVT99, "v052")
'			Else
'				vBib(Fldokument, DVT99, "v050")
'			End If
'		End If
'		If AankoopFlg = 2 Then
'			vBib(Fldokument, (TekstInfo(7).Text), "v044")
'			If Ar = 1 Then
'				MsgBox("in pseudo vak 88 wordt " & DVT99 & " bijgevoegd.  Bij de eigenlijke BTW aangifte dient U de cijfers van kolom '88!'  bij te tellen bij vak 87", MsgBoxStyle.Information)
'				vBib(Fldokument, DVT99, "v054")
'			Else
'				vBib(Fldokument, DVT99, "v051")
'			End If
'		End If

'		If Val(TekstInfo(5).Text) <> 0 Then
'			If Ar = 3 Then
'				vBib(FlJournaal, Dec(-Val(TekstInfo(5).Text), MaskerEURBH), "v068")
'				vBib(FlJournaal, rbtwVAK(5), "v019")
'			Else
'				vBib(FlJournaal, Dec(Val(TekstInfo(5).Text), MaskerEURBH), "v068")
'				vBib(FlJournaal, vSet(TekstInfo(10).Text, 7), "v019")
'			End If
'			bInsert(FlJournaal, 0)
'		End If

'		If AankoopFlg = 0 Then
'			If Medekontraktant.CheckState Then
'				If Ar = 1 Then
'					vBib(FlJournaal, Dec(-Val(TekstInfo(7).Text), MaskerEURBH), "v068")
'				Else
'					vBib(FlJournaal, Dec(Val(TekstInfo(7).Text), MaskerEURBH), "v068")
'				End If
'				FVT(FlJournaal, 1) = rbtwVAK(2)
'				vBib(FlJournaal, rbtwVAK(2), "v019")
'				bInsert(FlJournaal, 0)
'			End If
'			GoTo Label1440
'		End If

'		If AankoopFlg = 2 Then
'			If Ar = 1 Then
'				vBib(FlJournaal, Dec(-Val(TekstInfo(7).Text), MaskerEURBH), "v068")
'			Else
'				vBib(FlJournaal, Dec(Val(TekstInfo(7).Text), MaskerEURBH), "v068")
'			End If
'			vBib(FlJournaal, rbtwVAK(3), "v019")
'		Else
'			If Ar = 1 Then
'				vBib(FlJournaal, Dec(-Val(TekstInfo(7).Text), MaskerEURBH), "v068")
'			Else
'				vBib(FlJournaal, Dec(Val(TekstInfo(7).Text), MaskerEURBH), "v068")
'			End If
'			vBib(FlJournaal, rbtwVAK(1), "v019")
'		End If
'		bInsert(FlJournaal, 0)

'Label1440: 
'		If Val(TekstInfo(8).Text) <> 0 Then
'			If Ar = 3 Then
'				vBib(FlJournaal, Dec(-Val(TekstInfo(8).Text), MaskerEURBH), "v068")
'			Else
'				vBib(FlJournaal, Dec(Val(TekstInfo(8).Text), MaskerEURBH), "v068")
'			End If
'			vBib(FlJournaal, PriveRekening.Value, "v019")
'			bInsert(FlJournaal, 0)
'		End If

'		DVT99 = Str(Val(DVT99) + Val(TekstInfo(5).Text) + Val(TekstInfo(8).Text) - Val(TekstInfo(7).Text))
'		If Ar = 1 Then
'			vBib(FlJournaal, Dec(-Val(DVT99), MaskerEURBH), "v068")
'		Else
'			vBib(FlJournaal, Dec(Val(DVT99), MaskerEURBH), "v068")
'		End If
'		vBib(FlJournaal, vSet(TekstInfo(3).Text, 7), "v019")
'		bInsert(FlJournaal, 0)

'		If XisEuroWisBEF = False Then
'			vBib(Fldokument, DVT99, "v249")
'		Else
'			vBib(Fldokument, Str(System.Math.Round(CDbl(DVT99) / Euro, 2)), "v249")
'		End If

'		If GeScanBestand <> "" Then
'			FileToBlob(rsMAR(Fldokument).Fields("bstBLOB37"), GeScanBestand)
'			rsMAR(Fldokument).Fields("bstndNaam37").Value = GeScanBestand
'			rsMAR(Fldokument).Fields("typeZending37").Value = Mid(GeScanBestand, InStr(GeScanBestand, ".") + 1)
'		End If
'		bInsert(Fldokument, 0)

'		If dKtrlCumul <> 0 Then
'			frmBoeking.cmdBoeken.Enabled = False
'			MsgBox("LogikaFout bij vierkantskontrole journaal." & vbCrLf & vbCrLf & "Deze verrichting wordt geannuleerd.  Controleer zelf eerst en/of raadpleeg ons.")
'			frmBoeking.ShowDialog()
'			WegBoekFout = True
'		ElseIf JournaalLocked = True Then 
'			frmBoeking.cmdBoeken.Enabled = False
'			frmBoeking.ShowDialog()
'			WegBoekFout = True
'		Else
'			Select Case VB.Left(Mim.cmdWegBoekModus.Text, 1)
'				Case "0"
'				Case "1"
'					If dKtrlBEF Or dKtrlEUR Then
'						frmBoeking.ShowDialog()
'					End If
'				Case "2"
'					frmBoeking.ShowDialog()
'				Case Else
'					MsgBox("situatie...")
'			End Select
'			If dKtrlCumul Then WegBoekFout = True
'		End If

'	End Function
'	Function InstalleerRecenteCrediteuren() As Short

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'		Dim rsRecent As ADODB.Recordset
'		rsRecent = New ADODB.Recordset
'		rsRecent.CursorLocation = ADODB.CursorLocationEnum.adUseClient
'		rsRecent.Open("SELECT DISTINCT v067 AS Naam, Mid(v034,2) AS IdCode FROM Journalen WHERE Mid(v066,1,4)>=2002 AND v033 Like 'A%'", adntDB, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
'		MsgBox(rsRecent.RecordCount & " leveranciers aangewend laatste 2 jaren", MsgBoxStyle.Information)
'		Dim itmX As System.Windows.Forms.ListViewItem
'		ListView1.Items.Clear()

'		Do While Not rsRecent.EOF
'			' Add a ListItem object.
'			itmX = ListView1.Items.Add(rsRecent.Fields("Naam").Value)
'			'UPGRADE_WARNING: Lower bound of collection itmX has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
'			If itmX.SubItems.Count > 1 Then
'				itmX.SubItems(1).Text = rsRecent.Fields("idCode").Value
'			Else
'				itmX.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rsRecent.Fields("idCode").Value))
'			End If
'			rsRecent.MoveNext()
'		Loop 
'		rsRecent.Close()
'		'UPGRADE_NOTE: Object rsRecent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
'		rsRecent = Nothing
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		ListView1.Focus()

'	End Function

'	' Copy a file's contents into a BLOB field.
'	Function FileToBlob(ByRef fld As ADODB.Field, ByRef filename As String, Optional ByRef ChunkSize As Integer = 8192) As Short
'		Dim fnum As Short
'		Dim bytesLeft, bytes As Integer
'		Dim tmp() As Byte

'		' Raise an error if the field doesn't support GetChunk.
'		If (fld.Attributes And ADODB.FieldAttributeEnum.adFldLong) = 0 Then
'			Err.Raise(1001,  , "Field doesn't support the GetChunk method.")
'		End If
'		' Open the file; raise an error if the file doesn't exist.
'		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		If Dir(filename) = "" Then Err.Raise(53,  , "File not found")

'		fnum = FreeFile
'		FileOpen(fnum, filename, OpenMode.Binary)
'		' Read the file in chunks, and append data to the field.
'		bytesLeft = LOF(fnum)
'		Do While bytesLeft
'			bytes = bytesLeft
'			If bytes > ChunkSize Then bytes = ChunkSize
'			'UPGRADE_WARNING: Lower bound of array tmp was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
'			ReDim tmp(bytes)
'			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'			FileGet(1, tmp)
'			fld.AppendChunk(tmp)
'			bytesLeft = bytesLeft - bytes
'		Loop 
'		FileClose(fnum)

'	End Function


'	Function ktrlBLOBRecord() As Boolean

'		Dim ktrlString As String

'		Err.Clear()
'		On Error Resume Next

'		'nieuwe poging 03/2007

'		ktrlBLOBRecord = True
'		ktrlString = rsMAR(Fldokument).Fields("bstndNaam37").Name

'		'bstndNaam
'		'typeZending 'TIF, PDF, enz...
'		'bstBLOB inhoud bestand
'		If Err.Number = 3265 Then
'			rsMAR(Fldokument).Close()
'			Msg = "ALTER TABLE Dokumenten ADD COLUMN bstndNaam37 varchar;"
'			Err.Clear()
'			adntDB.Execute(Msg)
'			If Err.Number Then
'				MsgBox("Foutmelding bron: " & Err.Source & vbCrLf & "Foutkodenummer: " & Err.Number & vbCrLf & vbCrLf & "Foutmelding omschrijving:" & vbCrLf & Err.Description)
'			Else
'				MsgBox(Msg, MsgBoxStyle.Information, "Met succes")
'			End If
'			Msg = "ALTER TABLE Dokumenten ADD COLUMN typeZending37 TEXT(5);"
'			Err.Clear()
'			adntDB.Execute(Msg)
'			If Err.Number Then
'				MsgBox("Foutmelding bron: " & Err.Source & vbCrLf & "Foutkodenummer: " & Err.Number & vbCrLf & vbCrLf & "Foutmelding omschrijving:" & vbCrLf & Err.Description)
'			Else
'				MsgBox(Msg, MsgBoxStyle.Information, "Met succes")
'			End If
'			Msg = "ALTER TABLE Dokumenten ADD COLUMN bstBLOB37 OLEobject;"
'			Err.Clear()
'			adntDB.Execute(Msg)
'			If Err.Number Then
'				MsgBox("Foutmelding bron: " & Err.Source & vbCrLf & "Foutkodenummer: " & Err.Number & vbCrLf & vbCrLf & "Foutmelding omschrijving:" & vbCrLf & Err.Description)
'			Else
'				MsgBox(Msg, MsgBoxStyle.Information, "Met succes")
'			End If
'			MsgBox("Belangrijke velden werden toegevoegd. Gelieve het bedrijf opnieuw te openen a.u.b.")
'			ktrlBLOBRecord = False
'		End If

'	End Function
'End Class