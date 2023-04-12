using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{
    [SerializeField] new string name;
    [SerializeField] CharacterType type;
    [SerializeField] int currentHP;
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] TMP_Text overHead;
    [SerializeField] Image avatar;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text typeText;
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text hpText;
    [SerializeField] Button button;

    public Button Button { get => button; }

    public CharacterType Type { get => type; }

    public int attackPower { get => attack; }
    
    public int CurrentHP { get => currentHP; }

    private void Start()
    {
        overHead.text = name;
        nameText.text = name;
        typeText.text = type.ToString();
        button.interactable = false;
        UpdateHPBar();
    }

    public void ChangeHP(int value)
    {
        currentHP += value;

        // if(currentHP < 0) {
        //     currentHP = 0;
        // }

        // if(currentHP > maxHP) {
        //     currentHP = maxHP;
        // }

        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        healthBar.fillAmount = (float)currentHP / (float)maxHP;
        hpText.text = currentHP.ToString() + "/" + maxHP.ToString();
    }
}
