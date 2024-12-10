using TMPro;
using UnityEngine;

public class StatView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statName;
    [SerializeField] private TextMeshProUGUI _statValue;

    public void Show(string statName, string statValue)
    {
        _statName.text = statName;
        _statValue.text = statValue;
    }
}