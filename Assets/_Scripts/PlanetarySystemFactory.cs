using System;
using UnityEngine;

public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
{
    [SerializeField] private double _totalMass;
    [SerializeField] private PlanetaryObject _planetaryObjectPrefub;
    [SerializeField] private Vector3 _centerOfSystem = Vector3.zero;

    private PlanetarySystem _planetarySystem;

    private void Start()
    {
        Create(_totalMass);
    }

    private void Update()
    {
        _planetarySystem.Update(Time.deltaTime);
    }

    public void CreatePlanets()
    {
        float distanceToCenter = 150f;
        float distanceIncrement = 50f;
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPosition = transform.position + (transform.forward * distanceToCenter);
            
            var createdObject = Instantiate(_planetaryObjectPrefub, spawnPosition, Quaternion.identity);
            createdObject.Initialize(10, 10 - i * 2, distanceToCenter, 32, Vector3.zero);
            _planetarySystem.AddPlanetaryObject(createdObject);
            distanceToCenter += distanceIncrement;
        }
    }

    public IPlanetarySystem Create(double mass)
    {
        _planetarySystem = new PlanetarySystem(_centerOfSystem);
        
        CreatePlanets();
        
        return _planetarySystem;
    }
}