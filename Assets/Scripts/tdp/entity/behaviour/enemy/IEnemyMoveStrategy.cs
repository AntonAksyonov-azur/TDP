namespace Assets.Scripts.tdp.entity.behaviour.enemy
{
	public interface IEnemyMoveStrategy {
	    void Move(Enemy contextEnemy, float elapsedTime);
	}
}
