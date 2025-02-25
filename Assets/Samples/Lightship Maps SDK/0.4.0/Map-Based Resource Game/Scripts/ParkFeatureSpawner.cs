using System.Collections.Generic;
using UnityEngine;

public class ParkFeatureSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject parkFeaturePrefab; // Assignez votre prefab dans l'inspecteur

    [SerializeField]
    private int numberOfFeatures = 10; // Nombre de features à instancier

    [SerializeField]
    private float spawnRadius = 50f; // Rayon autour du joueur pour le spawn

    [System.Serializable]
    public class FeatureData
    {
        public Vector3 position;
        public bool collected;
    }

    // Liste statique pour conserver les données des features durant la session
    private static List<FeatureData> spawnedFeatures = new List<FeatureData>();

    void Start()
    {
        if (spawnedFeatures.Count > 0)
        {
            foreach (FeatureData feature in spawnedFeatures)
            {
                if (!feature.collected)
                    Instantiate(parkFeaturePrefab, feature.position, Quaternion.identity);
            }
        }
        else
        {
            SpawnFeaturesAroundPlayer();
        }
    }

    private void SpawnFeaturesAroundPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player not found in the scene.");
            return;
        }

        Vector3 playerPos = player.transform.position;

        for (int i = 0; i < numberOfFeatures; i++)
        {
            // Génère une position aléatoire dans un cercle autour du joueur
            Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPos = new Vector3(playerPos.x + randomPoint.x, playerPos.y, playerPos.z + randomPoint.y);

            FeatureData data = new FeatureData();
            data.position = spawnPos;
            data.collected = false;
            spawnedFeatures.Add(data);

            Instantiate(parkFeaturePrefab, spawnPos, Quaternion.identity);
        }
    }

    // Ajoutez cette méthode pour marquer une feature comme collectée
    public static void MarkFeatureCollected(Vector3 featurePosition)
    {
        float tolerance = 1.0f; // Tolérance pour la comparaison de positions
        foreach (FeatureData feature in spawnedFeatures)
        {
            if (!feature.collected && Vector3.Distance(feature.position, featurePosition) < tolerance)
            {
                feature.collected = true;
                break;
            }
        }
    }
}