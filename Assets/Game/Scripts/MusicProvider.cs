using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProvider : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musics = new List<AudioClip>();
    private int _currentMusicId = 0;
    private AudioSource _source;
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _currentMusicId = PlayerPrefs.GetInt("musicId",0);
        PlayMusic(musics[_currentMusicId]);
    }

    public void PlayNextMusic()
    {
        if (musics.Count == 0) return;
        _currentMusicId++;
        if (_currentMusicId >= musics.Count)
            _currentMusicId = 0;
        PlayerPrefs.SetInt("musicId", _currentMusicId);
        PlayMusic(musics[_currentMusicId]);
    }

    private void PlayMusic(AudioClip music)
    {
        _source.clip = music;
        _source.Play();
    }
}
