﻿Module modMIM
    Sub AutoLoadBedrijf(BJPERDAT)
        Dim destpath As String
        Dim X As Short
        Dim ptel As Short
        Dim ktrlfl As Short
        Dim T As Short
        Dim FlTemp As Integer
        Dim FlTemp2 As Integer
        Dim AktievePeriode As Short
        Dim XX As String = ""
        Dim YY As String
        Dim Titel As String
        Dim AT As String

        XisEuroWisBEF = False
        Static ProducentKopij As String

        Err.Clear()
        On Error Resume Next

        'Menuopties toegang geven
        Mim.SysteemToolStripMenuItem.Enabled = True
        Mim.FichesToolStripMenuItem.Enabled = True
        Mim.DocumentToolStripMenuItem.Enabled = True
        Mim.BoekhoudingToolStripMenuItem.Enabled = True
        If Trim(ProducentNummer) = "" Then
        Else
            Mim.ContractbeheerToolStripMenuItem.Enabled = True
        End If

        'For TelTot = 1 To 5
        ' Mim.MenuTitel(TelTot).Enabled = True
        ' Next
        ' For T = 1 To 4
        ' BasisB(T).Enabled = True
        ' Next
        ' Mim.Basis(11).Enabled = True

        BJPERDAT.Hide()
        BJPERDAT.DatumVerwerking.Value = Rdt
        BJPERDAT.PeriodeBoekjaar.Items.Clear()

        Dim c As String = ""
        Dim actiefBJ() As String
        Dim periodesBJ() As String


        Err.Clear()
        On Error GoTo 0

        FlTemp = FreeFile()

        Dim fullPath = BedrijfsLokatie & "9999.OXT"
        Dim FlFree As Integer

