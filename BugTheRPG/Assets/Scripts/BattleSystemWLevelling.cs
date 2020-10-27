using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleStateWL { START, PARTYONESEL, PARTYTWOSEL, PARTYTHREESEL, PARTYFOURSEL, ATTACKTURN, ENEMYTURN, WON, LOST, ESCAPE }
public enum ActionChoiceWL { ATTACKONE, ATTACKTWO, ITEM }
public enum PartySelectWL { PARTYONE, PARTYTWO, PARTYTHREE, PARTYFOUR}

public class BattleSystemWLevelling : MonoBehaviour
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

    UnitWLevelling partyOneUnit;
    UnitWLevelling partyTwoUnit;
    UnitWLevelling partyThreeUnit;
    UnitWLevelling partyFourUnit;
    UnitWLevelling enemyUnit;

    public GameObject dialogueObj;
    public TextMeshProUGUI dialogueText;

    public BattleHUDWLevelling pOneHUD;
    public BattleHUDWLevelling pTwoHUD;
    public BattleHUDWLevelling pThreeHUD;
    public BattleHUDWLevelling pFourHUD;
    public BattleHUDWLevelling enemyHUD;

    private int turnTick;

    public BattleStateWL state;
    public ActionChoiceWL choiceOne;
    public ActionChoiceWL choiceTwo;
    public ActionChoiceWL choiceThree;
    public ActionChoiceWL choiceFour;

    bool oneDead;
    bool twoDead;
    bool threeDead;
    bool fourDead;
    public int deadCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = dialogueObj.GetComponent<TextMeshProUGUI>();
        state = BattleStateWL.START;
        StartCoroutine(BattleInit());
    }

    //Initialises Battle
    IEnumerator BattleInit()
    {
        turnTick = 0;
        GameObject partyOneGO = Instantiate(partyMemOne, partyOnePlatform);
        partyOneUnit = partyOneGO.GetComponent<UnitWLevelling>();
        GameObject partyTwoGO = Instantiate(partyMemTwo, partyTwoPlatform);
        partyTwoUnit = partyTwoGO.GetComponent<UnitWLevelling>();
        GameObject partyThreeGO = Instantiate(partyMemThree, partyThreePlatform);
        partyThreeUnit = partyThreeGO.GetComponent<UnitWLevelling>();
        GameObject partyFourGO = Instantiate(partyMemFour, partyFourPlatform);
        partyFourUnit = partyFourGO.GetComponent<UnitWLevelling>();
        GameObject enemyGO = Instantiate(enemyObj, enemyPlatform);
        enemyUnit = enemyGO.GetComponent<UnitWLevelling>();

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

        state = BattleStateWL.PARTYONESEL;
        PartyPhaseBegin();
    }

    //Starts Action Choices
    void PartyPhaseBegin()
    {
        actionPanel.SetActive(true);
        dialogueText.text = partyOneUnit.unitName + "'s Action";
    }

    //Runs during attack phase if partyMemOne selected basic attack
    IEnumerator PartyOneBasicAtk()
    {
        if(partyOneUnit.unitClass == ClassSelect.TANK)
        {
            
        }
        bool isDead = enemyUnit.TakeRegDamage(partyOneUnit.unitAttack);

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = partyOneUnit.unitName + " attacks for " + partyOneUnit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleStateWL.WON;
            BattleEnd();
        }
        Debug.Log("Unit 1 B-ATK COMP");
    }

    //Runs during attack phase if partyMemOne selected special attack
    IEnumerator PartyOneSpecialAtk()
    {
        bool isDead = enemyUnit.TakeRegDamage(partyOneUnit.unitAttack);

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = partyOneUnit.unitName + " attacks for " + partyOneUnit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleStateWL.WON;
            BattleEnd();
        }
        Debug.Log("Unit 1 S-ATK COMP");
    }
    //Uses item if player selected to use an item
    IEnumerator PartyOneUseItem()
    {
        dialogueText.text = partyOneUnit.unitName + " totally used an Item, I promise! It's not just a placeholder, I swear";
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 1 ITEM COMP");
    }

    //Runs during attack phase if partyMemTwo selected basic attack
    IEnumerator PartyTwoBasicAtk()
    {
        bool isDead = enemyUnit.TakeRegDamage(partyTwoUnit.unitAttack);

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleStateWL.WON;
            BattleEnd();
        }
        Debug.Log("Unit 2 B-ATK COMP");
    }

    //Runs during attack phase if partyMemOne selected special attack
    IEnumerator PartyTwoSpecialAtk()
    {
        bool isDead = enemyUnit.TakeRegDamage(partyTwoUnit.unitAttack);

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleStateWL.WON;
            BattleEnd();
        }
        Debug.Log("Unit 2 S-ATK COMP");
    }

    //Uses item if player selected to use an item
    IEnumerator PartyTwoUseItem()
    {
        dialogueText.text = partyTwoUnit.unitName + " totally used an Item, I promise! It's not just a placeholder, I swear";
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 2 ITEM COMP");
    }

    //Runs during attack phase if partyMemThree selected basic attack
    IEnumerator PartyThreeBasicAtk()
    {
        bool isDead = enemyUnit.TakeRegDamage(partyThreeUnit.unitAttack);

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleStateWL.WON;
            BattleEnd();
        }
        Debug.Log("Unit 3 B-ATK COMP");
    }

    //Runs during attack phase if partyMemThree selected special attack
    IEnumerator PartyThreeSpecialAtk()
    {
        bool isDead = enemyUnit.TakeRegDamage(partyThreeUnit.unitAttack);

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleStateWL.WON;
            BattleEnd();
        }
        Debug.Log("Unit 3 S-ATK COMP");
    }

    //Uses item if player selected to use an item
    IEnumerator PartyThreeUseItem()
    {
        dialogueText.text = partyThreeUnit.unitName + " totally used an Item, I promise! It's not just a placeholder, I swear";
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 3 ITEM COMP");
    }

    //Runs during attack phase if partyMemFour selected basic attack
    IEnumerator PartyFourBasicAtk()
    {
        bool isDead = enemyUnit.TakeRegDamage(partyFourUnit.unitAttack);

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = partyFourUnit.unitName + " attacks for " + partyFourUnit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleStateWL.WON;
            BattleEnd();
        }
        Debug.Log("Unit 4 B-ATK COMP");
    }

    //Runs during attack phase if partyMemFour selected special attack
    IEnumerator PartyFourSpecialAtk()
    {
        bool isDead = enemyUnit.TakeRegDamage(partyFourUnit.unitAttack);

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = partyFourUnit.unitName + " attacks for " + partyFourUnit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleStateWL.WON;
            BattleEnd();
        }
        Debug.Log("Unit 4 S-ATK COMP");
    }

    //Uses item if player selected to use an item
    IEnumerator PartyFourUseItem()
    {
        dialogueText.text = partyFourUnit.unitName + " totally used an Item, I promise! It's not just a placeholder, I swear";
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 4 ITEM COMP");
    }

    //Enemy's Basic Attack Functionality
    IEnumerator EnemyBasic(UnitWLevelling unit, BattleHUDWLevelling hud)
    {
        bool isDead = unit.TakeRegDamage(enemyUnit.unitAttack);

            hud.HPFiddling(unit.unitCurrentHP);
            dialogueText.text = enemyUnit.unitName + " attacks " + unit.unitName + " for " + enemyUnit.unitAttack + "!";
        yield return new WaitForSeconds(2f);

        if (isDead)
            deadCheck += 1;


    }

    //Enemy's Special Attack Functionality
    IEnumerator EnemySpecial(UnitWLevelling unit, BattleHUDWLevelling hud)
    {
        bool isDead = unit.TakeRegDamage(enemyUnit.unitAttack);

        hud.HPFiddling(unit.unitCurrentHP);
        dialogueText.text = enemyUnit.unitName + " attacks " + unit.unitName + " for " + enemyUnit.unitAttack + "!";
        yield return new WaitForSeconds(2f);

        if (isDead)
            deadCheck += 1;


    }

    //Runs through functions for the enemy's attack turn
    IEnumerator EnemyTurn()
    {
        if (turnTick < 4)
        {
            Debug.Log("Enemy Basic Attack");
            AttackTargetingBasic();
        }
        else if (turnTick == 4)
        {
            Debug.Log("Enemy Special Attack");
            AttackTargetingSpecial();
        }


        yield return new WaitForSeconds(2f);

        if (deadCheck == 4)
        {
            state = BattleStateWL.LOST;
            BattleEnd();
        }
        else
        {
            state = BattleStateWL.PARTYONESEL;
            turnTick += 1;
            PartyPhaseBegin();
        }

    }

    //Runs when an attack ends, to check if either side won or lost
    void BattleEnd()
    {
        if (state == BattleStateWL.WON)
        {
            dialogueText.text = "You did a succeed.";
        }
        else if (state == BattleStateWL.LOST)
        {
            dialogueText.text = "You did a succeedn't";
        }
        else if (state == BattleStateWL.ESCAPE)
        {
            dialogueText.text = "You did a scoot-the-boots";
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
        if (state == BattleStateWL.PARTYONESEL)
        {
            choiceOne = ActionChoiceWL.ITEM;
        }
        else if (state == BattleStateWL.PARTYTWOSEL)
        {
            choiceTwo = ActionChoiceWL.ITEM;
        }
        else if (state == BattleStateWL.PARTYTHREESEL)
        {
            choiceThree = ActionChoiceWL.ITEM;
        }
        else if (state == BattleStateWL.PARTYFOURSEL)
        {
            choiceFour = ActionChoiceWL.ITEM;
        }
    }

    //If clicked at any point in the action select phase, battle will end. (probably)
    public void ButtonRunOption()
    {
        state = BattleStateWL.ESCAPE;
        BattleEnd();
    }

    //Dictates what happens on 'Basic Attack' Click
    public void ButtonAttackBasic()
    {
        StartCoroutine(CorouAttackBasic());
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
        if (choiceOne == ActionChoiceWL.ATTACKONE)
        {
            
            StartCoroutine(PartyOneBasicAtk());
        }
        else if (choiceOne == ActionChoiceWL.ATTACKTWO)
        {
            dialogueText.text = partyOneUnit.unitName + " attacks for " + partyOneUnit.unitAttack + "!";
            StartCoroutine(PartyOneSpecialAtk());
        }
        else if (choiceOne == ActionChoiceWL.ITEM)
        {
            dialogueText.text = partyOneUnit.unitName + " uses an item!";
            StartCoroutine(PartyOneUseItem());
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 1 COMP");
        //partyMemTwo Action
        if (choiceTwo == ActionChoiceWL.ATTACKONE)
        {
            dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.unitAttack + "!";
            StartCoroutine(PartyTwoBasicAtk());
        }
        else if (choiceTwo == ActionChoiceWL.ATTACKTWO)
        {
            dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.unitAttack + "!";
            StartCoroutine(PartyTwoSpecialAtk());
        }
        else if (choiceTwo == ActionChoiceWL.ITEM)
        {
            dialogueText.text = partyOneUnit.unitName + " uses an item!";
            StartCoroutine(PartyTwoUseItem());
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 2 COMP");
        //partyMemThree Action
        if (choiceThree == ActionChoiceWL.ATTACKONE)
        {
            dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.unitAttack + "!";
            StartCoroutine(PartyThreeBasicAtk());
        }
        else if (choiceThree == ActionChoiceWL.ATTACKTWO)
        {
            dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.unitAttack + "!";
            StartCoroutine(PartyThreeSpecialAtk());
        }
        else if (choiceThree == ActionChoiceWL.ITEM)
        {
            
            StartCoroutine(PartyThreeUseItem());
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 3 COMP");
        //partyMemFour Action
        if (choiceFour == ActionChoiceWL.ATTACKONE)
        {
            StartCoroutine(PartyFourBasicAtk());
        }
        else if (choiceFour == ActionChoiceWL.ATTACKTWO)
        {
            StartCoroutine(PartyFourSpecialAtk());
        }
        else if (choiceFour == ActionChoiceWL.ITEM)
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
        if (state == BattleStateWL.PARTYONESEL)
        {
            choiceOne = ActionChoiceWL.ATTACKONE;
            state = BattleStateWL.PARTYTWOSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyTwoUnit.unitName + "'s Action";
        }
        else if (state == BattleStateWL.PARTYTWOSEL)
        {
            choiceTwo = ActionChoiceWL.ATTACKONE;
            state = BattleStateWL.PARTYTHREESEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyThreeUnit.unitName + "'s Action";
        }
        else if (state == BattleStateWL.PARTYTHREESEL)
        {
            choiceThree = ActionChoiceWL.ATTACKONE;
            state = BattleStateWL.PARTYFOURSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyFourUnit.unitName + "'s Action";
        }
        else if (state == BattleStateWL.PARTYFOURSEL)
        {
            choiceFour = ActionChoiceWL.ATTACKONE;
            state = BattleStateWL.ATTACKTURN;
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
        if (state == BattleStateWL.PARTYONESEL)
        {
            choiceOne = ActionChoiceWL.ATTACKTWO;
            state = BattleStateWL.PARTYTWOSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyTwoUnit.unitName + "'s Action";
        }
        else if (state == BattleStateWL.PARTYTWOSEL)
        {
            choiceTwo = ActionChoiceWL.ATTACKTWO;
            state = BattleStateWL.PARTYTHREESEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyThreeUnit.unitName + "'s Action";
        }
        else if (state == BattleStateWL.PARTYTHREESEL)
        {
            choiceThree = ActionChoiceWL.ATTACKTWO;
            state = BattleStateWL.PARTYFOURSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyFourUnit.unitName + "'s Action";
        }
        else if (state == BattleStateWL.PARTYFOURSEL)
        {
            choiceFour = ActionChoiceWL.ATTACKTWO;
            state = BattleStateWL.ATTACKTURN;
            yield return new WaitForSeconds(1f);
            actionPanel.SetActive(false);
            attackPanel.SetActive(false);
            dialogueText.text = " ... ";
            StartCoroutine(PlayerCombatTurn());
        }
    }

    //Makes sure satan stops beating corpses
    void AttackTargetingBasic()
    {
        if (deadCheck == 0)
        {
            AttackZeroDead();
        }
        else if (deadCheck == 1)
        {
            AttackOneDead();
        }
        else if (deadCheck == 2)
        {
            AttackTwoDead();
        }
        else if (deadCheck == 3)
        {
            AttackThreeDead();
        }
    }

    //Decides Targeting Based on having everyone alive
    void AttackZeroDead()
    {
        if (partyOneUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
        }
        else if (partyTwoUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
        }
        else if (partyThreeUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
        }
        else if (partyFourUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
        }
    }
    //Decides Targeting Based on one party mem being dead
    void AttackOneDead()
    {
        if (partyOneUnit.dead)
        {
            Debug.Log("Party One is dead");
            if (partyTwoUnit.unitCurrentHP == Mathf.Min(partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
            }
            else if (partyThreeUnit.unitCurrentHP == Mathf.Min(partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
            }
            else if (partyFourUnit.unitCurrentHP == Mathf.Min(partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
            }
        }
        else if (partyTwoUnit.dead)
        {
            Debug.Log("Party Two is dead");
            if (partyOneUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
            }
            else if (partyThreeUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
            }
            else if (partyFourUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
            }
        }
        else if (partyThreeUnit.dead)
        {
            Debug.Log("Party Three is dead");
            if (partyOneUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
            }
            else if (partyTwoUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
            }
            
            else if (partyFourUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
            }
        }
        else if (partyFourUnit.dead)
        {
            Debug.Log("Party Four is dead");
            if (partyOneUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
            }
            else if (partyTwoUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
            }
            else if (partyThreeUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
            }
        }
    }
    //Decides Targeting Based on two party mems being dead
    void AttackTwoDead()
    {
        if (partyThreeUnit.dead && partyFourUnit.dead)
        {
            Debug.Log("Party Three and Four are dead");
            if (partyOneUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
            }
            else if (partyTwoUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
            }
        }
        else if (partyTwoUnit.dead && partyFourUnit.dead)
        {
            Debug.Log("Party Two and Four are dead");
            if (partyOneUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
            }
            else if (partyThreeUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
            }
        }
        else if (partyTwoUnit.dead && partyThreeUnit.dead)
        {
            Debug.Log("Party Two and Three are dead");
            if (partyOneUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
            }
            else if (partyFourUnit.unitCurrentHP == Mathf.Min(partyOneUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
            }
        }
        else if (partyOneUnit.dead && partyFourUnit.dead)
        {
            Debug.Log("Party One and Four are dead");
            if (partyTwoUnit.unitCurrentHP == Mathf.Min(partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
            }
            else if (partyThreeUnit.unitCurrentHP == Mathf.Min(partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
            }
        }
        else if (partyOneUnit.dead && partyThreeUnit.dead)
        {
            Debug.Log("Party One and Three are dead");
            if (partyTwoUnit.unitCurrentHP == Mathf.Min(partyTwoUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
            }
            else if (partyFourUnit.unitCurrentHP == Mathf.Min(partyTwoUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
            }
        }
        else if (partyOneUnit.dead && partyTwoUnit.dead)
        {
            Debug.Log("Party One and Two are dead");
            if (partyThreeUnit.unitCurrentHP == Mathf.Min(partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
            }
            else if (partyFourUnit.unitCurrentHP == Mathf.Min(partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
            {
                StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
            }
        }
    }
    //Decides Targeting Based on three party mems being dead
    void AttackThreeDead()
    {
        if (partyTwoUnit.dead && partyThreeUnit.dead && partyFourUnit.dead)
        {
            Debug.Log("All but Party One are dead");
            StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
        }
        else if (partyOneUnit.dead && partyFourUnit.dead && partyFourUnit.dead)
        {
            Debug.Log("All but Party Two are dead");
            StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
        }
        else if (partyOneUnit.dead && partyTwoUnit.dead && partyFourUnit.dead)
        {
            Debug.Log("All but Party Three are dead");
            StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
        }
        else if (partyOneUnit.dead && partyTwoUnit.dead && partyThreeUnit.dead)
        {
            Debug.Log("All but Party Four are dead");
            StartCoroutine(EnemyBasic(partyFourUnit, pFourHUD));
        }
    }
    
    //Targeting for special attack usage
    void AttackTargetingSpecial()
    {
        if (partyOneUnit.unitCurrentHP == Mathf.Max(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            if (!partyOneUnit.dead)
            {
                Debug.Log("Enemy SPEC-One");
                StartCoroutine(EnemySpecial(partyOneUnit, pOneHUD));
            }
        }
        else if (partyTwoUnit.unitCurrentHP == Mathf.Max(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            if (!partyTwoUnit.dead)
            {
                Debug.Log("Enemy SPEC-Two");
                StartCoroutine(EnemySpecial(partyTwoUnit, pTwoHUD));
            }
        }
        else if (partyThreeUnit.unitCurrentHP == Mathf.Max(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            if (!partyThreeUnit.dead)
            {
                Debug.Log("Enemy SPEC-Three");
                StartCoroutine(EnemySpecial(partyThreeUnit, pThreeHUD));
            }
        }
        else if (partyFourUnit.unitCurrentHP == Mathf.Max(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            if (!partyFourUnit.dead)
            {
                Debug.Log("Enemy SPEC-Four");
                StartCoroutine(EnemySpecial(partyFourUnit, pFourHUD));
            }
        }
    }
}
