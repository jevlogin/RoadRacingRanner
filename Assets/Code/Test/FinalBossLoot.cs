using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


namespace JevLogin
{
    internal sealed class FinalBossLoot : MonoBehaviour
    {
        public string BattleMVP = "Holtzman";
        public int MvpLevel = 34;
        public float BattleDurationInMinutes = 43.05f;


        private void Start()
        {
            Analytics.CustomEvent("final_boss_defeated");
            Analytics.CustomEvent("battle_mvp_selected", new Dictionary<string, object>
            {
                {"battle_mvp", BattleMVP },
                {"mvp_level", MvpLevel },
                {"battle_time", BattleDurationInMinutes }
            });
        }
    }
}