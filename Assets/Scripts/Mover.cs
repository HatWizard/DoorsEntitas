using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public bool IsMoved {get; private set;}

    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private int _framesCount;
    [SerializeField] private bool _disableOnMoved;

    public void Move()
    {
        if(!IsMoved)
        {
            IsMoved=true;
            StartCoroutine(MoveToTarget(_targetPosition));
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        var diff = _targetPosition/_framesCount;

        for(int i=0; i<_framesCount; i++)
        {
            transform.position+=diff;
            yield return null;
        }

        if(_disableOnMoved) gameObject.SetActive(false);
    }
}
