using UnityEngine;

public class ATypeBuiler : IUnitBuilder
{
    public void BuildUnit(GameObject unit, MapManager constructor)
    {
        unit.AddComponent<MaterialPainter>().Red();
        var motion = unit.AddComponent<Motion>();
        motion.speed = 1;
        motion.types.Clear();
        motion.types.Add(new ForwardMove());
        motion.Start();
        unit.AddComponent<StateMachine>().unitType = StateMachine.UnitTypes.Enemy;
    }
}
