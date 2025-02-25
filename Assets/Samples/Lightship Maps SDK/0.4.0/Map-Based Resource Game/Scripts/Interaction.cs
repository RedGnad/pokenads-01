using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject retourButton;

    public ParticleSystem particleSystemPrefab;

    private Collider myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider>();

        if (retourButton != null)
        {
            retourButton.SetActive(false);
        }
    }

    void Update()
    {
        if (score >= 10)
            return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    score++;
                    if (scoreText != null)
                    {
                        scoreText.text = "Score: " + score;
                    }

                    if (particleSystemPrefab != null)
                    {
                        ParticleSystem ps = Instantiate(particleSystemPrefab, hit.point, Quaternion.identity);
                        ps.Play();
                        Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                    }

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

    public void RetourEcranPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
