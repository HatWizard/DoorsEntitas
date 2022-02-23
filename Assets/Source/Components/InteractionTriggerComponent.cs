using Entitas;
using Entitas.CodeGeneration.Attributes;
[Event(EventTarget.Self, EventType.Added)][Cleanup(CleanupMode.RemoveComponent)]
public class InteractionTriggerComponent : IComponent
{
    public GameEntity TriggerSource;
}
