using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClick : Photon.MonoBehaviour, IPointerClickHandler
{
    CardModel cardmodel;
    public int clickNum = 0; //外部参照用のクリック数の宣言
    private int i = 0;

    void Awake()
    {
        cardmodel = GetComponent<CardModel>();
    }

   public void OnPointerClick(PointerEventData eventData)
   {
        if (photonView.isMine)
        {
            if (eventData.clickCount > 1)
            {
                i++;
                if(i % 2 == 1)
                {
                    Debug.Log(eventData.clickCount);
                    clickNum = i; //外部参照用のクリック数（PlayerNetwrokMoverで取得する）
                    cardmodel.ToggleFace(true);
                    GetComponent<MouseOver>().enabled = false;
                }
                else
                {
                    Debug.Log(eventData.clickCount);
                    clickNum = i; //外部参照用のクリック数（PlayerNetwrokMoverで取得する）
                    cardmodel.ToggleFace(false);
                    GetComponent<MouseOver>().enabled = true;
                }
                              
            }
        }
    }
}