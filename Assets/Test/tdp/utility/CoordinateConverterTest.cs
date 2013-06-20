using System;
using System.Collections.Generic;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.tdp.utility {
    [TestFixture]
    public class CoordinateConverterTest {
        [SetUp]
        public void InitSources() {
            ScreenWidth = Configuration.ScreenWidth;
            ScreenHeight = Configuration.ScreenHeight;

            unity = new List<Vector2> {
                new Vector2(0, 0), 
                new Vector2(-100, -100), 
                new Vector2(300, 200)
            };

            screen = new List<Vector2> {
                new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                new Vector2(300, 400),
                new Vector2(700, 100)
            };
        }

        private List<Vector2> unity;
        private List<Vector2> screen;
        private int ScreenWidth;
        private int ScreenHeight;

        [Test]
        public void RealCoordinatesToScreenTest() {
            for (int i = 0; i < unity.Count; i++) {
                Vector2 result = CoordinateConverter.RealCoordinatesToScreen(unity[i].x, unity[i].y);

                Assert.That(result, Is.EqualTo(screen[i]), String.Format("Failed on iteration #{0}", i));
            }
        }

        [Test]
        public void ScreenCoordinatesToRealTest() {
            for (int i = 0; i < screen.Count; i++) {
                Vector2 result = CoordinateConverter.ScreenCoordinatesToReal(screen[i].x, screen[i].y);

                Assert.That(result, Is.EqualTo(unity[i]), String.Format("Failed on iteration #{0}", i));
            }
        }
    }
}