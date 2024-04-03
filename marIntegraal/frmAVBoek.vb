Option Strict Off
Option Explicit On

Public Class AVBoek
	Dim getal As Integer

	Dim psTekst(5) As String
	Dim RapportVeldNr(23) As Short
	Dim RapportManier(23) As Short
	Dim KolomTotaal(17) As Decimal
	Dim T As Short

	Dim LFontSize(20) As Single
	Dim LAantalL(20) As Short
	Dim FontDefChanged As Short

	Dim LijstNaam As String
	Dim rFlag As String
	Dim r(10) As String
	Dim FlBtw As Short
	Dim DBVT(23) As Double
	Dim DDVT(23) As Double

	Dim BedragForfait(100) As Double
	Dim PctForfait(100) As Double
	Dim BtwForfait(100) As Single
	Dim KortingForfait(100) As Single
	Dim VakForfait(3) As Double
	Dim BtwTotaalForfait As Double

	Dim ForFait As Short
	Dim ForfaitBtw As Double

	Dim Ar As Short
	Dim tMaxVeld As Short
	Dim VeldTXT(17) As String
	Dim aa As String

	Dim MaskHier As String

	Dim rsAVBoekHier As ADODB.Recordset
	Dim rsJourHier As ADODB.Recordset

	Private Sub AVBoek_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		If bhEuro Then
			MaskHier = "#####0.00"
		Else
			MaskHier = "########0"
		End If

		tbDatumDrukken.Text = Rdt
			   
		Select Case aIndex
			Case FlLeverancier
				LijstNaam = "Aankoopboek"
				aIndex = FlLeverancier 
			Case FlKlant
				LijstNaam = "Verkoopboek"
				aIndex = FlKlant 
			Case Else
				MsgBox("Stop")
		End Select
		Me.Text = LijstNaam

		agfControle
		rbFactuur.Checked = True 

	End Sub

	Sub AgfControle

		Dim PeriodeSleutel As String 
		Dim T As Integer 
		Dim PeriodeMax As Integer 

		Ktrl = 0
		PeriodeMax = frmBJPERDAT.PeriodeBoekjaar.Items.Count + 1
		Do While PeriodeMax > frmBJPERDAT.PeriodeBoekjaar.SelectedIndex + 1
			PeriodeSleutel = "17" & frmBJPERDAT.Boekjaar.Text & Format(PeriodeMax, "00")
			bGet(FlAllerlei, 1, PeriodeSleutel)
			If Ktrl Then
				TLBRecord(FlAllerlei) = ""
				vBib(FlAllerlei, (frmBJPERDAT.Boekjaar.Text), "v090")
				vBib(FlAllerlei, Format(PeriodeMax, "00"), "v091")
				vBib(FlAllerlei, "17" & vBibTekst(FlAllerlei, "#v090 #") & vBibTekst(FlAllerlei, "#v091 #"), "v005")
				bInsert(FlAllerlei, 1)
			Else
				RecordToVeld(FlAllerlei)
				getal = 0
				For T = 92 To 99
					getal = getal + Val(vBibTekst(FlAllerlei, "#v" & Format(T, "000") & " #"))
				Next 
				If getal Then
					getal = PeriodeMax
					PeriodeMax = 0
					Exit Do
				End If
			End If
			PeriodeMax = PeriodeMax - 1
		Loop 
