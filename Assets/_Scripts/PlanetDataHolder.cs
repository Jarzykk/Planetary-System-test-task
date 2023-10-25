using UnityEngine;

public class PlanetDataHolder : MonoBehaviour
{
    [SerializeField] private PlanetData _asteroidanData;
    [SerializeField] private PlanetData _mercurianData;
    [SerializeField] private PlanetData _subterranData;
    [SerializeField] private PlanetData _terranData;
    [SerializeField] private PlanetData _superTerran;
    [SerializeField] private PlanetData _neptunianData;
    [SerializeField] private PlanetData _jovianData;
    
    public PlanetData GetPlanetData(PlanetType planetType)
    {
        switch (planetType)
        {
            case PlanetType.Asteroidan:
                return _asteroidanData;
            
            case PlanetType.Mercurian:
                return _mercurianData;
            
            case PlanetType.Subterran:
                return _subterranData;
            
            case PlanetType.Terran:
                return _terranData;
            
            case PlanetType.Superterran:
                return _superTerran;
            
            case PlanetType.Neptunian:
                return _neptunianData;
            
            case PlanetType.Jovian:
                return _jovianData;
        }

        return null;
    }
}