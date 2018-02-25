Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports AutoSellCommon

Public Class Form1

    Private _taskCount As Integer
    Private _isRunning As Boolean
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If _isRunning = True Then Exit Sub

        _isRunning = True

        Dim bgUpdateAndSell As New BackgroundWorker
        bgUpdateAndSell.WorkerReportsProgress = True
        bgUpdateAndSell.WorkerSupportsCancellation = True
        AddHandler bgUpdateAndSell.DoWork, AddressOf UpdateAndSell_DoWork
        bgUpdateAndSell.RunWorkerAsync()

        Dim bgWaiting As New BackgroundWorker
        bgWaiting.WorkerReportsProgress = True
        bgWaiting.WorkerSupportsCancellation = True
        AddHandler bgWaiting.DoWork, AddressOf Waiting_DoWork
        AddHandler bgWaiting.RunWorkerCompleted, AddressOf Waiting_Completed
        bgWaiting.RunWorkerAsync()
    End Sub

    Private Sub Waiting_Completed(sender As Object, e As RunWorkerCompletedEventArgs)
        RowData1.UpdateModel(OrdersManager.ReturnActiveOrders)
        _isRunning = False
    End Sub
    Private Sub Waiting_DoWork(sender As Object, e As DoWorkEventArgs)
        Do
            Threading.Thread.Sleep(500)
        Loop Until _taskCount <= 0
    End Sub

    Private Sub UpdateAndSell_DoWork(sender As Object, e As DoWorkEventArgs)

        Try

            _taskCount = OrdersManager.ReturnActiveOrders.Count

            For Each item In OrdersManager.ReturnActiveOrders
                Task.Factory.StartNew(Sub() RandomPrice(item))
            Next


        Catch ex As Exception
        Finally
        End Try

    End Sub

    Private _lockObject As New Object

    Private Sub RandomPrice(item As CryptoObject)

        Dim rnd As New Random(DateTime.Now.Millisecond)
        item.CurrentRateUSD = rnd.Next(1.34, 6.98)

        Threading.Thread.Sleep(600)

        SyncLock _lockObject
            _taskCount = _taskCount - 1
        End SyncLock

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        OrdersManager.LoadOrders()

        Dim lst As New ObservableCollection(Of RowData)

        For Each item In OrdersManager.ReturnActiveOrders

            Dim buildRowManager As New BuildRowDataManager(item)
            lst.Add(buildRowManager.ReturnRowDataObject)

        Next

        RowData1.SetActiveData(lst)

    End Sub
End Class
