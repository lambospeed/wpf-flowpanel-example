Imports System.Collections.ObjectModel

Public Class UIHelper


    Public Shared Function FindVisualChild(Of childItem As DependencyObject)(ByVal obj As DependencyObject) As childItem
        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(obj) - 1
            Dim child As DependencyObject = VisualTreeHelper.GetChild(obj, i)
            If child IsNot Nothing AndAlso TypeOf child Is childItem Then
                Return CType(child, childItem)
            Else
                Dim childOfChild As childItem = FindVisualChild(Of childItem)(child)
                If childOfChild IsNot Nothing Then
                    Return childOfChild
                End If
            End If
        Next i
        Return Nothing
    End Function

    Public Shared Function FindAncestorOrSelf(Of T As DependencyObject)(obj As DependencyObject, Optional controlName As String = "") As T
        While obj IsNot Nothing
            Dim objTest As T = TryCast(obj, T)
            If objTest IsNot Nothing Then
                If Not String.IsNullOrEmpty(controlName) Then
                    Dim frameworkElement = TryCast(objTest, FrameworkElement)
                    If frameworkElement.Name = controlName Then
                        Return objTest
                    End If
                Else
                    Return objTest
                End If
            End If
            obj = GetParent(obj)
        End While

        Return Nothing
    End Function

    Public Shared Function GetParent(obj As DependencyObject) As DependencyObject
        If obj Is Nothing Then
            Return Nothing
        End If

        Dim ce As ContentElement = TryCast(obj, ContentElement)
        If ce IsNot Nothing Then
            Dim parent As DependencyObject = ContentOperations.GetParent(ce)
            If parent IsNot Nothing Then
                Return parent
            End If

            Dim fce As FrameworkContentElement = TryCast(ce, FrameworkContentElement)
            Return If(fce IsNot Nothing, fce.Parent, Nothing)
        End If

        Return VisualTreeHelper.GetParent(obj)
    End Function

    ''' <summary> 
    ''' Finds a Child of a given item in the visual tree.  
    ''' </summary> 
    ''' <param name="parent">A direct parent of the queried item.</param> 
    ''' <typeparam name="T">The type of the queried item.</typeparam> 
    ''' <param name="childName">x:Name or Name of child. </param> 
    ''' <returns>The first parent item that matches the submitted type parameter.  
    ''' If not matching item can be found, a null parent is being returned.</returns> 
    Public Shared Function FindChild(Of T As DependencyObject)(parent As DependencyObject, childName As String, contains As Boolean) As T
        ' Confirm parent and childName are valid.  
        If parent Is Nothing Then
            Return Nothing
        End If

        Dim foundChild As T = Nothing

        Dim childrenCount As Integer = VisualTreeHelper.GetChildrenCount(parent)
        For i As Integer = 0 To childrenCount - 1
            Dim child = VisualTreeHelper.GetChild(parent, i)
            ' If the child is not of the request child type child 
            Dim childType As T = TryCast(child, T)
            If childType Is Nothing Then
                ' recursively drill down the tree 
                foundChild = FindChild(Of T)(child, childName, contains)

                ' If the child is found, break so we do not overwrite the found child.  
                If foundChild IsNot Nothing Then
                    Exit For
                End If
            ElseIf Not String.IsNullOrEmpty(childName) Then
                Dim frameworkElement = TryCast(child, FrameworkElement)
                ' If the child's name is set for search 
                If contains = True Then
                    If frameworkElement IsNot Nothing AndAlso frameworkElement.Name.Contains(childName) Then
                        ' if the child's name is of the request name 
                        foundChild = DirectCast(child, T)
                        Exit For
                    End If
                Else
                    If frameworkElement IsNot Nothing AndAlso frameworkElement.Name = childName Then
                        ' if the child's name is of the request name 
                        foundChild = DirectCast(child, T)
                        Exit For
                        'Added else loop for  recursively drill down the tree
                    Else
                        ' recursively drill down the tree
                        foundChild = FindChild(Of T)(child, childName, False)

                        ' If the child is found, break so we do not overwrite the found child.
                        If foundChild IsNot Nothing Then
                            Exit For
                        End If
                    End If


                End If
            Else
                ' child element found. 
                foundChild = DirectCast(child, T)
                Exit For
            End If
        Next

        Return foundChild
    End Function



End Class
