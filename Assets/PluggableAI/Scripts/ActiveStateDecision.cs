using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PluggableAI/Decision/ActivateState")]
public class ActiveStateDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool ChaseTargetisActive = controller.ChaseTarget.gameObject.activeSelf;
        return ChaseTargetisActive;
    }
}
