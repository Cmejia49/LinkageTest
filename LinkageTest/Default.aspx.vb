Imports System.Globalization

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblResult.Text = String.Empty
        End If
    End Sub

    Protected Sub btnConvert_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Not Page.IsValid Then
            lblResult.Text = String.Empty
            Return
        End If

        Dim amount As Decimal

        If Not Decimal.TryParse(txtAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, amount) AndAlso
           Not Decimal.TryParse(txtAmount.Text, amount) Then

            lblResult.Text = "Unable to parse the amount."
            Return
        End If

        If amount < 0D Then
            lblResult.Text = "Please enter a positive amount."
            Return
        End If

        If amount > CDec(999999.99) Then
            lblResult.Text = "Amount is too large to convert (max 999,999.99)."
            Return
        End If

        Dim words As String = ConvertAmount(amount)
        lblResult.Text = words
    End Sub

    ' ----------------- Helper methods -----------------

    Private Function ConvertAmount(amount As Decimal) As String
        Dim rounded As Decimal = Decimal.Round(amount, 2, MidpointRounding.AwayFromZero)

        Dim pesos As Long = CLng(Math.Truncate(rounded))
        Dim cents As Integer = CInt((rounded - pesos) * CDec(100))

        Dim words As String

        If pesos = 0L Then
            words = "zero"
        Else
            words = NumberToWords(pesos)
        End If

        words = CapitalizeFirst(words) &
                " and " &
                cents.ToString("00") &
                "/100 pesos"

        Return words
    End Function

    Private Function NumberToWords(number As Long) As String
        If number = 0L Then
            Return "zero"
        End If

        Dim parts As New List(Of String)()

        If number >= 1000L Then
            Dim thousands As Long = number \ 1000L
            parts.Add(NumberToWords(thousands) & " thousand")
            number = number Mod 1000L
        End If

        If number >= 100L Then
            Dim hundreds As Long = number \ 100L
            parts.Add(Ones(hundreds) & " hundred")
            number = number Mod 100L
        End If

        If number > 0L Then
            If number < 20L Then
                parts.Add(Ones(number))
            Else
                Dim t As Long = number \ 10L
                Dim u As Long = number Mod 10L

                Dim chunk As String = Tens(t)
                If u > 0L Then
                    chunk &= "-" & Ones(u)
                End If

                parts.Add(chunk)
            End If
        End If

        Return String.Join(" "c, parts)
    End Function

    Private Function CapitalizeFirst(input As String) As String
        If String.IsNullOrEmpty(input) Then
            Return input
        End If

        If input.Length = 1 Then
            Return input.ToUpperInvariant()
        End If

        Return Char.ToUpperInvariant(input(0)) & input.Substring(1)
    End Function

    Private Shared ReadOnly Ones() As String = {
        "zero", "one", "two", "three", "four",
        "five", "six", "seven", "eight", "nine",
        "ten", "eleven", "twelve", "thirteen", "fourteen",
        "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
    }

    Private Shared ReadOnly Tens() As String = {
        "", "", "twenty", "thirty", "forty",
        "fifty", "sixty", "seventy", "eighty", "ninety"
    }
End Class