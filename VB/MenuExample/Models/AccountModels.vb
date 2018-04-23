Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Globalization
Imports System.Web.Mvc
Imports System.Web.Security

Namespace MenuExample.Models
		Public Class UsersContext
			Inherits DbContext
		Public Sub New()
			MyBase.New("DefaultConnection")
		End Sub
		Private privateUserProfiles As DbSet(Of UserProfile)
		Public Property UserProfiles() As DbSet(Of UserProfile)
			Get
				Return privateUserProfiles
			End Get
			Set(ByVal value As DbSet(Of UserProfile))
				privateUserProfiles = value
			End Set
		End Property
		End Class
	<Table("UserProfile")> _
	Public Class UserProfile
		Private privateUserId As Integer
		<Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
		Public Property UserId() As Integer
			Get
				Return privateUserId
			End Get
			Set(ByVal value As Integer)
				privateUserId = value
			End Set
		End Property
		Private privateUserName As String
		Public Property UserName() As String
			Get
				Return privateUserName
			End Get
			Set(ByVal value As String)
				privateUserName = value
			End Set
		End Property
	End Class


    Public Class ChangePasswordModel

        Private privateOldPassword As String
        <Required, DataType(DataType.Password), Display(Name:="Current password")> _
        Public Property OldPassword() As String
            Get
                Return privateOldPassword
            End Get
            Set(ByVal value As String)
                privateOldPassword = value
            End Set
        End Property

        <Required, StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6), DataType(DataType.Password), Display(Name:="New password")> _
        Public Property NewPassword() As String
            Get
            End Get
            Set(ByVal value As String)
            End Set


        End Property
        <DataType(DataType.Password), Display(Name:="Confirm new password"), System.Web.Mvc.Compare("NewPassword", ErrorMessage:="The new password and confirmation password do not match.")> _
        Public Property ConfirmPassword As String
            Get

            End Get
            Set(value As String)

            End Set
        End Property
    End Class


    Public Class LoginModel
        Private privateUserName As String
        <Required, Display(Name:="User name")> _
        Public Property UserName() As String
            Get
                Return privateUserName
            End Get
            Set(ByVal value As String)
                privateUserName = value
            End Set
        End Property

        Private privatePassword As String
        <Required, DataType(DataType.Password), Display(Name:="Password")> _
        Public Property Password() As String
            Get
                Return privatePassword
            End Get
            Set(ByVal value As String)
                privatePassword = value
            End Set
        End Property


        <Display(Name:="Remember me?")> _
        Public Property RememberMe() As Boolean?
            Get
                Return If(RememberMe, False)
            End Get
            Set(ByVal value As Boolean?)

            End Set
        End Property
    End Class

    Public Class RegisterModel
        Private privateUserName As String
        <Required, Display(Name:="User name")> _
        Public Property UserName() As String
            Get
                Return privateUserName
            End Get
            Set(ByVal value As String)
                privateUserName = value
            End Set
        End Property

        Private privateEmail As String
        <Required, DataType(DataType.EmailAddress), Display(Name:="Email address")> _
        Public Property Email() As String
            Get
                Return privateEmail
            End Get
            Set(ByVal value As String)
                privateEmail = value
            End Set
        End Property

        <Required, StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6), DataType(DataType.Password), Display(Name:="Password")> _
        Public Property Password() As String
            Get

            End Get
            Set(ByVal value As String)
            End Set
        End Property

        <DataType(DataType.Password), Display(Name:="Confirm password"), System.Web.Mvc.Compare("Password", ErrorMessage:="The password and confirmation password do not match.")> _
        Public Property ConfirmPassword As String
            Get

            End Get
            Set(ByVal value As String)

            End Set
        End Property
    End Class
End Namespace