Public Class frmAankoopInvesteerFiche
    Private Sub FrmAankoopInvesteerFiche_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Friend Class InvesteringsFiche
'	Inherits System.Windows.Forms.Form
'	'UPGRADE_NOTE: DefInt A-Z statement was removed. Variables were explicitly declared as type Short. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92AFD3E3-440D-4D49-A8BF-580D74A8C9F2"'

'	Dim NietAanwezig As Short

'	Private Sub Annuleren_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Annuleren.Click

'		Msg = "InvesteringFiche negeren !  Bent U zeker ?"
'		Ktrl = MsgBox(Msg, 292, "Investeringsfiche overslaan")
'		If Ktrl = 6 Then
'			Me.Close()
'		End If

'	End Sub

'	Private Sub InvesteringsFiche_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
'		Dim T As Short
'		Dim Teller As Short
'		Dim RekeningTest As New VB6.FixedLengthString(7)
'		Dim RekeningNaam As New VB6.FixedLengthString(40)
'		Dim RekeningTest2 As String

'		TekstInfo(3).Text = vBibTekst(FlRekening, "#v019 #")
'		RekeningTest2 = RTrim(vBibTekst(FlRekening, "#v019 #"))
'		TekstInfo(0).Text = Mid(GridText, 1, 10)
'		TekstInfo(1).Text = Dec(Val(Mid(GridText, 11, 12)), MaskerEURBH)
'		TLBRecord(FlAllerlei) = ""

'		Teller = Len(RekeningTest2)
'		Do While Teller >= 0
'			If Mid(RekeningTest2, Teller, 1) = "0" Then
'				Mid(RekeningTest2, Teller, 1) = "9"
'				Exit Do
'			Else
'				Teller = Teller - 1
'			End If
'		Loop 
'		If Teller = 0 Then
'			MsgBox("Onlogika in investeringsrekening !")
'			Ok.Enabled = False
'		Else
'			RekeningTest.Value = RekeningTest2
'			TekstInfo(4).Text = RekeningTest.Value
'			bGet(FlRekening, 0, RekeningTest.Value)
'			If Ktrl Then
'				RekeningNaam.Value = vBibTekst(FlRekening, "#v020 #")
'				Msg = "Afschrijving op " & RTrim(RekeningNaam.Value) & vbCrLf
'				Msg = Msg & "Rekeningnr. : " & RekeningTest.Value & " bestaat nog niet." & vbCrLf & vbCrLf
'				Msg = Msg & "Wordt hierna automatisch aangemaakt..."
'				MsgBox(Msg, 0, "Aanmaak afschrijfrekening")

'				TLBRecord(FlRekening) = ""
'				vBib(FlRekening, RekeningTest.Value, "v019")
'				vBib(FlRekening, "Afschrijving op " & RTrim(RekeningNaam.Value), "v020")
'				vBib(FlRekening, "O", "v032")
'				bInsert(FlRekening, 0)
'			End If
'		End If

'		bGet(FlAllerlei, 1, vSet("18" & RekeningTest.Value, 20))
'		NietAanwezig = Ktrl
'		If Ktrl Then
'			TekstInfo(6).Text = ""
'			For T = 7 To 8
'				TekstInfo(T).Text = Dec(0, MaskerEURBH)
'			Next 
'			TekstInfo(2).Text = Dec(5, "###")
'			TekstInfo(5).Text = "6300000"
'			Versneld.CheckState = System.Windows.Forms.CheckState.Checked
'		Else
'			RecordToVeld(FlAllerlei)
'			TekstInfo(2).Text = Dec(Val(vBibTekst(FlAllerlei, "#v082 #")), "###") 'lineair over aantal jaar
'			TekstInfo(6).Text = (vBibTekst(FlAllerlei, "#v083 #")) 'datum vorige bewerking
'			TekstInfo(7).Text = Dec(Val(vBibTekst(FlAllerlei, "#v084 #")), MaskerEURBH) 'totaal vorige bewerkingen
'			TekstInfo(8).Text = Dec(Val(vBibTekst(FlAllerlei, "#v085 #")), MaskerEURBH) 'reeds afgeschreven
'			Versneld.CheckState = Val(vBibTekst(FlAllerlei, "#v086 #")) 'versnelde afschrijving
'			TekstInfo(4).Text = vBibTekst(FlAllerlei, "#v087 #")
'			TekstInfo(5).Text = vBibTekst(FlAllerlei, "#v088 #")
'			If TekstInfo(6).Text = TekstInfo(0).Text Then
'				Msg = "Opgelet, laatste bijwerking op dezelfde dag" & vbCrLf
'				Msg = Msg & "reeds aanwezig.  Vermijdt dubbele optellingen !" & vbCrLf & vbCrLf
'				Msg = Msg & "Kies Sluiten indien U zopas de fiche reeds bijgewerkt hebt."
'				MsgBox(Msg, 48, "Investeringsfiche éénzelfde datum")
'			ElseIf Not DatumKtrl(TekstInfo(6).Text, TekstBoekjaar) Then 
'				Msg = "Opgelet, U probeert een investeringsfiche" & vbCrLf
'				Msg = Msg & "van een ander boekjaar bij te werken !" & vbCrLf & vbCrLf
'				Msg = Msg & "Kies Sluiten en neem de juiste rekening."
'				MsgBox(Msg, 16, "Gebruikersfout !")
'				Ok.Enabled = False
'			End If
'		End If

