using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VFX Pool", menuName = "VFXPool", order = 1)]
public class VFXPool : ScriptableObject
{
    [SerializeField] private int _size = 15;
    [SerializeField] private GameObject _vfxPrefab;

    private List<VFXPoolItem> _items;
    private Queue<VFXPoolItem> _queue;

    private bool _poolIsInit = false;
    public void InitializePool()
    {  
        if (_poolIsInit)
            return;
        _items = new List<VFXPoolItem>();
        _queue = new Queue<VFXPoolItem>();
        for (int i = 0; i < _size; i++)
        {
            var a = CreateItem();
        }
        _poolIsInit = true;
    }

    public void ResetPool()
    {
        _items.ForEach(item =>
        {
            if (item != null && item.gameObject != null)
                Destroy(item);
        });

        _items?.Clear();
        _queue?.Clear();
        _poolIsInit = false;
    }

    public VFXPoolItem GetFromPool()
    {
        if (_queue.Count == 0)
            ExpandPool();
        VFXPoolItem vfxPoolItem = _queue.Dequeue();
        vfxPoolItem.OnGetFromPool();
        return vfxPoolItem;
    }

    public void ReturnToPool(VFXPoolItem item)
    {
        _queue.Enqueue(item);
    }
    
    protected void ExpandPool()
    {
        for (int i = 0; i < _size; i++)
        {
            CreateItem();
        }
    }

    protected VFXPoolItem CreateItem()
    {
        GameObject itemInstance = Instantiate(_vfxPrefab);
        itemInstance.SetActive(false);
        var vfxPoolItem = itemInstance.GetComponent<VFXPoolItem>();
        vfxPoolItem.Pool = this;
        _items.Add(vfxPoolItem);
        _queue.Enqueue(vfxPoolItem);
        return vfxPoolItem;
    }
}
