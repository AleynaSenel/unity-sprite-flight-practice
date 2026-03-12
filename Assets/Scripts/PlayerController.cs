using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float thrustForce = 1f;
    Rigidbody2D rb;
    public GameObject boosterFlame;

    private float elapsedTime = 0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;

    public UIDocument uiDocument;
    private Label scoreText;

    public GameObject explosionEffect;
    private Button restartButton;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
    }

    
    void Update()
    {

        UpdateScore();
        MovePlayer();

        if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                boosterFlame.SetActive(true);
            }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                boosterFlame.SetActive(false);
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;
    }

    private void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);   // floatý inte çevirdik
        scoreText.text = "Score: " + score;
    }
    private void MovePlayer()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            //mouse koordinatlarýný hesaplar
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;  // hýzý aradaki mesafeye göre deðil her basýldýðýnda sabit yaptý

            transform.up = direction;
            rb.AddForce(direction * thrustForce);


        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
