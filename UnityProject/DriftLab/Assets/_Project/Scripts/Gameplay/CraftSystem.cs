using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private SurvivalStats survivalStats;

    public void CraftFilter()
    {
        if (inventorySystem == null)
        {
            Debug.Log("InventorySystem nao configurado.");
            return;
        }

        if (inventorySystem.HasItem("Water", 1) && inventorySystem.HasItem("Charcoal", 1))
        {
            inventorySystem.RemoveItem("Water", 1);
            inventorySystem.RemoveItem("Charcoal", 1);
            inventorySystem.AddItem("Filter", 1);
            Debug.Log("Filtro criado!");
            return;
        }

        Debug.Log("Faltam recursos!");
    }

    public void DrinkWater()
    {
        if (inventorySystem == null || survivalStats == null)
        {
            Debug.Log("CraftSystem incompleto para beber agua.");
            return;
        }

        if (!inventorySystem.TryConsumeItem("Water", 1))
        {
            Debug.Log("Sem agua no inventario.");
            return;
        }

        survivalStats.RestoreThirst(30f);
        Debug.Log("Agua consumida!");
    }

    public void EatFood()
    {
        if (inventorySystem == null || survivalStats == null)
        {
            Debug.Log("CraftSystem incompleto para comer.");
            return;
        }

        if (!inventorySystem.TryConsumeItem("Food", 1))
        {
            Debug.Log("Sem comida no inventario.");
            return;
        }

        survivalStats.RestoreHunger(25f);
        Debug.Log("Comida consumida!");
    }
}
