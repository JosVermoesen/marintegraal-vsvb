Option Strict Off
Option Explicit On
Module modDataBaseRoutines

    Dim X As Short
    Function adoBlankoRecord(ByRef Fl As Integer) As Boolean

        TLBRecord(Fl) = ""
        Select Case Fl
            Case FlKlant, FlLeverancier
                vBib(Fl, "2", "A10C") 'Taalkode
                vBib(Fl, "002", "v149") 'Landnummer  ISO kode
                vBib(Fl, "B  ", "A109") 'Landkode Postkantoor
                vBib(Fl, "BE", "v150") 'Landkode    ISO kode
                'If bhEuro Then
                vBib(Fl, "EUR", "vs03") 'Munteenheid ISO kode
                'Else
                'vBib(Fl, "BEF", "vs03") 'Munteenheid ISO kode
                'End If
                vBib(Fl, "1", "vs07") 'exemplaren dokumenten
            Case FlRekening
                vBib(Fl, "O", "v032") 'Budgetcode
        End Select
        Return True

    End Function

    Function vSet(ByRef fTekst As String, ByRef fLengte As Short) As String
        Dim b As String

        b = Left(fTekst, fLengte)
        vSet = b & Space(fLengte - Len(b))

    End Function


    Sub vBib(ByRef Fl As Short, ByRef StringTekst1 As String, ByRef StringTekst2 As String)
        Dim TBLen As Short
        Dim TBStart As Short
        Dim TBStop As Short
        Dim TBCode As String

        TBCode = "#     #"
        Mid(TBCode, 2, 5) = StringTekst2

        If StringTekst1 = "" Then
            StringTekst1 = " "
        End If

jump:
        If InStr(TLBRecord(Fl), TBCode) = 0 Then
            TLBRecord(Fl) = TLBRecord(Fl) & TBCode & StringTekst1 & "#"
        Else
            If RTrim(vBibTekst(Fl, TBCode)) = StringTekst1 Then
                Exit Sub
            Else
                TBLen = Len(TLBRecord(Fl))
                TBStart = InStr(TLBRecord(Fl), TBCode)
                TBStop = InStr(TBStart + 7, TLBRecord(Fl), "#")
                TLBRecord(Fl) = Left(TLBRecord(Fl), TBStart - 1) & Right(TLBRecord(Fl), TBLen - TBStop)
                GoTo jump
            End If
        End If

    End Sub


    Function vBibTekst(ByRef Fl As Short, ByRef TBS As String) As String

        Dim tbsHier As String
        If Mid(TBS, 1, 1) = "#" And Len(TBS) = 7 Then
            tbsHier = TBS
        ElseIf Len(tbs) = 6 Then
            tbsHier = "#     #"
            Mid(tbsHier, 2) = Mid(TBS, 2, 4)
        Else
            Stop
        End If
        Err.Clear()
        On Error Resume Next
        If TLBRecord(Fl) = "" Then
            vBibTekst = ""
        Else
            vBibTekst = Mid(TLBRecord(Fl), InStr(TLBRecord(Fl), tbsHier) + 7, InStr(InStr(TLBRecord(Fl), tbsHier) + 7, TLBRecord(Fl), "#") - (InStr(TLBRecord(Fl), tbsHier) + 7))
        End If
        If Err.Number Then vBibTekst = ""

    End Function

    Function xrsMar(ByRef Fl As Short, ByRef TBS As String) As Object

        'UPGRADE_WARNING: IsEmpty was upgraded to IsNothing and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(rsMAR(Fl).Fields(TBS).Value) Or IsNothing(rsMAR(Fl).Fields(TBS).Value) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object xrsMar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            xrsMar = ""
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object xrsMar. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            xrsMar = rsMAR(Fl).Fields(TBS).Value
        End If

    End Function

    Function oWaarde(ByRef dbWaarde As Object) As Object

        'On Error Resume Next
        'UPGRADE_WARNING: IsEmpty was upgraded to IsNothing and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(dbWaarde) Or IsNothing(dbWaarde) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oWaarde = ""
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object dbWaarde. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object oWaarde. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oWaarde = dbWaarde
        End If

    End Function


    Sub ClearFlDummy()

        bClose(FlDummy)
        Ktrl = bOpen(FlDummy)
        bFirst(FlDummy, 0)
        If Ktrl Then
            bClose(FlDummy)
            Exit Sub
        End If
        bClose(FlDummy)

    End Sub


    Public Function Editmogelijk(ByRef Fl As Short) As Short
        Dim TTT As Short

        Editmogelijk = True
        Exit Function

ProbeerEdit:
        'On Local Error GoTo OpnieuwEdit
        Err.Clear()
        'If ntRS(Fl).EditMode = dbEditNone Then
        If rsMAR(Fl).EditMode = ADODB.EditModeEnum.adEditNone Then
            MsgBox("stop")
            Editmogelijk = False
        Else
            Editmogelijk = True
        End If
        'If IsNull(ntRS(Fl).Fields(0)) Then
        '    ntRS(Fl).AddNew
        'Else
        '    ntRS(Fl).Edit
        'End If
        Exit Function

