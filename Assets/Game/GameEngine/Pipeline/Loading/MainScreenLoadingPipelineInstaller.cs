using Zenject;

public class MainScreenLoadingPipelineInstaller: IInitializable
{
    private readonly DiContainer _diContainer;
    private readonly LoadingPipeline _loadingPipeline;
    private readonly TeamConfig _availableHeroes;
    private readonly PlayerSelectionService _playerSelectionService;
    
    [Inject]
    public MainScreenLoadingPipelineInstaller(
        DiContainer diContainer,
        LoadingPipeline loadingPipeline,
        [Inject(Id = "AvailableHeroes")] TeamConfig teamConfig,
        PlayerSelectionService playerSelectionService
    )
    {
        _availableHeroes = teamConfig;
        _diContainer = diContainer;
        _loadingPipeline = loadingPipeline;
        _playerSelectionService = playerSelectionService;
    }

    public void Initialize()
    { 
        _loadingPipeline.AddTask(new SpawnCharactersVisualsTask(_availableHeroes, _playerSelectionService));
        
        // _roundPipeline.AddTask(new RefreshServicesTask());
        // _loadingPipeline.AddTask(new StartRoundTask(_diContainer, _eventBus));
        // _loadingPipeline.AddTask(new RunTurnPipelineTask(_diContainer, _eventBus));
        // _loadingPipeline.AddTask(new FinishRoundTask(_diContainer, _eventBus));
        _loadingPipeline.RunNextTask();
    }
}