using UnityEngine;
using UnityEngine.SceneManagement;

namespace Niantic.Lightship.Maps.Samples.GameSample
{
    public class ScreenManager : MonoBehaviour
    {
        public static ScreenManager Instance;

        [SerializeField]
        private GameObject secondScreenPanel; // Ce champ n'est plus utilisé pour l'affichage du flux

        private void Awake()
        {
            Instance = this;
        }

        public void ShowSecondScreen()
        {
            Debug.Log("ShowSecondScreen appelée");
            // Charge la scène "CameraFeedScene"
            SceneManager.LoadScene("CameraFeedScene");
        }

        // Nouvelle méthode pour retourner sur l'écran Map avec un temps de chargement de 1 seconde
        public void ReturnToMap()
        {
            Debug.Log("ReturnToMap appelée");
            // Définir la durée de chargement à 1 seconde pour la transition AR -> Map
            SceneTransitionData.LoadingTime = 1f;
            // Chargez la scène map ; remplacez "MapScreenScene" par le nom réel de votre scène de carte
            SceneManager.LoadScene("MapScreenScene");
        }

        public void HideSecondScreen()
        {
            if (secondScreenPanel != null)
            {
                secondScreenPanel.SetActive(false);
            }
        }
    }
}