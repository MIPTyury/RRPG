using UnityEngine;
using Assets;
using System.Collections.Generic;
using System;
using Weapons;

namespace Runtime
{
    public class WeaponHolderController : IController
    {
        private WeaponAsset m_WeaponAsset;

        public WeaponHolderController(PlayerSpawnerAsset PlayerSpawnerAsset)
        {
            m_WeaponAsset = PlayerSpawnerAsset.PlayerAsset.WeaponAsset;
        }

        public void OnStart() 
        {
            Debug.Log(m_WeaponAsset.m_name);
            SetWeaponData();
        }

        public void OnStop() 
        {

        }

        public void OnTick () 
        {
            
        }

        public void SetWeaponData()
        {   
            WeaponData data = new WeaponData(m_WeaponAsset);

            Game.Runtime.SetWeapon(data);
        }

    }
    
}