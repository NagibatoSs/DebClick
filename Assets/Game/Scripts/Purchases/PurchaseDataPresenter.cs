using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurchaseDataPresenter : MonoBehaviour
{
    [SerializeField] private PurchaseData _purchaseData;
    [SerializeField] private TMP_Text _purchaseName;
    [SerializeField] private TMP_Text _purchasePrice;
    private void Start()
    {
        _purchaseName.text = _purchaseData.Name;
        _purchasePrice.text = _purchaseData.Price.ToString() + "$";
    }
}