jump: 
		If getal Then
			MsgBox("Periode " & Format(getal, "00") & " reeds afgesloten...")
			Drukken.Visible = False
			Exit Sub
		Else
			PeriodeSleutel = "17" & frmBJPERDAT.Boekjaar.Text & Format(frmBJPERDAT.PeriodeBoekjaar.SelectedIndex + 1, "00")
			bGet(FlAllerlei, 1, PeriodeSleutel)
			If Ktrl Then
				TLBRecord(FlAllerlei) = ""
				vBib(FlAllerlei, (frmBJPERDAT.Boekjaar.Text), "v090")
				vBib(FlAllerlei, Format(frmBJPERDAT.PeriodeBoekjaar.SelectedIndex + 1, "00"), "v091")
				vBib(FlAllerlei, "17" & vBibTekst(FlAllerlei, "#v090 #") & vBibTekst(FlAllerlei, "#v091 #"), "v005")
				bInsert(FlAllerlei, 1)
				GoTo jump
			Else
				RecordToVeld(FlAllerlei)
			End If
		End If

		If Mid(String99(Lees, 20), 1, 1) = "4" Then
			ForFait = 1
		Else
			ForFait = 0
		End If		
		
	End Sub

	Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

		Close

	End Sub

	Private Sub RbFactuur_CheckedChanged(sender As Object, e As EventArgs) Handles rbFactuur.CheckedChanged

		FactuurCreditnotaCheck 

	End Sub

	Private Sub RbCreditnota_CheckedChanged(sender As Object, e As EventArgs) Handles rbCreditnota.CheckedChanged

		FactuurCreditnotaCheck 

	End Sub

	Sub FactuurCreditnotaCheck

		Select Case aIndex
			Case FlLeverancier
				T = 0
			Case FlKlant
				T = 10
			Case Else
				MsgBox("Stop")
		End Select

		getal = 0
		Select Case rbFactuur.Checked 
			Case True 'Faktuur
				Fl99Record = String99(Lees, 1 + T)
				tbTOT.Text = Format(Val(Fl99Record), "00000")
				Fl99Record = String99(Lees, 2 + T)
				If Format(Val(Fl99Record), "00000") = tbTOT.Text Then
					Drukken.Enabled = False
					TekstVan.Text = Format(Val(Fl99Record), "00000")
				Else
					Drukken.Enabled = True
					TekstVan.Text = Format(Val(Fl99Record) + 1, "00000")
				End If
				If aIndex = FlLeverancier Then
					Ar = 1
					getal = Val(vBibTekst(FlAllerlei, "#v092 #")) + Val(vBibTekst(FlAllerlei, "#v093 #"))
				Else
					Ar = 12
					getal = Val(vBibTekst(FlAllerlei, "#v096 #")) + Val(vBibTekst(FlAllerlei, "#v097 #"))
				End If
			Case Else
				Fl99Record = String99(Lees, 3 + T)
				tbTOT.Text = Format(Val(Fl99Record), "00000")
				Fl99Record = String99(Lees, 4 + T)
				If Format(Val(Fl99Record), "00000") = tbTOT.Text Then
					Drukken.Enabled = False
					TekstVan.Text = Format(Val(Fl99Record), "00000")
				Else
					Drukken.Enabled = True
					TekstVan.Text = Format(Val(Fl99Record) + 1, "00000")
				End If
				If aIndex = FlLeverancier Then
					Ar = 3
					getal = Val(vBibTekst(FlAllerlei, "#v094 #")) + Val(vBibTekst(FlAllerlei, "#v095 #"))
				Else
					Ar = 14
					getal = Val(vBibTekst(FlAllerlei, "#v098 #")) + Val(vBibTekst(FlAllerlei, "#v099 #"))
				End If
		End Select
		If getal Then
			MsgBox("Binnen deze periode, zijn er reeds" & vbCrLf & "dokumenten opgenomen !", 0, "BTW aangifte kontroleren a.u.b. !")
			Drukken.Enabled = False
		Else
			'Drukken.Enabled = True
		End If
	End Sub
	
	Private Sub TbDatumDrukken_Leave(sender As Object, e As EventArgs) Handles tbDatumDrukken.Leave

		If Not DatumKtrl(tbDatumDrukken.Text, TekstPeriode) Then
			Beep()
			frmBJPERDAT.WindowState = FormWindowState.Normal
			frmBJPERDAT.Focus()
			tbDatumDrukken.Focus()            
		End If

	End Sub
		
End Class



'	Private Sub CumulPrint()
'		Dim Printer As New Printer
'		Dim RekeningNaam As New VB6.FixedLengthString(30)
'		Dim Tabul As Short
'		Dim Tel As Short

'		If chkAfdrukInVenster.CheckState Then Exit Sub

'		Printer.EndDoc()
'		If Printer.Width > 12000 Then
'			Printer.FontSize = 10
'			Printer.FontName = "Courier New"
'			Printer.Print(" ")
'			Printer.FontSize = 10
'		Else
'			Printer.FontSize = 7.2
'			Printer.FontName = "Courier New"
'			Printer.Print(" ")
'			Printer.FontSize = 7.2
'		End If
'		PrintTitel()
'		PrintTotaal()

'		Printer.Print()
'		Printer.Print(TAB(2), "** CENTRALISATIE **")
'		Printer.Print("")

'		bClose(FlDummy)
'		bFirst(FlDummy, 0)
'		RecordToVeld(FlDummy)
'		If Not adoGet(FlRekening, 0, "=", VB.Left(FVT(FlDummy, 0), 7)) Then
'			RekeningNaam.Value = "Rekening reeds vernietigd !!!"
'		Else
'			RecordToVeld(FlRekening)
'			'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			RekeningNaam.Value = RV(rsMAR(FlRekening), "v020")
'		End If
'		Tabul = 0
'		Printer.Write(TAB(Tabul + 2), Dec(Val(vBibTekst(FlDummy, "#v013 #")), "####") & " x " & vSet(vBibTekst(FlDummy, "#v089 #"), 7) & " " & RekeningNaam.Value & " " & Dec(Val(vBibTekst(FlDummy, "#v068 #")), MaskHier))

'		Do 
'			bNext(FlDummy)
'			If Ktrl Then
'				Exit Do
'			End If
'			RecordToVeld(FlDummy)
'			If Not adoGet(FlRekening, 0, "=", VB.Left(FVT(FlDummy, 0), 7)) Then
'				RekeningNaam.Value = "Rekening reeds vernietigd !!!"
'			Else
'				'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'				RekeningNaam.Value = RV(rsMAR(FlRekening), "v020")
'			End If
'			If Tabul = 0 Then
'				Tabul = 56
'				Printer.Write(TAB(Tabul + 2), Dec(Val(vBibTekst(FlDummy, "#v013 #")), "####") & " x " & vSet(vBibTekst(FlDummy, "#v089 #"), 7) & " " & RekeningNaam.Value & " " & Dec(Val(vBibTekst(FlDummy, "#v068 #")), MaskHier) & vbCrLf)
'			Else
'				Tabul = 0
'				Printer.Write(TAB(Tabul + 2), Dec(Val(vBibTekst(FlDummy, "#v013 #")), "####") & " x " & vSet(vBibTekst(FlDummy, "#v089 #"), 7) & " " & RekeningNaam.Value & " " & Dec(Val(vBibTekst(FlDummy, "#v068 #")), MaskHier))
'			End If
'		Loop 

