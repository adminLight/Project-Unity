using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


[ExecuteInEditMode]
public class PixelateCam : MonoBehaviour
{
    [Range(1,100)] public int pixelate;

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
