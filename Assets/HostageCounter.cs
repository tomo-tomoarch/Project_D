using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HostageCounter : MonoBehaviour
{
    GameObject[] tagHostage;
    GameObject[] Hostage;
    int CardKind;


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hostage") && other.GetComponent<PhotonView>().isMine == true)  // 壁にぶつかったら
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
        }else if (other.gameObject.CompareTag("Bag") && other.GetComponent<PhotonView>().isMine == true)
        {
            CardModel cardModel = other.GetComponent<CardModel>(); //ぶつかった相手のCardModel.csにアクセス
            CardKind = cardModel.cardIndex;
            PhotonNetwork.Destroy(other.gameObject);
            if (CardKind == 0 || CardKind == 1 || CardKind == 2 || CardKind == 3)
            {
                Vector3 temp = new Vector3(-5.4f + 1f * 13 * CardKind / 12, -2.06f);
                GameObject dummy = (GameObject)PhotonNetwork.Instantiate("used", temp, Quaternion.identity, 0);

                Vector3 temp2 = new Vector3(-4.3f + 1f * 13 * CardKind / 12, 4.14f);
                GameObject dummy2 = (GameObject)PhotonNetwork.Instantiate("dummy", temp2, Quaternion.identity, 0);

            }
            else if (CardKind == 4 || CardKind == 5 || CardKind == 6 || CardKind == 7)
            {
                Vector3 temp = new Vector3(-5.4f + 1f * 13 * CardKind / 12, -2.06f);
                GameObject money = (GameObject)PhotonNetwork.Instantiate("used", temp, Quaternion.identity, 0);

                Vector3 temp2 = new Vector3(-4.3f + 1f * 13 * CardKind / 12, 4.14f);
                GameObject money2 = (GameObject)PhotonNetwork.Instantiate("money", temp2, Quaternion.identity, 0);
            }
            else if (CardKind == 8 || CardKind == 9)
            {
                Vector3 temp = new Vector3(-5.4f + 1f * 13 * CardKind / 12, -2.06f);
                GameObject parashute = (GameObject)PhotonNetwork.Instantiate("used", temp, Quaternion.identity, 0);

                Vector3 temp2 = new Vector3(-4.3f + 1f * 13 * CardKind / 12, 4.14f);
                GameObject parashute2 = (GameObject)PhotonNetwork.Instantiate("parashute", temp2, Quaternion.identity, 0);
            }
            else if (CardKind == 10 || CardKind == 11)
            {
                Vector3 temp = new Vector3(-5.4f + 1f * 13 * (CardKind - 12) / 12, -2.06f);
                GameObject gun = (GameObject)PhotonNetwork.Instantiate("used", temp, Quaternion.identity, 0);

            }
            else if (CardKind == 12 || CardKind == 13)
            {
                Vector3 temp = new Vector3(-5.4f + 1f * 13 * (CardKind-2) / 12, -2.06f);
                GameObject Fparashute = (GameObject)PhotonNetwork.Instantiate("used", temp, Quaternion.identity, 0);

                Vector3 temp2 = new Vector3(-4.3f + 1f * 13 * (CardKind-2) / 12, 4.14f);
                GameObject fparashute2 = (GameObject)PhotonNetwork.Instantiate("fparashute", temp2, Quaternion.identity, 0);

            }
            else
            {
                Vector3 temp = new Vector3(-5.4f + 1f * 13 * (CardKind - 2) / 12, -2.06f);
                GameObject fgun = (GameObject)PhotonNetwork.Instantiate("used", temp, Quaternion.identity, 0);

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
