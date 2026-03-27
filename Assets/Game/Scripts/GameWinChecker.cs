using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinChecker : MonoBehaviour
{
    [SerializeField] EconomyScriptableModelProvider _model;
    [SerializeField] int _moneyToWin;
    [SerializeField] private GameObject _alertWindowPrefab;
    [SerializeField] GameObject _spawnParent;
    private EconomyScriptableModelProvider _economyProvider;
    private bool _isAlreadyWon = false;
    private void OnEnable()
    {
        _model.OnModelChange.AddListener(WinChecker);
    }

    private void Start()
    {
        _economyProvider = GetComponent<EconomyScriptableModelProvider>();
    }

    public void WinChecker()
    {
        if (!_isAlreadyWon && _model.EconomyScriptableModel.Model.Money > _moneyToWin)
        { 
            Debug.Log("Вы победили!");
            SpawnWinAlertWindow();
            _isAlreadyWon = true;
            _economyProvider.ResetEconomy();
            _isAlreadyWon = false;
        }
    }

    private void SpawnWinAlertWindow()
    {
        if (_alertWindowPrefab != null)
        {
            var instObj = Instantiate(_alertWindowPrefab, _spawnParent.transform.position, Quaternion.identity);//pomenyat transform.position
            instObj.transform.SetParent(_spawnParent.transform);
        }
    }
}
