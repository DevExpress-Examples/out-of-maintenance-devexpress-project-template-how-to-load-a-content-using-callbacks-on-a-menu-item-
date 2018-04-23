Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections

Namespace MenuExample.Models
    ' DXCOMMENT: Configure a data model (In this sample, we do this in file NorthwindDataProvider.cs. You would better create your custom file for a data model.)
    Public NotInheritable Class NorthwindDataProvider

        Private Sub New()
        End Sub
        Private Const NorthwindDataContextKey As String = "DXNorthwindDataContext"

        Public Shared ReadOnly Property DB() As NorthwindDataContext
            Get
                If HttpContext.Current.Items(NorthwindDataContextKey) Is Nothing Then
                    HttpContext.Current.Items(NorthwindDataContextKey) = New NorthwindDataContext()
                End If
                Return DirectCast(HttpContext.Current.Items(NorthwindDataContextKey), NorthwindDataContext)
            End Get
        End Property

        Public Shared Function GetCustomers() As IEnumerable
            Return From customer In DB.Customers _
                   Select customer
        End Function
    End Class
End Namespace