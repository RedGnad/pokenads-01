using UnityEngine;

public class RandomMovementAroundReference : MonoBehaviour
{
    // Référence au point autour duquel le modèle se déplace (par exemple, la caméra)
    public Transform referencePoint;
    // Rayon du cercle dans lequel le modèle se déplace autour de la référence
    public float radius = 2.0f;
    // Vitesse de déplacement vers la position cible
    public float moveSpeed = 1.0f;
    
    // Position cible actuelle
    private Vector3 targetPosition;

    void Start()
    {
        if (referencePoint == null)
        {
            Debug.LogError("Aucune référence (referencePoint) n'est assignée !");
            enabled = false;
            return;
        }
        SetNewTargetPosition();
    }

    void Update()
    {
        // Déplacer le modèle vers la position cible
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        // Si le modèle atteint la position cible, en définir une nouvelle
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewTargetPosition();
        }

        // Toujours orienter le modèle vers la référence (la caméra)
        Vector3 directionToReference = referencePoint.position - transform.position;
        if(directionToReference != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(directionToReference);
        }
    }

    void SetNewTargetPosition()
    {
        // Générer une direction aléatoire dans le plan horizontal (X, Z)
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        // Définir la nouvelle position cible autour de la référence
        targetPosition = new Vector3(
            referencePoint.position.x + randomDir.x * radius,
            transform.position.y,  // Conserver la hauteur actuelle
            referencePoint.position.z + randomDir.y * radius
        );
    }
}
