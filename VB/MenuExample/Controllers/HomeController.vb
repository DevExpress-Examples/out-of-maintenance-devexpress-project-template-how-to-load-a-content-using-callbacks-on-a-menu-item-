Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports MenuExample.Models

Namespace MenuExample.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			' DXCOMMENT: Pass a data model for GridView
			Return View()
		End Function

		Public Function GridViewPartialView() As ActionResult
			' DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
			Return PartialView("GridViewPartialView", NorthwindDataProvider.GetCustomers())
		End Function
		Public Function CallbackPanelPartial(ByVal view As String) As ActionResult
			ViewData("view") = view
			Return PartialView()
		End Function
		Public Function GridViewCategoriesPartial() As ActionResult

			Return PartialView(NorthwindDataProvider.DB.Categories)
		End Function
		Public Function GridViewProductsPartial() As ActionResult
			Return PartialView(NorthwindDataProvider.DB.Products)
		End Function
	End Class
End Namespace