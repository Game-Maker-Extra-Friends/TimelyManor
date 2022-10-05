using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using Cinemachine;

public class EndSequence : MonoBehaviour
{
    public CinemachineDollyCart cart;
    public CinemachineTrack track; 
	public CinemachineVirtualCamera vcam;

    public void Sequence()
    {

        StarterAssets.FirstPersonController.instance.playerState = StarterAssets.FirstPersonController.PlayerState.EndDemoSequence;
        vcam.Priority = 10;
        cart.m_Position = 0;
        vcam.transform.position = cart.gameObject.transform.position;
        StartCoroutine(EndOfAllThings());
    }


    public float transitionTime = 1f;

    IEnumerator EndOfAllThings()
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("OutroScene");
    }
}
