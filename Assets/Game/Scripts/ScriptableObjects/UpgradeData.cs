using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UpgradeData", menuName = "UpgradeData", order = 51)]
public class UpgradeData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get => _name; }

    [SerializeField] private int _cost;

    public int Cost { get => _cost; set => _cost = value; }
    [SerializeField] private int _clickRateChanger;

    public int ClickRateChanger { get => _clickRateChanger; }
    [SerializeField] private int _passiveRateChanger;
    public int PassiveRateChanger { get => _passiveRateChanger; }

    [SerializeField] private float _costMarkup;
    public float CostMarkup { get => _costMarkup; }
}
