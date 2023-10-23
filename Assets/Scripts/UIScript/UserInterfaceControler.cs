using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UserInterfaceControler : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject lostMenu;
    [SerializeField] private GameObject optins;
    [SerializeField] private GameObject startGameBtn;
    [SerializeField] private GameObject lostImage;


    [SerializeField] private Sprite closeImage;
    [SerializeField] private Sprite pauseImage;
    [SerializeField] private Sprite playImage;
    [SerializeField] private Sprite resultImage;

    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI motivationText;
    private bool optionsPicChange = false;


    private void Start()
    {
        
    }
    public void Options()
    {
        Image _playImage = startGameBtn.GetComponent<Image>();
        _playImage.sprite = playImage;

        if (!MainMenu.active){
            MainMenu.SetActive(true);
            lostMenu.SetActive(false);
            Time.timeScale = 0.0f;
            _playImage.sprite = playImage;
            _playImage.sprite.name = "PlayBtn";
        }
    }

    public void Pause()
    {
        Image _playImage = startGameBtn.GetComponent<Image>();
        _playImage.sprite = playImage;

        //Image _resultImage = lostImage.GetComponent<Image>();
        //_resultImage.sprite = resultImage;

        if (_playImage.sprite.name == "PauseBtn")
        {
            _playImage.sprite = playImage;
            _playImage.sprite.name = "PlayBtn";
            Time.timeScale = 0.0f;
        }
        else if (_playImage.sprite.name == "PlayBtn")
        {
            _playImage.sprite.name = "PauseBtn";
            _playImage.sprite = pauseImage;
            Time.timeScale = 1.0f;
            MainMenu.SetActive(false);

            //lostMenu.SetActive(true);
            //_resultImage.color = Color.green;
            //resultText.text = "Well Done";
            //motivationText.text = "It's fun, Playe more";
        }
    }
    public void Playe()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        
    }
    public void LoadingNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
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
        if(lostMenu.active)
        {
            lostMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
    public void Close()
    {

        if (MainMenu || pauseMenu || lostMenu) {
            MainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            lostMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}