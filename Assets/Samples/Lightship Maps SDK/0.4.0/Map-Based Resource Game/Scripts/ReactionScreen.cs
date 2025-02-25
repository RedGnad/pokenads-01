namespace MyGame.ReactionScreen
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class LoadingScreenManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject loadingScreenPanel; // Panneau de chargement assigné dans l'inspecteur

        // Valeur par défaut pour réinitialiser si besoin
        [SerializeField]
        private float defaultLoadingTime = 3f;

        private float currentLoadingTime;

        void Awake()
        {
            // Récupère la durée de chargement configurée globalement
            currentLoadingTime = SceneTransitionData.LoadingTime;
        }

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
            yield return new WaitForSeconds(currentLoadingTime);
            loadingScreenPanel.SetActive(false);
            
            // Réinitialise la durée par défaut pour les transitions suivantes
            SceneTransitionData.LoadingTime = defaultLoadingTime;
        }
    }
}