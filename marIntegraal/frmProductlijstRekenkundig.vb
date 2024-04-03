Public Class frmProductlijstRekenkundig
    Private Sub frmProductlijstRekenkundig_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
'Friend Class FrmLijstProdukten
'	Inherits System.Windows.Forms.Form
'	'UPGRADE_NOTE: DefInt A-Z statement was removed. Variables were explicitly declared as type Short. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92AFD3E3-440D-4D49-A8BF-580D74A8C9F2"'

'	Dim psTekst(5) As String
'	Dim VeldTXT(17) As String
'	Dim aa As String

'	Dim TLijnen As Integer

'	Dim rsLijstProducten As ADODB.Recordset

'	Dim IndexNR As Short
'	Dim tMaxVeld As Short

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

'	'UPGRADE_WARNING: Event CmbLijstType.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub CmbLijstType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmbLijstType.SelectedIndexChanged

'		If CmbLijstType.SelectedIndex > 1 Then
'			MsgBox("Voorlopig " & Now & " enkel eerste lijst mogelijk !")
'			CmbLijstType.SelectedIndex = 0
'		End If

'	End Sub


'	Private Sub Drukken_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drukken.Click
'		Dim Printer As New Printer
'		Dim BeginSleutel As String
'		Dim EindSleutel As String
'		Dim Lijn As Integer
'		Dim DCBedrag As Integer
'		Dim XX As Short
'		Dim Bedrag As Double

'		Dim TicketEUR2005 As Decimal
'		Dim ticketEUR As Decimal

'		Dim VeldTXT3 As String
'		Dim SQLstring As String

'		aa = ""
'		TLijnen = 0
'		Lijn = 0
'		BeginSleutel = TekstInfo(0).Text
'		EindSleutel = TekstInfo(1).Text

'		psTekst(2) = CmbLijstType.Text & " " & Mid(Mim.Text, InStr(Mim.Text, "["))
'		psTekst(0) = TekstLijn(1).Text
'		psTekst(3) = TekstLijn(0).Text

'		InitVelden()
'		bClose(FlProdukt)
'		'Set rsLijstProducten = New ADODB.Recordset
'		'SQLstring = "SELECT * FROM Produkten WHERE "
'		'Stop

'		bFirst(FlProdukt, IndexNR)
'		bGetOrGreater(FlProdukt, IndexNR, BeginSleutel)
'		If Ktrl Or UCase(KeyBuf(FlProdukt)) > UCase(EindSleutel) Then
'			Beep()
'			Exit Sub
'		Else
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'			PaginaTeller = 0
'			If chkAfdrukInVenster.CheckState = 0 Then
'				If Printer.Width > 12000 Then
'					Printer.FontSize = 10
'					Printer.FontName = "Courier New"
'					Printer.Print(" ")
'					Printer.FontSize = 10
'				Else
'					Printer.FontSize = 8
'					Printer.FontName = "Courier New"
'					Printer.Print(" ")
'					Printer.FontSize = 8
'				End If
'			End If
'			PrintTitel()
'			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'			GoSub PrintInfo
'		End If

'		Do 
'			bNext(FlProdukt)
'			If Ktrl Or UCase(Trim(KeyBuf(FlProdukt))) > UCase(EindSleutel) Then
'				Exit Do
'			Else
'				'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
'				GoSub PrintInfo
'			End If
'		Loop 
'		PrintTotaal()
'		If chkAfdrukInVenster.CheckState = 0 Then
'			Printer.EndDoc()
'		End If
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		'Annuleren_Click
'		Exit Sub

'		Dim Basisbedrag As Decimal
'		Dim BasisAantal As Single

'PrintInfo: 
'		RecordToVeld(FlProdukt)
'		Select Case CmbLijstType.SelectedIndex
'			Case 0
'				VeldTXT(0) = vBibTekst(FlProdukt, "#v102 #")
'				VeldTXT(1) = vBibTekst(FlProdukt, "#v105 #")

'				Basisbedrag = Val(vBibTekst(FlProdukt, "#e112 #"))
'				VeldTXT(2) = Dec(Val(vBibTekst(FlProdukt, "#e112 #")), MaskerEUR & "00")

'				VeldTXT(3) = vBibTekst(FlProdukt, "#v111 #")
'				VeldTXT3 = Mid(fmarBoxText("002", "2", VeldTXT(3)), 4)

'				BasisAantal = Val(vBibTekst(FlProdukt, "#v107 #"))
'				VeldTXT(4) = VB.Right(Dec(Val(vBibTekst(FlProdukt, "#v107 #")), MaskerSy(7)), 6)

