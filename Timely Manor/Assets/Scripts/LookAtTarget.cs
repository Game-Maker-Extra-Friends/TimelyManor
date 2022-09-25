using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    private Transform player;
    public bool threeAxis;
    public bool oneAxis;

    public float damping = 1;


    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.Find("PlayerCapsule").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // this script starts before the don't destroy prefab instantiate so finding the playercapsule needs to be in update
        if(player == null)
        {
            player = GameObject.Find("PlayerCapsule").transform;
        }

        if (threeAxis)
        {
            transform.LookAt(player);
        }
        if (oneAxis)
        {
            var lookPos = player.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(-lookPos); // The sprite is flippe so -pos
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

            
        }
    }
}
