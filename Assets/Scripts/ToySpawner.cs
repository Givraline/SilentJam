using System.Collections;
using UnityEngine;

public class ToySpawner : MonoBehaviour
{
    [SerializeField] int _numberOfToysToSpawn;
    [SerializeField] float _timeBewteenSpawn;
    [SerializeField] GameObject _toyPrefab;
    Coroutine _spawnToys;

    private void Start()
    {
        StartSpawnToys();
    }

    void StartSpawnToys()
    {
        _spawnToys = StartCoroutine(SpawnToys());
    }

    IEnumerator SpawnToys()
    {
        while(_numberOfToysToSpawn > 0)
        {
            _numberOfToysToSpawn--;
            Instantiate(_toyPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(_timeBewteenSpawn);
        }
        StopSpawnToys();
    }

    void StopSpawnToys()
    {
        StopCoroutine(_spawnToys);
    }
}
