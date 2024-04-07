using UnityEngine;

public class PotionView : MonoBehaviour, IInteractable
{
    [SerializeField] SoundType soundType;
    private int potionEffect = 20;

    public void Interact()
    {
        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(soundType);

        GameService.Instance.GetPlayerController().PotionsEquipped += 1;

        EventService.Instance.AfterPotionDrink.InvokeEvent(potionEffect);
        gameObject.SetActive(false);
    }
}
