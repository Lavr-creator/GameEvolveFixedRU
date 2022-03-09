using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagers : MonoBehaviour
{
    private AudioSource audioSrc;                                                       // ������ �� ������ 
    private float MusicVolume = 1.0f;                                                   // ��������� ���� ����� 

    private static MusicManagers instance;                                              // ������� ��������, ���� �����, ��� � � ��� ��������� 

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
