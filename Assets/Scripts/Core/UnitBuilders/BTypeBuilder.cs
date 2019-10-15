using UnityEngine;

public class BTypeBuiler : IUnitBuilder
{
    // Builds the yellow enemy unit that works like ATypeBuiler (move only forward)
    // and also can move diagonally
    public void BuildUnit(GameObject unit, MapManager constructor)
    {
        new ATypeBuiler().BuildUnit(unit, constructor);
        unit.GetComponent<MaterialPainter>().Yellow();
        var motion = unit.GetComponent<Motion>();
        motion.types.Add(new DiagonalyMove());
        motion.Start();
    }
}
