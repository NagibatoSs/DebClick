using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoActionPurchase : Purchase
{
    protected override void BuyAction()
    {
        Debug.Log("No action");
    }
}
