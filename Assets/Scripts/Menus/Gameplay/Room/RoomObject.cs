using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomObject : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    

    public void Initialize(string _DisplayName,string Guid, Action<string> action)
    {
        _text.SetText(_DisplayName);
        _button.onClick.AddListener(()=>action.Invoke(Guid));  
    } 
}
