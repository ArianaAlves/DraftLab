using System.Collections.Generic;
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

        string inventoryText = "Inventario:";

        foreach (KeyValuePair<string, int> entry in items)
        {
            inventoryText += "\n" + entry.Key + ": " + entry.Value;
        }

        return inventoryText;
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
