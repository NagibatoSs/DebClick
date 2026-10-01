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
    #if UNITY_WEBGL && !UNITY_EDITOR                                   
        if (!PlayerPrefs.HasKey(name + "data123"))                     
            return false;                                              
        string modelText = PlayerPrefs.GetString(name + "data123");  
    #else                                                               
        if (!File.Exists(GetStoragePath(name)))
            return false;
        string modelText = File.ReadAllText(GetStoragePath(name));
#endif
        TModel model = new TModel();
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
#if UNITY_WEBGL && !UNITY_EDITOR                                    
            PlayerPrefs.SetString(name + "data123", modelText);        
            PlayerPrefs.Save();                                        
#else                                                             
            File.WriteAllText(GetStoragePath(name), modelText);
#endif
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
