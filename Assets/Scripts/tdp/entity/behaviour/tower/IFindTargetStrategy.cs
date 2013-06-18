using UnityEngine;

namespace Assets.Scripts.tdp.entity.behaviour.tower
{
    public interface IFindTargetStrategy {
        GameObject FindTarget(Tower contextTower);
    }
}
