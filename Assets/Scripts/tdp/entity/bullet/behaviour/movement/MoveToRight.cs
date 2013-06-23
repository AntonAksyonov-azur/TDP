using Assets.Scripts.tdp.configuration;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.bullet.behaviour.movement {
    public class MoveToRight : IBulletMovementStrategy {
        public void Move(Bullet contextBullet, float elapsedTime) {
            float amountToMove = contextBullet.speed * elapsedTime;
            contextBullet.transform.Translate(Vector3.right * amountToMove);

            // Выход за границы
            if (contextBullet.transform.position.x > Configuration.RightGameFieldBorderX) {
                contextBullet.destroyStrategy.Destroy(contextBullet);
            }
        }
    }
}