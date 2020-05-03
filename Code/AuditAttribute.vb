Imports System.Text
Imports Microsoft.AspNetCore.Mvc.Filters
Imports Microsoft.Extensions.Logging

Public Class AuditAttribute
    Inherits Attribute
    Implements IResourceFilter

    Private _logger As ILogger

    Public Sub New(ByVal loggerFactory As ILoggerFactory)
        _logger = loggerFactory.CreateLogger("AuditAttribute")
    End Sub

    'Called before the action executes, after model binding is complete.
    Public Sub OnResourceExecuting(ByVal context As ResourceExecutingContext) Implements IResourceFilter.OnResourceExecuting
        Dim Headers As New StringBuilder
        context.HttpContext.Request.Headers.ToList.ForEach(Sub(X) Headers.Append(String.Format("{0}={1},", X.Key, X.Value)))
        _logger.LogInformation($"OnResourceExecuting - {DateTime.Now}, Headers={Headers.ToString}")
    End Sub

    'Called after the action executes, before the action result.
    Public Sub OnResourceExecuted(ByVal context As ResourceExecutedContext) Implements IResourceFilter.OnResourceExecuted
        _logger.LogInformation($"OnResourceExecuted - {DateTime.Now}, ContentType= {context.HttpContext.Response.ContentType}, ContentLength={context.HttpContext.Response.ContentLength}")
    End Sub



End Class
