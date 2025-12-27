using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameActionSystem : MonoBehaviour
{
    [SerializeField] private LayerMask foodStationLayerMask;
    [SerializeField] private LayerMask ingredientLayerMask;

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(TryHandleIngredientSelection())
        {
            return;
        }

        HandleSelectedStation();
    }

    private bool TryHandleIngredientSelection()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // if(selectedAction != null)
            // {
            //     //An action is currently selected
            //     return false;
            // }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, ingredientLayerMask);

            if (!hit.collider)
            {
                return false;
            }
                

            if (!hit.transform.TryGetComponent(out Ingredient ingredient))
            {
                return false;
            }

            // if(selectedUnit == unit)
            // {
            //     //Unit is already selected
            //     return false;
            // }

            // if(unit is Enemy)
            // {
            //     //Unit is an enemy
            //     return false;
            // }

            //SetSelectedUnit(unit);

            ingredient.IngredientClicked();
            return true;

        }
        return false;
    }

    private void HandleSelectedStation()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // if(selectedAction == null)
            // {
            //     //No action is currently selected
            //     return;
            // }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(ray, foodStationLayerMask);
            if(rayHit.collider == null)
            {
                //No collider at mouse position
                return;
            }
            
            rayHit.transform.TryGetComponent<FoodStation>(out FoodStation foodStation);
            
            // if(!selectedAction.IsValidActionSlotIndex(unit.GetSlotIndex()))
            // {
            //     //Is not a valid target for action
            //     return;
            // }
            
            // if(!selectedUnit.TrySpendActionPointsToTakeAction(selectedAction))
            // {
            //     return;
            // }

            foodStation.FoodStationClicked();
            // SetBusy();
            // selectedAction.TakeAction(unit.GetSlotIndex(), ClearBusy);
            // OnActionStarted?.Invoke(this, EventArgs.Empty);
            
        }
    }
}
