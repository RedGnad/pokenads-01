using UnityEngine;
using UnityEngine.SceneManagement;

namespace Niantic.Lightship.Maps.Samples.GameSample
{
    public class ScreenManager : MonoBehaviour
    {
        public static ScreenManager Instance;

        [SerializeField]
        private GameObject secondScreenPanel;

        private void Awake()
        {
            Instance = this;
        }

        public void ShowSecondScreen()
        {
            SceneTransitionData.LoadingTime = 1f;
            SceneManager.LoadScene("CameraFeedScene");
        }

        public void ReturnToMap()
        {
            Debug.Log("ReturnToMap appelée");
            SceneTransitionData.LoadingTime = 1f;
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