using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    [SerializeField] private ScoreData scoreData;

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
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            return;
        }
        else if (collision.gameObject.tag == "Border")
          {
            Destroy(gameObject);
        }
       else
        {
            Destroy(this.gameObject);
            var invader = collision.gameObject.GetComponent<InvadersScript>();
            if (invader != null)
            {
                invader.Hit();
            }
        }
        }
   
}
