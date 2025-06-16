/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour {

    [SerializeField] private float realSecondPerDay = 90f;
    [SerializeField] private Transform clockHourHandTransform;
    [SerializeField] private Transform clockMinuteHandTransform;
    [SerializeField] private Transform clockSecondHandTransform;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI realTimeText;
    
    [SerializeField] private GameObject clockUI;
    [SerializeField] private FloatReference levelTime;

    public UnityEvent OnLevelTimeEnd;

    private float day;
    private float totalTime;
    private bool gameEnded = false;
    private float timeLimit;

    private void Awake()
    {
        timeLimit = levelTime.Value;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E))
        {
            timeLimit = 0;
        }

        if(gameEnded)
        {
            return;
        }


        //Stop clock when clock run over time limit
        if(totalTime > timeLimit)
        {
            //Level time end
            OnLevelTimeEnd.Invoke();

            //End game
            gameEnded = true;
            return;
        }

        

        totalTime += Time.deltaTime;

        //Show time as number string
        string realTimeString = Mathf.Floor(totalTime).ToString();
        realTimeText.text = realTimeString;

        //a day = a clock spin
        day += Time.deltaTime / realSecondPerDay;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;
        // clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        // float hoursPerDay = 24f;
        // clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

        // string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

        // float minutesPerHour = 60f;
        // string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        clockSecondHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        //timeText.text = hoursString + ":" + minutesString;
    }

    public void EnableClock()
    {
        //Run the clock
        this.enabled = true;
        //Show the clock
        clockUI.SetActive(true);
    }

    public void DisableClock()
    {
        //Stop the clock
        this.enabled = false;
        //Hide the clock
        clockUI.SetActive(false);
    }
}
