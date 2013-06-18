using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.factory;
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
        private float cachedSize;

        public void Start() {
            cachedPosition = CoordinateConverter.RealCoordinatesToScreen(transform.position.x, transform.position.y);
            cachedSize = Configuration.TowerSlotHeight / 3;
        }

        public void OnGUI() {
            if (status == INITIAL_STATUS) {
                if (GUI.Button(new Rect(
                                   cachedPosition.x - Configuration.TowerSlotWidth / 2,
                                   cachedPosition.y - Configuration.TowerSlotHeight / 2,
                                   Configuration.TowerSlotWidth,
                                   Configuration.TowerSlotHeight), "Build\nTower")) {
                    status = CHOOSE_TYPE_OF_TOWER_STATUS;
                }
            }

            if (status == CHOOSE_TYPE_OF_TOWER_STATUS) {
                if (GUI.Button(new Rect(
                                   cachedPosition.x - Configuration.TowerSlotWidth / 2,
                                   cachedPosition.y - (Configuration.TowerSlotHeight / 2),
                                   Configuration.TowerSlotWidth,
                                   cachedSize), "Type 1")) {
                    CreateTowerAndDestroySlot(TowerType.Type1);
                }
                if (GUI.Button(new Rect(
                                   cachedPosition.x - Configuration.TowerSlotWidth / 2,
                                   cachedPosition.y - Configuration.TowerSlotHeight / 2 + cachedSize,
                                   Configuration.TowerSlotWidth,
                                   cachedSize), "Type 2")) {
                    CreateTowerAndDestroySlot(TowerType.Type2);
                }
                if (GUI.Button(new Rect(
                                   cachedPosition.x - Configuration.TowerSlotWidth / 2,
                                   cachedPosition.y - Configuration.TowerSlotHeight / 2 + cachedSize * 2,
                                   Configuration.TowerSlotWidth,
                                   cachedSize), "Type 3")) {
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