'		Dim BedragVK2 As Double
'		Dim BedragVK As Double

'		BtwTotaalForfait = 0
'		VakForfait(0) = 0
'		VakForfait(1) = 0
'		VakForfait(2) = 0
'		VakForfait(3) = 0
'		If ForFait Then
'			Printer.Write(vbCrLf & vbCrLf & vbCrLf & vbCrLf)
'			Printer.Print(TAB(2), "** FORFAITAIR STELSEL **")
'			Printer.Write(vbCrLf & vbCrLf)
'			Printer.Write(TAB(2), "FORFAITCODE", "AANKOOPBEDRAG", "FAKTOR", "VERKOOP 1", "KORTING", "VERKOOP NETTO", "BTW %", "BTW BEDRAG" & vbCrLf & vbCrLf)
'			For Tel = 0 To 39
'				If BedragForfait(Tel) <> 0 Then
'					BedragVK2 = CDbl(VB6.Format(BedragForfait(Tel) * PctForfait(Tel), "0.00"))
'					BedragVK = CDbl(VB6.Format(BedragVK2 - (BedragVK2 * KortingForfait(Tel) / 100), "0.00"))
'					Printer.Write(TAB(2), Dec(Tel, "00"), Dec(BedragForfait(Tel), "########.00"), Dec(PctForfait(Tel), "####.0000"), Dec(BedragVK2, "########.00"), Dec(BedragVK - BedragVK2, "########.00"), Dec(BedragVK, "#######.00"), Dec(BtwForfait(Tel), "###.0"))
'					ForfaitBtw = CDbl(VB6.Format(BedragVK * BtwForfait(Tel) / 100, "0.00"))
'					Printer.Write(Dec(ForfaitBtw, "########.00") & vbCrLf)
'					VakForfait(Int(Tel / 10)) = VakForfait(Int(Tel / 10)) + BedragVK
'					BtwTotaalForfait = BtwTotaalForfait + ForfaitBtw
'				End If
'			Next 
'			For Tel = 40 To 99
'				If BedragForfait(Tel) <> 0 Then
'					MsgBox("BTW aangifte Vak " & VB6.Format(System.Math.Abs(Tel / 10)) & " bestaat toch niet ?")
'				End If
'			Next 
'			Printer.Write(vbCrLf & vbCrLf & vbCrLf & vbCrLf)
'			Printer.Print(TAB(2), "** BTW VAKKEN **")
'			For Tel = 0 To 3
'				Printer.Write(TAB(2), "VAK " & Dec(Tel, "00") & " : " & Dec(VakForfait(Tel), "########.00") & vbCrLf)
'			Next 
'			Printer.Write(vbCrLf & vbCrLf)
'			Printer.Print(TAB(2), "VAK 54 : " & Dec(BtwTotaalForfait, "########.00"))
'		End If

'	End Sub

'	Private Sub DetailRekeningen()
'		Dim Printer As New Printer
'		Dim RekeningNaam As New VB6.FixedLengthString(30)
'		Dim Tabul As Short
'		Dim ForfaitNr As Short

'		If chkDetailJournaal.CheckState Then
'			If Printer.CurrentY >= Printer.Height - 1200 Then
'				Printer.NewPage()
'				Printer.FontSize = Printer.FontSize
'				Printer.Print(" ")
'				Printer.FontSize = Printer.FontSize
'				PrintTitel()
'			End If
'			Printer.Write(vbCrLf)
'			Tabul = 56
'		End If

'		Do While rsJourHier.EOF = False
'			'UPGRADE_WARNING: Couldn't resolve default property of object RV(rsAVBoekHier, v033). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			'UPGRADE_WARNING: Couldn't resolve default property of object RV(rsJourHier, v033). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			If RV(rsJourHier, "v033") = RV(rsAVBoekHier, "v033") Then
'				'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'				If VB.Left(RV(rsJourHier, "v019"), 2) = "40" Or VB.Left(RV(rsJourHier, "v019"), 2) = "44" Then
'					'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					RekeningNaam.Value = RV(rsJourHier, "v067")
'				Else
'					If Not adoGet(FlRekening, 0, "=", RV(rsJourHier, "v019")) Then
'						RekeningNaam.Value = "Rekening reeds vernietigd !!!"
'					Else
'						'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'						RekeningNaam.Value = RV(rsMAR(FlRekening), "v020")
'						If ForFait Then
'							'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'							GoSub ForFaitBerekening
'						End If
'					End If
'				End If
'				If chkDetailJournaal.CheckState Then
'					If Tabul = 0 Then
'						Tabul = 56
'						'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'						Printer.Write(TAB(Tabul + 2), RV(rsJourHier, "v019") & " " & RekeningNaam.Value & " " & Dec(RV(rsJourHier, "dece068"), MaskHier) & vbCrLf)
'						If Printer.CurrentY >= Printer.Height - 1200 Then
'							Printer.NewPage()
'							Printer.FontSize = Printer.FontSize
'							Printer.Print(" ")
'							Printer.FontSize = Printer.FontSize
'							PrintTitel()
'						End If
'					Else
'						Tabul = 0
'						'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'						Printer.Write(TAB(Tabul + 2), RV(rsJourHier, "v019") & " " & RekeningNaam.Value & " " & Dec(RV(rsJourHier, "dece068"), MaskHier))
'					End If
'				End If
'				'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'				GoSub DetailCumul
'				rsJourHier.MoveNext()
'			Else
'				Exit Do
'			End If
'		Loop 

