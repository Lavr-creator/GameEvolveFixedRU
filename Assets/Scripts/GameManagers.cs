using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagers : MonoBehaviour
{
    private static GameManagers instance;

    private GameObject PanelGame;                                                           // ������ ������� (������� ����)
    private GameObject PanelSettings;                                                       // ������ �������� 
    private GameObject PanelMove;                                                           // ������ �������� ��������
    private GameManagers() { }                                                              // ����� ���������

    public Toggle toggle;                                                                   // ������ �� ����� 

    private void Awake()
    {
        PanelGame = GameObject.Find("PanelMenu");                                           // ������� �� ������ ������
        PanelSettings = GameObject.Find("PanelSettings");
        PanelMove = GameObject.Find("PanelGamingMove");
       
        PanelSettings.SetActive(false);
        PanelMove.SetActive(false);
        toggle.isOn = false;                                                                // ����� �� ��������� ���������
        
    }
    /// <summary>
    /// �������� ���������� � ���, ������������ �� ��� ������, ���� ��� ���, �� �� ������� ������ ������. ���� ���, �� ��������� 
    /// </summary>
    /// <returns></returns>
    public static GameManagers getInstance()                                                
    {
        if (instance == null)
            instance = new GameManagers();
           
        return instance;
    }
    void Start()
    {
        Screen.fullScreen = true;                                                           // �� ��������� ������� ������������� �����

    }
    public void ChangeLevel(int Level)                                                      // ����� ������, �������� ��� 
    {
        SceneManager.LoadScene(Level);
    }
    public void Exits()                                                                     // ����� � ����
    {
        Application.Quit();
    }
    public void Settings()                                                                  
    {
        PanelGame.SetActive(false);
        PanelSettings.SetActive(true);
    }
    public void SettingsBack()
    {
        PanelGame.SetActive(true);
        PanelSettings.SetActive(false);
    }
    public void MoveCntrlBack()
    {
        PanelMove.SetActive(false);
        PanelSettings.SetActive(true);
    }
    public void Authors()
    {

    }
    public void NewGame()
    {
        ChangeLevel(1);
    }
    public void Continue()
    {

    }
    public void MoveControl()
    {
        PanelMove.SetActive(true);
        PanelSettings.SetActive(false);
    }
    public void ScreenFull()
    { 
        Screen.fullScreen = !toggle.isOn;
        Debug.Log("������" + Screen.fullScreen);
    }
    void Update()
    {
        
    }
}
