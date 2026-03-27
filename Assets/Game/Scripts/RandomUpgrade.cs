using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomUpgrade : MonoBehaviour
{
    [SerializeField] TMP_Text _randomCostText;
    [SerializeField] private EconomyData _economyData;
    [SerializeField] private int _cost = 100;

    private void Start()
    {
        _cost = PlayerPrefs.GetInt("randomUpgradeCost",222);
        _randomCostText.text = _cost.ToString();
    }
    public void Upgrade()
    {
        if (_economyData.Money < _cost) return;
        _economyData.Money = _economyData.Money - _cost;
        //Делаем рандомное начисление в рейт
        switch (Random.Range(1, 3))
        {
            case 1:
                _economyData.ClickRate += Random.Range(1, 60);
                PlayerPrefs.SetInt("clickRate", _economyData.ClickRate);
                break;
            case 2:
                _economyData.PassiveRate += Random.Range(1, 50);
                PlayerPrefs.SetInt("passiveRate", _economyData.PassiveRate);
                break;
        }
        //Добавляем 15% от суммы всех приростов к стоимости услуги 
        _cost += ((_economyData.ClickRate + _economyData.PassiveRate) / 100 * 50);
        _randomCostText.text = _cost.ToString();

        PlayerPrefs.SetInt("moneyCount", _economyData.Money);
        PlayerPrefs.SetInt("randomUpgradeCost", _cost);
    }
}
