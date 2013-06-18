using UnityEngine;
using System.Collections;
using Assets.Scripts.tdp.configuration;

namespace Assets.Scripts.tdp.entity.behaviour.bullet
{
    public class MoveToRight : IBulletMovementStrategy
    {
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
