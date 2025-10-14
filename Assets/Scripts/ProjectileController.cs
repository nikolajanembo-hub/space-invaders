using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private PlayerController owner;

    public void setOwner(PlayerController player)
    {
        owner = player;
    }
    private void Update()
    {
        this.transform.position += this.direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            Destroy(this.gameObject);
        }
        }
    private void OnDestroy()
    {
        if (owner != null)
        {
            owner.OnBulletDestroyed();
                }
    }
}
