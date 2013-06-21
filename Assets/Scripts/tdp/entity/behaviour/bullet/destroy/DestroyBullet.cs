using Assets.Scripts.sprite.manager;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.behaviour.bullet.destroy {
    public class DestroyBullet : IBulletDestroyStrategy {
        private readonly SpriteManager cachedSpriteManager;

        public DestroyBullet() {
            cachedSpriteManager = (SpriteManager) Object.FindObjectOfType(typeof (SpriteManager));
        }

        public void Destroy(Bullet contextBullet) {
            cachedSpriteManager.RemoveSprite(contextBullet.sprite);
            contextBullet.sprite = null;
            Object.Destroy(contextBullet.gameObject);
        }
    }
}