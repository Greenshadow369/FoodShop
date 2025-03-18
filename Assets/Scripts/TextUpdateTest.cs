using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdateTest : MonoBehaviour
{
    public FloatReference floatSO;
    public TextMeshProUGUI UIText;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(floatSO.Value);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {

            floatSO.Variable.ApplyChange(1);
        }
        UIText.text = floatSO.Value.ToString();
    }
}
