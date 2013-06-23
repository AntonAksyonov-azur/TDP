using Assets.Scripts.tdp.entity.bullet.factory;

namespace Assets.Scripts.tdp.entity.tower.behaviour.shooting {
    public class CreateBullet : IShootStrategy {
        private readonly BulletFactory bulletFactory;

        public CreateBullet(BulletFactory bulletFactory) {
            this.bulletFactory = bulletFactory;
        }

        public void Shoot(Tower contextTower) {
            bulletFactory.CreateBullet(contextTower.lineId, contextTower.damage, contextTower.transform.position);
        }
    }
}