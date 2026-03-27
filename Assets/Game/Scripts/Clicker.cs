using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] TMP_Text _moneyText;
    [SerializeField] TMP_Text _clickRateText;
    [SerializeField] TMP_Text _passiveRateText;
    [SerializeField] private EconomyData _economyData;

    private void Start()
    {
        _economyData.Money = PlayerPrefs.GetInt("moneyCount",0);
    }
    public void Click()
    {
        _economyData.Money += _economyData.ClickRate;
        PlayerPrefs.SetInt("moneyCount", _economyData.Money);
    }

    void Update()
    {
        _moneyText.text = _economyData.Money.ToString();
        _clickRateText.text = _economyData.ClickRate.ToString();
        _passiveRateText.text = _economyData.PassiveRate.ToString();
    }

    
}
