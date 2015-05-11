using UnityEngine;
using System.Collections;

public class RotatingMeshPattern_Gravity : _BulletSpawner {

    public float bulletSpeed;
    public float bulletAcceleration;
    public Vector3 gravityDirection;

    public Mesh mesh;
    public Vector3 rotationAxis;
    public float rotationAmount;

    private float angle;

    public override void spawnBullets() {
        foreach (Vector3 vertex in mesh.vertices) {
            Vector3 direction = Quaternion.AngleAxis(angle, rotationAxis) * vertex;
            GravityBullet bulletBehavior = new GravityBullet(transform.position, direction, bulletSpeed, bulletAcceleration, gravityDirection);

            spawnBullet(bulletPrefab, bulletBehavior, appearence, bulletLifetime);
        }

        angle += rotationAmount;
    }
}
