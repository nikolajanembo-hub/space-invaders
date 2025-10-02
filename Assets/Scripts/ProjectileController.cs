using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private void Update()
    {
        this.transform.position += this.direction * speed * Time.deltaTime;
    }
}
