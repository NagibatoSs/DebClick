using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EconomyData", menuName = "EconomyData", order = 51)]
public class EconomyData : ScriptableObject
{
    [SerializeField] private int _money = 0;
    [SerializeField] private int _clickRate = 1;
    [SerializeField] private int _passiveRate = 0;

    public int Money
    {
        get { return _money; }
        set { _money = value; }
    }
    public int ClickRate
    {
        get { return _clickRate; }
        set { _clickRate = value; }
    }
    public int PassiveRate
    {
        get { return _passiveRate; }
        set { _passiveRate = value; }
    }
}
