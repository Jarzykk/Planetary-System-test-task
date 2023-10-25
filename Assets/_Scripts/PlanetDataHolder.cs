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

    public PlanetData GetPlanetDataByMassClass(MassClass massClass)
    {
        switch (massClass)
        {
            case MassClass.Asteroidan:
                return _asteroidanData;
            
            case MassClass.Mercurian:
                return _mercurianData;
            
            case MassClass.Subterran:
                return _subterranData;
            
            case MassClass.Terran:
                return _terranData;
            
            case MassClass.Superterran:
                return _superTerran;
            
            case MassClass.Neptunian:
                return _neptunianData;
            
            case MassClass.Jovian:
                return _jovianData;
        }

        return null;
    }

    public MassClass GetMassClassByMassValue(double mass)
    {
        if (mass >= _asteroidanData.MinMass && mass < _asteroidanData.MaxMass)
            return MassClass.Asteroidan;
        else if (mass >= _mercurianData.MinMass && mass < _mercurianData.MaxMass)
            return MassClass.Mercurian;
        else if (mass >= _subterranData.MinMass && mass < _subterranData.MaxMass)
            return MassClass.Subterran;
        else if (mass >= _terranData.MinMass && mass < _terranData.MaxMass)
            return MassClass.Terran;
        else if (mass >= _superTerran.MinMass && mass < _superTerran.MaxMass)
            return MassClass.Superterran;
        else if (mass >= _neptunianData.MinMass && mass < _neptunianData.MaxMass)
            return MassClass.Neptunian;
        else if (mass >= _jovianData.MinMass)
            return MassClass.Jovian;
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

    public float GetRadiusByMassValue(MassClass massClass, double mass)
    {
        double minMass = GetPlanetDataByMassClass(massClass).MinMass;
        double maxMass = GetPlanetDataByMassClass(massClass).MaxMass;
        float minRadius = GetPlanetDataByMassClass(massClass).MinRadius;
        float maxRadius = GetPlanetDataByMassClass(massClass).MaxRadius;

        double normalizedMass = (mass - minMass) / (maxMass - minMass);
        double targetRadius = minRadius + normalizedMass * (maxRadius - minRadius);
        return (float)targetRadius;
    }
}