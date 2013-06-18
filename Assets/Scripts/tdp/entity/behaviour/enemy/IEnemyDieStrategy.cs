using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.tdp.entity.behaviour.enemy
{
	public interface IEnemyDieStrategy {
	    void Die(Enemy contextEnemy);
	}
}
