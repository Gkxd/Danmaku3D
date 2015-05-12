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

    protected void reorientBullet(BulletUpdate b, Vector3 direction) {
        Quaternion rotation = new Quaternion();
        //rotation.SetFromToRotation(Vector3.forward, direction);

        rotation.SetLookRotation(direction);

        b.getRigidBody().rotation = rotation;
    }
}
