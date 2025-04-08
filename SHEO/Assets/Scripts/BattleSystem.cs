using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;



public enum BattleState
{
    START, PLAYERTURN, ENEMYTURN, WON, LOST
}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    private Unit playerUnit;
    private Unit enemyUnit;

    public TextMeshProUGUI dialogueText;

    public BattleHudScript playerHUD;
    public BattleHudScript enemyHUD;
    
    public BattleState state;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
        StartCoroutine(SetUpBattle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetUpBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";
        
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(1f);
        
        state = BattleState.PLAYERTURN;
        PlayerTurn();



    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful";
        
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        yield return new WaitForSeconds(1f);
        
    }

    IEnumerator PlayerRecruit()
    {
        if (enemyUnit.currentHP <= (enemyUnit.maxHP / 2))
        {
            dialogueText.text = "You used your coorperate skills to sucessfully recruit.";
            yield return new WaitForSeconds(2f);
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            dialogueText.text = "You fail your recruitment.";
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        yield return new WaitForSeconds(1f);
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            //this can move onto the next battle
            dialogueText.text = "You win!";
        }
        else
        {
            //this can restart battle
            state = BattleState.LOST;
            dialogueText.text = "You lose!";
        }

    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        else
        {
            StartCoroutine(PlayerAttack());
        }

        
    }
    
    public void OnRecruitButton()
        {
            if (state != BattleState.PLAYERTURN)
            {
                return;
            }
            else
            {
                StartCoroutine(PlayerRecruit());
            }
        }
    
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        else
        {
            StartCoroutine(PlayerHeal());
        }
    }

    IEnumerator PlayerHeal()
    {
        
        playerUnit.Heal(10);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You healed!";
        
        
        state = BattleState.ENEMYTURN;
        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemyTurn());
    }
}
