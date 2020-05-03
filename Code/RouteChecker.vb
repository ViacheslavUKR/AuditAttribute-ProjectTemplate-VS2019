Imports Microsoft.AspNetCore.Mvc.Filters
Imports Microsoft.Extensions.Logging
Imports Microsoft.Extensions.Logging.Console

Public Class RouteChecker
    Implements IActionFilter

    'Called before the action executes, after model binding is complete.
    Private Sub IActionFilter_OnActionExecuting(context As ActionExecutingContext) Implements IActionFilter.OnActionExecuting

    End Sub

    'Called after the action executes, before the action result.
    Private Sub IActionFilter_OnActionExecuted(context As ActionExecutedContext) Implements IActionFilter.OnActionExecuted

    End Sub


End Class
