using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyPresenter : EconomyScriptableModelProvider
{
    [SerializeField] protected TMP_Text _moneyText;
    public TMP_Text MoneyText => _moneyText;
    [SerializeField] protected TMP_Text _clickRateText;
    public TMP_Text ClickRateText => _clickRateText;
    [SerializeField] protected TMP_Text _passiveRateText;
    public TMP_Text PassiveRateText => _passiveRateText;

    private void Start()
    {
        UpdateEconomy();
    }

    protected new void OnEnable()
    {
        base.OnEnable();
        EconomyScriptableModel.OnLoad.AddListener(UpdateEconomy);
    }

    protected new void OnDisable()
    {
        base.OnDisable();
        EconomyScriptableModel.OnLoad.RemoveListener(UpdateEconomy);
    }
    
    public void UpdateEconomy()
    {
        MoneyText.text = EconomyScriptableModel.Model.Money.ToString();
        ClickRateText.text = EconomyScriptableModel.Model.ClickRate.ToString();
        PassiveRateText.text = EconomyScriptableModel.Model.PassiveRate.ToString();
    }
}
