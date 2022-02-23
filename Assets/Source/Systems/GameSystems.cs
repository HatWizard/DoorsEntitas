using Entitas;

public class GameSystems : InjectableFeature
{
    public GameSystems(Contexts contexts) : base("Game Systems")
    {
        Add(new CreateSceneEntitiesGameSystem(contexts));
        Add(new CreatePlayerGameSystem(contexts));
        Add(new SetDestinationGameSystem(contexts));
        Add(new ProcessInteractionTriggersGameSystem(contexts));
        Add(new InteractionTriggerEventSystem(contexts));
        Add(new RemoveInteractionTriggerGameSystem(contexts));
        Add(new RemoveInteractTargetGameSystem(contexts));
    }
}
