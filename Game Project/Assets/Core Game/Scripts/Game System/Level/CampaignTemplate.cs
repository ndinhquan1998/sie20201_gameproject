using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ.Campaigns
{
    [CreateAssetMenu]
    public class CampaignTemplate : ScriptableObject
    {
        public GameObject module;
        public RoomHolder[] roomHolders;
    }

    [System.Serializable]
    public class RoomHolder
    {
        public GameObject prefab;

    }
}
