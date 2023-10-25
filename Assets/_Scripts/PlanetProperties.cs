public class PlanetProperties
{
    private double _mass;
    private float _radius;

    public double Mass => _mass;
    public float Radius => _radius;

    public PlanetProperties(double mass, float radius)
    {
        _mass = mass;
        _radius = radius;
    }
}