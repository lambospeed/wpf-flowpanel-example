Imports System.Runtime.CompilerServices
Imports System.Windows.Media.Color
Imports System.Drawing.Color

Module Extensions

    <Extension()>
    Public Function ToMediaColor(ByVal c As System.Drawing.Color) As System.Windows.Media.Color
        Return System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B)
    End Function

End Module

