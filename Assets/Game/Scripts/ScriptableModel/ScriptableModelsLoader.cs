using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableModelsLoader : MonoBehaviour
{
    [SerializeField] protected List<ScriptableObject> _scriptableModels;
    public List<ScriptableObject> ScriptableModels => _scriptableModels;
    private void Start()
    {
        foreach (var obj in _scriptableModels)
        {
            (obj as IStorable)?.Load();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {
            foreach (var obj in _scriptableModels)
            {
                (obj as IStorable)?.Save();
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var obj in _scriptableModels)
        {
            (obj as IStorable)?.Save();
        }
    }
    private void OnDisable()
    {
        foreach (var obj in _scriptableModels)
        {
            (obj as IStorable)?.Save();
        }
    }
}
