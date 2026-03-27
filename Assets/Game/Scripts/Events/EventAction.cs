using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventAction : MonoBehaviour
{
    [SerializeField] private RandomEventData _eventData;
    private EconomyScriptableModelProvider _economyModel;
    private DragItem dragItem;

    private void Start()
    {
        _economyModel = GetComponent<EconomyScriptableModelProvider>();
        dragItem = GetComponent<DragItem>();
    }
    public void ClickAction()
    {
        if (dragItem.isJustMove) return;
        _economyModel.AddMoney(_eventData.MoneyChanger);
        _economyModel.AddClickRate(_eventData.ClickRateChanger);
        _economyModel.AddPassiveRate(_eventData.PassiveRateChanger);
        Destroy(this.gameObject);

        // огда будет анимаци€, чтобы пропадало не сразу
        //Destroy(GetComponent<Button>());
        //Destroy(this.gameObject,1f);
    }
}
