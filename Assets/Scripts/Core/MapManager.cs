using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour, IMapManager
{

    public bool isActive = false;
    public GameObject prototype;
    public Transform SpawnPoint;
    public Vector3 spawnRange;
    public float generationSpeed;
    [ReadOnly]
    public float currentSpeed;
    public float exceloration;
    public float excelorationDelay = 2;
    public IMapGarbageCollector mapGC;
    public List<GameObject> units = new List<GameObject>();
    public List<IUnitBuilder> builders = new List<IUnitBuilder>();

    private float generationCounter = 0.0F;
    private float excelorationCounter = 0.0F;

    public List<GameObject> GetUnits()
    {
        return units;
    }

    void Start()
    {
        mapGC = GetComponent<IMapGarbageCollector>();
        builders.Add(new ATypeBuiler());
        builders.Add(new BTypeBuiler());
        builders.Add(new CTypeBuiler());
        currentSpeed = generationSpeed;
        generationCounter = 1 / currentSpeed;
    }

    public void StartGeneration()
    {
        isActive = true;
        mapGC?.StartCollecting(units);
    }
    
    void Update()
    {
        if (!isActive)
            return;
        generationCounter += Time.deltaTime;
        excelorationCounter += Time.deltaTime;
        if (excelorationCounter > excelorationDelay)
        {
            excelorationCounter -= excelorationDelay;
            currentSpeed += exceloration;
        }

        if (generationCounter > 1 / currentSpeed)
        {
            generationCounter -= 1 / currentSpeed;
            GameObject unit = Instantiate(prototype);
            units.Add(unit);
            int chance = Random.Range(0, builders.Count);
            builders[chance].BuildUnit(unit, this);

            unit.transform.position += SpawnPoint.position;
            unit.transform.position += spawnRange * Random.Range(-1.0F, 1.0F);
        }
    }

    public void Pause()
    {
        isActive = false;
    }

    public void Clear()
    {
        foreach (var unit in units)
            Destroy(unit);
        units.Clear();
    }
}
