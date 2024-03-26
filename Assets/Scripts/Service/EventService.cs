using System;

public class EventService
{
    public EventController OnLightSwitchToggled { get; private set; }
    public EventController<int> OnKeyEquipped { get; private set; } 

    private static EventService m_Instance;
    public static EventService Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new EventService();
            }
            return m_Instance;
        }
    }

    public EventService()
    {
        OnLightSwitchToggled = new EventController();
        OnKeyEquipped = new EventController<int>();
    }
}

