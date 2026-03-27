using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RandomEventData", menuName = "RandomEventData", order = 51)]
public class RandomEventData : ScriptableObject
{
    [SerializeField] private string _eventObjectName;
    public string EventObjectName { get => _eventObjectName; }
    [SerializeField] private string _description;
    //[SerializeField] private Sprite _icon;
   // public Sprite Icon { get => _icon; }
    [SerializeField] private int _moneyChanger;
    public int MoneyChanger { get => _moneyChanger; }
    [SerializeField] private int _clickRateChanger;
    public int ClickRateChanger { get => _clickRateChanger; }
    [SerializeField] private int _passiveRateChanger;
    public int PassiveRateChanger { get => _passiveRateChanger; }
    //[SerializeField] private EconomyScriptableModelProvider _economyModel;
}
