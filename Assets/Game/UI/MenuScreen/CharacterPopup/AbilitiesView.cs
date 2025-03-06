using System.Collections.Generic;
using Game.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _abilityNameText;
    [SerializeField] private TextMeshProUGUI _abilityDescriptionText;

    [SerializeField] private ToggleGroup _abilityToggleGroup;
    [SerializeField] private AbilityPresenter abilityPresenterPrefab;
    [SerializeField] private Transform _presentersContainer;
    private List<AbilityPresenter> _abilitiesPresenters = new();

    public void ShowAbilities(CharacterConfig characterConfig)
    {
        
        foreach (var ability in characterConfig.Abilities)
        {
            AbilityPresenter abilityPresenter = Instantiate(abilityPresenterPrefab, _presentersContainer);
            _abilitiesPresenters.Add(abilityPresenter);
            abilityPresenter.Setup(ability, _abilityToggleGroup);
            abilityPresenter.AbilityToggle.onValueChanged.AddListener(UpdateView);
        }
    }

    private void UpdateView(bool _)
    {
        foreach (var abilityView in _abilitiesPresenters)
        {
            if (abilityView.AbilityToggle.isOn)
            {
                _abilityNameText.text = abilityView.Name;
                _abilityDescriptionText.text = abilityView.Description;
            }
        }
    }

    public void Clear()
    {
        foreach (var abilityView in _abilitiesPresenters)
        {
            abilityView.AbilityToggle.onValueChanged.RemoveAllListeners();
            GameObject.Destroy(abilityView.gameObject);
        }
        _abilitiesPresenters.Clear();
    }
}