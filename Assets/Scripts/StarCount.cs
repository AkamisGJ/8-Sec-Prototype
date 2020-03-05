using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine;
using Doozy.Engine.UI;

public class StarCount : Singleton<StarCount>
{

    private bool _stars_1 = false; //Finish level
    private bool _stars_2 = false; //Bonus
    private bool _stars_3 = false; //Movement

    public UIView[] starsView;

    private bool[] stars = new bool[3];

    public int maximumMovementForThisLevel = 10;


    public void UnlockStar(int index)
    {
        stars[index - 1] = true;
    }


    public IEnumerator SendDataToUI()
    {
        yield return new WaitForSeconds(1.5f);
        for(int i = 0; i < stars.Length; i++)
        {
            if(stars[i] == true)
            {
                starsView[i].Show();
                
                print("Send star " + i);
            }
        }
    }
}
