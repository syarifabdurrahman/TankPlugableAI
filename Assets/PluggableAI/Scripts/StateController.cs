using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;
using UnityEngine.SceneManagement;

public class StateController : MonoBehaviour {

    
	public EnemyStats enemyStats;
	public Transform eyes;
    public State CurrentState;
    public State RemainState;

	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public Complete.TankShooting tankShooting;
	[HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform ChaseTarget;
    [HideInInspector] public float stateTimelapsed;

	private bool aiActive;


	void Awake () 
	{
		tankShooting = GetComponent<Complete.TankShooting> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
	{
		wayPointList = wayPointsFromTankManager;
		aiActive = aiActivationFromTankManager;
		if (aiActive) 
		{
			navMeshAgent.enabled = true;
		} else 
		{
			navMeshAgent.enabled = false;
		}
	}

    void Update()
    {
        if (!aiActive)
        {
            return;
        }
        CurrentState.updateState(this);
    }

    void OnDrawGizmos()
    {
        if (CurrentState != null && eyes != null)
        {
            Gizmos.color = CurrentState.sceneGizmosColor;
            Gizmos.DrawSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void TransitionTrueState(State nextState)
    {
        if (nextState != RemainState)
        {
            CurrentState = nextState;
            onExitstate();
        }
    }

    public bool CheckifCountDownElapsed(float duration)
    {
        stateTimelapsed += Time.deltaTime;
        return (stateTimelapsed >= duration);
    }

    private void onExitstate()
    {
        stateTimelapsed = 0;
    }
}