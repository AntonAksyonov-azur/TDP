using Assets.Scripts.tdp.entity.enemy;
using Assets.Scripts.tdp.entity.enemy.behaviour.death;
using Assets.Scripts.tdp.entity.enemy.behaviour.movement;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Tests.tdp.entity.enemy.behaviour.movement {

    /// <summary>
    /// Проверяет, что координата x тестового противника изменяются верно
    /// В соответствии с заданной скоростью и прошедшим временем
    /// При использовании стратегии движения MoveToLeft
    /// </summary>
    [TestFixture]
    public class EnemyMoveToLeftTest {
        private Enemy testEnemy;
        private const float EnemyMovementSpeed = 1.0f;
        private const float EnemyMovementTime = 100.0f;
        private readonly Vector3 startEnemyPosition = new Vector3(0, 0, 0);

        [SetUp]
        public void SetUp() {
            testEnemy =
                ScriptInstantiator.InstantiateScript<Enemy>(
                    (GameObject) Resources.Load("Prefabs/Entities/EnemyPrefab"));
            testEnemy.movementStrategy = new MoveToLeft();
            testEnemy.deathStrategy = new EnemyDeath();
            testEnemy.speed = EnemyMovementSpeed;
            testEnemy.transform.position = startEnemyPosition;
        }

        [Test]
        public void MoveTest() {
            Vector3 oldPosition = testEnemy.transform.position;
            testEnemy.movementStrategy.Move(testEnemy, EnemyMovementTime);
            Vector3 newPosition = testEnemy.transform.position;

            Assert.That(newPosition.x,
                        Is.EqualTo(oldPosition.x - EnemyMovementSpeed * EnemyMovementTime));
            Assert.That(newPosition.y, Is.EqualTo(oldPosition.y));
            Assert.That(newPosition.z, Is.EqualTo(oldPosition.z));
        }

        [TearDown]
        public void TearDown() {
            Object.DestroyImmediate(testEnemy.gameObject);
            ScriptInstantiator.CleanUp();
        }

    }
}