using Entitas;

public class InputSystems : Feature
{
    public InputSystems(Contexts contexts) : base("Input Systems")
    {
        Add(new ScreenClickInputSystem(contexts));
        Add(new EmitPointInputSystem(contexts));
        Add(new NavMeshDestinationInputSystem(contexts));
    }
}
