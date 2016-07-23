<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.startButton = New System.Windows.Forms.Button()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.rewindPicture = New System.Windows.Forms.PictureBox()
        Me.playPicture = New System.Windows.Forms.PictureBox()
        Me.fastFowardPicture = New System.Windows.Forms.PictureBox()
        Me.pausePicture = New System.Windows.Forms.PictureBox()
        Me.statusText = New System.Windows.Forms.TextBox()
        Me.speedText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.rewindPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.playPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fastFowardPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pausePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(12, 12)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(75, 23)
        Me.startButton.TabIndex = 0
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Location = New System.Drawing.Point(12, 38)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(39, 13)
        Me.statusLabel.TabIndex = 2
        Me.statusLabel.Text = "Label1"
        '
        'rewindPicture
        '
        Me.rewindPicture.Image = CType(resources.GetObject("rewindPicture.Image"), System.Drawing.Image)
        Me.rewindPicture.Location = New System.Drawing.Point(311, 187)
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
        Me.playPicture.Location = New System.Drawing.Point(530, 187)
        Me.playPicture.Name = "playPicture"
        Me.playPicture.Size = New System.Drawing.Size(65, 52)
        Me.playPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.playPicture.TabIndex = 3
        Me.playPicture.TabStop = False
        '
        'fastFowardPicture
        '
        Me.fastFowardPicture.Image = CType(resources.GetObject("fastFowardPicture.Image"), System.Drawing.Image)
        Me.fastFowardPicture.Location = New System.Drawing.Point(643, 187)
        Me.fastFowardPicture.Name = "fastFowardPicture"
        Me.fastFowardPicture.Size = New System.Drawing.Size(65, 52)
        Me.fastFowardPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.fastFowardPicture.TabIndex = 6
        Me.fastFowardPicture.TabStop = False
        '
        'pausePicture
        '
        Me.pausePicture.Image = CType(resources.GetObject("pausePicture.Image"), System.Drawing.Image)
        Me.pausePicture.Location = New System.Drawing.Point(420, 187)
        Me.pausePicture.Name = "pausePicture"
        Me.pausePicture.Size = New System.Drawing.Size(64, 52)
        Me.pausePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pausePicture.TabIndex = 4
        Me.pausePicture.TabStop = False
        '
        'statusText
        '
        Me.statusText.Location = New System.Drawing.Point(116, 104)
        Me.statusText.Name = "statusText"
        Me.statusText.Size = New System.Drawing.Size(100, 20)
        Me.statusText.TabIndex = 7
        Me.statusText.Text = "0"
        '
        'speedText
        '
        Me.speedText.Location = New System.Drawing.Point(292, 104)
        Me.speedText.Name = "speedText"
        Me.speedText.Size = New System.Drawing.Size(100, 20)
        Me.speedText.TabIndex = 8
        Me.speedText.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(292, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Speed"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(116, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Status"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 415)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.speedText)
        Me.Controls.Add(Me.statusText)
        Me.Controls.Add(Me.pausePicture)
        Me.Controls.Add(Me.fastFowardPicture)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.playPicture)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.rewindPicture)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.rewindPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.playPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fastFowardPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pausePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents startButton As Button
    Friend WithEvents statusLabel As Label
    Friend WithEvents rewindPicture As PictureBox
    Friend WithEvents playPicture As PictureBox
    Friend WithEvents fastFowardPicture As PictureBox
    Friend WithEvents pausePicture As PictureBox
    Friend WithEvents statusText As TextBox
    Friend WithEvents speedText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
