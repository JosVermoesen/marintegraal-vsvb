Option Strict Off
Option Explicit On

Module ModLibs

    Public BFKlanten As New frmBasisFiche
    Public BFLeveranciers As New frmBasisFiche
    Public BFRekeningen As New frmBasisFiche
    'Public BJPERDAT As New frmBJPERDAT

    'Mijn dokumenten, ApplicatieData
    Public Const CSIDL_PERSONAL As Integer = &H5
    Public Const CSIDL_APPDATA As Integer = &H1A
    Public Const CSIDL_PROGRAM_FILES As Integer = &H26

    Public Const TABLE_STR As String = "Tabel"
    Public Const ATTACHED_STR As String = "Verbonden"
    Public Const QUERY_STR As String = "Opzoeking"
    Public Const FIELD_STR As String = "Kolom"
    Public Const FIELDS_STR As String = "Kolommen"
    Public Const INDEX_STR As String = "Index"
    Public Const INDEXES_STR As String = "Indexen"
    Public Const PROPERTY_STR As String = "Eigenschap"
    Public Const PROPERTIES_STR As String = "Eigenschappen"

    Public Const adoJetProvider As String = "Provider=Microsoft.Jet.OLEDB.4.0;"

    Public gnodDBNode As System.Windows.Forms.TreeNode 'current database node in treeview
    Public gnodDBNode2 As System.Windows.Forms.TreeNode 'backup of current database node i

    'marNT constanten
    Public Const AFl As Short = 9
    Public Const FlAllerlei As Short = 0
    Public Const FlKlant As Short = 1
    Public Const FlLeverancier As Short = 2
    Public Const FlRekening As Short = 3
    Public Const FlProdukt As Short = 4
    Public Const FlPolis As Short = 5
    Public Const Fldokument As Short = 6
    Public Const FlJournaal As Short = 7
    Public Const FlDummy As Short = 8
    Public Const FlTeller As Short = 9
    Public Const FlAsLog As Short = 10

    Public Const TekstPeriode As Short = 0
    Public Const TekstBoekjaar As Short = 1
    Public Const SleutelPeriode As Short = 2
    Public Const SleutelBoekjaar As Short = 3
    Public Const SISO As String = "001*002*002*003*004*005*006*007*008*009*010*011*030*032*038*046*053*054*055*060*061*063*064*091*600*"
    Public Const maxTeleBib As Short = 150
    Public Const maxIndex As Short = 5
    Public Const maxPLUS As Short = 6
    Public Const Lees As Boolean = True
    Public Const LeesLock As Boolean = False

    Public Const MaskerEURX As String = "######0.0000"
    Public Const MaskerEURBH As String = "########0.00"

    Public Const MaskerBEF As String = "##########"
    Public Const MaskerEUR As String = "######0.00"

    Public Const Euro As Double = 40.3399
    Public Const BelgischeFrank As Short = 1

    <VBFixedString(16)> Public A As String
    <VBFixedString(4)> Public aa As String
    <VBFixedString(30)> Public AAA As String

    Public MaskerSy(8) As String
    Public Masker2002 As String 'VB6.FixedLengthString(10)
    Public vsfPro As Boolean

    Public SysVar(6) As String
    Public FileNr(AFl) As Short
    Public TLBRecord(AFl) As String
    Public KeyBuf(AFl) As String
    Public Bestand(AFl) As String
    Public KeyIndex(AFl) As Short
    Public InsertFlag(AFl) As Short
    Public FlAantalIndexen(10) As Short
    Public FlIndexIs(AFl, 10) As String
    Public FlIndexLen(AFl, 10) As Short
    Public FLIndexCaption(AFl, 10) As String
    Public ListIDX(5, 10) As String
    Public FVT(AFl, 10) As String
    Public aIndex As Integer 
    Public DagenInMaand(12) As Short
    'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    Public MaandTekst(12) As String '*9
    Public SetUpRecNum(25) As Short

    Public PrinterStuurkodes(2) As Short
    Public BladLengte(2) As Short
    Public PrinterINI(2) As String
    Public RapportVeld(23) As String
    Public RapportTab(23) As Short

    'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    Public TeleBibCode(maxTeleBib) As String '*10
    'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    Public TeleBibTekst(maxTeleBib) As String '*35
    'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    Public TeleBibType(maxTeleBib) As String '*1
    Public TeleBibLengte(maxTeleBib) As Short
    Public TeleBibPos(maxTeleBib) As Short
    Public TeleBibLast As Short

    Public FL99 As Short
    Public Fl99Record As String
    Public PrinterCurrentY As Short
    Public PaginaTeller As Short

    <VBFixedString(128)> Public Lijntje As String 'New VB6.FixedLengthString(128)

    Public marVersion As String
    Public LogPrint As String
    Public blLogging As Boolean

    Public dKtrlCumul As Decimal
    Public dKtrlBEF As Decimal
    Public dKtrlEUR As Decimal

    Public bModus As Short
    Public TelTot As Short

    Public PeriodeVanTot As String ' New VB6.FixedLengthString(16)
    Public BoekjaarVanTot As String 'New VB6.FixedLengthString(16)
    Public AktiefBoekjaar As Short
    Public Rdt As String 'New VB6.FixedLengthString(10)
    Public BtwBouw As Boolean
    Public DirecteVerkoopString As String

    Public BedrijfsLokatie As String
    Public NetDataLokatie As String
    Public ProgrammaLokatie As String
    Public Lokatie As String
    Public AssurnetLokatie As String
    Public FolderMijndokumenten As String

    Public ProducentNummer As String 'New VB6.FixedLengthString(8)
    Public Eigenaar As String 'New VB6.FixedLengthString(8)
    Public Fl As Short
    Public SharedFl As Short
    Public SharedScanFl As Short
    Public Ktrl As Short
    Public KtrlLong As Integer
    Public sharedIndex As Integer
    Public AktieveFiche As Short

    Public blMilieu As Boolean
    Public MilieuGridText As String
    Public GridText As String
    Public GridTextKwijting As String
    Public GridTextIs As String
    Public GridTextPolis As Object
    Public GridText9 As String
    Public GridRows As Short
    Public XLogKey As String

    Public XLogKassa As String

    Public dKtrCumul As Double
    Public SetupVelden As Short
    Public BedrijfKeuze As String
    Public dMuntL As Double
    Public Msg As String
    Public KtrlBox As Short
    Public SQLBevel As String
    Public DoEventsStatus As Short
    Public VsoftLog As Short
    Public ProgrammaVersie As String
    Public LockHold As Short

    'Public KBTable As DAO.Recordset
    Public ntDB As DAO.Database
    Public ntRS(9) As DAO.Recordset
    Public NTRuimte As DAO.Workspace


    Public adKBDB As ADODB.Connection
    Public adKBTable As ADODB.Recordset

    Public adntDB As ADODB.Connection
    Public adntDBSQLS As ADODB.Connection

    Public adTBIB As ADODB.Connection
    Public rsWaarden As ADODB.Recordset
    Public rsJournaal As ADODB.Recordset
    Public rsMAR(9) As ADODB.Recordset
    Public sqlMsg(9) As String
    Public jetConnect As String
    Public SQLConnect As String

    Public XDoEvents As Short
    Public bstNaam(9) As String
    Public AddNewStatus(9) As Short
    'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
    Public vBC(9, 200) As String '*4
    Public BAModus As Short

    Public TestEuroModus As Boolean
    Public bhEuro As Boolean
    Public XisEuroWisBEF As Boolean

    Public TimerTijd As Date
    Public RetVal As Object
    Public Figuur1 As Object
    Public Figuur2 As Object

    Public LijstPrinterNr As Short
    Public dokumentPrinterNr As Short
    Public KassaPrinterNr As Short

    Public FormReference As frmBasisFiche
    'UPGRADE_WARNING: Lower bound of array BasisB was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    'UPGRADE_WARNING: Arrays can't be declared with New. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC9D3AE5-6B95-4B43-91C7-28276302A5E8"'
    Public BasisB(3) As frmBasisFiche
    Public JumpVenster As Object

    Public fs As Scripting.FileSystemObject

    Public KasTicketTotaal As Decimal
    Public KasTotaal As Decimal
    Public KasBetalingBEF As Decimal
    Public KasBetalingEUR As Decimal
    Public KasTerugEUR As Decimal

    Public KasTotaalBEF As Decimal
    Public KasTotaalEUR As Decimal

    Public DecimalKTRL As Boolean

    'marIntegraal.NET
    'Public xpW As Word.dokument
    Public usrLicentieInfo As String
    Public JournaalLocked As Boolean
    Public usrMailAdres As String
    Public usrPW As String

    Public pdfVsoftVanaf As Double
    Public pdfVsoftTot As Double
    Public pdfadresXpos As Double
    Public pdfadresYpos As Double
    Public pdfadresXpos2 As Double
    Public pdfadresYpos2 As Double
End Module