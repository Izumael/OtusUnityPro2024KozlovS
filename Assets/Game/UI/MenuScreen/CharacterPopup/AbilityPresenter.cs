using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPresenter : MonoBehaviour
{
    [field: SerializeField] public Toggle AbilityToggle { get; private set; }
    [SerializeField] private Image _abilityIcon; 
    public string Description { get; private set; }
    public string Name { get; private set; }
    // public Sprite Icon { get; private set; }
    
    public void Setup(AbilityConfig abilityConfig, ToggleGroup abilityToggleGroup)
    {
        Description = abilityConfig.Description;
        Name = abilityConfig.Name;
        // Icon = abilityConfig.Icon;
        AbilityToggle.group = abilityToggleGroup;
        _abilityIcon.sprite = abilityConfig.Icon;
    }
}