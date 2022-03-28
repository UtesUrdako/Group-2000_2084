using System.Collections;
using System.Collections.Generic;
using LernProject;
using UnityEngine;

public sealed class ShieldGenerator : WeaponFabric
{
    private int _level;
    
    public ShieldGenerator(int level, GameObject spawnPrefab, Transform spawnPoint) : base(spawnPrefab, spawnPoint)
    {
        _level = level;
    }

    public override GameObject Spawn()
    {
        var shieldObj = Object.Instantiate(_spawnPrefab, _spawnPoint.position, _spawnPoint.rotation);
        var shield = shieldObj.GetComponent<Shield>();
        shield.Init(10 * _level);
            
        shield.transform.SetParent(_spawnPoint);
        return shieldObj;
    }
}
