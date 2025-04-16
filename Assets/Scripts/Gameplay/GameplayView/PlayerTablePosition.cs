using System;
using UnityEngine;


public class PlayerTablePosition : MonoBehaviour
{
    [SerializeField] private int m_TablePositionIndex;
    [SerializeField] private PlayerTablePositionView m_PositionView;
    
    [SerializeField] private Transform m_TopPointTransform;

    public int TablePositionIndex => m_TablePositionIndex;

    public void ResetPosition()
    {
        m_PositionView.SetPositionEnabled(false);
    }

    public void SetAvatarIndex(int index)
    {
        GameEvents.GameplayEvents.PlayerPositionInit.Raise(m_TablePositionIndex, m_TopPointTransform.position);
        m_PositionView.SetPositionEnabled(true);
        m_PositionView.SelectCharacterAtIndex(index);
    }
}
