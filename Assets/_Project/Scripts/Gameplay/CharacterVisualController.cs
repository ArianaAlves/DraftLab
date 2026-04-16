using UnityEngine;

public class CharacterVisualController : MonoBehaviour
{
    [SerializeField] private PlayerProfile playerProfile;
    [SerializeField] private Renderer[] primaryRenderers;
    [SerializeField] private Renderer[] secondaryRenderers;

    private void Start()
    {
        ApplyCurrentCustomization();
    }

    public void ApplyCurrentCustomization()
    {
        if (playerProfile == null)
        {
            return;
        }

        CustomizationOption outfit = playerProfile.SelectedOutfit;
        if (outfit == null)
        {
            return;
        }

        ApplyColor(primaryRenderers, outfit.PrimaryColor);
        ApplyColor(secondaryRenderers, outfit.SecondaryColor);
    }

    private void ApplyColor(Renderer[] renderers, Color colorValue)
    {
        foreach (Renderer rendererComponent in renderers)
        {
            if (rendererComponent == null || rendererComponent.material == null)
            {
                continue;
            }

            rendererComponent.material.color = colorValue;
        }
    }
}
