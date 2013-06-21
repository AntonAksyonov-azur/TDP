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
        private const float EnemyMovementSpeed = 1.0f;
        private const float EnemyMovementTime = 100.0f;

        [SetUp]
        public void SetUp() {
            testEnemy =
                ScriptInstantiator.InstantiateScript<Enemy>(
                    (GameObject) Resources.Load("Prefabs/Entities/EnemyPrefab"));
            testEnemy.movementStrategy = new MoveToLeft();
            testEnemy.deathStrategy = new EnemyDeath();
            testEnemy.speed = EnemyMovementSpeed;
        }

        [Test]
        public void MoveTest() {
            Vector3 oldPosition = testEnemy.transform.position;
            testEnemy.movementStrategy.Move(testEnemy, EnemyMovementTime);
            Vector3 newPosition = testEnemy.transform.position;

            Assert.That(newPosition.x,
                        Is.EqualTo(oldPosition.x - EnemyMovementSpeed * EnemyMovementTime));
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(testEnemy.gameObject);
            ScriptInstantiator.CleanUp();
        }

    }
}