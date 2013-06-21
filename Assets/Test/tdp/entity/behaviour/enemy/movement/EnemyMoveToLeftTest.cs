using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.enemy.death;
using Assets.Scripts.tdp.entity.behaviour.enemy.movement;
using Assets.Test.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.tdp.entity.behaviour.enemy.movement {
    [TestFixture]
    public class EnemyMoveToLeftTest {
        private Enemy testEnemy;

        [SetUp]
        public void SetUp() {
            testEnemy =
                ScriptInstantiator.InstantiateScript<Enemy>(
                    (GameObject)Resources.Load("Prefabs/Entities/EnemyPrefab"));
            testEnemy.movementStrategy = new MoveToLeft();
            testEnemy.deathStrategy = new EnemyDeath();
            testEnemy.speed = Configuration.Enemies[EnemyType.Type1].Speed;
        }

        [Test]
        public void MoveTest() {
            Vector3 oldPosition = testEnemy.transform.position;
            testEnemy.movementStrategy.Move(testEnemy, 100.0f);
            Vector3 newPosition = testEnemy.transform.position;

            Assert.That(newPosition.x, Is.LessThan(oldPosition.x));
        }

        [TearDown]
        public void TearDown() {
            Object.DestroyImmediate(testEnemy.gameObject);
            ScriptInstantiator.CleanUp();
        }
    }
}