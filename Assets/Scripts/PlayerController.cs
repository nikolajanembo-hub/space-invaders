using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public ProjectileController laserPrefab;
    private ProjectileController currentBullet;

    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canShoot = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true && currentBullet == null)
        {
            Shoot();            
        }
    }
   

    private void Shoot()
    {
       currentBullet = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
       currentBullet.setOwner(this);
    }
    public void OnBulletDestroyed ()
    {
        currentBullet = null;
    }
    
    

}
