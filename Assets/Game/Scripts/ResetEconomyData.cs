using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEconomyData : MonoBehaviour
{
    [SerializeField] EconomyScriptableModel _economyScrModel;

    public void Reset()
    {
        _economyScrModel.Model.Money = 0;
        _economyScrModel.Model.ClickRate = 1;
        _economyScrModel.Model.PassiveRate = 0;
    }
}
