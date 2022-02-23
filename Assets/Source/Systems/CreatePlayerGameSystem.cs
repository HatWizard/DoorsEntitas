using Entitas;
using Zenject;
using UnityEngine;

public class CreatePlayerGameSystem : IInitializeSystem
{
    readonly GameContext _context;

    [Inject]
    private PlayerViewFactory _playerViewFactory;
    [Inject]
    private SceneConfig _sceneConfig;

    public CreatePlayerGameSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var playerView = _playerViewFactory.Create();
        var e = _context.CreateEntity();
        e.AddView(playerView.View);
        e.AddNavAgent(playerView.NavAgent);
        e.isPlayer=true;
        e.isMovable=true;
        
        e.view.gameObject.transform.position = _sceneConfig.PlayerStartPosition;
        e.navAgent.Value.enabled=false;
        e.navAgent.Value.enabled=true;
    }
}
