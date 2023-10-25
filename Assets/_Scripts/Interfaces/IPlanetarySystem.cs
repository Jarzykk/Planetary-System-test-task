using System.Collections.Generic;

public interface IPlanetarySystem
{
    public IEnumerable<IPlanetaryObject> GetPlanetaryObjects();
    public void Update(float deltaTime);
}