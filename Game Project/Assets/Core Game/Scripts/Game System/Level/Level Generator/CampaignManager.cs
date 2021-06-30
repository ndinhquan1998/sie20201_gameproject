using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ.Campaigns
{
    public class CampaignManager : MonoBehaviour
    {
        public CampaignTemplate campaignTemplate;


        public int maxRooms = 5;
        List<GameObject> createdRooms = new List<GameObject>(); 
        List<RoomHolder> usedRooms = new List<RoomHolder>(); 
        private void Start()
        {
            StartCoroutine(CreateLevel());
        }

        List<RoomSlot> slots = new List<RoomSlot>();

        IEnumerator CreateLevel()
        {
            //Random.InitState(11111);

            yield return CreateRoom(campaignTemplate.module ,Vector3.zero, Quaternion.identity);

            if (slots.Count >0) { 
                while(createdRooms.Count < maxRooms)
                {
                    int ran = Random.Range(0, slots[0].prefabs.Length);
                    if (slots[0].prefabs.Length > 0) {
                    
                    GameObject prefab = slots[0].prefabs[ran];

                    yield return CreateRoom(prefab, slots[0].transform.position, slots[0].transform.rotation);
                    }
                    slots.RemoveAt(0);

                    if (slots.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        RoomHolder GetRandomPrefab(RoomHolder exclude)
        {
            RoomHolder result = null;
            while(result == null || result == exclude)
            {
                int ran = Random.Range(0, campaignTemplate.roomHolders.Length);
                result = campaignTemplate.roomHolders[ran];
            }
            return result;
        }

        IEnumerator CreateRoom (GameObject prefab,Vector3 position, Quaternion rotation)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = position;
            go.transform.rotation = rotation;

            createdRooms.Add(go);

            if (createdRooms.Count >= maxRooms)
                yield return null;

            RoomSlot[] ss = go.GetComponentsInChildren<RoomSlot>();
            slots.AddRange(ss);

        }
    }

    

}