'		If chkDetailJournaal.CheckState Then
'			If Tabul = 0 Then
'				Printer.Write(vbCrLf)
'			End If
'			If Printer.CurrentY >= Printer.Height - 1200 Then
'				Printer.NewPage()
'				Printer.FontSize = Printer.FontSize
'				Printer.Print(" ")
'				Printer.FontSize = Printer.FontSize
'				PrintTitel()
'			End If
'		End If
'		If chkAfdrukInVenster.CheckState = 0 Then
'			Printer.Write(vbCrLf)
'		End If
'		Exit Sub

'DetailCumul: 
'StartPunt: 
'		'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		bGet(FlDummy, 0, RV(rsJourHier, "v019"))
'		If Ktrl Then
'			TLBRecord(FlDummy) = ""
'			'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			vBib(FlDummy, RV(rsJourHier, "v019"), "v089")
'			vBib(FlDummy, "0", "v013")
'			vBib(FlDummy, "0", "v068")
'			bInsert(FlDummy, 0)
'			GoTo StartPunt
'		Else
'			RecordToVeld(FlDummy)
'			vBib(FlDummy, Str(Val(vBibTekst(FlDummy, "#v013 #")) + 1), "v013")
'			'UPGRADE_WARNING: Couldn't resolve default property of object RV(rsJourHier, dece068). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			vBib(FlDummy, Str(Val(vBibTekst(FlDummy, "#v068 #")) + RV(rsJourHier, "dece068")), "v068")
'			bUpdate(FlDummy, 0)
'		End If
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'ForFaitBerekening: 
'		'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		If RTrim(RV(rsMAR(FlRekening), "v216")) <> "" Then
'			'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			ForfaitNr = Val(RV(rsMAR(FlRekening), "v216"))
'			'UPGRADE_WARNING: Couldn't resolve default property of object RV(rsJourHier, dece068). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'			BedragForfait(ForfaitNr) = BedragForfait(ForfaitNr) + RV(rsJourHier, "dece068")
'			If PctForfait(ForfaitNr) = 0 Then
'				'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'				bGet(FlAllerlei, 1, vSet("21" + RV(rsMAR(FlRekening), "v216"), 20))
'				If Ktrl Then
'					'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					MsgBox("Forfaitaire Kode : " + RV(rsMAR(FlRekening), "v216") + " en waarde nog niet aanwezig.  Eerst inbrengen via diverse gebruikersfiches pér bedrijf a.u.b. !")
'				Else
'					RecordToVeld(FlAllerlei)
'					PctForfait(ForfaitNr) = Val(vBibTekst(FlAllerlei, "#v218 #"))
'					BtwForfait(ForfaitNr) = Val(Mid(fmarBoxText("002", "2", vBibTekst(FlAllerlei, "#v111 #")), 4, 4))
'					KortingForfait(ForfaitNr) = Val(vBibTekst(FlAllerlei, "#v230 #"))
'				End If
'			End If
'		End If
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'	End Sub

'	'UPGRADE_WARNING: Event chkAfdrukInVenster.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub chkAfdrukInVenster_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAfdrukInVenster.CheckStateChanged

'		If chkAfdrukInVenster.CheckState = 1 Then
'			chkDetailJournaal.CheckState = System.Windows.Forms.CheckState.Unchecked
'		End If

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
'		Dim BeginSleutel As String
'		Dim EindSleutel As String
'		Dim DummySleutel As String
'		Dim Tekst As String

'		Dim XX As Short
'		Dim LengteSleutel As Short
'		Dim sleutelIndex As Short
'		Dim Tel As Short

'		For T = 0 To 17
'			KolomTotaal(T) = 0
'		Next 
'		For T = 0 To 99
'			BedragForfait(T) = 0
'			PctForfait(T) = 0
'		Next 

'		Select Case aIndex
'			Case FlLeverancier
'				BeginSleutel = "A"
'				EindSleutel = "A"
'			Case FlKlant
'				BeginSleutel = "V"
'				EindSleutel = "V"
'			Case Else
'				MsgBox("Stop")
'		End Select
'		Select Case FaktuurCreditnota(0).Checked
'			Case -1
'				BeginSleutel = BeginSleutel & "0" & Mid(PeriodeVanTot.Value, 1, 4) & VB6.Format(Val(TekstVan.Text), "00000")
'				EindSleutel = EindSleutel & "0" & Mid(PeriodeVanTot.Value, 1, 4) & VB6.Format(Val(TekstLijn(3).Text), "00000")
'				Tekst = FaktuurCreditnota(0).Text
'			Case Else
'				BeginSleutel = BeginSleutel & "1" & Mid(PeriodeVanTot.Value, 1, 4) & VB6.Format(Val(TekstVan.Text), "00000")
'				EindSleutel = EindSleutel & "1" & Mid(PeriodeVanTot.Value, 1, 4) & VB6.Format(Val(TekstLijn(3).Text), "00000")
'				Tekst = FaktuurCreditnota(1).Text
'		End Select

