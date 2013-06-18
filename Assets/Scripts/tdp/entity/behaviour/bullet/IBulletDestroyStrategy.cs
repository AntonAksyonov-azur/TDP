using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.tdp.entity.behaviour.bullet
{
	public interface IBulletDestroyStrategy {
	    void Destroy(Bullet contextBullet);
	}
}
