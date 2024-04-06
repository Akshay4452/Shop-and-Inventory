using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ServiceLocator.ShopService
{
    public class ShopService
    {
        private List<Item> materialItems;
        private List<Item> weaponItems;
        private List<Item> consumableItems;
        private List<Item> treasureItems;

        private int materialItemCount;
        private int weaponItemCount;
        private int consumableItemCount;
        private int treasureItemCount;

        public ShopService()
        {
            materialItems = new List<Item>();
            weaponItems = new List<Item>();
            consumableItems = new List<Item>();
            treasureItems = new List<Item>();
        }

        public Item BuyItem()
        {
            Item selectedItem = null;
            // need to fetch the buy price of item, player wish to buy after clicking the item image
            // Need to check if the player has sufficient money to buy that item or not
            // Reduce item count by 1 after player buys an item from the shop
            // If transaction is successful, play ching sound else play error sound
            // Add the purchased item to inventory
            //itemCount--;

            return selectedItem;
        } 
    }
}

