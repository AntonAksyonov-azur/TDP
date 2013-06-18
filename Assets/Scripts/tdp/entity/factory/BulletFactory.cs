using System.Collections.Generic;
using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.entity.behaviour.bullet;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.factory {
    public class BulletFactory {
        private readonly GameObject bulletPrefab;
        private readonly IBulletBehaviourInCollisionStrategy BulletBehaviourInBehaviourInCollision;
        private readonly IBulletDestroyStrategy destroyStrategy;
        private readonly IBulletMovementStrategy movementStrategy;
        private readonly SpriteManager spriteManager;

        public BulletFactory() {
            bulletPrefab = (GameObject) Resources.Load("Prefabs/BulletPrefab");
            spriteManager = (SpriteManager)Object.FindObjectOfType(typeof(SpriteManager));

            BulletBehaviourInBehaviourInCollision = new CollideAndDamageEnemyThenDie();
            destroyStrategy = new DestroyBullet();
            movementStrategy = new MoveToRight();
        }

        public GameObject CreateBullet(int lineId, int damage, Vector3 position) {
            var bulletGameObject = (GameObject) Object.Instantiate(bulletPrefab, position, Quaternion.identity);

            var bullet = bulletGameObject.GetComponent<Bullet>();
            bullet.lineId = lineId;
            bullet.speed = Configuration.BulletMovementSpeed * Configuration.CellWidth;
            bullet.damage = damage;

            bullet.movementStrategy = movementStrategy;
            bullet.BulletBehaviourInBehaviourInCollision = BulletBehaviourInBehaviourInCollision;
            bullet.destroyStrategy = destroyStrategy;

            bulletGameObject.GetComponent<BoxCollider>().size = Configuration.BulletSize;

            Rect bulletFrame = Configuration.BulletFrame;

            bullet.sprite = spriteManager.AddSprite(bulletGameObject,
                                                    bulletFrame.width,
                                                    bulletFrame.height,
                                                    (int) bulletFrame.x,
                                                    (int) (bulletFrame.y + bulletFrame.height),
                                                    (int) bulletFrame.width, (int) bulletFrame.height,
                                                    false);

            return bulletGameObject;
        }
    }
}