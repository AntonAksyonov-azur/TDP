using System;
using System.Collections.Generic;
using Assets.Scripts.tdp.utility;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.tdp.utility {

    [TestFixture]
    public class CoordinateConverterTest {
        private List<Vector2> unity;
        private List<Vector2> screen;
        private const int ScreenWidth = 800;
        private const int ScreenHeight = 600;

        [SetUp]
        public void InitSources() {
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

        [Test]
        public void RealCoordinatesToScreenTest() {
            for (int i = 0; i < unity.Count; i++) {
                Vector2 result = 
                    CoordinateConverter.RealCoordinatesToScreen(
                    ScreenWidth,ScreenHeight, unity[i].x, unity[i].y);

                Assert.That(result, Is.EqualTo(screen[i]), String.Format("Failed on iteration #{0}", i));
            }
        }

        [Test]
        public void ScreenCoordinatesToRealTest() {
            for (int i = 0; i < screen.Count; i++) {
                Vector2 result = 
                    CoordinateConverter.ScreenCoordinatesToReal(
                    ScreenWidth, ScreenHeight, screen[i].x, screen[i].y);

                Assert.That(result, Is.EqualTo(unity[i]), String.Format("Failed on iteration #{0}", i));
            }
        }
    }
}