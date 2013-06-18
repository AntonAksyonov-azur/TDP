using UnityEngine;
using System.Collections;

namespace Assets.Scripts.tdp.entity.behaviour.bullet
{
    public interface IBulletMovementStrategy {
        void Move(Bullet contextBullet, float elapsedTime);
    }
}