'	End Sub

'	Private Sub InvesteringsFiche_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

'		bClose(FlAllerlei)

'	End Sub

'	Private Sub Ok_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ok.Click
'		Dim TempoTel As Short
'		Dim Ktrl2 As Short

'		vBib(FlAllerlei, (TekstInfo(3).Text), "v019")
'		vBib(FlAllerlei, (TekstInfo(2).Text), "v082")
'		vBib(FlAllerlei, (TekstInfo(0).Text), "v083")
'		vBib(FlAllerlei, Dec(Val(TekstInfo(1).Text) + Val(TekstInfo(7).Text), MaskerEURBH), "v084")
'		'v085 TekstInfo(8).Text reeds afgeschreven mag niet gewijzigd worden
'		vBib(FlAllerlei, VB6.Format(Versneld.CheckState, "0"), "v086")
'		vBib(FlAllerlei, (TekstInfo(4).Text), "v087")
'		vBib(FlAllerlei, (TekstInfo(5).Text), "v088")
'		vBib(FlAllerlei, "18" & vBibTekst(FlAllerlei, "#v087 #"), "v005")
'		Msg = "Informatielijn opslaan..." & vbCrLf
'		Msg = Msg & "Bent U zeker ?"
'		Ktrl2 = MsgBox(Msg, 292, "Fiche bijwerken/wegschrijven")
'		If Ktrl2 = 6 Then
'			If NietAanwezig Then
'				bInsert(FlAllerlei, 1)
'			Else
'				bUpdate(FlAllerlei, 1)
'			End If
'			Me.Close()
'		End If

'	End Sub

'	Private Sub TekstInfo_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstInfo.Enter
'		Dim Index As Short = TekstInfo.GetIndex(eventSender)

'		TekstInfo(Index).SelectionLength = Len(TekstInfo(Index).Text)

'	End Sub

'	Private Sub TekstInfo_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstInfo.Leave
'		Dim Index As Short = TekstInfo.GetIndex(eventSender)
'		Dim TempoBdrg As Integer

'		Select Case Index
'			Case 0
'				If DatumFout(TekstInfo(Index).Text) Then
'					TekstInfo(Index).Text = Mid(GridText, 1, 10)
'					Beep()
'				End If
'			Case 1, 8
'				TekstInfo(Index).Text = Dec(Val(TekstInfo(Index).Text), MaskerEURBH)
'			Case 2
'				TempoBdrg = Val(TekstInfo(Index).Text)
'				If TempoBdrg < 1 Or TempoBdrg > 50 Then
'					Beep()
'					TempoBdrg = 5
'				End If
'				TekstInfo(Index).Text = Dec(TempoBdrg, "##0")
'			Case 5
'				If VB.Left(TekstInfo(Index).Text, 3) <> "630" Then
'					Beep()
'					TekstInfo(Index).Text = "6300000"
'					TekstInfo(Index).Focus()
'					Exit Sub
'				End If
'		End Select

'	End Sub
'End Class