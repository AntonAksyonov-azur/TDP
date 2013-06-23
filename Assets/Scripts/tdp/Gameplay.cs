using Assets.Scripts.net.extension;
using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.bullet.factory;
using Assets.Scripts.tdp.entity.enemy.factory;
using Assets.Scripts.tdp.entity.tower.factory;
using Assets.Scripts.tdp.gui;
using UnityEngine;

namespace Assets.Scripts.tdp {
    public class Gameplay : MonoBehaviour, INotifyEnemyPassed {
        public SpriteManager mainSpriteManager;

        public GameObject linePrefab;
        public GameObject towerSlotPrefab;

        public BulletFactory bulletFactory;
        public EnemyFactory enemyFactory;
        public TowerFactory towerFactory;

        private float elapsedTimeSinceLastEnemyAppears;

        public float elapsedGameplayTime { get; private set; }

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
                GameObject lineGameObject =
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
                    Vector2 vector = new Vector2(
                        Configuration.FirstTowerSlotPositionX + j * Configuration.TowerSlotWidth,
                        Configuration.FirstTowerSlotPositionY - i * Configuration.LineHeight);

                    GameObject towerSlotGameObject =
                        (GameObject) Instantiate(
                            towerSlotPrefab,
                            vector,
                            Quaternion.identity);
                    TowerSlot towerSlot = towerSlotGameObject.GetComponent<TowerSlot>();
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
            Vector2 vector = new Vector2(Configuration.FirstEnemyPositionX,
                                     Configuration.FirstEnemyPositionY - targetLineId * Configuration.LineHeight);

            enemyFactory.CreateEnemy(vector, targetLineId, Configuration.Enemies.GetRandomKeyViaUnityRandom());
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