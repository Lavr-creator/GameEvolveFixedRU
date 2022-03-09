using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagers : MonoBehaviour
{
    private AudioSource audioSrc;                                                       // Ссылка на объект 
    private float MusicVolume = 1.0f;                                                   // Громкость игры общая 

    private static MusicManagers instance;                                              // Паттерн одиночка, тоже самое, что и в гей манэджере 

    private MusicManagers PanelGame;
    private MusicManagers PanelSettings;

    private MusicManagers() { }

    public static MusicManagers getInstance()
    {
        if (instance == null)
            instance = new MusicManagers();

        return instance;
    }
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        audioSrc.volume = MusicVolume;
    }

    public void SetVolume(float vol)
    {
        MusicVolume = vol;
    }
  
}
