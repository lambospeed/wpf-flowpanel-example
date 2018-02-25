Imports System.ComponentModel

Public Class Enums

    <TypeConverter(GetType(EnumToStringUsingDescription))>
    Public Enum Exchange
        Binance
        Bittrex
    End Enum

    Public Enum SellType
        ShortTerm
        MidTerm
        LongTerm
    End Enum

    <TypeConverter(GetType(EnumToStringUsingDescription))>
    Public Enum DateFilterRange
        Today
        Yesterday
        Tommorrow
        <Description("Two Days Ago")>
        TwoDaysAgo
        <Description("Three Days Ago")>
        ThreeDaysAgo
        <Description("This Week")>
        ThisWeek
        <Description("This Year")>
        ThisYear
        <Description("This Month")>
        ThisMonth
        <Description("This Month-Today")>
        ThisMonthToday
        <Description("Last Week")>
        LastWeek
        <Description("Last Two Weeks")>
        LastTwoWeeks
        <Description("Last Month")>
        LastMonth
        <Description("Last 60 Days")>
        Last60Days
        <Description("Last Year")>
        LastYear
        <Description("Last Quarter")>
        LastQuarter
        <Description("Next Week")>
        NextWeek
        <Description("Next 2 Weeks")>
        Next2Weeks
        <Description("Next Month")>
        NextMonth
        <Description("Remaining Year")>
        RemainingYear
        January
        February
        March
        April
        May
        June
        July
        August
        September
        October
        November
        December
        <Description("<All>")>
        All
        <Description("<Custom>")>
        Custom
    End Enum

    Public Shared Function GetDescription(en As [Enum]) As String
        Dim attrs As Object() = en.[GetType]().GetField(en.ToString).GetCustomAttributes(GetType(DescriptionAttribute), False)
        Return If((attrs.Length > 0), DirectCast(attrs(0), DescriptionAttribute).Description, en.ToString)
    End Function

    Public Shared Function ReturnEnumFromDescription(Of T)(ByVal descriptionString As String) As [Enum]

        'Dim enumList As System.Collections.IList = Assembly.GetExecutingAssembly().GetTypes().Where(Function(t) t.IsEnum AndAlso t.IsPublic).ToList
        'For Each t As [Enum] In enumList
        '    If GetDescription(t) = descriptionString Then
        '        Return t
        '    End If
        'Next

        'foreach(MyEnum target in Enum.GetValues(typeof(MyEnum)))
        '   {
        '       Console.WriteLine(target.ToString());
        '       // You can obviously perform an action on each one here.
        '   }

        Dim enumType As Type = GetType(T)
        Dim returnedEnum As [Enum] = Nothing

        ' Can't use type constraints on value types, so have to do check like this
        If enumType.BaseType() IsNot GetType([Enum]) Then
            Throw New ArgumentException("T must be of type System.Enum")
        End If

        For Each item As String In [Enum].GetNames(enumType)
            If ([Enum].IsDefined(enumType, item)) Then
                returnedEnum = [Enum].Parse(enumType, item)
                If GetDescription(returnedEnum) = descriptionString Then
                    Return returnedEnum
                End If
            End If
        Next

        Return returnedEnum

    End Function

End Class
