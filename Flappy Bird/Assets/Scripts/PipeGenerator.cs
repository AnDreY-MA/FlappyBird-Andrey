using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPosY;
    [SerializeField] private float _minSpawnPosY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initilize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;

                float spawnPosY = Random.Range(_minSpawnPosY, _maxSpawnPosY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPosY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }

    }
}
