using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Zenject;

public class SetDestinationGameSystem : ReactiveSystem<InputEntity>
{
    [Inject]
    SceneConfig _sceneConfig;

    private readonly IContext<InputEntity> _inputContext;
    private readonly IContext<GameEntity> _gameContext;
    private readonly IGroup<GameEntity> _gameEntities;

    public SetDestinationGameSystem(Contexts contexts) : base(contexts.input)
    {
        _inputContext=contexts.input;
        _gameContext=contexts.game;
        _gameEntities = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.NavAgent, GameMatcher.Movable));
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if(entities.Count<=0) return;

        var destinationPoint = entities[0].inputPoint.Value;
        _sceneConfig.CurrentDestinationPointView.transform.position = destinationPoint;

        //Debug.Log("[Set Destination System] Destination Set -> " + destinationPoint);
        foreach(var e in _gameEntities)
        {
            e.navAgent.Value.SetDestination(destinationPoint);
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputPoint;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.DestinationPoint.Added());
    }

}