<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AVBoek
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.chkDetailJournaal = New System.Windows.Forms.CheckBox()
        Me._TekstLijn_0 = New System.Windows.Forms.TextBox()
        Me.tbTOT = New System.Windows.Forms.TextBox()
        Me.tbDatumDrukken = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.rbCreditnota = New System.Windows.Forms.RadioButton()
        Me.rbFactuur = New System.Windows.Forms.RadioButton()
        Me.ButtonGenerateReport = New System.Windows.Forms.Button()
        Me.TekstVan = New System.Windows.Forms.Label()
        Me._Label1_0 = New System.Windows.Forms.Label()
        Me._Label1_1 = New System.Windows.Forms.Label()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me._Label1_3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'chkDetailJournaal
        '
        Me.chkDetailJournaal.BackColor = System.Drawing.SystemColors.Control
        Me.chkDetailJournaal.Checked = True
        Me.chkDetailJournaal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDetailJournaal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDetailJournaal.Location = New System.Drawing.Point(8, 104)
        Me.chkDetailJournaal.Name = "chkDetailJournaal"
        Me.chkDetailJournaal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDetailJournaal.Size = New System.Drawing.Size(119, 15)
        Me.chkDetailJournaal.TabIndex = 8
        Me.chkDetailJournaal.Text = "Detail Journaal"
        Me.chkDetailJournaal.UseVisualStyleBackColor = False
        '
        '_TekstLijn_0
        '
        Me._TekstLijn_0.AcceptsReturn = True
        Me._TekstLijn_0.BackColor = System.Drawing.Color.White
        Me._TekstLijn_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._TekstLijn_0.ForeColor = System.Drawing.Color.Black
        Me._TekstLijn_0.Location = New System.Drawing.Point(9, 38)
        Me._TekstLijn_0.MaxLength = 0
        Me._TekstLijn_0.Name = "_TekstLijn_0"
        Me._TekstLijn_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TekstLijn_0.Size = New System.Drawing.Size(276, 20)
        Me._TekstLijn_0.TabIndex = 3
        '
        'tbTOT
        '
        Me.tbTOT.AcceptsReturn = True
        Me.tbTOT.BackColor = System.Drawing.Color.White
        Me.tbTOT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbTOT.ForeColor = System.Drawing.Color.Black
        Me.tbTOT.Location = New System.Drawing.Point(228, 98)
        Me.tbTOT.MaxLength = 0
        Me.tbTOT.Name = "tbTOT"
        Me.tbTOT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbTOT.Size = New System.Drawing.Size(57, 20)
        Me.tbTOT.TabIndex = 7
        '
        'tbDatumDrukken
        '
        Me.tbDatumDrukken.AcceptsReturn = True
        Me.tbDatumDrukken.BackColor = System.Drawing.Color.White
        Me.tbDatumDrukken.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbDatumDrukken.ForeColor = System.Drawing.Color.Black
        Me.tbDatumDrukken.Location = New System.Drawing.Point(196, 12)
        Me.tbDatumDrukken.MaxLength = 0
        Me.tbDatumDrukken.Name = "tbDatumDrukken"
        Me.tbDatumDrukken.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbDatumDrukken.Size = New System.Drawing.Size(88, 20)
        Me.tbDatumDrukken.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(296, 95)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 21
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Sluiten"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'rbCreditnota
        '
        Me.rbCreditnota.BackColor = System.Drawing.SystemColors.Control
        Me.rbCreditnota.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbCreditnota.Location = New System.Drawing.Point(92, 68)
        Me.rbCreditnota.Name = "rbCreditnota"
        Me.rbCreditnota.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbCreditnota.Size = New System.Drawing.Size(93, 16)
        Me.rbCreditnota.TabIndex = 5
        Me.rbCreditnota.Text = "Creditnota's"
        Me.rbCreditnota.UseVisualStyleBackColor = False
        '
        'rbFactuur
        '
        Me.rbFactuur.BackColor = System.Drawing.SystemColors.Control
        Me.rbFactuur.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbFactuur.Location = New System.Drawing.Point(8, 68)
        Me.rbFactuur.Name = "rbFactuur"
        Me.rbFactuur.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbFactuur.Size = New System.Drawing.Size(77, 16)
        Me.rbFactuur.TabIndex = 4
        Me.rbFactuur.Text = "Facturen"
        Me.rbFactuur.UseVisualStyleBackColor = False
        '
        'ButtonGenerateReport
        '
        Me.ButtonGenerateReport.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonGenerateReport.Enabled = False
        Me.ButtonGenerateReport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonGenerateReport.Location = New System.Drawing.Point(296, 9)
        Me.ButtonGenerateReport.Name = "ButtonGenerateReport"
        Me.ButtonGenerateReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonGenerateReport.Size = New System.Drawing.Size(80, 49)
        Me.ButtonGenerateReport.TabIndex = 9
        Me.ButtonGenerateReport.Text = "Genereer Rapport"
        Me.ButtonGenerateReport.UseVisualStyleBackColor = False
        '
        'TekstVan
        '
        Me.TekstVan.BackColor = System.Drawing.SystemColors.Control
        Me.TekstVan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TekstVan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TekstVan.Location = New System.Drawing.Point(227, 75)
        Me.TekstVan.Name = "TekstVan"
        Me.TekstVan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TekstVan.Size = New System.Drawing.Size(57, 20)
        Me.TekstVan.TabIndex = 26
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(12, 16)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(58, 13)
        Me._Label1_0.TabIndex = 2
        Me._Label1_0.Text = "Sub&Titel"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(106, 16)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(89, 13)
        Me._Label1_1.TabIndex = 0
        Me._Label1_1.Text = "D&atum Drukken"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(191, 77)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(32, 13)
        Me._Label1_2.TabIndex = 24
        Me._Label1_2.Text = "Van"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(192, 100)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(32, 13)
        Me._Label1_3.TabIndex = 6
        Me._Label1_3.Text = "Tot"
        '
        'AVBoek
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(388, 128)
        Me.Controls.Add(Me.chkDetailJournaal)
        Me.Controls.Add(Me._TekstLijn_0)
        Me.Controls.Add(Me.tbTOT)
        Me.Controls.Add(Me.tbDatumDrukken)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.rbCreditnota)
        Me.Controls.Add(Me.rbFactuur)
        Me.Controls.Add(Me.ButtonGenerateReport)
        Me.Controls.Add(Me.TekstVan)
        Me.Controls.Add(Me._Label1_0)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_3)
        Me.Name = "AVBoek"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAVBoek"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents chkDetailJournaal As CheckBox
    Public WithEvents _TekstLijn_0 As TextBox
    Public WithEvents tbTOT As TextBox
    Public WithEvents tbDatumDrukken As TextBox
    Public WithEvents btnClose As Button
    Public WithEvents rbCreditnota As RadioButton
    Public WithEvents rbFactuur As RadioButton
    Public WithEvents ButtonGenerateReport As Button
    Public WithEvents TekstVan As Label
    Public WithEvents _Label1_0 As Label
    Public WithEvents _Label1_1 As Label
    Public WithEvents _Label1_2 As Label
    Public WithEvents _Label1_3 As Label
End Class
