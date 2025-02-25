﻿/* 
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
using UnityEngine.UI;

public class ClockUI : MonoBehaviour {

    [SerializeField] private float realSecondPerDay = 90f;

    [SerializeField] private Transform clockHourHandTransform;
    [SerializeField] private Transform clockMinuteHandTransform;
    [SerializeField] private Transform clockSecondHandTransform;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI realTimeText;
    [SerializeField] private float timeLimit;

    private float day;
    private float totalTime;

    private void Update() {
        //Stop clock when clock run over time limit
        if(totalTime > timeLimit)
        {
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
        transform.gameObject.SetActive(true);
    }

    public void DisableClock()
    {
        transform.gameObject.SetActive(false);
    }
}
