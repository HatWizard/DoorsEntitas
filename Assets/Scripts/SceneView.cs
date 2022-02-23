using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SceneView : MonoBehaviour
{
    protected GameEntity _entity;
    public string EntityId;

    public virtual void SetEntity(GameEntity entity)
    {
        _entity=entity;
    }
}
