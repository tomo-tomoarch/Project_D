using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    //ここまではデフォルトのまま変える必要なし。

    SpriteRenderer spriteRenderer;
    // SpriteRendererクラスを参照します。①（Cardmodelクラスが直接アタッチされているオブジェクトのクラスを参照void awakeの所とセット）

    public Sprite[] faces;　　// 外部から参照できる（インスペクターからいじれる）facesという表面のリストの宣言。
    public Sprite cardBack;
    public Sprite cardBack2;// 外部から参照できる（インスペクターからいじれる）cardBackという裏面の宣言。

    public int cardIndex;　// 外部から参照できるcardIndex という値の宣言。

    public void ToggleFace(bool showFace)　//外部アクセス可能なToggleFaceというメソッドの定義　引数に真偽値としてshowFaceを取る。
    {

        if (showFace)　// もし showface がtrueであれば、
        {
            spriteRenderer.sprite = faces[cardIndex];  //②で取得したspriteにfaces[与えられたインデックス値]をレンダーさせる。
        }
        else
        {
            if(cardIndex == 8 || cardIndex == 9 || cardIndex == 12 || cardIndex == 13 || cardIndex == 14)
            {
                spriteRenderer.sprite = cardBack2;
            }
            else
            {
                spriteRenderer.sprite = cardBack;　　//②で取得したspriteにcardbackをレンダーさせる。
            }
           
        }
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //このスクリプトがアタッチされているオブジェクトのインスペクター上のspriteRendererを取得します。①とセット。②
    }
}
