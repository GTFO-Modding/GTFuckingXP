using AIGraph;
using Player;
using System;
using UnityEngine;

namespace XpExpansions.Scripts
{
    public class ClientSidedBioTrackerAbility : MonoBehaviour
    {
        private float _nextUpdate = 0f;

        public ClientSidedBioTrackerAbility(IntPtr intPtr) : base(intPtr)
        { }

        public void Update()
        {
            if(Time.time > _nextUpdate)
            {
                if (GameStateManager.IsInExpedition)
                {
                    var player = PlayerManager.GetLocalPlayerAgent();
                    foreach (var enemyAgent in AIG_CourseGraph.GetReachableEnemiesInNodes(PlayerManager.GetLocalPlayerAgent().CourseNode, 1))
                    {
                        ToolSyncManager.WantToTagEnemy(enemyAgent);
                    }
                }

                _nextUpdate = Time.time + 10f;
            }
        }
    }
}
