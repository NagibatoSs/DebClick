using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAccruer : MonoBehaviour
{
    private EconomyScriptableModelProvider _economyModelProvider;
    void Start()
    {
        _economyModelProvider = GetComponent<EconomyScriptableModelProvider>();
        StartCoroutine(Accrue());
        //InvokeRepeating("Accrue", 0, 1.0f);
    }
    private IEnumerator Accrue()
    {
        while (true)
        {
            if (_economyModelProvider.EconomyScriptableModel.Model.PassiveRate != 0)
                _economyModelProvider.AddMoney(_economyModelProvider.EconomyScriptableModel.Model.PassiveRate);
            yield return new WaitForSeconds(1f);
        }
    }
}
