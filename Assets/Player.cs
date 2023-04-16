using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] Character selectedCharacter;
    [SerializeField] List<Character> characterList;
    [SerializeField] Transform atkRef;
    [SerializeField] bool isBot;
    [SerializeField] UnityEvent onTakeDamage;

    Vector3 direction = Vector3.zero;

    public Character SelectedCharacter { get => selectedCharacter; }
    public List<Character> CharacterList { get => characterList; }
    public bool IsBot { get => isBot; set => isBot = value; }

    private void Start()
    {
        if (IsBot)
        {
            foreach (var chara in CharacterList)
            {
                chara.Button.interactable = false;
            }
        }
    }

    public void Prepare()
    {
        selectedCharacter = null;
    }

    public void SelectCharacter(Character chara)
    {
        selectedCharacter = chara;
    }

    public void SetPlay(bool value)
    {
        if (IsBot)
        {
            List<Character> lotteryList = new List<Character>();
            foreach (var chara in CharacterList)
            {
                int ticket = Mathf.CeilToInt(((float)chara.CurrentHP / (float)chara.MaxHP) * 10);
                for (int i = 0; i < ticket; i++)
                {
                    lotteryList.Add(chara);
                }
            }
            int index = Random.Range(0, lotteryList.Count);
            selectedCharacter = lotteryList[index];
        }
        else
        {
            foreach (var chara in CharacterList)
            {
                chara.Button.interactable = value;
            }
        }
    }

    // manual (without DOTween)
    // public void Update()
    // {
    //     if(direction == Vector3.zero) {
    //         return;
    //     }

    //     if (Vector3.Distance(selectedCharacter.transform.position, atkRef.position) > 0.1f){
    //         selectedCharacter.transform.position += speed * direction * Time.deltaTime;
    //     }
    //     else {
    //         direction = Vector3.zero;
    //         selectedCharacter.transform.position = atkRef.position;
    //     }

    // }

    public void Attack()
    {
        // manual (without DOTween)
        // direction = atkRef.position - selectedCharacter.transform.position;
        // direction.Normalize();

        selectedCharacter.transform.DOMove(atkRef.position, 0.7f);
    }

    public bool IsAttacking()
    {
        if (selectedCharacter == null)
        {
            return false;
        }
        return DOTween.IsTweening(selectedCharacter.transform);
    }

    public void TakeDamage(int damageValue)
    {
        selectedCharacter.ChangeHP(-damageValue);
        var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
        spriteRend.DOColor(Color.red, 0.1f).SetLoops(6, LoopType.Yoyo);
        onTakeDamage.Invoke();
    }

    public bool IsDamaging()
    {
        if (selectedCharacter == null)
        {
            return false;
        }
        var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
        return DOTween.IsTweening(spriteRend);
    }

    public void Remove(Character chara)
    {
        if (characterList.Contains(chara) == false)
        {
            return;
        }
        if (selectedCharacter == chara)
        {
            selectedCharacter = null;
        }
        chara.Button.interactable = false;
        chara.gameObject.SetActive(false);
        CharacterList.Remove(chara);
    }

    public void Return()
    {
        selectedCharacter.transform.DOMove(selectedCharacter.OriginalPosition, 0.7f);
    }

    public bool IsReturning()
    {
        if (selectedCharacter == null)
        {
            return false;
        }
        return DOTween.IsTweening(selectedCharacter.transform);
    }
}


