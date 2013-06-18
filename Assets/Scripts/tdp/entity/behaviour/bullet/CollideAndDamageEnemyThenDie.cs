using Assets.Scripts.tdp.constants;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.tdp.entity.behaviour.bullet
{
    public class CollideAndDamageEnemyThenDie : IBulletBehaviourInCollisionStrategy
    {
        public void OnCollision(Bullet contextBullet, Collider colliderObject) {
            if (colliderObject.tag == Tags.Enemy) {
                Enemy enemy = colliderObject.GetComponent<Enemy>();
                enemy.currentHealth -= contextBullet.damage;
                contextBullet.destroyStrategy.Destroy(contextBullet);
            }
        }
    }
}
