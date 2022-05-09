using System.Collections;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField] private float fireDelay = 3;
    [SerializeField] private GameObject missilePrefab;
    
    private bool canFire = true;
    public TargetSpawner Spawner;
    
    

    private IEnumerator ShootMissileRoutine()
    {
        GameObject missileGO=Instantiate(missilePrefab, this.transform.position, missilePrefab.transform.rotation);
        Missile missile = missileGO.GetComponent<Missile>();
        missile.SetTarget(Spawner.GetTarget());
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    public void Fire()
    {
        if(canFire)
        {
            StartCoroutine(ShootMissileRoutine());
        }
    }
}
