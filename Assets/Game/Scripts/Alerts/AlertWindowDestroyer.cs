using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertWindowDestroyer : MonoBehaviour
{
    public void DestroyWindow()
    {
        SoundProvider.MusicOn();
        Destroy(this.gameObject);
    }
}
