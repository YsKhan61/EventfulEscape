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

    [Header("Achivement of all potions equipped")]

    [SerializeField]
    private IntDataSO totalPotions;

    [SerializeField]
    private StringDataSO allPotionsCollectedMessage;

    [Space(10)]

    [Header("Achivement of player escaped with 90% insanity")]

    [SerializeField, Tooltip("Minimum sanity level to be considered tormented")]
    [Range(0, 1)]
    private float minSanityLevel;

    [SerializeField]
    private StringDataSO playerTormentedMessage;



    private void OnEnable()
    {
        EventService.Instance.OnKeyPickedUp.AddListener(OnKeyPickedUp);
        EventService.Instance.AfterPotionDrink.AddListener(OnPotionDrink);
        EventService.Instance.PlayerEscapedEvent.AddListener(OnPlayerEscaped);
    }

    private void Awake()
    {
        uiView.HideAchivement(0);
    }

    private void OnDisable()
    {
        EventService.Instance.OnKeyPickedUp.RemoveListener(OnKeyPickedUp);
        EventService.Instance.AfterPotionDrink.RemoveListener(OnPotionDrink);
        EventService.Instance.PlayerEscapedEvent.RemoveListener(OnPlayerEscaped);
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

    private void OnPlayerEscaped()
    {
        float sanityLevel = GameService.Instance.GetPlayerController().playerSanity.SanityLevel;
        if (sanityLevel >= minSanityLevel)
        {
            uiView.ShowAchivement(playerTormentedMessage.Value);
            GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.AchivementUnlock);
            uiView.HideAchivement(3);
        }
    }

}
