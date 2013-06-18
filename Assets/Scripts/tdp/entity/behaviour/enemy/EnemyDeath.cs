using Assets.Scripts.sprite.manager;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.behaviour.enemy {
    public class EnemyDeath : IEnemyDieStrategy {
        private readonly SpriteManager cachedSpriteManager;

        public EnemyDeath() {
            cachedSpriteManager = (SpriteManager) Object.FindObjectOfType(typeof (SpriteManager));
        }

        public void Die(Enemy contextEnemy) {
            cachedSpriteManager.RemoveSprite(contextEnemy.sprite);
            contextEnemy.sprite = null;
            Object.Destroy(contextEnemy.gameObject);
        }
    }
}