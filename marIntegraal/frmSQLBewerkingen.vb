Imports System.ComponentModel

Public Class SQLBewerkingen
    Private Sub cmdSluiten_Click(sender As Object, e As EventArgs) Handles cmdSluiten.Click
        Close

    End Sub

    Private Sub SQLBewerkingen_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Mim.SQLBewerkingenToolStripMenuItem.Enabled = True 
    End Sub

    Private Sub SQLBewerkingen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

'Option Strict Off
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Friend Class frmADOSQLOpzoeker
'	Inherits System.Windows.Forms.Form

'	Dim grdColWidth(20) As Short
'	Dim allesGesloten As Boolean

'	Dim datPrimaryRS As ADODB.Recordset
'	Dim querySQL As String

'	'UPGRADE_WARNING: Event cbOperatie.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub cbOperatie_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbOperatie.SelectedIndexChanged

'		queryPLUS()
'		queryChange()

'	End Sub

'	'UPGRADE_WARNING: Event cbSQLBevel.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub cbSQLBevel_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbSQLBevel.SelectedIndexChanged

'		If cbSQLBevel.SelectedIndex <> 0 Then
'			Msg = cbSQLBevel.Text & " opdracht." & vbCr & vbCr & "Het is ten zeerste aan te raden om dergelijke" & vbCr & "opdrachten BINNENIN een TRANSACTIE uit te voeren" & vbCr & vbCr & vbCr & "BEGIN WORK start een transactie" & vbCr & vbCr & "ROLLBACK WORK annuleert alle wijziging na 'BEGIN WORK'" & vbCr & "(m.a.w. zéér interessant om foutieve 'DELETE/UPDATES/INSERT'" & vbCr & "opdrachten teniet te doen...)" & vbCr & vbCr & "COMMIT WORK ten slotte laat alle 'DELETE/UPDATE/INSERT'" & vbCr & "opdrachten doorgaan." & vbCr & vbCr & "BEGIN WORK wordt hierna voorgesteld als instructie.  Druk Alt+E om te activeren"
'			MsgBox(Msg, MsgBoxStyle.Exclamation)
'			txtSQL.Text = "BEGIN WORK"
'		Else
'			queryPLUS()
'			queryChange()
'		End If

'	End Sub

'	'UPGRADE_WARNING: Event cbVelden.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub cbVelden_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVelden.SelectedIndexChanged

'		queryPLUS()
'		queryChange()

'	End Sub

'	'UPGRADE_WARNING: Event cmbSelect.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub cmbSelect_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbSelect.SelectedIndexChanged

'		bGet(FlAllerlei, 1, "29" & cmbSelect.Text)
'		If Ktrl Then
'		Else
'			RecordToVeld(FlAllerlei)
'			If InStr(vBibTekst(FlAllerlei, "#v132 #"), "[Colwidth]") Then
'				txtSQL.Text = VB.Left(vBibTekst(FlAllerlei, "#v132 #"), InStr(vBibTekst(FlAllerlei, "#v132 #"), "[Colwidth]") - 1)
'			Else
'				txtSQL.Text = vBibTekst(FlAllerlei, "#v132 #")
'			End If

'			On Error Resume Next
'			Msg = Mid(vBibTekst(FlAllerlei, "#v132 #"), InStr(vBibTekst(FlAllerlei, "#v132 #"), "[Colwidth]") + 10)
'			If Msg = "" Then
'				grdColWidth(0) = 0
'			Else
'				TelTot = 0
'				Do While Msg <> ""
'					If InStr(Msg, vbTab) <> 0 Then
'						grdColWidth(TelTot) = Val(VB.Left(Msg, InStr(Msg, vbTab) - 1))
'						Msg = Mid(Msg, InStr(Msg, vbTab) + 1)
'						TelTot = TelTot + 1
'					Else
'						Exit Do
'					End If
'				Loop 
'				grdColWidth(TelTot) = 0
'			End If

'		End If

'	End Sub

'	Private Sub cmbSelect_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cmbSelect.KeyDown
'		Dim KeyCode As Short = eventArgs.KeyCode
'		Dim Shift As Short = eventArgs.KeyData \ &H10000

