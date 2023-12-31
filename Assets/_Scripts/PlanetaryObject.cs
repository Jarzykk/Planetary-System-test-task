using System;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
    private double _mass;
    private float _orbitalSpeed;
    private Vector3 _centerOfSystemPosition;
    private MassClass _massClass;

    public void Initialize(MassClass massClass, double mass, float radius, float orbitalSpeed, Vector3 centerOfSystemPosition)
    {
        _mass = mass;
        _orbitalSpeed = orbitalSpeed;
        _centerOfSystemPosition = centerOfSystemPosition;
        _massClass = massClass;

        transform.localScale = new Vector3(radius, radius, radius);
    }
    
    public double GetMass()
    {
        return _mass;
    }

    public MassClass GetMassClass()
    {
        return _massClass;
    }

    public void OrbitalMove(float deltaTime)
    {
        transform.RotateAround(_centerOfSystemPosition, Vector3.up, _orbitalSpeed * deltaTime);
    }
}
