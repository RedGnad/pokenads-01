using UnityEngine;
using TMPro;

public class MapScreenUI : MonoBehaviour
{
    public TextMeshProUGUI generalScoreText;  // Ou [SerializeField] private TextMeshProUGUI generalScoreText;

    void Start()
    {
        if (generalScoreText != null && GameManager.Instance != null)
        {
            generalScoreText.text = "Score général : " + GameManager.Instance.generalScore;
        }
    }
}
