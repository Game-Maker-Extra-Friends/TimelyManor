using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using Cinemachine;

public class EndSequence : MonoBehaviour
{
    public CinemachineDollyCart cart;
	public CinemachineVirtualCamera vcam;

    public Door door;

    public void Sequence()
    {

        StarterAssets.FirstPersonController.instance.playerState = StarterAssets.FirstPersonController.PlayerState.EndDemoSequence;
        vcam.Priority = 10;
        cart.m_Position = 0;
        vcam.transform.position = cart.gameObject.transform.position;
        StartCoroutine(OpenDoor());
        StartCoroutine(EndOfAllThings());
    }

    public float doorTimer = 3f;

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(doorTimer);
        door.Open(this.transform.position);
    }

    public float transitionTime = 1f;

    IEnumerator EndOfAllThings()
    {
        yield return new WaitForSeconds(transitionTime);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("OutroScene");
    }
}
