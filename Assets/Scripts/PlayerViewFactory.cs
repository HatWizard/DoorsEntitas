using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerViewFactory : MonoBehaviour, IFactory<PlayerView>
{
    [SerializeField] private GameObject _playerViewPrefab;

    public PlayerView Create()
    {
        var view = Instantiate(_playerViewPrefab);
        var navAgent = view.GetComponent<NavMeshAgent>();
        return new PlayerView(view, navAgent);
    }
}
