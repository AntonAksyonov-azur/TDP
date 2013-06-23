using Assets.Scripts.tdp.entity.bullet;
using Assets.Scripts.tdp.entity.bullet.behaviour.destruction;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Tests.tdp.entity.bullet.behaviour.destruction {

    [TestFixture]
    public class DestroyBulletTest {
        private Bullet testBullet;

        [SetUp]
        public void SetUp() {
            testBullet =
                ScriptInstantiator.InstantiateScript<Bullet>(
                    (GameObject) Resources.Load("Prefabs/Entities/BulletPrefab"));
            testBullet.destroyStrategy = new DestroyBullet();
        }

        [Test]
        public void DestroyTest() {
            Assert.NotNull(testBullet);

            testBullet.destroyStrategy.Destroy(testBullet);

            Assert.Null(testBullet.sprite);

        }

        [TearDown]
        public void TearDown() {
            // Если тест провалился, ресурсы все равно должны быть очищены
            if (testBullet != null) {
                Object.DestroyImmediate(testBullet);
            }
            ScriptInstantiator.CleanUp();
        }
    }
}