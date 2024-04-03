Option Strict Off
Option Explicit On
Imports System.ComponentModel

Public Class Mim
    Inherits System.Windows.Forms.Form

    Sub InitEerst()
        Lijntje = New String(Chr(173), 128)
        Bestand(FlAllerlei) = "0000000.ONT" '00
        Bestand(FlKlant) = "0010000.ONT" '01
        Bestand(FlLeverancier) = "0020000.ONT" '02
        Bestand(FlRekening) = "0030000.ONT" '03
        Bestand(FlProdukt) = "0040000.ONT" '04
        Bestand(FlJournaal) = "0600000.ONT" '05
        Bestand(Fldokument) = "0200000.ONT" '06
        Bestand(FlPolis) = "0700000.ONT" '07
        Bestand(FlDummy) = "90DUMMY.ONT" '08
        Bestand(FlTeller) = "00.ONT" '09

        bstNaam(FlAllerlei) = "Allerlei" '00
        bstNaam(FlKlant) = "Klanten" '01
        bstNaam(FlLeverancier) = "Leveranciers" '02
        bstNaam(FlRekening) = "Rekeningen" '03
        bstNaam(FlProdukt) = "Produkten" '04
        bstNaam(FlJournaal) = "Journalen" '05
        bstNaam(Fldokument) = "dokumenten" '06
        bstNaam(FlPolis) = "Polissen" '07
        bstNaam(FlDummy) = "TmpBestand" '08
        bstNaam(FlTeller) = "Tell" '09

        DagenInMaand(1) = 31
        DagenInMaand(2) = 29
        DagenInMaand(3) = 31
        DagenInMaand(4) = 30
        DagenInMaand(5) = 31
        DagenInMaand(6) = 30
        DagenInMaand(7) = 31
        DagenInMaand(8) = 31
        DagenInMaand(9) = 30
        DagenInMaand(10) = 31
        DagenInMaand(11) = 30
        DagenInMaand(12) = 31

        MaandTekst(1) = "Januari  "
        MaandTekst(2) = "Februari "
        MaandTekst(3) = "Maart    "
        MaandTekst(4) = "April    "
        MaandTekst(5) = "Mei      "
        MaandTekst(6) = "Juni     "
        MaandTekst(7) = "Juli     "
        MaandTekst(8) = "Augustus "
        MaandTekst(9) = "September"
        MaandTekst(10) = "October  "
        MaandTekst(11) = "November "
        MaandTekst(12) = "December "
        InitBestanden()

    End Sub

    Private Sub TotalClose()

        marVersion = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        AutoUnloadBedrijf(BJPERDAT:=frmBJPERDAT)
        For TelTot = 0 To 9
            'UPGRADE_NOTE: Object rsMAR() may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsMAR(TelTot) = Nothing
        Next
        'TODO: adKBDB.Close()
        'UPGRADE_NOTE: Object adKBDB may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        adKBDB = Nothing

        On Error Resume Next
        adntDB.Close()
        If Err.Number Then Exit Sub
        ntDB.Close()

        'UPGRADE_NOTE: Object adntDB may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        adntDB = Nothing
        'UPGRADE_NOTE: Object ntDB may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        ntDB = Nothing


    End Sub


    Private Sub Mim_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Dim X As Boolean
        TotalClose()
        If WindowState = System.Windows.Forms.FormWindowState.Minimized Then
            WindowState = System.Windows.Forms.FormWindowState.Normal
        End If
        X = InstellingenBewaard(Me)
        On Error Resume Next

    End Sub

    Private Sub Mim_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitEerst()
        Rdt = Format(Now, "dd/MM/yyyy")
        ProgrammaLokatie = My.Application.Info.DirectoryPath & "\"

        marVersion = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        Text = "marIntegraal.NET " & marVersion
        opStart()
        LaadInstellingen(Me)

        On Error GoTo 0

        adKBDB = New ADODB.Connection
        adTBIB = New ADODB.Connection

        'adKBDB.ConnectionString = marIntegraal.My.Settings.defaultConnectionString
        adKBDB.ConnectionString = adoJetProvider & "Data Source=" & ProgrammaLokatie & "Def\default.def;" & "Persist Security Info=False"
        adKBDB.Open()

        adTBIB.ConnectionString =  adoJetProvider & "Data Source=" & ProgrammaLokatie & "\Def\Telebib2.def;" & "Persist Security Info=False"
        adTBIB.Open()

        adKBTable = New ADODB.Recordset
        adKBTable.CursorLocation = ADODB.CursorLocationEnum.adUseServer
        adKBTable.Open("KeuzeBoxData", adKBDB, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTableDirect) '  adLockReadOnly, adCmdTableDirect
        adKBTable.Index = "BestandsNaam"
        With BFKlanten
            .MdiParent = Me
            .Text = "Klanten"
            .BackColor = System.Drawing.ColorTranslator.FromOle(QBColor(9))
            .Tag = "1"

            .WindowState = FormWindowState.Minimized
            .Enabled = False
            .Show()
        End With

        With bfLeveranciers
            .MdiParent = Me
            .Text = "Leveranciers"
            .BackColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
            .Tag = "2"
            .WindowState = FormWindowState.Minimized
            .Enabled = False
            .Show()
        End With

        With BFRekeningen
            .MdiParent = Me
            .Text = "Rekeningen"
            .BackColor = System.Drawing.ColorTranslator.FromOle(QBColor(15))
            .Tag = "3"
            .WindowState = FormWindowState.Minimized
            .Enabled = False
            .Show()
        End With
        BedrijfOpenenToolStripMenuItem_Click(sender, e)

    End Sub

    Private Sub BedrijfOpenenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BedrijfOpenenToolStripMenuItem.Click
        Msg = "Hierna worden eerst alle bestanden en openstaande vensters van een actief bedrijf gesloten."
        If GaVerder(Msg, 1, "Bedrijf Openen") Then
            Ktrl = 100
            AutoUnloadBedrijf(BJPERDAT:=frmBJPERDAT)
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
        Dim DiversePosten As New frmDiversePosten
        DiversePosten.MdiParent = Me
        DiversePostenToolStripMenuItem.Enabled = False
        DiversePosten.Show()
    End Sub
    Private Sub DiversePostenboekToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiversePostenboekToolStripMenuItem.Click
        Dim dpBoek As New frmDiversePostenBoek
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
            AutoUnloadBedrijf(BJPERDAT:=frmBJPERDAT)
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

    Private Sub HostingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HostingToolStripMenuItem.Click

        Dim BrowserHosting As New Browser 

        With BrowserHosting 
            .StartingAddress = "https://ccp.my-hosting-panel.com"
            .MdiParent = Me
            .Text = "Hosting"
            .WindowState = FormWindowState.Maximized 
            .Enabled = True 
            .Show()
        End With
        HostingToolStripMenuItem.Enabled = False 

    End Sub

    Private Sub SmartermailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SmartermailToolStripMenuItem.Click

        Dim BrowserSmartermail As New Browser 

        With BrowserSmartermail 
            .StartingAddress = "http://webmail.herdersem.be"
            .MdiParent = Me
            .Text = "SmarterMail"
            .WindowState = FormWindowState.Maximized 
            .Enabled = True 
            .Show()
        End With
        SmartermailToolStripMenuItem.Enabled = False 

    End Sub

    Private Sub marIntegraalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles marIntegraalToolStripMenuItem.Click

        Dim BrowserMAR As New Browser 

        With BrowserMAR 
            .StartingAddress = "http://www.rv.be/marIntegraal.aspx"
            .MdiParent = Me
            .Text = "marIntegraal"
            .WindowState = FormWindowState.Maximized 
            .Enabled = True 
            .Show()
        End With
        marIntegraalToolStripMenuItem.Enabled = False 

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

        aIndex = FlLeverancier 
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
