using DG.Tweening;
using UnityEngine;
using Zenject;

public class CharacterSelectionSceneView : MonoBehaviour
{
    [SerializeField] private Transform[] _chosenCharacterPosition;
    
    private PlayerSelectionService _playerSelectionService; 

    [Inject]
    public void Construct(
        PlayerSelectionService playerSelectionService
    )
    {
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
        Vector3 position = _chosenCharacterPosition[index].position;
        position.z += 0.5f;
        characterVisual.transform.position = position;
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
}