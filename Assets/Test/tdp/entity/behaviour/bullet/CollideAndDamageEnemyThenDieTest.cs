using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.bullet;
using Assets.Test.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.tdp.entity.behaviour.bullet {
    [TestFixture]
    public class CollideAndDamageEnemyThenDieTest {
        private Bullet testBullet;
        private Enemy testEnemy;
        
        [SetUp]
        public void SetUp() {
            testBullet =
                ScriptInstantiator.InstantiateScript<Bullet>((GameObject) Resources.Load("Prefabs/BulletPrefab"));
            testBullet.damage = Configuration.TowerDamage[0];
            testBullet.bulletBehaviourInCollision = new CollideAndDamageEnemyThenDie();
            testBullet.destroyStrategy = new DestroyBullet();

            testEnemy =
                ScriptInstantiator.InstantiateScript<Enemy>((GameObject) Resources.Load("Prefabs/EnemyPrefab"));
            testEnemy.maxHealth = Configuration.EnemyMaxHealth[0];
            testEnemy.currentHealth = Configuration.EnemyMaxHealth[0];
        }

        [Test]
        public void OnCollisionTest() {
            testBullet.bulletBehaviourInCollision.OnCollision(testBullet, testEnemy.collider);
            Assert.That(testEnemy.currentHealth, Is.EqualTo(testEnemy.maxHealth - testBullet.damage));
        }

        [TearDown]
        public void TearDown() {
            Object.DestroyImmediate(testBullet.gameObject);
            Object.DestroyImmediate(testEnemy.gameObject);
            ScriptInstantiator.CleanUp();
        }
    }
}