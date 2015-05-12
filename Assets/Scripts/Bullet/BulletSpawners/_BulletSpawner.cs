using UnityEngine;
using System.Collections;

public abstract class _BulletSpawner : MonoBehaviour {
    
    public GameObject bulletPrefab;
    public GameObject bulletUpdate;
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

    public Pair<GameObject, GameObject> createBullet() {
        
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        
        BulletVisual bulletVisual = bullet.GetComponent<BulletVisual>();
        bulletVisual.appearence = appearence;

        GameObject update = GameObject.Instantiate(bulletUpdate);
        update.transform.parent = bullet.transform;
        update.GetComponent<_BulletUpdate>().init(bulletLifetime, delaySeconds);

        return new Pair<GameObject, GameObject>(bullet, update);
    }
}