'		If KeyCode = 46 Then
'			bGet(FlAllerlei, 1, "29" & cmbSelect.Text)
'			If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "29" Then
'			ElseIf MsgBox("Bestaande definitie '" & cmbSelect.Text & "' verwijderen ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then 
'				RecordToVeld(FlAllerlei)
'				bDelete(FlAllerlei)
'				SelectComboVullen()
'			Else
'				Exit Sub
'			End If
'		ElseIf KeyCode = 13 Then 
'			cmdSelectWegschrijven_Click(cmdSelectWegschrijven, New System.EventArgs())
'		End If

'	End Sub

'	Private Sub cmbVersie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbVersie.Click
'		Dim strVersionInfo As String

'		On Error Resume Next
'		strVersionInfo = "ADO Versie: " & adntDB.Version & vbCr & "DBMS Naam: " & adntDB.Properties("DBMS Name").Value & vbCr & "DBMS Versie: " & adntDB.Properties("DBMS Version").Value & vbCr & "OLE DB Versie: " & adntDB.Properties("OLE DB Version").Value & vbCr & "Provider Naam: " & adntDB.Properties("Provider Name").Value & vbCr & "Provider Versie: " & adntDB.Properties("Provider Version").Value & vbCr
'		MsgBox(strVersionInfo)

'	End Sub

'	Private Sub cmdBackup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBackup.Click

'		Dim TQString As String
'		Dim sTBLName As String
'		Dim SQLstring As String

'		Dim cnnSubHier As ADODB.Connection
'		Dim rsSubHier As ADODB.Recordset
'		Dim jetConnectSubHier As String
'		Dim RecordTeller As Integer
'		Dim msgStringHier As String

'		jetConnectSubHier = adoJetProvider & "Data Source=" & BedrijfsLokatie & "\marnt.mdv;" & "Persist Security Info=False"

'		cnnSubHier = New ADODB.Connection
'		cnnSubHier.Open(jetConnectSubHier)
'		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		If Dir(BedrijfsLokatie & "\marnt.mdb") <> "" Then
'			Kill(BedrijfsLokatie & "\marnt.mdb")
'		End If
'		If Not CopyFile(ProgrammaLokatie, BedrijfsLokatie, "marnt.mdb") Then
'			MsgBox("Stop" & vbCr & ErrorToString())
'		End If

'		'UPGRADE_WARNING: Couldn't resolve default property of object OpenSchemaString(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		TQString = OpenSchemaString("TABLE")
'		Do While TQString <> ""
'			sTBLName = Mid(TQString, 1, InStr(TQString, vbCr) - 1)
'			TQString = Mid(TQString, InStr(TQString, vbCr) + 1)
'			SQLstring = "SELECT * INTO [" & BedrijfsLokatie & "marnt.mdb].[" & sTBLName & "] FROM " & sTBLName
'			Err.Clear()
'			On Error Resume Next
'			SnelHelpPrint("Bezig aan tabel " & sTBLName, blLogging)
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'			cnnSubHier.Execute(SQLstring, RecordTeller)
'			If Err.Number Then
'				MsgBox(ErrorToString())
'			Else
'				msgStringHier = msgStringHier & RecordTeller & " records met succes overgedragen in tabel " & sTBLName & " / "
'			End If
'			'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'			'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'			System.Windows.Forms.Cursor.Current = vbNormal
'		Loop 
'		MsgBox("Einde backup database" & vbCr & vbCr & msgStringHier, MsgBoxStyle.Information)
'		MsgBox("Backup nog op veilige plaats bewaren: " & BedrijfsLokatie & "marnt.mdb", MsgBoxStyle.Information)
'		MsgBox("Hierna worden de belangrijkste indexen nog aangemaakt in de marnt.mdb database")
'		MsgBox("Stop")


'	End Sub

'	Private Sub cmdExecute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExecute.Click

'		Dim recAantal As Integer

