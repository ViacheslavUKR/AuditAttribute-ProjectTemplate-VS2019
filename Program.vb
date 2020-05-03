Imports System
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging

'Minimal dynamicallyFormed onePageSite with static content, defaultPage, ActionFilters and audit/logging all requestHeaders by custom attribute (with headers for nginx reverseProxy)

Module Program
    Public Sub Main(args As String())
        CreateHostBuilder(args).Build().Run()
    End Sub

    Public Function CreateHostBuilder(ByVal args As String()) As IHostBuilder
        Return Host.
            CreateDefaultBuilder().
            ConfigureLogging(Sub(logging)
                                 logging.AddConsole()
                             End Sub).
            ConfigureWebHostDefaults(Function(webBuilder)
                                         Return webBuilder.UseStartup(Of Startup)()
                                     End Function)
    End Function

End Module
