Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Authorization
Imports Newtonsoft.Json

<Route("[controller]")>
<ApiController>
<ServiceFilter(GetType(AuditAttribute))>
Public Class TestController
    Inherits ControllerBase

    Public Function Index() As ActionResult
        Dim D As New ObjectDumper
        Dim Str1 As String = D.Dump(3, Request)
        Return Content(String.Format("<html><body><img src='asp_net_core_3_1_vb_GDH_icon.ico'><pre>{0}</pre></body></html>", Str1), "text/html")
    End Function
End Class
