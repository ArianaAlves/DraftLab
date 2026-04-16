using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour
{
    [SerializeField] private Text itemText;

    private int collectedItems;

    private void Start()
    {
        UpdateUI();
    }

    public void AddItem(int amount)
    {
        collectedItems += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (itemText == null)
        {
            return;
        }

        itemText.text = "Itens coletados: " + collectedItems;
    }
}
