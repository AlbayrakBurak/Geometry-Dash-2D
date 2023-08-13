using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    public GameObject Player;
    public float jumpForce = 15.0f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;

    public GameObject particlePrefab;
    public Transform particleSpawn;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (isGrounded)
        {
            SpawnParticle();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        rb.angularVelocity = -180f;
    }

    private void FixedUpdate()
    {
        Vector3 groundCheckPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        groundCheck.position = groundCheckPosition;
        Vector3 particleSpawnPosition = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
        particleSpawn.position = particleSpawnPosition;
    }

    private void SpawnParticle()
    {
        GameObject particleObject = Instantiate(particlePrefab, particleSpawn.transform.position, Quaternion.identity);
        Destroy(particleObject, 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.IncreaseAttempts();
            SceneManager.LoadScene("MainMenu");
        }
    }
}