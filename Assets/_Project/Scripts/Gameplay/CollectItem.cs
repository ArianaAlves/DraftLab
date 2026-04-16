using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private string itemId = "Water";
    [SerializeField] private int amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        InventorySystem inventorySystem = other.GetComponent<InventorySystem>();
        if (inventorySystem != null)
        {
            inventorySystem.AddItem(itemId, amount);
        }

        ItemCounter itemCounter = FindFirstObjectByType<ItemCounter>();
        if (itemCounter != null)
        {
            itemCounter.AddItem(amount);
        }

        Debug.Log("Item coletado: " + itemId + " x" + amount);
        Destroy(gameObject);
    }
}
