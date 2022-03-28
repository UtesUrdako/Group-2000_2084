using System.Collections;
using System.Collections.Generic;
using LernProject;
using UnityEngine;

public class Gun : WeaponFabric
{
    public Gun(GameObject spawnPrefab, Transform spawnPoint) : base(spawnPrefab, spawnPoint)
    {
    }

    public override GameObject Spawn()
    {
        var bulletObj = Object.Instantiate(_spawnPrefab, _spawnPoint.position, _spawnPoint.rotation);
        var bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(10, 0.6f);
        //Invoke(nameof(Reloading), _cooldown);
        return bulletObj;
    }
}
