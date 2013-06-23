using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.enemy;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.bullet.behaviour.collision {
    public class CollideAndDamageEnemyThenDie : IBulletBehaviourInCollisionStrategy {
        public void OnCollision(Bullet contextBullet, Collider colliderObject) {
            if (colliderObject.tag == Tags.Enemy) {
                var enemy = colliderObject.GetComponent<Enemy>();
                enemy.currentHealth -= contextBullet.damage;
                contextBullet.destroyStrategy.Destroy(contextBullet);
            }
        }
    }
}