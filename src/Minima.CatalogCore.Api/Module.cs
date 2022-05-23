using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Minima.Infrastructure.Modularity;


namespace Minima.CatalogModule.Api;

public class Module : IModule
{
    private IApplicationBuilder _applicationBuilder;

    

    public ManifestModuleInfo ModuleInfo { get; set; }


    public void Initialize(IServiceCollection serviceCollection)
    {
        
    }

    public void PostInitialize(IApplicationBuilder appBuilder)
    {
     
    }

    public void Uninstall()
    {
     
    }
}