OpnieuwEdit:
        If Err.Number = 91 Then
            bOpen(Fl)
            GoTo ProbeerEdit
        ElseIf Err.Number = 3021 Then
            'MsgBox "addnew niet uitgevoerd voor bestand " + ntRS(Fl).Name + " !  Verwittig ons."
            MsgBox("addnew niet uitgevoerd voor tabel " & bstNaam(Fl) & " !  Verwittig ons.")
            Err.Clear()
            'ntRS(Fl).AddNew
            rsMAR(Fl).AddNew()
            'msgBox "Addnew 2e poging met succes " + ntRS(Fl).Name + " !  Vergeet ons niet te verwittigen a.u.b. !"
            MsgBox("Addnew 2e poging met succes " & bstNaam(Fl) & " !  Vergeet ons niet te verwittigen a.u.b. !")
            Editmogelijk = True
            Exit Function
        End If
        MsgBox(ErrorToString())
        Msg = "De recordgegevens zelf zijn op dit ogenblik in bewerking bij een andere gebruiker !" & vbCrLf
        Msg = Msg & "Steeds opnieuw proberen ?" & vbCrLf & vbCrLf
        Ktrl = MsgBox(Msg, 5 + 16, "Schrijfbeveiliging andere gebruiker")
        Select Case Ktrl
            Case 4
                Resume
            Case Else
                Exit Function
        End Select

    End Function


    Sub bAbort()

        On Error Resume Next
        Err.Clear()
        'NTRuimte.Rollback
        adntDB.RollbackTrans()
        Ktrl = Err.Number
        If Err.Number Then
            MsgBox(ErrorToString())
        End If

    End Sub

    Sub bBegin()

        On Error Resume Next
        Err.Clear()
        'NTRuimte.BeginTrans
        adntDB.BeginTrans()
        Ktrl = Err.Number
        If Err.Number Then
            MsgBox(ErrorToString())
        End If

    End Sub


    Sub bClose(ByRef Fl As Short)
        Dim T As Short

        If Fl = 99 Then
            For Fl = 0 To AFl
                TLBRecord(Fl) = ""
                If rsMAR(Fl).State = ADODB.ObjectStateEnum.adStateClosed Then
                Else
                    Err.Clear()
                    On Error Resume Next
                    If rsMAR(Fl).EditMode Then
                        rsMAR(Fl).CancelUpdate()
                    End If
                    rsMAR(Fl).Close()
                    Ktrl = Err.Number
                    If Err.Number = 3420 Then MsgBox(ErrorToString())
                End If
            Next
        Else
            If rsMAR(Fl).State = ADODB.ObjectStateEnum.adStateClosed Then
            Else
                Err.Clear()
                On Error Resume Next
                If rsMAR(Fl).EditMode Then
                    rsMAR(Fl).CancelUpdate()
                End If
                rsMAR(Fl).Close()
                Ktrl = Err.Number
                If Err.Number = 3420 Then MsgBox(ErrorToString())
            End If
        End If

    End Sub

    Sub bDelete(ByRef Fl As Short)

        Ktrl = 0
        If VsoftLog Then
            SchrijfLog("DELETE", Fl, 0, "")
        End If

        On Error Resume Next
        Err.Clear()
        'ntRS(Fl).Delete
        rsMAR(Fl).Delete()
        Ktrl = Err.Number
        If Err.Number Then
            MsgBox(ErrorToString())
        End If

    End Sub


    Sub bEnd()

        On Error Resume Next
        adntDB.CommitTrans()
        Ktrl = Err.Number
        If Err.Number Then
            MsgBox(ErrorToString())
        End If

    End Sub

    Sub bFirst(ByRef Fl As Short, ByRef fIndex As Short)

        On Error Resume Next

        bClose(Fl)
        If VsoftLog Then
            SchrijfLog("FIRST ", Fl, fIndex, "")
        End If

        Err.Clear()
        'SELECT  TOP 1 * FROM Klanten ORDER BY A110 ASC
        sqlMsg(Fl) = "SELECT TOP 1 * FROM " & bstNaam(Fl) & " ORDER BY " & FlIndexIs(Fl, fIndex) & " ASC"
        Ktrl = 0 : bOpen(Fl)

        If rsMAR(Fl).EOF Then
            MsgBox("Stop")
        ElseIf rsMAR(Fl).RecordCount = -1 Then
            MsgBox("Stop")
        ElseIf rsMAR(Fl).RecordCount = 1 Then
            'fSleutel = vSet(fSleutel, FlIndexLen(Fl, fIndex))
            KeyIndex(Fl) = fIndex
        ElseIf rsMAR(Fl).RecordCount > 1 Then
            MsgBox("Stop")
        End If

    End Sub

    Sub bGet(ByRef Fl As Short, ByRef fIndex As Short, ByRef fSleutel As String)

        On Error Resume Next
        bClose(Fl)
        If VsoftLog Then
            SchrijfLog("GET   ", Fl, fIndex, fSleutel)
        End If

        Err.Clear()
        fSleutel = vSet(fSleutel, FlIndexLen(Fl, fIndex))
        sqlMsg(Fl) = "SELECT * FROM " & bstNaam(Fl) & " WHERE " & FlIndexIs(Fl, fIndex) & "='" & fSleutel & "'"
        Ktrl = 0 : bOpen(Fl)

        If rsMAR(Fl).EOF Then
            Ktrl = 9
        ElseIf rsMAR(Fl).RecordCount = -1 Then
            MsgBox("Stop")
        ElseIf rsMAR(Fl).RecordCount = 1 Then
            KeyBuf(Fl) = vSet(fSleutel, FlIndexLen(Fl, fIndex))
            KeyIndex(Fl) = fIndex
        ElseIf rsMAR(Fl).RecordCount > 1 Then
            MsgBox("Stop")
        End If

    End Sub

    Sub bGetOrGreater(ByRef Fl As Short, ByRef fIndex As Short, ByRef fSleutel As String)

        On Error Resume Next

