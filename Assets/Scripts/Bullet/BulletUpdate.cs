using UnityEngine;
using System.Collections;

public class BulletUpdate : MonoBehaviour {

    private _BulletBehavior behavior;
    private Rigidbody r;
    
    private bool hasInit;
    private float totalLifeTime;

    private float delay;
    private float timeExisted = 0;

    public void init(_BulletBehavior b, float lifeTime, float delaySeconds = 0) {

        if (!BulletManager.canSpawnBullets()) {
            GameObject.DestroyImmediate(gameObject);
            return;
        }

        behavior = b;
        delay = Mathf.Max(delaySeconds, 0);

        r = GetComponent<Rigidbody>();
        totalLifeTime = lifeTime + delay;

        BulletManager.bulletCounter++;
    }

    void FixedUpdate() {
        if (timeExisted > totalLifeTime) {
            GameObject.DestroyImmediate(gameObject);
            BulletManager.bulletCounter--;
        }
        else if (timeExisted > delay) {
            if (!hasInit) {
                behavior.initBullet(this);
                hasInit = true;
            }
            else {
                behavior.moveBullet(this, Time.deltaTime);
                behavior.additionalUpdates(this, Time.deltaTime);
            }
        }
        timeExisted += Time.deltaTime;
    }

    public Rigidbody getRigidBody() {
        return r;
    }
}
