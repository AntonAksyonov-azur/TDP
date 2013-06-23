using Assets.Scripts.tdp.entity.bullet.behaviour.collision;
using Assets.Scripts.tdp.entity.bullet.behaviour.destruction;
using Assets.Scripts.tdp.entity.bullet.behaviour.movement;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.bullet {
    public class Bullet : BasicGameEntity {
        public float speed; // Число клеток в секунду
        public int damage;

        public IBulletBehaviourInCollisionStrategy bulletBehaviourInCollision;
        public IBulletDestroyStrategy destroyStrategy;
        public IBulletMovementStrategy movementStrategy;

        public override void Update() {
            movementStrategy.Move(this, Time.deltaTime);
        }

        public void OnTriggerEnter(Collider colliderObject) {
            //Debug.Log(string.Format("Bullet hits something ({0})", colliderObject.tag));

            bulletBehaviourInCollision.OnCollision(this, colliderObject);
        }
    }
}