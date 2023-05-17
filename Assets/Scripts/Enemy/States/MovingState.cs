using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class MovingState : FSMState<EnemyController>
    {
        public MovingState(EnemyController controller) : base(controller)
        {
            Transitions.Add(new FSMTransition<EnemyController>(
                isValid : () => {
                    return Vector3.Distance(
                        mController.transform.position,
                        mController.Player.transform.position
                    ) >= mController.WakeDistance;
                },
                getNextState : () => {
                    return new IdleState(mController);
                }
            ));
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter MovingState");
            mController.spriteRenderer.color = Color.green;
        }

        public override void OnExit()
        {
            Debug.Log("OnExit MovingState");
        }

        public override void OnUpdate(float deltaTime)
        {
            var playerPosition = mController.Player.transform.position;
            var enemyPosition = mController.transform.position;

            var direction = (playerPosition - enemyPosition).normalized;

            mController.rb.MovePosition(
                mController.transform.position + (direction * mController.Speed * deltaTime)
            );
        }
    }
}
