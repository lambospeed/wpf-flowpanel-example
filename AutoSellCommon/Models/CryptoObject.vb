Imports System.Xml.Serialization

<Serializable>
Public Class CryptoObject

    Public Property ID As Guid
    Public Property Exchange As Enums.Exchange

    Public Property SellType As Enums.SellType

    Public Property Target1 As Decimal
    Public Property Target2 As Decimal
    Public Property Target3 As Decimal
    Public Property Target4 As Decimal

    Public Property UseTargetsInstreadOfPercentages As Boolean = False

    Public Property SellAllAtTarget As String

    Public Property SellAllAtTargetAndAfterReaching As String

    Public Property Symbol As String

    <XmlIgnore>
    Public Property OrderFormAmount As Decimal 'this is only for the testing object

    <XmlIgnore>
    Public Property IsSelling As Boolean

    <XmlIgnore>
    Public Property TestingSellAmount As Decimal 'this is only for the testing object

    Public Property StartingAmount As Decimal
    Public Property CurrentAmount As Decimal

    Public Property UsedTargets As String = ""

    Public Property CurrentRateUSD As Decimal
    Public Property CurrentRateBTC As Decimal

    Public Property MaxPercentageReached As Decimal
    Public Property MaxBTCReached As Decimal

    Public Property TradeAtRateBTC As Decimal
    Public Property TradeAtRateUSD As Decimal

    Public Property TradeAtDateTime As DateTime

    'ordering
    Public Property OrderID As String
    Public Property OrderCompleted As Boolean

    Public Property IsActive As Boolean
    Public Property IsParent As Boolean
    Public Property IsBuyObject As Boolean

    <XmlIgnore>
    Public Property IsRunning As Boolean

    Public Property LastAutoSellTime As DateTime
    Public Property SoldAllTime As DateTime


End Class
