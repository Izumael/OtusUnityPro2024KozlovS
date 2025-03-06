using DG.Tweening;
using Game.Gameplay;
using UnityEngine;

public class SpawnCharactersVisualsTask : EventTask
{
    private readonly TeamConfig _teamConfig;
    private readonly PlayerSelectionService _playerSelectionService;

    public SpawnCharactersVisualsTask(TeamConfig teamConfig, PlayerSelectionService playerSelectionService)
    {
        _teamConfig = teamConfig;
        _playerSelectionService = playerSelectionService;
    }

    protected override void OnRun()
    {
        for (int i = 0; i < _teamConfig.characters.Count; i++)
        {
            var character = GameObject.Instantiate(_teamConfig.characters[i].CharacterVisualPrefab, Vector3.zero, 
                Quaternion.LookRotation(new Vector3(0, 0, -1), Vector3.up));
            character.SetActive(false);
            _playerSelectionService.AddCharacterVisual(_teamConfig.characters[i], character);
        }
    }

    private void OnMoveFinish()
    {
        Finish();
    }
}