using UnityEngine;

namespace Assets.Scripts.tdp.entity.bullet.behaviour.collision
{
	public interface IBulletBehaviourInCollisionStrategy {
	    void OnCollision(Bullet contextBullet, Collider colliderObject);
	}
}
