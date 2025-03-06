using System;
using System.Collections.Generic;
using Game.Gameplay;
using UnityEngine;

public class PlayerSelectionService
{
    public event Action<GameObject, int> OnCharacterSelected;
    public event Action<GameObject, int> OnCharacterDeselected;
    public event Action<CharacterConfig> OnCharacterHighlited;
    public event Action OnCharacterUnhighlited;
    
    //Characters selection
    public int MaxSelectedCharacters { get; } = 3;
    public CharacterConfig[] SelectedCharacters { get; private set; }= new CharacterConfig[4];
    private Vector2[] SelectedCharacterPositions = new Vector2[4];
    
    private CharacterConfig HighlitedCharacter; 
    
    //Characters visuals
    private List<KeyValuePair<CharacterConfig, GameObject>> _characterVisuals = new();

    public void AddCharacterVisual(CharacterConfig config, GameObject visual)
    {
        _characterVisuals.Add(new KeyValuePair<CharacterConfig, GameObject>(config, visual));
    }
    
    public void SelectCharacter(CharacterConfig newCharacter)
    {
        int index;
        for (index = 0; index <= SelectedCharacters.Length - 1; index++)
        {
            if (SelectedCharacters[index] == null)
            {
                SelectedCharacters[index] = newCharacter;
                break;
            }
        }
        SelectedCharacterPositions[index] = Vector2.zero;
        GameObject visual = _characterVisuals.Find(x => x.Key == newCharacter).Value;
        OnCharacterSelected?.Invoke(visual, index);
    }

    public void DeselectCharacter(CharacterConfig character)
    {
        int index;
        for (index = 0; index <= SelectedCharacters.Length - 1; index++)
        {
            if (SelectedCharacters[index] == character)
            {
                SelectedCharacters[index] = null;
                break;
            }
        }
        SelectedCharacterPositions[index] = Vector2.zero;
        GameObject visual = _characterVisuals.Find(x => x.Key == character).Value;
        OnCharacterDeselected?.Invoke(visual, index);
    }

    public void ChangePosition(CharacterConfig character, Vector2 newPosition)
    {
        for (int i = 0; i < SelectedCharacters.Length; i++)
        {
            if (SelectedCharacters[i] == character)
            {
                SelectedCharacterPositions[i] = newPosition;
            }
        }
    }

    public void UnhighlightCharacter()
    {
        HighlitedCharacter = null;
        OnCharacterUnhighlited?.Invoke();
    }

    public void HighlightCharacter(int index)
    {
        if (SelectedCharacters[index] == null)
        {
            return;
        }
        HighlitedCharacter = SelectedCharacters[index];
        OnCharacterHighlited?.Invoke(HighlitedCharacter);
    }
}