ProbeerNogEens:
        If Dir(fullPath) = "" Then
            MsgBox("9999.OXT niet te vinden in " & BedrijfsLokatie)
            FlFree = FreeFile()
            FileOpen(FlFree, fullPath, OpenMode.Output)
            PrintLine(FlFree, "0,2016,6")
            FileClose(FlFree)
            GoTo ProbeerNogEens
        Else
            FileOpen(FlTemp, fullPath, OpenMode.Input)
            If Err.Number Then
                MsgBox(Err.Description & vbCrLf & fullPath)
            Else
                c = LineInput(FlTemp)
                FileClose(FlTemp)
            End If
            actiefBJ = Split(c, ",")
        End If

        AktiefBoekjaar = Val(actiefBJ(0))
        For TelTot = 9 To 0 Step -1
            If Dir(BedrijfsLokatie & "DEF" & Format(TelTot, "00") & ".OXT") <> "" Then
                FlTemp2 = FreeFile()
                FileOpen(FlTemp2, BedrijfsLokatie & "DEF" & Format(TelTot, "00") & ".OXT", OpenMode.Input)
                c = LineInput(FlTemp2)
                'periodesBJ = Split(c, ",")
                XX = Left(c, 4)
                FileClose(FlTemp2)
                BJPERDAT.Boekjaar.Items.Insert(0, XX)
            End If
        Next

        AktievePeriode = Val(actiefBJ(2))
        BJPERDAT.Boekjaar.SelectedIndex = AktiefBoekjaar
        bstNaam(FlTeller) = "jr" & BJPERDAT.Boekjaar.Text

        FlTemp = FreeFile()
        FileOpen(FlTemp, BedrijfsLokatie & "DEF" & Format(AktiefBoekjaar, "00") & ".OXT", OpenMode.Input)
        c = LineInput(FlTemp)
        periodesBJ = Split(c, ",")
        FileClose(FlTemp)

        For T = 0 To UBound(periodesBJ)
            A = periodesBJ(T)
            If T = 0 Then
                BoekjaarVanTot = Left(A, 8)
            End If
            If T = UBound (periodesBJ) Then
                BoekjaarVanTot = BoekjaarVanTot + Right(A, 8)
            End If

            If A = Space(16) Then
                BJPERDAT.PeriodeBoekjaar.SelectedIndex = 0
                YY = BJPERDAT.PeriodeBoekjaar.Text
                BoekjaarVanTot = Mid(YY, 7, 4) & Mid(YY, 4, 2) & Mid(YY, 1, 2) & Mid(XX, 20, 4) & Mid(XX, 17, 2) & Mid(XX, 14, 2)
                Exit For
            Else
                XX = Mid(A, 7, 2) & "/" & Mid(A, 5, 2) & "/" & Left(A, 4) & " - " & Right(A, 2) & "/" & Mid(A, 13, 2) & "/" & Mid(A, 9, 4)
                BJPERDAT.PeriodeBoekjaar.Items.Add(XX)
            End If
        Next


        If AktievePeriode - 1 > BJPERDAT.PeriodeBoekjaar.Items.Count Then
            MsgBox("Het hoogste boekjaar wordt automatisch ingeladen.  Laatste bewerking gebeurde in een boekjaar met meer periodes dan nu mogelijk.  De eerste periode van het hoogste boekjaar wordt hierna automatisch geaktiveerd")
            AktievePeriode = 1
        End If
        BJPERDAT.PeriodeBoekjaar.SelectedIndex = AktievePeriode - 1
        AT = BJPERDAT.PeriodeBoekjaar.Text
        PeriodeVanTot = Mid(AT, 7, 4) & Mid(AT, 4, 2) & Left(AT, 2) & Right(AT, 4) & Mid(AT, 17, 2) & Mid(AT, 14, 2)
        FileClose(FlTemp)

        adntDB = New ADODB.Connection

        On Error Resume Next
        Err.Clear()
        ' voor JET
        'ntDB = NTRuimte.OpenDatabase(BedrijfsLokatie & NetDataLokatie & "marnt.MDV", False, False)
        BAModus = 1
        jetConnect = adoJetProvider & "Data Source=" & BedrijfsLokatie & NetDataLokatie & "\marnt.mdv;" & "Persist Security Info=False"
        adntDB.Open(jetConnect)

        If String99(Lees, 20) = "5" Then
            Mim.ContractbeheerToolStripMenuItem.Enabled = True
            ProducentNummer = "60423"
        Else
            ProducentNummer = ""
        End If

        If Len(Trim(String99(Lees, 296))) = 0 Then
            MsgBox("Gelieve Setup Boekingen en algemene instellingen : munt van de Boekhouding in te stellen a.u.b.  Pér bedrijf, pér boekjaar.  Hierna wordt voorlopig verder gewerkt in EUR.")
            bhEuro = True
            SS99("EUR", 296)

        ElseIf String99(Lees, 296) = "BEF" Then
            bhEuro = False
        ElseIf String99(Lees, 296) = "EUR" Then
            bhEuro = True
            'MsgBox(String99(Lees, 296))
        Else
            bhEuro = False
        End If
        If bhEuro = False Then
            MsgBox("Hoogste boekjaar enkel nog in EUR vanaf versie 6.5.301 of hoger.  Indien U nog BEF verrichtingen wenst uit te voeren, gelieve een eerdere versie opnieuw te installeren a.u.b.", MsgBoxStyle.Information)
            End
        End If
        BJPERDAT.MdiParent = Mim
        BJPERDAT.Enabled = True
        BJPERDAT.Visible = True
        BJPERDAT.WindowState = FormWindowState.Minimized
        BJPERDAT.Show()

        BFKlanten.Enabled = True
        BFLeveranciers.Enabled = True
        BFRekeningen.Enabled = True

        rsJournaal = New ADODB.Recordset
        If ntDB.Connect <> "" Then
            rsJournaal.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Else
            rsJournaal.CursorLocation = ADODB.CursorLocationEnum.adUseServer
        End If
        rsJournaal.Open("SELECT TOP 1 * FROM Journalen", adntDB, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        Exit Sub


ErrorOpvang:
        MsgBox(vBC(ktrlfl, ptel) & " " & ErrorToString())
        Resume Next

    End Sub

    Sub AutoUnloadBedrijf(BJPERDAT)
        Dim T As Short
        Dim LastUsed As String

        Ktrl = 100
        BJPERDAT.Close()
        'TODO:CloseOpenWindows()

        '2. Tabellen sluiten
        bClose(99)

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        On Error Resume Next
        rsJournaal.Close()
        rsJournaal = Nothing

        For TelTot = FlAllerlei To FlPolis
            rsMAR(TelTot).Close()
        Next

        'Menuopties beperken
        Mim.SysteemToolStripMenuItem.Enabled = False
        Mim.FichesToolStripMenuItem.Enabled = False
        Mim.DocumentToolStripMenuItem.Enabled = False
        Mim.BoekhoudingToolStripMenuItem.Enabled = False
        Mim.ContractbeheerToolStripMenuItem.Enabled = False

        'For TelTot = 1 To 6
        'TODO
        'Mim.MenuTitel(TelTot).Enabled = False
        'Next

        With BFKlanten
            .Enabled = False
            .WindowState = System.Windows.Forms.FormWindowState.Minimized
        End With
        With BFLeveranciers
            .Enabled = False
            .WindowState = System.Windows.Forms.FormWindowState.Minimized
        End With
        With BFRekeningen
            .Enabled = False
            .WindowState = System.Windows.Forms.FormWindowState.Minimized
        End With
        With BJPERDAT
            .Close()
        End With
        'TODO: Mim.AV(11).Enabled = False
        'TODO: Mim.Basis(11).Enabled = False

        BedrijfsLokatie = Lokatie
        Mim.Text = My.Application.Info.Title
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        FileClose()
        BedrijfsLokatie = ""

    End Sub


    Function InitBestanden() As Boolean
        Dim T As Integer

        InitBestanden = True
        FlAantalIndexen(FlAllerlei) = 1
        FlIndexIs(FlAllerlei, 0) = "v004 " : FlIndexLen(FlAllerlei, 0) = 13 : FLIndexCaption(FlAllerlei, 0) = "Partij"
        FlIndexIs(FlAllerlei, 1) = "v005 " : FlIndexLen(FlAllerlei, 1) = 20 : FLIndexCaption(FlAllerlei, 1) = "SPtype"

        FlAantalIndexen(FlKlant) = 1
        FlIndexIs(FlKlant, 0) = "A110 " : FlIndexLen(FlKlant, 0) = 12 : FLIndexCaption(FlKlant, 0) = "Nummer"
        FlIndexIs(FlKlant, 1) = "A100 " : FlIndexLen(FlKlant, 1) = 10 : FLIndexCaption(FlKlant, 1) = "Bedrijfsnaam"

        FlAantalIndexen(FlLeverancier) = 1
        FlIndexIs(FlLeverancier, 0) = "A110 " : FlIndexLen(FlLeverancier, 0) = 12 : FLIndexCaption(FlLeverancier, 0) = "Nummer"
        FlIndexIs(FlLeverancier, 1) = "A100 " : FlIndexLen(FlLeverancier, 1) = 10 : FLIndexCaption(FlLeverancier, 1) = "Bedrijfsnaam"

        FlAantalIndexen(FlRekening) = 1
        FlIndexIs(FlRekening, 0) = "v019 " : FlIndexLen(FlRekening, 0) = 7 : FLIndexCaption(FlRekening, 0) = "RekeningNummer"
        FlIndexIs(FlRekening, 1) = "v020 " : FlIndexLen(FlRekening, 1) = 10 : FLIndexCaption(FlRekening, 1) = "Omschrijving"

        FlAantalIndexen(FlProdukt) = 1
        FlIndexIs(FlProdukt, 0) = "v102 " : FlIndexLen(FlProdukt, 0) = 13 : FLIndexCaption(FlProdukt, 0) = "Artikelkode EAN"
        FlIndexIs(FlProdukt, 1) = "v105 " : FlIndexLen(FlProdukt, 1) = 10 : FLIndexCaption(FlProdukt, 1) = "Omschrijving"

        FlAantalIndexen(FlJournaal) = 4
        FlIndexIs(FlJournaal, 0) = "v070 " : FlIndexLen(FlJournaal, 0) = 15 : FLIndexCaption(FlJournaal, 0) = "Rekening Boekdatum"
        FlIndexIs(FlJournaal, 1) = "v033 " : FlIndexLen(FlJournaal, 1) = 11 : FLIndexCaption(FlJournaal, 1) = "Dokumentnummer"
        FlIndexIs(FlJournaal, 2) = "v038 " : FlIndexLen(FlJournaal, 2) = 8 : FLIndexCaption(FlJournaal, 2) = "Betalingsstuk"
        FlIndexIs(FlJournaal, 3) = "v041 " : FlIndexLen(FlJournaal, 3) = 1 : FLIndexCaption(FlJournaal, 3) = "Bewerkingsvlag"
        FlIndexIs(FlJournaal, 4) = "v066 " : FlIndexLen(FlJournaal, 4) = 7 : FLIndexCaption(FlJournaal, 4) = "Boekdatum"

        FlAantalIndexen(Fldokument) = 2
        FlIndexIs(Fldokument, 0) = "v033 " : FlIndexLen(Fldokument, 0) = 11 : FLIndexCaption(Fldokument, 0) = "DokumentNummer"
        FlIndexIs(Fldokument, 1) = "v034 " : FlIndexLen(Fldokument, 1) = 13 : FLIndexCaption(Fldokument, 1) = "Partij"
        FlIndexIs(Fldokument, 2) = "A000 " : FlIndexLen(Fldokument, 2) = 12 : FLIndexCaption(Fldokument, 2) = "KontraktNummer"

        FlAantalIndexen(FlPolis) = 3
        FlIndexIs(FlPolis, 0) = "A000 " : FlIndexLen(FlPolis, 0) = 12 : FLIndexCaption(FlPolis, 0) = "Polisnummer"
        FlIndexIs(FlPolis, 1) = "A110 " : FlIndexLen(FlPolis, 1) = 12 : FLIndexCaption(FlPolis, 1) = "Klantkode"
        FlIndexIs(FlPolis, 2) = "A010 " : FlIndexLen(FlPolis, 2) = 4 : FLIndexCaption(FlPolis, 2) = "Maatschappij"
        FlIndexIs(FlPolis, 3) = "v167 " : FlIndexLen(FlPolis, 3) = 30 : FLIndexCaption(FlPolis, 3) = "MaandKlantMijPolis"

        FlAantalIndexen(FlTeller) = 0
        FlIndexIs(FlTeller, 0) = "v071 " : FlIndexLen(FlTeller, 0) = 5 : FLIndexCaption(FlTeller, 0) = "Setup Parameter"

        FlAantalIndexen(FlDummy) = 0
        FlIndexIs(FlDummy, 0) = "v089 " : FlIndexLen(FlDummy, 0) = 20 : FLIndexCaption(FlDummy, 0) = "Plaatselijk sorteren"

        For T = FlAllerlei To FlTeller
            If TeleBibPagina(T) Then
            Else
                MsgBox("Fout tijdens inladen bestandsdefinities.  Herinstalleer het programma en/of kontakteer Vsoft")
                InitBestanden = False
            End If
        Next
    End Function


    Function InstellingenBewaard(ByRef frmVenster As System.Windows.Forms.Form) As Boolean

        Err.Clear() : InstellingenBewaard = True
        SaveSetting(My.Application.Info.ProductName, frmVenster.Name, "Top", frmVenster.Top.ToString)
        SaveSetting(My.Application.Info.ProductName, frmVenster.Name, "Links", frmVenster.Left.ToString)
        SaveSetting(My.Application.Info.ProductName, frmVenster.Name, "Breedte", frmVenster.Width.ToString)
        SaveSetting(My.Application.Info.ProductName, frmVenster.Name, "Hoogte", frmVenster.Height.ToString)
        If Err.Number Then InstellingenBewaard = False

    End Function
    Sub LaadInstellingen(ByRef frmVenster As System.Windows.Forms.Form)
        Dim valTop As Integer = Val(GetSetting(My.Application.Info.ProductName, frmVenster.Name, "Top"))
        Dim valLeft As Integer = Val(GetSetting(My.Application.Info.ProductName, frmVenster.Name, "Top"))
        Dim valWidth As Integer = Val(GetSetting(My.Application.Info.ProductName, frmVenster.Name, "Breedte"))
        Dim valHeight As Integer = Val(GetSetting(My.Application.Info.ProductName, frmVenster.Name, "Hoogte"))

        If valTop + valLeft + valWidth + valHeight = 0 Then
        Else
            frmVenster.Top = valTop
            frmVenster.Left = valLeft
            frmVenster.Width = valWidth
            frmVenster.Height = valHeight
        End If
    End Sub
    Function LaadTekst(ByRef Onderdeel As String, ByRef SubDeel As String) As Object

        On Error Resume Next
        If InStr(Onderdeel, ";") Then
            LaadTekst = GetSetting(Left(Onderdeel, InStr(Onderdeel, ";") - 1), Mid(Onderdeel, InStr(Onderdeel, ";") + 1), SubDeel)
        Else
            LaadTekst = GetSetting(My.Application.Info.ProductName, Onderdeel, SubDeel)
        End If

EenFoutBijINLaden:
    End Function
    Sub BeWaarTekst(ByRef Onderdeel As String, ByRef SubDeel As String, ByRef Element As String)

        SaveSetting(My.Application.Info.ProductName, Onderdeel, SubDeel, Element)

    End Sub

    Sub SS99(ByRef StringInhoud As String, ByRef NummerRec As Short)

        Fl99Record = StringInhoud
        SetString99(NummerRec)

    End Sub

    Sub SetString99(ByRef NummerSleutel As Short)
        Dim DummySleutel As String

        DummySleutel = "s" & Format(NummerSleutel, "000") & " "
        bGet(FlTeller, 0, DummySleutel)
        If Ktrl Then
            If BAModus = 1 Then

                TLBRecord(FlTeller) = ""
                vBib(FlTeller, DummySleutel, "v071")
                vBib(FlTeller, Fl99Record, "v217")
                bInsert(FlTeller, 0)
            Else
                MsgBox("Onlogika btrieve versie !")
            End If
        Else
            RecordToVeld(FlTeller)
            If BAModus = 1 Then
                vBib(FlTeller, Fl99Record, "v217 ")
                bUpdate(FlTeller, 0)
                If Ktrl Then
                    MsgBox("UpdateStop Teller. kontakteer vsoft")
                End If
            Else
                MsgBox("Onlogika btrieve versie !")
            End If
        End If
        bClose(FlTeller)

    End Sub


    Public Function VeldOK(ByRef FlHier As Short, ByRef VeldNaam As String, Optional ByRef VeldDef As String = "") As Integer
        Dim AantalRC As Short

        If rsMAR(FlHier).State = ADODB.ObjectStateEnum.adStateClosed Then
            Ktrl = bOpen(FlHier)
        End If
        On Error Resume Next
        Err.Clear()
        Msg = rsMAR(FlHier).Fields(VeldNaam).Name
        If Err.Number = 0 Then
            VeldOK = Err.Number
            Exit Function
        ElseIf VeldDef = "" Then
            VeldOK = Err.Number
            Exit Function
        Else
            bClose(FlHier)
            Msg = "ALTER TABLE " & bstNaam(FlHier) & " ADD COLUMN " & VeldNaam & " " & VeldDef & ";"
            If MsgBox(Msg & vbCr & vbCr & "SQL-instructie uitvoeren", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Err.Clear()
                adntDB.Execute(Msg, AantalRC)
                If Err.Number Then
                    MsgBox("Foutmelding bron: " & Err.Source & vbCrLf & "Foutkodenummer: " & Err.Number & vbCrLf & vbCrLf & "Foutmelding omschrijving:" & vbCrLf & Err.Description)
                Else
                    MsgBox(Msg & " met succes uitgevoerd", MsgBoxStyle.Information)

                End If
                VeldOK = Err.Number
            Else
                VeldOK = 99
            End If
        End If

    End Function

    Sub CloseOpenWindows()

        On Error Resume Next

        'SqlSearch.Close()
        'UPGRADE_ISSUE: DoEvents does not return a value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8D115264-E27F-4472-A684-865A00B5E826"'
        'XDoEvents = System.Windows.Forms.Application.DoEvents()
        'Xlog.Close()
        ''UPGRADE_ISSUE: DoEvents does not return a value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8D115264-E27F-4472-A684-865A00B5E826"'
        'XDoEvents = System.Windows.Forms.Application.DoEvents()
        'SetupEnParameters.Close()
        'Afbeeldingen.Close()
        'xDokument.Close()
        'VrijBericht.Close()
        'Unload VoorkeurDefinities
        'Unload ProgrammaStruktuur
        'HistoriekSQL.Close()
        'Unload Importeren
        'SQLLijsten.Close()
        'LayOutDokument.Close()
        'Unload StandaardKostPrijsKaart
        'Venster.Close()
        'DirekteAankoop.Close()
        'Unload DirekteVerkoop
        'DiversePosten.Close()
        'InbrengFinancieel.Close()

    End Sub
    Function TeleBibClick(ByRef Fl As Integer) As Boolean
        Dim PositieX As Integer
        Dim aa As String
        Dim LogTekst As String
        Dim BoxType As Integer
        Dim BoxMask As String = ""
        Dim t As Integer
        Dim CrText As String

        TeleBibClick = False
        Select Case Fl
            Case FlKlant To FlPolis 'Hoofdfiches
                If TeleBibPagina(Fl) = False Then
                    Beep()
                    Exit Function
                End If
            Case Fldokument 'Aankoop verkoopdokumenten
                If TLBPag2("020" & Left(FVT(Fldokument, 0), 1)) = False Then
                    Beep()
                    Exit Function
                End If
            Case 10, 12, 18, 21, 28 'Diverse gebruikersfiches
                If TLBPag2(Format(Fl, "000")) = False Then
                    Beep()
                    Exit Function
                End If
            Case 1000 To 1999 'As1 verzoekdokument
                If TLBPag3("AS1" & Format(Fl - 1000, "000")) = False Then
                    Beep()
                    Exit Function
                End If
            Case 2000 To 2099 'Diverse groepen eigen aan ROELANDT systeem
                If TLBPag2("GROEP" & Format(Fl - 2000, "00")) = False Then
                    Beep()
                    Exit Function
                End If
            Case 3000 To 3099 'Schadedossiers e.a.
                If TLBPag2("SCHADE" & Format(Fl - 3000, "00")) = False Then
                    Beep()
                    Exit Function
                End If
            Case 4000 To 4999 'takkodes
                If TLBPag3("TAK" & Format(Fl - 4000)) = False Then
                    Beep()
                    Exit Function
                End If
            Case Else
                MsgBox("stop in telebibclick, fl=" & Format(Fl))
        End Select
        Select Case Fl
            Case FlKlant
                LogTekst = "BIB voor Klanten"
            Case FlLeverancier
                LogTekst = "BIB voor Leveranciers"
            Case FlRekening
                LogTekst = "BIB voor Algemene Rekeningen"
            Case FlProdukt
                LogTekst = "BIB voor Artikels/Diensten"
            Case FlPolis
                LogTekst = "BIB voor contracten"
            Case Fldokument
                LogTekst = "BIB voor Aan- en Verkoopdokumenten"
            Case 1000 To 1999
                Fl = FlAllerlei
                LogTekst = "BIB AS1/verzoeken"
            Case 2000 To 2099
                Fl = FlAllerlei
                LogTekst = "BIB Polis " & vBibTekst(FlPolis, "#A000 #")
            Case 3000 To 3099
                Fl = FlAllerlei
                LogTekst = "Bib Schade " & vBibTekst(FlAllerlei, "#C000 #")
            Case 4000 To 4099
                Fl = FlAllerlei
                LogTekst = "BIB DetailPolis " & vBibTekst(FlPolis, "#A000 #")
            Case Else
                Fl = FlAllerlei
                LogTekst = " BIB Allerlei"
        End Select

        xLog.Close()
        xLog.Dispose()
        xLog.Hide()
        xLog.Text = xLog.Text & LogTekst
        xLog.Tag = Str(Fl)
        If Fl = Fldokument Then
            If vsfPro Then
                xLog.WijzigenLijn.Enabled = True
                xLog.Afsluiten.Text = "Speciaal"
            Else
                xLog.WijzigenLijn.Enabled = False
                xLog.Afsluiten.Text = "Vernietig!"
            End If
        End If

        'xLog.X.set_ColWidth(0, 45)
        'xLog.X.set_ColWidth(1, 2805)
        'xLog.X.set_ColWidth(2, 6165)
        'xLog.X.set_ColAlignment(0, MSFlexGridLib.AlignmentSettings.flexAlignLeftTop)
        'xLog.X.set_ColAlignment(1, MSFlexGridLib.AlignmentSettings.flexAlignLeftTop)
        'xLog.X.set_ColAlignment(2, MSFlexGridLib.AlignmentSettings.flexAlignLeftTop)
        'xLog.X.Row = 1
        'xLog.X.Col = 2

        Dim codeString As String
        Dim inputString As String
        Dim omsString As String
        Dim tijdelijk As String
        Dim crText2 As String


XLogShow:
        'SetDefault(xLog.WijzigenLijn, True)
        xLog.Afsluiten.TabStop = True
        XLogKey = ""
        'xLog.SSTab1.TabPages.Item(1).Visible = False
        xLog.ShowDialog()
        If XLogKey <> "" Then
            t = 0
            'xLog.X.Col = 2
            Do While Trim(TeleBibCode(t)) <> ""
                Dim itemX As ListViewItem
                itemX = xLog.X.Items.Item(t)
                codeString = itemX.SubItems.Item(0).Text
                omsString = itemX.SubItems.Item(1).Text
                inputString = itemX.SubItems.Item(2).Text
                crText2 = inputString
                If Mid(codeString, 10, 1) = "*" And crText2 = "" Then

                    MsgBox("Invoer voor '" & RTrim(omsString) & "'" & vbCrLf & vbCrLf & "is verplicht !", 0, "Vervolledig a.u.b.")
                    GoTo XLogShow
                End If
                t = t + 1
            Loop
            If xLog.Afsluiten.Text = "Speciaal" Then
                Msg = "Gegevens bestaande fiche wijzigen.  Bent U zeker ?"
                Ktrl = MsgBox(Msg, 292)
                If Ktrl = 6 Then
                    bUpdate(Fl, 0)
                End If
            End If
            TeleBibClick = True
        End If

    End Function

    Sub ArrangeDeckChairs(Fl As Integer)

        Dim T As Integer
        Dim CrText As String
        Dim BoxMask As String = ""
        Dim BoxType As Integer

        With xLog.X
            .Clear()
            .Columns.Add("vsfKode", 5)
            .Columns.Add("Veldomschrijving", 220)
            .Columns.Add("Veldgegevens", 250)
        End With
        aa = ""
        T = 0
        Do While Trim(TeleBibCode(T)) <> ""
            CrText = vBibTekst(Fl, "#" & Mid(TeleBibCode(T), 5, 5) & "#")
            Select Case Mid(TeleBibCode(T), 2, 2)
                Case "  ", "K ", "L ", "LC", "R ", "R3", "R4", "R6", "R7"
                    'niks
                Case Else
                    Select Case Mid(TeleBibCode(T), 1, 1)
                        Case " "
                            BoxMask = "00"
                            BoxType = 0
                        Case "0" To "9"
                            BoxMask = "000"
                            BoxType = 1
                    End Select
                    If Left(TeleBibCode(T), 1) = "@" Or CrText = "" Then
                    Else
                        CrText = fmarBoxText(Format(Val(Mid(TeleBibCode(T), 1, 3)), BoxMask), "2", CrText) 'hier eventueel taaloptie
                    End If
            End Select
            aa = TeleBibCode(T) & vbTab & TeleBibTekst(T) & vbTab & CrText
            Dim itemHier As New ListViewItem(TeleBibCode(T))
            itemHier.SubItems.Add(TeleBibTekst(T))
            itemHier.SubItems.Add(CrText)
            xLog.X.Items.Add(itemHier)
            T = T + 1
        Loop

    End Sub
    Function vsfInputBox(ByRef InfoTekst As String, ByRef Titel As String, ByRef TekstZelf As String, ByRef Paswoord As String) As String
        Dim T As Short
        Dim TT As Short

        On Error GoTo 0

        Dim ToolDef(3) As String
        'UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
        ntInputbox.Dispose()
        ntInputbox.Hide()
        ntInputbox.Text = Titel
        SQLBevel = ""
        If Mid(InfoTekst, 1, 1) = "@" Then
            ntInputbox.Hernieuw.Visible = True
            ntInputbox.cmdVooruit.Visible = True
            ntInputbox.cmdAchteruit.Visible = True
            ntInputbox.lblInfo.Visible = True
            Select Case Mid(InfoTekst, 2, 2)
                Case "00"
                    SQLBevel = "SELECT * FROM ISOLandKodes WHERE ISOLandNummer LIKE '" & Trim(TekstZelf) & "%';"
                    'ntInputbox.BindingNavigator.BindingSource = ntInputbox.ISOLandkodesBindingSource
                    'TODO: NTInputbox.DefaultData.RecordSource = SQLBevel & RTrim(TekstZelf) & "%';"
                    ReDim ToolDef(3)
                    ToolDef(0) = "00=v149 " 'Landnummer  ISO kode
                    ToolDef(1) = "01=vs03 " 'Munteenheid ISO kode
                    ToolDef(2) = "02=v150 " 'Landkode    ISO kode
                Case "01"
                    SQLBevel = "SELECT * FROM PostKodesWoonplaatsen WHERE PostKode LIKE '" & Trim(TekstZelf) & "%';"
                    'TODO: NTInputbox.DefaultData.RecordSource = SQLBevel & RTrim(TekstZelf) & "%';"
                    'ntInputbox.BindingNavigator.BindingSource = ntInputbox.PostKodesWoonPlaatsenBindingSource

                    ReDim ToolDef(3)
                    ToolDef(0) = "01=A107 " 'PostKode volgens Postkantoor
                    ToolDef(1) = "02=A108 " 'Plaatsnaam

                Case "02"
                    SQLBevel = "SELECT * FROM PostKodesWoonplaatsen WHERE PlaatsNaam LIKE '" & Trim(TekstZelf) & "%';"
                    'TODO: NTInputbox.DefaultData.RecordSource = SQLBevel & RTrim(TekstZelf) & "%';"
                    'ntInputbox.BindingNavigator.BindingSource = ntInputbox.PostKodesWoonPlaatsenBindingSource
                    ReDim ToolDef(3)
                    ToolDef(0) = "02=A108 " 'Plaatsnaam
                    ToolDef(1) = "01=A107 " 'PostKode volgens Postkantoor
            End Select
        Else
            ntInputbox.Hernieuw.Visible = False
            NTInputbox.cmdVooruit.Visible = False
            NTInputbox.cmdAchteruit.Visible = False
            NTInputbox.lblInfo.Visible = False
        End If
        NTInputbox.Tag = GridText
        If GridText = "Edit No" Then
            ntInputbox.Ok.Visible = False
            ntInputbox.TekstInfo.Enabled = False
            ntInputbox.AcceptButton = ntInputbox.Sluiten
        Else
            ntInputbox.Ok.Visible = True
            ntInputbox.TekstInfo.Enabled = True
            ntInputbox.AcceptButton = ntInputbox.Ok
        End If
        GridText = InfoTekst
        If Mid(InfoTekst, 1, 1) = "@" Then
            'ntInputbox.ToolStrip.Text = GridText ' & NTInputbox.DefaultData.RecordSource
        Else
            'ntInputbox.ToolStrip.Text = GridText
        End If
        NTInputbox.TekstInfo.Text = TekstZelf
        'nTInputBox.TekstInfo.PasswordChar = Paswoord
        NTInputbox.ShowDialog()

        Dim AantalRijen As Short
        If NTInputbox.TekstInfo.Text = Chr(255) Then
            vsfInputBox = TekstZelf
        Else
            If SQLBevel = "" Then
                vsfInputBox = ntInputbox.TekstInfo.Text
            ElseIf Mid(InfoTekst, 1, 1) = "@" Then
                Stop
                'And NTInputbox.TekstInfo.Text = NTInputbox.DefaultData.Recordset.Fields(Val(Mid(ToolDef(0), 1, 2))).Value Then
                'Select Case Mid(InfoTekst, 2, 2)
                'Case "00"
                'AantalRijen = 2
                'Case "01", "02"
                'AantalRijen = 1
                'Case Else
                'MsgBox("Stop")
                'End Select
                'For T = AantalRijen To 0 Step -1
                'xLog.X.Col = 0
                'For TT = 1 To xLog.X.Rows
                'xLog.X.Row = TT
                'If Mid(xLog.X.Text, 5, 5) = Mid(ToolDef(T), 4) Then
                'xLog.X.Col = 2
                'xLog.X.Text = NTInputbox.DefaultData.Recordset.Fields(Val(Mid(ToolDef(T), 1, 2))).Value
                'Exit For
                'End If
                'Next
                'Next
                'vsfInputBox = ntInputbox.TekstInfo.Text
                'Else
                'vsfInputBox = NTInputbox.TekstInfo.Text
                'End If
            End If



        End If
        'TODO: NTInputbox.DefaultData.RecordSource = ""
        Exit Function

ErrInput:
        Beep()
        vsfInputBox = TekstZelf
        Exit Function

    End Function
    Function Dec(ByRef fGetal As Double, ByRef fMasker As String) As String

        Dim MaskerLengte As Short
        Dim TempoString As String

        MaskerLengte = Len(fMasker)
        TempoString = Format(fGetal, fMasker)
        If (MaskerLengte - Len(TempoString)) > 0 Then
            TempoString = Space(MaskerLengte - Len(TempoString)) & TempoString
        End If
        If InStr(TempoString, ",") Then
            Mid(TempoString, InStr(TempoString, ","), 1) = "."
        End If
        Dec = TempoString

    End Function
    Function DatumKtrl(ByRef fDatum As String, ByRef fVlag As Short) As Boolean

        Dim Dag As String = "  "
        Dim Maand As String = "  "
        Dim Jaar As String = "    "
        Dim gDatum As String
        Dim gPos As Short

        DatumKtrl = False
        gDatum = fDatum
        Do While InStr(gDatum, "/")
            gPos = InStr(gDatum, "/")
            gDatum = Left(gDatum, gPos - 1) & Mid(gDatum, gPos + 1)
        Loop

        Select Case fVlag
            Case TekstPeriode, TekstBoekjaar
                Dag = Mid(gDatum, 1, 2)
                Maand = Mid(gDatum, 3, 2)
                Jaar = Mid(gDatum, 5, 4)
            Case SleutelPeriode, SleutelBoekjaar
                Jaar = Mid(gDatum, 1, 4)
                Maand = Mid(gDatum, 5, 2)
                Dag = Mid(gDatum, 7, 2)
            Case Else
                MsgBox("Datum onjuist !")
        End Select

        Select Case fVlag
            Case TekstPeriode, SleutelPeriode
                If Jaar & Maand & Dag < Left(PeriodeVanTot, 8) Or Jaar & Maand & Dag > Right(PeriodeVanTot, 8) Then
                Else
                    DatumKtrl = True
                End If
            Case TekstBoekjaar, SleutelBoekjaar
                If Jaar & Maand & Dag < Left(BoekjaarVanTot, 8) Or Jaar & Maand & Dag > Right(BoekjaarVanTot, 8) Then
                Else
                    DatumKtrl = True
                End If
        End Select

    End Function
    Function VValdag(ByRef rDat1 As String, ByRef rvv As String) As String
        Dim adm1 As Short
        Dim irjr43, irdg43, irmd43, avd43 As Short
        On Error GoTo handlerVVDag

        irdg43 = Val(Left(rDat1, 2))
        irmd43 = Val(Mid(rDat1, 4, 2))
        irjr43 = Val(Right(rDat1, 4)) - 1990
        avd43 = Val(rvv)

        If avd43 Then
        Else
            VValdag = rDat1
            Exit Function
        End If

        adm1 = DagenInMaand(irmd43)
        While irdg43 + avd43 > adm1
            avd43 = avd43 - (adm1 - irdg43)
            irdg43 = 0
            If irmd43 = 12 Then
                irmd43 = 1
                irjr43 = irjr43 + 1
            Else
                irmd43 = irmd43 + 1
            End If
            adm1 = DagenInMaand(irmd43)
        End While

        irdg43 = irdg43 + avd43
        If InStr(UCase(rvv), "E") Then
            irdg43 = adm1
        End If
        VValdag = Format(irdg43, "00") & "/" & Format(irmd43, "00") & "/" & Format(irjr43 + 1990, "0000")
        Exit Function

handlerVVDag:
        VValdag = ""
        Exit Function

    End Function

    Function SleutelDok(ByRef fRecordNr As Short) As String
        Dim VoorLetter As String = "  "

        Fl99Record = String99(LeesLock, fRecordNr)
        Select Case fRecordNr
            Case 1
                VoorLetter = "A0"
            Case 3
                VoorLetter = "A1"
            Case 11
                VoorLetter = "V0"
            Case 13
                VoorLetter = "V1"
            Case 73
                VoorLetter = "B0"
            Case 59
                VoorLetter = "F0"
            Case 121
                VoorLetter = "Q0"
            Case 188
                VoorLetter = "PF"
            Case Else
                MsgBox("Ongeldige record : " & Str(fRecordNr))
        End Select
        SleutelDok = VoorLetter & Mid(PeriodeVanTot, 1, 4) & Format(Val(Fl99Record) + 1, "00000")
    End Function
    Function fDatumText(ByRef fDatumSleutel As String) As String
        Dim Dag As String = "  "
        Dim Maand As String = "  "
        Dim Jaar As String = "    "

        Dag = Mid(fDatumSleutel, 7, 2)
        Maand = Mid(fDatumSleutel, 5, 2)
        Jaar = Mid(fDatumSleutel, 1, 4)
        fDatumText = Dag & "/" & Maand & "/" & Jaar
    End Function
    Function CopyFile(ByRef SourcePath As String, ByRef TargetPath As String, ByRef FileToCopy As String) As Short
        Dim FlCopy1 As Short
        Dim FlCopy2 As Short
        Dim BigChunks As Short
        Dim LeftOver As Short
        Dim inD As Short
        Dim Aantal As Short
        Dim BufferVar As String
        Dim BestandReeks(512) As String

        On Error GoTo CopyError
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If InStr(FileToCopy, "?") Or InStr(FileToCopy, "*") Then
            Aantal = 1
            'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            BestandReeks(1) = Dir(SourcePath & "\" & FileToCopy)
            If BestandReeks(1) = "" Then
                MsgBox("Stop tijdens het kopieren.  Bestand niet te vinden: """ & FileToCopy & """", 64, "SETUP")
                GoTo CopyError
            Else
                Do
                    Aantal = Aantal + 1
                    'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                    BestandReeks(Aantal) = Dir()
                    If BestandReeks(Aantal) = "" Then
                        Aantal = Aantal - 1
                        Exit Do
                    End If
                Loop
            End If
        Else
            BestandReeks(1) = FileToCopy
            Aantal = 1
            If Not FileExists(SourcePath & "\" & FileToCopy) Then
                MsgBox("Bestand niet te vinden: """ & FileToCopy & """", 64, "SETUP")
                GoTo CopyError
            End If
        End If

        For TelTot = 1 To Aantal

            'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            If Dir(TargetPath & "\" & BestandReeks(TelTot)) <> "" Then
                Kill(TargetPath & "\" & BestandReeks(TelTot))
            End If

            FlCopy1 = FreeFile()
            FileOpen(FlCopy1, SourcePath & "\" & BestandReeks(TelTot), OpenMode.Binary)

            FlCopy2 = FreeFile()
            FileOpen(FlCopy2, TargetPath & "\" & BestandReeks(TelTot), OpenMode.Binary)

            BufferVar = New String(" ", 3000)

            BigChunks = LOF(FlCopy1) \ Len(BufferVar)
            LeftOver = LOF(FlCopy1) Mod Len(BufferVar)

            For inD = 1 To BigChunks
                'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FileGet(FlCopy1, BufferVar)
                'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FilePut(FlCopy2, BufferVar)
            Next

            If LeftOver Then
                BufferVar = ""
                BufferVar = New String(" ", LeftOver)
                'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FileGet(FlCopy1, BufferVar)
                'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                FilePut(FlCopy2, BufferVar)
            End If

            If LOF(FlCopy1) = LOF(FlCopy2) Then
                FileClose(FlCopy1)
                FileClose(FlCopy2)
            Else
                GoTo CopyError
            End If

        Next
        CopyFile = -1
        'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
        'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'

        Exit Function

CopyError:
        MsgBox("Stop tijdens het kopieren van " & FileToCopy & """", 64, "SETUP")
        MsgBox(ErrorToString())
        FileClose(FlCopy1)
        FileClose(FlCopy2)
        CopyFile = False
        'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
        'UPGRADE_ISSUE: Screen property Screen.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'



    End Function
    '----------------------------------------------------------
    ' Check for the existence of a file by attempting an OPEN.
    '----------------------------------------------------------
    Function FileExists(ByRef path As String) As Short
        Dim X As Short

        X = FreeFile()

        On Error Resume Next
        FileOpen(X, path, OpenMode.Input)
        If Err.Number = 0 Then
            FileExists = True
        Else
            FileExists = False
        End If
        FileClose(X)

    End Function
    Sub CMDVSOFTSPACE(flfree As Short)
        On Error GoTo errorCMDVSOFTSPACE
        Input(flfree, pdfVsoftVanaf)
        Input(flfree, pdfVsoftTot)
        Exit Sub

errorCMDVSOFTSPACE:
        MsgBox("CMDVSOFTSPACE foutieve definitie")
    End Sub
    Sub CMDPICTURE(flfree As Short)
        Dim YPOS As Double
        Dim xPos As Double
        Dim YPOS2 As Double
        Dim xPos2 As Double
        Dim pdfBoxPen As Double
        Dim filename As String = ""

        On Error GoTo errorCMDPICTURE
        Input(flfree, xPos)
        Input(flfree, YPOS)
        Input(flfree, xPos2)
        Input(flfree, YPOS2)
        Input(flfree, pdfBoxPen)
        Input(flfree, filename)
        Mim.Report.PictureBestFit = True
        '2.5, 0.5, 19, 2.5
        If Mid(filename, 1, 4) = "[BL]" Then
            filename = BedrijfsLokatie & Mid(filename, 5)
        ElseIf Mid(filename, 1, 4) = "[PL]" Then
            filename = ProgrammaLokatie & Mid(filename, 5)
        End If
        Ktrl = Mim.Report.Picture(xPos, YPOS, xPos2, YPOS2, filename)
        Exit Sub

errorCMDPICTURE:
        MsgBox("CMDPICTURE foutieve definitie")
    End Sub
    Sub CMDADRESSPACE(Flfree As Short)
        On Error GoTo errorCMDADRESSPACE
        Input(Flfree, pdfadresXpos)
        Input(Flfree, pdfadresYpos)
        Input(Flfree, pdfadresXpos2)
        Input(Flfree, pdfadresYpos2) ', adresBox
        'Ktrl = Mim.Report.WriteBox(pdfadresXpos, pdfadresYpos, pdfadresXpos2, pdfadresYpos2, "")
        Exit Sub

errorCMDADRESSPACE:
        MsgBox("CMDADRESSPACE foutieve definitie")
    End Sub
    Sub CMDWRITE(FlFree As Short)
        Dim YPOS As Double
        Dim xPos As Double
        Dim YPOS2 As Double
        Dim xPos2 As Double
        Dim pdfFontSize As Double
        Dim pdfFontName As String = ""
        Dim pdfFontBold As Double
        Dim pdfFontItalic As Double
        Dim pdfFontUnderLine As Double
        Dim pdfColor As Double
        Dim pdfAlign As Double

        Dim textstring As String
        Dim texttmp As String

        On Error GoTo errorCMDWRITE
        Input(FlFree, xPos)
        Input(FlFree, YPOS)
        Input(FlFree, xPos2)
        Input(FlFree, YPOS2)
        Input(FlFree, pdfFontSize)
        Input(FlFree, pdfFontName)
        Input(FlFree, pdfColor)
        Input(FlFree, pdfAlign)
        Input(FlFree, pdfFontBold)
        Input(FlFree, pdfFontItalic)
        Input(FlFree, pdfFontUnderLine)
        textstring = LineInput(FlFree)
        Do
            texttmp = LineInput(FlFree)
            If texttmp = "CMD-ENDWRITE" Then
                Exit Do
            Else
                textstring = textstring & vbCrLf & texttmp
            End If
        Loop
        'Mim.Report.Font = VB6.FontChangeName(Mim.Report.Font, pdfFontName)
        'Mim.Report.Font = VB6.FontChangeSize(Mim.Report.Font, pdfFontSize)
        Mim.Report.SelectFont(pdfFontName, pdfFontSize)
        Mim.Report.TextColor = System.Drawing.ColorTranslator.FromOle(pdfColor)
        Mim.Report.TextBold = pdfFontBold
        Mim.Report.TextItalic = pdfFontItalic
        Mim.Report.TextUnderline = pdfFontUnderLine
        Mim.Report.TextAlignment = pdfAlign
        Ktrl = Mim.Report.Write(xPos, YPOS, xPos2, YPOS2, textstring)
        Exit Sub

errorCMDWRITE:
        MsgBox("CMDWRITE foutieve definitie")
    End Sub
    Sub CMDWRITEBOX(FlFree As Short)
        Dim YPOS As Double
        Dim xPos As Double
        Dim YPOS2 As Double
        Dim xPos2 As Double
        Dim pdfFontSize As Double
        Dim pdfFontName As String = ""
        Dim pdfFontBold As Double
        Dim pdfFontItalic As Double
        Dim pdfFontUnderLine As Double
        Dim pdfColor As Double
        Dim pdfAlign As Double

        Dim textstring As String
        Dim texttmp As String

        On Error GoTo errorCMDWRITEBOX
        Input(FlFree, xPos)
        Input(FlFree, YPOS)
        Input(FlFree, xPos2)
        Input(FlFree, YPOS2)
        Input(FlFree, pdfFontSize)
        Input(FlFree, pdfFontName)
        Input(FlFree, pdfColor)
        Input(FlFree, pdfAlign)
        Input(FlFree, pdfFontBold)
        Input(FlFree, pdfFontItalic)
        Input(FlFree, pdfFontUnderLine)
        textstring = LineInput(FlFree)
        Do
            texttmp = LineInput(FlFree)
            If texttmp = "CMD-ENDWRITE" Then
                Exit Do
            Else
                textstring = textstring & vbCrLf & texttmp
            End If
        Loop
        Mim.Report.SelectFont(pdfFontName, pdfFontSize)
        'Mim.Report.Font = VB6.FontChangeName(Mim.Report.Font, pdfFontName)
        'Mim.Report.Font = VB6.FontChangeSize(Mim.Report.Font, pdfFontSize)
        Mim.Report.TextColor = System.Drawing.ColorTranslator.FromOle(pdfColor)
        Mim.Report.TextBold = pdfFontBold
        Mim.Report.TextItalic = pdfFontItalic
        Mim.Report.TextUnderline = pdfFontUnderLine

        Mim.Report.TextAlignment = pdfAlign
        Ktrl = Mim.Report.WriteBox(xPos, YPOS, xPos2, YPOS2, textstring)
        Exit Sub

errorCMDWRITEBOX:
        MsgBox("CMDWRITEBOX foutieve definitie")
    End Sub
    Sub CMDPRINT(FLFree As Short, pdfOVSStrook As Double)
        Dim YPOS As Double
        Dim xPos As Double
        Dim pdfFontSize As Double
        Dim pdfFontName As String = ""
        Dim pdfFontBold As Double
        Dim pdfFontItalic As Double
        Dim pdfFontUnderLine As Double
        Dim pdfColor As Double
        Dim textstring As String

        On Error GoTo errorCMDPRINT
        Input(FLFree, xPos)
        Input(FLFree, YPOS)
        Input(FLFree, pdfFontSize)
        Input(FLFree, pdfFontName)
        Input(FLFree, pdfColor)
        Input(FLFree, pdfFontBold)
        Input(FLFree, pdfFontItalic)
        Input(FLFree, pdfFontUnderLine)
        textstring = LineInput(FLFree)
        Mim.Report.SelectFont(pdfFontName, pdfFontSize)
        'Mim.Report.Font = VB6.FontChangeName(Mim.Report.Font, pdfFontName)
        'Mim.Report.Font = VB6.FontChangeSize(Mim.Report.Font, pdfFontSize)
        Mim.Report.TextColor = System.Drawing.ColorTranslator.FromOle(pdfColor)
        Mim.Report.TextBold = pdfFontBold
        Mim.Report.TextItalic = pdfFontItalic
        Mim.Report.TextUnderline = pdfFontUnderLine
        If YPOS > pdfVsoftTot Then
            Ktrl = Mim.Report.Print(xPos, YPOS - pdfOVSStrook, textstring)
        Else
            Ktrl = Mim.Report.Print(xPos, YPOS, textstring)
        End If
        Exit Sub

errorCMDPRINT:
        MsgBox("CMDPRINT foutieve definitie")
    End Sub
    Function DatumFout(ByRef fDatum As String) As Short
        Dim Dag As Short
        Dim Maand As Short
        Dim Jaar As Short
        If Len(fDatum) <> 10 Then
            DatumFout = True
        Else
            Dag = Val(Mid(fDatum, 1, 2))
            Maand = Val(Mid(fDatum, 4, 2))
            Jaar = Val(Mid(fDatum, 7, 4))
            If Dag < 32 And Dag > 0 And Maand < 13 And Maand > 0 And Jaar > 1985 And Jaar < 2025 Then
                DatumFout = False
            Else
                DatumFout = True
                Beep()
            End If
        End If
    End Function
End Module