'				VeldTXT(5) = Mid(fmarBoxText("004", "2", vBibTekst(FlProdukt, "#v106 #")), 4)
'				TicketEUR2005 = ((Basisbedrag * BasisAantal) + ((Basisbedrag * BasisAantal * Val(VeldTXT3) / 100)))
'				VeldTXT(6) = VB.Right(Dec(TicketEUR2005, MaskerEUR), 8)
'				VeldTXT(7) = VB.Right(Dec(Val(vBibTekst(FlProdukt, "#v114 #")) + Val(vBibTekst(FlProdukt, "#v119 #")) - Val(vBibTekst(FlProdukt, "#v120 #")), MaskerSy(7)), 6)
'				VeldTXT(8) = vBibTekst(FlProdukt, "#v109 #")

'			Case 1
'				VeldTXT(0) = vBibTekst(FlProdukt, "#v102 #")
'				VeldTXT(1) = vBibTekst(FlProdukt, "#v105 #")

'				Basisbedrag = Val(vBibTekst(FlProdukt, "#e113 #"))
'				VeldTXT(2) = Dec(Val(vBibTekst(FlProdukt, "#e113 #")), MaskerEUR & "00")

'				VeldTXT(3) = vBibTekst(FlProdukt, "#v111 #")
'				VeldTXT3 = Mid(fmarBoxText("002", "2", VeldTXT(3)), 4)

'				BasisAantal = Val(vBibTekst(FlProdukt, "#v107 #"))
'				VeldTXT(4) = VB.Right(Dec(Val(vBibTekst(FlProdukt, "#v107 #")), MaskerSy(7)), 6)
'				VeldTXT(5) = Mid(fmarBoxText("004", "2", vBibTekst(FlProdukt, "#v106 #")), 4)

'				'TicketEUR2005 = ((Basisbedrag * BasisAantal) + ((Basisbedrag * BasisAantal * Val(VeldTXT3) / 100)))
'				'VeldTXT(6) = Right(Dec((TicketEUR2005), MaskerEUR), 8)
'				VeldTXT(6) = VB.Right(Dec(Val(vBibTekst(FlProdukt, "#v115 #")), MaskerSy(7)), 6)
'				VeldTXT(7) = VB.Right(Dec(Val(vBibTekst(FlProdukt, "#v114 #")) + Val(vBibTekst(FlProdukt, "#v119 #")) - Val(vBibTekst(FlProdukt, "#v120 #")), MaskerSy(7)), 6)
'				VeldTXT(8) = Dec(Val(VeldTXT(6)) - Val(VeldTXT(7)), MaskerSy(7))
'		End Select
'		PrintVelden()
'		'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Return 

'	End Sub

'	Private Sub FrmLijstProdukten_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
'		Dim Printer As New Printer

'		If Not Toegankelijk(Me) Then
'			Me.Close()
'			Exit Sub
'		End If

'		Dim T As Short
'		Dim TempbModus As Short
'		Dim SorteringTel As Short

'		TekstLijn(0).Text = ""
'		TekstLijn(1).Text = Rdt.Value

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

'		CmbLijstType.Items.Add("Lijst Verkoopstock")
'		CmbLijstType.Items.Add("Lijst Te Bestellen")
'		CmbLijstType.Items.Add("Lijst Aankoop stockwaarde")
'		CmbLijstType.SelectedIndex = 0

'		SorteringTel = -1
'		ToonIndexen(bstNaam(FlProdukt), Sortering)
'		For T = 0 To Sortering.Items.Count - 1
'			If InStr(VB6.GetItemString(Sortering, T), FLIndexCaption(FlProdukt, 0)) Then
'				Sortering.SelectedIndex = T
'				Exit For
'			End If
'		Next 

'	End Sub

'	Private Sub InitVelden()
'		Dim T As Short

'		Select Case CmbLijstType.SelectedIndex
'			Case 0
'				RapportVeld(0) = "Nummer"
'				RapportTab(0) = 5

'				RapportVeld(1) = "Omschrijving"
'				RapportTab(1) = 19

'				RapportVeld(2) = "VK EUR Ex."
'				RapportTab(2) = 60

'				RapportVeld(3) = "B"
'				RapportTab(3) = 73

'				RapportVeld(4) = "Verpak"
'				RapportTab(4) = 75

'				RapportVeld(5) = "Maat"
'				RapportTab(5) = 83

'				RapportVeld(6) = "EUR incl"
'				RapportTab(6) = 89

'				RapportVeld(7) = " Stock"
'				RapportTab(7) = 98

'				RapportVeld(8) = "Plaats"
'				RapportTab(8) = 107
'				tMaxVeld = 8

'			Case 1
'				RapportVeld(0) = "Nummer"
'				RapportTab(0) = 5

'				RapportVeld(1) = "Omschrijving"
'				RapportTab(1) = 19

'				RapportVeld(2) = "AK EUR Ex."
'				RapportTab(2) = 60

'				RapportVeld(3) = "B"
'				RapportTab(3) = 73

