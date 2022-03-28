using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFabric
{
    protected GameObject _spawnPrefab;
    protected Transform _spawnPoint;

    public WeaponFabric(GameObject spawnPrefab, Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
        _spawnPrefab = spawnPrefab;
    }

    public abstract GameObject Spawn();
}
