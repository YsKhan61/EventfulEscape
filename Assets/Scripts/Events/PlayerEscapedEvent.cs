using UnityEngine;

public class PlayerEscapedEvent : MonoBehaviour
{
    [SerializeField] private SoundType soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerView view))
        {
            GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
            EventService.Instance.PlayerEscapedEvent.InvokeEvent();
            GetComponent<Collider>().enabled = false;
        }
    }
}
