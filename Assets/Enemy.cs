using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Ship.score++;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
