using UnityEngine;

public class SurvivalStats : MonoBehaviour
{
    [SerializeField] private float maxHunger = 100f;
    [SerializeField] private float maxThirst = 100f;
    [SerializeField] private float hungerDrainPerSecond = 1f;
    [SerializeField] private float thirstDrainPerSecond = 1.5f;

    private float currentHunger;
    private float currentThirst;

    public float HungerNormalized => maxHunger <= 0f ? 0f : currentHunger / maxHunger;
    public float ThirstNormalized => maxThirst <= 0f ? 0f : currentThirst / maxThirst;
    public int HungerRounded => Mathf.CeilToInt(currentHunger);
    public int ThirstRounded => Mathf.CeilToInt(currentThirst);

    private void Start()
    {
        currentHunger = maxHunger;
        currentThirst = maxThirst;
        NotifyUI();
    }

    private void Update()
    {
        currentHunger = Mathf.Max(0f, currentHunger - hungerDrainPerSecond * Time.deltaTime);
        currentThirst = Mathf.Max(0f, currentThirst - thirstDrainPerSecond * Time.deltaTime);
        NotifyUI();
    }

    public void RestoreHunger(float amount)
    {
        currentHunger = Mathf.Clamp(currentHunger + amount, 0f, maxHunger);
        NotifyUI();
    }

    public void RestoreThirst(float amount)
    {
        currentThirst = Mathf.Clamp(currentThirst + amount, 0f, maxThirst);
        NotifyUI();
    }

    private void NotifyUI()
    {
        SurvivalUI survivalUI = FindFirstObjectByType<SurvivalUI>();
        if (survivalUI != null)
        {
            survivalUI.Refresh(this);
        }
    }
}
