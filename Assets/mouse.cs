using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : Photon.MonoBehaviour {


    //マウスでドラッグするスクリプト

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Start()
    {
  
    }

    void OnMouseDown()
    {
        
            if (this.GetComponent<PhotonView>().ownerId == PhotonNetwork.player.ID)//追加thisでちゃんと動いた。ownerが同じならば。
            {
                this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                Debug.Log("shori 1 ");
            }
            else
            {
                this.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);//追加thisでちゃんと動いた。所有権の移譲。
            　　this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                Debug.Log("shori 2");
            }
        
    }

    void OnMouseDrag()
    {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
            transform.position = currentPosition;
            Debug.Log("shori 3");
    }
}
