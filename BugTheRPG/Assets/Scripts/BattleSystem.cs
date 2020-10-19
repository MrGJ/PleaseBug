using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PARTYONESEL, PARTYTWOSEL, PARTYTHREESEL, PARTYFOURSEL, ATTACKTURN, ENEMYTURN, WON, LOST }
public enum ActionChoice { ATTACKONE, ATTACKTWO, ITEM }
public enum PartySelect { PARTYONE, PARTYTWO, PARTYTHREE, PARTYFOUR}

public class BattleSystem : MonoBehaviour
{

    public GameObject partyMemOne;
    public GameObject partyMemTwo;
    public GameObject partyMemThree;
    public GameObject partyMemFour;
    public GameObject enemyObj;
    public GameObject actionPanel;
    public GameObject attackPanel;

    public Transform partyOnePlatform;
    public Transform partyTwoPlatform;
    public Transform partyThreePlatform;
    public Transform partyFourPlatform;
    public Transform enemyPlatform;

    Unit partyOneUnit;
    Unit partyTwoUnit;
    Unit partyThreeUnit;
    Unit partyFourUnit;
    Unit enemyUnit;

    public GameObject dialogueObj;
    public TextMeshProUGUI dialogueText;

    public BattleHUD pOneHUD;
    public BattleHUD pTwoHUD;
    public BattleHUD pThreeHUD;
    public BattleHUD pFourHUD;
    public BattleHUD enemyHUD;

    private int turnTick;

    public BattleState state;
    public ActionChoice choiceOne;
    public ActionChoice choiceTwo;
    public ActionChoice choiceThree;
    public ActionChoice choiceFour;

