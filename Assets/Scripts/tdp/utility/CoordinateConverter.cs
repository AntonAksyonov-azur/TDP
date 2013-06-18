using Assets.Scripts.tdp.configuration;
using UnityEngine;

namespace Assets.Scripts.tdp.utility {
    public static class CoordinateConverter {
        public static Vector2 RealCoordinatesToScreen(float x, float y) {
            return new Vector2(x + Configuration.ScreenWidth / 2, -y + Configuration.ScreenHeight / 2);
        }

        public static Vector2 ScreenCoordinatesToReal(float x, float y) {
            return new Vector2(x - Configuration.ScreenWidth / 2, -y + Configuration.ScreenHeight / 2);
        }
    }
}