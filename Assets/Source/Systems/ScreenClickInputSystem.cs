using Entitas;
using UnityEngine;

public class ScreenClickInputSystem : IExecuteSystem, ICleanupSystem
{
    readonly InputContext _context;
    readonly IGroup<InputEntity> _inputs;

    public ScreenClickInputSystem(Contexts contexts)
    {
        _context = contexts.input;
        _inputs=_context.GetGroup(InputMatcher.ScreenClick);
    }

    public void Execute()
    {
        
        #if UNITY_ANDROID || UNITY_IOS
        if(Input.touchCount>0)
        {
            foreach(var touch in Input.touches)
            {
                var position = touch.position;
                var e = _context.CreateEntity();
                e.AddScreenPosition(position);
                e.isScreenClick=true;
            }
        }
        #else
        if(Input.GetMouseButtonDown(0))
        {
            var position = Input.mousePosition;
            var e = _context.CreateEntity();
            e.AddScreenPosition(position);
            e.isScreenClick=true;
        }
        #endif
    }

    public void Cleanup()
    {
        foreach(var input in _inputs.GetEntities())
        {
            input.Destroy();
        }
    }
}
