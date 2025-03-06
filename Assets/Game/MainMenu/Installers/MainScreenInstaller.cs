using UnityEngine;
using Zenject;

public class MainScreenInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerSelectionService>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<LoadingPipeline>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<MainScreenLoadingPipelineInstaller>().FromNew().AsSingle().NonLazy();
    }
}