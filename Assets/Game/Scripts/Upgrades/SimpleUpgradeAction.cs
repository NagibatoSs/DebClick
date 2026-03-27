using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleUpgradeAction : UpgradeAction
{
    protected override void ChangeData()
    {
        _economyModel.AddMoney(-(_upgradeData.Cost));
        _economyModel.AddClickRate(_upgradeData.ClickRateChanger);
        _economyModel.AddPassiveRate(_upgradeData.PassiveRateChanger);
    }
}
