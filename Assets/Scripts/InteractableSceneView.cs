using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableSceneView : SceneView, IInteractionTriggerListener
{
    [SerializeField] public UnityEvent OnInteracted;

    public void OnInteractionTrigger(GameEntity entity, GameEntity triggerSource)
    {
        OnInteracted?.Invoke();
        Debug.Log("[InteractableView] "+EntityId + " interaction triggered from "+ triggerSource.sceneId.Id);
    }

    public override void SetEntity(GameEntity entity)
    {
        base.SetEntity(entity);
        entity.isInteractable=true;
        entity.AddInteractionTriggerListener(this);
    }
}
