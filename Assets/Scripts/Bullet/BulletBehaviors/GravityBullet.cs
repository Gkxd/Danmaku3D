using UnityEngine;
using System.Collections;


public class GravityBullet : _DirectionalBulletBehavior {
    private float velocity;
    private float acceleration;
    private Vector3 gravityDirection;

    public GravityBullet(Vector3 p, Vector3 d, float v, float a, Vector3 g) : base(p, d) {
        velocity = v;
        acceleration = a;
        gravityDirection = g;
    }

    public override void initBullet(BulletUpdate b) {
        base.initBullet(b);
        b.getRigidBody().velocity = velocity * direction;
        
        reorientBullet(b, direction);
    }
    
    public override void moveBullet(BulletUpdate b, float deltaTime) {
        b.getRigidBody().velocity += acceleration * gravityDirection * deltaTime;
        
        reorientBullet(b, b.getRigidBody().velocity);
    }
}
