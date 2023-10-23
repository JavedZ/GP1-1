using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float runTime;
    //public TextMeshProUGUI timeText;
    public TextMeshProUGUI TimerText;
    private bool timeIsRunning = false;
    private float timeRunning;
    public float timeRemaining = 0;

    public GameObject lostMenu;


    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (timeIsRunning)
        {
            if (timeRunning >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);


                string timeRemainingRunTime = runTime.ToString();
                // fuleText.text = timeRemainingRunTime;
                runTime = 100 - timeRemaining;
                _slider.value = runTime;
                if (runTime <= 90)
                {
                    Time.timeScale = 0.0f;
                    lostMenu.SetActive(true);
                    timeIsRunning=false;
                }
            }
        }

        _slider.onValueChanged.AddListener((v) =>
        {
            TimerText.text = v.ToString("0");

        });
    }

    private void DisplayTime(float timeToDesplay)
    {
        timeToDesplay += 1;
        float minutes = Mathf.FloorToInt(timeToDesplay / 60);
        float seconds = Mathf.FloorToInt(minutes % 60);
        //timeText.text = string.Format("(0:00) : (1:00)", minutes, seconds);
    }


}
