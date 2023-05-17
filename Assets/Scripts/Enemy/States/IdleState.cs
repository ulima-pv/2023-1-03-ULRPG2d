using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class IdleState : FSMState<EnemyController>
    {
        public IdleState(EnemyController controller) : base(controller)
        {
            // Transiciones
            Transitions.Add(new FSMTransition<EnemyController>(
                isValid : () => {
                    return Vector3.Distance(
                        mController.transform.position,
                        mController.Player.transform.position
                    ) < mController.WakeDistance;
                },
                getNextState : () => {
                    return new MovingState(mController);
                }
            ));
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter IdleState");
            mController.spriteRenderer.color = Color.blue;
        }

        public override void OnExit()
        {
            Debug.Log("OnExit IdleState");
        }

        public override void OnUpdate(float deltaTime)
        {}
    }
    
}
