using Assets.Scripts.tdp.entity.factory;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.tdp.entity.behaviour.tower
{
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
