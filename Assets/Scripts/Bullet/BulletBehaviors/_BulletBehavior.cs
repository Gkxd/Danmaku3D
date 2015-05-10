using UnityEngine;
using System.Collections;

public abstract class _BulletBehavior {
    protected Vector3 initialPosition;

    public _BulletBehavior(Vector3 p) {
        initialPosition = p;
    }

    public virtual void initBullet(BulletUpdate b) {
        b.getRigidBody().position = initialPosition;
    }

    public virtual void moveBullet(BulletUpdate b, float deltaTime) {}

    public virtual void additionalUpdates(BulletUpdate b, float deltaTime) {}

    public void setInitialPosition(Vector3 p) {
        initialPosition = p;
    }
}
