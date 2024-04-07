using UnityEngine;

public class AchivementService : MonoBehaviour
{
    [SerializeField]
    AchivementUIView uiView;

    [SerializeField]
    private IntDataSO totalKeys;

    [SerializeField]
    private StringDataSO allKeysCollectedMessage;

    private void OnEnable()
    {
        EventService.Instance.OnKeyPickedUp.AddListener(OnKeyPickedUp);
    }

    private void Awake()
    {
        uiView.HideAchivement(0);
    }

    private void OnDisable()
    {
        EventService.Instance.OnKeyPickedUp.RemoveListener(OnKeyPickedUp);
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
