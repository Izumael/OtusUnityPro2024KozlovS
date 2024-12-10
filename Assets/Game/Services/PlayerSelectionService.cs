using System;
using System.Collections.Generic;
using Game.Gameplay;
using UnityEngine;

public class PlayerSelectionService
{
    public event Action<GameObject, int> OnCharacterSelected;
    public event Action<GameObject, int> OnCharacterDeselected;
    
    //Characters selection
    public int MaxSelectedCharacters { get; } = 3;
    private CharacterConfig[] SelectedCharacters = new CharacterConfig[4];
    private Vector2[] SelectedCharacterPositions = new Vector2[4];
    
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
        // SelectedCharacters.Add(newCharacter);
        SelectedCharacterPositions[index] = Vector2.zero;
        // int index = SelectedCharacters.Count - 1;
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
        // SelectedCharacters.Remove(character);
        SelectedCharacterPositions[index] = Vector2.zero;
        // index = _characterVisuals.FindIndex(x => x.Key == character);
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
}