public class EventService
{
    private static EventService instance;
    public static EventService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventService();
            }
            return instance;
        }
    }

    public EventController OnLightSwitchToggled { get; private set; }
    public EventController<int> OnKeyPickedUp { get; private set; }
    public EventController OnLightsOffByGhostEvent { get; private set; }

    public EventController PlayerEscapedEvent { get; private set; }
    public EventController PlayerDeathEvent { get; private set; }

    public EventController AfterRatRush { get; private set; }
    public EventController AfterSkullShower { get; private set; }
    public EventController<int> AfterPotionDrink { get; private set; }
    public EventController AfterDollAppear { get; private set; }

    public EventController OnScaryImageSeen { get; private set; }

    public EventService()
    {
        OnLightSwitchToggled = new EventController();
        OnKeyPickedUp = new EventController<int>();

        OnLightsOffByGhostEvent = new EventController();

        PlayerEscapedEvent = new EventController();
        PlayerDeathEvent = new EventController();

        AfterRatRush = new EventController();
        AfterSkullShower = new EventController();
        AfterPotionDrink = new EventController<int>();
        AfterDollAppear = new EventController();
        OnScaryImageSeen = new EventController();
    }
}
