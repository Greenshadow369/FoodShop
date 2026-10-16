using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLayout : MonoBehaviour
{
    [SerializeField] private GameObject dayCellPrefab;
    [SerializeField] private int cellCount = 35;

    void Start()
    {
        for (int i = 0; i < cellCount; i++)
        {
            GameObject cell = Instantiate(dayCellPrefab, transform);

            cell.GetComponent<DayCell>().SetDate(i + 1);
        }
    }
}
