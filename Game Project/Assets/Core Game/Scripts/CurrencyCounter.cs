using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DQ
{
    public class CurrencyCounter : MonoBehaviour
    {
        public Text coinCountText;

        public void SetCoinText(int coinNumber)
        {
            coinCountText.text = coinNumber.ToString();
        }
    }

}
