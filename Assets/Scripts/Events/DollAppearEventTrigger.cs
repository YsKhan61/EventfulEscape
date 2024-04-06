using UnityEngine;

public class DollAppearEventTrigger : MonoBehaviour
{
    [SerializeField] private int keysRequiredToTrigger;
    [SerializeField] private DollView doll;
    [SerializeField] private SoundType soundToPlay;
    
    [SerializeField, Tooltip("The position and rotation that the doll will be set to")] 
    private Transform target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null && GameService.Instance.GetPlayerController().KeysEquipped == keysRequiredToTrigger)
        {
            doll.SetPose(new Pose(target.position, target.rotation));
            doll.Show();
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            EventService.Instance.AfterDollAppear.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
            GetComponent<Collider>().enabled = false;
        }
    }
}