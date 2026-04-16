using UnityEngine;
using UnityEngine.UI;

public class SurvivalUI : MonoBehaviour
{
    [SerializeField] private SurvivalStats survivalStats;
    [SerializeField] private Text hungerText;
    [SerializeField] private Text thirstText;

    private void Start()
    {
        Refresh(survivalStats);
    }

    public void Refresh(SurvivalStats stats)
    {
        if (stats == null)
        {
            return;
        }

        if (hungerText != null)
        {
            hungerText.text = "Fome: " + stats.HungerRounded;
        }

        if (thirstText != null)
        {
            thirstText.text = "Sede: " + stats.ThirstRounded;
        }
    }
}
