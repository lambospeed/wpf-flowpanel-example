Imports System.ComponentModel
Imports System.Globalization

Public Class EnumToStringUsingDescription
    Inherits TypeConverter

    Public Overrides Function CanConvertFrom(context As ITypeDescriptorContext, sourceType As Type) As Boolean
        Return (sourceType.Equals(GetType([Enum])))
    End Function

    Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
        Return (destinationType.Equals(GetType([String])))
    End Function

    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As CultureInfo, value As Object) _
        As Object
        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object,
                                         destinationType As Type) As Object
        If Not destinationType.Equals(GetType([String])) Then
            Throw New ArgumentException("Can only convert to string.", "destinationType")
        End If

        If Not value.[GetType]().BaseType.Equals(GetType([Enum])) Then
            Throw New ArgumentException("Can only convert an instance of enum.", "value")
        End If

        Dim name As String = value.ToString()
        Dim _
            attrs As Object() =
                value.[GetType]().GetField(name).GetCustomAttributes(GetType(DescriptionAttribute), False)
        Return If((attrs.Length > 0), DirectCast(attrs(0), DescriptionAttribute).Description, name)
    End Function
End Class

