using UnityEngine;

public class DollView : MonoBehaviour
{
    [SerializeField]
    private GameObject m_DollLight;

    private void OnEnable()
    {
        EventService.Instance.OnLightSwitchToggled.AddListener(Hide);
    }

    private void Start()
    {
        Hide();
    }

    private void OnDisable()
    {
        EventService.Instance.OnLightSwitchToggled.RemoveListener(Hide);
    }

    public void SetPose(in Pose pose)
    {
        transform.position = pose.position;
        transform.rotation = pose.rotation;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        m_DollLight.gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        m_DollLight.gameObject.SetActive(false);
    }
}
