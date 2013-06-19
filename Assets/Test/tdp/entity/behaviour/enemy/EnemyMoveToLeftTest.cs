using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.enemy;
using Assets.Test.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.tdp.entity.behaviour.enemy {
    [TestFixture]
    public class EnemyMoveToLeftTest {
        private Enemy testEnemy;
        
        [SetUp]
        public void SetUp() {
            testEnemy =
                ScriptInstantiator.InstantiateScript<Enemy>((GameObject) Resources.Load("Prefabs/EnemyPrefab"));
            testEnemy.movementStrategy = new MoveToLeft();
            testEnemy.deathStrategy = new EnemyDeath();
            testEnemy.speed = Configuration.Enemies[EnemyType.Type1].Speed;
        }

        [TearDown]
        public void TearDown() {
            Object.DestroyImmediate(testEnemy.gameObject);
            ScriptInstantiator.CleanUp();
        }

        [Test]
        public void MoveTest() {
            Vector3 oldPosition = testEnemy.transform.position;
            testEnemy.movementStrategy.Move(testEnemy, 100.0f);
            Vector3 newPosition = testEnemy.transform.position;

            Assert.That(newPosition.x, Is.LessThan(oldPosition.x));
        }
    }
}