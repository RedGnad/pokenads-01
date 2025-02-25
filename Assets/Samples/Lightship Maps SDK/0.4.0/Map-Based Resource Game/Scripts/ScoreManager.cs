using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TMP_Text scoreText; // Assignez le TextMeshProUGUI pour afficher le score
    [SerializeField] private Button returnButton;  // Assignez le bouton de retour

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        UpdateScoreUI();

        if (returnButton != null)
            returnButton.gameObject.SetActive(false);
    }

    public void AddScore()
    {
        score++;
        UpdateScoreUI();

        if (score >= 10 && returnButton != null)
            returnButton.gameObject.SetActive(true);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score : " + score;
    }

    public void ReturnToMap()
    {
        // Remplacez "MapScreen" par le nom réel de la scène de la carte
        SceneManager.LoadScene("MapScreen");
    }
}