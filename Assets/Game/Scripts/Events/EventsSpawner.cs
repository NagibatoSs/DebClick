using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsSpawner : MonoBehaviour
{
    [SerializeField] float _delayTimeInSec = 10f;
    [SerializeField] float _apearingProbability = 0.2f;
    [SerializeField] Vector3 _range = new Vector3(400, 600, 0);
    [SerializeField] GameObject _spawnParent;
    private Object[] _prefabs;

    private void Start()
    {
        LoadEventsPrefabs();
        StartCoroutine(EventsApearing());
    }
    private void LoadEventsPrefabs()
    {
        _prefabs = Resources.LoadAll("Prefabs/EventObjects", typeof(GameObject));
    }

    private IEnumerator EventsApearing()
    {
        yield return new WaitForSeconds(_delayTimeInSec);
        while (true)
        {
            if (isEventShouldApear(_apearingProbability))
            {
                var randomEventNumber = GenerateRandomEventNumber();
                Spawn(_prefabs[randomEventNumber]);
            }
            yield return new WaitForSeconds(_delayTimeInSec);
        }
    }

    private bool isEventShouldApear(float probability)
    {
        var number = Random.Range(1, 101);
        if (number <= 100 * probability) return true;
            else return false;
    }

    private int GenerateRandomEventNumber()
    {
        return Random.Range(0, _prefabs.Length);
    }

    private void Spawn(Object prefab)
    {
        var prefabObj = prefab as GameObject;
        if (prefabObj == null)
            return;
        Vector3 offset = new Vector3(Random.Range(-_range.x, _range.x), Random.Range(-_range.y, _range.y),0);
        var instObj = Instantiate(prefabObj, _spawnParent.transform.position + offset, Quaternion.identity);
        instObj.transform.SetParent(_spawnParent.transform, false);
    }
}
