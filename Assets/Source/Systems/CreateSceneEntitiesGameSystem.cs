using Entitas;
using Zenject;

public class CreateSceneEntitiesGameSystem : IInitializeSystem
{
    readonly GameContext _context;

    [Inject]
    private SceneConfig _sceneConfig;

    public CreateSceneEntitiesGameSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        foreach(var view in _sceneConfig.SceneEntityViews)
        {
            var e = _context.CreateEntity();
            e.AddSceneId(view.EntityId);
            view.SetEntity(e);
        }
    }
}
