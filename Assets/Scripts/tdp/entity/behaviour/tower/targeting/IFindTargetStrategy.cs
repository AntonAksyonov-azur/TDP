using UnityEngine;

namespace Assets.Scripts.tdp.entity.behaviour.tower.targeting {
    public interface IFindTargetStrategy {
        GameObject FindTarget(Tower contextTower);
    }
}