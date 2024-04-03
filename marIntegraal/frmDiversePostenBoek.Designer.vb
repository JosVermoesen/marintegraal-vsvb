<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiversePostenBoek
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
        Me.AutoPageBreak = New IDEALSoftware.VpeStandard.VpeControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.vantotTextBox = New System.Windows.Forms.TextBox()
        Me.subtitelLabel = New System.Windows.Forms.Label()
        Me.datumdrukkenLabel = New System.Windows.Forms.Label()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.aantalrecordsLabel = New System.Windows.Forms.Label()
        Me.afdrukButton = New System.Windows.Forms.Button()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.aantalrecordsTextBox = New System.Windows.Forms.TextBox()
        Me.mailTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'AutoPageBreak
        '
        Me.AutoPageBreak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AutoPageBreak.DocFileReadOnly = false
        Me.AutoPageBreak.EnableHelpRouting = false
        Me.AutoPageBreak.EnablePrintSetupDialog = true
        Me.AutoPageBreak.ExternalWindow = true
        Me.AutoPageBreak.GridMode = IDEALSoftware.VpeStandard.GridMode.InForeground
        Me.AutoPageBreak.GridVisible = false
        Me.AutoPageBreak.Location = New System.Drawing.Point(13, 188)
        Me.AutoPageBreak.Name = "AutoPageBreak"
        Me.AutoPageBreak.PageFormat = IDEALSoftware.VpeStandard.PageFormat.A4
        Me.AutoPageBreak.PageHeight = 29.7R
        Me.AutoPageBreak.PageOrientation = IDEALSoftware.VpeStandard.PageOrientation.Portrait
        Me.AutoPageBreak.PageScroller = true
        Me.AutoPageBreak.PageScrollerTracking = true
        Me.AutoPageBreak.PageWidth = 21R
        Me.AutoPageBreak.PaperView = true
        Me.AutoPageBreak.PreviewCtrl = IDEALSoftware.VpeStandard.PreviewCtrl.JumpTop
        Me.AutoPageBreak.Rulers = true
        Me.AutoPageBreak.RulersMeasure = IDEALSoftware.VpeStandard.RulersMeasure.Centimeter
        Me.AutoPageBreak.Size = New System.Drawing.Size(96, 80)
        Me.AutoPageBreak.StatusBar = true
        Me.AutoPageBreak.StatusSegment = true
        Me.AutoPageBreak.SwapFileName = Nothing
        Me.AutoPageBreak.TabIndex = 6
        Me.AutoPageBreak.TabStop = false
        Me.AutoPageBreak.tbAbout = true
        Me.AutoPageBreak.tbClose = true
        Me.AutoPageBreak.tbGrid = false
        Me.AutoPageBreak.tbHelp = true
        Me.AutoPageBreak.tbMail = true
        Me.AutoPageBreak.tbNavigate = true
        Me.AutoPageBreak.tbOpen = true
        Me.AutoPageBreak.tbPrint = true
        Me.AutoPageBreak.tbSave = true
        Me.AutoPageBreak.tbScale = true
        Me.AutoPageBreak.Text = "Automatic Page Break Demo"
        Me.AutoPageBreak.ToolBar = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(115, 188)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.TabStop = false
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'vantotTextBox
        '
        Me.vantotTextBox.AcceptsReturn = true
        Me.vantotTextBox.BackColor = System.Drawing.Color.White
        Me.vantotTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.vantotTextBox.ForeColor = System.Drawing.Color.Black
        Me.vantotTextBox.Location = New System.Drawing.Point(11, 35)
        Me.vantotTextBox.MaxLength = 0
        Me.vantotTextBox.Name = "vantotTextBox"
        Me.vantotTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.vantotTextBox.Size = New System.Drawing.Size(270, 20)
        Me.vantotTextBox.TabIndex = 1
        '
        'subtitelLabel
        '
        Me.subtitelLabel.AutoSize = true
        Me.subtitelLabel.BackColor = System.Drawing.SystemColors.Control
        Me.subtitelLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.subtitelLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.subtitelLabel.Location = New System.Drawing.Point(8, 16)
        Me.subtitelLabel.Name = "subtitelLabel"
        Me.subtitelLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.subtitelLabel.Size = New System.Drawing.Size(84, 13)
        Me.subtitelLabel.TabIndex = 0
        Me.subtitelLabel.Text = "Selectie &Periode"
        '
        'datumdrukkenLabel
        '
        Me.datumdrukkenLabel.AutoSize = true
        Me.datumdrukkenLabel.BackColor = System.Drawing.SystemColors.Control
        Me.datumdrukkenLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.datumdrukkenLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.datumdrukkenLabel.Location = New System.Drawing.Point(10, 61)
        Me.datumdrukkenLabel.Name = "datumdrukkenLabel"
        Me.datumdrukkenLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.datumdrukkenLabel.Size = New System.Drawing.Size(82, 13)
        Me.datumdrukkenLabel.TabIndex = 2
        Me.datumdrukkenLabel.Text = "Datu&m Drukken"
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Location = New System.Drawing.Point(11, 77)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(176, 20)
        Me.DateTimePicker.TabIndex = 3
        '
        'aantalrecordsLabel
        '
        Me.aantalrecordsLabel.AutoSize = true
        Me.aantalrecordsLabel.Location = New System.Drawing.Point(295, 16)
        Me.aantalrecordsLabel.Name = "aantalrecordsLabel"
        Me.aantalrecordsLabel.Size = New System.Drawing.Size(68, 13)
        Me.aantalrecordsLabel.TabIndex = 102
        Me.aantalrecordsLabel.Text = "Aantal Lijnen"
        '
        'afdrukButton
        '
        Me.afdrukButton.Enabled = false
        Me.afdrukButton.Location = New System.Drawing.Point(207, 78)
        Me.afdrukButton.Name = "afdrukButton"
        Me.afdrukButton.Size = New System.Drawing.Size(75, 23)
        Me.afdrukButton.TabIndex = 4
        Me.afdrukButton.Text = "Af&drukken"
        Me.afdrukButton.UseVisualStyleBackColor = true
        '
        'closeButton
        '
        Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.closeButton.Location = New System.Drawing.Point(288, 78)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 104
        Me.closeButton.TabStop = false
        Me.closeButton.Text = "Sluiten"
        Me.closeButton.UseVisualStyleBackColor = true
        '
        'aantalrecordsTextBox
        '
        Me.aantalrecordsTextBox.Location = New System.Drawing.Point(288, 35)
        Me.aantalrecordsTextBox.Name = "aantalrecordsTextBox"
        Me.aantalrecordsTextBox.ReadOnly = true
        Me.aantalrecordsTextBox.Size = New System.Drawing.Size(75, 20)
        Me.aantalrecordsTextBox.TabIndex = 105
        Me.aantalrecordsTextBox.TabStop = false
        Me.aantalrecordsTextBox.Text = "0"
        Me.aantalrecordsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mailTextBox
        '
        Me.mailTextBox.AcceptsReturn = true
        Me.mailTextBox.BackColor = System.Drawing.Color.White
        Me.mailTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.mailTextBox.ForeColor = System.Drawing.Color.Black
        Me.mailTextBox.Location = New System.Drawing.Point(14, 126)
        Me.mailTextBox.MaxLength = 0
        Me.mailTextBox.Name = "mailTextBox"
        Me.mailTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mailTextBox.Size = New System.Drawing.Size(349, 20)
        Me.mailTextBox.TabIndex = 106
        Me.mailTextBox.Text = "josvermoesen@outlook.be"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Default mailadres:"
        '
        'frmDiversePostenBoek
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.closeButton
        Me.ClientSize = New System.Drawing.Size(374, 154)
        Me.ControlBox = false
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mailTextBox)
        Me.Controls.Add(Me.aantalrecordsTextBox)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.afdrukButton)
        Me.Controls.Add(Me.aantalrecordsLabel)
        Me.Controls.Add(Me.DateTimePicker)
        Me.Controls.Add(Me.vantotTextBox)
        Me.Controls.Add(Me.subtitelLabel)
        Me.Controls.Add(Me.datumdrukkenLabel)
        Me.Controls.Add(Me.AutoPageBreak)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.Name = "frmDiversePostenBoek"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Diverse Postenboek"
        Me.TopMost = true
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents AutoPageBreak As IDEALSoftware.VpeStandard.VpeControl
    Friend WithEvents Button1 As Button
    Public WithEvents vantotTextBox As TextBox
    Public WithEvents subtitelLabel As Label
    Public WithEvents datumdrukkenLabel As Label
    Friend WithEvents DateTimePicker As DateTimePicker
    Friend WithEvents aantalrecordsLabel As Label
    Friend WithEvents afdrukButton As Button
    Friend WithEvents closeButton As Button
    Friend WithEvents aantalrecordsTextBox As TextBox
    Public WithEvents mailTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
