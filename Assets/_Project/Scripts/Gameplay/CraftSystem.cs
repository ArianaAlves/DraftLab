using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;

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
}
