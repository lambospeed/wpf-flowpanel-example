Imports System.Collections.ObjectModel
Imports AutoSellCommon

Public Class RowData

    Public Event RowOpened(ByVal id As String)

    Public RowViewModel As New RowViewModel

    Public Sub SetActiveData(lst As ObservableCollection(Of AutoSellCommon.RowData))

        RowViewModel.Items = lst
        rowItemsControl.ItemsSource = RowViewModel.Items

    End Sub

    Public Sub UpdateModel(ByVal items As List(Of CryptoObject))

        Try
            Using Dispatcher.DisableProcessing()

                For Each item In items

                    Dim found = (From x In RowViewModel.Items Where x.Id = item.ID).FirstOrDefault
                    If Not found Is Nothing Then
                        Dim brm As New BuildRowDataManager(item)
                        Dim updatedModel = brm.ReturnRowDataObject

                        With found
                            .ButtonText = updatedModel.ButtonText
                            .ButtonTextVisibility = updatedModel.ButtonTextVisibility
                            .CurrentPrice = updatedModel.CurrentPrice
                            .CurrentPriceForecolor = updatedModel.CurrentPriceForecolor
                            .CurrentPriceVisibility = updatedModel.CurrentPriceVisibility
                            .ExchangeImageUri = updatedModel.ExchangeImageUri
                            .Id = updatedModel.Id
                            .SymbolName = updatedModel.SymbolName
                            .SymbolNameVisibility = updatedModel.SymbolNameVisibility
                            .PaidPrice = updatedModel.PaidPrice
                            .PaidPriceVisibility = updatedModel.PaidPriceVisibility
                            .PlusMinusPercent = updatedModel.PlusMinusPercent
                            .PlusMinusPercentForecolor = updatedModel.PlusMinusPercentForecolor
                            .PlusMinusPercentVisibility = updatedModel.PlusMinusPercentVisibility
                            .PlusMinusRate = updatedModel.PlusMinusRate
                            .PlusMinusRateForecolor = updatedModel.PlusMinusRateForecolor
                            .PlusMinusRateVisibility = updatedModel.PlusMinusRateVisibility
                            .StatusMessage = updatedModel.StatusMessage
                            .StatusMessageForecolor = updatedModel.StatusMessageForecolor
                            .StatusMessageVisibility = updatedModel.StatusMessageVisibility
                            .SymbolImageUri = updatedModel.SymbolImageUri
                        End With

                    End If

                Next

            End Using

        Catch ex As Exception
        Finally

        End Try

    End Sub

    Private Sub RowDetail_Open(sender As Object, e As MouseButtonEventArgs)

        If (e.ClickCount = 2) Then
            Dim rowIdLabel As Label = UIHelper.FindChild(Of Label)(sender, "Id", False)
            Dim rowId As String = rowIdLabel.Content.ToString

            If Not String.IsNullOrEmpty(rowId) Then RaiseEvent RowOpened(rowId)

        End If

    End Sub
End Class
