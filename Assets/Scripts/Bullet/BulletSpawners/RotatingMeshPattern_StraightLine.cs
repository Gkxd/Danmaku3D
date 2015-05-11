using UnityEngine;
using System.Collections;

public class RotatingMeshPattern_StraightLine : _BulletSpawner {

    public float bulletSpeed;
    public float bulletAcceleration;

    public Mesh mesh;
    public Vector3 rotationAxis;
    public float rotationAmount;

    private float angle;

    public override void spawnBullets() {
        foreach (Vector3 vertex in mesh.vertices) {
            Vector3 direction = Quaternion.AngleAxis(angle, rotationAxis) * vertex;
            StraightLineBullet bulletBehavior = new StraightLineBullet(transform.position, direction, bulletSpeed, bulletAcceleration);
            
            spawnBullet(bulletPrefab, bulletBehavior, appearence, bulletLifetime);
        }

        angle += rotationAmount;
    }
}
