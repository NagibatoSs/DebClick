using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUpgradeAction : UpgradeAction
{
    [SerializeField] float _superUpgradeProbability = 0.1f;
    [SerializeField] int _maxAbsClickSuperRate = 100;
    [SerializeField] int _maxAbsPassiveSuperRate = 25;
    protected override void ChangeData()
    {
        _economyModel.AddMoney(-(_upgradeData.Cost));
        int value;
        bool isSuper = isSuperUpgrade();
        if (isClickUpgrade())
        {
            if (isSuper)
                value = Random.Range(- _maxAbsClickSuperRate,_maxAbsClickSuperRate);
            else
                value = Random.Range(- _upgradeData.ClickRateChanger, _upgradeData.ClickRateChanger);
            _economyModel.AddClickRate(value);
        }
        else
        {
            if (isSuper)
                value = Random.Range(- _maxAbsPassiveSuperRate, _maxAbsPassiveSuperRate);
            else
                value = Random.Range(- _upgradeData.PassiveRateChanger, _upgradeData.PassiveRateChanger);
            _economyModel.AddPassiveRate(value);
        }
    }
    //случайно выбирает тип улучшения, возвращает тру, если клик
    private bool isClickUpgrade()
    {
        if (Random.Range(0,2) > 0) return true;
        else return false;
    }
    private bool isSuperUpgrade()
    {
        var number = Random.Range(1, 101);
        if (number <= 100 * _superUpgradeProbability)
        {
            Debug.Log("isSuper");
            return true;
        }
        else return false;
    }
}
