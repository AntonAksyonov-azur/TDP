using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.tower.factory;
using Assets.Scripts.tdp.utility;
using UnityEngine;

namespace Assets.Scripts.tdp.gui {
    public class TowerSlot : MonoBehaviour {
        public int lineId;
        public TowerFactory towerFactory;

        private const int INITIAL_STATUS = 0;
        private const int CHOOSE_TYPE_OF_TOWER_STATUS = 1;

        private int status;
        private Vector2 cachedPosition;
        private Rect cachedRectangleMainButton;

        private float cachedSizeForTypeButtons;
        private Rect cachedRectangleTypeButton1;
        private Rect cachedRectangleTypeButton2;
        private Rect cachedRectangleTypeButton3;

        public void Start() {
            cachedPosition = CoordinateConverter.RealCoordinatesToScreen(
                Configuration.ScreenWidth, Configuration.ScreenHeight,
                transform.position.x, transform.position.y);

            cachedRectangleMainButton = new Rect(
                cachedPosition.x - Configuration.TowerSlotWidth / 2,
                cachedPosition.y - Configuration.TowerSlotHeight / 2,
                Configuration.TowerSlotWidth,
                Configuration.TowerSlotHeight);

            cachedSizeForTypeButtons = Configuration.TowerSlotHeight / 3;
            cachedRectangleTypeButton1 = new Rect(
                cachedPosition.x - Configuration.TowerSlotWidth / 2,
                cachedPosition.y - Configuration.TowerSlotHeight / 2,
                Configuration.TowerSlotWidth,
                cachedSizeForTypeButtons);
            cachedRectangleTypeButton2 = new Rect(
                cachedPosition.x - Configuration.TowerSlotWidth / 2,
                cachedPosition.y - Configuration.TowerSlotHeight / 2 + cachedSizeForTypeButtons,
                Configuration.TowerSlotWidth,
                cachedSizeForTypeButtons);
            cachedRectangleTypeButton3 = new Rect(
                cachedPosition.x - Configuration.TowerSlotWidth / 2,
                cachedPosition.y - Configuration.TowerSlotHeight / 2 + cachedSizeForTypeButtons * 2,
                Configuration.TowerSlotWidth,
                cachedSizeForTypeButtons);
        }

        public void OnGUI() {
            if (status == INITIAL_STATUS) {
                if (GUI.Button(cachedRectangleMainButton, "Build\nTower")) {
                    status = CHOOSE_TYPE_OF_TOWER_STATUS;
                }
            }

            if (status == CHOOSE_TYPE_OF_TOWER_STATUS) {
                if (GUI.Button(cachedRectangleTypeButton1, "Type 1")) {
                    CreateTowerAndDestroySlot(TowerType.Type1);
                }
                if (GUI.Button(cachedRectangleTypeButton2, "Type 2")) {
                    CreateTowerAndDestroySlot(TowerType.Type2);
                }
                if (GUI.Button(cachedRectangleTypeButton3, "Type 3")) {
                    CreateTowerAndDestroySlot(TowerType.Type3);
                }
            }
        }

        private void CreateTowerAndDestroySlot(TowerType towerType) {
            towerFactory.CreateTower(this, towerType);
            Destroy(gameObject);
        }
    }
}