using UnityEngine;

public class Bullet : MonoBehaviour
{
    float countdown;

    void Start()
    {
        countdown = 5;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown < 0)
        {
            Destroy(gameObject);
        }
    }
}
