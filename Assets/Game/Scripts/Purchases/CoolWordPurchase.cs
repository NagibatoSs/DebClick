using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolWordPurchase : Purchase
{
    string[] words = { "√–≈Ѕ≈Ќ№ - интеллегент",
        "ƒ¬»√ј“№ Ѕј«ќ… - танцевать", "«»ѕќ¬— »…- крутой", " ќ«џ–Ќјя ƒ∆јћЅј - просто отпад",
        "—Ќ”√≈Ќ—- что-то типа круто, все зашибись", "ƒжекпот!!! ¬ам попалась волчь€ цитата - Ќе ныр€й в воду, если не знаешь дна. ÷ени друзей, а еще больше свободу" };
    protected override void BuyAction()
    {
        var ind = Random.Range(0, words.Length);
        _purchaseData.Description = words[ind];
    }

}