'		psTekst(2) = LijstNaam & " " & Tekst & " " & Mid(Mim.Text, InStr(Mim.Text, "["))
'		psTekst(0) = TekstLijn(1).Text
'		psTekst(3) = TekstLijn(0).Text
'		InitVelden()

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'		'recordset maken
'		rsAVBoekHier = New ADODB.Recordset
'		On Error Resume Next
'		Err.Clear()
'		rsAVBoekHier.CursorLocation = ADODB.CursorLocationEnum.adUseClient

'		Msg = "SELECT * FROM dokumenten WHERE v033 >='" & BeginSleutel & "' AND v033 <= '" & EindSleutel & "' ORDER BY v033"

'		SnelHelpPrint(Msg, blLogging)
'		rsAVBoekHier.Open(Msg, adntDB, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
'		If Err.Number Then
'			MsgBox("Bron:" & vbCrLf & Err.Source & vbCrLf & vbCrLf & "Foutnummer: " & Err.Number & vbCrLf & vbCrLf & "Detail:" & vbCrLf & Err.Description)
'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal
'			Exit Sub
'		ElseIf rsAVBoekHier.RecordCount = 0 Then 
'			MsgBox("Er zijn géén dokumenten", MsgBoxStyle.Exclamation)
'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal
'			Exit Sub
'		End If

'		'recordset maken
'		rsJourHier = New ADODB.Recordset
'		On Error Resume Next
'		Err.Clear()
'		rsJourHier.CursorLocation = ADODB.CursorLocationEnum.adUseClient

'		Msg = "SELECT * FROM Journalen WHERE v033 >='" & BeginSleutel & "' AND v033 <= '" & EindSleutel & "' " & "AND IsNull(v038) ORDER BY v033"

'		SnelHelpPrint(Msg, blLogging)
'		rsJourHier.Open(Msg, adntDB, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
'		If Err.Number Then
'			MsgBox("Bron:" & vbCrLf & Err.Source & vbCrLf & vbCrLf & "Foutnummer: " & Err.Number & vbCrLf & vbCrLf & "Detail:" & vbCrLf & Err.Description)
'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal
'			Exit Sub
'		End If
'		bClose(FlDummy)
'		ClearFlDummy()
'		Ktrl = bOpen(FlDummy)
'		Me.Refresh()

'		PaginaTeller = 0
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
'		PrintTitel()


'		Do While Not rsAVBoekHier.EOF
'			PrintVelden()
'			DetailRekeningen()
'			rsAVBoekHier.MoveNext()
'		Loop 
'		PrintTotaal()
'		CumulPrint()
'		If chkAfdrukInVenster.CheckState = 0 Then
'			Printer.NewPage()
'			Printer.EndDoc()
'		End If
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		Msg = "Totaliseren voor BTW AANGIFTE.  Bent U zeker?"
'		If FaktuurCreditnota(0).Checked Then
'			Msg = Msg & vbCrLf & vbCrLf & "Opgelet !  Creditnota's niet vergeten straks..."
'		End If
'		Ktrl = MsgBox(Msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "BTW Aangifte")
'		If Ktrl = MsgBoxResult.Yes Then
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub BTWAangifte
'		End If
'		Me.Refresh()
'		Me.Activate()
'		rsAVBoekHier.Close()
'		rsJourHier.Close()
'		'UPGRADE_NOTE: Object rsAVBoekHier may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
'		rsAVBoekHier = Nothing
'		'UPGRADE_NOTE: Object rsJourHier may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
'		rsJourHier = Nothing
'		If FaktuurCreditnota(0).Checked = True Then
'			FaktuurCreditnota(1).Checked = True
'		Else
'			Me.Close()
'		End If
'		Exit Sub

'PrtHandler2: 
'		MsgBox("Kontroleer de printer.")
'		Resume 

'BTWAangifte: 
'		bGet(FlAllerlei, 1, vSet("17" & BJPERDAT.Boekjaar.Text & VB6.Format(BJPERDAT.PeriodeBoekjaar.SelectedIndex + 1, "00"), 20))
'		If Ktrl Then
'			MsgBox("Stop")
'		Else
'			RecordToVeld(FlAllerlei)
'		End If

'		'btwperiode bijvoegen vanaf 07/2008 voor Intervat
'		If Mid(PeriodeVanTot.Value, 5, 2) = Mid(PeriodeVanTot.Value, 13, 2) Then
'			'ok de periode marIntegraal staan op maandelijks
'			vBib(FlAllerlei, Mid(PeriodeVanTot.Value, 5, 2), "i001") 'werkelijke maand
'			vBib(FlAllerlei, Mid(PeriodeVanTot.Value, 1, 4), "i002") 'werkelijk jaar
'		Else
'			MsgBox("marIntegraal boekhoudperiodes staan nog altijd op 3-maandelijks.  Geen Intervat aangifte mogelijk met deze werkwijze die dateert van 1985-1994 en vermoedelijk overgenomen werd uit marIntegraal DOS periode. Contacteer ons 0475/292255 voor manuele tussenkomst!!)", MsgBoxStyle.Critical)
'		End If

