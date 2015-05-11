using UnityEngine;
using System.Collections;

public abstract class _BulletSpawner : MonoBehaviour {
    
    public GameObject bulletPrefab;
    public BulletAppearence appearence;

    public float bulletLifetime = 10;
    public float delaySeconds;


    void Start() {
        init(delaySeconds);
    }

    private void init(float delaySeconds) {
        StartCoroutine(spawnLoop(delaySeconds));
    }

    private IEnumerator spawnLoop(float delaySeconds) {
        while (true) {
            spawnBullets();
            yield return new WaitForSeconds(delaySeconds);
        }
    }

    public abstract void spawnBullets();

    public static void spawnBullet(GameObject bulletPrefab,
                                   _BulletBehavior behavior,
                                   BulletAppearence appearence,
                                   float lifeTime,
                                   float delaySeconds = 0) {
        
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        
        BulletVisual bulletVisual = bullet.GetComponent<BulletVisual>();
        bulletVisual.appearence = appearence;

        BulletUpdate bulletUpdate = bullet.AddComponent<BulletUpdate>();
        bulletUpdate.init(behavior, lifeTime, delaySeconds);
    }
}
