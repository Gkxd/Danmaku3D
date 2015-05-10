using UnityEngine;
using System.Collections;

public abstract class _BulletBehavior {
    public virtual void initBullet(BulletUpdate b) {}

    public virtual void moveBullet(BulletUpdate b, float deltaTime) {}

    public virtual void additionalUpdates(BulletUpdate b, float deltaTime) {}
}
