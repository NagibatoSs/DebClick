using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundProvider : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Sprite _soundOnImg;
    [SerializeField] private Sprite _soundOffImg;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public static void MusicOn()
    {
        AudioListener.volume = 1;
    }

    public static void MusicOff()
    {
        AudioListener.volume = 0;
    }
    public void ChangeSoundMode()
    {
        _audio.mute = !_audio.mute;
        if (_audio.mute)
            _image.sprite = _soundOffImg;
        else
            _image.sprite = _soundOnImg;
    }

}
