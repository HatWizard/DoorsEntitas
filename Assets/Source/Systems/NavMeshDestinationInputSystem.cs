using System.Collections.Generic;
using Entitas;


public class NavMeshDestinationInputSystem :  ReactiveSystem<InputEntity>, ICleanupSystem
{

    private readonly IContext<InputEntity> _context;
    private readonly IGroup<InputEntity> _inputs;

    public NavMeshDestinationInputSystem(Contexts contexts) : base(contexts.input)
    {
        _context=contexts.input;
        _inputs = _context.GetGroup(InputMatcher.AllOf(InputMatcher.InputPoint, InputMatcher.DestinationPoint));
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if(entities.Count==0) return;

        var last = entities[entities.Count-1];
        last.isDestinationPoint=true;
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputPoint;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputPoint.Added());
    }

    public void Cleanup()
    {
        foreach(var e in _inputs)
        {
            e.Destroy();
        }
    }
}
