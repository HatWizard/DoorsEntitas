using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerViewFactory _playerViewFactory;
    [SerializeField] private SceneConfig _sceneConfig;

    private GameSystems _gameSystems;
    private InputSystems _inputSystems;

    public override void InstallBindings()
    {
        Container.Bind<PlayerViewFactory>().FromInstance(_playerViewFactory).AsSingle();
        Container.Bind<SceneConfig>().FromInstance(_sceneConfig).AsSingle();

        _inputSystems = new InputSystems(Contexts.sharedInstance);
        _gameSystems = new GameSystems(Contexts.sharedInstance);
        _gameSystems.IncjectSelfAndChildren(Container);

        _inputSystems.Initialize();
        _gameSystems.Initialize();

        _inputSystems.ActivateReactiveSystems();
        _gameSystems.ActivateReactiveSystems();
        
    }


    private void Update() 
    {
        _inputSystems.Execute();
        _gameSystems.Execute();
    }

    private void LateUpdate() 
    {
        _inputSystems.Cleanup();
        _gameSystems.Cleanup();
    }
}
