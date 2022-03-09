using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagers : MonoBehaviour
{
    private static GameManagers instance;

    private GameObject PanelGame;                                                           // Панель Игровая (Главное меню)
    private GameObject PanelSettings;                                                       // Панель настроек 
    private GameObject PanelMove;                                                           // Панель настроек движения
    private GameManagers() { }                                                              // Часть синглтона

    public Toggle toggle;                                                                   // Ссылка на галку 

    private void Awake()
    {
        PanelGame = GameObject.Find("PanelMenu");                                           // Находит по ссылке объект
        PanelSettings = GameObject.Find("PanelSettings");
        PanelMove = GameObject.Find("PanelGamingMove");
       
        PanelSettings.SetActive(false);
        PanelMove.SetActive(false);
        toggle.isOn = false;                                                                // Галка по умолчанию выключена
        
    }
    /// <summary>
    /// Получает информацию о том, оригинальный ли это объект, если это так, то он удаляет другой объект. Если нет, то оставляет 
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
        Screen.fullScreen = true;                                                           // По умолчанию включен полноэкранный режим

    }
    public void ChangeLevel(int Level)                                                      // Смена уровня, банально все 
    {
        SceneManager.LoadScene(Level);
    }
    public void Exits()                                                                     // Выход с игры
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
        Debug.Log("Статус" + Screen.fullScreen);
    }
    void Update()
    {
        
    }
}
