using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.entity.bullet;
using Assets.Scripts.tdp.entity.bullet.behaviour.movement;
using Assets.Scripts.tdp.entity.bullet.factory;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Tests.tdp.entity.bullet.behaviour.movement {

    /// <summary>
    /// Проверяет, что координата x тестовой пули изменяются верно
    /// В соответствии с заданной скоростью и прошедшим временем
    /// При использовании стратегии движения MoveToRight
    /// </summary>
    [TestFixture]
    public class BulletMoveToRightTest {
        private Bullet testBullet;
        private const float BulletMovementSpeed = 1.0f;
        private const float BulletMovementTime = 100.0f;
        private readonly Vector3 startBulletPosition = new Vector3(0, 0, 0);

        [SetUp]
        public void SetUp() {
            testBullet =
                ScriptInstantiator.InstantiateScript<Bullet>(
                    (GameObject) Resources.Load("Prefabs/Entities/BulletPrefab"));
            testBullet.movementStrategy = new MoveToRight();
            testBullet.speed = BulletMovementSpeed;
            testBullet.transform.position = startBulletPosition;

            testBullet.sprite = new Sprite();

            // С учемтом, что границы поля по x: -350 до 350
            Configuration.LeftGameFieldBorderX = -350;
            Configuration.RightGameFieldBorderX = 350;

            var bulletFactory =
                ScriptInstantiator.InstantiateScript<BulletFactory>(
                    (GameObject) Resources.Load("Prefabs/Factories/BulletFactoryPrefab"));
            bulletFactory.spriteManager = (SpriteManager) Object.FindObjectOfType(typeof (SpriteManager));
            bulletFactory.Start();
        }

        [Test]
        public void MoveTest() {
            Vector3 oldPosition = testBullet.transform.position;
            testBullet.movementStrategy.Move(testBullet, BulletMovementTime);
            Vector3 newPosition = testBullet.transform.position;

            Assert.That(newPosition.x,
                        Is.EqualTo(oldPosition.x + BulletMovementSpeed * BulletMovementTime));
            Assert.That(newPosition.y, Is.EqualTo(oldPosition.y));
            Assert.That(newPosition.z, Is.EqualTo(oldPosition.z));
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(testBullet.gameObject);
            ScriptInstantiator.CleanUp();
        }
    }
}