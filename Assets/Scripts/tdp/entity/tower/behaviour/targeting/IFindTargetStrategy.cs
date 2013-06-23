using UnityEngine;

namespace Assets.Scripts.tdp.entity.tower.behaviour.targeting {
    public interface IFindTargetStrategy {
        GameObject FindTarget(Tower contextTower);
    }
}