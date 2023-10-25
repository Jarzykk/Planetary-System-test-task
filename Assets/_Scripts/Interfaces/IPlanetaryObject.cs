public interface IPlanetaryObject
{
    public double GetMass();
    public PlanetProperties GetPlanetProperties();
    public void OrbitalMove(float deltaTime);
}