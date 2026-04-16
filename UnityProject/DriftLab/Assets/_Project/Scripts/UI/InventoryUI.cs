using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private Text inventoryText;

    private void Start()
    {
        Refresh(inventorySystem);
    }

    public void Refresh(InventorySystem inventory)
    {
        if (inventoryText == null)
        {
            return;
        }

        if (inventory == null)
        {
            inventoryText.text = "Inventario: vazio";
            return;
        }

        inventoryText.text = inventory.GetInventoryText();
    }
}
