using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.bullet;
using Assets.Scripts.tdp.entity.bullet.behaviour.collision;
using Assets.Scripts.tdp.entity.bullet.behaviour.destruction;
using Assets.Scripts.tdp.entity.enemy;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Tests.tdp.entity.bullet.behaviour.collision {

    [TestFixture]
    public class CollideAndDamageEnemyThenDieTest {
        private Bullet testBullet;
        private Enemy testEnemy;
        private const int TestTowerDamage = 100;
        private const int TestTowerMaxHealth = 1000;
        private readonly Vector3 startBulletPosition = new Vector3(0, 0, 0);

        [SetUp]
        public void SetUp() {
            testBullet =
                ScriptInstantiator.InstantiateScript<Bullet>((GameObject)Resources.Load("Prefabs/Entities/BulletPrefab"));
            testBullet.damage = TestTowerDamage;
            testBullet.bulletBehaviourInCollision = new CollideAndDamageEnemyThenDie();
            testBullet.destroyStrategy = new DestroyBullet();

            testEnemy =
                ScriptInstantiator.InstantiateScript<Enemy>((GameObject)Resources.Load("Prefabs/Entities/EnemyPrefab"));
            testEnemy.maxHealth = TestTowerMaxHealth;
            testEnemy.currentHealth = TestTowerMaxHealth;
            testEnemy.transform.position = startBulletPosition;
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