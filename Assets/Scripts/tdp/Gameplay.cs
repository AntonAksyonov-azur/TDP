using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.factory;
using Assets.Scripts.tdp.gui;
using UnityEngine;

namespace Assets.Scripts.tdp {
    public class Gameplay : MonoBehaviour, INotifyEnemyPassed {
        public EnemyFactory enemyFactory;
        public TowerFactory towerFactory;
        public BulletFactory bulletFactory;
        
        public GameObject linePrefab;
        public GameObject towerSlotPrefab;

        public SpriteManager mainSpriteManager;

        public float elapsedGameplayTime { get; private set; }
        private float elapsedTimeSinceLastEnemyAppears;
        
        public int enemiesPassed { get; private set; }

        #region Initialization Methods
        public void Start() {
            CreateLines();

            CreateTowerSlots();

            //CreateRandomEnemy();

            elapsedTimeSinceLastEnemyAppears = 0;
            elapsedGameplayTime = 0;
            enemiesPassed = 0;
        }

        private void CreateLines() {
            Rect lineFrame = Configuration.LineFrame;

            for (int i = 0; i < Configuration.LinesCount; i++) {
                var lineGameObject =
                    (GameObject) Instantiate(linePrefab,
                                             new Vector3(Configuration.FirstLinePositionX,
                                                         Configuration.FirstLinePositionY - i * lineFrame.height),
                                             Quaternion.identity);

                mainSpriteManager.AddSprite(lineGameObject,
                                            lineFrame.width,
                                            lineFrame.height,
                                            (int) lineFrame.x,
                                            (int) (lineFrame.y + lineFrame.height),
                                            (int) lineFrame.width, (int) lineFrame.height,
                                            false);
            }
        }

        private void CreateTowerSlots() {
            for (int i = 0; i < Configuration.LinesCount; i++) {
                for (int j = 0; j < Configuration.TowerSlotsCount; j++) {
                    var towerSlotGameObject = (GameObject) Instantiate(towerSlotPrefab,
                                                                       new Vector3(
                                                                           Configuration.FirstTowerSlotPositionX +
                                                                           j * Configuration.TowerSlotWidth,
                                                                           Configuration.FirstTowerSlotPositionY -
                                                                           i * Configuration.LineHeight),
                                                                       Quaternion.identity);
                    var towerSlot = towerSlotGameObject.GetComponent<TowerSlot>();
                    towerSlot.lineId = i;
                    towerSlot.towerFactory = towerFactory;
                }
            }
        }
        #endregion

        #region Update Methods

        public void Update() {
            UpdateEnemyAppearance();

            UpdateGameStatus();
        }

        private void UpdateEnemyAppearance() {
            elapsedTimeSinceLastEnemyAppears += Time.deltaTime;
            if (elapsedTimeSinceLastEnemyAppears >= Configuration.EnemyAppearsInterval) {
                CreateRandomEnemy();
                elapsedTimeSinceLastEnemyAppears = 0;
            }
        }

        private void CreateRandomEnemy() {
            int targetLineId = Random.Range(0, Configuration.LinesCount);
            var enemyType = (EnemyType)Random.Range(0, Configuration.EnemyTypesCount);

            enemyFactory.CreateEnemy(
                new Vector2(Configuration.FirstEnemyPositionX,
                            Configuration.FirstEnemyPositionY - targetLineId * Configuration.LineHeight), targetLineId,
                enemyType);
        }

        private void UpdateGameStatus() {
            elapsedGameplayTime += Time.deltaTime;

            if (elapsedGameplayTime >= Configuration.SecondsToEndGame) {
                Application.LoadLevel(SceneNames.Win);
            }
        }

        #endregion

        #region INofityEnemyPassed
        public void EnemyPassed() {
            enemiesPassed += 1;
            if (enemiesPassed >= Configuration.EnemiesPassesCountToLoose) {
                Application.LoadLevel(SceneNames.Loose);
            }
        }
        #endregion
    }
}