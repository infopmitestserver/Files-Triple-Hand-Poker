using System.Collections.Generic;
using UnityEngine;

public class RoomSelection : UIMenuBase
{
    [SerializeField] private RoomObject roomPrefab;
    [SerializeField] private Transform roomTParent;

    private List<RoomObject> instantiatedObj = new();
    private void Awake()
    {
        GameEvents.MenuEvents.RoomsListUpdated.Register(OnRoomsUpdated);
    }
    private void OnDestroy()
    {
        GameEvents.MenuEvents.RoomsListUpdated.UnRegister(OnRoomsUpdated);
    }

    private void OnRoomsUpdated(List<string> obj)
    {
        foreach(var v in instantiatedObj)
            Destroy(v.gameObject);
        
        instantiatedObj.Clear();

        for (int i = 0; i < obj.Count; i++)
        {
            RoomObject room = Instantiate(roomPrefab.gameObject,roomTParent).GetComponent<RoomObject>();
            
            room.Initialize($"GameRoom-{i + 1}", obj[i], OnRoomButtonClicked);
            instantiatedObj.Add(room);
        }
    }

    private void OnRoomButtonClicked(string name)
    {
        GameEvents.MenuEvents.RoomJoinRequested.Raise(name);
        
        foreach(var v in instantiatedObj)
            Destroy(v.gameObject);
        
        instantiatedObj.Clear();
        
        GameEvents.MenuEvents.MenuTransitionEvent.Raise(MenuName.ConnectionScreen);
    }

    
}