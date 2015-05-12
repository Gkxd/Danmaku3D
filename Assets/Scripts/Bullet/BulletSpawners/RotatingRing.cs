using UnityEngine;
using System.Collections;

public class RotatingRing : _BulletSpawner {
    public int amount;
    public float spread = 360;

    public Vector3 ringRotationAxis;
    public float ringRotationAmount;

    public Vector3 ringOrthogonalAxis = Vector3.up;
    public float ringSpinAmount;

    private float angleOffset;

    public override void spawnBullets() {
        for (int i = 0; i < amount; i++) {
            Vector3 direction = Quaternion.AngleAxis(spread * i / amount + angleOffset, ringOrthogonalAxis) * Vector3.Cross(ringOrthogonalAxis, ringRotationAxis);

            Pair<GameObject, GameObject> bulletUpdatePair = createBullet();
            bulletUpdatePair.b.GetComponent<_BulletUpdate>().setDirection(direction);
        }
        ringOrthogonalAxis = Quaternion.AngleAxis(ringRotationAmount, ringRotationAxis) * ringOrthogonalAxis;
        angleOffset += ringSpinAmount;
    }
}
