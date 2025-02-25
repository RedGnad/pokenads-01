using UnityEngine;
using UnityEngine.UI;

public class CameraFeedDisplay : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImage; // Assignez ce RawImage via l'inspecteur

    private WebCamTexture webCamTexture;

    private void Awake()
    {
        Debug.Log("[CameraFeedDisplay] Awake appelé");
        if (rawImage != null)
        {
            Debug.Log("[CameraFeedDisplay] Désactivation du RawImage au démarrage");
            rawImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("[CameraFeedDisplay] rawImage non assigné dans l'inspecteur");
        }
    }

    // Méthode à appeler pour démarrer le flux de la caméra
    public void StartCameraFeed()
    {
        Debug.Log("[CameraFeedDisplay] StartCameraFeed appelé");
        Debug.Log("[CameraFeedDisplay] Nombre de webcams détectées : " + WebCamTexture.devices.Length);

        if (WebCamTexture.devices.Length > 0)
        {
            if (rawImage != null)
            {
                Debug.Log("[CameraFeedDisplay] Réactivation du RawImage pour afficher le flux");
                rawImage.gameObject.SetActive(true);

                Debug.Log("[CameraFeedDisplay] Création d'un WebCamTexture");
                webCamTexture = new WebCamTexture();

                Debug.Log("[CameraFeedDisplay] Assignation des textures du RawImage");
                rawImage.texture = webCamTexture;
                rawImage.material.mainTexture = webCamTexture;

                Debug.Log("[CameraFeedDisplay] Démarrage de la caméra");
                webCamTexture.Play();
            }
            else
            {
                Debug.LogError("[CameraFeedDisplay] rawImage est null, impossible d'afficher le flux");
            }
        }
        else
        {
            Debug.LogWarning("[CameraFeedDisplay] Aucune webcam détectée sur cet appareil.");
        }
    }
}