using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum State
    {
        start, platerTurn, enemyTurn, win, loes

    }
    public State state;

    [SerializeField] bool musicButton;
    public bool inLive;

    void Awake() {
        state = State.start;
        
        BattleStart();

    }
    void BGMmusic(bool musicButton)
    {
        if(musicButton)
        {
            
        }
    }



    void BattleStart()
    {
        // 전주 시작시 캐릭터 등장/애니매이션 등 효과 넣기


        // 플래이어나 적에게 턴 넘기기

        state = State.platerTurn;
    }

    public void PlayAttackButton()
    {
        

                //버튼이 계속 눌리는 거 방지하기위함
        if(state != State.platerTurn)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("플레이어 공격");
        // 공격 스킬, 데미지 등 코드작성 

                //적이 죽으면 전투 종료
        if(!inLive)
        {
            state = State.win;
            EndBattle();
        }       //적이 살아있으면 적에게 턴 넘기기
        else
        {
            state = State.enemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }
    public void EndBattle()
    {
        Debug.Log("전투 종류");
        
        
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        //적 공격 코드
                //적 공격이 끝났으면 플레이어에게 턴 넘기기
        state = State.enemyTurn;
    }
    
}
