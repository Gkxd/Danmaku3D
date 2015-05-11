using UnityEngine;
using System.Collections;

public class RotatingRing_Gravity: _BulletSpawner {
    
    public float bulletSpeed;
    public float bulletAcceleration;
    public Vector3 gravityDirection;

    public int amount;
    public float spread = 360;

    public Vector3 ringRotationAxis;
    public float ringRotationAmount;
    public float ringSpinAmount;

    private Vector3 orthogonalAxis = Vector3.up;
    private float angleOffset;

    public override void spawnBullets() {
        for (int i = 0; i < amount; i++) {
            Vector3 direction = Quaternion.AngleAxis(spread * i / amount + angleOffset, orthogonalAxis) * Vector3.Cross(orthogonalAxis, ringRotationAxis);
            GravityBullet bulletBehavior = new GravityBullet(transform.position, direction, bulletSpeed, bulletAcceleration, gravityDirection);

            spawnBullet(bulletPrefab, bulletBehavior, appearence, bulletLifetime);
        }
        orthogonalAxis = Quaternion.AngleAxis(ringRotationAmount, ringRotationAxis) * orthogonalAxis;
        angleOffset += ringSpinAmount;
    }

}
