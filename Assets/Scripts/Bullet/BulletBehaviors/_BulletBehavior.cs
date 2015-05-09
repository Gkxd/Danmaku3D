using UnityEngine;
using System.Collections;

public abstract class _BulletBehavior {

    public abstract void moveBullet(Rigidbody r, float deltaTime);

    public virtual void additionalUpdates(BulletUpdate b, float deltaTime) {}
}
