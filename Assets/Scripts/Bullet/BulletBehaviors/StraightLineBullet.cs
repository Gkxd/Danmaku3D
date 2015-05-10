using UnityEngine;
using System.Collections;


public class StraightLineBullet : _DirectionalBulletBehavior {
    private float velocity;

    public StraightLineBullet(Vector3 p, Vector3 d, float v) : base(p, d) {
        velocity = v;
    }

    public override void initBullet(BulletUpdate b) {
        base.initBullet(b);
        b.getRigidBody().velocity = velocity * direction;

        Quaternion rotation = new Quaternion();
        rotation.SetFromToRotation(Vector3.forward, direction);

        b.getRigidBody().rotation = rotation;
    }
}
