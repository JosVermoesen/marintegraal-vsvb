<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BSBook
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
        Me.tbTOT = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.rbCreditnota = New System.Windows.Forms.RadioButton()
        Me.rbFactuur = New System.Windows.Forms.RadioButton()
        Me.ButtonGenerateReport = New System.Windows.Forms.Button()
        Me.TekstVan = New System.Windows.Forms.Label()
        Me._Label1_1 = New System.Windows.Forms.Label()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me._Label1_3 = New System.Windows.Forms.Label()
        Me.DateTimePickerProcessingDate = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'chkDetailJournaal
        '
        Me.chkDetailJournaal.BackColor = System.Drawing.SystemColors.Control
        Me.chkDetailJournaal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDetailJournaal.Location = New System.Drawing.Point(9, 86)
        Me.chkDetailJournaal.Name = "chkDetailJournaal"
        Me.chkDetailJournaal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDetailJournaal.Size = New System.Drawing.Size(119, 15)
        Me.chkDetailJournaal.TabIndex = 8
        Me.chkDetailJournaal.Text = "Detail Journaal"
        Me.chkDetailJournaal.UseVisualStyleBackColor = False
        '
        'tbTOT
        '
        Me.tbTOT.AcceptsReturn = True
        Me.tbTOT.BackColor = System.Drawing.Color.White
        Me.tbTOT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbTOT.ForeColor = System.Drawing.Color.Black
        Me.tbTOT.Location = New System.Drawing.Point(213, 66)
        Me.tbTOT.MaxLength = 0
        Me.tbTOT.Name = "tbTOT"
        Me.tbTOT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbTOT.Size = New System.Drawing.Size(57, 20)
        Me.tbTOT.TabIndex = 7
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(287, 78)
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
        Me.rbCreditnota.Location = New System.Drawing.Point(77, 43)
        Me.rbCreditnota.Name = "rbCreditnota"
        Me.rbCreditnota.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbCreditnota.Size = New System.Drawing.Size(83, 16)
        Me.rbCreditnota.TabIndex = 5
        Me.rbCreditnota.Text = "Creditnota's"
        Me.rbCreditnota.UseVisualStyleBackColor = False
        '
        'rbFactuur
        '
        Me.rbFactuur.BackColor = System.Drawing.SystemColors.Control
        Me.rbFactuur.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbFactuur.Location = New System.Drawing.Point(9, 42)
        Me.rbFactuur.Name = "rbFactuur"
        Me.rbFactuur.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rbFactuur.Size = New System.Drawing.Size(62, 16)
        Me.rbFactuur.TabIndex = 4
        Me.rbFactuur.Text = "Facturen"
        Me.rbFactuur.UseVisualStyleBackColor = False
        '
        'ButtonGenerateReport
        '
        Me.ButtonGenerateReport.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonGenerateReport.Enabled = False
        Me.ButtonGenerateReport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonGenerateReport.Location = New System.Drawing.Point(287, 9)
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
        Me.TekstVan.Location = New System.Drawing.Point(212, 43)
        Me.TekstVan.Name = "TekstVan"
        Me.TekstVan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TekstVan.Size = New System.Drawing.Size(57, 20)
        Me.TekstVan.TabIndex = 26
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(9, 16)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(77, 13)
        Me._Label1_1.TabIndex = 0
        Me._Label1_1.Text = "Datu&m"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(176, 45)
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
        Me._Label1_3.Location = New System.Drawing.Point(177, 68)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(32, 13)
        Me._Label1_3.TabIndex = 6
        Me._Label1_3.Text = "Tot"
        '
        'DateTimePickerProcessingDate
        '
        Me.DateTimePickerProcessingDate.Location = New System.Drawing.Point(92, 12)
        Me.DateTimePickerProcessingDate.MaxDate = New Date(2061, 12, 31, 0, 0, 0, 0)
        Me.DateTimePickerProcessingDate.MinDate = New Date(1985, 12, 1, 0, 0, 0, 0)
        Me.DateTimePickerProcessingDate.Name = "DateTimePickerProcessingDate"
        Me.DateTimePickerProcessingDate.Size = New System.Drawing.Size(176, 20)
        Me.DateTimePickerProcessingDate.TabIndex = 1
        '
        'BSBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(383, 115)
        Me.Controls.Add(Me.DateTimePickerProcessingDate)
        Me.Controls.Add(Me.chkDetailJournaal)
        Me.Controls.Add(Me.tbTOT)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.rbCreditnota)
        Me.Controls.Add(Me.rbFactuur)
        Me.Controls.Add(Me.ButtonGenerateReport)
        Me.Controls.Add(Me.TekstVan)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me._Label1_2)
        Me.Controls.Add(Me._Label1_3)
        Me.Name = "BSBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAVBoek"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents chkDetailJournaal As CheckBox
    Public WithEvents tbTOT As TextBox
    Public WithEvents btnClose As Button
    Public WithEvents rbCreditnota As RadioButton
    Public WithEvents rbFactuur As RadioButton
    Public WithEvents ButtonGenerateReport As Button
    Public WithEvents TekstVan As Label
    Public WithEvents _Label1_1 As Label
    Public WithEvents _Label1_2 As Label
    Public WithEvents _Label1_3 As Label
    Friend WithEvents DateTimePickerProcessingDate As DateTimePicker
End Class
