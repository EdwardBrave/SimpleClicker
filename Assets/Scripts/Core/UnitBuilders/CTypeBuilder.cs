using UnityEngine;

public class CTypeBuiler : IUnitBuilder
{
    //Builds the green FRIENDLY unit that works like CTypeBuiler (can move forward and/or diagonally)
    public void BuildUnit(GameObject unit, MapManager constructor)
    {
        new BTypeBuiler().BuildUnit(unit, constructor);
        unit.GetComponent<MaterialPainter>().Green();
        unit.GetComponent<StateMachine>().unitType = StateMachine.UnitTypes.Friendly;
    }
}
