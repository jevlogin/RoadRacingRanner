﻿using System.Collections.Generic;
using UnityEngine.Analytics;


namespace JevLogin
{
    internal sealed class UnityAnalyticTools : IAnalyticTools
    {
        #region IAnalyticTools

        public void SendMessage(string alias, IDictionary<string, object> eventData)
        {
            if (eventData == null)
            {
                eventData = new Dictionary<string, object>();
            }
            Analytics.CustomEvent(alias, eventData);
        }

        #endregion
    }
}