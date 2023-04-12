using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] Character selectedCharacter;
    [SerializeField] List<Character> characterList;
    [SerializeField] Transform atkRef;
    // [SerializeField] float speed = 1f;

    Vector3 direction = Vector3.zero;

    public Character SelectedCharacter { get => selectedCharacter; }

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
        foreach (var chara in characterList)
        {
            chara.Button.interactable = value;
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

        selectedCharacter.transform.DOMove(atkRef.position, 1f);
    }

    public bool IsAttacking()
    {
        return DOTween.IsTweening(selectedCharacter.transform); 
    }

    public void TakeDamage(int damageValue)
    {
        selectedCharacter.ChangeHP(-damageValue);
        var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
        spriteRend.DOColor(Color.red, 0.1f).SetLoops(6, LoopType.Yoyo); 
    }

    public bool IsDamaging()
    {
        var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
        return DOTween.IsTweening(spriteRend);
    }

    public void Remove(Character chara)
    {
        if (characterList.Contains(chara) == false)
        {
            return;
        }
        selectedCharacter.Button.interactable = false;
        selectedCharacter.gameObject.SetActive(false);
        characterList.Remove(chara);
    }

    
}


