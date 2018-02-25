Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Xml.Serialization

Public Class OrdersManager

    Public Shared OrderList As List(Of CryptoObject)
    Public Shared RunningActiveList As New ObservableCollection(Of RowData)

    Private Shared Function ReturnOrderFilePath() As String
        If IsTestMode = True Then
            Dim orderFile As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Orders-Testing.xml")
            Return orderFile
        Else
            Dim orderFile As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Orders.xml")
            Return orderFile
        End If
    End Function


    Public Shared Sub LoadOrders()

        OrderList = New List(Of CryptoObject)

        Dim serializer As XmlSerializer = New XmlSerializer(GetType(List(Of CryptoObject)))

        Dim orderFile As String = ReturnOrderFilePath()
        If Not System.IO.File.Exists(orderFile) Then Exit Sub
        Using reader As StreamReader = New StreamReader(orderFile)
            OrderList = New XmlSerializer(GetType(List(Of CryptoObject))).Deserialize(reader)
        End Using

    End Sub

    Public Shared Function ReturnActiveOrders() As List(Of CryptoObject)

        Dim openOrders = (From x In OrderList Where x.IsActive = True AndAlso
                                                  x.IsParent = True AndAlso
                                                  x.IsBuyObject = True).ToList

        Return openOrders

    End Function


    Public Shared Function ReturnCompletedOrders(range As Enums.DateFilterRange,
                                                  startDate? As DateTime,
                                                  endDate? As DateTime) As List(Of CryptoObject)

        If range = Enums.DateFilterRange.Today Then

            startDate = DateTime.Today
            endDate = DateTime.Today.AddDays(1).AddTicks(-1)

        End If


        If startDate Is Nothing AndAlso endDate Is Nothing OrElse startDate = DateTime.MinValue Then
            Dim openOrders = (From x In OrderList Where x.IsActive = False AndAlso
                                                      x.IsParent = True AndAlso
                                                      x.IsBuyObject = True AndAlso
                                                      x.OrderCompleted = True).ToList

            Return openOrders
        Else
            Dim openOrders = (From x In OrderList Where x.IsActive = False AndAlso
                                                      x.IsParent = True AndAlso
                                                      x.IsBuyObject = True AndAlso
                                                      x.OrderCompleted = True AndAlso
                                                      x.SoldAllTime >= startDate AndAlso x.SoldAllTime <= endDate).ToList

            Return openOrders
        End If



    End Function

    Public Shared Sub SaveOrders()
        'save to disk

        If OrderList Is Nothing Then Exit Sub 'must have been some bad error, dont want to overwrite our save

        Dim orderFile As String = ReturnOrderFilePath()

        'If OrderList.Count = 0 Then Exit Sub

        Dim writer As XmlSerializer = New XmlSerializer(GetType(List(Of CryptoObject)))
        Using file As New System.IO.StreamWriter(orderFile)
            writer.Serialize(file, OrderList)
            file.Close()
        End Using
    End Sub

End Class
