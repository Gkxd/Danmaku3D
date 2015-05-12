using UnityEngine;
using System.Collections;

public class RotatingMeshPattern : _BulletSpawner {

    public Mesh mesh;
    public Vector3 rotationAxis;
    public float rotationAmount;

    private float angle;
    public override void spawnBullets() {
        foreach (Vector3 vertex in mesh.vertices) {
            Vector3 direction = Quaternion.AngleAxis(angle, rotationAxis) * vertex;
            
            Pair<GameObject, GameObject> bulletUpdatePair = createBullet();
            bulletUpdatePair.b.GetComponent<_BulletUpdate>().setDirection(direction);
        }

        angle += rotationAmount;
    }
}
