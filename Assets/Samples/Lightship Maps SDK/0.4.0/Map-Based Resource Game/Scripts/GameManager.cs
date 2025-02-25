using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int generalScore = 0;

    private void Awake()
    {
        // Si aucune instance n'existe, on la définit et on la rend persistante
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

    // Méthode pour ajouter des points au score général
    public void AddScore(int points)
    {
        generalScore += points;
        Debug.Log("Score général mis à jour : " + generalScore);
    }
}
