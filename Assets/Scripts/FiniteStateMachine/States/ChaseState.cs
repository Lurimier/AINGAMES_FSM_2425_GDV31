using UnityEngine;

public class ChaseState : FSMState
{
    public override StateID StateId => StateID.Chase;

    private Transform[] _waypoints;
    private Transform _currentTarget;
    private Transform _player;
    private EnemyTankController _enemyTankController;

    public ChaseState(EnemyTankController enemyTankController)
    {
        _enemyTankController = enemyTankController;
    }

    public override void CheckTransition(Transform agent, Transform player)
    {
        if (Vector3.Distance(agent.position, player.position) <= (_enemyTankController.ChaseDistance/2))
        {
            _enemyTankController.PerformTransition(TransitionID.ReachPlayer);
        }
    }

    public override void RunState(Transform agent, Transform player)
    {
        if (Vector3.Distance(agent.position, player.position) <= _enemyTankController.ChaseDistance)
        {
            _enemyTankController.MoveToTarget(_player);
        }
    }

    private void SetCurrentTarget(Transform player)
    {
        _currentTarget = player;
    }
}
