Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Logging
Imports Microsoft.Extensions.Options
Imports Microsoft.AspNetCore.Authentication
Imports Microsoft.Extensions.Hosting
Imports Newtonsoft.Json
Imports Microsoft.AspNetCore.HttpOverrides
Imports Microsoft.AspNetCore.Http
Imports Microsoft.Extensions.Logging.Console

Public Class Startup

    Public ReadOnly Property _Configuration As IConfiguration
    Public Sub New(ByVal configuration As IConfiguration)
        _Configuration = configuration
    End Sub

    Public Sub ConfigureServices(ByVal services As IServiceCollection)
        services.AddScoped(GetType(AuditAttribute))

        services.AddMvc(Sub(opt)
                            opt.EnableEndpointRouting = False
                            opt.Filters.Add(New RouteChecker())
                        End Sub).
            SetCompatibilityVersion(CompatibilityVersion.Latest)

    End Sub


    Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IHostEnvironment, logger As ILogger(Of Startup))
        If env.IsDevelopment() Then
            app.UseDeveloperExceptionPage()
        End If
        app.UseForwardedHeaders(New ForwardedHeadersOptions With {    'headers for ngins reversy proxy
                .ForwardedHeaders = ForwardedHeaders.XForwardedFor Or ForwardedHeaders.XForwardedProto
        })
        app.UseStaticFiles()
        app.UseRouting()
        app.UseMvc()
        app.UseEndpoints(Sub(endpoints)
                             endpoints.MapGet("/", Async Function(context)
                                                       logger.LogInformation("ContentRootPath=" & env.ContentRootPath)
                                                       Await context.Response.WriteAsync("<html><body><img src='asp_net_core_3_1_vb_GDH_icon.ico'></body></html>")
                                                   End Function)
                         End Sub)

    End Sub
End Class
