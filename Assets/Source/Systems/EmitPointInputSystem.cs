using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EmitPointInputSystem : ReactiveSystem<InputEntity>, ICleanupSystem
{
    private readonly IContext<InputEntity> _context;
    private readonly IGroup<InputEntity> _inputs;

    public EmitPointInputSystem(Contexts contexts) : base(contexts.input)
    {
        _context=contexts.input;
        _inputs = _context.GetGroup(InputMatcher.InputPoint);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach(var e in entities)
        {
            var screenPos = e.screenPosition.Value;

            var ray = Camera.main.ScreenPointToRay(screenPos);
            if(Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                var pos = hit.point;
                _context.CreateEntity().AddInputPoint(pos);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasScreenPosition;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.ScreenClick.Added());
    }

    public void Cleanup()
    {
        foreach(var e in _inputs.GetEntities())
        {
            e.Destroy();
        }
    }
}
