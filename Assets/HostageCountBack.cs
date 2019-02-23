using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageCountBack : MonoBehaviour
{
    GameObject[] tagHostage;
    GameObject[] Hostage;




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("tradable") && other.GetComponent<PhotonView>().isMine == true)  // 壁にぶつかったら
            {
            other.gameObject.tag = "Hostage";
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
                    Vector3 temp = new Vector3(-3.5f + 1f * 11 * k / 12, 2.1f);
                    GameObject hostages = (GameObject)PhotonNetwork.Instantiate("hostages", temp, Quaternion.identity, 0);
                }
            }
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
