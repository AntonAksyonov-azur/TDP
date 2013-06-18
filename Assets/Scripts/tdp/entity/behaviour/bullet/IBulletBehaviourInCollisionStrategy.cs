using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.behaviour.bullet
{
	public interface IBulletBehaviourInCollisionStrategy {
	    void OnCollision(Bullet contextBullet, Collider colliderObject);
	}
}
