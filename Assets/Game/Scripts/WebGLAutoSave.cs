using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WebGLAutoSave : MonoBehaviour
{
    [SerializeField] private List<ScriptableObject> models;
    [SerializeField] private float interval = 3f;

#if UNITY_WEBGL && !UNITY_EDITOR
    private void Start()
    {
        StartCoroutine(AutoSave());
    }
 
    private IEnumerator AutoSave()
    {
        var wait = new WaitForSecondsRealtime(interval);
        while (true)
        {
            yield return wait;
            foreach (var model in models)
                if (model is IStorable storable)
                    storable.Save();
        }
    }
#endif
}
