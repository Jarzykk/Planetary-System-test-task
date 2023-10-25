using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
{
    [SerializeField] private double _totalMass;
    [SerializeField] private float _spawnDistanceFromCenter = 50f;
    [SerializeField] private float _minSpawnDistanceIncrement = 30f;
    [SerializeField] private float _maxSpawnDistanceIncrement = 50f;
    [SerializeField] private float _initialPlanetSpeed = 10f;
    [SerializeField] private PlanetaryObject _planetaryObjectPrefub;
    [SerializeField] private GameObject _sun;
    
    private Vector3 _centerOfSystem = Vector3.zero;

    private PlanetarySystem _planetarySystem;

    private void Start()
    {
        _centerOfSystem = _sun.transform.position;
        
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
        
        System.Random random = new System.Random();
        
        float currentAngle = 0f;
        
        while (totalMass > minAvailableMass)
        {
            double randomMass = random.NextDouble() * (totalMass - minAvailableMass) + minAvailableMass;
            
            var createdPlanetType = GetSpawnPlanetParameters(randomMass, random, out var targetMass, out var targetRadius);
            var spawnPosition = GetPlanetaryObjectSpawnPosition(targetDistanceFromCenter);

            PlanetaryObject createdPlanetaryObject = Instantiate(_planetaryObjectPrefub, spawnPosition, Quaternion.identity);
            
            createdPlanetaryObject.Initialize(createdPlanetType, targetMass, targetRadius, _initialPlanetSpeed, _centerOfSystem);
            _planetarySystem.AddPlanetaryObject(createdPlanetaryObject);
                
            targetDistanceFromCenter += Random.Range(_minSpawnDistanceIncrement, _maxSpawnDistanceIncrement) + targetRadius * 2;
            totalMass -= randomMass;
            
            if (totalMass < minAvailableMass)
            {
                break;
            }
        }
    }

    private static PlanetType GetSpawnPlanetParameters(double randomMass, System.Random random, out double targetMass,
        out float targetRadius)
    {
        PlanetType createdPlanetType = PlanetDataHolder.Instance.GetPlanetTypeByMass(randomMass);
        PlanetData planetData = PlanetDataHolder.Instance.GetPlanetDataByType(createdPlanetType);

        targetMass = random.NextDouble() * (planetData.MaxMass - planetData.MinMass) + planetData.MinMass;
        targetRadius = PlanetDataHolder.Instance.GetRadiusByMass(createdPlanetType, targetMass);
        return createdPlanetType;
    }

    private Vector3 GetPlanetaryObjectSpawnPosition(float targetDistanceFromCenter)
    {
        float currentAngle;
        currentAngle = Random.Range(0, 360f);

        Vector3 spawnPosition = (transform.position +
                                 Quaternion.Euler(0, currentAngle, 0) *
                                 (transform.forward * targetDistanceFromCenter));
        return spawnPosition;
    }

    public IPlanetarySystem Create(double mass)
    {
        _planetarySystem = new PlanetarySystem();
        
        CreatePlanets(mass);
        
        return _planetarySystem;
    }
}