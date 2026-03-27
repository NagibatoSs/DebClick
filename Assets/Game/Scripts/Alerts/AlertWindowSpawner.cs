using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertWindowSpawner : MonoBehaviour
{
    public static GameObject SpawnAlertWindow()
    {
        try
        {
            var prefab = Resources.Load("Prefabs/AlertWindows/AlertWindow2", typeof(GameObject)) as GameObject;
            var parentTransform = GameObject.Find("UICanvas").transform;
            //var alert = Instantiate(prefab, new Vector3(Screen.width/2, Screen.height/2, 0), Quaternion.identity);
            var alert = Instantiate(prefab, new Vector3(parentTransform.position.x / 2, parentTransform.position.y / 2, parentTransform.position.z), Quaternion.identity);
            alert.transform.SetParent(parentTransform);
            alert.transform.localScale = new Vector3(1, 1, 1);
            return alert;
        }
        catch
        {
            Debug.Log("Spawn Alert Error");
            return null;
        }
    }
}
