using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EconomyScriptableModel", menuName = "Create EconomyScriptableModel", order = 1)]
public class EconomyScriptableModel : ScriptableModel<EconomyModel>
{
    public bool AddMoney(int value)
    {
        if (Model.Money + value < 0)
            return false;
        Model.Money += value;
        return true;
    }

}
