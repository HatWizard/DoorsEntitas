using Entitas;
using Entitas.CodeGeneration.Attributes;
[Game]
public class SceneIdComponent : IComponent
{
    [EntityIndex]
    public string Id;
}
