Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO

Public Class WoodGrainEffectMainForm
    Private Sub BrowseCuraFile_Click(sender As Object, e As EventArgs) Handles btnBrowseCuraFile.Click
        Dim ofdlgCura As OpenFileDialog
        ofdlgCura = New OpenFileDialog()
        ofdlgCura.Title = "Cura GCode File"
        ofdlgCura.InitialDirectory = "c:\"
        ofdlgCura.Filter = "GCode files (*.gcode)|*.gcode|All files (*.*)|*.*"
        ofdlgCura.FilterIndex = 1
        ofdlgCura.RestoreDirectory = True
        If ofdlgCura.ShowDialog() = DialogResult.OK Then
            tboxCuraFile.Text = ofdlgCura.FileName
        End If
    End Sub
    Private Sub BrowseSaveAs_Click(sender As Object, e As EventArgs) Handles btnBrowseSaveAs.Click
        Dim sfdlgSaveAs As SaveFileDialog
        sfdlgSaveAs = New SaveFileDialog
        sfdlgSaveAs.Title = "Save The New File As"
        sfdlgSaveAs.InitialDirectory = "c:\"
        sfdlgSaveAs.Filter = "GCode files (*.gcode)|*.gcode|All files (*.*)|*.*"
        sfdlgSaveAs.FilterIndex = 1
        sfdlgSaveAs.ShowDialog()
        If sfdlgSaveAs.FileName <> "" Then
            tboxSaveAs.Text = sfdlgSaveAs.FileName
        End If
    End Sub
    Private Sub RunNow_Click(sender As Object, e As EventArgs) Handles btnRunNow.Click
        '*****************************
        '*** declare variables and set defaults
        '*****************************
        Dim strOriginalFilePath As String = "C:/temp/gcodetest.gcode"
        Dim strAlteredFilePath As String = "C:/temp/gcodetest-altered.gcode"
        Dim iOriginalFileLine As Integer = 1
        Dim iAlteredFileLine As Integer = 1
        Dim iLineLength As Integer = 0
        Dim iM104position As Integer = 0
        Dim strOrigTemp As String = ""
        Dim iOrigTemp As Integer = 0
        Dim iZposition As Integer = 0
        Dim strPrintHeight As String = ""
        Dim decCurrentPrintHeight As Decimal = 0.0
        Dim decTallestPrintHeight As Decimal = 0.0
        Dim strBottomTemp As String = ""
        Dim iBottomTemp As Integer = 190
        Dim strTopTemp As String = ""
        Dim iTopTemp As Integer = 240
        Dim iRangeGap As Integer = 0
        Dim iEndLowRangeTemp As Integer = 0
        Dim iStartHighRangeTemp As Integer = 0
        Dim ranNewTemp As New Random()
        Dim iNewTemp As Integer = 0
        Dim iPreviousTemp As Integer = 0
        Dim ranNewBandHeight As New Random()
        Dim iNewBandHeight As Integer = 3 'mm
        Dim iPreviousBandHeight As Integer = 0
        Dim iProtectedBaseHeight As Integer = 2 'mm
        Dim iTallestRoundedDown As Integer = 0
        Dim iProtectedCeilingHeight As Integer = 0 'mm
        Dim boolCeilingReset As Boolean = False
        Dim decNextBandHeight As Decimal = 0.0

        Try
            '***********************
            '*** validate user input
            '***********************
            '* did they even choose files before clicking the button
            If tboxCuraFile.Text = "" Or tboxSaveAs.Text = "" Then
                tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "There was a problem")
                tboxStatus.AppendText(Environment.NewLine & "Please choose your files first. Try again...")
            End If
            strOriginalFilePath = tboxCuraFile.Text
            '* make sure the original file actually exists
            If Not File.Exists(strOriginalFilePath) Then
                tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "There was a problem")
                tboxStatus.AppendText(Environment.NewLine & "The original file listed was not found. Try again...")
                Return
            End If
            strAlteredFilePath = tboxSaveAs.Text
            '* make sure they are not choosing the same file and path as the original
            If strOriginalFilePath = strAlteredFilePath Then
                tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "There was a problem")
                tboxStatus.AppendText(Environment.NewLine & "The new file cannot have the same path and name as the original. Try again...")
                Return
            End If
            tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "Using the file: " & strOriginalFilePath & Environment.NewLine)
            tboxStatus.AppendText(Environment.NewLine & "New file will be: " & strAlteredFilePath & Environment.NewLine)
            '* make sure the Bottom Temp entry was numeric
            If IsNumeric(tboxBottomTemp.Text) Then
                iBottomTemp = tboxBottomTemp.Text
            Else
                tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "There was a problem")
                tboxStatus.AppendText(Environment.NewLine & "The bottom temp you entered was not numeric. Try again...")
                Return
            End If
            tboxStatus.AppendText(Environment.NewLine & "Bottom temp: " & iBottomTemp)
            '* make sure the Top Temp entry was numeric
            If IsNumeric(tboxTopTemp.Text) Then
                iTopTemp = tboxTopTemp.Text
                '* make sure the top temperature entered is higher than the bottom temp
                If iTopTemp < iBottomTemp Then
                    tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "There was a problem")
                    tboxStatus.AppendText(Environment.NewLine & "The top temp you entered was lower than the bottom temp. Try again...")
                    Return
                End If
            Else
                tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "There was a problem")
                tboxStatus.AppendText(Environment.NewLine & "The top temp you entered was not numeric. Try again...")
                Return
            End If
            '* check to see if they entered a top temp which may be dangerous
            If iTopTemp > 240 Then
                If MessageBox.Show("The top temperature you entered appears to be higher than a" & Environment.NewLine & "normal maximum temperature." & Environment.NewLine & Environment.NewLine & "Be sure you know the limitations of your printer and the materials" & Environment.NewLine & "you are using." & Environment.NewLine & Environment.NewLine & "It can be DANGEROUS to your printer and YOUR HEALTH if you choose" & Environment.NewLine & "too high of a temperature." & Environment.NewLine & Environment.NewLine & "Are you sure you want to use this high-end temperature (" & iTopTemp & " C)?", "Use This High Temp?", MessageBoxButtons.YesNo) = DialogResult.No Then
                    tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "Please choose a different Top Temp and try again...")
                    Return
                End If
            End If
            tboxStatus.AppendText(Environment.NewLine & "Top temp: " & iTopTemp)
            '*****************************
            '*** Use the top and bottom entries from the user input to create a low and high range of temps
            '*** We want to create random temps that are a worthwhile change from the previous "band"
            '*** To do this, we'll avoid the middle third of the overall range
            '*****************************
            iRangeGap = iTopTemp - iBottomTemp
            iEndLowRangeTemp = iBottomTemp + (Math.Floor(iRangeGap * 0.33))
            iStartHighRangeTemp = iTopTemp - (Math.Floor(iRangeGap * 0.33))
            tboxStatus.AppendText(Environment.NewLine & "lower range: " & iBottomTemp & "-" & iEndLowRangeTemp)
            tboxStatus.AppendText(Environment.NewLine & "upper range: " & iStartHighRangeTemp & "-" & iTopTemp & Environment.NewLine)
            '*****************************
            '*** step through the file once, just to gather details
            '*** such as tallest Z axis height and original hot-end/nozzle temperature
            '*****************************
            Using sr As StreamReader = New StreamReader(strOriginalFilePath)
                Dim line As String
                line = sr.ReadLine()
                While Not sr.EndOfStream
                    If iOrigTemp = 0 Then 'once the default value has been overwritten, leave it alone
                        If line.Contains("M104") Then
                            iLineLength = line.Length
                            iM104position = InStr(line, "M104 S")
                            strOrigTemp = Mid(line, iM104position + 6, iLineLength)
                            If IsNumeric(strOrigTemp) Then iOrigTemp = strOrigTemp
                            If decCurrentPrintHeight > decTallestPrintHeight Then decTallestPrintHeight = decCurrentPrintHeight
                        End If
                    End If
                    If line.Contains(" Z") AndAlso Not line.Contains(";") Then
                        iLineLength = line.Length
                        iZposition = InStr(line, "Z")
                        strPrintHeight = Mid(line, iZposition + 1, iLineLength)
                        If IsNumeric(strPrintHeight) Then decCurrentPrintHeight = strPrintHeight
                        If decCurrentPrintHeight > decTallestPrintHeight Then decTallestPrintHeight = decCurrentPrintHeight
                    End If
                    line = sr.ReadLine()
                End While
                iTallestRoundedDown = Math.Floor(decTallestPrintHeight)
                iProtectedCeilingHeight = iTallestRoundedDown - 2 'mm
            End Using
            tboxStatus.AppendText(Environment.NewLine & "Original temp was determined to be " & iOrigTemp & " C")
            tboxStatus.AppendText(Environment.NewLine & "Tallest Z height was determined to be " & decTallestPrintHeight & " mm")
            tboxStatus.AppendText(Environment.NewLine & "The protected base will be " & iProtectedBaseHeight & " mm (will retain original temp)")
            tboxStatus.AppendText(Environment.NewLine & "The tallest height we will alter temps is " & iProtectedCeilingHeight & " mm" & Environment.NewLine)
            '*****************************
            '*** step through the file again, this time rewriting it to a new file
            '*** with the new temperature changes included
            '*****************************
            Using sr As StreamReader = New StreamReader(strOriginalFilePath)
                Using sw As StreamWriter = New StreamWriter(strAlteredFilePath)
                    Dim line As String
                    line = sr.ReadLine()
                    iOriginalFileLine = iOriginalFileLine + 1
                    While Not sr.EndOfStream
                        '* write the line from the original file every time
                        sw.WriteLine(line)
                        iAlteredFileLine = iAlteredFileLine + 1
                        '* start to determine if we need to add a line for a temperature change
                        If line.Contains(" Z") AndAlso Not line.Contains(";") Then
                            '* this is a line that contains a Z axis change
                            iLineLength = line.Length
                            '* determine the new height
                            iZposition = InStr(line, "Z")
                            strPrintHeight = Mid(line, iZposition + 1, iLineLength)
                            If IsNumeric(strPrintHeight) Then decCurrentPrintHeight = strPrintHeight
                            '* check to make sure we are above the protected base height
                            If decCurrentPrintHeight > iProtectedBaseHeight Then
                                '* check to make sure we are below the protected ceiling height
                                If decCurrentPrintHeight < iProtectedCeilingHeight Then
                                    '* check to make sure we have completed the previous band height
                                    If decCurrentPrintHeight > decNextBandHeight Then
                                        '* a new temperature band needs to start here
                                        '* check to see if the current temp is in the lower or upper range
                                        If iNewTemp > iBottomTemp + (iRangeGap * 0.5) Then
                                            '* was in the upper range, get a new random temp in the lower range
                                            iNewTemp = ranNewTemp.Next(iBottomTemp, iEndLowRangeTemp)
                                        Else
                                            '* was in the lower range, get a new random temp in the upper range
                                            iNewTemp = ranNewTemp.Next(iStartHighRangeTemp, iTopTemp)
                                        End If
                                        sw.WriteLine("M104 S" & iNewTemp & " ; added by WoodGrainEffect app")
                                        iAlteredFileLine = iAlteredFileLine + 1
                                        tboxStatus.AppendText(Environment.NewLine & "Set temp to " & iNewTemp & " at height of " & decCurrentPrintHeight)
                                        'tboxStatus.AppendText(Environment.NewLine & "Added M104 S" & iNewTemp & " after height change to " & decCurrentPrintHeight & " [at lines " & iOriginalFileLine & "/" & iAlteredFileLine & "]")
                                        '* update the next band height
                                        iNewBandHeight = ranNewBandHeight.Next(1, 4)
                                        decNextBandHeight = decCurrentPrintHeight + iNewBandHeight
                                    End If
                                Else
                                    '* we are in the protected ceiling, make sure the temp is set back to the original
                                    If Not boolCeilingReset Then
                                        sw.WriteLine("M104 S" & iOrigTemp & " ; added by WoodGrainEffect App")
                                        boolCeilingReset = True
                                        tboxStatus.AppendText(Environment.NewLine & "Set temp to " & iOrigTemp & " at height of " & decCurrentPrintHeight & " to reset back to original for the protected ceiling.")
                                        'tboxStatus.AppendText(Environment.NewLine & "Added M104 S" & iOrigTemp & " to reset temp back to original for the protected ceiling " & decCurrentPrintHeight & " [at lines " & iOriginalFileLine & "/" & iAlteredFileLine & "]")
                                    End If
                                End If
                            End If
                        End If
                        line = sr.ReadLine()
                        iOriginalFileLine = iOriginalFileLine + 1
                    End While
                End Using
            End Using

            tboxStatus.AppendText(Environment.NewLine & Environment.NewLine & "Done. New file has been created.")
        Catch ex As Exception
            tboxStatus.AppendText(Environment.NewLine & "Error: " & ex.Message)
        End Try
    End Sub
End Class
