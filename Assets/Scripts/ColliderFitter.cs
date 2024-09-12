using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFitter : MonoBehaviour
{
    private void Awake() {
        Vector2 v = GetComponent<SpriteRenderer>().sprite.bounds.size; 

        BoxCollider2D b = GetComponent<BoxCollider2D>() as BoxCollider2D;
        
        b.size = new Vector2(v.x, v.y);
    }
}
