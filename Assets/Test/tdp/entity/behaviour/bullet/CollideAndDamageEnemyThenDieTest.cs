using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.bullet;
using Assets.Scripts.tdp.entity.behaviour.bullet.collide;
using Assets.Scripts.tdp.entity.behaviour.bullet.destroy;
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
                ScriptInstantiator.InstantiateScript<Bullet>((GameObject)Resources.Load("Prefabs/Entities/BulletPrefab"));
            testBullet.damage = Configuration.Towers[TowerType.Type1].Damage;
            testBullet.bulletBehaviourInCollision = new CollideAndDamageEnemyThenDie();
            testBullet.destroyStrategy = new DestroyBullet();

            testEnemy =
                ScriptInstantiator.InstantiateScript<Enemy>((GameObject)Resources.Load("Prefabs/Entities/EnemyPrefab"));
            testEnemy.maxHealth = Configuration.Enemies[EnemyType.Type1].MaxHealth;
            testEnemy.currentHealth = Configuration.Enemies[EnemyType.Type1].MaxHealth;
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