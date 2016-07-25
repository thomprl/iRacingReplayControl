<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReplayForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReplayForm))
        Me.rewindPicture = New System.Windows.Forms.PictureBox()
        Me.playPicture = New System.Windows.Forms.PictureBox()
        Me.fastFowardPicture = New System.Windows.Forms.PictureBox()
        Me.pausePicture = New System.Windows.Forms.PictureBox()
        Me.slowMoRewindPicture = New System.Windows.Forms.PictureBox()
        Me.slowMoForwardPicture = New System.Windows.Forms.PictureBox()
        Me.endPicture = New System.Windows.Forms.PictureBox()
        Me.beginPicture = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.rewindPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.playPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fastFowardPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pausePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slowMoRewindPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slowMoForwardPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.endPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beginPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rewindPicture
        '
        Me.rewindPicture.Image = CType(resources.GetObject("rewindPicture.Image"), System.Drawing.Image)
        Me.rewindPicture.Location = New System.Drawing.Point(204, 12)
        Me.rewindPicture.Name = "rewindPicture"
        Me.rewindPicture.Size = New System.Drawing.Size(65, 52)
        Me.rewindPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.rewindPicture.TabIndex = 5
        Me.rewindPicture.TabStop = False
        '
        'playPicture
        '
        Me.playPicture.Image = CType(resources.GetObject("playPicture.Image"), System.Drawing.Image)
        Me.playPicture.InitialImage = Nothing
        Me.playPicture.Location = New System.Drawing.Point(417, 12)
        Me.playPicture.Name = "playPicture"
        Me.playPicture.Size = New System.Drawing.Size(65, 52)
        Me.playPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.playPicture.TabIndex = 3
        Me.playPicture.TabStop = False
        '
        'fastFowardPicture
        '
        Me.fastFowardPicture.Image = CType(resources.GetObject("fastFowardPicture.Image"), System.Drawing.Image)
        Me.fastFowardPicture.Location = New System.Drawing.Point(536, 12)
        Me.fastFowardPicture.Name = "fastFowardPicture"
        Me.fastFowardPicture.Size = New System.Drawing.Size(65, 52)
        Me.fastFowardPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.fastFowardPicture.TabIndex = 6
        Me.fastFowardPicture.TabStop = False
        '
        'pausePicture
        '
        Me.pausePicture.Image = CType(resources.GetObject("pausePicture.Image"), System.Drawing.Image)
        Me.pausePicture.Location = New System.Drawing.Point(313, 12)
        Me.pausePicture.Name = "pausePicture"
        Me.pausePicture.Size = New System.Drawing.Size(64, 52)
        Me.pausePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pausePicture.TabIndex = 4
        Me.pausePicture.TabStop = False
        '
        'slowMoRewindPicture
        '
        Me.slowMoRewindPicture.Image = CType(resources.GetObject("slowMoRewindPicture.Image"), System.Drawing.Image)
        Me.slowMoRewindPicture.Location = New System.Drawing.Point(104, 12)
        Me.slowMoRewindPicture.Name = "slowMoRewindPicture"
        Me.slowMoRewindPicture.Size = New System.Drawing.Size(64, 52)
        Me.slowMoRewindPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.slowMoRewindPicture.TabIndex = 11
        Me.slowMoRewindPicture.TabStop = False
        '
        'slowMoForwardPicture
        '
        Me.slowMoForwardPicture.Image = CType(resources.GetObject("slowMoForwardPicture.Image"), System.Drawing.Image)
        Me.slowMoForwardPicture.Location = New System.Drawing.Point(647, 12)
        Me.slowMoForwardPicture.Name = "slowMoForwardPicture"
        Me.slowMoForwardPicture.Size = New System.Drawing.Size(65, 52)
        Me.slowMoForwardPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.slowMoForwardPicture.TabIndex = 12
        Me.slowMoForwardPicture.TabStop = False
        '
        'endPicture
        '
        Me.endPicture.Image = CType(resources.GetObject("endPicture.Image"), System.Drawing.Image)
        Me.endPicture.Location = New System.Drawing.Point(742, 12)
        Me.endPicture.Name = "endPicture"
        Me.endPicture.Size = New System.Drawing.Size(63, 52)
        Me.endPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.endPicture.TabIndex = 13
        Me.endPicture.TabStop = False
        '
        'beginPicture
        '
        Me.beginPicture.Image = CType(resources.GetObject("beginPicture.Image"), System.Drawing.Image)
        Me.beginPicture.Location = New System.Drawing.Point(12, 12)
        Me.beginPicture.Name = "beginPicture"
        Me.beginPicture.Size = New System.Drawing.Size(64, 52)
        Me.beginPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.beginPicture.TabIndex = 14
        Me.beginPicture.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 393)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1155, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(204, 170)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 16
        '
        'ReplayForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 415)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.beginPicture)
        Me.Controls.Add(Me.endPicture)
        Me.Controls.Add(Me.slowMoForwardPicture)
        Me.Controls.Add(Me.slowMoRewindPicture)
        Me.Controls.Add(Me.pausePicture)
        Me.Controls.Add(Me.fastFowardPicture)
        Me.Controls.Add(Me.playPicture)
        Me.Controls.Add(Me.rewindPicture)
        Me.Name = "ReplayForm"
        Me.Text = "iRacing Replay Control"
        CType(Me.rewindPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.playPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fastFowardPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pausePicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slowMoRewindPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slowMoForwardPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.endPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beginPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rewindPicture As PictureBox
    Friend WithEvents playPicture As PictureBox
    Friend WithEvents fastFowardPicture As PictureBox
    Friend WithEvents pausePicture As PictureBox
    Friend WithEvents slowMoRewindPicture As PictureBox
    Friend WithEvents slowMoForwardPicture As PictureBox
    Friend WithEvents endPicture As PictureBox
    Friend WithEvents beginPicture As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ComboBox1 As ComboBox
End Class
