using System;
using UnityEngine;

namespace Niantic.Lightship.Maps.Samples.GameSample
{
    internal class MapGameResourceFeature : MonoBehaviour
    {
        [SerializeField]
        private MapGameState.ResourceType _resourceType;

        [SerializeField]
        private int _maxUnits;
        public MapGameState.ResourceType ResourceType => _resourceType;

        private int _currentUnits;
        private float _resourceIncreaseTime;

        public bool ResourcesAvailable => _currentUnits > 0;

        public int GainResources()
        {
            // Recherche du joueur via son tag "Player"
            GameObject player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                Debug.LogWarning("Player not found in the scene.");
                return 0;
            }

            // Vérification de la distance entre le joueur et la feature
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > 30.0f)
            {
                Debug.Log("Player is too far to collect resources (" + distance + "f).");
                return 0;
            }

            // Si aucune ressource n'est accumulée, on ne fait rien
            if (_currentUnits <= 0)
            {
                return 0;
            }

            // Récupération et réinitialisation des ressources accumulées
            int currentUnits = _currentUnits;
            _currentUnits = 0;
            
            // Affichage d'un texte flottant pour indiquer la récolte
            FloatingTextManager.Instance?.ShowText($"+{currentUnits} nads", transform.position);

            // Ouverture du second écran (par exemple pour la réalité augmentée)
            ScreenManager.Instance?.ShowSecondScreen();
            
            // Marquer la feature comme collectée pour qu'elle ne soit plus utilisée
            ParkFeatureSpawner.MarkFeatureCollected(transform.position);

            // Supprimer la feature de la map
            Destroy(gameObject);

            return currentUnits;
        }

        private void Update()
        {
            // Augmente les ressources toutes les 2 secondes jusqu'à atteindre le maximum (_maxUnits)
            if (Time.time > _resourceIncreaseTime + 2.0f)
            {
                _resourceIncreaseTime = Time.time;
                _currentUnits = Mathf.Min(_currentUnits + 1, _maxUnits);
            }
        }
    }
}