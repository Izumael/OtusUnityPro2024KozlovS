using System;
using Game.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CharacterInfoPopup : MonoBehaviour
{
    [SerializeField] private StatsView _statsView; 
    [SerializeField] private AbilitiesView _abilitiesView;
    // [SerializeField] private GameObject _popupBody;
    [SerializeField] private Image _characterIcon;
    [SerializeField] private TextMeshProUGUI _characterName;
    private PlayerSelectionService _playerSelectionService;

    [Inject]
    public void Construct(PlayerSelectionService playerSelectionService)
    {
        _playerSelectionService = playerSelectionService;
        _playerSelectionService.OnCharacterHighlited += ShowPopup;
        _playerSelectionService.OnCharacterUnhighlited += HidePopup;
        // HidePopup();
    }

    private void HidePopup()
    {
        this.gameObject.SetActive(false);
        _statsView.Clear();
        _abilitiesView.Clear();
    }

    public void ShowPopup(CharacterConfig characterConfig)
    {
        this.gameObject.SetActive(true);
        _statsView.ShowStats(characterConfig);
        _characterIcon.sprite = characterConfig.CharacterIcon;
        _characterName.text = characterConfig.CharacterName;
        _abilitiesView.ShowAbilities(characterConfig);
    }
}