using System.Collections;
using System.Runtime.CompilerServices;
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
    private float cooldownShoot;
    private int bulletCount = 0;
    private Vector3 startProjectileSpawnLocation;
    private int bulletstoSpawn;
    private int currentRow;

    [SerializeField] private ScoreData scoreData;
    [SerializeField] private ScreenBorderData screenBorderData;
    [SerializeField] private float fireRate;
    [SerializeField] private int scoretoUpgrade = 20;
    [SerializeField] private int bulletsinRow = 3;
    [SerializeField] private float Xoffset = 0.1f;
    [SerializeField] private float shootDelay = 0.2f;
    
    
    private bool canShoot = true;
    public IEnumerator ShootRest()
    { 
        yield return new WaitForSeconds(shootDelay);
        currentRow++;
        startProjectileSpawnLocation = transform.position;
        int bulletShift = 0;
        if ((bulletstoSpawn-bulletCount) / bulletsinRow > 0)
        {
            bulletShift = bulletsinRow;
        }
        else
        {
            bulletShift = bulletstoSpawn-bulletCount;
        }
        if (bulletstoSpawn > 0)
        {
            startProjectileSpawnLocation -= (bulletShift / 2) * Xoffset * Vector3.right;
        }
        for (bulletShift=0; bulletCount < bulletstoSpawn + 1 && bulletCount-currentRow*bulletsinRow < bulletsinRow; bulletCount++, bulletShift++)
        {
            Instantiate(this.laserPrefab, startProjectileSpawnLocation + (bulletShift * Xoffset * Vector3.right), Quaternion.identity);
        }
        if (bulletCount < bulletstoSpawn + 1)
        {
            StartCoroutine(ShootRest());
        }
        else
        {
            canShoot = true;
        }
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.A) && transform.position.x > screenBorderData.Leftedge)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < screenBorderData.Rightedge)
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && cooldownShoot < Time.time)
        {
            cooldownShoot = Time.time + fireRate;
            Shoot();            
        }
        

    }
   

    private void Shoot()
    {
        if (canShoot == false)
        {
            return;
        }
        canShoot = false;
        bulletCount = 0;
        currentRow = 0;
        

        startProjectileSpawnLocation = transform.position;
        bulletstoSpawn = scoreData.Score / scoretoUpgrade;
        int bulletShift = bulletstoSpawn;
        if (bulletstoSpawn / bulletsinRow > 0)
        {
            bulletShift = bulletsinRow;
        }
    
        if (bulletstoSpawn > 0)
        {
            startProjectileSpawnLocation -= (bulletShift / 2) * Xoffset * Vector3.right;
        }
        for (; bulletCount < bulletstoSpawn + 1 && bulletCount<bulletsinRow; bulletCount++) 
        {
            Instantiate(this.laserPrefab, startProjectileSpawnLocation + (bulletCount * Xoffset * Vector3.right), Quaternion.identity);
        }
        if (bulletCount < bulletstoSpawn + 1)
        {
            StartCoroutine(ShootRest());
        }
        else 
        {
            canShoot = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }



}
