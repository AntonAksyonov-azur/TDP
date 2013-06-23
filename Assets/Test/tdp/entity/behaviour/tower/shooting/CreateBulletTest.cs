﻿using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.tower.shooting;
using Assets.Scripts.tdp.entity.factory;
using Assets.Test.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.tdp.entity.behaviour.tower.shooting {
    [TestFixture]
    public class CreateBulletTest {
        private Bullet testBullet;
        private Tower testTower;
        private BulletFactory bulletFactory;
        private IShootStrategy testingStrategy;

        [SetUp]
        public void SetUp() {
            bulletFactory = ScriptInstantiator.InstantiateScript<BulletFactory>(
                (GameObject)Resources.Load("Prefabs/Factories/BulletFactoryPrefab"));
            bulletFactory.spriteManager = (SpriteManager)Object.FindObjectOfType(typeof (SpriteManager));

            testTower = ScriptInstantiator.InstantiateScript<Tower>(
                (GameObject)Resources.Load("Prefabs/Entities/TowerPrefab"));

            testingStrategy = new CreateBullet(bulletFactory);
        }

        [Test]
        public void ShootTest() {
            testingStrategy.Shoot(testTower);

            var bullets = Object.FindObjectsOfType(typeof(Bullet));

            Assert.That(bullets.Length, Is.EqualTo(1), "Too many bullets");
            
            testBullet = (Bullet)bullets.GetValue(0);

            Assert.NotNull(testBullet, "Bullet wasn't created");
        }

        [TearDown]
        public void TearDown() {
            if (testBullet != null) {
                bulletFactory.spriteManager.RemoveSprite(testBullet.sprite);
                testBullet.sprite = null;
                Object.DestroyImmediate(testBullet.gameObject);
            }
            Object.DestroyImmediate(bulletFactory.gameObject);
        }
    }
}