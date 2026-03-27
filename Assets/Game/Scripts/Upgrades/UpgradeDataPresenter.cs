using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeDataPresenter : MonoBehaviour
{
    [SerializeField] private  TMP_Text _nameText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private TMP_Text _clickRateText;
    [SerializeField] private TMP_Text _passiveRateText;
    [SerializeField] protected UpgradeData _upgradeData;

    #region subscribing
    private void OnEnable()
    {
        GlobalEvents.onUpgradeDataChange += UpdateUpgradeCost;
    }
    private void OnDisable()
    {
        GlobalEvents.onUpgradeDataChange -= UpdateUpgradeCost;
    }
    #endregion
    private void Start()
    {
        _upgradeData.Cost = PlayerPrefs.GetInt(_upgradeData.Name, _upgradeData.Cost);
        _nameText.text = _upgradeData.Name;
        _costText.text = _upgradeData.Cost.ToString() + "$";
        if (GetComponent<RandomUpgradeAction>() != null)
        {
            ChangeRandomUpgradeText();
            return;
        }
        _clickRateText.text += " " + _upgradeData.ClickRateChanger;
        _passiveRateText.text += " " + _upgradeData.PassiveRateChanger;
    }
    private void ChangeRandomUpgradeText()
    {
        _clickRateText.text += "???";
        _passiveRateText.text += "???";
    }
    public void UpdateUpgradeCost()
    {
        _costText.text = _upgradeData.Cost.ToString() + "$";
    }
}
