using UnityEngine;
using System.Collections;

public class BulletSpawn {
    public static void spawnBullet(GameObject bulletPrefab,
                                   _BulletBehavior behavior,
                                   Color color,
                                   Blending blendMode = Blending.Alpha,
                                   ColorBlending colorBlendMode = ColorBlending.Add,
                                   float lifeTime = 10) {

        GameObject bullet = GameObject.Instantiate(bulletPrefab);

        BulletVisual bulletVisual = bullet.GetComponent<BulletVisual>();

        bulletVisual.appearence.color = color;
        bulletVisual.appearence.colorBlendMode = colorBlendMode;
        bulletVisual.appearence.blendMode = blendMode;

        BulletUpdate bulletUpdate = bullet.AddComponent<BulletUpdate>();
        bulletUpdate.init(behavior, lifeTime);
    }

    public static void spawnBullet(GameObject bulletPrefab,
                                   _BulletBehavior behavior,
                                   Blending blendMode = Blending.Alpha,
                                   ColorBlending colorBlendMode = ColorBlending.Add,
                                   float lifeTime = 10) {
        
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        
        BulletVisual bulletVisual = bullet.GetComponent<BulletVisual>();
        
        bulletVisual.appearence.color = Color.red;
        bulletVisual.appearence.colorBlendMode = colorBlendMode;
        bulletVisual.appearence.blendMode = blendMode;
        
        BulletUpdate bulletUpdate = bullet.AddComponent<BulletUpdate>();
        bulletUpdate.init(behavior, lifeTime);
    }
}
