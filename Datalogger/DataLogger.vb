'Angel Nava
'Spring 2025
'RCET2265
'SayMyName
'https://github.com/TheGoldenPorkchop/Datalogger
Option Strict On
Option Explicit On
Imports System.IO.Ports

Public Class DataLogger
    Dim DataBuffer As New Queue(Of Integer)
    'Program Logic-----------------------------------------------------------------------------------------------------------------------


    Function GetRandomNumberAround(thisnumber%, Optional within% = 10) As Integer
        Dim result As Integer

        result = GetRandomNumber(2 * within) + (thisnumber - within)
        Return result
    End Function

    Function GetRandomNumber(max%, Optional min% = 0) As Integer
        Randomize()

        Return CInt(System.Math.Floor((Rnd() * (max + 1))))
    End Function

    Sub LogData(currentSample As Integer)
        Dim filePath As String = $"..\..\data_{DateTime.Now.ToString("yyMMddhh")}.log"
        Dim exactTime As String = DateTime.Now.ToString '("yyMMddhh") 'MODIFY FOR 
        FileOpen(1, filePath, OpenMode.Append)
        Write(1, "$$AN1")
        Write(1, currentSample)
        Write(1, DateTime.Now)
        WriteLine(1, DateTime.Now.Millisecond)
        FileClose(1)
    End Sub

    Sub LoadData()
        Dim choice As DialogResult
        Dim fileNumber% = FreeFile()
        Dim currentRecord$
        Dim temp() As String

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "log file (*.log)|*.log"
        choice = OpenFileDialog1.ShowDialog()
        If choice = DialogResult.OK Then
            'MsgBox(OpenFileDialog1.FileName)
            Try
                FileOpen(fileNumber, OpenFileDialog1.FileName, OpenMode.Input)
                Me.DataBuffer.Clear()

                Do Until EOF(fileNumber)
                    currentRecord = LineInput(fileNumber)
                    temp = Split(currentRecord, ",")

                    Me.DataBuffer.Enqueue(CInt(temp((1))))


                Loop
                FileClose(fileNumber)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            'cancel
            'MsgBox("Canceled")
        End If
        GraphData()
    End Sub

    Sub GetData()
        'Me.DataBuffer.Last
        Dim _last%
        Dim sample%

        If Me.DataBuffer.Count > 0 Then
            _last = Me.DataBuffer.Last
        Else
            _last = GetRandomNumberAround(50, 50)
        End If

        If DataBuffer.Count >= 100 Then
            Me.DataBuffer.Dequeue()
        End If


        sample = GetRandomNumberAround(_last, 5)
        Me.DataBuffer.Enqueue(sample)
        LogData(sample)

    End Sub

    Sub GetAnalogData()
        AnalogRead()
        Try
            CheckForIllegalCrossThreadCalls = False
            Dim numberOfBytes = SerialPort1.BytesToRead
            Dim buffer(numberOfBytes - 1) As Byte
            Dim got As Integer = SerialPort1.Read(buffer, 0, numberOfBytes)
            Dim analogbyte1 As Integer

            If got > 1 Then
                analogbyte1 = CInt((buffer(0) / 256) * 100)

                Me.DataBuffer.Enqueue(analogbyte1)

                LogData(analogbyte1)
            End If
        Catch ex As Exception
            SampleRateGroupBox.Enabled = True
            SampleTimer.Interval = 100
            SampleTimer.Stop()
            SampleTimer.Enabled = False
            GraphButton.Text = "Graph"
            MsgBox("Try Reconnecting your QY@ Board")
        End Try

    End Sub

    Sub GraphData()
        Dim g As Graphics = GraphPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Lime)
        Dim eraser As New Pen(Color.Black)

        'This works
        Dim scaleX! = CSng(GraphPictureBox.Width / 100)
        Dim scaleY! = CSng((GraphPictureBox.Height / 100) * -1)

        'this is the new stuff
        'Dim scaleX! = CSng(GraphPictureBox.Width / Me.DataBuffer.Count)
        'Dim scaleY! = CSng((GraphPictureBox.Height / 100) * -1)

        g.TranslateTransform(0, GraphPictureBox.Height) 'move origin to bottom left
        g.ScaleTransform(scaleX, scaleY) 'scale to 100 x 100 units
        pen.Width = 0.25 'fix pen so it is not too thick

        Dim oldY% = 0 ' GetRandomNumberAround(50, 50)
        Dim x = -1
        For Each y In Me.DataBuffer.Reverse
            x += 1
            g.DrawLine(eraser, x, 0, x, 100)
            g.DrawLine(pen, x - 1, oldY, x, y)
            oldY = y
        Next

        g.Dispose()
        pen.Dispose()

    End Sub
    Sub GetPorts()
        Dim ports() = SerialPort1.GetPortNames()
        PortsComboBox.Items.Clear()

        For Each port In ports
            PortsComboBox.Items.Add(port)
        Next
        Try
            PortsComboBox.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Sub Connect()
        SerialPort1.Close()
        SerialPort1.BaudRate = 115200 'Q@ Board Default
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.DataBits = 8
        Try
            SerialPort1.PortName = PortsComboBox.Text
        Catch ex As Exception
            MsgBox("Select or Change your Port via the Combo Box")
        End Try
        'SerialPort1.PortName = "COM5" 'RS232 Cable
        SerialPort1.Open()
    End Sub

    Sub AnalogRead()
        Dim data(0) As Byte
        data(0) = &H53 'Read Analog

        Try
            SerialPort1.Write(data, 0, 1)
        Catch ex As Exception

        End Try

    End Sub


    'Event Handlers----------------------------------------------------------------------------------------------------------------------

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub GraphButton_Click(sender As Object, e As EventArgs) Handles GraphButton.Click
        Dim sampleRate As Integer = CInt(SampleRateComboBox.SelectedItem)
        If SampleTimer.Enabled Then
            SampleRateGroupBox.Enabled = True
            SampleTimer.Interval = 100
            SampleTimer.Stop()
            SampleTimer.Enabled = False
            GraphButton.Text = "Graph"
        Else

            If MillisecondRadioButton.Checked = True Then
                SampleTimer.Interval = sampleRate
            ElseIf SecondsRadioButton.Checked = True Then
                sampleRate = sampleRate * 1000
                SampleTimer.Interval = sampleRate
            ElseIf MinutesRadioButton.Checked = True Then

                sampleRate = sampleRate * 60000
                SampleTimer.Interval = sampleRate

            End If

            SampleTimer.Enabled = True
            SampleRateGroupBox.Enabled = False
            SampleTimer.Start()
            GraphButton.Text = "Stop Graphing"
        End If
    End Sub

    Private Sub SampleTimer_Tick(sender As Object, e As EventArgs) Handles SampleTimer.Tick
        'AnalogRead()
        GetAnalogData()
        GraphData()

    End Sub

    Private Sub OpenTopMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTopMenuItem.Click
        LoadData()
    End Sub

    Private Sub DataLogger_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetPorts()
        Try
            Connect()
        Catch ex As Exception
            MsgBox("Connect your Qy@ Board")
        End Try
        SampleRateComboBox.SelectedIndex = 0
    End Sub

    Private Sub RadioButtons_CheckedChanged(sender As Object, e As EventArgs) Handles MillisecondRadioButton.CheckedChanged, SecondsRadioButton.CheckedChanged, MinutesRadioButton.CheckedChanged
        If MillisecondRadioButton.Checked = True Then
            SampleRateComboBox.Items.Clear()
            SampleRateComboBox.Items.Add(100)
            SampleRateComboBox.Items.Add(200)
            SampleRateComboBox.Items.Add(500)
        ElseIf SecondsRadioButton.Checked = True Then
            SampleRateComboBox.Items.Clear()
            SampleRateComboBox.Items.Add(1)
            SampleRateComboBox.Items.Add(5)
            SampleRateComboBox.Items.Add(10)
            SampleRateComboBox.Items.Add(30)
        ElseIf MinutesRadioButton.Checked = True Then
            SampleRateComboBox.Items.Clear()
            SampleRateComboBox.Items.Add(1)
            SampleRateComboBox.Items.Add(5)
            SampleRateComboBox.Items.Add(10)
        End If
        SampleRateComboBox.SelectedIndex = 0
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

    End Sub
End Class
