using Entitas;
using Entitas.CodeGeneration.Attributes;
[Game]
[Cleanup(CleanupMode.RemoveComponent)]
public class InteractTargetComponent : IComponent
{
    public string TargetEntityId;
}
