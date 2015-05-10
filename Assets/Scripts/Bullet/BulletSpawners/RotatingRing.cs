using UnityEngine;
using System.Collections;

public class RotatingRing : _BulletSpawner {

    public int amount;
    public float bulletSpread = 360;

    public Vector3 ringRotationAxis;
    public float ringRotationAmount;
    public float ringSpinAmount;

    private Vector3 orthogonalAxis = Vector3.up;
    private float angleOffset;

    public override void spawnBullets() {
        for (int i = 0; i < amount; i++) {
            Vector3 direction = Quaternion.AngleAxis(bulletSpread * i / amount + angleOffset, orthogonalAxis) * Vector3.Cross(orthogonalAxis, ringRotationAxis);
            StraightLineBullet bulletBehavior = new StraightLineBullet(bulletSpeed, direction);

            spawnBullet(bulletPrefab, bulletBehavior, appearence, bulletLifetime);
        }
        orthogonalAxis = Quaternion.AngleAxis(ringRotationAmount, ringRotationAxis) * orthogonalAxis;
        angleOffset += ringSpinAmount;
    }

}
