using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject retourButton;

    // Référence au prefab ParticleSystem (assurez-vous de l'assigner dans l'Inspector)
    public ParticleSystem particleSystemPrefab;

    private Collider myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider>();

        // Masquer le bouton de retour au démarrage
        if (retourButton != null)
        {
            retourButton.SetActive(false);
        }
    }

    void Update()
    {
        // Ne traite plus les interactions si le score est déjà à 10
        if (score >= 10)
            return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Vérifie que l'objet touché est bien celui auquel ce script est attaché
                if (hit.transform == transform)
                {
                    score++;
                    Debug.Log("Score: " + score);
                    if (scoreText != null)
                    {
                        scoreText.text = "Score: " + score;
                    }

                    // Instanciation du prefab ParticleSystem à l'endroit du contact
                    if (particleSystemPrefab != null)
                    {
                        ParticleSystem ps = Instantiate(particleSystemPrefab, hit.point, Quaternion.identity);
                        ps.Play();
                        // Détruire l'instance après la fin de l'effet pour éviter d'encombrer la scène
                        Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                    }

                    // Si le score atteint 10, afficher le bouton et désactiver le collider
                    if (score >= 10)
                    {
                        if (retourButton != null)
                        {
                            retourButton.SetActive(true);
                        }
                        if (myCollider != null)
                        {
                            myCollider.enabled = false;
                        }
                    }
                }
            }
        }
    }

    // Méthode appelée par le bouton pour revenir à l'écran principal
    public void RetourEcranPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
