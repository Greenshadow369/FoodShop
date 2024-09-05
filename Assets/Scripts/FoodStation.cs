using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FoodStation will provide basic functions such as storing and operating
//FoodStationSO will provide detailed functions such grilling, pouring drink or slicing 
public class FoodStation : MonoBehaviour
{
    //private List<IngredientListSO> currentIngredientList;
    [Header("Food Station")]
    [SerializeField] private FoodStationSO foodStationSO;
    [SerializeField] Transform ingredientSpawnPoint;
    
    [SerializeField] Transform ingredientPrefab;
    [Header("Can this station create ingredient?")]
    [SerializeField] bool isIngredientSpawner;
    [SerializeField] IngredientSO ingredientSO;

    [SerializeField] private DishStateSO dishStateSO;

    private MixingStation mixingStation;

    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Mixing Station").TryGetComponent<MixingStation>(out MixingStation mixingStation_))
        {
            mixingStation = mixingStation_;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(dishStateSO.IsDishStarted());
        }
    }

    private void OnMouseDown() {
        //Spawner can be clicked on to create ingredient
        if(isIngredientSpawner)
        {
            IngredientButtonClicked();
        }
    }

    private void IngredientButtonClicked()
    {
        if(!IsActionValid(ingredientSO))
        {
            return;
        }

        //Create new ingredient
        Transform ingredientTransform = Instantiate(ingredientPrefab);
        //Update ingredient
        Ingredient ingredient = ingredientTransform.GetComponent<Ingredient>();
        ingredient.SetIngredientSO(ingredientSO);
        //Trigger ingredient
        ingredient.TriggerIngredient();
    }

    public FoodStationSO GetFoodStationSO()
    {
        return foodStationSO;
    }

    public void ReceiveIngredient(Ingredient ingredient)
    {
        Transform ingredientTransform = ingredient.gameObject.transform;

        //Set parent
        ingredientTransform.SetParent(ingredientSpawnPoint);
        
        //Set default position
        ingredientTransform.position = ingredientSpawnPoint.position;
        //Set alternative position if this is Mixing Station
        if(TryGetComponent<MixingStation>(out MixingStation mixSta))
        {
            mixSta.PlaceIngredient(ingredient);
        }
        
    }

    public bool IsActionValid(IngredientSO ingreSO)
    {
        bool isValid = true;

        Debug.Log("mix: " + mixingStation.GetStarterIngredientSO().GetIngredientName());
        Debug.Log("SO: " + ingreSO.GetIngredientName());
        //Check the current state of the dish
        if(mixingStation.GetStarterIngredientSO().GetIngredientName() != ingreSO.GetIngredientName() ^ dishStateSO.IsDishStarted())
        {
            isValid = false;
        }

        if(dishStateSO.IsDishFinished())
        {
            //Dish is already finished
            isValid = false;
        }

        return isValid;
    }
}
