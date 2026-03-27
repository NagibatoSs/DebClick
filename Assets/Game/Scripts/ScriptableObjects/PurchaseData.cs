using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Purchase", menuName = "PurchaseData", order = 51)]
public class PurchaseData : ScriptableObject
{
    [SerializeField] protected string _name;
    public string Name { get => _name; }
    [SerializeField] protected int _price;
    public int Price { get => _price; }
    [SerializeField] protected string _description;
    public string Description { get => _description; set => _description = value; }
    [SerializeField] protected string _buttonText;
    public string ButtonText { get => _buttonText; set => _buttonText = value; }
    [SerializeField] protected Texture _contentTexture;
    public Texture ContentTexture { get => _contentTexture; }
}
