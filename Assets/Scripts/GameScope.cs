using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameManager>(Lifetime.Singleton);
        builder.RegisterEntryPoint<ScoreHandler>().AsSelf();
    }
}