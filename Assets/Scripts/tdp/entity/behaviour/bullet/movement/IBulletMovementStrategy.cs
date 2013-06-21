namespace Assets.Scripts.tdp.entity.behaviour.bullet.movement
{
    public interface IBulletMovementStrategy {
        void Move(Bullet contextBullet, float elapsedTime);
    }
}
