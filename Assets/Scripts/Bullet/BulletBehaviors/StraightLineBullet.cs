﻿using UnityEngine;
using System.Collections;


public class StraightLineBullet : _DirectionalBulletBehavior {
    private float velocity;
    private float acceleration;

    public StraightLineBullet(Vector3 p, Vector3 d, float v, float a = 0) : base(p, d) {
        velocity = v;
        acceleration = a;
    }

    public override void initBullet(BulletUpdate b) {
        base.initBullet(b);
        b.getRigidBody().velocity = velocity * direction;

        b.getRigidBody().AddForce(acceleration * direction);
        
        reorientBullet(b, direction);
    }

    public override void moveBullet(BulletUpdate b, float deltaTime) {
        b.getRigidBody().velocity += acceleration * direction * deltaTime;
        
        reorientBullet(b, direction);
    }
}
