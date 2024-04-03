<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Browser
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Browser))
        Me.webBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.timTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbToolBar = New System.Windows.Forms.ToolStrip()
        Me.imlIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.goButton = New System.Windows.Forms.ToolStripButton()
        Me.cmdSluiten = New System.Windows.Forms.Button()
        Me.tbToolBar.SuspendLayout
        Me.SuspendLayout
        '
        'webBrowser1
        '
        Me.webBrowser1.AllowWebBrowserDrop = false
        Me.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.webBrowser1.Name = "webBrowser1"
        Me.webBrowser1.Size = New System.Drawing.Size(691, 537)
        Me.webBrowser1.TabIndex = 5
        '
        'timTimer
        '
        Me.timTimer.Interval = 5
        '
        'tbToolBar
        '
        Me.tbToolBar.ImageList = Me.imlIcons
        Me.tbToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.goButton, Me.ToolStripTextBox1})
        Me.tbToolBar.Location = New System.Drawing.Point(0, 0)
        Me.tbToolBar.Name = "tbToolBar"
        Me.tbToolBar.Size = New System.Drawing.Size(691, 25)
        Me.tbToolBar.TabIndex = 6
        '
        'imlIcons
        '
        Me.imlIcons.ImageStream = CType(resources.GetObject("imlIcons.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imlIcons.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.imlIcons.Images.SetKeyName(0, "")
        Me.imlIcons.Images.SetKeyName(1, "")
        Me.imlIcons.Images.SetKeyName(2, "")
        Me.imlIcons.Images.SetKeyName(3, "")
        Me.imlIcons.Images.SetKeyName(4, "")
        Me.imlIcons.Images.SetKeyName(5, "")
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(500, 25)
        '
        'goButton
        '
        Me.goButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.goButton.Image = CType(resources.GetObject("goButton.Image"),System.Drawing.Image)
        Me.goButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.goButton.Name = "goButton"
        Me.goButton.Size = New System.Drawing.Size(23, 22)
        Me.goButton.Text = "GO"
        Me.goButton.ToolTipText = "GO"
        '
        'cmdSluiten
        '
        Me.cmdSluiten.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSluiten.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSluiten.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSluiten.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSluiten.Location = New System.Drawing.Point(445, 62)
        Me.cmdSluiten.Name = "cmdSluiten"
        Me.cmdSluiten.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSluiten.Size = New System.Drawing.Size(81, 25)
        Me.cmdSluiten.TabIndex = 4
        Me.cmdSluiten.Text = "Sluiten"
        Me.cmdSluiten.UseVisualStyleBackColor = false
        '
        'Browser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSluiten
        Me.ClientSize = New System.Drawing.Size(691, 537)
        Me.Controls.Add(Me.tbToolBar)
        Me.Controls.Add(Me.webBrowser1)
        Me.Controls.Add(Me.cmdSluiten)
        Me.Name = "Browser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBrowser"
        Me.tbToolBar.ResumeLayout(false)
        Me.tbToolBar.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Public WithEvents webBrowser1 As WebBrowser
    Public WithEvents timTimer As Timer
    Public WithEvents ToolTip1 As ToolTip
    Public WithEvents tbToolBar As ToolStrip
    Public WithEvents imlIcons As ImageList
    Public WithEvents cmdSluiten As Button
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents goButton As ToolStripButton
End Class