opnieuwGOG:
        If rsMAR(Fl).State = ADODB.ObjectStateEnum.adStateClosed Then
            Ktrl = bOpen(Fl)
        End If
        If VsoftLog Then
            SchrijfLog("GETOG ", Fl, fIndex, fSleutel)
        End If

        Err.Clear()
        fSleutel = vSet(fSleutel, FlIndexLen(Fl, fIndex))
        'If ntRS(Fl).Index = FLIndexCaption(Fl, fIndex) Then
        If rsMAR(Fl).Index = FLIndexCaption(Fl, fIndex) Then
        Else
            'ntRS(Fl).Index = FLIndexCaption(Fl, fIndex)
            rsMAR(Fl).Index = FLIndexCaption(Fl, fIndex)
            If Err.Number = -2147217883 Then
                'MsgBox "Stop"
                bClose(Fl)
                System.Windows.Forms.Application.DoEvents()
                GoTo opnieuwGOG
            End If
        End If

        'ntRS(Fl).Seek "=", fSleutel
        rsMAR(Fl).Seek(fSleutel, ADODB.SeekEnum.adSeekAfterEQ)

        'If ntRS(Fl).NoMatch Then

        If rsMAR(Fl).EOF Then
            Ktrl = 4
        Else
            Ktrl = 0
        End If
        KeyBuf(Fl) = rsMAR(Fl).Fields(RTrim(FlIndexIs(Fl, fIndex))).Value
        KeyIndex(Fl) = fIndex

        'KeyBuf(Fl) = vSet(fSleutel, FlIndexLen(Fl, fIndex))


    End Sub
    Sub bInsert(ByRef Fl As Short, ByRef fIndex As Short) ', fSleutel As String)
        Dim XXXXX As Short

        If Fl = Fldokument Then
        Else
            If rsMAR(Fl).State = ADODB.ObjectStateEnum.adStateClosed Then
                Ktrl = bOpen(Fl)
            End If
            'ntRS(Fl).AddNew
            rsMAR(Fl).AddNew()
        End If
        XXXXX = VeldToRecord(Fl)
        If Ktrl = 32000 Then Exit Sub
        KeyIndex(Fl) = fIndex
        KeyBuf(Fl) = FVT(Fl, fIndex)
        If VsoftLog Then
            SchrijfLog("INSERT", Fl, fIndex, "")
        End If

        Dim Pipo As Object
        If Fl = FlJournaal Then
            dKtrlCumul = dKtrlCumul + Val(rsMAR(FlJournaal).Fields("v068").Value)
            If bhEuro Then
                dKtrlBEF = dKtrlBEF + System.Math.Round(Val(rsMAR(FlJournaal).Fields("v068").Value) * Euro, 0)
                dKtrlEUR = dKtrlEUR + System.Math.Round(Val(rsMAR(FlJournaal).Fields("v068").Value), 2)
                On Error Resume Next
                rsMAR(FlJournaal).Fields("dece068").Value = Val(rsMAR(FlJournaal).Fields("v068").Value)
                Err.Clear()
                On Error Resume Next
            Else
                dKtrlBEF = dKtrlBEF + System.Math.Round(Val(rsMAR(FlJournaal).Fields("v068").Value), 0)
                dKtrlEUR = dKtrlEUR + System.Math.Round(Val(rsMAR(FlJournaal).Fields("v068").Value) / Euro, 2)
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Pipo = rsMAR(Fl).Fields("v019").Value & vbTab & rsMAR(Fl).Fields("v067").Value & vbTab
            If bhEuro Then
                If Val(rsMAR(Fl).Fields("v068").Value) < 0 Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Pipo = Pipo & "" & vbTab & Format(-Val(rsMAR(Fl).Fields("v068").Value), "#,##0.00")
                    'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Pipo = Pipo & vbTab & "" & vbTab & Format(System.Math.Round(-Val(rsMAR(Fl).Fields("v068").Value) * Euro, 0), "#,##0.00")
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Pipo = Pipo & Format(Val(rsMAR(Fl).Fields("v068").Value), "#,##0.00") & vbTab & ""
                    'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Pipo = Pipo & vbTab & Format(System.Math.Round(Val(rsMAR(Fl).Fields("v068").Value) * Euro, 0), "#,##0.00") & vbTab & ""
                End If
            Else
                If Val(rsMAR(Fl).Fields("v068").Value) < 0 Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Pipo = Pipo & "" & vbTab & Format(-Val(rsMAR(Fl).Fields("v068").Value) / Euro, "#,##0.00")
                    'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Pipo = Pipo & vbTab & "" & vbTab & Format(-Val(rsMAR(Fl).Fields("v068").Value), "#,##0.00")
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Pipo = Pipo & Format(Val(rsMAR(Fl).Fields("v068").Value) / Euro, "#,##0.00") & vbTab & ""
                    'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Pipo = Pipo & vbTab & Format(Val(rsMAR(Fl).Fields("v068").Value), "#,##0.00") & vbTab & ""
                End If
            End If
            'UPGRADE_WARNING: Couldn't resolve default property of object Pipo. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Stop
            'TO DO:frmBoeking.mshfBoekLijst.AddItem(Pipo, frmBoeking.mshfBoekLijst.Rows - 1)
        End If

        On Error GoTo AccesErrorInsert
        Ktrl = 0
        'ntRS(Fl).Update
        rsMAR(Fl).Update()
        If Fl = FlJournaal Then
            If Ktrl Then
                MsgBox("bInsert journaal stopkode " & Str(Ktrl))
            Else
                bGet(FlRekening, 0, Left(FVT(FlJournaal, 0), 7))
                If Ktrl Then
                    MsgBox("Rekening " & Left(FVT(FlJournaal, 0), 7) & " niet te vinden." & vbCrLf & "Eerst SETUPrekening inbrengen a.u.b. !")
                    dKtrlCumul = dKtrlCumul + 99
                    Exit Sub
                ElseIf AktiefBoekjaar Then
                    RecordToVeld(FlRekening)
                    vBib(FlRekening, Str(Val(vBibTekst(FlRekening, "#e023 #")) + Val(vBibTekst(FlJournaal, "#v068 #"))), "e023")
                    rsMAR(FlRekening).Fields("dece023").Value = rsMAR(FlRekening).Fields("dece023").Value + rsMAR(FlJournaal).Fields("dece068").Value
                Else
                    RecordToVeld(FlRekening)
                    vBib(FlRekening, Str(Val(vBibTekst(FlRekening, "#e022 #")) + Val(vBibTekst(FlJournaal, "#v068 #"))), "e022")
                    rsMAR(FlRekening).Fields("dece022").Value = rsMAR(FlRekening).Fields("dece022").Value + rsMAR(FlJournaal).Fields("dece068").Value
                End If
                bUpdate(FlRekening, 0)
            End If
        End If
        Select Case Ktrl
            Case 0
            Case 5
                Msg = "Dergelijke ID.Kode Bestaat reeds : " & KeyBuf(Fl) & " : " & Str(Fl)
                MsgBox(Msg)
            Case 46
                Msg = "Bestand werd geopend in LEES-modus." & vbCrLf & "Schrijven is niet mogelijk..."
                MsgBox(Msg, 0, "Database beveiliging")

            Case Else
                Msg = "Stopkode " & Str(Ktrl) & " tijdens invoegen nieuwe record."
                MsgBox(Msg)
        End Select
        Exit Sub

