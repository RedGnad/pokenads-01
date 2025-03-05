using UnityEngine;
using FT = Niantic.Lightship.Maps.Samples.GameSample.FloatingText.FloatingText;

namespace Niantic.Lightship.Maps.Samples.GameSample
{
    internal class FloatingTextManager : MonoBehaviour
    {
        public static FloatingTextManager Instance;

        [SerializeField]
        private GameObject floatingTextPrefab;
        
        [SerializeField]
        private bool enableFloatingText = false;
        private void Awake()
        {
            Instance = this;
        }

        public void ShowText(string text, Vector3 position)
        {
            
            if (!enableFloatingText)
            {
                return;
            }
            
            GameObject clone = Instantiate(floatingTextPrefab, position, Quaternion.identity);
            if (clone != null)
            {
                Debug.Log("[FloatingTextManager] Prefab ok");
            }
            else
            {
                return;
            }

            FT floatText = clone.GetComponent<FT>();
            if (floatText != null)
            {
                floatText.SetText(text);
            }
            else
            {
                Debug.LogError("[FloatingTextManager] Le composant FloatingText n'a pas été trouvé sur le prefab");
            }
        }
    }
}