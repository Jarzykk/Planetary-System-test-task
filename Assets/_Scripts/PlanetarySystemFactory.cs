using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
{
    [Header("Parameters")]
    [SerializeField] private double _totalMass;
    [SerializeField] private Vector3 _centerOfSystemPosition = Vector3.zero;
    
    [Header("Distance values")]
    [SerializeField] private float _spawnDistanceFromCenter = 50f;
    [SerializeField, Min(35f)] private float _minSpawnDistanceIncrement = 35f;
    [SerializeField] private float _maxSpawnDistanceIncrement = 50f;
    
    [Header("Speed")]
    [SerializeField] private float _minPlanetaryObjectSpeed = 5f;
    [SerializeField] private float _maxPlanetaryObjectSpeed = 15f;
    
    [Header("Prefabs")]
    [SerializeField] private PlanetaryObject _planetaryObjectPrefab;
    
    [Header("Other")]
    [SerializeField] private Sun _sun;
    

    private PlanetarySystem _planetarySystem;

    private void Start()
    {
        _sun.transform.position = _centerOfSystemPosition;
        Create(_totalMass);
    }

    private void Update()
    {
        _planetarySystem.Update(Time.deltaTime);
    }

    private void CreatePlanets(double totalMass)
    {
        float targetDistanceFromCenter = _spawnDistanceFromCenter;
        double minAvailableMass = PlanetDataHolder.Instance.GetMinAvailableMass();

        if (_totalMass <= minAvailableMass)
            throw new SystemException("Total mass is lesser than the tiniest planetary objest");
        
        System.Random random = new System.Random();

        while (totalMass > minAvailableMass)
        {
            double randomMass = random.NextDouble() * (totalMass - minAvailableMass) + minAvailableMass;
            
            PlanetType createdPlanetType = PlanetDataHolder.Instance.GetPlanetTypeByMass(randomMass);
            PlanetData planetData = PlanetDataHolder.Instance.GetPlanetDataByType(createdPlanetType);
        
            double targetMass = random.NextDouble() * (planetData.MaxMass - planetData.MinMass) + planetData.MinMass;
            float targetRadius = PlanetDataHolder.Instance.GetRadiusByMass(createdPlanetType, targetMass);
            
            float currentSpawnAngle = Random.Range(0f, 360f);
            
            Vector3 spawnPosition = transform.position + Quaternion.Euler(0, currentSpawnAngle, 0) * (transform.forward * targetDistanceFromCenter);
            spawnPosition.y = _centerOfSystemPosition.y;

            float targetSpeed = Random.Range(_minPlanetaryObjectSpeed, _maxPlanetaryObjectSpeed);

            PlanetaryObject createdPlanetaryObject = Instantiate(_planetaryObjectPrefab, spawnPosition, Quaternion.identity);
            createdPlanetaryObject.Initialize(createdPlanetType, targetMass, targetRadius, targetSpeed, _centerOfSystemPosition);
            _planetarySystem.AddPlanetaryObject(createdPlanetaryObject);
            
            targetDistanceFromCenter += Random.Range(_minSpawnDistanceIncrement, _maxSpawnDistanceIncrement) + targetRadius * 2;
            totalMass -= randomMass;

            if (totalMass < minAvailableMass)
            {
                break;
            }
        }
    }

    public IPlanetarySystem Create(double mass)
    {
        _planetarySystem = new PlanetarySystem();
        
        CreatePlanets(mass);
        
        return _planetarySystem;
    }
}