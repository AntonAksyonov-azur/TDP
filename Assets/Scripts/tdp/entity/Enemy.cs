using Assets.Scripts.tdp.entity.behaviour.enemy;
using UnityEngine;

namespace Assets.Scripts.tdp.entity {
    public class Enemy : BasicGameEntity {
        public int currentHealth;
        public int maxHealth;
        public float speed; // Число клеток в секунду
        
        public IEnemyDieStrategy deathStrategy;
        public IEnemyMoveStrategy movementStrategy;

        public override void Update() {
            movementStrategy.Move(this, Time.deltaTime);

            if (currentHealth <= 0) {
                deathStrategy.Die(this);
            }
        }
    }
}