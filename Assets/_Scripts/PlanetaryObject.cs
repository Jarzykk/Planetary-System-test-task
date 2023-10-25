using System;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
    private double _mass;
    private float _orbitalSpeed;
    private Vector3 _centerOfSystemPosition;
    private PlanetType _planetType;

    public void Initialize(PlanetType planetType, double mass, float radius, float orbitalSpeed, Vector3 centerOfSystemPosition)
    {
        _mass = mass;
        _orbitalSpeed = orbitalSpeed;
        _centerOfSystemPosition = centerOfSystemPosition;
        _planetType = planetType;

        transform.localScale = new Vector3(radius, radius, radius);
    }
    
    public double GetMass()
    {
        return _mass;
    }

    public PlanetType GetPlanetType()
    {
        return _planetType;
    }

    public void OrbitalMove(float deltaTime)
    {
        transform.RotateAround(_centerOfSystemPosition, Vector3.up, _orbitalSpeed * deltaTime);
    }
}