'				RapportVeld(4) = "Verpak"
'				RapportTab(4) = 75

'				RapportVeld(5) = "Maat"
'				RapportTab(5) = 83

'				RapportVeld(6) = "Min.Stock"
'				RapportTab(6) = 89

'				RapportVeld(7) = " Stock"
'				RapportTab(7) = 98

'				RapportVeld(8) = "Bestellen"
'				RapportTab(8) = 107
'				tMaxVeld = 8

'			Case Else
'				MsgBox("Stop")
'		End Select

'		If chkAfdrukInVenster.CheckState Then
'			Me.Hide()
'			Xlog.Close()
'			Xlog.Hide()
'			Xlog.Text = CmbLijstType.Text
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

'		'On Local Error GoTo PrtHandler3

'		If chkAfdrukInVenster.CheckState Then Exit Sub

'		If usrLicentieInfo <> "" Then
'			Printer.CurrentX = 50
'			Printer.CurrentY = 50
'			Printer.Write(usrLicentieInfo)
'		End If
'		PaginaTeller = PaginaTeller + 1
'		Printer.CurrentY = 400
'		Printer.Write(TAB(1), psTekst(2), TAB(107), Dec(PaginaTeller, "##########"))

'		Printer.Write(TAB(107), psTekst(0) & vbCrLf & vbCrLf)
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

'		For T = 0 To tMaxVeld
'			VeldTXT(T) = ""
'		Next 
'		VeldTXT(1) = "Totaal aantal lijnen : " & VB6.Format(TLijnen)

'		If chkAfdrukInVenster.CheckState Then
'		Else
'			Printer.Print(vbCrLf & Lijntje.Value)
'		End If

'		T = 0
'		aa = ""
'		Do While T < tMaxVeld
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
'		If chkAfdrukInVenster.CheckState Then Xlog.X.AddItem(aa, Xlog.X.Rows - 1)

'		If chkAfdrukInVenster.CheckState Then
'			Select Case CmbLijstType.SelectedIndex
'				Case 0
'					Xlog.X.Row = 1
'					Xlog.X.Col = 0
'					Xlog.X.set_ColWidth(0, 1335)
'					Xlog.X.set_ColWidth(1, 3360)
'					Xlog.X.set_ColWidth(2, 810)
'					Xlog.X.set_ColWidth(3, 210)
'					Xlog.X.set_ColWidth(4, 615)
'					Xlog.X.set_ColWidth(5, 525)
'					Xlog.X.set_ColWidth(6, 945)
'					Xlog.X.set_ColWidth(7, 900)
'					Xlog.X.set_ColWidth(8, 1425)
'					Xlog.WindowState = System.Windows.Forms.FormWindowState.Maximized

'					Xlog.X.set_ColAlignment(2, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'					Xlog.X.set_ColAlignment(4, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'					Xlog.X.set_ColAlignment(6, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'					Xlog.X.set_ColAlignment(7, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'					Xlog.X.set_ColAlignment(8, MSFlexGridLib.AlignmentSettings.flexAlignRightTop)
'			End Select

'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal
'			Xlog.WijzigenLijn.Visible = False
'			Xlog.Afsluiten.TabStop = False
'			Xlog.Afsluiten.Enabled = False
'			Xlog.cbAfbeelding.Visible = False
'			XLogKey = ""
'			Xlog.SSTab1.TabPages.Item(1).Visible = False
'			Xlog.ShowDialog()
'			'Unload Xlog
'		End If

'	End Sub

'	Private Sub PrintVelden()
'		Dim Printer As New Printer
'		Dim T As Short
'		Dim aa As String

'		T = 0
'		aa = ""
'		Dim bstAantal As Single

'		If CmbLijstType.SelectedIndex = 1 Then
'			'Bestellijst geselecteerd.  Enkel afdrukken indien nodig
'			If Val(VeldTXT(8)) > 0 Then
'			Else
'				Exit Sub
'			End If
'		End If
'		TLijnen = TLijnen + 1

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

'		If chkAfdrukInVenster.CheckState Then Xlog.X.AddItem(aa, Xlog.X.Rows - 1)

'	End Sub



'	'UPGRADE_WARNING: Event SorTering.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub SorTering_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SorTering.SelectedIndexChanged
'		Dim T As Short

'		IndexNR = -1
'		For T = 0 To Sortering.Items.Count - 1
'			If InStr(Sortering.Text, FLIndexCaption(FlProdukt, T)) Then
'				IndexNR = T
'				Exit For
'			End If
'		Next 
'		If IndexNR < 0 Then
'			MsgBox("Indexen zijn ondertussen vernieuwd ?" & vbCrLf & vbCrLf & "Om van de nieuwe indexen gebruik te kunnen maken dient U het bedrijf te heropenen !")
'		End If

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
'		End Select

'	End Sub
'End Class