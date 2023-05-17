using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class AttackingState : FSMState<EnemyController>
    {
        public AttackingState(EnemyController controller) : base(controller)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("OnEnter AttackingState");
        }

        public override void OnExit()
        {
            Debug.Log("OnExit AttackingState");
        }

        public override void OnUpdate(float deltaTime)
        {}
    }
}
