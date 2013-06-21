using Assets.Scripts.tdp.entity;
using Assets.Scripts.tdp.entity.behaviour.tower;
using Assets.Scripts.tdp.entity.behaviour.tower.shooting;
using Assets.Scripts.tdp.entity.behaviour.tower.targeting;
using UnityEngine;

namespace Assets.Scripts.tdp {
    public class Tower : BasicGameEntity {
        public float attackRange;
        public float shootsPerSecond;
        public int damage;
        
        public IShootStrategy shootingStrategy;
        public IFindTargetStrategy targetingStrategy;

        private float timeShootInterval;
        private float elapsedTimeSinceLastShoot;

        public override void Start() {
            timeShootInterval = 1.0f / shootsPerSecond;
        }

        public override void Update() {
            elapsedTimeSinceLastShoot += elapsedTimeSinceLastShoot < timeShootInterval ? Time.deltaTime : 0;
            GameObject enemy = targetingStrategy.FindTarget(this);

            if (enemy != null && elapsedTimeSinceLastShoot >= timeShootInterval) {
                shootingStrategy.Shoot(this);
                elapsedTimeSinceLastShoot = 0;
            }
        }
    }
}