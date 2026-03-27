using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public abstract class Purchase : MonoBehaviour
{
    [SerializeField] protected PurchaseData _purchaseData;
    protected bool isVideoPlayerNeed = false;
    private EconomyScriptableModelProvider _economyProvider;

    private void Start()
    {
        try
        {
            _economyProvider = GetComponent<EconomyScriptableModelProvider>();
        }
        catch
        { }
    }


    public void Buy()
    {
        Debug.Log("buy");
        if (_economyProvider.EconomyScriptableModel.Model.Money < _purchaseData.Price)
            return;
        _economyProvider.EconomyScriptableModel.AddMoney(-_purchaseData.Price);
        BuyAction();
        Debug.Log("cr");
        CreateAndFillAlert();
    }

    private void CreateAndFillAlert()
    {
        Debug.Log("alert");
        var alert = AlertWindowSpawner.SpawnAlertWindow();
        var presenter = alert.GetComponent<AlertDataPresenter>();
        if (isVideoPlayerNeed)
        {
            var videoPlayer = alert.GetComponent<VideoPlayer>();
            SoundProvider.MusicOff();
            videoPlayer.Play();
        }
        presenter.FillAlertDataText(_purchaseData);
    }
    //хрень надо поменять на досуге, но работает
    private Button GetButtonFromAlert(GameObject alert)
    {
        var child = alert.transform.Find("MainBody");
        var child2 = child.transform.Find("Button");
        return child2.GetComponent<Button>();
    }
    protected abstract void BuyAction();
}
