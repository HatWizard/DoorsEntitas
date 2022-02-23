using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Entitas; 

public class InteractionReporter : SceneView
{
    [SerializeField] protected string _targetEntityId;
    [SerializeField] protected UnityEvent OnInteractReported;

    public void OnInteract()
    {
        if(_entity!=null)
        {
            print("[Interaction Reporter] "+ EntityId + " reported interaction to target "+ _targetEntityId);
            _entity.AddInteractTarget(_targetEntityId);
            OnInteractReported?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        OnInteract();
    }
}
