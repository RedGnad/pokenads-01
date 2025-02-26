using UnityEngine;
using TMPro;

public class MapGameUI : MonoBehaviour
{
    public TextMeshProUGUI generalScoreText;

    void OnEnable()
    {
        RefreshScore();
    }

    void RefreshScore()
    {
        if (generalScoreText != null && GameManager.Instance != null)
        {
            generalScoreText.text = "Score général : " + GameManager.Instance.generalScore;
        }
    }

    public void OnReturnToMapScreen()
    {
        RefreshScore();
    }
}