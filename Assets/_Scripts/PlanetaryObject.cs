using UnityEngine;

public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
    private double _mass;
    private float _distanceToPlanetarySystemCenter;
    private float _orbitalSpeed;
    private Vector3 _centerOfSystemPosition;
    private PlanetProperties _planetProperties;
    
    public PlanetaryObject(double mass, float radius, float distanceToPlanetarySystemCenter, float orbitalSpeed, Vector3 centerOfSystemPosition)
    {
        Initialize(mass, radius, distanceToPlanetarySystemCenter, orbitalSpeed, centerOfSystemPosition);
    }

    public void Initialize(double mass, float radius, float distanceToPlanetarySystemCenter, float orbitalSpeed, Vector3 centerOfSystemPosition)
    {
        _mass = mass;
        _distanceToPlanetarySystemCenter = distanceToPlanetarySystemCenter;
        _orbitalSpeed = orbitalSpeed;
        _centerOfSystemPosition = centerOfSystemPosition;
        _planetProperties = new PlanetProperties(mass, radius);

        transform.localScale = new Vector3(radius, radius, radius);
    }
    
    public double GetMass()
    {
        return _mass;
    }

    public PlanetProperties GetPlanetProperties()
    {
        return _planetProperties;
    }

    public void OrbitalMove(float deltaTime)
    {
        transform.RotateAround(_centerOfSystemPosition, Vector3.up, _orbitalSpeed * deltaTime);
    }
}
