    using UnityEngine;

    public class BallCollision : MonoBehaviour
    {
        private Rigidbody2D rb;
        public GameObject gameOverUI; // Reference to the Game Over UI
        public AudioSource audioSource;
        public AudioSource backgroundAudio;


        void Start()
        {
            // Get the Rigidbody2D component attached to the ball
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
          if ((collision.gameObject.CompareTag("Obstacle")) || (collision.gameObject.CompareTag("DiagonalObstacle")))

            {
                Debug.Log("Game Over! Ball hit an obstacle.");

                // Stop the ball's movement
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
                backgroundAudio.Stop();

                audioSource.Play();
                // Stop the entire game by freezing time
                Time.timeScale = 0f;
                backgroundAudio.Play();

               
                // Display the Game Over UI
                gameOverUI.SetActive(true);

            }
        }
    }