    int deadCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = dialogueObj.GetComponent<TextMeshProUGUI>();
        state = BattleState.START;
        StartCoroutine(BattleInit());
    }

    //Initialises Battle
    IEnumerator BattleInit()
    {
        GameObject partyOneGO = Instantiate(partyMemOne, partyOnePlatform);
        partyOneUnit = partyOneGO.GetComponent<Unit>();
        GameObject partyTwoGO = Instantiate(partyMemTwo, partyTwoPlatform);
        partyTwoUnit = partyTwoGO.GetComponent<Unit>();
        GameObject partyThreeGO = Instantiate(partyMemThree, partyThreePlatform);
        partyThreeUnit = partyThreeGO.GetComponent<Unit>();
        GameObject partyFourGO = Instantiate(partyMemFour, partyFourPlatform);
        partyFourUnit = partyFourGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyObj, enemyPlatform);
        enemyUnit = enemyGO.GetComponent<Unit>();

        actionPanel.SetActive(false);
        attackPanel.SetActive(false);

        dialogueText = dialogueObj.GetComponent<TextMeshProUGUI>();
        dialogueText.text = "A wild" + enemyUnit.unitName + " is committing Flibbity";

        pOneHUD.HUDFiddling(partyOneUnit);
        pTwoHUD.HUDFiddling(partyTwoUnit);
        pThreeHUD.HUDFiddling(partyThreeUnit);
        pFourHUD.HUDFiddling(partyFourUnit);
        enemyHUD.HUDFiddling(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PARTYONESEL;
        PartyPhaseBegin();
    }

    void PartyPhaseBegin()
    {
        actionPanel.SetActive(true);
        dialogueText.text = partyOneUnit.unitName + "'s Action";
    }

    //Runs during attack phase if partyMemOne selected basic attack
    IEnumerator PartyOneBasicAtk()
    {
        bool isDead = enemyUnit.TakeDamage(partyOneUnit.regDamage);

        enemyHUD.HPFiddling(enemyUnit.currentHP);
        dialogueText.text = partyOneUnit.unitName + " attacks for " + partyOneUnit.regDamage + "!";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
            BattleEnd();
        }
        Debug.Log("Unit 1 B-ATK COMP");
    }

    //Runs during attack phase if partyMemOne selected special attack
    IEnumerator PartyOneSpecialAtk()
    {
        bool isDead = enemyUnit.TakeDamage(partyOneUnit.specDamage);

        enemyHUD.HPFiddling(enemyUnit.currentHP);
        dialogueText.text = partyOneUnit.unitName + " attacks for " + partyOneUnit.specDamage + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            BattleEnd();
        }
        Debug.Log("Unit 1 S-ATK COMP");
    }
    //Uses item if player selected to use an item
    IEnumerator PartyOneUseItem()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 1 ITEM COMP");
    }

    //Runs during attack phase if partyMemTwo selected basic attack
    IEnumerator PartyTwoBasicAtk()
    {
        bool isDead = enemyUnit.TakeDamage(partyTwoUnit.regDamage);

        enemyHUD.HPFiddling(enemyUnit.currentHP);
        dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.regDamage + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            BattleEnd();
        }
        Debug.Log("Unit 2 B-ATK COMP");
    }

    //Runs during attack phase if partyMemOne selected special attack
    IEnumerator PartyTwoSpecialAtk()
    {
        bool isDead = enemyUnit.TakeDamage(partyTwoUnit.specDamage);

        enemyHUD.HPFiddling(enemyUnit.currentHP);
        dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.specDamage + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            BattleEnd();
        }
        Debug.Log("Unit 2 S-ATK COMP");
    }

    //Uses item if player selected to use an item
    IEnumerator PartyTwoUseItem()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 2 ITEM COMP");
    }

    //Runs during attack phase if partyMemThree selected basic attack
    IEnumerator PartyThreeBasicAtk()
    {
        bool isDead = enemyUnit.TakeDamage(partyThreeUnit.regDamage);

        enemyHUD.HPFiddling(enemyUnit.currentHP);
        dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.regDamage + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            BattleEnd();
        }
        Debug.Log("Unit 3 B-ATK COMP");
    }

    //Runs during attack phase if partyMemThree selected special attack
    IEnumerator PartyThreeSpecialAtk()
    {
        bool isDead = enemyUnit.TakeDamage(partyThreeUnit.specDamage);

        enemyHUD.HPFiddling(enemyUnit.currentHP);
        dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.specDamage + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            BattleEnd();
        }
        Debug.Log("Unit 3 S-ATK COMP");
    }

    //Uses item if player selected to use an item
    IEnumerator PartyThreeUseItem()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 3 ITEM COMP");
    }

    //Runs during attack phase if partyMemFour selected basic attack
    IEnumerator PartyFourBasicAtk()
    {
        bool isDead = enemyUnit.TakeDamage(partyFourUnit.regDamage);

        enemyHUD.HPFiddling(enemyUnit.currentHP);
        dialogueText.text = partyFourUnit.unitName + " attacks for " + partyFourUnit.regDamage + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            BattleEnd();
        }
        Debug.Log("Unit 4 B-ATK COMP");
    }

    //Runs during attack phase if partyMemFour selected special attack
    IEnumerator PartyFourSpecialAtk()
    {
        bool isDead = enemyUnit.TakeDamage(partyFourUnit.specDamage);

        enemyHUD.HPFiddling(enemyUnit.currentHP);
        dialogueText.text = partyFourUnit.unitName + " attacks for " + partyFourUnit.specDamage + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            BattleEnd();
        }
        Debug.Log("Unit 4 S-ATK COMP");
    }

    //Uses item if player selected to use an item
    IEnumerator PartyFourUseItem()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 4 ITEM COMP");
    }

    IEnumerator EnemyBasic(Unit unit, BattleHUD hud)
    {
        bool isDead = unit.TakeDamage(enemyUnit.regDamage);

            hud.HPFiddling(unit.currentHP);
            dialogueText.text = enemyUnit.unitName + " attacks " + unit.unitName + " for " + enemyUnit.regDamage + "!";
        yield return new WaitForSeconds(2f);

        if (isDead)
            deadCheck += 1;


    }

    IEnumerator EnemyTurn()
    {
        if (partyOneUnit.currentHP == Mathf.Min(partyOneUnit.currentHP, partyTwoUnit.currentHP, partyThreeUnit.currentHP, partyFourUnit.currentHP))
        {
            StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
        }
        else if (partyTwoUnit.currentHP == Mathf.Min(partyOneUnit.currentHP, partyTwoUnit.currentHP, partyThreeUnit.currentHP, partyFourUnit.currentHP))
        {
            StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
        }
        else if(partyThreeUnit.currentHP == Mathf.Min(partyOneUnit.currentHP, partyTwoUnit.currentHP, partyThreeUnit.currentHP, partyFourUnit.currentHP))
        {
            StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
        }
        else if (partyFourUnit.currentHP == Mathf.Min(partyOneUnit.currentHP, partyTwoUnit.currentHP, partyThreeUnit.currentHP, partyFourUnit.currentHP))
        {
            StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
        }

        yield return new WaitForSeconds(2f);

        if (deadCheck == 4)
        {
            state = BattleState.LOST;
            BattleEnd();
        }
        else
        {
            state = BattleState.PARTYONESEL;
            PartyPhaseBegin();
        }

    }

    //Runs when an attack ends, to check if either side won or lost
    void BattleEnd()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You did a succeed.";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You did a succeedn't";
        }
    }

    //Shows the attack menu to choose an attack for the current party member
    public void ButtonAttackOption()
    {
        actionPanel.SetActive(false);
        attackPanel.SetActive(true);
    }

    //Lets the player select an item for the party member to use
    public void ButtonItemOption()
    {
        if (state == BattleState.PARTYONESEL)
        {
            choiceOne = ActionChoice.ITEM;
        }
        else if (state == BattleState.PARTYTWOSEL)
        {
            choiceTwo = ActionChoice.ITEM;
        }
        else if (state == BattleState.PARTYTHREESEL)
        {
            choiceThree = ActionChoice.ITEM;
        }
        else if (state == BattleState.PARTYFOURSEL)
        {
            choiceFour = ActionChoice.ITEM;
        }
    }

    //If clicked at any point in the action select phase, battle will end. (probably)
    public void ButtonRunOption()
    {

    }

    //Dictates what happens on 'Basic Attack' Click
    public void ButtonAttackBasic()
    {
        StartCoroutine(CorouAttackBasic()); ;
    }

    //Dictates what happens on 'Special Attack' Click
    public void ButtonAttackSpecial()
    {
        StartCoroutine(CorouAttackSpecial());
    }

    //Dictates what happens on 'Attack Back' Click
    public void ButtonAttackBack()
    {
        actionPanel.SetActive(true);
        attackPanel.SetActive(false);
    }

    //Progresses through player's selected actions
    IEnumerator PlayerCombatTurn()
    {
        //partyMemOne Action
        if (choiceOne == ActionChoice.ATTACKONE)
        {
            
            StartCoroutine(PartyOneBasicAtk());
        }
        else if (choiceOne == ActionChoice.ATTACKTWO)
        {
            dialogueText.text = partyOneUnit.unitName + " attacks for " + partyOneUnit.specDamage + "!";
            StartCoroutine(PartyOneSpecialAtk());
        }
        else if (choiceOne == ActionChoice.ITEM)
        {
            dialogueText.text = partyOneUnit.unitName + " uses an item!";
            StartCoroutine(PartyOneUseItem());
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 1 COMP");
        //partyMemTwo Action
        if (choiceTwo == ActionChoice.ATTACKONE)
        {
            dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.regDamage + "!";
            StartCoroutine(PartyTwoBasicAtk());
        }
        else if (choiceTwo == ActionChoice.ATTACKTWO)
        {
            dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.regDamage + "!";
            StartCoroutine(PartyTwoSpecialAtk());
        }
        else if (choiceTwo == ActionChoice.ITEM)
        {
            dialogueText.text = partyOneUnit.unitName + " uses an item!";
            StartCoroutine(PartyTwoUseItem());
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 2 COMP");
        //partyMemThree Action
        if (choiceThree == ActionChoice.ATTACKONE)
        {
            dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.regDamage + "!";
            StartCoroutine(PartyThreeBasicAtk());
        }
        else if (choiceThree == ActionChoice.ATTACKTWO)
        {
            dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.specDamage + "!";
            StartCoroutine(PartyThreeSpecialAtk());
        }
        else if (choiceThree == ActionChoice.ITEM)
        {
            
            StartCoroutine(PartyThreeUseItem());
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 3 COMP");
        //partyMemFour Action
        if (choiceFour == ActionChoice.ATTACKONE)
        {
            StartCoroutine(PartyFourBasicAtk());
        }
        else if (choiceFour == ActionChoice.ATTACKTWO)
        {
            StartCoroutine(PartyFourSpecialAtk());
        }
        else if (choiceFour == ActionChoice.ITEM)
        {
            StartCoroutine(PartyFourUseItem());
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 4 COMP");
        StartCoroutine(EnemyTurn());
    }

    //Fills in action for Basic Button
    IEnumerator CorouAttackBasic()
    {
        if (state == BattleState.PARTYONESEL)
        {
            choiceOne = ActionChoice.ATTACKONE;
            state = BattleState.PARTYTWOSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyTwoUnit.unitName + "'s Action";
        }
        else if (state == BattleState.PARTYTWOSEL)
        {
            choiceTwo = ActionChoice.ATTACKONE;
            state = BattleState.PARTYTHREESEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyThreeUnit.unitName + "'s Action";
        }
        else if (state == BattleState.PARTYTHREESEL)
        {
            choiceThree = ActionChoice.ATTACKONE;
            state = BattleState.PARTYFOURSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyFourUnit.unitName + "'s Action";
        }
        else if (state == BattleState.PARTYFOURSEL)
        {
            choiceFour = ActionChoice.ATTACKONE;
            state = BattleState.ATTACKTURN;
            yield return new WaitForSeconds(1f);
            actionPanel.SetActive(false);
            attackPanel.SetActive(false);
            dialogueText.text = " ... ";
            StartCoroutine(PlayerCombatTurn());
        }
    }

    //Fills in action for Special Button
    IEnumerator CorouAttackSpecial()
    {
        if (state == BattleState.PARTYONESEL)
        {
            choiceOne = ActionChoice.ATTACKTWO;
            state = BattleState.PARTYTWOSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyTwoUnit.unitName + "'s Action";
        }
        else if (state == BattleState.PARTYTWOSEL)
        {
            choiceTwo = ActionChoice.ATTACKTWO;
            state = BattleState.PARTYTHREESEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyThreeUnit.unitName + "'s Action";
        }
        else if (state == BattleState.PARTYTHREESEL)
        {
            choiceThree = ActionChoice.ATTACKTWO;
            state = BattleState.PARTYFOURSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyFourUnit.unitName + "'s Action";
        }
        else if (state == BattleState.PARTYFOURSEL)
        {
            choiceFour = ActionChoice.ATTACKTWO;
            state = BattleState.ATTACKTURN;
            yield return new WaitForSeconds(1f);
            actionPanel.SetActive(false);
            attackPanel.SetActive(false);
            dialogueText.text = " ... ";
            StartCoroutine(PlayerCombatTurn());
        }
    }
}
