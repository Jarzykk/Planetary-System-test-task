using System;
using System.Collections.Generic;
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
    
    private List<PlanetData> _planetDataGroup = new List<PlanetData>();
    
    public static PlanetDataHolder Instance { get; private set; }

    private void Awake()
    {
        SetSingleton();
        FormPlanetDataGroup();
    }

    private void SetSingleton()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public PlanetData GetPlanetDataByType(PlanetType planetType)
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

    public PlanetType GetPlanetTypeByMass(double mass)
    {
        if (mass >= _asteroidanData.MinMass && mass < _asteroidanData.MaxMass)
            return PlanetType.Asteroidan;
        else if (mass >= _mercurianData.MinMass && mass < _mercurianData.MaxMass)
            return PlanetType.Mercurian;
        else if (mass >= _subterranData.MinMass && mass < _subterranData.MaxMass)
            return PlanetType.Subterran;
        else if (mass >= _terranData.MinMass && mass < _terranData.MaxMass)
            return PlanetType.Terran;
        else if (mass >= _superTerran.MinMass && mass < _superTerran.MaxMass)
            return PlanetType.Superterran;
        else if (mass >= _neptunianData.MinMass && mass < _neptunianData.MaxMass)
            return PlanetType.Neptunian;
        else if (mass >= _jovianData.MinMass)
            return PlanetType.Jovian;
        else
            throw new SystemException("Can't get planet type by provided mass");
    }

    private void FormPlanetDataGroup()
    {
        _planetDataGroup.Add(_asteroidanData);
        _planetDataGroup.Add(_mercurianData);
        _planetDataGroup.Add(_subterranData);
        _planetDataGroup.Add(_terranData);
        _planetDataGroup.Add(_superTerran);
        _planetDataGroup.Add(_neptunianData);
        _planetDataGroup.Add(_jovianData);
    }

    public double GetMinAvailableMass()
    {
        double result = 0;

        foreach (var planetData in _planetDataGroup)
        {
            if (result > planetData.MinMass && planetData.MinMass > 0 || result == 0)
                result = planetData.MinMass;
        }

        return result;
    }

    public float GetRadiusByMass(PlanetType planetType, double mass)
    {
        double minMass = GetPlanetDataByType(planetType).MinMass;
        double maxMass = GetPlanetDataByType(planetType).MaxMass;
        float minRadius = GetPlanetDataByType(planetType).MinRadius;
        float maxRadius = GetPlanetDataByType(planetType).MaxRadius;

        double normalizedMass = (mass - minMass) / (maxMass - minMass);
        double targetRadius = minRadius + normalizedMass * (maxRadius - minRadius);
        return (float)targetRadius;
    }
}