//DiceRoller.cs
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DiceValues = new int[2];
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

    }

    StateManager theStateManager;

    public int[] DiceValues;


    public Sprite[] DiceImageOne;
    public Sprite[] DiceImageTwo;
    public Sprite[] DiceImageThree;
    public Sprite[] DiceImageFour;
    public Sprite[] DiceImageFive;
    public Sprite[] DiceImageSix;

    // Update is called once per frame
    void Update()
    {
        
    }

    
    internal string text;



    public void RollTheDice()
    {

       // DiceTotalDisplay.frame = 0;
        
        if (theStateManager.IsDoneRolling == true)
        {
            //We've already rolled this turn
            return;
        }

        theStateManager.DiceTotal = 0;
        for (int i = 0; i < DiceValues.Length; i++)
        {
            DiceValues[i] = Random.Range(1, 7);
            theStateManager.DiceTotal += DiceValues[i];

            if (DiceValues[i] == 1)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageOne[Random.Range(0, DiceImageOne.Length)];
            }
            else if (DiceValues[i] == 2)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageTwo[Random.Range(0, DiceImageTwo.Length)];
            }
            else if (DiceValues[i] == 3)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageThree[Random.Range(0, DiceImageThree.Length)];
            }
            else if (DiceValues[i] == 4)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageFour[Random.Range(0, DiceImageFour.Length)];
            }
            else if (DiceValues[i] == 5)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageFive[Random.Range(0, DiceImageFive.Length)];
            }
            else if (DiceValues[i] == 6)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageSix[Random.Range(0, DiceImageSix.Length)];
            }
        }

        Debug.Log("Rolled: " + theStateManager.DiceTotal);
        theStateManager.IsDoneRolling = true;

        // Find all PlayerMove components and trigger movement for current player
        PlayerMove[] players = GameObject.FindObjectsByType<PlayerMove>(FindObjectsSortMode.None);
        foreach (PlayerMove player in players)
        {
            player.StartMove(theStateManager.DiceTotal);
        }
    }
}
