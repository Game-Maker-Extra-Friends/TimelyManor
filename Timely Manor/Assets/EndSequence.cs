using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class EndSequence : MonoBehaviour
{
    public CinemachineDollyCart cart;
	public CinemachineTrack track;
	public CinemachineVirtualCamera vcam;

    public void Sequence()
    {
        cart.m_Position = 0;
    }
}
