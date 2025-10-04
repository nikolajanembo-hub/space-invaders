using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public ProjectileController laserPrefab;

    public bool canMoveLeft = true;
    public bool canMoveRight = true;
 
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
    
    private void Shoot()
    {
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }
    

}
