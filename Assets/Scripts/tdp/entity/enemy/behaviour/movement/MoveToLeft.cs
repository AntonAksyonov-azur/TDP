using Assets.Scripts.tdp.configuration;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.enemy.behaviour.movement {
    public class MoveToLeft : IEnemyMoveStrategy {
        public void Move(Enemy contextEnemy, float elapsedTime) {
            float amountToMove = contextEnemy.speed * elapsedTime;
            contextEnemy.transform.Translate(Vector3.left * amountToMove);

            // Выход за границы
            if (contextEnemy.transform.position.x < Configuration.LeftGameFieldBorderX) {
                contextEnemy.deathStrategy.Die(contextEnemy);

                var notifyFail = Object.FindObjectOfType(typeof (Gameplay)) as INotifyEnemyPassed;
                if (notifyFail != null) {
                    notifyFail.EnemyPassed();
                }
            }
        }
    }
}