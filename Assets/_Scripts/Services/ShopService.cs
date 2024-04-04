using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ServiceLocator.ShopService
{
    public class ShopService
    {
        private List<Item> shopItems;
        private int itemCount;

        public ShopService()
        {
            shopItems = new List<Item>();
            itemCount = 0;
        }

        public Item BuyItem()
        {
            Item selectedItem = null;
            // need to fetch the buy price of item, player wish to buy after clicking the item image
            // Need to check if the player has sufficient money to buy that item or not
            // Reduce item count by 1 after player buys an item from the shop
            // If transaction is successful, play ching sound else play error sound
            // Add the purchased item to inventory
            itemCount--;

            return selectedItem;
        } 
    }
}

