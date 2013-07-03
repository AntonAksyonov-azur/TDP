using System;
using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.tower;
using Assets.Scripts.tdp.entity.tower.behaviour.shooting;
using Assets.Scripts.tdp.entity.tower.behaviour.targeting;
using Assets.Scripts.tdp.entity.tower.factory;
using Assets.Scripts.tdp.gui;
using Assets.Tests.utility;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Tests.tdp.entity.tower.factory {
    [TestFixture]
    public class TowerFactoryTest {
        private TowerSlot towerSlot;
        private TowerFactory towerFactory;
        private GameObject testTower;

        private int lineId = 1;
        private TowerType[] towerTypes = new[] {TowerType.Type1, TowerType.Type2, TowerType.Type3};
        private readonly Vector3 position = new Vector3(1, 2, 10);

        [SetUp]
        public void SetUp() {
            towerFactory =
                ScriptInstantiator.InstantiateScript<TowerFactory>(
                    (GameObject) Resources.Load("Prefabs/Factories/TowerFactoryPrefab"));
            towerFactory.SetSpriteManager((SpriteManager) Object.FindObjectOfType(typeof (SpriteManager)));
            towerFactory.Start();

            towerSlot =
                ScriptInstantiator.InstantiateScript<TowerSlot>(
                    (GameObject) Resources.Load("Prefabs/TowerSlotPrefab"));
            towerSlot.SetTowerFactory(towerFactory);
            towerSlot.SetLineId(lineId);
            towerSlot.transform.position = position;
            towerSlot.Start();
        }

        [Test]
        public void CreateEnemyTest() {
            foreach (TowerType towerType in towerTypes) {
                testTower = towerFactory.CreateTower(towerSlot, towerType);
                Assert.NotNull(testTower,
                               String.Format("Tower Game object wasn't created, was type {0}", towerType));

                var towerInstance = testTower.GetComponent<Tower>();

                Assert.NotNull(towerInstance,
                               String.Format("Tower script instance wasn't created, was type {0}", towerType));
                Assert.That(towerInstance.lineId, Is.EqualTo(lineId),
                            String.Format("Line id is wrong, was type {0}", towerType));
                Assert.That(towerInstance.attackRange,
                            Is.EqualTo(Configuration.Towers[towerType].AttackRange * Configuration.CellWidth),
                            String.Format("Attack range is not as in configuration, was type {0}", towerType));
                Assert.That(towerInstance.shootsPerSecond,
                            Is.EqualTo(Configuration.Towers[towerType].ShootsPerSecond),
                            String.Format("Shoots per second is not as in configuration, was type {0}", towerType));
                Assert.That(towerInstance.damage,
                            Is.EqualTo(Configuration.Towers[towerType].Damage),
                            String.Format("Damage is not as in configuration, was type {0}", towerType));
                Assert.That(towerInstance.transform.position, Is.EqualTo(position),
                            String.Format("Position is wrong, was type {0}", towerType));
                Assert.That(towerInstance.shootingStrategy, Is.InstanceOf(typeof (CreateBullet)),
                            String.Format("Shooting strategy is wrong, was type {0}", towerType));
                Assert.That(towerInstance.targetingStrategy, Is.InstanceOf(typeof (FindEnemy)),
                            String.Format("Targeting strategy is wrong, was type {0}", towerType));

                Assert.NotNull(testTower.GetComponent<Tower>().sprite,
                               String.Format("Sprite wasn't created, was type {0}", towerType));

                TearDownTestObject();
            }
        }


        [TearDown]
        public void TearDown() {
            Object.DestroyImmediate(towerFactory.gameObject);
            Object.DestroyImmediate(towerSlot.gameObject);
        }

        public void TearDownTestObject() {
            var spriteManager = (SpriteManager) Object.FindObjectOfType(typeof (SpriteManager));
            spriteManager.RemoveSprite(testTower.GetComponent<Tower>().sprite);
            testTower.GetComponent<Tower>().sprite = null;
            Object.DestroyImmediate(testTower);
        }
    }
}