using UnityEngine;
using System.Collections;

public class BulletUpdate : MonoBehaviour {

    private _BulletBehavior behavior;
    private Rigidbody r;

    public void init(_BulletBehavior b, float lifeTime) {
        behavior = b;
        r = GetComponent<Rigidbody>();
        GameObject.Destroy(gameObject, lifeTime);
    }

    void FixedUpdate() {
        behavior.moveBullet(r, Time.deltaTime);
        behavior.additionalUpdates(this, Time.deltaTime);
    }
}
