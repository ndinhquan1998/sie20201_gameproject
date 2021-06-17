using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class LevelExit : Interactable
    {
        GameManager gameManager;


        void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        public override void Interact(PlayerManager playerManager)
        {
            RGBColor col = new RGBColor(200, 217, 40);
            Color c = col.getRGBColor;
            gameManager.UpdateStatus(c, "Mission Accomplish");
            //gameManager.Saving();

            gameManager.LevelEndCo();
        }
    }

}
