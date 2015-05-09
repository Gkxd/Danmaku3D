using UnityEngine;
using System.Collections;


public class StraightLineBullet : _BulletBehavior {

    private float velocity;
    private Vector3 direction;

    public StraightLineBullet(float v, Vector3 d) {
        velocity = v;
        direction = d;
    }

    public override void moveBullet(Rigidbody r, float deltaTime) {
        r.velocity = velocity * direction;
    }
}
