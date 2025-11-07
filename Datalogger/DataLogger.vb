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
        Write(1, DateTime.Now)
        Write(1, DateTime.Now.Millisecond)
        WriteLine(1, currentSample)
        FileClose(1)
    End Sub

    Sub LoadData()
        Dim choice As DialogResult
        Dim fileNumber As Integer = FreeFile()
        Dim currentRecord As String
        Dim temp() As String

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "log file (*.log)|*.log"
        choice = OpenFileDialog1.ShowDialog()
        If choice = DialogResult.OK Then
            MsgBox(OpenFileDialog1.FileName)

            Try
                FileOpen(fileNumber, OpenFileDialog1.FileName, OpenMode.Input)
                Me.DataBuffer.Clear()

                Do Until EOF(fileNumber)
                    currentRecord = LineInput(fileNumber)
                    temp = Split(currentRecord, ",")
                    Me.DataBuffer.Enqueue(CInt(temp(temp.GetUpperBound(0))))
                Loop
                FileClose(fileNumber)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MsgBox("Erm...")
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

    'Event Handlers----------------------------------------------------------------------------------------------------------------------

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub GraphButton_Click(sender As Object, e As EventArgs) Handles GraphButton.Click
        Dim sampleRate As Integer = SampleRateComboBox.SelectedItem
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
        'GraphData()
        'GetData()

    End Sub

    Private Sub SampleTimer_Tick(sender As Object, e As EventArgs) Handles SampleTimer.Tick
        GraphData()
        GetData()
    End Sub

    Private Sub OpenTopMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTopMenuItem.Click
        LoadData()
    End Sub

    Private Sub DataLogger_Load(sender As Object, e As EventArgs) Handles Me.Load
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
    End Sub
End Class
