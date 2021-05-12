using System.Collections.Generic;


namespace JevLogin
{
    internal interface IAnalyticTools
    {
        void SendMessage(string alias, IDictionary<string, object> eventData = null);
    }
}