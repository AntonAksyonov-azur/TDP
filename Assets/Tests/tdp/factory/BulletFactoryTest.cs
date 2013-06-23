using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.bullet;
using Assets.Scripts.tdp.entity.behaviour.bullet.collide;
using Assets.Scripts.tdp.entity.behaviour.bullet.destroy;
using Assets.Scripts.tdp.entity.behaviour.bullet.movement;
using Assets.Scripts.tdp.entity.factory;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Tests.tdp.factory {
    [TestFixture]
    public class BulletFactoryTest {
        private BulletFactory bulletFactory;
        private GameObject testBullet;

        private int lineId = 1;
        private int damage = 100;
        private Vector3 position = new Vector3(1, 2, 3);

        [SetUp]
        public void SetUp() {
            bulletFactory =
                ScriptInstantiator.InstantiateScript<BulletFactory>(
                (GameObject)Resources.Load("Prefabs/Factories/BulletFactoryPrefab"));
            bulletFactory.spriteManager = (SpriteManager)Object.FindObjectOfType(typeof(SpriteManager));
            bulletFactory.Start();
        }

        [Test]
        public void CreateBulletTest() {
            testBullet = bulletFactory.CreateBullet(lineId, damage, position);

            Assert.NotNull(testBullet, "Bullet Game object wasn't created");
            Bullet bulletInstance = testBullet.GetComponent<Bullet>();
            
            Assert.NotNull(bulletInstance, "Bullet script instance wasn't created");
            Assert.That(bulletInstance.lineId, Is.EqualTo(lineId), "Line id is wrong");
            Assert.That(bulletInstance.damage, Is.EqualTo(damage), "Damage is wrong");
            Assert.That(bulletInstance.transform.position, Is.EqualTo(position), "Position is wrong");
            Assert.That(bulletInstance.speed, 
                Is.EqualTo(Configuration.BulletMovementSpeed * Configuration.CellWidth), "Speed is not as in configuration");

            Assert.That(bulletInstance.movementStrategy, Is.InstanceOf(typeof(MoveToRight)), "Movement strategy is wrong");
            Assert.That(bulletInstance.destroyStrategy, Is.InstanceOf(typeof(DestroyBullet)), "Destroy strategy is wrong");
            Assert.That(bulletInstance.bulletBehaviourInCollision, 
                Is.InstanceOf(typeof(CollideAndDamageEnemyThenDie)), "Collide beheviour strategy is wrong");

            Assert.NotNull(testBullet.GetComponent<Bullet>().sprite, "Sprite wasn't created");
        }

        [TearDown]
        public void TearDown() {
            SpriteManager spriteManager = (SpriteManager)Object.FindObjectOfType(typeof(SpriteManager));
            spriteManager.RemoveSprite(testBullet.GetComponent<Bullet>().sprite);
            testBullet.GetComponent<Bullet>().sprite = null;

            Object.DestroyImmediate(testBullet);
            Object.DestroyImmediate(bulletFactory.gameObject);
        }
    }
}