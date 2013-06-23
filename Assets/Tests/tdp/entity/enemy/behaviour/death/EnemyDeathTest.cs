using Assets.Scripts.tdp.entity.enemy;
using Assets.Scripts.tdp.entity.enemy.behaviour.death;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Tests.tdp.entity.enemy.behaviour.death {
    [TestFixture]
    public class EnemyDeathTest {
        [SetUp]
        public void SetUp() {
            testEnemy =
                ScriptInstantiator.InstantiateScript<Enemy>(
                    (GameObject) Resources.Load("Prefabs/Entities/EnemyPrefab"));
            testEnemy.deathStrategy = new EnemyDeath();
        }

        private Enemy testEnemy;

        [Test]
        public void DestroyTest() {
            Assert.NotNull(testEnemy);

            testEnemy.deathStrategy.Die(testEnemy);

            Assert.Null(testEnemy.sprite);
        }


        [TearDown]
        public void TearDown() {
            // Если тест провалился, ресурсы все равно должны быть очищены
            if (testEnemy != null) {
                Object.DestroyImmediate(testEnemy);
            }
            ScriptInstantiator.CleanUp();
        }
    }
}