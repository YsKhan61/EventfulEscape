using UnityEngine;

public class AchivementService : MonoBehaviour
{
    [SerializeField]
    AchivementUIView uiView;

    [Header("Achivement of all keys equipped")]

    [SerializeField]
    private IntDataSO totalKeys;

    [SerializeField]
    private StringDataSO allKeysCollectedMessage;

    [Space(10)]

    [SerializeField]
    private IntDataSO totalPotions;

    [SerializeField]
    private StringDataSO allPotionsCollectedMessage;



    private void OnEnable()
    {
        EventService.Instance.OnKeyPickedUp.AddListener(OnKeyPickedUp);
        EventService.Instance.AfterPotionDrink.AddListener(OnPotionDrink);
    }

    private void Awake()
    {
        uiView.HideAchivement(0);
    }

    private void OnDisable()
    {
        EventService.Instance.OnKeyPickedUp.RemoveListener(OnKeyPickedUp);
        EventService.Instance.AfterPotionDrink.RemoveListener(OnPotionDrink);
    }

    private void OnPotionDrink(int _)
    {
        int potionsEquipped = GameService.Instance.GetPlayerController().PotionsEquipped;
        if (potionsEquipped == totalPotions.Value)
        {
            uiView.ShowAchivement(allPotionsCollectedMessage.Value);
            GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.AchivementUnlock);
            uiView.HideAchivement(3);
        }
    }

    private void OnKeyPickedUp(int currentKeys)
    {
        if (currentKeys == totalKeys.Value)
        {
            uiView.ShowAchivement(allKeysCollectedMessage.Value);
            GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.AchivementUnlock); 
            uiView.HideAchivement(3);
        }
    }
}
