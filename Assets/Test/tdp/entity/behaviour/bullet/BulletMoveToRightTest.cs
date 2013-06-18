using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.bullet;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.tdp.entity.behaviour.bullet {
    [TestFixture]
    public class BulletMoveToRightTest {
        private Bullet testBullet;
        
        [SetUp]
        public void SetUp() {
            
            testBullet =
                ScriptInstantiator.InstantiateScript<Bullet>((GameObject) Resources.Load("Prefabs/BulletPrefab"));
            testBullet.movementStrategy = new MoveToRight();
            testBullet.speed = Configuration.BulletMovementSpeed;
        }

        [Test]
        public void MoveTest() {
            //Debug.Log("BulletMoveToRight Test");
            Vector3 oldPosition = testBullet.transform.position;
            testBullet.movementStrategy.Move(testBullet, 100.0f);
            Vector3 newPosition = testBullet.transform.position;

            Assert.That(newPosition.x, Is.GreaterThan(oldPosition.x));
        }

        [TearDown]
        public void TearDown() {
            Object.DestroyImmediate(testBullet.gameObject);
            ScriptInstantiator.CleanUp();
        }
    }
}