using UnityEngine;

public class ParticleEffectTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject particlePrefab; // Assurez-vous que ce champ est correctement assigné

    [SerializeField]
    private Transform effectSpawnPoint; // Optionnel, sinon le script utilisera transform.position

    public void TriggerEffect()
    {
        Debug.Log("TriggerEffect appelé sur " + gameObject.name);
        if (particlePrefab != null)
        {
            Vector3 spawnPos = effectSpawnPoint != null ? effectSpawnPoint.position : transform.position;
            GameObject effect = Instantiate(particlePrefab, spawnPos, Quaternion.identity);
            Debug.Log("Effet de particule instancié à " + spawnPos);
        }
        else
        {
            Debug.LogWarning("Particle prefab non assigné dans ParticleEffectTrigger sur " + gameObject.name);
        }
    }
}