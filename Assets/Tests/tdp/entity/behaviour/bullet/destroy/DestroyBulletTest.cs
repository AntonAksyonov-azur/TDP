using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.bullet.destroy;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Tests.tdp.entity.behaviour.bullet.destroy {
    /// <summary>
    /// Тест проверяет, что уничтожение игрового объекта срабатывает
    /// Сложности, связанные с этим тестом:
    /// 1) Нельзя использовать обычное разрушение объекта, т.к. оно срабатывает с задержкой, 
    ///    был написан класс-клон для тестирования DestroyBulletForTest
    /// 2) Невозможно проверить обычным способом, что объект был уничтожен
    ///    У него нет свойства "уничтожен", при этом не становится эквивалентен null
    ///    Сообщение при обычном сравнении: "expected null but was < null >"
    ///    Однако обычная проверка на null срабатывает, поэтому 
    ///    успех теста определяется с помощью исключения, генерируемого Assert.Success
    ///    провал с помощью исключения, генерируемого Assert.Fail
    ///  </summary>
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