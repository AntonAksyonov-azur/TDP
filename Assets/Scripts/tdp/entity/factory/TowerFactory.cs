using Assets.Scripts.sprite.manager;
using Assets.Scripts.tdp.configuration;
using Assets.Scripts.tdp.constants;
using Assets.Scripts.tdp.entity.behaviour.tower;
using Assets.Scripts.tdp.gui;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.factory {
    public class TowerFactory : MonoBehaviour {
        public SpriteManager spriteManager;
        public GameObject towerPrefab;

        private BulletFactory bulletFactory;

        private IFindTargetStrategy targetingStrategy;
        private IShootStrategy shootingStrategy;

        public void Start() {
            bulletFactory = new BulletFactory();

            targetingStrategy = new FindEnemy();
            shootingStrategy = new CreateBullet(bulletFactory);
        }

        public GameObject CreateTower(TowerSlot towerSlot, TowerType towerType) {
            var towerGameObject = (GameObject)Instantiate(
                towerPrefab,
                towerSlot.gameObject.transform.position,
                Quaternion.identity);

            Tower tower = towerGameObject.GetComponent<Tower>();
            tower.towerSlot = towerSlot;
            tower.lineId = towerSlot.lineId;

            tower.attackRange = Configuration.TowerAttackRange[towerType] * Configuration.CellWidth;
            tower.damage = Configuration.TowerDamage[towerType];
            tower.shootsPerSecond = Configuration.TowerShootsPerSecond[towerType];

            tower.shootingStrategy = shootingStrategy;
            tower.targetingStrategy = targetingStrategy;

            towerGameObject.GetComponent<BoxCollider>().size = Configuration.TowerSize;

            // Объект уже в мире из-за вызова Instantiate

            // Добавляем спрайт
            Rect towerFrame = Configuration.TowerFrames[towerType];

            tower.sprite = spriteManager.AddSprite(towerGameObject,
                                                   towerFrame.width,
                                                   towerFrame.height,
                                                   (int) towerFrame.x,
                                                   (int) (towerFrame.y + towerFrame.height),
                                                   (int) towerFrame.width, (int) towerFrame.height,
                                                   false);

            return towerGameObject;
        }
    }
}