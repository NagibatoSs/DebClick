using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeAction : MonoBehaviour
{
    [SerializeField] protected UpgradeData _upgradeData;
    protected EconomyScriptableModelProvider _economyModel;
    protected abstract void ChangeData();

    private void Start()
    {
        _upgradeData.Cost = PlayerPrefs.GetInt(_upgradeData.Name, _upgradeData.Cost);
       // SavePlayerPrefsUpgradeCost();
        _economyModel = GetComponent<EconomyScriptableModelProvider>();
    }
    public void Upgrade()
    {
        if (_economyModel.EconomyScriptableModel.Model.Money < _upgradeData.Cost)
            return;
        ChangeData();
        IncreaseCost();
        GlobalEvents.onUpgradeDataChange();
    }
    private void IncreaseCost()
    {
        _upgradeData.Cost += (int)(_upgradeData.Cost * _upgradeData.CostMarkup);
        SavePlayerPrefsUpgradeCost();
    }
    private void SavePlayerPrefsUpgradeCost()
    {
        PlayerPrefs.SetInt(_upgradeData.Name, _upgradeData.Cost);
    }
}
