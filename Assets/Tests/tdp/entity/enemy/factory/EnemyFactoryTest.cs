using System;
using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.enemy;
using Assets.Scripts.tdp.entity.enemy.behaviour.death;
using Assets.Scripts.tdp.entity.enemy.behaviour.movement;
using Assets.Scripts.tdp.entity.enemy.factory;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Tests.tdp.entity.enemy.factory
{
    [TestFixture]
	public class EnemyFactoryTest {
        private EnemyFactory enemyFactory;
        private GameObject testEnemy;

        private int lineId = 1;
        private EnemyType[] enemyTypes = new[] {EnemyType.Type1, EnemyType.Type2, EnemyType.Type3};
        private Vector3 position = new Vector3(1, 2, 10);

        [SetUp]
        public void SetUp() {
            enemyFactory =
                ScriptInstantiator.InstantiateScript<EnemyFactory>(
                    (GameObject) Resources.Load("Prefabs/Factories/EnemyFactoryPrefab"));
            enemyFactory.SetSpriteManager((SpriteManager) Object.FindObjectOfType(typeof (SpriteManager)));
            enemyFactory.Start();
        }

        [Test]
        public void CreateEnemyTest() {
            foreach (EnemyType enemyType in enemyTypes) {
                testEnemy = enemyFactory.CreateEnemy(position, lineId, enemyType);
                Assert.NotNull(testEnemy, String.Format("Enemy Game object wasn't created, was type {0}", enemyType));
                var enemyInstance = testEnemy.GetComponent<Enemy>();

                Assert.NotNull(enemyInstance,
                               String.Format("Enemy script instance wasn't created, was type {0}", enemyType));
                Assert.That(enemyInstance.lineId, Is.EqualTo(lineId),
                            String.Format("Line id is wrong, was type {0}", enemyType));
                Assert.That(enemyInstance.maxHealth,
                            Is.EqualTo(Configuration.Enemies[enemyType].MaxHealth),
                            String.Format("Line id is wrong, was type {0}", enemyType));
                Assert.That(enemyInstance.currentHealth, Is.EqualTo(enemyInstance.maxHealth),
                            String.Format(
                                "Current health is not as same as max health right after creation, was type {0}",
                                enemyType));
                Assert.That(enemyInstance.transform.position, Is.EqualTo(position),
                            String.Format("Position is wrong, was type {0}", enemyType));
                Assert.That(enemyInstance.speed,
                            Is.EqualTo(Configuration.Enemies[enemyType].Speed * Configuration.CellWidth),
                            String.Format("Speed is not as in configuration, was type {0}", enemyType));

                Assert.That(enemyInstance.movementStrategy, Is.InstanceOf(typeof (MoveToLeft)),
                            String.Format("Movement strategy is wrong, was type {0}", enemyType));
                Assert.That(enemyInstance.deathStrategy, Is.InstanceOf(typeof (EnemyDeath)),
                            String.Format("Death strategy is wrong, was type {0}", enemyType));

                Assert.NotNull(testEnemy.GetComponent<Enemy>().sprite,
                               String.Format("Sprite wasn't created, was type {0}", enemyType));

                TearDownTestObject();
            }
        }

        [TearDown]
        public void TearDown() {
            Object.DestroyImmediate(enemyFactory.gameObject);
        }

        private void TearDownTestObject() {
            var spriteManager = (SpriteManager)Object.FindObjectOfType(typeof(SpriteManager));
            spriteManager.RemoveSprite(testEnemy.GetComponent<Enemy>().sprite);
            testEnemy.GetComponent<Enemy>().sprite = null;
            Object.DestroyImmediate(testEnemy);
        }
	}
}
