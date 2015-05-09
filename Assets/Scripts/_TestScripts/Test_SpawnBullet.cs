using UnityEngine;
using System.Collections;

public class Test_SpawnBullet : MonoBehaviour {

    GameObject bulletPrefab;

	void Start () {
        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullets/Bullet00");

        StartCoroutine(intervalUpdate(0.1f));
	}

    public IEnumerator intervalUpdate(float seconds) {
        float yaw = 0;
        float pitch = 0;

        while (true) {
            Vector3 direction = Quaternion.Euler(pitch, yaw, 0) * Vector3.forward;
            StraightLineBullet bulletBehavior = new StraightLineBullet(10, direction);

            BulletSpawn.spawnBullet(bulletPrefab,
                                    bulletBehavior,
                                    Color.cyan,
                                    blendMode: Blending.Add,
                                    lifeTime: 1);

            yaw += 13;
            pitch += 7;

            yield return new WaitForSeconds(seconds);
        }
    }
}
