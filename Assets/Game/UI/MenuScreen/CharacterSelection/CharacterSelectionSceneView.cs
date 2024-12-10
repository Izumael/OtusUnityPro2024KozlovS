using DG.Tweening;
using Game.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class CharacterSelectionSceneView : MonoBehaviour
{
    [SerializeField] private Transform[] _chosenCharacterPosition;
    [SerializeField] private Transform _spotlight;
    
    private TeamConfig _teamConfig;
    private CharacterSelectionView[] _characterSelectionViews = new CharacterSelectionView[5];
    private PlayerSelectionService _playerSelectionService; 

    [Inject]
    public void Construct(
        [Inject(Id = "AvailableHeroes")] TeamConfig teamConfig,
        PlayerSelectionService playerSelectionService
    )
    {
        _teamConfig = teamConfig;
        _playerSelectionService = playerSelectionService;
        _playerSelectionService.OnCharacterSelected += OnCharacterSelected;
        _playerSelectionService.OnCharacterDeselected += OnCharacterDeselected;
    }

    private void OnCharacterSelected(GameObject characterVisual, int index)
    {
        if (index >= _playerSelectionService.MaxSelectedCharacters)
        {
            return;
        }
        characterVisual.SetActive(true);
        characterVisual.transform.position = _chosenCharacterPosition[index].position;
    }

    private void OnCharacterDeselected(GameObject characterVisual, int index)
    {
        if (index >= _playerSelectionService.MaxSelectedCharacters)
        {
            return;
        }
        characterVisual.SetActive(false);
        characterVisual.transform.position = _chosenCharacterPosition[index].position;
    }

    public void MoveSpotLight(int index)
    {
        _spotlight.transform.DOMoveX(_chosenCharacterPosition[index].position.x, 0.5f);
    }
}