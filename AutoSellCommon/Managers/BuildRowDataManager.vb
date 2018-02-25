Imports System.Drawing
Imports System.Windows
Imports System.Windows.Media.Imaging

Public Class BuildRowDataManager

    Private _crypto As CryptoObject
    Sub New(crypto As CryptoObject)

        _crypto = crypto

    End Sub

    Public Function ReturnRowDataObject() As RowData

        Dim rd As New RowData With
        {
            .ButtonText = ReturnButtonText(),
            .ButtonTextVisibility = ReturnButtonTextVisibility(),
            .CurrentPrice = ReturnCurrentPrice(),
            .CurrentPriceForecolor = ReturnCurrentPriceForecolor(),
            .CurrentPriceVisibility = ReturnCurrentPriceVisibility(),
            .ExchangeImageUri = ReturnExchangeImageUri(),
            .Id = _crypto.ID,
            .SymbolName = ReturnSymbolName(),
            .SymbolNameVisibility = ReturnSymbolNameVisibility(),
            .PaidPrice = ReturnPaidPrice(),
            .PaidPriceVisibility = ReturnPaidPriceVisibility(),
            .PaidPriceForecolor = ReturnPaidPriceForecolor(),
            .PlusMinusPercent = ReturnPlusMinusPercent(),
            .PlusMinusPercentForecolor = ReturnPlusMinusPercentForecolor(),
            .PlusMinusPercentVisibility = ReturnPlusMinusPercentVisibility(),
            .PlusMinusRate = ReturnPlusMinusRate(),
            .PlusMinusRateForecolor = ReturnPlusMinusRateForecolor(),
            .PlusMinusRateVisibility = ReturnPlusMinusRateVisibility(),
            .StatusMessage = ReturnStatusMessage(),
            .StatusMessageForecolor = ReturnStatusMessageForecolor(),
            .StatusMessageVisibility = ReturnStatusMessageVisibility(),
            .SymbolImageUri = ReturnSymbolImageUri()
        }

        Return rd

    End Function

    Private Function ReturnExchangeImageUri() As String
        Return "/AutoSellCommon;component/Resources/" & Enums.GetDescription(_crypto.Exchange) & ".png"
    End Function
    Private Function ReturnSymbolImageUri() As String

        Dim ourImageName As String = "question"

        Try
            Dim ourImage = My.Resources.ResourceManager.GetObject(_crypto.Symbol)

            If ourImage Is Nothing Then
                ourImage = My.Resources.ResourceManager.GetObject("_" & _crypto.Symbol)

                If Not ourImage Is Nothing Then
                    ourImageName = "_" & _crypto.Symbol
                End If

            Else
                ourImageName = _crypto.Symbol

            End If

        Catch ex As Exception

        End Try

        Return "/AutoSellCommon;component/Resources/" & ourImageName & ".png"


    End Function

    Private Function ReturnSymbolName() As String
        Return _crypto.Symbol.ToUpper
    End Function
    Private Function ReturnSymbolNameVisibility() As Visibility
        Return Visibility.Visible
    End Function

    Private Function ReturnPaidPrice() As String
        Return _crypto.TradeAtRateUSD
    End Function
    Private Function ReturnPaidPriceVisibility() As Visibility
        Return Visibility.Visible
    End Function
    Private Function ReturnPaidPriceForecolor() As System.Windows.Media.Brush
        Return System.Windows.Media.Brushes.Green
    End Function
    Private Function ReturnCurrentPrice() As String
        Return _crypto.CurrentRateUSD
    End Function
    Private Function ReturnCurrentPriceVisibility() As Visibility
        Return Visibility.Visible
    End Function
    Private Function ReturnCurrentPriceForecolor() As System.Windows.Media.Brush
        Return System.Windows.Media.Brushes.Green
    End Function

    Private Function ReturnPlusMinusRate() As String
        'Return _crypto.CurrentRateUSD
    End Function
    Private Function ReturnPlusMinusRateVisibility() As Visibility
        Return Visibility.Visible
    End Function
    Private Function ReturnPlusMinusRateForecolor() As System.Windows.Media.Brush
        Return System.Windows.Media.Brushes.Green
    End Function

    Private Function ReturnPlusMinusPercent() As String
        'Return _crypto.CurrentRateUSD
    End Function
    Private Function ReturnPlusMinusPercentVisibility() As Visibility
        Return Visibility.Visible
    End Function
    Private Function ReturnPlusMinusPercentForecolor() As System.Windows.Media.Brush
        Return System.Windows.Media.Brushes.Green
    End Function

    Private Function ReturnStatusMessage() As String
        'Return _crypto.CurrentRateUSD
    End Function
    Private Function ReturnStatusMessageVisibility() As Visibility
        Return Visibility.Hidden
    End Function
    Private Function ReturnStatusMessageForecolor() As System.Windows.Media.Brush
        Return System.Windows.Media.Brushes.Orange
    End Function


    Private Function ReturnButtonText() As String
        'Return _crypto.CurrentRateUSD
    End Function
    Private Function ReturnButtonTextVisibility() As Visibility
        Return Visibility.Visible
    End Function


End Class
