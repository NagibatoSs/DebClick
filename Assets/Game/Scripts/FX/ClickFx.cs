using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFx : MonoBehaviour, IPointerDownHandler
{
    //[SerializeField] private GameObject _clickVFXPrefab;
    //[SerializeField] private GameObject _parent;
    [SerializeField] private VFXPoolProvider _provider;
    [SerializeField] private float _posZ = 8f;

    public void OnPointerDown(PointerEventData eventData)
    {
        var item = _provider.VFXPool.GetFromPool();
        //var pos = Camera.allCameras[1].ScreenToWorldPoint(eventData.position);
        var pos = Camera.main.ScreenToWorldPoint(eventData.position);
        item.transform.position = new Vector3(pos.x, pos.y, _posZ);
        item.ParticleSystem.Play();
        //var pos = Camera.allCameras[1].ScreenToWorldPoint(eventData.position);
        //var pos = Camera.main.ScreenToWorldPoint(eventData.position);
        //Instantiate(_clickVFXPrefab, pos, Quaternion.identity, _parent.transform);
    }
}
