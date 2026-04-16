using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private readonly Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string itemId, int amount)
    {
        if (string.IsNullOrWhiteSpace(itemId) || amount <= 0)
        {
            return;
        }

        if (!items.ContainsKey(itemId))
        {
            items[itemId] = 0;
        }

        items[itemId] += amount;
        NotifyUI();
    }

    public bool HasItem(string itemId, int amount)
    {
        return GetItemAmount(itemId) >= amount;
    }

    public bool RemoveItem(string itemId, int amount)
    {
        if (!HasItem(itemId, amount))
        {
            return false;
        }

        items[itemId] -= amount;

        if (items[itemId] <= 0)
        {
            items.Remove(itemId);
        }

        NotifyUI();
        return true;
    }

    public int GetItemAmount(string itemId)
    {
        if (string.IsNullOrWhiteSpace(itemId) || !items.ContainsKey(itemId))
        {
            return 0;
        }

        return items[itemId];
    }

    public string GetInventoryText()
    {
        if (items.Count == 0)
        {
            return "Inventario: vazio";
        }

        StringBuilder inventoryText = new StringBuilder("Inventario:");

        foreach (KeyValuePair<string, int> entry in items)
        {
            inventoryText.Append("\n").Append(entry.Key).Append(": ").Append(entry.Value);
        }

        return inventoryText.ToString();
    }

    public bool TryConsumeItem(string itemId, int amount)
    {
        return RemoveItem(itemId, amount);
    }

    private void NotifyUI()
    {
        InventoryUI inventoryUI = FindFirstObjectByType<InventoryUI>();
        if (inventoryUI != null)
        {
            inventoryUI.Refresh(this);
        }
    }
}
