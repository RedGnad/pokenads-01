using UnityEngine;
using TMPro;
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
            ProcessInput(Input.GetTouch(0).position);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            ProcessInput(Input.mousePosition);
        }
    }

    void ProcessInput(Vector3 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                score++;
                if(scoreText != null)
                {
                    scoreText.text = "Score : " + score;
                }
                
                if (score >= 10)
                {
                    if(GameManager.Instance != null)
                    {
                        GameManager.Instance.AddScore(10);
                    }
                    if (retourButton != null)
                    {
                        retourButton.SetActive(true);
                    }
                    if (myCollider != null)
                    {
                        myCollider.enabled = false;
                    }
                }

                if (particleSystemPrefab != null)
                {
                    ParticleSystem ps = Instantiate(particleSystemPrefab, hit.point, Quaternion.identity);
                    ps.Play();
                    Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                }
            }
        }
    }

    public void RetourEcranPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}