using Assets.Scripts.tdp.constants;
using UnityEngine;

namespace Assets.Scripts.tdp.entity.behaviour.tower {
    public class FindEnemy : IFindTargetStrategy {
        public GameObject FindTarget(Tower contextTower) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.Enemy);

            if (enemies != null) {
                foreach (GameObject gameObject in enemies) {
                    var enemy = gameObject.GetComponent<Enemy>();
                    if (enemy.lineId == contextTower.lineId) {
                        Vector2 towerVector =
                            new Vector2(
                                contextTower.transform.position.x + contextTower.GetComponent<BoxCollider>().size.x / 2,
                                contextTower.transform.position.y);
                        Vector2 enemyVector =
                            new Vector2(
                                gameObject.transform.position.x - gameObject.GetComponent<BoxCollider>().size.x / 2,
                                gameObject.transform.position.y);

                        // Дополнительно: враг справа, а не слева
                        // Правая точка хитбокса башни находится справа от левой точки хитбокса противника
                        if (towerVector.x >= enemyVector.x) {
                            continue;
                        }

                        float distance = Vector2.Distance(towerVector, enemyVector);

                        if (distance <= contextTower.attackRange) {
                            return gameObject;
                        }
                    }
                }
            }

            return null;
        }
    }
}