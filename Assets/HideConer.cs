using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideConer : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<PhotonView>().ownerId == PhotonNetwork.player.ID)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
