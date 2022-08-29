Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Namespace Common
    Public Class Logging

        Public Shared Sub WriteToLog(ByVal messageType As String, ByVal title As String, ByVal message As String)

            ' Load Settings
            Dim json As String = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"))
            Dim settings As Common.Models.Settings = JsonConvert.DeserializeObject(Of Models.Settings)(json)

            'Create the Log directory if it does not exist.
            If Not Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")) Then Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"))

            ' Check if logging has been enabled.
            If settings.Application.Logging.Enabled Then

                'Rotate log files if log rotation is active.
                If settings.Application.Logging.RotateLogs Then RotateLogFiles()

                ' Create a new log file if one does not alreay exist.
                If Not File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt")) Then File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt")).Dispose()

                ' Write event to the log file.
                Dim line As StringBuilder = New StringBuilder()
                line.Append("[" & DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss") & "] ")
                line.Append("(" & messageType & ") ")
                line.Append(title.ToUpper() & ": ")
                line.Append(message.Replace(vbCrLf, ""))
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt"), line.ToString() + Environment.NewLine)
            End If
        End Sub

        Private Shared Sub RotateLogFiles()
            If File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt")) Then

                ' Load Settings
                Dim json As String = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"))
                Dim settings As Models.Settings = JsonConvert.DeserializeObject(Of Common.Models.Settings)(json)

                ' Check if log rotaion has been enabled.
                If settings.Application.Logging.RotateLogs Then

                    ' Check if this log is from yesterday or earlier.
                    Dim lastEntry = File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt")).Last()
                    Dim firstIndex As Integer = lastEntry.IndexOf("[")
                    Dim entryDate = DateTime.Parse(lastEntry.Substring(firstIndex + 1, lastEntry.IndexOf("]", firstIndex + 1) - firstIndex - 1))

                    ' Rotate this log file if it was from before today.
                    If DateTime.Today - entryDate.Date = TimeSpan.FromDays(1.0R) Then
                        File.Move(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log" & entryDate.ToString("_yyyy-MM-dd") & ".txt"))
                    End If

                    ' Delete any logs older than specified in the applications settings if the days to keep is not set to 0.
                    If Not (settings.Application.Logging.DaysToKeep = 0) Then

                        'Loop through each file and get the last entry date contained within.
                        For Each logFile As String In Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"))
                            Dim thisLastEntry As String = File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", logFile)).Last()
                            Dim thisFirstIndex As Integer = thisLastEntry.IndexOf("[")
                            Dim thisEntryDate = DateTime.Parse(thisLastEntry.Substring(thisFirstIndex + 1, thisLastEntry.IndexOf("]", thisFirstIndex + 1) - thisFirstIndex - 1))

                            ' Delete the file if that last entry day is older than the DaysToKeep Settings.
                            If DateTime.Today - thisEntryDate.Date > TimeSpan.FromDays(Convert.ToDouble(settings.Application.Logging.DaysToKeep)) Then
                                File.Delete(logFile)
                            End If
                        Next
                    End If
                End If
            End If
        End Sub

    End Class
End Namespace