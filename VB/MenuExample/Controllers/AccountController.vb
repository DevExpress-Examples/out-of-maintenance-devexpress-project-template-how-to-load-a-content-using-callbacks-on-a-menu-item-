Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Security
Imports WebMatrix.WebData
Imports MenuExample.Filters
Imports MenuExample.Models
Imports MenuExample.Models.ChangePasswordModel

Namespace MenuExample.Controllers
    <Authorize, InitializeSimpleMembership> _
    Public Class AccountController
        Inherits Controller

        '
        ' GET: /Account/Login
        <AllowAnonymous> _
        Public Function Login() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Account/Login

        <HttpPost, AllowAnonymous, ValidateAntiForgeryToken> _
        Public Function Login(ByVal model As LoginModel, ByVal returnUrl As String) As ActionResult
            If ModelState.IsValid Then
                If WebSecurity.Login(model.UserName, model.Password, persistCookie:=model.RememberMe.Value) Then
                    Return Redirect(If(returnUrl, "/"))
                End If
                ModelState.AddModelError("", "The user name or password provided is incorrect.")
            End If

            ' If we got this far, something failed, redisplay form
            Return View(model)
        End Function

        '
        ' GET: /Account/LogOff

        Public Function LogOff() As ActionResult
            WebSecurity.Logout()
            Return RedirectToAction("Index", "Home")
        End Function

        '
        ' GET: /Account/Register

        <AllowAnonymous> _
        Public Function Register() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Account/Register

        <HttpPost, AllowAnonymous, ValidateAntiForgeryToken> _
        Public Function Register(ByVal model As RegisterModel) As ActionResult
            If ModelState.IsValid Then
                ' Attempt to register the user
                Try
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password)
                    WebSecurity.Login(model.UserName, model.Password)
                    Return RedirectToAction("Index", "Home")
                Catch e As MembershipCreateUserException
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode))
                End Try
            End If

            ' If we got this far, something failed, redisplay form
            Return View(model)
        End Function

        '
        ' GET: /Account/ChangePassword

        Public Function ChangePassword() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Account/ChangePassword

        <HttpPost, ValidateAntiForgeryToken> _
        Public Function ChangePassword(ByVal model As ChangePasswordModel) As ActionResult
            If ModelState.IsValid Then
                Dim changePasswordSucceeded As Boolean
                Try
                    changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword)
                Catch e1 As Exception
                    changePasswordSucceeded = False
                End Try
                If changePasswordSucceeded Then
                    Return RedirectToAction("ChangePasswordSuccess")
                Else
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.")
                End If

            End If

            ' If we got this far, something failed, redisplay form
            Return View(model)
        End Function

        '
        ' GET: /Account/ChangePasswordSuccess

        Public Function ChangePasswordSuccess() As ActionResult
            Return View()
        End Function

#Region "Status Codes"
        Private Shared Function ErrorCodeToString(ByVal createStatus As MembershipCreateStatus) As String
            ' See http://go.microsoft.com/fwlink/?LinkID=177550 for
            ' a full list of status codes.
            Select Case createStatus
                Case MembershipCreateStatus.DuplicateUserName
                    Return "User name already exists. Please enter a different user name."

                Case MembershipCreateStatus.DuplicateEmail
                    Return "A user name for that e-mail address already exists. Please enter a different e-mail address."

                Case MembershipCreateStatus.InvalidPassword
                    Return "The password provided is invalid. Please enter a valid password value."

                Case MembershipCreateStatus.InvalidEmail
                    Return "The e-mail address provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.InvalidAnswer
                    Return "The password retrieval answer provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.InvalidQuestion
                    Return "The password retrieval question provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.InvalidUserName
                    Return "The user name provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.ProviderError
                    Return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

                Case MembershipCreateStatus.UserRejected
                    Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

                Case Else
                    Return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
            End Select
        End Function
#End Region
    End Class
End Namespace