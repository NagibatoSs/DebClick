using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketEgorLetovPurchase : Purchase
{
    protected override void BuyAction()
    {
        isVideoPlayerNeed = true;
        Debug.Log("egor");

        //isAlertNeed = false;
        //var prefab = Resources.Load("Prefabs/AlertWindows/TicketEgorLetovWindow", typeof(GameObject)) as GameObject;
        //var video = Instantiate(prefab, new Vector3(Screen.width / 2, Screen.height / 2, 0), Quaternion.identity);
        //video.transform.SetParent(GameObject.Find("UICanvas").transform);
    }
}
