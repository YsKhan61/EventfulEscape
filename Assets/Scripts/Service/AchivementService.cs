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

    [Space(10)]

    [Header("Achivement of player spent lot of time in dark")]

    [SerializeField, Tooltip("Minimum seconds to spend in darkness")]
    private int secondsInDark;

    [SerializeField]
    private StringDataSO playerInDarkMessage;

    private PlayerSanity playerSanity;

    private bool playerSpentLotOfTimeInDarkAchivementInvoked = false;

    private void Awake()
    {
        uiView.HideAchivement(0);
    }


    private void OnEnable()
    {
        EventService.Instance.OnKeyPickedUp.AddListener(OnKeyPickedUp);
        EventService.Instance.AfterPotionDrink.AddListener(OnPotionDrink);
        EventService.Instance.PlayerEscapedEvent.AddListener(OnPlayerEscaped);
    }

    private void Start()
    {
        playerSanity = GameService.Instance.GetPlayerController().playerSanity;
    }

    private void Update()
    {

        TryInvokePlayerInDarkAchivement();
        
    }

    private void OnDisable()
    {
        EventService.Instance.OnKeyPickedUp.RemoveListener(OnKeyPickedUp);
        EventService.Instance.AfterPotionDrink.RemoveListener(OnPotionDrink);
        EventService.Instance.PlayerEscapedEvent.RemoveListener(OnPlayerEscaped);
    }

    private void TryInvokePlayerInDarkAchivement()
    {
        if (playerSanity.TimeSpentInDark >= secondsInDark && !playerSpentLotOfTimeInDarkAchivementInvoked)
        {
            InvokeAchivement(playerInDarkMessage.Value);
            playerSpentLotOfTimeInDarkAchivementInvoked = true;
        }
    }

    private void OnPotionDrink(int _)
    {
        int potionsEquipped = GameService.Instance.GetPlayerController().PotionsEquipped;
        if (potionsEquipped == totalPotions.Value)
        {
            InvokeAchivement(allPotionsCollectedMessage.Value);
        }
    }

    private void OnKeyPickedUp(int currentKeys)
    {
        if (currentKeys == totalKeys.Value)
        {
            InvokeAchivement(allKeysCollectedMessage.Value);
        }
    }

    private void OnPlayerEscaped()
    {
        if (playerSanity.SanityLevel >= minSanityLevel)
        {
            InvokeAchivement(playerTormentedMessage.Value);
        }
    }

    private void InvokeAchivement(string message)
    {
        uiView.ShowAchivement(message);
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.AchivementUnlock);
        uiView.HideAchivement(3);
    }

}
