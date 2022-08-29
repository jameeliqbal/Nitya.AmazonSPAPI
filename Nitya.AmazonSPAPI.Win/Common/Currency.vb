Imports System.IO
Imports FixerSharp
Imports Newtonsoft.Json

Namespace Common
    Public Class Currency

        Public Shared Function UpdateConversionRateUsingFixer(from As String) As Boolean

            ' Load Settings
            Dim json As String = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"))
            Dim settings As Models.Settings = JsonConvert.DeserializeObject(Of Models.Settings)(json)

            ' Convert CAD to USD using the Fixer.io API.
            Dim conversionResult As Double = 0
            Fixer.SetApiKey(settings.ThirdPartyServices.FixerApiKey)

            Try
                ' Get the current conversion rate for the amount of one.
                conversionResult = Fixer.Convert(from, settings.Application.Currency, 1)
                Logging.WriteToLog("INFO", "APPLICATION", "Successfully retieved the conversion rate for " & from & " to " & settings.Application.Currency & " amounts using fixer.")
            Catch ex As Exception
                Logging.WriteToLog("INFO", "APPLICATION", "Failed to retieve the conversion rate for " & from & " to " & settings.Application.Currency & " amounts using fixer. " + ex.Message)
                Return False
            End Try

            ' Update the affected marketplaces to reflect this new rate.
            Try

                For Each place In settings.Amazon.Marketplaces.Where(Function(m) m.Currency = from)
                    place.ConversionRate = Math.Round(conversionResult, 2).ToString("F2")
                    place.ConversionRateUpdated = DateTime.Now
                Next

                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"), JsonConvert.SerializeObject(settings, Formatting.Indented))
            Catch ex As Exception
                Logging.WriteToLog("ERROR", "APPLICATION", "Unable to write the file Settings.json. " & ex.Message)
                Return False
            End Try

            Logging.WriteToLog("INFO", "APPLICATION", "Settings changes were successfully saved.")

            ' Everything went well so return true.
            Return True
        End Function

    End Class
End Namespace