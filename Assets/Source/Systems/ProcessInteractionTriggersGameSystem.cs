using System.Collections.Generic;
using Entitas;

public class ProcessInteractionTriggersGameSystem :  ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ProcessInteractionTriggersGameSystem(Contexts contexts) : base(contexts.game)
    {
        _context=contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            var index = e.interactTarget.TargetEntityId;
            var targetInteractedEntities = _context.GetEntitiesWithSceneId(index);
            foreach(var targetEntity in targetInteractedEntities)
            {
                if(targetEntity.isInteractable) targetEntity.AddInteractionTrigger(e);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSceneId;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.InteractTarget.Added());
    }
}