using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Model;
using UnityEngine;

namespace events
{
    public class PlayerKillEnemy : Simulation.Event<PlayerKillEnemy>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public float damage;


        public override void Execute()
        {
            var player = model.player;
            Debug.Log("damage is : " + damage);

            // var player = model.player;
            // if (player.health.IsAlive)
            // {
            //     player.health.Die();
            //     // model.virtualCamera.Follow = null;
            //     // model.virtualCamera.m_LookAt = null;
            //     // player.collider.enabled = false;
            //     player.controlEnabled = false;
            //
            //     if (player.audioSource && player.ouchAudio)
            //         player.audioSource.PlayOneShot(player.ouchAudio);
            //     player.animator.SetTrigger("hurt");
            //     player.animator.SetBool("dead", true);
            //     Simulation.Schedule<PlayerSpawn>(2);
            // }
        }
    }
}