'		On Error Resume Next
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'		Err.Clear()
'		adntDB.Execute(txtSQL.Text, recAantal)
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal
'		If Err.Number Then
'			MsgBox("Foutmelding bron: " & Err.Source & vbCrLf & "Foutkodenummer: " & Err.Number & vbCrLf & vbCrLf & "Foutmelding omschrijving:" & vbCrLf & Err.Description)
'		Else
'			MsgBox(txtSQL.Text & vbCr & vbCr & "met succes uitgevoerd." & vbCr & vbCr & recAantal & " records met wijzigingen.", MsgBoxStyle.Information)
'		End If
'		'adoLoadDatabase

'	End Sub

'	Private Sub cmdKopij_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdKopij.Click

'		Msg = "Kies 'Ja' voor kopij als XML bestand" & vbCr & "Kies 'Nee' voor kopij naar het klassieke plakbord"

'		KtrlBox = MsgBox(Msg, MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton3)
'		Dim BestandHier As String
'		If KtrlBox = MsgBoxResult.Cancel Then
'			Exit Sub
'		ElseIf KtrlBox = MsgBoxResult.No Then 
'			On Error Resume Next
'			My.Computer.Clipboard.Clear()
'			My.Computer.Clipboard.SetText(msfSQL.Clip)
'			Exit Sub
'		Else
'			On Error GoTo CancelError
'			Mim.TekenOpen.FileName = ""
'			Mim.TekenSave.FileName = ""
'			'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
'			Mim.Teken.CancelError = True
'			'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'			Mim.TekenOpen.Filter = "Alle bestanden (*.xml)|*.xml"
'			Mim.TekenSave.Filter = "Alle bestanden (*.xml)|*.xml"
'			Mim.TekenSave.ShowDialog()
'			Mim.TekenOpen.FileName = Mim.TekenSave.FileName
'			BestandHier = Mim.TekenOpen.FileName
'			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'			If Not Dir(BestandHier) = "" Then
'				Kill(BestandHier)
'			End If
'			datPrimaryRS.Save(Mim.TekenOpen.FileName, ADODB.PersistFormatEnum.adPersistXML)
'		End If

'CancelError: 
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal

'	End Sub

'	Private Sub cmdNet1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNet1.Click

'		Msg = "ALTER TABLE Journalen DROP COLUMN dece068"
'		MsgBox("Alle rekening- en journaalvelden voor cijfers/bedragen dienen vanaf versie 6.5.301 bij voorkeur formaat DECIMAL te zijn (voorheen CURRENCY).  Wij zullen zolang als mogelijk een manuele hersamenstelling beschikbaar stellen d.m.v. de SQL instructie hierna EN VERVOLGENS opnieuw openen van het bedrijf.  Zeker tot aan versie 6.5.500 zal deze functie beschikbaar blijven." & vbCr & vbCr & "Aarzel NOOIT ons te contacteren voor bijkomende inlichtingen:" & vbCr & vbCr & Msg & vbCr & vbCr & "Uiteraard alléén indien U een verkeerde herrekening wenst te verbeteren..." & vbCr & vbCr & "NETWERKERS !  EERST AL UW ANDERE marINTEGRAAL GEBRUIKERSVERBINDINGEN STOPPEN !!!!", MsgBoxStyle.Information)

'	End Sub

'	Private Sub cmdOpenXML_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpenXML.Click

'		On Error GoTo CancelError
'		Mim.TekenOpen.FileName = ""
'		Mim.TekenSave.FileName = ""
'		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
'		Mim.Teken.CancelError = True
'		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
'		Mim.TekenOpen.Filter = "Alle bestanden (*.xml)|*.xml"
'		Mim.TekenSave.Filter = "Alle bestanden (*.xml)|*.xml"
'		Mim.TekenOpen.ShowDialog()
'		Mim.TekenSave.FileName = Mim.TekenOpen.FileName
'		Dim BestandHier As String
'		BestandHier = Mim.TekenOpen.FileName
'		Err.Clear()
'		On Error Resume Next
'		datPrimaryRS.Close()
'		On Error Resume Next
'		Err.Clear()
'		datPrimaryRS.Open(Mim.TekenOpen.FileName,  , ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdFile)
'		msfSQL.DataSource = datPrimaryRS
'		If Err.Number Then
'			MsgBox("Dit is geen ADO-compatibel XML bestand.", MsgBoxStyle.Information)
'		Else
'			txtSQL.Text = datPrimaryRS.Source
'			lblRecordCount.Text = CStr(datPrimaryRS.RecordCount)
'			'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
'			msfSQL.CtlRefresh()
'		End If

