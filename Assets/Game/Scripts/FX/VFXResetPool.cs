using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXResetPool : MonoBehaviour
{
    [SerializeField] private VFXPool _vfxPool;

    //проверить, поменять если не будет работать
    private void OnDisable()
    {
        _vfxPool.ResetPool();
    }

    //хз что работает а что нет, это не нравится так как постоянно будет создаваться и уничтожаться пул
    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {
        //    _vfxPool.ResetPool();
        }
        else
        {
        //    _vfxPool.InitializePool();
        }
    }
}
