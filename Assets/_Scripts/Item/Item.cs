using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private ItemType type;
    private Sprite image;
    private string description;
    private float buyPrice;
    private float sellPrice;
    private float weight;
    private ItemRarity rarity;

    public Item(ItemType type, Sprite image, string description, float buyPrice, float sellPrice, float weight, ItemRarity rarity)
    {
        this.type = type;
        this.image = image;
        this.description = description;
        this.buyPrice = buyPrice;
        this.sellPrice = sellPrice;
        this.weight = weight;
        this.rarity = rarity;
    }
}