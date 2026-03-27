using UnityEngine;
using UnityEngine.Events;

public class EconomyScriptableModelProvider : MonoBehaviour
{
    [SerializeField] protected EconomyScriptableModel _economyScriptableModel;
    public EconomyScriptableModel EconomyScriptableModel 
    { 
        get => _economyScriptableModel; 
        set => _economyScriptableModel = value;
    }
    public UnityEvent OnModelChange = new UnityEvent();

    protected void OnEnable()
    {
        EconomyScriptableModel.OnLoad.AddListener(OnLoadDelegate);
        EconomyScriptableModel.Model.OnChange.AddListener(OnModelChangeDelegate);
    }

    protected void OnDisable()
    {
        EconomyScriptableModel.OnLoad.RemoveListener(OnLoadDelegate);
        EconomyScriptableModel.Model.OnChange.RemoveListener(OnModelChangeDelegate);
    }

    public void Load()
    {
        EconomyScriptableModel.Load();
        EconomyScriptableModel.Model.OnChange.AddListener(OnModelChangeDelegate);
    }

    public void Save()
    {
        EconomyScriptableModel.Save();
    }

    public void OnLoadDelegate()
    {
        EconomyScriptableModel.Model.OnChange.AddListener(OnModelChangeDelegate);
    }

    public void AddMoney(int value)
    {
        if (EconomyScriptableModel.AddMoney(value) == false)
            EconomyScriptableModel.Model.Money = 0;
    }

    public void AddMoneyByClick()
    {
        EconomyScriptableModel.Model.Money += EconomyScriptableModel.Model.ClickRate;
    }

    public void AddClickRate(int value)
    {
        if (EconomyScriptableModel.Model.ClickRate + value < 0)
            EconomyScriptableModel.Model.ClickRate = 0;
        EconomyScriptableModel.Model.ClickRate += value;
    }

    public void AddPassiveRate(int value)
    {
        if (EconomyScriptableModel.Model.PassiveRate + value < 0)
            EconomyScriptableModel.Model.PassiveRate = 0;
        EconomyScriptableModel.Model.PassiveRate += value;
    }

    public void ResetEconomy()
    {
        EconomyScriptableModel.Model.Money = 0;
        EconomyScriptableModel.Model.PassiveRate = 0;
        EconomyScriptableModel.Model.ClickRate = 1;
    }

    protected void OnModelChangeDelegate()
    {
        OnModelChange.Invoke();
    }
}
