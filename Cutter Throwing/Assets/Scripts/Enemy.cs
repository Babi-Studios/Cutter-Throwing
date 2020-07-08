using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * 5f;
        if (transform.position.x <= -10) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
