using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableModel<TModel> : ScriptableObject, IStorable where TModel:Model, new()
{
    [SerializeField] protected TModel _model;
    public UnityEvent OnLoad;
    public UnityEvent OnSave;

    public TModel Model
    {
        get => _model;
        set => _model = value;
    }

    public bool Load()
    {
        if (!File.Exists(GetStoragePath(name)))
            return false;
        TModel model = new TModel();
        File.ReadAllText(GetStoragePath(name));
        string modelText = File.ReadAllText(GetStoragePath(name));
        JsonUtility.FromJsonOverwrite(modelText, model);
        Model.OnChange.RemoveAllListeners();
        Model = model;
        OnLoad.Invoke();
        return true;
    }

    public bool Save()
    {
        try 
        {
            string modelText = JsonUtility.ToJson(Model);
            File.WriteAllText(GetStoragePath(name), modelText);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return false;
        }
        OnSave.Invoke();
        return true;
    }

    protected static string GetStoragePath(string modelName)
    {
        return Application.persistentDataPath + Path.DirectorySeparatorChar + modelName + "data123.json"; 
    }
}
