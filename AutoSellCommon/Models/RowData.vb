Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows

Public Class RowData

    Implements INotifyPropertyChanged
    Public Property Id As Guid


    Private _exchangeImageUri As String
    Public Property ExchangeImageUri() As String
        Get
            Return _exchangeImageUri
        End Get
        Set(ByVal value As String)
            _exchangeImageUri = value
            OnPropertyChanged("ExchangeImageUri")
        End Set
    End Property

    Private _symbolImageUri As String
    Public Property SymbolImageUri() As String
        Get
            Return _symbolImageUri
        End Get
        Set(ByVal value As String)
            _symbolImageUri = value
            OnPropertyChanged("SymbolImageUri")
        End Set
    End Property


    Private _symbolName As String
    Public Property SymbolName() As String
        Get
            Return _symbolName
        End Get
        Set(ByVal value As String)
            _symbolName = value
            OnPropertyChanged("SymbolName")
        End Set
    End Property

    Private _symbolNameVisibility As Visibility
    Public Property SymbolNameVisibility() As Visibility
        Get
            Return _symbolNameVisibility
        End Get
        Set(ByVal value As Visibility)
            _symbolNameVisibility = value
            OnPropertyChanged("SymbolNameVisibility")
        End Set
    End Property


    Private _paidPrice As Decimal
    Public Property PaidPrice() As Decimal
        Get
            Return _paidPrice
        End Get
        Set(ByVal value As Decimal)
            _paidPrice = value
            OnPropertyChanged("PaidPrice")
        End Set
    End Property

    Private _paidPriceVisibility As Visibility
    Public Property PaidPriceVisibility() As Visibility
        Get
            Return _paidPriceVisibility
        End Get
        Set(ByVal value As Visibility)
            _paidPriceVisibility = value
            OnPropertyChanged("PaidPriceVisibility")
        End Set
    End Property

    Private _paidPriceForecolor As System.Windows.Media.Brush
    Public Property PaidPriceForecolor() As System.Windows.Media.Brush
        Get
            Return _paidPriceForecolor
        End Get
        Set(ByVal value As System.Windows.Media.Brush)
            _paidPriceForecolor = value
            OnPropertyChanged("PaidPriceForecolor")
        End Set
    End Property


    Private _currentPrice As Decimal
    Public Property CurrentPrice() As Decimal
        Get
            Return _currentPrice
        End Get
        Set(ByVal value As Decimal)
            _currentPrice = value
            OnPropertyChanged("CurrentPrice")
        End Set
    End Property

    Private _currentPriceVisibility As Visibility
    Public Property CurrentPriceVisibility() As Visibility
        Get
            Return _currentPriceVisibility
        End Get
        Set(ByVal value As Visibility)
            _currentPriceVisibility = value
            OnPropertyChanged("CurrentPriceVisibility")
        End Set
    End Property

    Private _currentPriceForecolor As System.Windows.Media.Brush
    Public Property CurrentPriceForecolor() As System.Windows.Media.Brush
        Get
            Return _currentPriceForecolor
        End Get
        Set(ByVal value As System.Windows.Media.Brush)
            _currentPriceForecolor = value
            OnPropertyChanged("CurrentPriceForecolor")
        End Set
    End Property


    Private _plusMinusRate As Decimal
    Public Property PlusMinusRate() As Decimal
        Get
            Return _plusMinusRate
        End Get
        Set(ByVal value As Decimal)
            _plusMinusRate = value
            OnPropertyChanged("PlusMinusRate")
        End Set
    End Property

    Private _plusMinusRateVisibility As Visibility
    Public Property PlusMinusRateVisibility() As Visibility
        Get
            Return _plusMinusRateVisibility
        End Get
        Set(ByVal value As Visibility)
            _plusMinusRateVisibility = value
            OnPropertyChanged("PlusMinusRateVisibility")
        End Set
    End Property

    Private _plusMinusRateForecolor As System.Windows.Media.Brush
    Public Property PlusMinusRateForecolor() As System.Windows.Media.Brush
        Get
            Return _plusMinusRateForecolor
        End Get
        Set(ByVal value As System.Windows.Media.Brush)
            _plusMinusRateForecolor = value
            OnPropertyChanged("PlusMinusRateForecolor")
        End Set
    End Property

    Private _plusMinusPercent As Decimal
    Public Property PlusMinusPercent() As Decimal
        Get
            Return _plusMinusPercent
        End Get
        Set(ByVal value As Decimal)
            _plusMinusPercent = value
            OnPropertyChanged("PlusMinusPercent")
        End Set
    End Property

    Private _plusMinusPercentVisibility As Visibility
    Public Property PlusMinusPercentVisibility() As Visibility
        Get
            Return _plusMinusPercentVisibility
        End Get
        Set(ByVal value As Visibility)
            _plusMinusPercentVisibility = value
            OnPropertyChanged("PlusMinusPercentVisibility")
        End Set
    End Property

    Private _plusMinusPercentForecolor As System.Windows.Media.Brush
    Public Property PlusMinusPercentForecolor() As System.Windows.Media.Brush
        Get
            Return _plusMinusPercentForecolor
        End Get
        Set(ByVal value As System.Windows.Media.Brush)
            _plusMinusPercentForecolor = value
            OnPropertyChanged("PlusMinusPercentForecolor")
        End Set
    End Property

    Private _statusMessage As String
    Public Property StatusMessage() As String
        Get
            Return _statusMessage
        End Get
        Set(ByVal value As String)
            _statusMessage = value
            OnPropertyChanged("StatusMessage")
        End Set
    End Property

    Private _statusMessageVisibility As Visibility
    Public Property StatusMessageVisibility() As Visibility
        Get
            Return _statusMessageVisibility
        End Get
        Set(ByVal value As Visibility)
            _statusMessageVisibility = value
            OnPropertyChanged("StatusMessageVisibility")
        End Set
    End Property

    Private _statusMessageForecolor As System.Windows.Media.Brush
    Public Property StatusMessageForecolor() As System.Windows.Media.Brush
        Get
            Return _statusMessageForecolor
        End Get
        Set(ByVal value As System.Windows.Media.Brush)
            _statusMessageForecolor = value
            OnPropertyChanged("StatusMessageForecolor")
        End Set
    End Property

    Private _buttonText As String
    Public Property ButtonText() As String
        Get
            Return _buttonText
        End Get
        Set(ByVal value As String)
            _buttonText = value
            OnPropertyChanged("ButtonText")
        End Set
    End Property

    Private _buttonTextVisibility As Visibility
    Public Property ButtonTextVisibility() As Visibility
        Get
            Return _buttonTextVisibility
        End Get
        Set(ByVal value As Visibility)
            _buttonTextVisibility = value
            OnPropertyChanged("ButtonTextVisibility")
        End Set
    End Property


    Public Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

End Class
