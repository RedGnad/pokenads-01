using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingScreenPanel; // Assignez votre panneau de chargement dans l'inspecteur

    // Optionnel : durée minimale d'affichage de l'écran de chargement
    [SerializeField]
    private float minimumLoadingTime = 3f;

    void Start()
    {
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(true);
            StartCoroutine(HideLoadingScreen());
        }
    }

    private IEnumerator HideLoadingScreen()
    {
        // Ici, vous pouvez insérer des conditions pour attendre la fin de toutes les initialisations (ex.: vos spawns, chargement de la map, etc.)
        yield return new WaitForSeconds(minimumLoadingTime);
        loadingScreenPanel.SetActive(false);
    }
}