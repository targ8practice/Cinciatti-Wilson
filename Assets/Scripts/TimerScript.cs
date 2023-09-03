using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    float countdownValue;
    [SerializeField]
    TMP_Text timerTextField;
    [SerializeField]
     GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {
        if (countdownValue > 0f)
        {
            countdownValue -= Time.deltaTime;

            if (countdownValue <= 0f)
            {
                PauseGame();
                countdownValue = 0f;
            }
            double correctedCountdownValue = System.Math.Round(countdownValue, 0);
            timerTextField.text = correctedCountdownValue.ToString();
        }
       

    }
}
