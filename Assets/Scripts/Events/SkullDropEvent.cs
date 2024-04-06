using System.Threading.Tasks;
using UnityEngine;

public class SkullDropEvent : MonoBehaviour
{
    [SerializeField] private int keysRequiredToTrigger;
    [SerializeField] private Transform skulls;
    [SerializeField] private SoundType soundToPlay;

    [SerializeField]
    LightFlicker[] lights;

    private void Awake()
    {
        skulls.gameObject.SetActive(false);
        ToggleFlickeringLights(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null && GameService.Instance.GetPlayerController().KeysEquipped >= keysRequiredToTrigger)
        {
            OnSkullDrop();
            GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
            GetComponent<Collider>().enabled = false;
        }
    }

    private async void OnSkullDrop()
    {
        EventService.Instance.AfterSkullShower.InvokeEvent();
        skulls.gameObject.SetActive(true);
        ToggleFlickeringLights(true);

        await Task.Delay(5000);     // 5 seconds to wait for the skull to drop
        ToggleFlickeringLights(false);
    }

    private void ToggleFlickeringLights(bool on)
    {
        foreach (var light in lights)
        {
            light.enabled = on;
        }
    }
}
