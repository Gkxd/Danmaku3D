using UnityEngine;
using System.Collections;


public class StraightLineBullet : _BulletBehavior {

    private float velocity;
    private Vector3 direction;

    public StraightLineBullet(float v, Vector3 d) {
        velocity = v;
        direction = d;
    }

    public override void initBullet(BulletUpdate b) {
        b.getRigidBody().velocity = velocity * direction;
    }
}
