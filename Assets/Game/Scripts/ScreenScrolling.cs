using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScrolling : MonoBehaviour
{
    [SerializeField] float _slideSpeed;
    [SerializeField] private Vector2[] _screensPositions;
    private RectTransform _contentRect;
    private int _selectedScreenId;
    private bool _isScrolling;
    private Vector2 _contentVect;

    private void Start()
    {   
        _contentRect = GetComponent<RectTransform>();
        _screensPositions = new Vector2[4];

        _screensPositions[0] = new Vector2(-1100, 0);
        _screensPositions[1] = new Vector2(0, 0);
        _screensPositions[2] = new Vector2(-2200, 0);
        _screensPositions[3] = new Vector2(-3300, 0);
        //ѕотом сделать по умолчанию на значени€ на слайдере 0.5, и раскомментировать этот код
        //_screensPositions[0] = _contentRect.localPosition;
        //_screensPositions[1] = new Vector2(_contentRect.localPosition.x + _contentRect.sizeDelta.x / 2, _contentRect.localPosition.y);
        //_screensPositions[2] = new Vector2(_contentRect.localPosition.x - _contentRect.sizeDelta.x / 2, _contentRect.localPosition.y);
    }

    private void Update()
    {
        float nearestPos = float.MaxValue;
        for (int i = 0; i < _screensPositions.Length; i++)
        {
            float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _screensPositions[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
               _selectedScreenId = i;
            }
      }
        if (_isScrolling) return;
        _contentVect.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _screensPositions[_selectedScreenId].x, _slideSpeed * Time.deltaTime);
        _contentRect.anchoredPosition = _contentVect;
    }
    public void SetIsScrolling(bool scroll)
    {
        _isScrolling = scroll;
    }
}
