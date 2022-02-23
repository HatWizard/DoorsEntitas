using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConfig : MonoBehaviour
{
    [field: SerializeField] public Vector3 PlayerStartPosition {get; private set;}
    [field: SerializeField] public SceneView[] SceneEntityViews {get; private set;}
    [field: SerializeField] public GameObject CurrentDestinationPointView {get; private set;}
}
