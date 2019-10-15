using UnityEngine;

public class CTypeBuiler : IUnitBuilder
{
    public void BuildUnit(GameObject unit, MapManager constructor)
    {
        new BTypeBuiler().BuildUnit(unit, constructor);
        unit.GetComponent<MaterialPainter>().Green();
        unit.AddComponent<StateMachine>().unitType = StateMachine.UnitTypes.Friendly;
    }
}
