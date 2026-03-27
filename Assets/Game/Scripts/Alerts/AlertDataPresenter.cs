using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlertDataPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private RawImage _contentImg;
    public void FillAlertDataText(PurchaseData purchaseData)
    {
        if (_descriptionText != null && _buttonText != null)
        {
            _descriptionText.text = purchaseData.Description;
            _buttonText.text = purchaseData.ButtonText;
            _contentImg.texture = purchaseData.ContentTexture;
        }
    }
}
