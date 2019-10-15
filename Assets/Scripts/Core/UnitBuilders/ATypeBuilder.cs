using UnityEngine;

public class ATypeBuiler : IUnitBuilder
{
    // Builds the red enemy unit which can move only forward.
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