'CancelError: 
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal

'	End Sub

'	Private Sub cmdSelectWegschrijven_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectWegschrijven.Click

'		bGet(FlAllerlei, 1, "29" & cmbSelect.Text)
'		If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "29" Then
'			'Als nieuw bijvoegen
'			TLBRecord(FlAllerlei) = ""
'			Msg = ""
'			For TelTot = 0 To msfSQL.get_Cols() - 1
'				Msg = Msg & VB6.Format(msfSQL.get_ColWidth(TelTot)) & vbTab
'			Next 
'			Msg = "[Colwidth]" & Msg
'			Msg = txtSQL.Text & Msg
'			vBib(FlAllerlei, Msg, "v132")
'			vBib(FlAllerlei, (cmbSelect.Text), "v250")
'			vBib(FlAllerlei, "29" & vBibTekst(FlAllerlei, "#v250 #"), "v005")
'			bInsert(FlAllerlei, 1)
'		ElseIf MsgBox("Bestaande definitie '" & cmbSelect.Text & "' overschrijven ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then 
'			RecordToVeld(FlAllerlei)
'			Msg = ""
'			For TelTot = 0 To msfSQL.get_Cols() - 1
'				Msg = Msg & VB6.Format(msfSQL.get_ColWidth(TelTot)) & vbTab
'			Next 
'			Msg = "[Colwidth]" & Msg
'			Msg = txtSQL.Text & Msg

'			vBib(FlAllerlei, Msg, "v132")
'			vBib(FlAllerlei, (cmbSelect.Text), "v250")
'			vBib(FlAllerlei, "29" & vBibTekst(FlAllerlei, "#v250 #"), "v005")
'			bUpdate(FlAllerlei, 1)
'		Else
'			Exit Sub
'		End If
'		SelectComboVullen()

'	End Sub

'	Private Sub cmdSluiten_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSluiten.Click

'		Me.Close()

'	End Sub

'	Private Sub cmdSQL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSQL.Click

'		On Error Resume Next

'		lblRecordCount.Text = ""
'		Me.Refresh()
'		If adoRECORDset Then
'			For TelTot = 0 To msfSQL.get_Cols() - 1
'				If grdColWidth(TelTot) = 0 Then
'					Exit For
'				Else
'					msfSQL.set_ColWidth(TelTot,  , grdColWidth(TelTot))
'				End If
'				msfSQL.set_ColAlignment(TelTot, MSFlexGridLib.AlignmentSettings.flexAlignLeftTop)
'			Next 
'		End If

'	End Sub


'	Private Sub frmADOSQLOpzoeker_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

'		datPrimaryRS = New ADODB.Recordset
'		datPrimaryRS.CursorLocation = ADODB.CursorLocationEnum.adUseClient

'		allesGesloten = False
'		Msg = "Moeten de tabellen gesloten worden (noodzakelijk om wijzigingen aan 'structuur' aan te brengen)"
'		If MsgBox(Msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
'			MsgBox("De bestanden worden gesloten.  U kan eveneens wijzigingen aan de structuur van tabellin in de database aanbrengen.  Het is aanbevolen straks het bedrijf opnieuw te openen", MsgBoxStyle.Information)
'			allesGesloten = True
'			bClose(99)
'		Else
'			MsgBox("De bestanden worden niet gesloten.  U kan enkel de gegevens in de database bewerken.  U kan géén wijzigingen aan de structuur van tabellen in de database aanbrengen.", MsgBoxStyle.Information)
'		End If

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'		With msfSQL
'			.Top = VB6.TwipsToPixelsY(5)
'			.Left = 0
'			.Height = VB6.TwipsToPixelsY(2175)
'			.Width = VB6.TwipsToPixelsX(6135)
'		End With
'		adoLoadDatabase()

