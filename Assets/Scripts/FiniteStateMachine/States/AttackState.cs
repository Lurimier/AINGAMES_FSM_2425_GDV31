using UnityEngine;

public class AttackState : FSMState
{
    public override StateID StateId => StateID.Attack;

    private EnemyTankController _enemyTankController;

    public AttackState(EnemyTankController enemyTankController)
    {
        _enemyTankController = enemyTankController;
    }

    public override void CheckTransition(Transform agent, Transform player)
    {
        if (Vector3.Distance(agent.position, player.position) <= (_enemyTankController.ChaseDistance / 2))
        {
            _enemyTankController.PerformTransition(TransitionID.ReachPlayer);
        }
    }

    public override void RunState(Transform agent, Transform player)
    {

    }
}