'		Select Case aIndex
'			Case FlLeverancier
'				Select Case Ar
'					Case 1
'						'Record Kontroleren, zou MOETEN op nul staan...
'						vBib(FlAllerlei, Str(KolomTotaal(16)), "v045") 'vak 59
'						vBib(FlAllerlei, Str(KolomTotaal(9)), "v052") 'vak 86
'						vBib(FlAllerlei, Str(KolomTotaal(11)), "v053") 'vak 87
'						vBib(FlAllerlei, Str(KolomTotaal(12)), "v054") 'vak 88

'						vBib(FlAllerlei, VB6.Format(Val(TekstVan.Text), "00000"), "v092")
'						vBib(FlAllerlei, VB6.Format(Val(TekstLijn(3).Text), "00000"), "v093")

'					Case 3
'						vBib(FlAllerlei, Str(KolomTotaal(16)), "v100") 'vak 63
'						vBib(FlAllerlei, Str(KolomTotaal(7)), "v050") 'vak 84
'						vBib(FlAllerlei, Str(KolomTotaal(8)), "v051") 'vak 85

'						vBib(FlAllerlei, VB6.Format(Val(TekstVan.Text), "00000"), "v094")
'						vBib(FlAllerlei, VB6.Format(Val(TekstLijn(3).Text), "00000"), "v095")
'						For Tel = 3 To 16
'							KolomTotaal(Tel) = -KolomTotaal(Tel)
'						Next 
'					Case Else
'						MsgBox("Stop")
'				End Select

'				vBib(FlAllerlei, Str(KolomTotaal(13) + Val(vBibTekst(FlAllerlei, "#v042 #"))), "v042") 'vak 55
'				vBib(FlAllerlei, Str(KolomTotaal(14) + Val(vBibTekst(FlAllerlei, "#v043 #"))), "v043") 'vak 56
'				vBib(FlAllerlei, Str(KolomTotaal(15) + Val(vBibTekst(FlAllerlei, "#v044 #"))), "v044") 'vak 57
'				vBib(FlAllerlei, Str(KolomTotaal(3) + Val(vBibTekst(FlAllerlei, "#v046 #"))), "v046") 'vak 81
'				vBib(FlAllerlei, Str(KolomTotaal(4) + Val(vBibTekst(FlAllerlei, "#v047 #"))), "v047") 'vak 82
'				vBib(FlAllerlei, Str(KolomTotaal(5) + Val(vBibTekst(FlAllerlei, "#v048 #"))), "v048") 'vak 83

'				If ForFait Then
'					vBib(FlAllerlei, Str(VakForfait(0)), "v055") 'vak 00
'					vBib(FlAllerlei, Str(VakForfait(1)), "v056") 'vak 01
'					vBib(FlAllerlei, Str(VakForfait(2)), "v057") 'vak 02
'					vBib(FlAllerlei, Str(VakForfait(3)), "v058") 'vak 03
'					vBib(FlAllerlei, Str(BtwTotaalForfait), "v064") 'vak 54
'				End If

'			Case FlKlant
'				Select Case Ar
'					Case 12
'						vBib(FlAllerlei, Str(KolomTotaal(12)), "v064") 'vak 54
'						vBib(FlAllerlei, Str(KolomTotaal(2) + Val(vBibTekst(FlAllerlei, "#v055 #"))), "v055") 'vak 00 bijtellen ?

'						vBib(FlAllerlei, Str(KolomTotaal(3)), "v056") 'vak 01
'						vBib(FlAllerlei, Str(KolomTotaal(4)), "v057") 'vak 02
'						vBib(FlAllerlei, Str(KolomTotaal(5)), "v058") 'vak 03
'						vBib(FlAllerlei, Str(KolomTotaal(6)), "v059") 'vak 45
'						vBib(FlAllerlei, Str(KolomTotaal(7)), "v060") 'vak 46
'						vBib(FlAllerlei, Str(KolomTotaal(8)), "v061") 'vak 47

'						vBib(FlAllerlei, VB6.Format(Val(TekstVan.Text), "00000"), "v096")
'						vBib(FlAllerlei, VB6.Format(Val(TekstLijn(3).Text), "00000"), "v097")

'					Case 14
'						vBib(FlAllerlei, Str(KolomTotaal(12)), "v101") 'vak 64
'						vBib(FlAllerlei, Str(Val(vBibTekst(FlAllerlei, "#v055 #")) - KolomTotaal(2)), "v055") 'vak 00 aftrekken ?

'						vBib(FlAllerlei, Str(KolomTotaal(10)), "v062") 'vak 48
'						vBib(FlAllerlei, Str(KolomTotaal(11)), "v063") 'vak 49

'						vBib(FlAllerlei, VB6.Format(Val(TekstVan.Text), "00000"), "v098")
'						vBib(FlAllerlei, VB6.Format(Val(TekstLijn(3).Text), "00000"), "v099")

'					Case Else
'						MsgBox("Stop")
'				End Select
'			Case Else
'				MsgBox("Stop")
'		End Select

'		If bhEuro Then
'			vBib(FlAllerlei, "EUR", "vEUR")
'		End If