'QueryNogEens: 
'		bGetOrGreater(FlAllerlei, 1, "29")
'		If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "29" Then
'			'Steek er een voorbeeld in
'			Msg = "SELECT TOP 6" & vbCrLf
'			Msg = Msg & "    v019 AS RekNr," & vbCrLf
'			Msg = Msg & "    v020 AS Omschrijving," & vbCrLf
'			Msg = Msg & "    v022 AS [Boekjaar 0]," & vbCrLf
'			Msg = Msg & "    v023 AS [Boekjaar -1]," & vbCrLf
'			Msg = Msg & "    v024 AS [Boekjaar -2]," & vbCrLf
'			Msg = Msg & "    v025 As [Boekjaar -3]" & vbCrLf
'			Msg = Msg & "FROM" & vbCrLf
'			Msg = Msg & "    Rekeningen" & vbCrLf
'			Msg = Msg & "ORDER BY" & vbCrLf
'			Msg = Msg & "    v020 DESC"
'			TLBRecord(FlAllerlei) = ""
'			vBib(FlAllerlei, Msg, "v132")
'			vBib(FlAllerlei, "Query voorbeeld", "v250")
'			vBib(FlAllerlei, "29" & vBibTekst(FlAllerlei, "#v250 #"), "v005")
'			bInsert(FlAllerlei, 1)
'			If Ktrl Then
'			Else
'				GoTo QueryNogEens
'			End If
'		Else
'			SelectComboVullen()
'		End If

'Opzoeking: 
'		cmdSQL_Click(cmdSQL, New System.EventArgs())

'		On Error Resume Next
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal

'	End Sub

'	Sub SelectComboVullen()

'		cmbSelect.Items.Clear()
'		bGetOrGreater(FlAllerlei, 1, "29")
'		If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "29" Then
'		Else
'			Do 
'				RecordToVeld(FlAllerlei)
'				cmbSelect.Items.Add(vBibTekst(FlAllerlei, "#v250 #"))
'				bNext(FlAllerlei)
'				If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "29" Then
'					Exit Do
'				End If
'			Loop 
'		End If
'		If cmbSelect.Items.Count = 0 Then
'		Else
'			cmbSelect.SelectedIndex = 0
'		End If

'	End Sub

'	Private Sub frmADOSQLOpzoeker_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

'		On Error Resume Next
'		datPrimaryRS.Close()
'		'UPGRADE_NOTE: Object datPrimaryRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
'		datPrimaryRS = Nothing

'		'hier nu eerst terug rsjournaal maken !!!!!
'		If allesGesloten = True Then
'			MsgBox("Bedrijfsdatabase wordt hierna automatisch afgesloten.", MsgBoxStyle.Information)
'			AutoUnloadBedrijf()
'			Exit Sub
'		End If

'	End Sub

'	Private Sub lvDatabase_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvDatabase.Click

'		txtSQL.Text = "SELECT * FROM " & lvDatabase.FocusedItem.Text

'	End Sub

'	Private Sub lvDatabase_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvDatabase.DoubleClick

'		Dim TelTot As Short

'		txtSQL.Text = "SELECT * FROM " & lvDatabase.FocusedItem.Text
'		cmdSQL_Click(cmdSQL, New System.EventArgs())
'		cbSQLBevel.Enabled = True
'		cbSQLBevel.SelectedIndex = 0

'		cbVelden.Enabled = True
'		cbVelden.Items.Clear()
'		For TelTot = 0 To datPrimaryRS.Fields.Count - 1
'			cbVelden.Items.Add(datPrimaryRS.Fields(TelTot).Name)
'		Next 
'		If cbVelden.Items.Count Then
'			cbVelden.SelectedIndex = 0

'		End If
'		cbOperatie.Enabled = True
'		cbOperatie.SelectedIndex = 0
'		txtWaarde.Enabled = True
'		txtWaarde.Text = "'%'"
'		txtWaarde.Focus()

'	End Sub

'	Private Sub msfSQL_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles msfSQL.DblClick

