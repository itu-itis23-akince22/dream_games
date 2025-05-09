using TMPro;
using UnityEngine;


public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    public void SetProgress(float progress)
    {
        loadingText.text = progress < 0.25f ? "Loading" :
                           progress < 0.50f ? "Loading." :
                           progress < 0.75f ? "Loading.." :
                                              "Loading...";
    }
}
