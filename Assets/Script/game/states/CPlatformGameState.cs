﻿using UnityEngine;
using System.Collections;

public class CPlatformGameState : CGameState
{
	private CTileMap mMap;

	private CEnemyManager mEnemyManager;
	private CItemManager mItemManager;
	private CBulletManager mBulletManager;
	private CParticleManager mParticleManger;
    private Tierra mTierra;


	private CAndy mAndy;




	public CPlatformGameState()
	{
	}

	override public void init()
	{
		base.init ();

		//CGame.inst ().setPlayer (mPlayer);

		mEnemyManager = new CEnemyManager ();
		mItemManager = new CItemManager ();
		mBulletManager = new CBulletManager ();
		mParticleManger = new CParticleManager ();
        mTierra = new Tierra();


		// El mapa crea enemigos. Crear los managers antes que el mapa.
		mMap = new CTileMap ();
		CGame.inst ().setMap (mMap);



		mAndy = new CAndy ();
		mAndy.setXY (400, 400);

		//createAsteroids ();

		/*CEnemyShip e = new CEnemyShip ();
		e.setXY (200, 200);
		CEnemyManager.inst ().add (e);*/
	}

	override public void update()
	{
		base.update (); 

		mMap.update ();

		mAndy.update ();

        mTierra.update();

		mEnemyManager.update ();
		mItemManager.update ();
		mBulletManager.update ();
		mParticleManger.update ();

		if (CEnemyManager.inst ().getLength () == 0) 
		{
			//Debug.Log ("WIN");
		}
     
	}

	override public void render()
	{
		base.render ();

		mMap.render ();

		mAndy.render ();
        mTierra.render();

		mEnemyManager.render ();
		mItemManager.render ();
		mBulletManager.render ();
		mParticleManger.render ();
	}

	override public void destroy()
	{
		base.destroy ();

		mMap.destroy ();
		mMap = null;

		mAndy.destroy ();
		mAndy = null;

		mEnemyManager.destroy ();
		mEnemyManager = null;

		mItemManager.destroy ();
		mItemManager = null;

		mBulletManager.destroy ();
		mBulletManager = null;

		mParticleManger.destroy ();
		mParticleManger = null;


        mTierra.destroy();
        mTierra = null;
    }

	/*private void createAsteroids()
	{
		CAsteroid asteroid;

		for (int i = 0; i < 10; i++) 
		{
			asteroid = new CAsteroid (CAsteroid.TYPE_BIG, CMath.randomIntBetween(1, 3));
			asteroid.setXY (CMath.randomIntBetween(0, CGameConstants.SCREEN_WIDTH), CMath.randomIntBetween(0, CGameConstants.SCREEN_HEIGHT));
			asteroid.setVelX (CMath.randomFloatBetween(-500, 500));
			asteroid.setVelY (CMath.randomFloatBetween(-500, 500));
			CEnemyManager.inst ().add (asteroid);
		}

	}*/


     
}
