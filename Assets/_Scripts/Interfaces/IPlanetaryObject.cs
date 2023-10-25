public interface IPlanetaryObject
{
    public double GetMass();
    public PlanetType GetPlanetType();
    public void OrbitalMove(float deltaTime);
}