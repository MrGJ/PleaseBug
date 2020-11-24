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
    public GameObject partyMemOne, partyMemTwo, partyMemThree, partyMemFour, enemyObj;

    public GameObject actionPanel, attackPanel;
    public GameObject basicActionPan, specialActionPan, backActionPan;
    public GameObject attackPanelAction, itemPanel, runPanel;

    public Transform partyOnePlatform, partyTwoPlatform, partyThreePlatform, partyFourPlatform, enemyPlatform;

    public UnitWLevelling partyOneUnit, partyTwoUnit, partyThreeUnit, partyFourUnit, enemyUnit;

    public GameObject dialogueObj;
    public TextMeshProUGUI dialogueText;

    public BattleHUDWLevelling pOneHUD, pTwoHUD, pThreeHUD, pFourHUD, enemyHUD;

    public GameObject encounterObj;
    public EncounterTwisting encounter;

    public Tutscript tutorialScript;

    private int turnTick;

    public BattleStateWL state;
    public ActionChoiceWL choiceOne, choiceTwo, choiceThree, choiceFour;

    public int deadCheck = 0;
    public int buttonCheck = 0;
    public bool inBattle;


    // Start is called before the first frame update
    void Start()
    {
        inBattle = false;
        dialogueText = dialogueObj.GetComponent<TextMeshProUGUI>();
        encounter = encounterObj.GetComponent<EncounterTwisting>();

        //state = BattleStateWL.START;
        //StartCoroutine(BattleInit());
    }

    //Initialises Battle
    public IEnumerator BattleInit()
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
        dialogueText.text = "A wild " + enemyUnit.unitName + " is committing Flibbity";

        pOneHUD.HUDFiddling(partyOneUnit);
        pTwoHUD.HUDFiddling(partyTwoUnit);
        pThreeHUD.HUDFiddling(partyThreeUnit);
        pFourHUD.HUDFiddling(partyFourUnit);
        enemyHUD.HUDFiddling(enemyUnit);

        if (tutorialScript.battleTutEnd == false)
        {
            yield return new WaitForSeconds(2f);
            state = BattleStateWL.PARTYONESEL;
            PartyPhaseBegin();
            StartCoroutine(tutorialScript.TutBattle());
            
        }
        else if (tutorialScript.battleTutEnd == true)
        {
            yield return new WaitForSeconds(2f);
            state = BattleStateWL.PARTYONESEL;
            PartyPhaseBegin();
            Debug.Log("PartyPhaseBegun");
        }
    }

    //Starts Action Choices
    public void PartyPhaseBegin()
    {
        if (tutorialScript.battleTutEnd == false)
        {
            StartCoroutine(TutorialBattle());
        }
        else
        {
            actionPanel.SetActive(true);
        }
        dialogueText.text = partyOneUnit.unitName + "'s Action";
    }

    IEnumerator TutorialBattle()
    {
        yield return StartCoroutine(BattlePrompt(tutorialScript.battlePrompt1));
        actionPanel.SetActive(true);
        itemPanel.SetActive(false);
        runPanel.SetActive(false);
    }

    IEnumerator BattlePrompt(bool prompt)
    {
        while (prompt == false)
            yield return null;
    }

    //Runs during attack phase if passed unit selected basic attack
    IEnumerator PartyBasicAtk(UnitWLevelling unit)
    {
        bool isDead = false;
        if (!unit.unitIsMagic)
        {
            isDead = enemyUnit.TakeRegDamage(unit, false);

        }
        else if (unit.unitIsMagic)
        {
            isDead = enemyUnit.TakeMagDamage(unit, false);
        }
        
        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = unit.unitName + " attacks for " + unit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleStateWL.WON;
            StartCoroutine(BattleEnd());
        }
        Debug.Log(unit.unitName + " B-ATK COMP");
    }

    //Runs during attack phase if passed unit selected special attack
    IEnumerator PartySpecialAtk(UnitWLevelling unit)
    {
        bool isDead = false;
        if (!unit.unitIsMagic)
        {
            isDead = enemyUnit.TakeRegDamage(unit, true);
        }
        else if (unit.unitIsMagic)
        {
            isDead = enemyUnit.TakeMagDamage(unit, true);
        }

        enemyHUD.HPFiddling(enemyUnit.unitCurrentHP);
        dialogueText.text = unit.unitName + " attacks super hard for " + unit.unitAttack + "!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleStateWL.WON;
            StartCoroutine(BattleEnd());
        }
        Debug.Log(unit.unitName + " S-ATK COMP");
    }
    //Uses item if passed unit selected to use an item
    IEnumerator PartyUseItem(UnitWLevelling unit)
    {
        dialogueText.text = unit.unitName + " totally used an Item, I promise! It's not just a placeholder, I swear";
        yield return new WaitForSeconds(2f);
        Debug.Log(unit.unitName + " used an item");
    }

    //Enemy's Basic Attack Functionality
    IEnumerator EnemyBasic(UnitWLevelling unit, BattleHUDWLevelling hud)
    {
        bool isDead = false;
        if (!enemyUnit.unitIsMagic)
        {
            isDead = unit.TakeRegDamage(enemyUnit, false);
        }
        else if (enemyUnit.unitIsMagic)
        {
            isDead = unit.TakeMagDamage(enemyUnit, false);
        }
        hud.HPFiddling(unit.unitCurrentHP);
            dialogueText.text = enemyUnit.unitName + " attacks " + unit.unitName + " for " + enemyUnit.unitAttack + "!";
        yield return new WaitForSeconds(2f);

        if (isDead)
            deadCheck += 1;
    }

    //Enemy's Special Attack Functionality
    IEnumerator EnemySpecial(UnitWLevelling unit, BattleHUDWLevelling hud)
    {
        bool isDead = false;
        if (!enemyUnit.unitIsMagic)
        {
            isDead = unit.TakeRegDamage(enemyUnit, true);
        }
        else if (enemyUnit.unitIsMagic)
        {
            isDead = unit.TakeMagDamage(enemyUnit, true);
        }
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
            StartCoroutine(BattleEnd());
        }
        else
        {
            if (state != BattleStateWL.LOST || state != BattleStateWL.WON || state != BattleStateWL.ESCAPE)
            {
                state = BattleStateWL.PARTYONESEL;
                turnTick += 1;
                PartyPhaseBegin();
            }
            
        }

    }

    //Runs when an attack ends, to check if either side won or lost
    IEnumerator BattleEnd()
    {
        if (state == BattleStateWL.WON)
        {
            
            dialogueText.text = "You did a succeed.";
            
            partyOneUnit.unitExp += enemyUnit.unitExpGainedOnDeath;
            partyTwoUnit.unitExp += enemyUnit.unitExpGainedOnDeath;
            partyThreeUnit.unitExp += enemyUnit.unitExpGainedOnDeath;
            partyFourUnit.unitExp += enemyUnit.unitExpGainedOnDeath;
            yield return new WaitForSeconds(1f);
            partyOneUnit.UnitLevelling();
            partyTwoUnit.UnitLevelling();
            partyThreeUnit.UnitLevelling();
            partyFourUnit.UnitLevelling();
            yield return new WaitForSeconds(1f);
            encounter.EncounterEnd();
        }
        else if (state == BattleStateWL.LOST)
        {
            dialogueText.text = "You did a succeedn't";
            yield return new WaitForSeconds(1f);
            encounter.EncounterEnd();
        }
        else if (state == BattleStateWL.ESCAPE)
        {
            dialogueText.text = "You did a scoot-the-boots";
            yield return new WaitForSeconds(1f);
            encounter.EncounterEnd();
        }
        turnTick = 0;
    }

    //Shows the attack menu to choose an attack for the current party member
    public void ButtonAttackOption()
    {
        if (tutorialScript.battleTutEnd == false)
        {
            attackPanel.SetActive(true);
            specialActionPan.SetActive(false);
        }
        else
        {
            actionPanel.SetActive(false);
            attackPanel.SetActive(true);
        }
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
        StartCoroutine(BattleEnd());
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
        if (tutorialScript.battleTutEnd == false)
        {
            if (tutorialScript.battlePrompt1 == true)
            {
                actionPanel.SetActive(true);
                itemPanel.SetActive(false);
                runPanel.SetActive(false);
            }
        }
        else
        {
            actionPanel.SetActive(true);
            attackPanel.SetActive(false);
        }
    }

    //Progresses through player's selected actions
    IEnumerator PlayerCombatTurn()
    {
        //partyMemOne Action
        if (choiceOne == ActionChoiceWL.ATTACKONE)
        {
            
            StartCoroutine(PartyBasicAtk(partyOneUnit));
        }
        else if (choiceOne == ActionChoiceWL.ATTACKTWO)
        {
            dialogueText.text = partyOneUnit.unitName + " attacks for " + partyOneUnit.unitAttack + "!";
            StartCoroutine(PartySpecialAtk(partyOneUnit));
        }
        else if (choiceOne == ActionChoiceWL.ITEM)
        {
            dialogueText.text = partyOneUnit.unitName + " uses an item!";
            StartCoroutine(PartyUseItem(partyOneUnit));
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 1 COMP");
        //partyMemTwo Action
        if (choiceTwo == ActionChoiceWL.ATTACKONE)
        {
            dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.unitAttack + "!";
            StartCoroutine(PartyBasicAtk(partyTwoUnit));
        }
        else if (choiceTwo == ActionChoiceWL.ATTACKTWO)
        {
            dialogueText.text = partyTwoUnit.unitName + " attacks for " + partyTwoUnit.unitAttack + "!";
            StartCoroutine(PartySpecialAtk(partyTwoUnit));
        }
        else if (choiceTwo == ActionChoiceWL.ITEM)
        {
            dialogueText.text = partyOneUnit.unitName + " uses an item!";
            StartCoroutine(PartyUseItem(partyTwoUnit));
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 2 COMP");
        //partyMemThree Action
        if (choiceThree == ActionChoiceWL.ATTACKONE)
        {
            dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.unitAttack + "!";
            StartCoroutine(PartyBasicAtk(partyThreeUnit));
        }
        else if (choiceThree == ActionChoiceWL.ATTACKTWO)
        {
            dialogueText.text = partyThreeUnit.unitName + " attacks for " + partyThreeUnit.unitAttack + "!";
            StartCoroutine(PartySpecialAtk(partyThreeUnit));
        }
        else if (choiceThree == ActionChoiceWL.ITEM)
        {
            
            StartCoroutine(PartyUseItem(partyThreeUnit));
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Unit 3 COMP");

        //partyMemFour Action
        if (choiceFour == ActionChoiceWL.ATTACKONE)
        {
            StartCoroutine(PartyBasicAtk(partyFourUnit));
        }
        else if (choiceFour == ActionChoiceWL.ATTACKTWO)
        {
            StartCoroutine(PartySpecialAtk(partyFourUnit));
        }
        else if (choiceFour == ActionChoiceWL.ITEM)
        {
            StartCoroutine(PartyUseItem(partyFourUnit));
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
            Debug.Log("Party One Option Comp");
        }
        else if (state == BattleStateWL.PARTYTWOSEL)
        {
            choiceTwo = ActionChoiceWL.ATTACKONE;
            state = BattleStateWL.PARTYTHREESEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyThreeUnit.unitName + "'s Action";
            Debug.Log("Party Two Option Comp");
        }
        else if (state == BattleStateWL.PARTYTHREESEL)
        {
            choiceThree = ActionChoiceWL.ATTACKONE;
            state = BattleStateWL.PARTYFOURSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyFourUnit.unitName + "'s Action";
            Debug.Log("Party Three Option Comp");
        }
        else if (state == BattleStateWL.PARTYFOURSEL)
        {
            choiceFour = ActionChoiceWL.ATTACKONE;
            state = BattleStateWL.ATTACKTURN;
            yield return new WaitForSeconds(1f);
            actionPanel.SetActive(false);
            attackPanel.SetActive(false);
            dialogueText.text = " ... ";
            Debug.Log("Party Four Option Comp");
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
            Debug.Log("Party One Option Comp");
        }
        else if (state == BattleStateWL.PARTYTWOSEL)
        {
            choiceTwo = ActionChoiceWL.ATTACKTWO;
            state = BattleStateWL.PARTYTHREESEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyThreeUnit.unitName + "'s Action";
            Debug.Log("Party Two Option Comp");
        }
        else if (state == BattleStateWL.PARTYTHREESEL)
        {
            choiceThree = ActionChoiceWL.ATTACKTWO;
            state = BattleStateWL.PARTYFOURSEL;
            yield return new WaitForSeconds(1f);
            ButtonAttackBack();
            dialogueText.text = partyFourUnit.unitName + "'s Action";
            Debug.Log("Party Three Option Comp");
        }
        else if (state == BattleStateWL.PARTYFOURSEL)
        {
            choiceFour = ActionChoiceWL.ATTACKTWO;
            state = BattleStateWL.ATTACKTURN;
            yield return new WaitForSeconds(1f);
            actionPanel.SetActive(false);
            attackPanel.SetActive(false);
            dialogueText.text = " ... ";
            Debug.Log("Party Four Option Comp");
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
        if (partyOneUnit.unitIsDead)
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
        else if (partyTwoUnit.unitIsDead)
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
        else if (partyThreeUnit.unitIsDead)
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
        else if (partyFourUnit.unitIsDead)
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
        if (partyThreeUnit.unitIsDead && partyFourUnit.unitIsDead)
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
        else if (partyTwoUnit.unitIsDead && partyFourUnit.unitIsDead)
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
        else if (partyTwoUnit.unitIsDead && partyThreeUnit.unitIsDead)
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
        else if (partyOneUnit.unitIsDead && partyFourUnit.unitIsDead)
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
        else if (partyOneUnit.unitIsDead && partyThreeUnit.unitIsDead)
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
        else if (partyOneUnit.unitIsDead && partyTwoUnit.unitIsDead)
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
        if (partyTwoUnit.unitIsDead && partyThreeUnit.unitIsDead && partyFourUnit.unitIsDead)
        {
            Debug.Log("All but Party One are dead");
            StartCoroutine(EnemyBasic(partyOneUnit, pOneHUD));
        }
        else if (partyOneUnit.unitIsDead && partyFourUnit.unitIsDead && partyFourUnit.unitIsDead)
        {
            Debug.Log("All but Party Two are dead");
            StartCoroutine(EnemyBasic(partyTwoUnit, pTwoHUD));
        }
        else if (partyOneUnit.unitIsDead && partyTwoUnit.unitIsDead && partyFourUnit.unitIsDead)
        {
            Debug.Log("All but Party Three are dead");
            StartCoroutine(EnemyBasic(partyThreeUnit, pThreeHUD));
        }
        else if (partyOneUnit.unitIsDead && partyTwoUnit.unitIsDead && partyThreeUnit.unitIsDead)
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
            if (!partyOneUnit.unitIsDead)
            {
                Debug.Log("Enemy SPEC-One");
                StartCoroutine(EnemySpecial(partyOneUnit, pOneHUD));
            }
        }
        else if (partyTwoUnit.unitCurrentHP == Mathf.Max(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            if (!partyTwoUnit.unitIsDead)
            {
                Debug.Log("Enemy SPEC-Two");
                StartCoroutine(EnemySpecial(partyTwoUnit, pTwoHUD));
            }
        }
        else if (partyThreeUnit.unitCurrentHP == Mathf.Max(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            if (!partyThreeUnit.unitIsDead)
            {
                Debug.Log("Enemy SPEC-Three");
                StartCoroutine(EnemySpecial(partyThreeUnit, pThreeHUD));
            }
        }
        else if (partyFourUnit.unitCurrentHP == Mathf.Max(partyOneUnit.unitCurrentHP, partyTwoUnit.unitCurrentHP, partyThreeUnit.unitCurrentHP, partyFourUnit.unitCurrentHP))
        {
            if (!partyFourUnit.unitIsDead)
            {
                Debug.Log("Enemy SPEC-Four");
                StartCoroutine(EnemySpecial(partyFourUnit, pFourHUD));
            }
        }
    }
}
