using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextUpdateTest : MonoBehaviour
{
    [SerializeField] Transform resultCanvas;
    [SerializeField] RectTransform canvasRect;
    [SerializeField] float displacement;
    private Vector2 startingPosition;

    private void Start()
    {
        canvasRect.DOAnchorPosY(1000, 3);
    }

    void Update()
    {
        if(displacement > 0)
        {
            //displacement = displacement - Time.deltaTime * 0.01f;
            //transform.position = new Vector2(startingPosition.x - Time.deltaTime, startingPosition.y - Time.deltaTime);
        }
        
    }
}
