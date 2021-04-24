using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    Rigidbody shipRb;
    public static int score = 0;
    float speed = 0.2f;

    public Text shipText;
    public GameObject EnemyPrefab;
    public GameObject BulletPrefab;

    void Start()
    {
        shipRb = GetComponent<Rigidbody>();
        InvokeRepeating("GenerateEnemy", Time.time + 3f, 1f);
    }

    void Update()
    {
        EnableMovement();

        if (Input.GetMouseButtonDown(0))
        {
            GenerateBullet();
        }

        PlayerPrefs.SetInt("score", score);
    }

    void EnableMovement()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        Vector3 rotationVector = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed);
            rotationVector.z += 10;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed);
            rotationVector.z -= 10;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed);
            rotationVector.x += 10;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed);
            rotationVector.x -= 10;
        }

        transform.Rotate(rotationVector);
    }

    void GenerateEnemy()
    {
        Vector3 currentEnemyPosition = new Vector3(Random.Range(-10f, 10f), 0, 100);
        GameObject currentEnemy = Instantiate(EnemyPrefab, currentEnemyPosition, EnemyPrefab.transform.rotation);
        Rigidbody currentEnemyRb = currentEnemy.GetComponent<Rigidbody>();
        currentEnemyRb.velocity = Vector3.forward * Random.Range(-100, -40);
    }

    void GenerateBullet()
    {
        Vector3 currentBulletPosition = transform.position + new Vector3(0, 0, 4.5f);
        GameObject currentBullet = Instantiate(BulletPrefab, currentBulletPosition, BulletPrefab.transform.rotation);
        Rigidbody currentBulletRb = currentBullet.GetComponent<Rigidbody>();
        currentBulletRb.velocity = new Vector3(0, 0, 50);
    }
}
