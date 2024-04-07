using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    [SerializeField] private float sanityLevel = 100.0f;
    public float SanityLevel => sanityLevel;
    [SerializeField] private float sanityDropRate = 0.2f;
    [SerializeField] private float sanityDropAmountPerEvent = 10f;
    private float maxSanity;
    private PlayerController playerController;

    private float timeSpentInDark = 0f;
    public float TimeSpentInDark => timeSpentInDark;

    private void OnEnable()
    {
        EventService.Instance.AfterRatRush.AddListener(OnSupernaturalEvent);
        EventService.Instance.AfterSkullShower.AddListener(OnSupernaturalEvent);
        EventService.Instance.AfterPotionDrink.AddListener(OnDrankPotion);
        EventService.Instance.AfterDollAppear.AddListener(OnSupernaturalEvent);
        EventService.Instance.OnScaryImageSeen.AddListener(OnSupernaturalEvent);
    }

    private void Start()
    {
        maxSanity = sanityLevel;
        playerController = GameService.Instance.GetPlayerController();
        playerController.playerSanity = this;
    }
    void Update()
    {
        if (playerController.PlayerState == PlayerState.Dead)
            return;

        float sanityDrop = updateSanity();

        increaseSanity(sanityDrop);

        updateTimeSpentInDark();
    }

    private void OnDisable()
    {
        EventService.Instance.AfterRatRush.RemoveListener(OnSupernaturalEvent);
        EventService.Instance.AfterSkullShower.RemoveListener(OnSupernaturalEvent);
        EventService.Instance.AfterPotionDrink.RemoveListener(OnDrankPotion);
        EventService.Instance.AfterDollAppear.RemoveListener(OnSupernaturalEvent);
        EventService.Instance.OnScaryImageSeen.RemoveListener(OnSupernaturalEvent);
    }

    private float updateSanity()
    {
        float sanityDrop = sanityDropRate * Time.deltaTime;
        if (playerController.PlayerState == PlayerState.InDark)
        {
            sanityDrop *= 10f;
        }
        return sanityDrop;
    }

    private void increaseSanity(float amountToDecrease)
    {
        Mathf.Floor(sanityLevel -= amountToDecrease);
        if (sanityLevel <= 0)
        {
            sanityLevel = 0;
            GameService.Instance.GameOver();
        }
        GameService.Instance.GetGameUI().UpdateInsanity(1f - sanityLevel / maxSanity);
    }

    private void decreaseSanity(float amountToIncrease)
    {
        Mathf.Floor(sanityLevel += amountToIncrease);
        if (sanityLevel > 100)
        {
            sanityLevel = 100;
        }
        GameService.Instance.GetGameUI().UpdateInsanity(1f - sanityLevel / maxSanity);
    }
    private void OnSupernaturalEvent()
    {
        increaseSanity(sanityDropAmountPerEvent);
    }

    private void OnDrankPotion(int potionEffect)
    {
        decreaseSanity(potionEffect);
    }

    private void updateTimeSpentInDark()
    {
        if (playerController.PlayerState == PlayerState.InDark)
        {
            timeSpentInDark += Time.deltaTime;
        }
    }
}