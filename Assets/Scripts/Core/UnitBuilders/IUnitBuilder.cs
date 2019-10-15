using UnityEngine;

// Building interface for different unit types realisation
public interface IUnitBuilder
{ 
    void BuildUnit(GameObject unit, MapManager constructor);
}
