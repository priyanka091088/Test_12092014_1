using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using MvcIoC.Models;
using System.Web.Configuration;

namespace MvcIoC
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterTypes(
           AllClasses.FromLoadedAssemblies(),
           WithMappings.FromMatchingInterface,
           WithName.Default);

        //Injection Constructor
        //container.RegisterType<IProteinRepository, ProteinRepository>(new InjectionConstructor("test data"));
        
        //Using register Instance
        //container.RegisterInstance(typeof(IProteinRepository), new ProteinRepository("test data 123"));

        //Named Registration
        container.RegisterType<IProteinRepository, ProteinRepository>("StandardRepository", new InjectionConstructor("test"));
        container.RegisterType<IProteinRepository, DebugProteinRepository>("DebugProteinRepository");

        //Named Registration
        var repositoryType = WebConfigurationManager.AppSettings["RepositoryType"];
        container.RegisterType<IProteinTrackingService, ProteinTrackingService>(
            new InjectionConstructor(container.Resolve<IProteinRepository>(repositoryType)));

        //container.RegisterType<IProteinTrackingService, ProteinTrackingService>();
        //container.RegisterType<IProteinRepository, ProteinRepository>();
    }
  }

  public class DebugProteinRepository : IProteinRepository
  {
      public ProteinData GetData(System.DateTime dt)
      {
          return new ProteinData();
      }

      public void SetGoal(System.DateTime dt, int iGoal)
      {
          //
      }

      public void SetTotal(System.DateTime dt, int itotal)
      {
          //
      }
  }

} 