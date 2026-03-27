using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private EconomyScriptableModelProvider _economyProvider;
    private bool isClicking = false;

    private void Start()
    {
        _economyProvider = GetComponent<EconomyScriptableModelProvider>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isClicking)
            _economyProvider.AddMoneyByClick();
        isClicking = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
            isClicking = false;
    }
}
