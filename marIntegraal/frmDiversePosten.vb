Option Strict Off
Option Explicit On
Public Class frmDiversePosten
    Dim totaalDCBedrag As Double

    Private Sub frmDiversePosten_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Top = 0
        Left = 0
        SoortBoeking.Items.Add("0: Diverse post")
        SoortBoeking.Items.Add("1: Afschrijvingspost Eindejaar")
        SoortBoeking.Items.Add("2: Beginbalans")
        'SoortBoeking.AddItem "9: Gebruikerssjabloon"
        DatumVerwerking.Value = frmBJPERDAT.DatumVerwerking.Value
        Schoon.PerformClick()
        If XLogKey = "SchrijfAF!" Then
            SoortBoeking.SelectedIndex = 1
        End If
    End Sub

    Private Function BoekFout() As Boolean
        Dim T As Short
        
        BoekFout = False
        dKtrlCumul = 0 : dKtrlBEF = 0 : dKtrlEUR = 0

        Boeking.Close()
        Boeking.Hide()

        For T = 0 To JournaalPost.Items.Count - 1
            Msg = JournaalPost.Items.Item(T)
            rsJournaal.AddNew()
            rsJournaal.Fields("v041").Value = "0"
            rsJournaal.Fields("v066").Value = Format(DatumVerwerking.Value, "yyyyMMdd") 'Boekdatum
            rsJournaal.Fields("v033").Value = "D0" & Format(DatumVerwerking.Value, "yyyyMMdd") 'dokument
            rsJournaal.Fields("v035").Value = Format(DatumVerwerking.Value, "yyyyMMdd") 'dokumentdatum
            rsJournaal.Fields("v067").Value = Mid(Omschrijving.Text, 1, 35) 'Omschrijving
            rsJournaal.Fields("v019").Value = Mid(Msg, 1, 7) 'Rekening
            rsJournaal.Fields("v068").Value = Mid(Msg, 50, 12) 'Bedrag
            rsJournaal.Fields("dece068").Value = Val(Mid(Msg, 50, 12)) 'Bedrag
            rsJournaal.Fields("v069").Value = Mid(Msg, 63, 7) 'TegenRekening
            If Not adoJournaalOK Then
                BoekFout = True
                dKtrlCumul = 999
            ElseIf Mid(msg, 63, 7) <> "       " Then
                rsJournaal.AddNew()
                rsJournaal.Fields("v041").Value = "0"
                rsJournaal.Fields("v066").Value = Format(DatumVerwerking.Value, "yyyyMMdd") 'Boekdatum
                rsJournaal.Fields("v033").Value = "D0" & Format(DatumVerwerking.Value, "yyyyMMdd") 'dokument
                rsJournaal.Fields("v035").Value = Format(DatumVerwerking.Value, "yyyyMMdd") 'dokumentdatum
                rsJournaal.Fields("v067").Value = Mid(Omschrijving.Text, 1, 35) 'Omschrijving

                rsJournaal.Fields("v019").Value = Mid(Msg, 63, 7) 'Rekening
                rsJournaal.Fields("v068").Value = Str(-Val(Mid(Msg, 50, 12))) 'Bedrag
                rsJournaal.Fields("dece068").Value = -Val(Mid(Msg, 50, 12)) 'Bedrag
                rsJournaal.Fields("v069").Value = Mid(Msg, 1, 7) 'TegenRekening
                If Not adoJournaalOK Then
                    BoekFout = True
                    dKtrlCumul = 999
                End If
            End If
        Next

        If dKtrlCumul Then
            MsgBox("Fout bij vierkantskontrole journaal." & vbCrLf & vbCrLf & "Deze verrichting wordt genegeerd.")
            Boeking.cmdBoeken.Enabled = False
            Boeking.ShowDialog()
            BoekFout = True
        ElseIf JournaalLocked = True Then
            Boeking.cmdBoeken.Enabled = False
            Boeking.ShowDialog()
            BoekFout = True
        Else
            Boeking.ShowDialog()
            If dKtrlCumul Then BoekFout = True
        End If

    End Function

    Private Sub SoortBoeking_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SoortBoeking.SelectedIndexChanged
        Select Case Mid(SoortBoeking.Text, 1, 1)
            Case "0"
            Case Else
                Msg = SoortBoeking.Text & " aktiveren !" & vbCrLf & vbCrLf
                Msg = Msg & "Bent U zeker ?"
                Ktrl = MsgBox(Msg, 292)
                If Ktrl = 6 Then
                    Select Case Mid(SoortBoeking.Text, 1, 1)
                        Case "1"
                            'If AfschrijfBoeking() Then
                            'Else
                                Schoon.PerformClick()
                            'End If
                        Case "2"
                            'If BoekBeginBalans() Then
                            'Else
                                Schoon.PerformClick()
                            'End If
                        Case "9"
                            'BoekUserDef()
                        Case Else
                            MsgBox("stop")
                    End Select
                Else
                    Schoon.PerformClick()
                    Exit Sub
                End If
        End Select
    End Sub

    Private Sub Schoon_Click(sender As Object, e As EventArgs) Handles Schoon.Click
        OpKuisVolgendeLijn()
        Afsluiten.Enabled = False
        Omschrijving.Text = ""
        Saldo.Text = "0"
        JournaalPost.Items.Clear()
        SoortBoeking.Enabled = True
        SoortBoeking.SelectedIndex = 0
        Sluiten.Enabled = True
        dKeuze.Enabled = True
        cKeuze.Enabled = True
        Bedrag.Visible = True
        RekeningNummer.Visible = True
        TRvlag.Enabled = True
        SoortBoeking.Focus()
    End Sub

    Private Sub OpKuisVolgendeLijn()
        TRvlag.Checked = False
        TRaanUit()
        RekeningNummer.Text = ""
        NaamRekening.Text = ""
        Bedrag.Text = ""
        Tegenrekening.Text = ""
        NaamTegenRekening.Text = ""
        dKeuze.Checked = True
        VolgendeLijn.Enabled = False
    End Sub

    Private Sub TRaanUit()
        If TRvlag.Checked Then
            Tegenrekening.Visible = True
            NaamTegenRekening.Visible = True
        Else
            Tegenrekening.Visible = False
            NaamTegenRekening.Visible = False
        End If
    End Sub

    Private Sub Sluiten_Click(sender As Object, e As EventArgs) Handles Sluiten.Click
        If JournaalPost.Items.Count Then
            Msg = Format(JournaalPost.Items.Count) & " Journaallijnen negeren.  Bent U zeker ?"
            Ktrl = MsgBox(Msg, 292, "Inbreng Journaalpost")
            If Ktrl <> 6 Then
                Exit Sub
            End If
        End If
        Mim.DiversePostenToolStripMenuItem.Enabled = True
        Close()
    End Sub

    Private Sub SoortBoeking_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SoortBoeking.KeyPress
        If e.KeyChar = vbCr Then Omschrijving.Focus()
    End Sub

    Private Sub Omschrijving_Enter(sender As Object, e As EventArgs) Handles Omschrijving.Enter
        SoortBoeking.Enabled = False
    End Sub

    Sub DCKeuzeCheck(toetsString As String)
        Select Case toetsString
            Case "D", "+"
                dKeuze.Checked = True
                RekeningNummer.Focus()
            Case "C", "-"
                cKeuze.Checked = True
                RekeningNummer.Focus()
            Case "T", "/"
                TRvlag.Checked = Not TRvlag.Checked
                TRaanUit()
                RekeningNummer.Focus()
        End Select
    End Sub

    Private Sub dKeuze_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dKeuze.KeyPress
        Dim keyString As String = UCase(e.KeyChar)
        DCKeuzeCheck(e.KeyChar)
    End Sub

    Private Sub cKeuze_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cKeuze.KeyPress
        Dim keyString As String = UCase(e.KeyChar)
        DCKeuzeCheck(e.KeyChar)
    End Sub

    Private Sub Omschrijving_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Omschrijving.KeyPress
        If e.KeyChar = vbCr Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub TRvlag_CheckStateChanged(sender As Object, e As EventArgs) Handles TRvlag.CheckStateChanged
        TRaanUit()
    End Sub

    Private Sub RekeningNummer_KeyDown(sender As Object, e As KeyEventArgs) Handles RekeningNummer.KeyDown
        If e.KeyCode = 17 Then
            If okRekeningen(RekeningNummer, NaamRekening) Then
                System.Windows.Forms.SendKeys.Send("{TAB}")
            Else
                RekeningNummer.Focus()
            End If
        End If
    End Sub

    Private Sub RekeningNummer_LostFocus(sender As Object, e As EventArgs) Handles RekeningNummer.LostFocus
        If Trim(RekeningNummer.Text) = "" Then
        Else
            bGet(FlRekening, 0, RekeningNummer.Text)
            If Ktrl Then
                RekeningNummer.Focus()
                Beep()
            Else
                RecordToVeld(FlRekening)
                RekeningNummer.Text = vBibTekst(FlRekening, "#v019 #")
                NaamRekening.Text = vBibTekst(FlRekening, "#v020 #")
            End If
        End If
    End Sub

    Private Sub Tegenrekening_KeyDown(sender As Object, e As KeyEventArgs) Handles Tegenrekening.KeyDown
        If e.KeyCode = 17 Then
            If okRekeningen(Tegenrekening, NaamTegenRekening) Then
                System.Windows.Forms.SendKeys.Send("{TAB}")
            Else
                Tegenrekening.Focus()
            End If
        End If
    End Sub

    Private Sub Tegenrekening_LostFocus(sender As Object, e As EventArgs) Handles Tegenrekening.LostFocus
        If Trim(Tegenrekening.Text) = "" Then
        Else
            bGet(FlRekening, 0, Tegenrekening.Text)
            If Ktrl Then
                Tegenrekening.Focus()
                Beep()
            Else
                RecordToVeld(FlRekening)
                Tegenrekening.Text = vBibTekst(FlRekening, "#v019 #")
                NaamTegenRekening.Text = vBibTekst(FlRekening, "#v020 #")
            End If
        End If
    End Sub

    Function okRekeningen(rekTextBox As TextBox, rekLabel As Label) As Boolean
        okRekeningen = False
        SharedFl = FlRekening
        sharedIndex = 0
        GridText = rekTextBox.Text
        SqlSearch.ShowDialog()
        If Ktrl Then
            rekLabel.Text = ""
        Else
            rekTextBox.Text = vBibTekst(FlRekening, "#v019 #")
            rekLabel.Text = vBibTekst(FlRekening, "#v020 #")
            okRekeningen = True
        End If
    End Function

    Private Sub Bedrag_Enter(sender As Object, e As EventArgs) Handles Bedrag.Enter
        If Val(Saldo.Text) = 0 Then
            Afsluiten.Enabled = True
        Else
            Afsluiten.Enabled = False
        End If
    End Sub

    Private Sub Bedrag_TextChanged(sender As Object, e As EventArgs) Handles Bedrag.TextChanged
        If Bedrag.Text <> "" Then
            VolgendeLijn.Enabled = True
            AcceptButton = VolgendeLijn
        Else
            VolgendeLijn.Enabled = False
        End If
    End Sub

    Private Sub VolgendeLijn_Click(sender As Object, e As EventArgs) Handles VolgendeLijn.Click
        Dim LijnText As String
        If RTrim(RekeningNummer.Text) = "" Then
            Beep()
            RekeningNummer.Focus()
            Exit Sub
        ElseIf Val(Bedrag.Text) = 0 Then
            Beep()
            Bedrag.Focus()
            Exit Sub
        ElseIf TRvlag.CheckState Then
            If RTrim(Tegenrekening.Text) = "" Then
                Beep()
                Tegenrekening.Focus()
                Exit Sub
            End If
        End If
        totaalDCBedrag = Val(Bedrag.Text)
        If dKeuze.Checked Then
        ElseIf TRvlag.Checked Then
        Else
            'kan alleen nog creditering zijn (zonder tegenrekening)
            totaalDCBedrag = -totaalDCBedrag
        End If
        LijnText = vSet((RekeningNummer.Text), 7) & " " & vSet((NaamRekening.Text), 40) & " " & Dec(totaalDCBedrag, MaskerEURBH) & " "
        If TRvlag.CheckState Then
            LijnText = LijnText & vSet((Tegenrekening.Text), 7)
        Else
            LijnText = LijnText & Space(7)
        End If
        JournaalPost.Items.Add(LijnText)
        checkDCStatus()
        OpKuisVolgendeLijn()
        dKeuze.Focus()
    End Sub

    Sub checkDCStatus()
        totaalDCBedrag = 0
        For t = 0 To JournaalPost.Items.Count - 1
            Msg = JournaalPost.Items.Item(t)
            If Trim(Mid(Msg, 63)) <> "" Then
            Else
                totaalDCBedrag = totaalDCBedrag + Val(Mid(Msg, 50, 12))
            End If
        Next
        Saldo.Text = Dec(totaalDCBedrag, MaskerEURBH)
        If Val(Saldo.Text) = 0 Then
            Afsluiten.Enabled = True
            AcceptButton = Afsluiten
        Else
            Afsluiten.Enabled = False
        End If
    End Sub

    'Private Function BoekBeginBalans() As Object
        'Dim pHier As String
        'Dim Verwittigen As Boolean

        'Verwittigen = False
        'If String99(Lees, 64) = "1" Then
        '    MsgBox("Beginbalans reeds gegenereerd voor dit boekjaar.  Bijkomende posten kunnen uitsluitend via 'Diverse post'-optie ingebracht worden !")
        '    'UPGRADE_WARNING: Couldn't resolve default property of object BoekBeginBalans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    BoekBeginBalans = False
        '    Exit Function
        'ElseIf String99(Lees, 64) <> "0" Then
        '    MsgBox("Setup beginbalans bevat niet de juiste vlag geboekt of niet geboekt.  Kontroleer")
        '    'UPGRADE_WARNING: Couldn't resolve default property of object BoekBeginBalans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    BoekBeginBalans = False
        '    Exit Function
        'End If

        'Dim TotaalBalans As Decimal
        'Dim TotaalResultaat As Decimal

        ''kontrole vanaf eerst 1 tot laatste 5
        'TotaalBalans = 0

        ''If Not adoGet(FlRekening, 0, "=", XLogKey) Then
        ''Else
        ''    RekeningNummer = RV(rsMAR(FlRekening), "v019")
        ''    NaamRekening = RV(rsMAR(FlRekening), "v020")

        'If Not adoGet(FlRekening, 0, ">=", vSet("1", 7)) Then
        '    MsgBox("Geen rekeningen ???")
        '    'UPGRADE_WARNING: Couldn't resolve default property of object BoekBeginBalans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    BoekBeginBalans = False
        '    Exit Function
        '    'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'ElseIf VB.Left(RV(rsMAR(FlRekening), "v019"), 1) < "6" Then
        '    If bhEuro Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        TotaalBalans = TotaalBalans + Val(RV(rsMAR(FlRekening), "e" & VB6.Format(AktiefBoekjaar + 23, "000")))
        '    Else
        '        'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        TotaalBalans = TotaalBalans + Val(RV(rsMAR(FlRekening), "v" & VB6.Format(AktiefBoekjaar + 23, "000")))
        '    End If
        '    Do While Not rsMAR(FlRekening).EOF
        '        rsMAR(FlRekening).MoveNext()
        '        'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        If VB.Left(RV(rsMAR(FlRekening), "v019"), 1) >= "6" Then
        '            Exit Do
        '        Else
        '            If bhEuro Then
        '                'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                TotaalBalans = TotaalBalans + Val(RV(rsMAR(FlRekening), "e" & VB6.Format(AktiefBoekjaar + 23, "000")))
        '            Else
        '                'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                TotaalBalans = TotaalBalans + Val(RV(rsMAR(FlRekening), "v" & VB6.Format(AktiefBoekjaar + 23, "000")))
        '            End If
        '        End If
        '    Loop
        'End If

        ''+ eerste 6 tot laatste 7
        'TotaalResultaat = 0
        'bGetOrGreater(FlRekening, 0, vSet("6", 7))
        'If Ktrl Then
        '    MsgBox("Geen rekeningen ???")
        '    'UPGRADE_WARNING: Couldn't resolve default property of object BoekBeginBalans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    BoekBeginBalans = False
        '    Exit Function
        'ElseIf VB.Left(KeyBuf(FlRekening), 1) < "8" Then
        '    RecordToVeld(FlRekening)
        '    If bhEuro Then
        '        TotaalResultaat = TotaalResultaat + Val(vBibTekst(FlRekening, "#e" & VB6.Format(AktiefBoekjaar + 23, "000") & " #"))
        '    Else
        '        TotaalResultaat = TotaalResultaat + Val(vBibTekst(FlRekening, "#v" & VB6.Format(AktiefBoekjaar + 23, "000") & " #"))
        '    End If
        '    Do
        '        bNext(FlRekening)
        '        If Ktrl Or VB.Left(KeyBuf(FlRekening), 1) > "7" Then
        '            Exit Do
        '        Else
        '            RecordToVeld(FlRekening)
        '            If bhEuro Then
        '                TotaalResultaat = TotaalResultaat + Val(vBibTekst(FlRekening, "#e" & VB6.Format(AktiefBoekjaar + 23, "000") & " #"))
        '            Else
        '                TotaalResultaat = TotaalResultaat + Val(vBibTekst(FlRekening, "#v" & VB6.Format(AktiefBoekjaar + 23, "000") & " #"))
        '            End If
        '        End If
        '    Loop
        'End If

        'Msg = ""
        'If TotaalResultaat <> 0 Then
        '    Msg = Msg & "Resultatenbalans verschil  : " & Dec(TotaalResultaat, MaskerEURBH) & vbCrLf
        'End If
        'If TotaalBalans <> 0 Then
        '    If Msg = "" Then
        '        Verwittigen = True
        '        Msg = "Blijkbaar is het resultaat verleden jaar GOED geboekt maar actief/passief is verschillend.  Straks wordt U de mogelijkheid geboden om de verschillen bij te werken OP EIGEN VERANTWOORDELIJKHEID" & vbCrLf & vbCrLf
        '    End If
        '    Msg = Msg & "ACTIVE/PASSIVA verschil   : " & Dec(TotaalBalans, MaskerEURBH) & vbCrLf
        'End If
        'If Msg = "" Then
        'Else
        '    Msg = Msg & vbCrLf & "Balansrekeningen Actief <> Passief, Resultaatrekeningen Debet <> Credit" & vbCrLf & vbCrLf & "Eerst resultaatsverwerking vorig jaar boeken a.u.b."
        '    MsgBox(Msg)
        '    'If Verwittigen Then
        '    'Else
        '    'BoekBeginBalans = False
        '    'Exit Function
        '    'End If
        'End If

        'Dim dTotaalKtrl As Decimal
        'Dim dBedrag As Decimal
        'Dim LijnText As String
        'bGetOrGreater(FlRekening, 0, vSet("1", 7))
        'If Ktrl Then
        '    MsgBox("Geen rekeningen ???")
        '    'UPGRADE_WARNING: Couldn't resolve default property of object BoekBeginBalans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    BoekBeginBalans = False
        '    Exit Function
        'ElseIf VB.Left(KeyBuf(FlRekening), 1) < "6" Then
        '    RecordToVeld(FlRekening)
        '    If bhEuro Then
        '        dBedrag = Val(vBibTekst(FlRekening, "#e" & VB6.Format(AktiefBoekjaar + 23, "000") & " #"))
        '    Else
        '        dBedrag = Val(vBibTekst(FlRekening, "#v" & VB6.Format(AktiefBoekjaar + 23, "000") & " #"))
        '    End If
        '    dTotaalKtrl = dTotaalKtrl + dBedrag
        '    If dBedrag <> 0 Then
        '        LijnText = vSet(vBibTekst(FlRekening, "#v019 #"), 7) & " " & vSet(vBibTekst(FlRekening, "#v020 #"), 40) & " " & Dec(dBedrag, MaskerEURBH) & " " & vSet("", 7)
        '        JournaalPost.Items.Add(LijnText)
        '    End If
        '    Do
        '        bNext(FlRekening)
        '        If Ktrl Or VB.Left(KeyBuf(FlRekening), 1) >= "6" Then
        '            Exit Do
        '        Else
        '            RecordToVeld(FlRekening)
        '            If bhEuro Then
        '                dBedrag = Val(vBibTekst(FlRekening, "#e" & VB6.Format(AktiefBoekjaar + 23, "000") & " #"))
        '            Else
        '                dBedrag = Val(vBibTekst(FlRekening, "#v" & VB6.Format(AktiefBoekjaar + 23, "000") & " #"))
        '            End If
        '            dTotaalKtrl = dTotaalKtrl + dBedrag
        '            If dBedrag <> 0 Then
        '                LijnText = vSet(vBibTekst(FlRekening, "#v019 #"), 7) & " " & vSet(vBibTekst(FlRekening, "#v020 #"), 40) & " " & Dec(dBedrag, MaskerEURBH) & " " & vSet("", 7)
        '                JournaalPost.Items.Add(LijnText)
        '            End If
        '        End If
        '    Loop
        'End If
        'Afsluiten.Enabled = True
        'Omschrijving.Text = SoortBoeking.Text
        'Afsluiten.Focus()
        ''
        ''If Verwittigen Then
        'JournaalSaldoKTRL()
        ''Else
        ''    DCkeuze(0).Enabled = False
        ''    DCkeuze(1).Enabled = False
        ''    Bedrag.Visible = False
        ''    RekeningNummer.Visible = False
        ''    TRvlag.Enabled = False
        ''End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object BoekBeginBalans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'BoekBeginBalans = True
        'BJPERDAT.PeriodeBoekjaar.SelectedIndex = 0
    'End Function

    'Private Function AfschrijfBoeking() As Short
        'Dim OmschrijvingsLijn As New VB6.FixedLengthString(40)
        'Dim LijnText As String
        'Dim Succes As Short
        'On Error Resume Next
        'Succes = True
        'If String99(Lees, 63) = "1" Then
        'MsgBox("Afschrijvingsposten reeds gegenereerd voor dit boekjaar.  Bijkomende posten kunnen uitsluitend via 'Diverse post'-optie ingebracht worden !")
        '        AfschrijfBoeking = False
        '            Exit Function
        '        ElseIf String99(Lees, 63) <> "0" Then
        '            MsgBox("Setup boekjaar en parameters bevat niet de juiste vlag geboekt of niet geboekt.  Kontroleer")
        '            AfschrijfBoeking = False
        '            Exit Function
        '        ElseIf String99(Lees, 64) <> "1" Then
        '            MsgBox("Onlogische situatie.  Dit boekjaar bevat nog geen beginbalans ?  De beginbalans dient aanwezig te zijn.  Mogelijk bevindt U zich in het verkeerde boekjaar ?")
        '            AfschrijfBoeking = False
        '            Exit Function
        '        End If

        '        bGetOrGreater(FlAllerlei, 1, vSet("18", 20))
        '        If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "18" Then
        '            MsgBox("Er zijn geen investeringsfiches !")
        '            AfschrijfBoeking = False
        '            Exit Function
        '        Else
        '			'FIXIT: Keyword 'GoSub' not supported in Visual Basic .NET                                 FixIT90210ae-R6614-H1984
        '			'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
        '			GoSub AfschrijvingsLijnErBij
        '			Do
        '                bNext(FlAllerlei)
        '                If Ktrl Or VB.Left(KeyBuf(FlAllerlei), 2) <> "18" Then
        '                    Exit Do
        '                Else
        '					'FIXIT: Keyword 'GoSub' not supported in Visual Basic .NET                                 FixIT90210ae-R6614-H1984
        '					'UPGRADE_ISSUE: GoSub statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"'
        '					GoSub AfschrijvingsLijnErBij
        '				End If
        '            Loop
        '            If Succes Then
        '                Afsluiten.Enabled = True
        '                Omschrijving.Text = SoortBoeking.Text
        '                SoortBoeking.Enabled = False
        '                Afsluiten.Focus()
        '            End If
        '            DCkeuze(0).Enabled = False
        '            DCkeuze(1).Enabled = False
        '            Bedrag.Visible = False
        '            RekeningNummer.Visible = False
        '            TRvlag.Enabled = False
        '            AfschrijfBoeking = True
        '        End If
        '        Exit Function

        'AfschrijvingsLijnErBij:
        '        OmschrijvingsLijn.Value = ""
        '        RecordToVeld(FlAllerlei)
        '        If Len(vBibTekst(FlAllerlei, "#v083 #")) <> 8 Then
        '            OmschrijvingsLijn.Value = "Datumformaat onjuist voor " & vBibTekst(FlAllerlei, "#v087 #")
        '            MsgBox("dokumentendatum niet in formaat DDMMJJEE" & vbCrLf & vbCrLf & OmschrijvingsLijn.Value & vbCrLf & vbCrLf & vBibTekst(FlAllerlei, "#v083 #"))
        '            AfschrijfBoeking = False
        '            Exit Function
        '        End If

        '        Dim dRest As Double
        '        Dim ipct As Short
        '        Dim dTas As Double
        '        Dim dbdrg As Double
        '        Dim dRa As Double
        '        Dim Das As Double
        '        Dim restKtrl As Double
        '        Dim MaskerHier As String
        '        If Mid(vBibTekst(FlAllerlei, "#v083 #"), 5, 4) > Mid(BoekjaarVanTot.Value, 9, 4) Then
        '            'FIXIT: Return has new meaning in Visual Basic .NET                                        FixIT90210ae-R9642-H1984
        '            'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '            Return
        '        ElseIf Val(vBibTekst(FlAllerlei, "#v084 #")) = Val(vBibTekst(FlAllerlei, "#v085 #")) Then
        '            Msg = "Alles is afgeschreven voor " & vBibTekst(FlAllerlei, "#v087 #") & vbCrLf & vbCrLf & "Totaal : " & VB6.Format(Val(vBibTekst(FlAllerlei, "#v084 #")), MaskerSy(0)) & vbCrLf & vbCrLf
        '            If Not adoGet(FlRekening, 0, "=", vBibTekst(FlAllerlei, "#v087 #")) Then
        '                Msg = Msg & "Rekening bestaat zelfs niet eens..."
        '            Else
        '                'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                Msg = Msg + RV(rsMAR(FlRekening), "v020")
        '            End If
        '            MsgBox(Msg)
        '            'FIXIT: Return has new meaning in Visual Basic .NET                                        FixIT90210ae-R9642-H1984
        '            'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '            Return
        '        Else

        '            ipct = Val(vBibTekst(FlAllerlei, "#v082 #"))
        '            dbdrg = Val(vBibTekst(FlAllerlei, "#v084 #"))
        '            dRa = Val(vBibTekst(FlAllerlei, "#v085 #"))

        '            If bhEuro = True Then
        '                restKtrl = 0.5
        '                MaskerHier = MaskerEURBH
        '            Else
        '                restKtrl = 20
        '                MaskerHier = MaskerSy(0)
        '            End If

        '            dRest = dbdrg - (dRa + Val(Dec(dbdrg / ipct, MaskerHier)))

        '            If dRest < restKtrl Then
        '                Das = Val(Dec(dbdrg / ipct, MaskerHier)) + dRest
        '                dTas = dTas + Das
        '            Else
        '                Das = Val(Dec(dbdrg / ipct, MaskerHier))
        '                dTas = dTas + Das
        '            End If
        '        End If

        '        If Not adoGet(FlRekening, 0, "=", vBibTekst(FlAllerlei, "#v087 #")) Then
        '            OmschrijvingsLijn.Value = RTrim(OmschrijvingsLijn.Value) & " Afschr. op!!!"
        '        End If
        '        If Not adoGet(FlRekening, 0, "=", vBibTekst(FlAllerlei, "#v088 #")) Then
        '            OmschrijvingsLijn.Value = RTrim(OmschrijvingsLijn.Value) & " Kostrekening !!"
        '        Else
        '            If OmschrijvingsLijn.Value = Space(40) Then
        '                'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                OmschrijvingsLijn.Value = "Ok, " + RV(rsMAR(FlRekening), "v020")
        '            End If
        '        End If

        '        If VB.Left(OmschrijvingsLijn.Value, 3) = "Ok," Then
        '        Else
        '            Succes = False
        '        End If
        '        LijnText = vSet(vBibTekst(FlAllerlei, "#v088 #"), 7) & " " & OmschrijvingsLijn.Value & " " & Dec(Das, MaskerEURBH) & " " & vSet(vBibTekst(FlAllerlei, "#v087 #"), 7)
        '        JournaalPost.Items.Add(LijnText)
        '        'FIXIT: Return has new meaning in Visual Basic .NET                                        FixIT90210ae-R9642-H1984
        '        'UPGRADE_WARNING: Return has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '        Return
    'End Function

    'Private Sub EindeAfschrijving()
        'Dim dRa As Double
        'Dim DummySleutel As String
        'Dim T As Short

        'If XisEuroWisBEF = True Then
        'Msg = "Laatste afschrijving in BEF is geboekt." & vbCr & vbCr
        'Msg = Msg & "Uw hoogste boekjaar is in EUR" & vbCr & vbCr
        'Msg = Msg & "Hierna worden alle nog openstaande afschrijvingslijnen eveneens omgerekend naar EUR voor toekomstige bewerkingen"
        'MsgBox(Msg, MsgBoxStyle.Information)
        'End If

        'For T = 0 To JournaalPost.Items.Count - 1
        'bGetOrGreater(FlAllerlei, 1, vSet("18" & VB.Right(VB6.GetItemString(JournaalPost, T), 7), 20))
        'If Ktrl Then
        'MsgBox("Stop")
        'Else
        'RecordToVeld(FlAllerlei)
        'dRa = Val(vBibTekst(FlAllerlei, "#v085 #")) + Val(Mid(VB6.GetItemString(JournaalPost, T), 50, 12))
        'vBib(FlAllerlei, Str(dRa), "v085")
        'If XisEuroWisBEF = True Then
        'vBib(FlAllerlei, Str(Val(Dec(dRa / Euro, "########0.00"))), "v085")
        'dRa = Val(vBibTekst(FlAllerlei, "#v084 #"))
        'vBib(FlAllerlei, Str(Val(Dec(dRa / Euro, "########0.00"))), "v084")
        'End If
        'bUpdate(FlAllerlei, 1)
        'If Ktrl Then MsgBox("stop tijdens update investeringsfiche")
        'End If
        'Next
        'SS99("1", 63)

    'End Sub

    Private Sub Afsluiten_Click(sender As Object, e As EventArgs) Handles Afsluiten.Click
        If Trim(Omschrijving.Text) = "" Then
            MsgBox("Omschrijving mag niet leeg zijn, ook géén spaties...", MsgBoxStyle.Information)
            Omschrijving.Focus()
            Exit Sub
        End If
        If Not DatumKtrl(Format(DatumVerwerking.Value, "dd/MM/yyyy"), TekstPeriode) Then
            Beep()
            frmBJPERDAT.WindowState = FormWindowState.Normal
            frmBJPERDAT.Focus()
            DatumVerwerking.Focus()
            Exit Sub
        ElseIf JournaalPost.Items.Count = 0 Then
            Beep()
            Exit Sub
        End If

        Ktrl = MsgBox("Journaalpost bestaande uit" & Str(JournaalPost.Items.Count) & " Lijnen wegboeken.  Bent U zeker ?", 292)
        If Ktrl = 6 Then
            bBegin()
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If BoekFout() Then
                bAbort()
                Me.Activate()
            Else
                Select Case Mid(SoortBoeking.Text, 1, 1)
                    Case "1"
                        'EindeAfschrijving()
                    Case "2"
                        SS99("1", 64)
                    Case "0"
                    Case Else
                        MsgBox("Stop")
                End Select
                bEnd()
                Schoon.PerformClick()
            End If


        End If
    End Sub

End Class