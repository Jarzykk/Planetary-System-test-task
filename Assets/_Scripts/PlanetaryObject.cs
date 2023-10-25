using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
    private double _mass;
    private PlanetProperties _planetProperties;
    
    public PlanetaryObject(double mass, float radius)
    {
        _mass = mass;
        _planetProperties = new PlanetProperties(mass, radius);

    }
    
    public double GetMass()
    {
        return _mass;
    }

    public PlanetProperties GetPlanetProperties()
    {
        return _planetProperties;
    }
}
