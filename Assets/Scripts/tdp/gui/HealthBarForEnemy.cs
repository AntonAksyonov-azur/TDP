using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.enemy;
using Assets.Scripts.tdp.utility;
using UnityEngine;

namespace Assets.Scripts.tdp.gui {
    public class HealthBarForEnemy : MonoBehaviour {
        private Enemy cachedEnemy;          
        public Texture healthBarBody;
        public Texture healthBarBorder;

        public void Start() {
            cachedEnemy = gameObject.GetComponent<Enemy>();  // Можно использовать некий базовый класс, у которого будет "здоровье"
        }

        public void OnGUI() {
            /*
            GUI.Label(new Rect(positionAtScreen.x - 16, positionAtScreen.y - 64, 64, 32),
                      string.Format("{0}/{1}", cachedEnemy.currentHealth, cachedEnemy.maxHealth));
            */
            Vector2 positionAtScreen = CoordinateConverter.RealCoordinatesToScreen(
                Configuration.ScreenWidth, Configuration.ScreenHeight,
                transform.position.x, transform.position.y);
            GUI.DrawTexture(new Rect(
                                positionAtScreen.x - 32,
                                positionAtScreen.y - 32 - healthBarBody.height,
                                healthBarBorder.width * ((float)cachedEnemy.currentHealth / cachedEnemy.maxHealth),
                                healthBarBorder.height), healthBarBody);
            GUI.DrawTexture(new Rect(
                                positionAtScreen.x - 32,
                                positionAtScreen.y - 32 - healthBarBorder.height,
                                healthBarBorder.width,
                                healthBarBorder.height), healthBarBorder);
        }
    }
}