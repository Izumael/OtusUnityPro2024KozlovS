
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class CharacterHighligther : MonoBehaviour
{
    [SerializeField] private Toggle[] _spotlightToggles;
    [SerializeField] private Transform _spotlight;
    [SerializeField] private Transform[] _spotlightPosition;
    private PlayerSelectionService _playerSelectionService; 

    [Inject]
    public void Construct(
        PlayerSelectionService playerSelectionService
    )
    {
        _playerSelectionService = playerSelectionService;
    }

    private void Start()
    {
        foreach (var toggle in _spotlightToggles)
        {
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (!isOn)
        {
            _spotlight.gameObject.SetActive(false);
            _playerSelectionService.UnhighlightCharacter();
            return;
        }
        
        for (int i = 0; i < _spotlightToggles.Length; i++)
        {
            if (_spotlightToggles[i].isOn && _playerSelectionService.SelectedCharacters[i] != null)
            {
                MoveSpotLight(i);
                _playerSelectionService.HighlightCharacter(i);
                break;
            }
        }
    }

    public void MoveSpotLight(int index)
    {
        _spotlight.gameObject.SetActive(true);
        _spotlight.transform.DOMoveX(_spotlightPosition[index].position.x, 0.5f);
    }
}