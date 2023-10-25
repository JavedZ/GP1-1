using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIControler : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SettingMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject lostMenu;
    //[SerializeField] private GameObject optins;
    [SerializeField] private GameObject startGameBtn;
    //[SerializeField] private GameObject lostImage;


    [SerializeField] private Sprite closeImage;
    [SerializeField] private Sprite pauseImage;
    [SerializeField] private Sprite playImage;
    [SerializeField] private Sprite resultImage;

    //[SerializeField] private TextMeshProUGUI resultText;
    //[SerializeField] private TextMeshProUGUI motivationText;
    private bool optionsPicChange = false;


    private void Start()
    {

    }
    //public void Options()
    //{
    //    Image _playImage = startGameBtn.GetComponent<Image>();
    //    _playImage.sprite = playImage;

    //    if (!MainMenu.active)
    //    {
    //        MainMenu.SetActive(true);
    //        lostMenu.SetActive(false);
    //        Time.timeScale = 0.0f;
    //        _playImage.sprite = playImage;
    //        //_playImage.sprite.name = "PlayBtn";
    //    }
    //}

    

    public void PauseUnpause()
    {
        Image _playImage = startGameBtn.GetComponent<Image>();
        _playImage.sprite = playImage;

        //Image _resultImage = lostImage.GetComponent<Image>();
        //_resultImage.sprite = resultImage;

        if (_playImage.sprite.name == "PauseBtn")
        {
            _playImage.sprite = playImage;
            _playImage.sprite.name = "ClosBtn";
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
        }
        else if (_playImage.sprite.name == "ClosBtn")
        {
            _playImage.sprite.name = "PauseBtn";
            _playImage.sprite = pauseImage;

            if (MainMenu || pauseMenu || lostMenu || SettingMenu)
            {
                MainMenu.SetActive(false);
                pauseMenu.SetActive(false);
                lostMenu.SetActive(false);
                SettingMenu.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }
    public void Playe()
    {
        Image _playImage = startGameBtn.GetComponent<Image>();
        _playImage.sprite = playImage;
        _playImage.sprite.name = "PauseBtn";
        _playImage.sprite = pauseImage;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);

    }
    //public void LoadingNextScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    Time.timeScale = 1.0f;
    //}
    public void ExitGame()
    {
        if (Application.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
    public void BackToMainMenu()
    {
        if (MainMenu || SettingMenu || lostMenu)
        {
            MainMenu.SetActive(false);
            pauseMenu.SetActive(true);
            lostMenu.SetActive(false);
            SettingMenu.SetActive(false);
        }
    }
    public void GameSetting()
    {
        SettingMenu.SetActive(true);

    }
    public void Close()
    {

        if (MainMenu || pauseMenu || lostMenu)
        {
            MainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            lostMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
