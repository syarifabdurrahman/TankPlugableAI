using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PluggableAI/State")]
public class State : ScriptableObject
{

    public Action[] actions;
    public Transition[] transitions;
    public Color sceneGizmosColor = Color.grey;

    public void updateState(StateController controller)
    {
        DoAction(controller);
        CheckTransition(controller);
    }

    private void DoAction(StateController controller)
    {

    for(int i =0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransition(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSuccseded = transitions[i].decision.Decide(controller);

            if (decisionSuccseded)
            {
                controller.TransitionTrueState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionTrueState(transitions[i].falseState);
            }
        }

    }

}
