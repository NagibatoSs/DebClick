using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoRublesPurchase : Purchase
{
    protected override void BuyAction()
    {
        if (PlayerPrefs.GetString("AlreadyGiven2rubs1", "false") == "false")
        {
            PlayerPrefs.SetString("AlreadyGiven2rubs1", "true");
            var code = Random.Range(100000, 1000000);
            _purchaseData.Description += "Ваш секретный код: " + code;
            return;
        }
        else
        {
            _purchaseData.Description = "Вы уже получали 2 рубля(((";
            _purchaseData.ButtonText = "Эх ладна";
        }
    }
}