'		bUpdate(FlAllerlei, 1)
'		Select Case FaktuurCreditnota(0).Checked
'			Case True 'Faktuur
'				If aIndex = FlLeverancier Then
'					SS99(TekstLijn(3).Text, 2)
'				Else
'					SS99(TekstLijn(3).Text, 12)
'				End If

'			Case False
'				If aIndex = FlLeverancier Then
'					SS99(TekstLijn(3).Text, 4)
'				Else
'					SS99(TekstLijn(3).Text, 14)
'				End If
'		End Select
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'	End Sub

'	Private Sub InitVelden()
'		Dim T As Short
'		Dim VolgTab As Short

'		RapportVeldNr(0) = 33
'		RapportManier(0) = 0 'niks omwerken gewoon afdrukken
'		RapportVeld(0) = "dokument"
'		RapportTab(0) = 2

'		RapportVeldNr(1) = 35
'		RapportManier(1) = 5 'datum omwerken
'		RapportVeld(1) = "Datum dok."
'		RapportTab(1) = 14

'		Select Case aIndex
'			Case FlLeverancier
'				RapportVeldNr(2) = 39
'				RapportManier(2) = 0
'				RapportVeld(2) = "Referte"
'				RapportTab(2) = 25

'				RapportVeldNr(3) = 46
'				RapportManier(3) = 9 'geheel getal geformateerd
'				RapportVeld(3) = "   VAK 81"
'				RapportTab(3) = 46

'				RapportVeldNr(4) = 47
'				RapportManier(4) = 9
'				RapportVeld(4) = "   VAK 82"
'				RapportTab(4) = 56

'				RapportVeldNr(5) = 48
'				RapportManier(5) = 9
'				RapportVeld(5) = "   VAK 83"
'				RapportTab(5) = 66

'				RapportVeldNr(6) = 49
'				RapportManier(6) = 9
'				RapportVeld(6) = "   DERDEN"
'				RapportTab(6) = 76

'				RapportVeldNr(7) = 50
'				RapportManier(7) = 9
'				RapportVeld(7) = "   VAK 84"
'				RapportTab(7) = 86

'				RapportVeldNr(8) = 51
'				RapportManier(8) = 9
'				RapportVeld(8) = "   VAK 85"
'				RapportTab(8) = 96

'				RapportVeldNr(9) = 52
'				RapportManier(9) = 9
'				RapportVeld(9) = "   VAK 86"
'				RapportTab(9) = 106

'				RapportVeldNr(10) = 99
'				RapportManier(10) = 1 'zoek flpartij kode+naam1
'				RapportVeld(10) = "ID.Kode/Naam"
'				RapportTab(10) = 2

'				RapportVeldNr(11) = 53
'				RapportManier(11) = 9
'				RapportVeld(11) = "   VAK 87"
'				RapportTab(11) = 56

'				RapportVeldNr(12) = 54
'				RapportManier(12) = 9
'				RapportVeld(12) = "   VAK 88"
'				RapportTab(12) = 66

'				RapportVeldNr(13) = 42
'				RapportManier(13) = 9
'				RapportVeld(13) = "   VAK 55"
'				RapportTab(13) = 76

'				RapportVeldNr(14) = 43
'				RapportManier(14) = 9
'				RapportVeld(14) = "   VAK 56"
'				RapportTab(14) = 86

'				RapportVeldNr(15) = 44
'				RapportManier(15) = 9
'				RapportVeld(15) = "   VAK 57"
'				RapportTab(15) = 96

'				RapportVeldNr(16) = 45
'				RapportManier(16) = 9
'				RapportTab(16) = 106

'				Select Case Ar
'					Case 1
'						RapportVeld(16) = "   VAK 59"
'					Case Else
'						RapportVeld(16) = "   VAK 63"
'				End Select
'				RapportTab(17) = 0
'				tMaxVeld = 16

'			Case FlKlant
'				RapportVeldNr(2) = 55
'				RapportManier(2) = 9 'geheel getal geformateerd
'				RapportVeld(2) = "VAK 00"
'				RapportTab(2) = 44

'				RapportVeldNr(3) = 56
'				RapportManier(3) = 9
'				RapportVeld(3) = "VAK 01"
'				RapportTab(3) = 55

'				RapportVeldNr(4) = 57
'				RapportManier(4) = 9
'				RapportVeld(4) = "VAK 02"
'				RapportTab(4) = 66

'				RapportVeldNr(5) = 58
'				RapportManier(5) = 9
'				RapportVeld(5) = "VAK 03"
'				RapportTab(5) = 77

'				RapportVeldNr(6) = 59
'				RapportManier(6) = 9
'				RapportVeld(6) = "VAK 45"
'				RapportTab(6) = 88

'				RapportVeldNr(7) = 60
'				RapportManier(7) = 9
'				RapportVeld(7) = "VAK 46"
'				RapportTab(7) = 99

'				RapportVeldNr(8) = 61
'				RapportManier(8) = 9
'				RapportVeld(8) = "VAK 47"
'				RapportTab(8) = 110

'				RapportVeldNr(9) = 99
'				RapportManier(9) = 1
'				RapportVeld(9) = "ID.Kode/Naam"
'				RapportTab(9) = 2

'				RapportVeldNr(10) = 62
'				RapportManier(10) = 9
'				RapportVeld(10) = "VAK 48"
'				RapportTab(10) = 77


