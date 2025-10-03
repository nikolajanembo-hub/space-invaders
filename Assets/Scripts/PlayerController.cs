using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public ProjectileController laserPrefab;

    private bool canMoveLeft = true;
    private bool canMoveRight = true;
 
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && canMoveLeft == true)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && canMoveRight == true)
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BorderRight")
        {
            canMoveRight = false;
        }
        if (collision.gameObject.name == "BorderLeft")
        {
            canMoveLeft = false; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BorderRight")
        {
            canMoveRight = true;
        }
        if (collision.gameObject.name == "BorderLeft")
        {
            canMoveLeft = true;
        }

    }
    private void Shoot()
    {
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }
    

}
