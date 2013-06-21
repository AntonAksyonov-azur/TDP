using UnityEngine;

namespace Assets.Scripts.tdp.entity.behaviour.bullet.collide
{
	public interface IBulletBehaviourInCollisionStrategy {
	    void OnCollision(Bullet contextBullet, Collider colliderObject);
	}
}
