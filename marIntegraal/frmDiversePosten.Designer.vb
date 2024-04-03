<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiversePosten
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SoortBoeking = New System.Windows.Forms.ComboBox()
        Me.VolgendeLijn = New System.Windows.Forms.Button()
        Me.Omschrijving = New System.Windows.Forms.TextBox()
        Me.dKeuze = New System.Windows.Forms.RadioButton()
        Me.cKeuze = New System.Windows.Forms.RadioButton()
        Me.TRvlag = New System.Windows.Forms.CheckBox()
        Me.RekeningNummer = New System.Windows.Forms.TextBox()
        Me.Tegenrekening = New System.Windows.Forms.TextBox()
        Me.Sluiten = New System.Windows.Forms.Button()
        Me.Schoon = New System.Windows.Forms.Button()
        Me.Bedrag = New System.Windows.Forms.TextBox()
        Me.Afsluiten = New System.Windows.Forms.Button()
        Me.JournaalPost = New System.Windows.Forms.ListBox()
        Me.NaamTegenRekening = New System.Windows.Forms.Label()
        Me.NaamRekening = New System.Windows.Forms.Label()
        Me.boekdatumLabel = New System.Windows.Forms.Label()
        Me._Label1_4 = New System.Windows.Forms.Label()
        Me._Label1_3 = New System.Windows.Forms.Label()
        Me.omschrijvingLabel = New System.Windows.Forms.Label()
        Me._Label1_5 = New System.Windows.Forms.Label()
        Me._Label1_8 = New System.Windows.Forms.Label()
        Me._Label1_7 = New System.Windows.Forms.Label()
        Me._Label1_6 = New System.Windows.Forms.Label()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me.Saldo = New System.Windows.Forms.Label()
        Me.DatumVerwerking = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SoortBoeking
        '
        Me.SoortBoeking.BackColor = System.Drawing.SystemColors.Window
        Me.SoortBoeking.Cursor = System.Windows.Forms.Cursors.Default
        Me.SoortBoeking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SoortBoeking.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SoortBoeking.Location = New System.Drawing.Point(16, 20)
        Me.SoortBoeking.Name = "SoortBoeking"
        Me.SoortBoeking.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SoortBoeking.Size = New System.Drawing.Size(174, 21)
        Me.SoortBoeking.TabIndex = 0
        '
        'VolgendeLijn
        '
        Me.VolgendeLijn.BackColor = System.Drawing.SystemColors.Control
        Me.VolgendeLijn.Cursor = System.Windows.Forms.Cursors.Default
        Me.VolgendeLijn.Enabled = False
        Me.VolgendeLijn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.VolgendeLijn.Location = New System.Drawing.Point(322, 77)
        Me.VolgendeLijn.Name = "VolgendeLijn"
        Me.VolgendeLijn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.VolgendeLijn.Size = New System.Drawing.Size(73, 21)
        Me.VolgendeLijn.TabIndex = 37
        Me.VolgendeLijn.TabStop = False
        Me.VolgendeLijn.Text = "Bij&voegen"
        Me.VolgendeLijn.UseVisualStyleBackColor = False
        '
        'Omschrijving
        '
        Me.Omschrijving.AcceptsReturn = True
        Me.Omschrijving.BackColor = System.Drawing.Color.White
        Me.Omschrijving.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Omschrijving.ForeColor = System.Drawing.Color.Black
        Me.Omschrijving.Location = New System.Drawing.Point(196, 20)
        Me.Omschrijving.MaxLength = 0
        Me.Omschrijving.Name = "Omschrijving"
        Me.Omschrijving.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Omschrijving.Size = New System.Drawing.Size(209, 20)
        Me.Omschrijving.TabIndex = 2
        '
        'dKeuze
        '
        Me.dKeuze.BackColor = System.Drawing.SystemColors.Control
        Me.dKeuze.Checked = True
        Me.dKeuze.Cursor = System.Windows.Forms.Cursors.Default
        Me.dKeuze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dKeuze.Location = New System.Drawing.Point(6, 19)
        Me.dKeuze.Name = "dKeuze"
        Me.dKeuze.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dKeuze.Size = New System.Drawing.Size(88, 16)
        Me.dKeuze.TabIndex = 4
        Me.dKeuze.TabStop = True
        Me.dKeuze.Text = "&Debiteren (+)"
        Me.dKeuze.UseVisualStyleBackColor = False
        '
        'cKeuze
        '
        Me.cKeuze.BackColor = System.Drawing.SystemColors.Control
        Me.cKeuze.Cursor = System.Windows.Forms.Cursors.Default
        Me.cKeuze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cKeuze.Location = New System.Drawing.Point(6, 36)
        Me.cKeuze.Name = "cKeuze"
        Me.cKeuze.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cKeuze.Size = New System.Drawing.Size(85, 16)
        Me.cKeuze.TabIndex = 5
        Me.cKeuze.Text = "&Crediteren (-)"
        Me.cKeuze.UseVisualStyleBackColor = False
        '
        'TRvlag
        '
        Me.TRvlag.BackColor = System.Drawing.SystemColors.Control
        Me.TRvlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.TRvlag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TRvlag.Location = New System.Drawing.Point(6, 57)
        Me.TRvlag.Name = "TRvlag"
        Me.TRvlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TRvlag.Size = New System.Drawing.Size(99, 21)
        Me.TRvlag.TabIndex = 6
        Me.TRvlag.TabStop = False
        Me.TRvlag.Text = "&Tegenrekening (/)"
        Me.TRvlag.UseVisualStyleBackColor = False
        '
        'RekeningNummer
        '
        Me.RekeningNummer.AcceptsReturn = True
        Me.RekeningNummer.BackColor = System.Drawing.Color.White
        Me.RekeningNummer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RekeningNummer.ForeColor = System.Drawing.Color.Black
        Me.RekeningNummer.Location = New System.Drawing.Point(12, 133)
        Me.RekeningNummer.MaxLength = 0
        Me.RekeningNummer.Name = "RekeningNummer"
        Me.RekeningNummer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RekeningNummer.Size = New System.Drawing.Size(80, 20)
        Me.RekeningNummer.TabIndex = 8
        '
        'Tegenrekening
        '
        Me.Tegenrekening.AcceptsReturn = True
        Me.Tegenrekening.BackColor = System.Drawing.Color.White
        Me.Tegenrekening.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Tegenrekening.ForeColor = System.Drawing.Color.Black
        Me.Tegenrekening.Location = New System.Drawing.Point(12, 159)
        Me.Tegenrekening.MaxLength = 0
        Me.Tegenrekening.Name = "Tegenrekening"
        Me.Tegenrekening.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Tegenrekening.Size = New System.Drawing.Size(80, 20)
        Me.Tegenrekening.TabIndex = 9
        Me.Tegenrekening.Visible = False
        '
        'Sluiten
        '
        Me.Sluiten.BackColor = System.Drawing.SystemColors.Control
        Me.Sluiten.Cursor = System.Windows.Forms.Cursors.Default
        Me.Sluiten.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Sluiten.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Sluiten.Location = New System.Drawing.Point(322, 158)
        Me.Sluiten.Name = "Sluiten"
        Me.Sluiten.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Sluiten.Size = New System.Drawing.Size(73, 21)
        Me.Sluiten.TabIndex = 40
        Me.Sluiten.TabStop = False
        Me.Sluiten.Text = "Sluiten"
        Me.Sluiten.UseVisualStyleBackColor = False
        '
        'Schoon
        '
        Me.Schoon.BackColor = System.Drawing.SystemColors.Control
        Me.Schoon.Cursor = System.Windows.Forms.Cursors.Default
        Me.Schoon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Schoon.Location = New System.Drawing.Point(322, 131)
        Me.Schoon.Name = "Schoon"
        Me.Schoon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Schoon.Size = New System.Drawing.Size(73, 21)
        Me.Schoon.TabIndex = 42
        Me.Schoon.TabStop = False
        Me.Schoon.Text = "Schoo&n"
        Me.Schoon.UseVisualStyleBackColor = False
        '
        'Bedrag
        '
        Me.Bedrag.AcceptsReturn = True
        Me.Bedrag.BackColor = System.Drawing.Color.White
        Me.Bedrag.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Bedrag.ForeColor = System.Drawing.Color.Black
        Me.Bedrag.Location = New System.Drawing.Point(102, 100)
        Me.Bedrag.MaxLength = 0
        Me.Bedrag.Name = "Bedrag"
        Me.Bedrag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Bedrag.Size = New System.Drawing.Size(88, 20)
        Me.Bedrag.TabIndex = 11
        '
        'Afsluiten
        '
        Me.Afsluiten.BackColor = System.Drawing.SystemColors.Control
        Me.Afsluiten.Cursor = System.Windows.Forms.Cursors.Default
        Me.Afsluiten.Enabled = False
        Me.Afsluiten.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Afsluiten.Location = New System.Drawing.Point(322, 104)
        Me.Afsluiten.Name = "Afsluiten"
        Me.Afsluiten.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Afsluiten.Size = New System.Drawing.Size(73, 21)
        Me.Afsluiten.TabIndex = 38
        Me.Afsluiten.Text = "Boeken"
        Me.Afsluiten.UseVisualStyleBackColor = False
        '
        'JournaalPost
        '
        Me.JournaalPost.BackColor = System.Drawing.Color.White
        Me.JournaalPost.Cursor = System.Windows.Forms.Cursors.Default
        Me.JournaalPost.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JournaalPost.ForeColor = System.Drawing.Color.Black
        Me.JournaalPost.ItemHeight = 15
        Me.JournaalPost.Location = New System.Drawing.Point(12, 197)
        Me.JournaalPost.Name = "JournaalPost"
        Me.JournaalPost.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.JournaalPost.Size = New System.Drawing.Size(497, 229)
        Me.JournaalPost.TabIndex = 41
        '
        'NaamTegenRekening
        '
        Me.NaamTegenRekening.BackColor = System.Drawing.SystemColors.Control
        Me.NaamTegenRekening.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.NaamTegenRekening.Cursor = System.Windows.Forms.Cursors.Default
        Me.NaamTegenRekening.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NaamTegenRekening.Location = New System.Drawing.Point(96, 157)
        Me.NaamTegenRekening.Name = "NaamTegenRekening"
        Me.NaamTegenRekening.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NaamTegenRekening.Size = New System.Drawing.Size(217, 21)
        Me.NaamTegenRekening.TabIndex = 49
        Me.NaamTegenRekening.Visible = False
        '
        'NaamRekening
        '
        Me.NaamRekening.BackColor = System.Drawing.SystemColors.Control
        Me.NaamRekening.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.NaamRekening.Cursor = System.Windows.Forms.Cursors.Default
        Me.NaamRekening.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NaamRekening.Location = New System.Drawing.Point(96, 133)
        Me.NaamRekening.Name = "NaamRekening"
        Me.NaamRekening.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NaamRekening.Size = New System.Drawing.Size(217, 21)
        Me.NaamRekening.TabIndex = 50
        '
        'boekdatumLabel
        '
        Me.boekdatumLabel.BackColor = System.Drawing.SystemColors.Control
        Me.boekdatumLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.boekdatumLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.boekdatumLabel.Location = New System.Drawing.Point(20, 67)
        Me.boekdatumLabel.Name = "boekdatumLabel"
        Me.boekdatumLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.boekdatumLabel.Size = New System.Drawing.Size(72, 16)
        Me.boekdatumLabel.TabIndex = 99
        Me.boekdatumLabel.Text = "Datu&m"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(145, 81)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(45, 16)
        Me._Label1_4.TabIndex = 10
        Me._Label1_4.Text = "&Bedrag"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(12, 116)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(64, 14)
        Me._Label1_3.TabIndex = 7
        Me._Label1_3.Text = "&Rekening"
        '
        'omschrijvingLabel
        '
        Me.omschrijvingLabel.BackColor = System.Drawing.SystemColors.Control
        Me.omschrijvingLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.omschrijvingLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.omschrijvingLabel.Location = New System.Drawing.Point(202, 4)
        Me.omschrijvingLabel.Name = "omschrijvingLabel"
        Me.omschrijvingLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.omschrijvingLabel.Size = New System.Drawing.Size(112, 16)
        Me.omschrijvingLabel.TabIndex = 1
        Me.omschrijvingLabel.Text = "&Omschrijving"
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(426, 24)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(84, 33)
        Me._Label1_5.TabIndex = 44
        Me._Label1_5.Text = "Saldo nog toe te wijzen"
        Me._Label1_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(436, 182)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(56, 16)
        Me._Label1_8.TabIndex = 48
        Me._Label1_8.Text = "TegenR."
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(382, 182)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(48, 16)
        Me._Label1_7.TabIndex = 47
        Me._Label1_7.Text = "Bedrag"
        Me._Label1_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(93, 182)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(80, 16)
        Me._Label1_6.TabIndex = 46
        Me._Label1_6.Text = "Naam"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(17, 182)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(56, 16)
        Me._Label1_2.TabIndex = 45
        Me._Label1_2.Text = "Nummer"
        '
        'Saldo
        '
        Me.Saldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Saldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Saldo.Cursor = System.Windows.Forms.Cursors.Default
        Me.Saldo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Saldo.Location = New System.Drawing.Point(426, 60)
        Me.Saldo.Name = "Saldo"
        Me.Saldo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Saldo.Size = New System.Drawing.Size(83, 21)
        Me.Saldo.TabIndex = 43
        Me.Saldo.Text = "0"
        Me.Saldo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DatumVerwerking
        '
        Me.DatumVerwerking.Location = New System.Drawing.Point(16, 47)
        Me.DatumVerwerking.Name = "DatumVerwerking"
        Me.DatumVerwerking.Size = New System.Drawing.Size(176, 20)
        Me.DatumVerwerking.TabIndex = 100
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TRvlag)
        Me.GroupBox1.Controls.Add(Me.cKeuze)
        Me.GroupBox1.Controls.Add(Me.dKeuze)
        Me.GroupBox1.Location = New System.Drawing.Point(196, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(111, 78)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "D/C Keuze"
        '
        'frmDiversePosten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Sluiten
        Me.ClientSize = New System.Drawing.Size(519, 434)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DatumVerwerking)
        Me.Controls.Add(Me.SoortBoeking)
        Me.Controls.Add(Me.VolgendeLijn)
        Me.Controls.Add(Me.Omschrijving)
        Me.Controls.Add(Me.RekeningNummer)
        Me.Controls.Add(Me.Tegenrekening)
        Me.Controls.Add(Me.Sluiten)
        Me.Controls.Add(Me.Schoon)
        Me.Controls.Add(Me.Bedrag)
        Me.Controls.Add(Me.Afsluiten)
        Me.Controls.Add(Me.JournaalPost)
        Me.Controls.Add(Me.NaamTegenRekening)
        Me.Controls.Add(Me.NaamRekening)
        Me.Controls.Add(Me.boekdatumLabel)
        Me.Controls.Add(Me._Label1_4)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me.omschrijvingLabel)
        Me.Controls.Add(Me._Label1_5)
        Me.Controls.Add(Me._Label1_8)
        Me.Controls.Add(Me._Label1_7)
        Me.Controls.Add(Me._Label1_6)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me.Saldo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmDiversePosten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ctrl+Shift+F5 Diverse Posten"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents SoortBoeking As ComboBox
    Public WithEvents VolgendeLijn As Button
    Public WithEvents Omschrijving As TextBox
    Public WithEvents dKeuze As RadioButton
    Public WithEvents cKeuze As RadioButton
    Public WithEvents TRvlag As CheckBox
    Public WithEvents RekeningNummer As TextBox
    Public WithEvents Tegenrekening As TextBox
    Public WithEvents Sluiten As Button
    Public WithEvents Schoon As Button
    Public WithEvents Bedrag As TextBox
    Public WithEvents Afsluiten As Button
    Public WithEvents JournaalPost As ListBox
    Public WithEvents NaamTegenRekening As Label
    Public WithEvents NaamRekening As Label
    Public WithEvents boekdatumLabel As Label
    Public WithEvents _Label1_4 As Label
    Public WithEvents _Label1_3 As Label
    Public WithEvents omschrijvingLabel As Label
    Public WithEvents _Label1_5 As Label
    Public WithEvents _Label1_8 As Label
    Public WithEvents _Label1_7 As Label
    Public WithEvents _Label1_6 As Label
    Public WithEvents _Label1_2 As Label
    Public WithEvents Saldo As Label
    Friend WithEvents DatumVerwerking As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
End Class
