using UnityEngine;

namespace Assets.Scripts.tdp.utility {
    public static class CoordinateConverter {
        public static Vector2 RealCoordinatesToScreen(int screenWidth, int screenHeight, float x, float y) {
            return new Vector2(x + screenWidth / 2, -y + screenHeight / 2);
        }

        public static Vector2 ScreenCoordinatesToReal(int screenWidth, int screenHeight, float x, float y) {
            return new Vector2(x - screenWidth / 2, -y + screenHeight / 2);
        }
    }
}