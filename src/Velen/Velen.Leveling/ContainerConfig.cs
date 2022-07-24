using Autofac;
using Velen.Leveling.Services.Experience;
using Velen.Leveling.Services.Fatigue;
using Velen.Server.Models;
using Velen.Server.Services.Fatigue;
using Velen.Server.Services.Leveling;

namespace Velen.Leveling;

/// <summary>
/// Resolves autofac types for the leveling system.
/// </summary>
public static class ContainerConfig
{
    public static IContainer Configure()
    {
        ContainerBuilder builder = new();

        builder.RegisterType<ExperienceValueProvider>().As<IExperienceValueProvider>();
        builder.RegisterType<LevelProvider>().As<ILevelValueProvider>();
        builder.RegisterType<VelenPlayer>().AsSelf();
        builder.RegisterType<FatigueProvider>().As<IFatigueProvider>();
        
        return builder.Build();
    }
}