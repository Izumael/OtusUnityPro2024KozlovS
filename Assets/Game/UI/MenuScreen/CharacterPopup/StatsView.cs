using System.Collections.Generic;
using Game.Gameplay;
using UnityEngine;

public class StatsView : MonoBehaviour
{
    [SerializeField] private StatView _statViewPrefab;
    [SerializeField] private Transform _statsContainer;
    private List<StatView> _statsViews = new();

    public void ShowStats(CharacterConfig characterConfig)
    {
        foreach (var statData in characterConfig.StatsData)
        {
            var statView = Instantiate(_statViewPrefab, _statsContainer);
            statView.Show(statData.StatType.ToString(), statData.Value.ToString());
            _statsViews.Add(statView);
        }
    }

    public void Clear()
    {
        foreach (var statView in _statsViews)
        {
            GameObject.Destroy(statView.gameObject);
        }
        _statsViews.Clear();
    }
}