using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayCell : MonoBehaviour
{
    [SerializeField] private TMP_Text dayNumber;
    [SerializeField] private Button button;

    void Start()
    {
        //SetEmpty();
    }

    public void SetEmpty()
    {
        dayNumber.text = "";
        button.interactable = false;
    }

    public void SetDate(int day)
    {
        dayNumber.text = day.ToString();
        button.interactable = true;
    }
}