using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.bullet.movement;
using Assets.Test.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.tdp.entity.behaviour.bullet.movement {
    [TestFixture]
    public class BulletMoveToRightTest {
        private Bullet testBullet;
        private const float BulletMovementSpeed = 1.0f;
        private const float BulletMovementTime = 100.0f;

        [SetUp]
        public void SetUp() {
            testBullet =
                ScriptInstantiator.InstantiateScript<Bullet>(
                    (GameObject) Resources.Load("Prefabs/Entities/BulletPrefab"));
            testBullet.movementStrategy = new MoveToRight();
            testBullet.speed = BulletMovementSpeed;
        }

        [Test]
        public void MoveTest() {
            Vector3 oldPosition = testBullet.transform.position;
            testBullet.movementStrategy.Move(testBullet, BulletMovementTime);
            Vector3 newPosition = testBullet.transform.position;

            Assert.That(newPosition.x,
                        Is.EqualTo(oldPosition.x + BulletMovementSpeed * BulletMovementTime));
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(testBullet.gameObject);
            ScriptInstantiator.CleanUp();
        }
    }
}