'		If VB6.PixelsToTwipsY(msfSQL.Top) = 5 Then
'			'vergroten
'			Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
'			msfSQL.Top = 0
'			msfSQL.Left = 0
'			msfSQL.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 700)
'			msfSQL.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 100)
'		Else
'			'terug normaal
'			Me.WindowState = System.Windows.Forms.FormWindowState.Normal
'			With msfSQL
'				.Top = VB6.TwipsToPixelsY(5)
'				.Left = 0
'				.Height = VB6.TwipsToPixelsY(2175)
'				.Width = VB6.TwipsToPixelsX(6135)
'			End With
'		End If

'	End Sub


'	Public Sub adoLoadDatabase()

'		Dim itmX As System.Windows.Forms.ListViewItem
'		Dim TQString As String
'		Dim sTBLName As String

'		lvDatabase.Items.Clear()
'		'UPGRADE_WARNING: Couldn't resolve default property of object OpenSchemaString(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
'		TQString = OpenSchemaString("TABLE")

'		'add the Tables
'		Do While TQString <> ""
'			sTBLName = Mid(TQString, 1, InStr(TQString, vbCr) - 1)
'			TQString = Mid(TQString, InStr(TQString, vbCr) + 1)
'			'UPGRADE_WARNING: Lower bound of collection lvDatabase.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
'			itmX = lvDatabase.Items.Add(sTBLName, "Tabel")
'		Loop 
'		lvDatabase.View = System.Windows.Forms.View.LargeIcon

'	End Sub

'	Function adoRECORDset() As Boolean

'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'		On Error Resume Next
'		'UPGRADE_NOTE: Object msfSQL.Recordset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
'		msfSQL.Recordset = Nothing

'		datPrimaryRS.Close()
'		On Error Resume Next
'		datPrimaryRS.Open(txtSQL.Text, adntDB)
'		If Err.Number Then
'			MsgBox("Bron:" & vbCrLf & Err.Source & vbCrLf & vbCrLf & "Foutnummer: " & Err.Number & vbCrLf & vbCrLf & "Detail:" & vbCrLf & Err.Description)
'			'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
'			msfSQL.CtlRefresh()
'		Else
'			msfSQL.DataSource = datPrimaryRS
'		End If
'		lblRecordCount.Text = CStr(datPrimaryRS.RecordCount)
'		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
'		'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
'		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
'		System.Windows.Forms.Cursor.Current = vbNormal

'	End Function

'	'UPGRADE_WARNING: Event txtPLUS.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub txtPLUS_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPLUS.TextChanged

'		queryChange()

'	End Sub


'	'UPGRADE_WARNING: Event txtWaarde.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
'	Private Sub txtWaarde_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtWaarde.TextChanged

'		queryPLUS()
'		queryChange()

'	End Sub

'	Function queryChange() As Object

'		querySQL = cbSQLBevel.Text & " " & txtPLUS.Text & " " & cbVelden.Text & " " & cbOperatie.Text & " " & txtWaarde.Text
'		txtSQL.Text = querySQL

'	End Function

'	Function queryPLUS() As Object

'		Select Case cbSQLBevel.SelectedIndex
'			Case 0
'				txtPLUS.Text = " * FROM " & lvDatabase.FocusedItem.Text & " WHERE "
'				txtPLUS.Enabled = False

'			Case 1
'				txtPLUS.Text = " FROM " & lvDatabase.FocusedItem.Text & " WHERE "
'				txtPLUS.Enabled = False

'			Case 2
'				txtPLUS.Text = " " & lvDatabase.FocusedItem.Text & " SET " & cbVelden.Text & " = ??? WHERE "
'				txtPLUS.Enabled = True

'			Case Else
'				MsgBox(cbSQLBevel.Text & " nog niet beschikbaar via snelinstructies", MsgBoxStyle.Information)
'				txtSQL.Text = ""
'				Exit Function
'		End Select

'	End Function

'    Private Sub lblRecordCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRecordCount.Click

'    End Sub

'    Private Sub lvDatabase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDatabase.SelectedIndexChanged

'    End Sub

'    Private Sub txtSQL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSQL.TextChanged

'    End Sub

'    Private Sub msfSQL_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msfSQL.Enter

'    End Sub
'End Class