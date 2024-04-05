﻿Option Strict Off
Option Explicit On
Imports System.ComponentModel

Public Class Mim
    Inherits Form

    Sub InitFirst()
        FullLine = New String(Chr(173), 128)
        TableDefOnt(TableOfVarious) = "0000000.ONT" '00
        TableDefOnt(TableOfCustomers) = "0010000.ONT" '01
        TableDefOnt(TableOfSuppliers) = "0020000.ONT" '02
        TableDefOnt(TableOfLedgerAccounts) = "0030000.ONT" '03
        TableDefOnt(TableOfProductsAndServices) = "0040000.ONT" '04
        TableDefOnt(FlJournaal) = "0600000.ONT" '05
        TableDefOnt(TableOfInvoices) = "0200000.ONT" '06
        TableDefOnt(TableOfContracts) = "0700000.ONT" '07
        TableDefOnt(TableDummy) = "90DUMMY.ONT" '08
        TableDefOnt(TableOfCounters) = "00.ONT" '09

        JetTableName(TableOfVarious) = "Allerlei" '00
        JetTableName(TableOfCustomers) = "Klanten" '01
        JetTableName(TableOfSuppliers) = "Leveranciers" '02
        JetTableName(TableOfLedgerAccounts) = "Rekeningen" '03
        JetTableName(TableOfProductsAndServices) = "Produkten" '04
        JetTableName(FlJournaal) = "Journalen" '05
        JetTableName(TableOfInvoices) = "dokumenten" '06
        JetTableName(TableOfContracts) = "Polissen" '07
        JetTableName(TableDummy) = "TmpBestand" '08
        JetTableName(TableOfCounters) = "Tell" '09

        DaysInAMonth(1) = 31
        DaysInAMonth(2) = 29
        DaysInAMonth(3) = 31
        DaysInAMonth(4) = 30
        DaysInAMonth(5) = 31
        DaysInAMonth(6) = 30
        DaysInAMonth(7) = 31
        DaysInAMonth(8) = 31
        DaysInAMonth(9) = 30
        DaysInAMonth(10) = 31
        DaysInAMonth(11) = 30
        DaysInAMonth(12) = 31

        MonthText(1) = "Januari  "
        MonthText(2) = "Februari "
        MonthText(3) = "Maart    "
        MonthText(4) = "April    "
        MonthText(5) = "Mei      "
        MonthText(6) = "Juni     "
        MonthText(7) = "Juli     "
        MonthText(8) = "Augustus "
        MonthText(9) = "September"
        MonthText(10) = "October  "
        MonthText(11) = "November "
        MonthText(12) = "December "
        InitTables()

    End Sub

    Private Sub TotalClose()

        marVersion = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        AutoUnloadCompany(BJPERDAT:=frmBJPERDAT)
        For CountTo = 0 To 9
            rsMAR(CountTo) = Nothing
        Next
        'TODO: adKBDB.Close()
        adKBDB = Nothing

        On Error Resume Next
        adntDB.Close()
        If Err.Number Then Exit Sub
        ntDB.Close()

        adntDB = Nothing
        ntDB = Nothing

    End Sub

    Private Sub Mim_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Dim X As Boolean
        TotalClose()
        If WindowState = FormWindowState.Minimized Then
            WindowState = FormWindowState.Normal
        End If
        X = SettingsSaving(Me)
        On Error Resume Next

    End Sub

    Private Sub Mim_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitFirst()
        MimGlobalDate = Format(Now, "dd/MM/yyyy")
        ProgramLocation = My.Application.Info.DirectoryPath & "\"

        marVersion = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        Text = "marIntegraal.NET " & marVersion
        StartUp()
        SettingsLoading(Me)

        On Error GoTo 0

        adKBDB = New ADODB.Connection
        adTBIB = New ADODB.Connection

        'adKBDB.ConnectionString = marIntegraal.My.Settings.defaultConnectionString
        adKBDB.ConnectionString = adoJetProvider & "Data Source=" & ProgramLocation & "Def\default.def;" & "Persist Security Info=False"
        adKBDB.Open()

        adTBIB.ConnectionString = adoJetProvider & "Data Source=" & ProgramLocation & "\Def\Telebib2.def;" & "Persist Security Info=False"
        adTBIB.Open()

        adKBTable = New ADODB.Recordset With {
            .CursorLocation = ADODB.CursorLocationEnum.adUseServer
        }
        adKBTable.Open("KeuzeBoxData", adKBDB, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTableDirect) '  adLockReadOnly, adCmdTableDirect
        adKBTable.Index = "BestandsNaam"
        With BFKlanten
            .MdiParent = Me
            .Text = "Klanten"
            .BackColor = ColorTranslator.FromOle(QBColor(9))
            .Tag = "1"
            .WindowState = FormWindowState.Minimized
            .Enabled = False
            .Show()
        End With

        With BFLeveranciers
            .MdiParent = Me
            .Text = "Leveranciers"
            .BackColor = ColorTranslator.FromOle(QBColor(12))
            .Tag = "2"
            .WindowState = FormWindowState.Minimized
            .Enabled = False
            .Show()
        End With

        With BFRekeningen
            .MdiParent = Me
            .Text = "Rekeningen"
            .BackColor = ColorTranslator.FromOle(QBColor(15))
            .Tag = "3"
            .WindowState = FormWindowState.Minimized
            .Enabled = False
            .Show()
        End With
        BedrijfOpenenToolStripMenuItem_Click(sender, e)

    End Sub

    Private Sub LicentieToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Licentie")
    End Sub

    Private Sub PleskMailToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Process.Start(New ProcessStartInfo("https://webmail.rv.be"))
    End Sub

    Private Sub HostingToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Process.Start(New ProcessStartInfo("https://web20.foxxl.com:8443"))
    End Sub

    Private Sub VsoftToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Process.Start(New ProcessStartInfo("https://vsoft.be/#/marintegraal"))
    End Sub

    Private Sub CommandToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim myDocumentsFolderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim myDocProcess As New Process

        myDocProcess.StartInfo.FileName = "cmd.exe"
        myDocProcess.StartInfo.WorkingDirectory = myDocumentsFolderPath
        myDocProcess.StartInfo.UseShellExecute = True
        myDocProcess.StartInfo.CreateNoWindow = True
        myDocProcess.Start()

        If LocationCompanyData IsNot "" Then
            Dim myCompanyProcess As New Process
            myCompanyProcess.StartInfo.FileName = "cmd.exe"
            myCompanyProcess.StartInfo.WorkingDirectory = LocationCompanyData
            myCompanyProcess.StartInfo.UseShellExecute = True
            myCompanyProcess.StartInfo.CreateNoWindow = True
            myCompanyProcess.Start()
        End If

    End Sub

    Private Sub BedrijfOpenenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BedrijfOpenenToolStripMenuItem.Click
        Msg = "Hierna worden eerst alle bestanden en openstaande vensters van een actief bedrijf gesloten."
        If GaVerder(Msg, 1, "Bedrijf Openen") Then
            Ktrl = 100
            AutoUnloadCompany(BJPERDAT:=frmBJPERDAT)
            On Error Resume Next
            ntDB.Close()
            On Error GoTo 0
            BedrijfOpenenToolStripMenuItem.Enabled = False
            NieuwBedrijfToolStripMenuItem.Enabled = False
            Dim BedrijfOpenen As New frmBedrijfOpenen
            BedrijfOpenen.MdiParent = Me
            BedrijfOpenen.Show()
        End If

    End Sub

    Private Sub OnderElkaarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnderElkaarToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub NaastElkaarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NaastElkaarToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub PictogrammenSchikkenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PictogrammenSchikkenToolStripMenuItem.Click
        LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub trapsgewijsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles trapsgewijsToolStripMenuItem.Click
        LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Function GaVerder(ByRef Bericht As String, ByRef BedrijfOpenKontrole As Short, ByRef Titel As String) As Short
        If BedrijfOpenKontrole Then
            If BFKlanten.Enabled = True Then
            Else
                GaVerder = True
                Exit Function
            End If
        End If
        KtrlBox = MsgBox(Bericht & vbCrLf & vbCrLf & "Bent U zeker ?", 292, Titel)
        If KtrlBox = 6 Then
            GaVerder = True
        Else
            GaVerder = False
        End If
    End Function

    Private Sub DatumPeriodeBoekjaarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatumPeriodeBoekjaarToolStripMenuItem.Click
        frmBJPERDAT.WindowState = FormWindowState.Normal
    End Sub
    Private Sub KlantenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KlantenToolStripMenuItem.Click
        BFKlanten.WindowState = FormWindowState.Normal
    End Sub
    Private Sub LeveranciersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeveranciersToolStripMenuItem.Click
        BFLeveranciers.WindowState = FormWindowState.Normal
    End Sub
    Private Sub RekeningenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RekeningenToolStripMenuItem.Click
        BFRekeningen.WindowState = FormWindowState.Normal
    End Sub


    Private Sub DiversePostenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiversePostenToolStripMenuItem.Click
        Dim DiversePosten As New FrmJournalEntryInput
        DiversePosten.MdiParent = Me
        DiversePostenToolStripMenuItem.Enabled = False
        DiversePosten.Show()
    End Sub
    Private Sub DiversePostenboekToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiversePostenboekToolStripMenuItem.Click
        Dim dpBoek As New FrmJournalEntriesBook
        'dpBoek.MdiParent = Me
        dpBoek.ShowDialog()
    End Sub
    Private Sub AankoopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AankoopToolStripMenuItem.Click
        Dim AankoopVerrichtingen As New frmAankoopVerrichtingen
        AankoopVerrichtingen.MdiParent = Me
        AankoopToolStripMenuItem.Enabled = False
        AankoopVerrichtingen.Show()

    End Sub
    Private Sub VerkoopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerkoopToolStripMenuItem.Click
        Dim VerkoopVerrichtingen As New frmVerkoopVerrichtingen
        VerkoopVerrichtingen.MdiParent = Me
        VerkoopToolStripMenuItem.Enabled = False
        VerkoopVerrichtingen.Show()
    End Sub

    Private Sub SetUpBoekjaarEnParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetUpBoekjaarEnParametersToolStripMenuItem.Click
        frmSetupBoekjaar.ShowDialog()
    End Sub

    Private Sub NieuwBedrijfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NieuwBedrijfToolStripMenuItem.Click
        Msg = "Hierna worden eerst alle bestanden en openstaande vensters van een actief bedrijf gesloten."
        If GaVerder(Msg, 1, "Nieuw Bedrijf") Then
            Ktrl = 100
            AutoUnloadCompany(BJPERDAT:=frmBJPERDAT)
            On Error Resume Next
            ntDB.Close()
            On Error GoTo 0
            BedrijfOpenenToolStripMenuItem.Enabled = False
            NieuwBedrijfToolStripMenuItem.Enabled = False
            Dim NieuwBedrijf As New frmNieuwBedrijf
            NieuwBedrijf.MdiParent = Me
            NieuwBedrijf.Show()
        End If
    End Sub

    Private Sub ArtikelProductDienstToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtikelProductDienstToolStripMenuItem.Click
        Dim ProductFiche As New frmProductFiche
        ProductFiche.MdiParent = Me
        ArtikelProductDienstToolStripMenuItem.Enabled = False
        ProductFiche.Show()
    End Sub

    Private Sub LayOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LayOutToolStripMenuItem.Click
        Dim LayOutDocument As New LayOutpdfDokument
        LayOutToolStripMenuItem.Enabled = False
        LayOutpdfDokument.Show
    End Sub

    Private Sub SQLBewerkingenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLBewerkingenToolStripMenuItem.Click
        Dim SqlBewerkingen As New SQLBewerkingen
        SQLBewerkingenToolStripMenuItem.Enabled = False
        SqlBewerkingen.Show
    End Sub

    Private Sub InboekenKwijtingenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InboekenKwijtingenToolStripMenuItem.Click
        Dim InboekenKwijtingen As New KwijtingInboeken
        InboekenKwijtingenToolStripMenuItem.Enabled = False
        KwijtingInboeken.Show
    End Sub

    Private Sub BetalingsverzoekToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BetalingsverzoekToolStripMenuItem.Click
        Dim BetalingsVerzoeken As New BetalingsVerzoek
        BetalingsverzoekToolStripMenuItem.Enabled = False
        BetalingsVerzoek.Show
    End Sub

    Private Sub AfsluitenToolStripMenu_Click(sender As Object, e As EventArgs) Handles AfsluitenToolStripMenu.Click
        Ktrl = 100
        'TotalClose()
        Close()
    End Sub

    Private Sub Mim_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim hierCancel As Boolean = e.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = CloseReason.ApplicationExitCall
        If Me.Report.IsOpen = True Then
            MsgBox("Sluit eerst het PDF venster a.u.b.", MsgBoxStyle.Information)
            hierCancel = True
        End If
        e.Cancel = hierCancel
    End Sub

    Private Sub DiverseGebruikersficheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiverseGebruikersficheToolStripMenuItem.Click

        With XDocument 
            .WindowState = FormWindowState.Normal 
            .Enabled = True 
            .ShowDialog 
            .Dispose
        End With

    End Sub

    Private Sub LijstRapportageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LijstRapportageToolStripMenuItem.Click

        With LijstRapportage 
            .WindowState = FormWindowState.Normal 
            .Enabled = True 
            .ShowDialog 
            .Dispose
        End With
        
    End Sub

    Private Sub HistoriekGrootboekInSchermToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoriekGrootboekInSchermToolStripMenuItem.Click

        HistoriekGrootboekInSchermToolStripMenuItem.Enabled = False 
        With HistoriekRekeningScherm 
            .MdiParent = Me
            .WindowState = FormWindowState.Normal 
            .Enabled = True 
            .Show 
        End With

    End Sub

    Private Sub FinanciëelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinanciëelToolStripMenuItem.Click

       FinanciëelToolStripMenuItem.Enabled = False 
        With FinancieleVerrichtingen 
            .MdiParent = Me
            .WindowState = FormWindowState.Normal 
            .Enabled = True 
            .Show 
        End With

    End Sub

    Private Sub BriefwisselingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BriefwisselingToolStripMenuItem.Click

        BriefwisselingToolStripMenuItem.Enabled = False 
        With Briefwisseling 
            .MdiParent = Me
            .WindowState = FormWindowState.Normal 
            .Enabled = True 
            .Show 
        End With
        
    End Sub

    Private Sub AankoopboekToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AankoopboekToolStripMenuItem.Click

        aIndex = TableOfSuppliers 
         With AVBoek
            .WindowState = FormWindowState.Normal 
            .Enabled = True
            .ShowDialog 
            .Dispose
        End With
        
    End Sub

    Private Sub AccessTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccessTestToolStripMenuItem.Click
        
        'Form1.ShowDialog 

    End Sub

    Private Sub AswebGboUitwisselingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AswebGboUitwisselingToolStripMenuItem.Click

        With TelebibIN
            .WindowState = FormWindowState.Normal
            .Enabled = True
            .ShowDialog
            .Dispose
        End With

    End Sub

End Class
