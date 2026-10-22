using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayCell : MonoBehaviour
{
    [SerializeField] private TMP_Text dayNumber;
    [SerializeField] private Button button;
    [SerializeField] private Animator circleAnimator;
    [SerializeField] private GameObject staticCircle;
    [SerializeField] private GameObject animatedCircle;

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

    public void PlayCircle()
    {
        staticCircle.SetActive(false);
        animatedCircle.SetActive(true);

        circleAnimator.Play("Circle_Draw", 0, 0f);
    }

    public void ShowStaticCircle()
    {
        animatedCircle.SetActive(false);
        staticCircle.SetActive(true);
    }
}