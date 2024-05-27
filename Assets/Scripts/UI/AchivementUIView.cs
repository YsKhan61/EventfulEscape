using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class AchivementUIView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI achivementText;

    public void ShowAchivement(in string achivement)
    {
        achivementText.gameObject.SetActive(true);
        achivementText.SetText(achivement);
    }

    public async void HideAchivement(int time)
    {
        await Task.Delay(time * 1000);

        achivementText.SetText("");
        achivementText.gameObject.SetActive(false);
    }
}
