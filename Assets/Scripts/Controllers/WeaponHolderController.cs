using UnityEngine;
using Player;
using Assets;
using System.Collections.Generic;
using System;
using Skills;
using Weapons;

namespace Runtime
{
    public class WeaponHolderController : IController
    {
        private WeaponAsset m_WeaponAsset;
        private Dictionary<string, Action> ModeDict = new();

        public WeaponHolderController(PlayerSpawnerAsset PlayerSpawnerAsset)
        {
            m_WeaponAsset = PlayerSpawnerAsset.PlayerAsset.WeaponAsset;
        }

        public void OnStart() 
        {
            SetWeaponData();
        }

        public void OnStop() 
        {
            // Debug.Log("OnStop was called");
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