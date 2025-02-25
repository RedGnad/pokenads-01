using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int generalScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        generalScore += points;
    }
}
