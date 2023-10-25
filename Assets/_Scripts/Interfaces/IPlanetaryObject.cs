public interface IPlanetaryObject
{
    public double GetMass();
    public MassClass GetMassClass();
    public void OrbitalMove(float deltaTime);
}