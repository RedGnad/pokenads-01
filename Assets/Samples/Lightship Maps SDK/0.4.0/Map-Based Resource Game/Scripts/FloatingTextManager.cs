using UnityEngine;
// Création d'un alias "FT" pour la classe FloatingText dans le namespace correspondant
using FT = Niantic.Lightship.Maps.Samples.GameSample.FloatingText.FloatingText;

namespace Niantic.Lightship.Maps.Samples.GameSample
{
    internal class FloatingTextManager : MonoBehaviour
    {
        public static FloatingTextManager Instance;

        [SerializeField]
        private GameObject floatingTextPrefab; // Ce prefab doit contenir le composant FloatingText (classe FT)
        
        // Contrôle l'affichage des floating texts
        [SerializeField]
        private bool enableFloatingText = false; // false pour désactiver temporairement

        private void Awake()
        {
            Instance = this;
            Debug.Log("[FloatingTextManager] Awake - Instance établie.");
        }

        public void ShowText(string text, Vector3 position)
        {
            Debug.Log($"[FloatingTextManager] ShowText appelé avec le texte : \"{text}\" à la position : {position}");

            if (!enableFloatingText)
            {
                Debug.Log("[FloatingTextManager] Affichage des floating texts désactivé.");
                return;
            }
            
            // Instanciation du prefab à la position donnée
            GameObject clone = Instantiate(floatingTextPrefab, position, Quaternion.identity);
            if (clone != null)
            {
                Debug.Log("[FloatingTextManager] Prefab instancié avec succès.");
            }
            else
            {
                Debug.LogError("[FloatingTextManager] L'instanciation du prefab a échoué.");
                return;
            }

            // Récupération du composant FloatingText via l'alias FT
            FT floatText = clone.GetComponent<FT>();
            if (floatText != null)
            {
                Debug.Log("[FloatingTextManager] Composant FloatingText récupéré, définition du texte.");
                floatText.SetText(text);
            }
            else
            {
                Debug.LogError("[FloatingTextManager] Le composant FloatingText n'a pas été trouvé sur le prefab instancié.");
            }
        }
    }
}