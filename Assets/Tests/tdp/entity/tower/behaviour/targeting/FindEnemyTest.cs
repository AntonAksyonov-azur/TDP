using System;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.entity.enemy;
using Assets.Scripts.tdp.entity.enemy.behaviour.death;
using Assets.Scripts.tdp.entity.tower;
using Assets.Scripts.tdp.entity.tower.behaviour.targeting;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Tests.tdp.entity.tower.behaviour.targeting
{
    [TestFixture]
	public class FindEnemyTest {
        private Tower testTower;
        private Enemy testEnemy;
        private TestCaseData[] testData;
        private const float TestTowerAttackRange = 100.0f;

        [SetUp]
        public void SetUp() {
            testTower = ScriptInstantiator.InstantiateScript<Tower>((GameObject)Resources.Load("Prefabs/Entities/TowerPrefab"));
            testTower.targetingStrategy = new FindEnemy();
            testTower.gameObject.GetComponent<BoxCollider>().size = Configuration.TowerSize;
            testTower.attackRange = TestTowerAttackRange; // Устанавливаем хардкодом, чтобы тест на функциональность не зависил от изменения конфигурации
            testTower.lineId = 0;

            testEnemy = ScriptInstantiator.InstantiateScript<Enemy>((GameObject)Resources.Load("Prefabs/Entities/EnemyPrefab"));
            testEnemy.deathStrategy = new EnemyDeath();
            testEnemy.gameObject.GetComponent<BoxCollider>().size = Configuration.EnemySize;
            testEnemy.lineId = 0;

            testData = new[] {
                new TestCaseData {EnemyPositionX = 96, TowerPositionX = 0, ExpectedResult = true},
                new TestCaseData {EnemyPositionX = 0, TowerPositionX = 0, ExpectedResult = false},
                new TestCaseData {EnemyPositionX = -96, TowerPositionX = 0, ExpectedResult = false}
            };
        }

        [TearDown]
        public void TearDown() {
            Object.DestroyImmediate(testEnemy);
            Object.DestroyImmediate(testTower); 
            ScriptInstantiator.CleanUp();
        }

        [Test]
        public void FindTargetTest() {
            for (int i = 0; i < testData.Length; i++) {
                testTower.transform.position = new Vector3(testData[i].TowerPositionX, 0);
                testEnemy.transform.position = new Vector3(testData[i].EnemyPositionX, 0);

                GameObject result = testTower.targetingStrategy.FindTarget(testTower);

                Assert.That(result != null, Is.EqualTo(testData[i].ExpectedResult),
                            String.Format("Failed on iteration {0}", i));
            }
        }

        struct TestCaseData {
            public float TowerPositionX;
            public float EnemyPositionX;
            public bool ExpectedResult;
        }
	}
}
