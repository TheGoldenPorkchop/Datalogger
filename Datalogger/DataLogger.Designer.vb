<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataLogger
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
        Me.components = New System.ComponentModel.Container()
        Me.ButtonGroupBox = New System.Windows.Forms.GroupBox()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.GraphButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.GraphPictureBox = New System.Windows.Forms.PictureBox()
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenTopMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SampleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SampleRateComboBox = New System.Windows.Forms.ComboBox()
        Me.SampleRateGroupBox = New System.Windows.Forms.GroupBox()
        Me.MinutesRadioButton = New System.Windows.Forms.RadioButton()
        Me.SecondsRadioButton = New System.Windows.Forms.RadioButton()
        Me.MillisecondRadioButton = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PortsComboBox = New System.Windows.Forms.ComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SerialGroupBox = New System.Windows.Forms.GroupBox()
        Me.ButtonGroupBox.SuspendLayout()
        CType(Me.GraphPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopMenuStrip.SuspendLayout()
        Me.SampleRateGroupBox.SuspendLayout()
        Me.SerialGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonGroupBox
        '
        Me.ButtonGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGroupBox.Controls.Add(Me.ExitButton)
        Me.ButtonGroupBox.Controls.Add(Me.GraphButton)
        Me.ButtonGroupBox.Controls.Add(Me.SaveButton)
        Me.ButtonGroupBox.Location = New System.Drawing.Point(506, 299)
        Me.ButtonGroupBox.Name = "ButtonGroupBox"
        Me.ButtonGroupBox.Size = New System.Drawing.Size(282, 106)
        Me.ButtonGroupBox.TabIndex = 6
        Me.ButtonGroupBox.TabStop = False
        Me.ButtonGroupBox.Text = "GroupBox1"
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(191, 21)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(86, 76)
        Me.ExitButton.TabIndex = 3
        Me.ExitButton.Text = "E&xitButton"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'GraphButton
        '
        Me.GraphButton.Location = New System.Drawing.Point(99, 21)
        Me.GraphButton.Name = "GraphButton"
        Me.GraphButton.Size = New System.Drawing.Size(86, 76)
        Me.GraphButton.TabIndex = 2
        Me.GraphButton.Text = "&Graph"
        Me.GraphButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(7, 21)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(86, 76)
        Me.SaveButton.TabIndex = 1
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'GraphPictureBox
        '
        Me.GraphPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GraphPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GraphPictureBox.Location = New System.Drawing.Point(12, 27)
        Me.GraphPictureBox.Name = "GraphPictureBox"
        Me.GraphPictureBox.Size = New System.Drawing.Size(776, 266)
        Me.GraphPictureBox.TabIndex = 5
        Me.GraphPictureBox.TabStop = False
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.Size = New System.Drawing.Size(800, 28)
        Me.TopMenuStrip.TabIndex = 7
        Me.TopMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenTopMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenTopMenuItem
        '
        Me.OpenTopMenuItem.Name = "OpenTopMenuItem"
        Me.OpenTopMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.OpenTopMenuItem.Text = "&Open"
        '
        'SampleTimer
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 415)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SampleRateComboBox
        '
        Me.SampleRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SampleRateComboBox.FormattingEnabled = True
        Me.SampleRateComboBox.Location = New System.Drawing.Point(6, 71)
        Me.SampleRateComboBox.Name = "SampleRateComboBox"
        Me.SampleRateComboBox.Size = New System.Drawing.Size(121, 24)
        Me.SampleRateComboBox.TabIndex = 9
        '
        'SampleRateGroupBox
        '
        Me.SampleRateGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SampleRateGroupBox.Controls.Add(Me.MinutesRadioButton)
        Me.SampleRateGroupBox.Controls.Add(Me.SecondsRadioButton)
        Me.SampleRateGroupBox.Controls.Add(Me.MillisecondRadioButton)
        Me.SampleRateGroupBox.Location = New System.Drawing.Point(384, 299)
        Me.SampleRateGroupBox.Name = "SampleRateGroupBox"
        Me.SampleRateGroupBox.Size = New System.Drawing.Size(116, 106)
        Me.SampleRateGroupBox.TabIndex = 10
        Me.SampleRateGroupBox.TabStop = False
        Me.SampleRateGroupBox.Text = "Sample Rate"
        '
        'MinutesRadioButton
        '
        Me.MinutesRadioButton.AutoSize = True
        Me.MinutesRadioButton.Location = New System.Drawing.Point(6, 77)
        Me.MinutesRadioButton.Name = "MinutesRadioButton"
        Me.MinutesRadioButton.Size = New System.Drawing.Size(74, 20)
        Me.MinutesRadioButton.TabIndex = 2
        Me.MinutesRadioButton.TabStop = True
        Me.MinutesRadioButton.Text = "Minutes"
        Me.MinutesRadioButton.UseVisualStyleBackColor = True
        '
        'SecondsRadioButton
        '
        Me.SecondsRadioButton.AutoSize = True
        Me.SecondsRadioButton.Location = New System.Drawing.Point(6, 51)
        Me.SecondsRadioButton.Name = "SecondsRadioButton"
        Me.SecondsRadioButton.Size = New System.Drawing.Size(82, 20)
        Me.SecondsRadioButton.TabIndex = 1
        Me.SecondsRadioButton.TabStop = True
        Me.SecondsRadioButton.Text = "Seconds"
        Me.SecondsRadioButton.UseVisualStyleBackColor = True
        '
        'MillisecondRadioButton
        '
        Me.MillisecondRadioButton.AutoSize = True
        Me.MillisecondRadioButton.Checked = True
        Me.MillisecondRadioButton.Location = New System.Drawing.Point(6, 25)
        Me.MillisecondRadioButton.Name = "MillisecondRadioButton"
        Me.MillisecondRadioButton.Size = New System.Drawing.Size(103, 20)
        Me.MillisecondRadioButton.TabIndex = 0
        Me.MillisecondRadioButton.TabStop = True
        Me.MillisecondRadioButton.Text = "Milliseconds"
        Me.MillisecondRadioButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Port Select"
        '
        'PortsComboBox
        '
        Me.PortsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PortsComboBox.FormattingEnabled = True
        Me.PortsComboBox.Location = New System.Drawing.Point(6, 41)
        Me.PortsComboBox.Name = "PortsComboBox"
        Me.PortsComboBox.Size = New System.Drawing.Size(121, 24)
        Me.PortsComboBox.TabIndex = 15
        '
        'SerialGroupBox
        '
        Me.SerialGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SerialGroupBox.Controls.Add(Me.Label3)
        Me.SerialGroupBox.Controls.Add(Me.PortsComboBox)
        Me.SerialGroupBox.Controls.Add(Me.SampleRateComboBox)
        Me.SerialGroupBox.Location = New System.Drawing.Point(243, 305)
        Me.SerialGroupBox.Name = "SerialGroupBox"
        Me.SerialGroupBox.Size = New System.Drawing.Size(135, 100)
        Me.SerialGroupBox.TabIndex = 18
        Me.SerialGroupBox.TabStop = False
        Me.SerialGroupBox.Text = "Serial"
        '
        'DataLogger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 437)
        Me.Controls.Add(Me.SerialGroupBox)
        Me.Controls.Add(Me.SampleRateGroupBox)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ButtonGroupBox)
        Me.Controls.Add(Me.GraphPictureBox)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "DataLogger"
        Me.Text = "Form1"
        Me.ButtonGroupBox.ResumeLayout(False)
        CType(Me.GraphPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.SampleRateGroupBox.ResumeLayout(False)
        Me.SampleRateGroupBox.PerformLayout()
        Me.SerialGroupBox.ResumeLayout(False)
        Me.SerialGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonGroupBox As GroupBox
    Friend WithEvents ExitButton As Button
    Friend WithEvents GraphButton As Button
    Friend WithEvents SaveButton As Button
    Friend WithEvents GraphPictureBox As PictureBox
    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SampleTimer As Timer
    Friend WithEvents OpenTopMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SampleRateComboBox As ComboBox
    Friend WithEvents SampleRateGroupBox As GroupBox
    Friend WithEvents MinutesRadioButton As RadioButton
    Friend WithEvents SecondsRadioButton As RadioButton
    Friend WithEvents MillisecondRadioButton As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents PortsComboBox As ComboBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents SerialGroupBox As GroupBox
End Class
