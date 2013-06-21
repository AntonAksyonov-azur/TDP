using Assets.Scripts.sprite.manager;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.behaviour.bullet.destroy {
    /// <summary>
    ///     Этот класс должен использоваться только для тестирования.
    ///     Клон стратегии DestroyBullet, но т.к. Object.Destroy не работает в "режиме редактирования" (edit mode)",
    ///     объект не уничтожается немедленно, а только по прошествии некоторого времени,
    ///     поэтому вызовы этой функции заменены на Object.DestroyImmediate
    /// </summary>
    public class DestroyBulletForTest : IBulletDestroyStrategy {
        private readonly SpriteManager cachedSpriteManager;

        public DestroyBulletForTest() {
            cachedSpriteManager = (SpriteManager) Object.FindObjectOfType(typeof (SpriteManager));
        }

        public void Destroy(Bullet contextBullet) {
            cachedSpriteManager.RemoveSprite(contextBullet.sprite);
            contextBullet.sprite = null;
            Object.DestroyImmediate(contextBullet.gameObject);
        }
    }
}