'				RapportVeldNr(11) = 63
'				RapportManier(11) = 9
'				RapportVeld(11) = "VAK 49"
'				RapportTab(11) = 88

'				RapportVeldNr(12) = 64
'				RapportManier(12) = 9
'				RapportTab(12) = 99

'				Select Case Ar
'					Case 12
'						RapportVeld(12) = "VAK 54"
'					Case Else
'						RapportVeld(12) = "VAK 64"
'				End Select
'				tMaxVeld = 12
'				RapportTab(13) = 0
'		End Select

'		For T = 0 To 17
'			KolomTotaal(T) = 0
'		Next 

'		If chkAfdrukInVenster.CheckState Then
'			Me.Hide()
'			Xlog.Close()
'			Xlog.Hide()
'			Xlog.Text = Me.Text
'			Xlog.X.Cols = tMaxVeld + 1
'			Xlog.X.Row = 0
'			For T = 0 To tMaxVeld
'				Xlog.X.Col = T
'				Xlog.X.Text = RapportVeld(T)
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

'	End Sub

'	Private Sub PrintTotaal()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim VeldTekst As String
'		Dim TotaalGrens As Integer

'		If chkAfdrukInVenster.CheckState = 0 Then
'			Printer.Write(vbCrLf & Lijntje.Value & vbCrLf)
'		End If

'		aa = ""
'		Do While RapportTab(T) <> 0
'			If chkAfdrukInVenster.CheckState = 0 Then
'				Printer.Print(TAB(RapportTab(T)))
'			End If
'			Select Case RapportManier(T)
'				Case 9
'					VeldTekst = Dec(KolomTotaal(T), MaskHier)
'					If chkAfdrukInVenster.CheckState Then
'						aa = aa & VeldTekst & vbTab
'					Else
'						Printer.Write(VeldTekst)
'						If RapportTab(T + 1) < RapportTab(T) Then
'							Printer.Write(vbCrLf)
'						End If
'					End If
'				Case Else
'					If chkAfdrukInVenster.CheckState Then
'						aa = aa & " " & vbTab
'					End If
'			End Select
'			T = T + 1
'		Loop 
'		If chkAfdrukInVenster.CheckState Then
'			Xlog.X.AddItem(aa, Xlog.X.Rows - 1)
'			Xlog.X.Row = 1
'			Xlog.X.Col = 0
'			Xlog.X.set_ColWidth(0, 1140)
'			Xlog.WindowState = System.Windows.Forms.FormWindowState.Maximized
'			'Xlog.X.ColAlignment(2) = flexAlignRightTop
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

'	End Sub

'	Private Sub PrintVelden()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim VeldTekst As String

'		Err.Clear()
'		On Error Resume Next

'		aa = ""
'		Do While RapportTab(T) <> 0
'			If chkAfdrukInVenster.CheckState = 0 Then
'				Printer.Print(TAB(RapportTab(T)))
'			End If

'			Select Case RapportManier(T)
'				Case 1
'					'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					If Not adoGet(aIndex, 0, "=", Mid(RV(rsAVBoekHier, "v034"), 2)) Then
'						'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'						VeldTekst = Mid(RV(rsAVBoekHier, "v034"), 2) & " is niet meer aanwezig"
'						MsgBox(VeldTekst)
'					Else
'						'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'						VeldTekst = Trim(RV(rsMAR(aIndex), "A110")) & " " & Trim(RV(rsMAR(aIndex), "A100"))
'					End If
'				Case 5
'					'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					VeldTekst = fDatumText(RV(rsAVBoekHier, "v" & VB6.Format(RapportVeldNr(T), "000")))
'				Case 9
'					'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					VeldTekst = Dec(Val(RV(rsAVBoekHier, "v" & VB6.Format(RapportVeldNr(T), "000"))), MaskHier)
'					KolomTotaal(T) = KolomTotaal(T) + Val(VeldTekst)
'				Case Else
'					'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'					VeldTekst = RV(rsAVBoekHier, "v" & VB6.Format(RapportVeldNr(T), "000"))
'			End Select

'			If chkAfdrukInVenster.CheckState = 0 Then
'				Printer.Write(VeldTekst)
'				If RapportTab(T + 1) < RapportTab(T) Then
'					Printer.Write(vbCrLf)
'				End If
'			Else
'				aa = aa & VeldTekst & vbTab
'			End If
'			T = T + 1
'		Loop 

'		If chkAfdrukInVenster.CheckState Then
'			Xlog.X.AddItem(aa, Xlog.X.Rows - 1)
'		Else
'			If Printer.CurrentY >= Printer.Height - 1200 Then
'				Printer.NewPage()
'				Printer.FontSize = Printer.FontSize
'				Printer.Print(" ")
'				Printer.FontSize = Printer.FontSize
'				PrintTitel()
'			End If
'		End If

'	End Sub

'	Private Sub TekstLijn_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Enter
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		TekstLijn(Index).SelectionStart = 0
'		TekstLijn(Index).SelectionLength = Len(TekstLijn(Index).Text)

'	End Sub

'	Private Sub TekstLijn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TekstLijn.Leave
'		Dim Index As Short = TekstLijn.GetIndex(eventSender)

'		Select Case Index
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
'End Class