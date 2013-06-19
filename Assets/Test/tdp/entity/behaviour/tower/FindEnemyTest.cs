using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.tdp;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.enemy;
using Assets.Scripts.tdp.entity.behaviour.tower;
using Assets.Test.utility;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Test.tdp.entity.behaviour.tower
{
    [TestFixture]
	public class FindEnemyTest {
        private Tower testTower;
        private Enemy testEnemy;
        private TestCaseData[] testData;

        [SetUp]
        public void SetUp() {
            testTower = ScriptInstantiator.InstantiateScript<Tower>((GameObject)Resources.Load("Prefabs/TowerPrefab"));
            testTower.targetingStrategy = new FindEnemy();
            testTower.gameObject.GetComponent<BoxCollider>().size = Configuration.TowerSize;
            testTower.attackRange = 100.0f; // Устанавливаем хардкодом, чтобы тест на функциональность не зависил от изменения конфигурации
            //Configuration.TowerAttackRange[0] * Configuration.CellWidth;
            testTower.lineId = 0;

            testEnemy = ScriptInstantiator.InstantiateScript<Enemy>((GameObject)Resources.Load("Prefabs/EnemyPrefab"));
            testEnemy.deathStrategy = new EnemyDeath();
            testEnemy.gameObject.GetComponent<BoxCollider>().size = Configuration.EnemySize;
            testEnemy.lineId = 0;

            testData = new[] {
                new TestCaseData {EnemyPositionX = 96, TowerPositionX = 0, ExpectedResult = true},
                new TestCaseData {EnemyPositionX = 0, TowerPositionX = 0, ExpectedResult = false},
                new TestCaseData {EnemyPositionX = -96, TowerPositionX = 0, ExpectedResult = false},
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
