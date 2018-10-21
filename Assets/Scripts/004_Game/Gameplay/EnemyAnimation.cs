using UnityEngine;

namespace MindworksGames.MyGame
{
    public class EnemyAnimation : HumanoidAnimation
    {

        [SerializeField] EnemyMaster _enemyMaster;

        protected override void SetMovementAnimation() { }

        protected override void SetAttackAnimation() { }

    }
}

