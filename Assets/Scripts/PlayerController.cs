using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public ProjectileController laserPrefab;
    private ProjectileController currentBullet;
    private ProjectileController currentBullet2;
    public ScoreManager currentScore;

    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canShoot = true;
    public IEnumerator doubleShoot()
    {
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot2();
    }

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
        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true && currentBullet == null && currentScore.score <= 20)
        {
            Shoot();            
        }
        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true && currentBullet == null && currentBullet2 == null && currentScore.score > 20)
        {
            StartCoroutine(doubleShoot());
        }
        
    }
   

    private void Shoot()
    {
       currentBullet = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
       currentBullet.setOwner(this);
    }
    private void Shoot2()
    {
        currentBullet = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
        currentBullet.setOwner(this);
    }
    public void OnBulletDestroyed ()
    {
        currentBullet = null;
        currentBullet2 = null;
    }
    
    

}