AccesErrorInsert:
        Select Case Err.Number
            Case 3022
                MsgBox("Unieke sleutel reeds aanwezig in bestand : " & bstNaam(Fl) & vbCrLf & vbCrLf & "Mogelijke sleutel : " & FVT(Fl, fIndex))
                Ktrl = Err.Number
            Case Else
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rsMAR(Fl).Fields(fIndex).Value) Then
                    MsgBox(ErrorToString() & vbCrLf & vbCrLf & "Bestand : " & bstNaam(Fl) & vbCrLf & vbCrLf & "De sleutel heeft 'null' waarde", MsgBoxStyle.Exclamation)
                Else
                    MsgBox(ErrorToString() & vbCrLf & vbCrLf & "Bestand : " & bstNaam(Fl) & vbCrLf & vbCrLf & "Mogelijke sleutel : " & FVT(Fl, fIndex), MsgBoxStyle.Exclamation)
                End If
                Ktrl = Err.Number
        End Select
        Resume Next

    End Sub

    Sub bLast(ByRef Fl As Short, ByRef fIndex As Short)

        On Error Resume Next

        bClose(Fl)
        If VsoftLog Then
            SchrijfLog("LAST  ", Fl, fIndex, "")
        End If

        Err.Clear()
        'SELECT  TOP 1 * FROM Klanten ORDER BY A110 DESC
        sqlMsg(Fl) = "SELECT TOP 1 * FROM " & bstNaam(Fl) & " ORDER BY " & FlIndexIs(Fl, fIndex) & " DESC"
        Ktrl = 0 : bOpen(Fl)

        If rsMAR(Fl).EOF Then
            Stop
        ElseIf rsMAR(Fl).RecordCount = -1 Then
            Stop
        ElseIf rsMAR(Fl).RecordCount = 1 Then
            'fSleutel = vSet(fSleutel, FlIndexLen(Fl, fIndex))
            KeyIndex(Fl) = fIndex
        ElseIf rsMAR(Fl).RecordCount > 1 Then
            Stop
        End If

    End Sub


    Sub bNext(ByRef Fl As Short, ByRef fIndex As Short, ByRef SleutelBefore As String)

        On Error Resume Next
        bClose(Fl)
        If VsoftLog Then
            SchrijfLog("NEXT  ", Fl, 0, "")
        End If

        Err.Clear()

        sqlMsg(Fl) = "SELECT TOP 1 * FROM " & bstNaam(Fl) & " WHERE " & FlIndexIs(Fl, fIndex) & " > '" & SleutelBefore & "' " & " ORDER BY " & FlIndexIs(Fl, fIndex) & " ASC"
        Ktrl = 0 : bOpen(Fl)

        If rsMAR(Fl).EOF Then
            Ktrl = 9
        ElseIf rsMAR(Fl).RecordCount = -1 Then
            Ktrl = 9
        ElseIf rsMAR(Fl).RecordCount = 1 Then
            'KeyBuf(Fl) = vSet(fSleutel, FlIndexLen(Fl, fIndex))
            KeyBuf(Fl) = ""
            KeyIndex(Fl) = fIndex
        ElseIf rsMAR(Fl).RecordCount > 1 Then
            MsgBox("Stop meer dan een record!")
        End If

    End Sub

    Function bOpen(ByRef Fl As Short) As Short
        Dim DataLijn As String
        Dim FlNr As Short
        Dim Dlen As Short

        If rsMAR(Fl).State = ADODB.ObjectStateEnum.adStateClosed Then
        Else
            bOpen = 0
            Exit Function
        End If

        Err.Clear()
        On Error Resume Next
        rsMAR(Fl).CursorLocation = ADODB.CursorLocationEnum.adUseClient 'ADODB.CursorLocationEnum.adUseServer
        If Fl = FlTeller Then
            rsMAR(Fl).Open(sqlMsg(Fl), adntDB) ', ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTableDirect)
        Else
            rsMAR(Fl).Open(sqlMsg(Fl), adntDB, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdTableDirect)
        End If

        'ntRS(Fl).LockEdits = False
        If Err.Number Then
            MsgBox(ErrorToString())
            Ktrl = Err.Number
        Else
            bOpen = 0
        End If

    End Function

    Sub bPrev(ByRef Fl As Short, ByRef fIndex As Short, ByRef SleutelBefore As String)

        On Error Resume Next
        bClose(Fl)
        If VsoftLog Then
            SchrijfLog("PREV  ", Fl, 0, "")
        End If


        Err.Clear()
        sqlMsg(Fl) = "SELECT TOP 1 * FROM " & bstNaam(Fl) & " WHERE " & FlIndexIs(Fl, fIndex) & " < '" & SleutelBefore & "' " & " ORDER BY " & FlIndexIs(Fl, fIndex) & " DESC"
        Ktrl = 0 : bOpen(Fl)

        If rsMAR(Fl).EOF Then
            Ktrl = 9
        ElseIf rsMAR(Fl).RecordCount = -1 Then
            Ktrl = 9
        ElseIf rsMAR(Fl).RecordCount = 1 Then
            'KeyBuf(Fl) = vSet(fSleutel, FlIndexLen(Fl, fIndex))
            KeyBuf(Fl) = ""
            KeyIndex(Fl) = fIndex
        ElseIf rsMAR(Fl).RecordCount > 1 Then
            MsgBox("Stop meer dan een record!")
        End If


    End Sub
    Sub bUpdate(ByRef Fl As Short, ByRef fIndex As Short)
        Dim XXXXX As Short
        Err.Clear()
        XXXXX = VeldToRecord(Fl)
        If Ktrl = 32000 Then Exit Sub
        KeyBuf(Fl) = FVT(Fl, fIndex)
        KeyIndex(Fl) = fIndex
        rsMAR(Fl).Fields("dnnsync").Value = False
        If VsoftLog Then
            SchrijfLog("UPDATE", Fl, fIndex, "")
        End If
        Try
            rsMAR(Fl).Update()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function RTV(ByRef Fl As Short) As Short
        Dim T As Short

        RTV = False
        TLBRecord(Fl) = ""
        On Error Resume Next
        T = 0
        Do While Asc(vBC(Fl, T)) <> 0
            'vBib Fl, RTrim$(ntRS(Fl).Fields(vBC(Fl, T))), vBC(Fl, T)
            vBib(Fl, RTrim(rsMAR(Fl).Fields(vBC(Fl, T)).Value), vBC(Fl, T))
            T = T + 1
        Loop
        For T = 0 To FlAantalIndexen(Fl)
            FVT(Fl, T) = vBibTekst(Fl, "#" & FlIndexIs(Fl, T) & "#")
        Next
        RTV = True

    End Function


    Sub RecordToVeld(ByRef Fl As Short)
        Dim T As Short
        Dim b As String

        TLBRecord(Fl) = ""
        On Error Resume Next
        T = 0
        If Fl = FlAllerlei Then
            'TLBRecord(Fl) = ntRS(Fl).Fields("MEMO")
            TLBRecord(Fl) = rsMAR(Fl).Fields("MEMO").Value
        ElseIf Fl = FlDummy Then
            'TLBRecord(Fl) = ntRS(Fl).Fields("MEMO")
            TLBRecord(Fl) = rsMAR(Fl).Fields("MEMO").Value
        Else
            Do While vBC(Fl, T) <> ""
                'vBib Fl, Trim$(ntRS(Fl).Fields(vBC(Fl, T))), vBC(Fl, T)
                vBib(Fl, rsMAR(Fl).Fields(vBC(Fl, T)).Value, vBC(Fl, T))
                T = T + 1
            Loop
        End If

    End Sub


    Sub SchrijfLog(ByRef BtrieveAktie As String, ByRef FlNummer As Short, ByRef IndexNummer As Short, ByRef IndexSleutel As String)
        Dim FlLog As Short
        Dim RecordLijn As String

        RecordLijn = BtrieveAktie & Format(IndexNummer)
        Select Case FlNummer
            Case FlAllerlei
                RecordLijn = RecordLijn & "ALLERLEI"
            Case FlKlant
                RecordLijn = RecordLijn & "KLANTEN "
            Case FlLeverancier
                RecordLijn = RecordLijn & "LEVERANC"
            Case FlRekening
                RecordLijn = RecordLijn & "REKENING"
            Case FlProdukt
                RecordLijn = RecordLijn & "PRODUKT "
            Case Fldokument
                RecordLijn = RecordLijn & "dokument"
            Case FlJournaal
                RecordLijn = RecordLijn & "JOURNAAL"
            Case FlPolis
                RecordLijn = RecordLijn & "POLISSEN"
            Case FlTeller
                RecordLijn = RecordLijn & "TELLERS "
        End Select

        Select Case BtrieveAktie
            Case "INSERT", "UPDATE"
                RecordLijn = RecordLijn & TLBRecord(FlNummer)
            Case Else
                RecordLijn = RecordLijn & IndexSleutel
        End Select

        FlLog = FreeFile()
        FileOpen(FlLog, ProgrammaLokatie & "NTIMPORT.LOG", OpenMode.Append, , OpenShare.LockWrite)
        Print(FlLog, RecordLijn & vbCrLf)
        FileClose(FlLog)

    End Sub


    Sub SetFields(ByRef Fl As Short, ByRef vBibCode As String, ByRef StringData As String)
        Dim vBCode As String
        If StringData = "" Then
            StringData = " "
        End If
        vBCode = RTrim(vBibCode)
        Debug.Print(vBCode)
        If RTrim(vBCode) = "MEMO" Then
            Try
                rsMAR(Fl).Fields(vBCode).Value = TLBRecord(Fl)
            Catch ex As Exception
                MsgBox(ex.Message)
                Stop
            End Try

        Else
            Try
                rsMAR(Fl).Fields(vBCode).Value = Mid(StringData, 1, rsMAR(Fl).Fields(vBCode).DefinedSize)
            Catch ex As Exception
                MsgBox(ex.Message)
                Stop
            End Try
        End If
    End Sub


    Function VeldToRecord(ByRef Fl As Short) As Short
        Dim T As Short

        On Error GoTo 0
        If rsMAR(Fl).State = ADODB.ObjectStateEnum.adStateClosed Then
            Ktrl = bOpen(Fl)
            'ElseIf Editmogelijk(Fl) = False Then
            '    Ktrl = 32000
            '    Exit Function
        End If

        If Fl = FlPolis Then
            vBib(Fl, vSet(vBibTekst(Fl, "#v164 #"), 2) & vSet(vBibTekst(Fl, "#A110 #"), 12) & vSet(vBibTekst(Fl, "#A010 #"), 4) & vSet(vBibTekst(Fl, "#A000 #"), 12), "v167") 'MaandKlantMaatschappijPolis
        ElseIf Fl = FlJournaal Then
            vBib(Fl, vSet(vBibTekst(Fl, "#v019 #"), 7) & vBibTekst(Fl, "#v066 #"), "v070")
        End If
        For T = 0 To FlAantalIndexen(Fl)
            FVT(Fl, T) = vSet(vBibTekst(Fl, "#" & FlIndexIs(Fl, T) & "#"), FlIndexLen(Fl, T))
        Next
        vBib(Fl, FVT(Fl, 0), FlIndexIs(Fl, 0))
        T = 0
        Do While vBC(Fl, T) <> ""
            SetFields(Fl, vBC(Fl, T), vBibTekst(Fl, "#" & vBC(Fl, T) & " #"))
            T = T + 1
        Loop
        On Error Resume Next
        If Fl = FlAllerlei Then
            rsMAR(FlAllerlei).Fields("A000").Value = vBibTekst(FlAllerlei, "#A000 #")
        End If

    End Function

    Function String99(ByRef LockModus As Short, ByRef SZNummer As Short) As String
        Dim TlString As String

        TlString = "s" & Format(SZNummer, "000")
        If LockModus = Lees Then
            LockHold = False
        Else
            LockHold = True
        End If
        bGet(FlTeller, 0, TlString)

        If Ktrl = 99 Then
        ElseIf Ktrl Then
            MsgBox("Tellers Stopkode " & Format(Ktrl) & ", voor setup-tellersleutel " & TlString & vbCrLf & vbCrLf & "Overloop ALLE setup instellingen vooraleer énig boekjaar op te starten !" & vbCrLf & "Wij staan tot uw beschikking om U hierbij te helpen.")
        Else
            RecordToVeld(FlTeller)
            'String99 = ntRS(FlTeller).Fields("v217")
            On Error Resume Next
            Err.Clear()
            String99 = rsMAR(FlTeller).Fields("v217").Value
            If Err.Number Then MsgBox(ErrorToString())
        End If
        bClose(FlTeller)

    End Function

    Function TeleBibPagina(ByRef Fl As Short) As Short
        Dim FlInput As Short
        Dim FFDefinitie As String
        Dim DummyString As String
        Dim DummYtje As String
        Dim KtrlAantal As Integer

        Dim CurBedrag As Decimal
        Dim T As Short

        TeleBibPagina = False



        On Error GoTo TeleBibError

        'code= 1 - 1 : Poliskontrole 1 = ON
        '      2 - 3 : Selektiekeuze waarde (ListIDX)
        '      4 - 4 :
        '      5 - 8 : TeleBib
        '      9 - 9 : Volgnummer eventueel 1 tot 9
        '      10    : * voor verplichte invulling
        'Inlaadvolgorde 1 : 000     'hoofddefinitie (VSOFT)
        '               2 : xxxG    'uitbreiding gebruiker
        '               2 : xxxM    'uitbreiding makelaar

        Dim LokaalBestand As String

        If Fl <> FlTeller Then
            LokaalBestand = Left(Bestand(Fl), 3)
        Else
            LokaalBestand = "00"
        End If

        Dim ProgrammaLokatieHier As String = Application.StartupPath & "\"

        'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Dir(ProgrammaLokatieHier & "Def\" & LokaalBestand & ".Def") = "" Then
            MsgBox("Geen VsoftBib definitie " & ProgrammaLokatieHier & "Def\" & LokaalBestand & ".Def")
            Exit Function
        End If

EerstEnVooral:
        'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If Dir(ProgrammaLokatieHier & "Def\" & LokaalBestand & "U.Def") = "" Then
            GoTo GeenUserVoorkeur
        Else
            T = 0
            FlInput = FreeFile()
            FileOpen(FlInput, ProgrammaLokatieHier & "Def\" & LokaalBestand & "U.Def", OpenMode.Input)
            Do While Not EOF(FlInput)
                Input(FlInput, TeleBibCode(T))
                Input(FlInput, TeleBibTekst(T))
                Input(FlInput, TeleBibType(T))
                Input(FlInput, TeleBibLengte(T))
                vBC(Fl, T) = Mid(TeleBibCode(T), 5, 4)
                T = T + 1
            Loop
            vBC(Fl, T) = ""
            FileClose(FlInput)
            TeleBibCode(T) = ""
            TeleBibLast = T - 1
            TeleBibPagina = True
            Exit Function
        End If

GeenUserVoorkeur:
        FlInput = FreeFile()
        FileOpen(FlInput, ProgrammaLokatieHier & "Def\" & LokaalBestand & ".Def", OpenMode.Input)
        T = 0
        Do While Not EOF(FlInput)
            Input(FlInput, TeleBibCode(T))
            Input(FlInput, TeleBibTekst(T))
            Input(FlInput, TeleBibType(T))
            Input(FlInput, TeleBibLengte(T))
            vBC(Fl, T) = Mid(TeleBibCode(T), 5, 4)
            T = T + 1
        Loop
        vBC(Fl, T) = ""
        FileClose(FlInput)
        TeleBibLast = T - 1
        TeleBibCode(T) = ""
        TeleBibPagina = True

MakelaarIn:
        If Trim(ProducentNummer) = "" Then
            'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        ElseIf Dir(ProgrammaLokatieHier & "Def\" & LokaalBestand & "M.Def") = "" Then
        Else
            FlInput = FreeFile()
            FileOpen(FlInput, ProgrammaLokatieHier & "Def\" & LokaalBestand & "M.Def", OpenMode.Input)
            Do While Not EOF(FlInput)
                Input(FlInput, TeleBibCode(T))
                Input(FlInput, TeleBibTekst(T))
                Input(FlInput, TeleBibType(T))
                Input(FlInput, TeleBibLengte(T))
                vBC(Fl, T) = Mid(TeleBibCode(T), 5, 4)
                T = T + 1
            Loop
            vBC(Fl, T) = ""
            FileClose(FlInput)
            TeleBibLast = T - 1
            TeleBibCode(T) = ""
        End If
        Exit Function

TeleBibError:
        MsgBox("Telebibinlaadfout" & Str(T) & " error:" & ErrorToString())
        FileClose(FlInput)
        TeleBibPagina = False
        Exit Function
        Resume

    End Function

    Function fmarBoxText(ByRef marBoxNumber As String, ByRef Taal As String, ByRef marBoxOption As String) As String
        Dim ZoekTekst As String
        fmarBoxText = ""

        If Len(marBoxNumber) = 2 Then
            ZoekTekst = "NTKB" & Taal & "9"
        ElseIf Len(marBoxNumber) = 3 Then
            ZoekTekst = "NTKB" & Taal
        ElseIf Len(marBoxNumber) = 4 Then
            MsgBox("Stop")
            ZoekTekst = "NT"
        Else
            MsgBox("fmarBoxText fout")
            Exit Function
        End If
        ZoekTekst = ZoekTekst & marBoxNumber
        fmarBoxText = ZoekEnPlaats(KeuzeVSF.NTBoxLijst, ZoekTekst, 0, 0, marBoxOption)

    End Function

    Function ZoekEnPlaats(ByRef DeKontrol As ListBox, ByRef ZoekTekst As String, ByRef ALijnen As Short, ByRef OptieNr As Short, ByRef OptieTxt As String) As String
        Dim OptieLen As Short
        'Dim CRLFLokatie As Integer
        Dim PuntKommaLokatie As Short

        Dim DeString As String
        Dim joinStringHier As String


        ZoekEnPlaats = ""
        adKBTable.Seek(ZoekTekst, ADODB.SeekEnum.adSeekFirstEQ)
        If adKBTable.EOF Then
            MsgBox("Stop !  Keuzebox " & ZoekTekst & " niet te vinden...")
            Exit Function
        Else
            'adKBTable.Fields("BestandsNaam")
            joinStringHier = adKBTable.Fields("splitDefinitie").Value
        End If

        PuntKommaLokatie = 1
        ALijnen = 0
        OptieNr = 0
        OptieLen = Len(OptieTxt)
        'UPGRADE_WARNING: Couldn't resolve default property of object DeKontrol.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        DeKontrol.Items.Clear()
        Do While InStr(PuntKommaLokatie, joinStringHier, ";")
            ALijnen = ALijnen + 1
            DeString = Mid(joinStringHier, PuntKommaLokatie, InStr(PuntKommaLokatie, joinStringHier, ";") - PuntKommaLokatie)
            'KeuzeVSF.NTBoxLijst.AddItem DeString
            'UPGRADE_WARNING: Couldn't resolve default property of object DeKontrol.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            DeKontrol.Items.Add(DeString)
            If Mid(joinStringHier, PuntKommaLokatie, OptieLen) = OptieTxt Then
                OptieNr = ALijnen - 1
                ZoekEnPlaats = DeString
            End If
            PuntKommaLokatie = InStr(PuntKommaLokatie, joinStringHier, ";") + 1
        Loop
        If Len(OptieTxt) = 0 Then OptieNr = 0

    End Function
    Function RV(ByRef adoRecord As ADODB.Recordset, ByRef TBS As String) As Object
        If IsDBNull(adoRecord.Fields(TBS).Value) Or IsNothing(adoRecord.Fields(TBS).Value) Then
            RV = ""
        Else
            RV = adoRecord.Fields(TBS).Value
        End If
    End Function
    Function adoJournaalOK() As Boolean

        adoJournaalOK = False
        'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Dim Pipo As String
        Dim nieuwePipo As String

        nieuwePipo = rsJournaal.Fields("v019").Value

        Dim itemHier As New ListViewItem(nieuwePipo)
        itemHier.SubItems.Add(rsJournaal.Fields("v067").Value)
        If Val(RV(rsJournaal, "v068")) = 0 Then
            MsgBox("BoekBedrag is 0")
            Stop
        Else
            dKtrlCumul = dKtrlCumul + Val(RV(rsJournaal, "v068"))
            dKtrlBEF = dKtrlBEF + Math.Round(Val(RV(rsJournaal, "v068")) * Euro, 0)
            dKtrlEUR = dKtrlEUR + Math.Round(Val(RV(rsJournaal, "v068")), 2)
            rsJournaal.Fields("dece068").Value = Val(RV(rsJournaal, "v068"))
            Pipo = rsJournaal.Fields("v019").Value & vbTab & rsJournaal.Fields("v067").Value & vbTab
            If Val(rsJournaal.Fields("v068").Value) < 0 Then
                Pipo = Pipo & "" & vbTab & Format(-Val(rsJournaal.Fields("v068").Value), "#,##0.00")
                Pipo = Pipo & vbTab & "" & vbTab & Format(Math.Round(-Val(rsJournaal.Fields("v068").Value) * Euro), "#,##0.00")
                itemHier.SubItems.Add(" ")
                itemHier.SubItems.Add(Format(-Val(rsJournaal.Fields("v068").Value), "#,##0.00"))
                itemHier.SubItems.Add(" ")
                itemHier.SubItems.Add(Format(Math.Round(-Val(rsJournaal.Fields("v068").Value) * Euro), "#,##0.00"))
            Else
                Pipo = Pipo & Format(Val(rsJournaal.Fields("v068").Value), "#,##0.00") & vbTab & ""
                Pipo = Pipo & vbTab & Format(Math.Round(Val(rsJournaal.Fields("v068").Value) * Euro), "#,##0.00") & vbTab & ""
                itemHier.SubItems.Add(Format(Val(rsJournaal.Fields("v068").Value), "#,##0.00"))
                itemHier.SubItems.Add(" ")
                itemHier.SubItems.Add(Format(Math.Round(Val(rsJournaal.Fields("v068").Value) * Euro), "#,##0.00"))
                itemHier.SubItems.Add(" ")
            End If
            'TODOBoeking. Boeking.mshfBoekLijst.AddItem(Pipo, frmBoeking.mshfBoekLijst.Rows - 1)
        End If
        Boeking.boekListView.Items.Add(itemHier)

        rsJournaal.Fields("v070").Value = vSet(rsJournaal.Fields("v019").Value, 7) + rsJournaal.Fields("v066").Value

        bGet(FlRekening, 0, rsJournaal.Fields("v019").Value)
        If Ktrl Then
            MsgBox("Rekening " + rsJournaal.Fields("v019").Value + " niet te vinden." + vbCrLf + "Eerst SETUPrekening inbrengen a.u.b. !")
            dKtrlCumul = dKtrlCumul + 99
            Exit Function
        ElseIf AktiefBoekjaar Then
            RecordToVeld(FlRekening)
            'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            vBib(FlRekening, Str(Val(vBibTekst(FlRekening, "#e023 #")) + Val(RV(rsJournaal, "v068"))), "e023")
            'UPGRADE_WARNING: Couldn't resolve default property of object RV(rsJournaal, dece068). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rsMAR(FlRekening).Fields("dece023").Value = rsMAR(FlRekening).Fields("dece023").Value + RV(rsJournaal, "dece068")
        Else
            RecordToVeld(FlRekening)
            'UPGRADE_WARNING: Couldn't resolve default property of object RV(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            vBib(FlRekening, Str(Val(vBibTekst(FlRekening, "#e022 #")) + Val(RV(rsJournaal, "v068"))), "e022")
            'UPGRADE_WARNING: Couldn't resolve default property of object RV(rsJournaal, dece068). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rsMAR(FlRekening).Fields("dece022").Value = rsMAR(FlRekening).Fields("dece022").Value + RV(rsJournaal, "dece068")
        End If
        rsMAR(FlRekening).Fields("dnnsync").Value = False
        bUpdate(FlRekening, 0)
        Err.Clear()
        On Error Resume Next
        rsJournaal.Update()
        If Err.Number Then
            MsgBox(ErrorToString())
        Else
            adoJournaalOK = True
        End If

    End Function
    Function adoGet(ByRef iTabel As Short, ByRef iIndex As Short, ByRef sZoals As String, ByRef sZoek As Object) As Boolean

        Dim MsgHier As String

        On Error Resume Next
        If rsMAR(iTabel).State = ADODB.ObjectStateEnum.adStateClosed Then
            Ktrl = bOpen(iTabel)
        End If
        adoGet = False
        Err.Clear()
        If InStr(SQLConnect, "SQLOLEDB") Then
            rsMAR(iTabel).Close()
            If iTabel = FlTeller Then
                'UPGRADE_WARNING: Couldn't resolve default property of object sZoek. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MsgHier = "SELECT * FROM " & "jr" & bstNaam(iTabel) & " WHERE " & FlIndexIs(iTabel, iIndex) & " " & sZoals & " " & " '" & sZoek & "'"
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object sZoek. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MsgHier = "SELECT * FROM " & bstNaam(iTabel) & " WHERE " & FlIndexIs(iTabel, iIndex) & " " & sZoals & " " & " '" & sZoek & "'"
            End If
            'SnelHelpPrint MsgHier, blLogging
            rsMAR(iTabel).Open(MsgHier, adntDB, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
            If Err.Number Then
                MsgBox("Bron:" & vbCrLf & Err.Source & vbCrLf & vbCrLf & "Foutnummer: " & Err.Number & vbCrLf & vbCrLf & "Detail:" & vbCrLf & Err.Description)
                Exit Function
            ElseIf rsMAR(iTabel).RecordCount Then
                adoGet = True
            End If
        Else
            rsMAR(iTabel).Index = FLIndexCaption(iTabel, iIndex)
            If sZoals = "=" Then
                rsMAR(iTabel).Seek(sZoek)
            ElseIf sZoals = ">=" Then
                rsMAR(iTabel).Seek(sZoek, ADODB.SeekEnum.adSeekAfterEQ)
            Else
                MsgBox(sZoals & " nog niet beschikbaar")
            End If
            If rsMAR(iTabel).EOF Then
            Else
                adoGet = True
            End If
        End If

    End Function
    Function adoBibTekst(ByRef adoField As ADODB.Field, ByRef TBS As String) As String

        Err.Clear()
        On Error Resume Next
        If adoField.Value = "" Then
            adoBibTekst = ""
        Else
            adoBibTekst = Mid(adoField.Value, InStr(adoField.Value, TBS) + 7, InStr(InStr(adoField.Value, TBS) + 7, adoField.Value, "#") - (InStr(adoField.Value, TBS) + 7))
        End If
        If Err.Number Then adoBibTekst = ""

    End Function
End Module
