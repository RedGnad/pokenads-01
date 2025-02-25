using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveObject : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Recherche automatique du composant ParticleEffectTrigger sur le même GameObject
        ParticleEffectTrigger effectTrigger = GetComponent<ParticleEffectTrigger>();
        if (effectTrigger != null)
        {
            effectTrigger.TriggerEffect();
        }
        else
        {
            Debug.LogWarning("Aucun composant ParticleEffectTrigger trouvé sur " + gameObject.name);
        }
    }
}