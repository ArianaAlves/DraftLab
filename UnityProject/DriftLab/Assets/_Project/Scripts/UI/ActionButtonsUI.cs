using UnityEngine;
using UnityEngine.UI;

public class ActionButtonsUI : MonoBehaviour
{
    [SerializeField] private CraftSystem craftSystem;
    [SerializeField] private Text feedbackText;

    public void CraftFilter()
    {
        if (craftSystem == null)
        {
            SetFeedback("CraftSystem nao configurado.");
            return;
        }

        craftSystem.CraftFilter();
        SetFeedback("Tentando criar filtro...");
    }

    public void DrinkWater()
    {
        if (craftSystem == null)
        {
            SetFeedback("CraftSystem nao configurado.");
            return;
        }

        craftSystem.DrinkWater();
        SetFeedback("Tentando beber agua...");
    }

    public void EatFood()
    {
        if (craftSystem == null)
        {
            SetFeedback("CraftSystem nao configurado.");
            return;
        }

        craftSystem.EatFood();
        SetFeedback("Tentando comer...");
    }

    private void SetFeedback(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
        }
    }
}
