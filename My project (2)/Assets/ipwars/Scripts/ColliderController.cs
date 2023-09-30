using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f; // Adjust the speed as needed
    private int playerObstacleCollisions = 0;
    public GameObject bulletSpawnPoint;


    void Update()
{
    Debug.Log("Update called"); // Add this line to check if Update is called
    
    // Check for player input to shoot a bullet
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Shoot();
    }
}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CorrectAns"))
        {
            print("collision");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("IncorrectAns"))
        {
            print("collision");
            Destroy(gameObject); // Destroy the player
            RestartScene();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            print("collision");
            playerObstacleCollisions++;
            if (playerObstacleCollisions >= 2)
            {
                Destroy(gameObject); // Destroy the player
                RestartScene();
            }
        }
      
    }

    void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Shoot()
{
    if (bulletSpawnPoint != null)
    {
        // Create a new bullet at the spawn point's position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        Debug.Log("Bullet instantiated");

        // Get the bullet's rigidbody2D and apply velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = bullet.transform.right * bulletSpeed; // Shoot in the direction of the bullet's right
        }
    }
}


}
