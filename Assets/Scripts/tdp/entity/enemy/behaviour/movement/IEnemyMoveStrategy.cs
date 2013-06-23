namespace Assets.Scripts.tdp.entity.enemy.behaviour.movement {
    public interface IEnemyMoveStrategy {
        void Move(Enemy contextEnemy, float elapsedTime);
    }
}