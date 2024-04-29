using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


[ExecuteInEditMode]
public class PixelateCam : MonoBehaviour
{
    [Range(1,100)] public int pixelate;
    [SerializeField] GameObject player; //카메라가 따라갈 플레이어
    [SerializeField] Vector3 PlayerDistance;

    private void Awake() {
        //카메라와 플레이거 거리 초기화
        PlayerDistance = new Vector3(0,26,-50); 

    }
    private void Update() {
        
        transform.position = player.transform.position + PlayerDistance;
    }

    //픽셀 렌더러
    private void OnRenderImage(RenderTexture src, RenderTexture dest) 
    {
        src.filterMode = FilterMode.Point;
        RenderTexture resultTextuer = RenderTexture.GetTemporary(src.width / pixelate, src.height / pixelate,0,src.format);
        resultTextuer.filterMode = FilterMode.Point;
        Graphics.Blit(src,resultTextuer);
        Graphics.Blit(resultTextuer, dest);
        RenderTexture.ReleaseTemporary(resultTextuer);
    }

}
