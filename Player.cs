using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
  [SerializeField]  private uint moveSpeed;
  float hAxis;
  float vAxis;

  bool shouldMove = false;
  Vector3 moveVec;
 
  Animator anim;

  Vector3 clickPoint;
  private void Awake() {
    anim = GetComponent<Animator>();
    moveSpeed = 5;
  }

  void Start()
  {
    
    
    
  }
  private void Update() 
  {

    // KeyCodeMove_3();
    MaouseMove_1();
    ani_Move(shouldMove);
  }

    void KeyCodeMove_3()
    {
      
      hAxis = Input.GetAxisRaw("Horizontal");
      vAxis = Input.GetAxisRaw("Vertical");
                                            //normalized 어떤방향이든 값을 1로 고정
      moveVec = new Vector3(hAxis,0,vAxis).normalized;
      
      transform.position += moveVec * Time.deltaTime * moveSpeed;

      transform.LookAt(transform.position + moveVec);
    }

    void MaouseMove_1()
    {
      
      
      

      if(Input.GetMouseButton(1))
      {

        //method
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;        
        if(Physics.Raycast(ray,out hit,100f))//100; 마지막 실수값은 레이가 도달하는 최대거리
        {
          clickPoint = new Vector3(hit.point.x,transform.position.y,hit.point.z);  
          shouldMove = true;
          transform.LookAt(clickPoint);
          transform.position = Vector3.MoveTowards(transform.position,clickPoint,moveSpeed *Time.deltaTime);
          shouldMove = true;
        } 
      }
      else
      {
        shouldMove = false;
      }

        
    }

    void ani_Move(bool _isMove)
    {
      anim.SetBool("isRun",_isMove);

    }
    void MouseMove_2()
    {
      if(Input.GetMouseButton(0))
      {
        Vector3 clickPos = Vector3.one;
        clickPos  = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,1f,0 ));

        //check
        Debug.Log(clickPos);
        
        gameObject.transform.position = clickPos * moveSpeed * Time.deltaTime;
      }
    }
}
