using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    [Tooltip("Timer minute")]
    [SerializeField] private int timer;
    [SerializeField] private TextMeshProUGUI timerText;
    
    [SerializeField] private GameObject offCanvas;
    [SerializeField] private GameObject onCanvas;
    
    private int _sec = 59;
    private int _min = 0;
    private int delta = 0; //0 or 1

    private void Start()
    {
        _min = timer - 1;
        this.delta = 1;
        Time.timeScale = 1;//start with 0 value time
        StartCoroutine(TimeRun());
    }

    private void Update()
    {
        if (_min == 0 & _sec == 0)
        { 
            StartStop(0);
           offCanvas.SetActive(false);
           onCanvas.SetActive(true);

           GameObject[] Circle = GameObject.FindGameObjectsWithTag("Circle");

           foreach (GameObject _circleOff in Circle)
           {
               _circleOff.SetActive(false);
           }
        }
    }

    public void StartStop(int delta)
    {
        this.delta = delta;
        Time.timeScale = delta;
    }

    private IEnumerator TimeRun()
    {
        while (_min < timer)
        {
            if (_sec == 0)
            {
                if (_min == 0)
                {
                    // Досягнуто 0:00 - можна додатково обробити подію або завершити таймер
                    Debug.Log("Таймер завершено!");
                    break; // Завершити цикл
                }

                _min--;
                _sec = 59;
            }
            else
            {
                _sec--;
            }

            timerText.text = _min.ToString("D2") + ":" + _sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
