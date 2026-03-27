using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicPurchase : Purchase
{
    [SerializeField] private MusicProvider provider;
    protected override void BuyAction()
    {
        provider.PlayNextMusic();
    }

}
