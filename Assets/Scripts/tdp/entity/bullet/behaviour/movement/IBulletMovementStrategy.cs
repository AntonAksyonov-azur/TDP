namespace Assets.Scripts.tdp.entity.bullet.behaviour.movement
{
    public interface IBulletMovementStrategy {
        void Move(Bullet contextBullet, float elapsedTime);
    }
}
