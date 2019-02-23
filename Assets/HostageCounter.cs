using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HostageCounter : MonoBehaviour
{
    GameObject[] tagHostage;
    GameObject[] Hostage;



    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hostage"))  // 壁にぶつかったら
        {
            other.gameObject.tag = "tradable";
            Debug.Log("atattayo");
            tagHostage = GameObject.FindGameObjectsWithTag("Hostage");
            var tagHostageNum = tagHostage.Length;
            if (tagHostageNum != 0)
            {
                Hostage = GameObject.FindGameObjectsWithTag("HostageWindow");
                var HostageNum = Hostage.Length;
                int j;
                for (j = 0; j < HostageNum; j++)
                {
                    PhotonNetwork.Destroy(Hostage[j]);
                }
                int k;
                for (k = 0; k < tagHostageNum; k++)
                {
                    Vector3 temp = new Vector3(-3.5f + 1f * 11*k/12, 2.1f);
                    GameObject hostages = (GameObject)PhotonNetwork.Instantiate("hostages", temp, Quaternion.identity, 0);
                }
            }
        }
    }

        // Update is called once per frame
        void Update()
    {
        

       
            /*
            Transform myTransform = tagHostage.transform;

            Vector3 HostagePosition = tagHostage.position;
            worldPos.x;
            if (tagHostage.transform.y => 2){
                Transform myTransform = this.transform;
            }
            もし、カードが上の方にあって　＆＆　カードにタグが付いていたら
           カウントします　カードの枚数を
           */
        }
}
