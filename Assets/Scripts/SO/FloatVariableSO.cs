using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariableSO : ScriptableObject
{
    public float value;
    public void SetValue(float value)
    {
        this.value = value;
    }

    public void SetValue(FloatVariableSO value)
    {
        this.value = value.value;
    }

    public void ApplyChange(float amount)
    {
        value += amount;
    }

    public void ApplyChange(FloatVariableSO amount)
    {
        value += amount.value;
    }
}
