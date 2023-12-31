﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : IPlanetarySystem
{
    private List<IPlanetaryObject> _planetaryObjects = new List<IPlanetaryObject>();
    
    public IEnumerable<IPlanetaryObject> GetPlanetaryObjects()
    {
        return _planetaryObjects;
    }

    public void Update(float deltaTime)
    {
        foreach (var planetaryObject in _planetaryObjects)
        {
            planetaryObject.OrbitalMove(deltaTime);
        }
    }

    public void AddPlanetaryObject(IPlanetaryObject planetaryObjectToAdd)
    {
        foreach (var planetaryObject in _planetaryObjects)
        {
            if (planetaryObject == planetaryObjectToAdd)
                throw new SystemException("You're trying to add planetary object that already added to list");
        }
        
        _planetaryObjects.Add(planetaryObjectToAdd);
    }
}