using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EconomyModel : Model
{
    [SerializeField] private int _money = 0;
    [SerializeField] private int _clickRate = 1;
    [SerializeField] private int _passiveRate = 0;

    public int Money
    {
        get { return _money; }
        set 
        {
            if (_money + value < 0)
                value = 0;
            SetData(ref _money, value);
        }
    }
    public int ClickRate
    {
        get { return _clickRate; }
        set 
        {
            if (_clickRate + value < 0)
                value = 0;
            SetData(ref _clickRate, value);
        }
    }
    public int PassiveRate
    {
        get { return _passiveRate; }
        set 
        {
            if (_passiveRate + value < 0)
                value = 0;
            SetData(ref _passiveRate, value);
        }
    }
}
