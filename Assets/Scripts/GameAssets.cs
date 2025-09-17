using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use this class to make universal items that can be get information from anywhere, currently unsed
public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    public List<IngredientSO> ingredientSOList;
    public List<OrderSO> orderSOList;
}
