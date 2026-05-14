using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class NPC : MonoBehaviour
{
    public NPCDialogue dialogueData; 
    public GameObject dialoguePanel; //Khung chat
    public TextMeshProUGUI dialogueText, nameText; //nội dung và tên NPC
    public Image spriteNPC; //ảnh NPC

    private int dialogueIndex; //đánh số trang
    private bool isTyping, isDialogueActive; //ngăn người chơi next quá nhanh, kiểm tra cuộc thoại có nên bắt đầu không

    private bool isPlayer = false;
    [SerializeField] GameObject buttonE;

    [SerializeField] Room currentRoom;
    [SerializeField] GameObject boss;


    private void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (dialogueData == null) return;


        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        spriteNPC.sprite = dialogueData.npcSprite;
        nameText.text = dialogueData.npcName;
        dialoguePanel.SetActive(true);
        buttonE.SetActive(false);

        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {
        //Bấm skip khi đang gõ chữ
        if (isTyping) 
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLine[dialogueIndex]);
            isTyping = false;


            AudioManager.instance.StopAudioClip(); //Dừng âm thanh khi bấm skip
        }

        //Chuyển sang câu tiếp theo
        else
        {
            dialogueIndex++;
            if (dialogueIndex < dialogueData.dialogueLine.Length)
            {
                StartCoroutine(TypeLine());
            }
            else
            {
                EndDialogue();
            }
        }
        
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        bool isTag = false;

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip(AudioManager.instance.npcClip);
        }

        foreach (char letter in dialogueData.dialogueLine[dialogueIndex])
        {
            if (letter == '<')
            {
                isTag = true;
            }

            dialogueText.text += letter;

            if (isTag == true)
            {

            }
            else
            {
                yield return new WaitForSeconds(dialogueData.typingSpeed);
            }

            if (letter == '>')
            {
                isTag= false;
            }
        }
              
        isTyping = false;
        AudioManager.instance.StopAudioClip(); //Hết chữ thì dừng âm thanh

    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);

        if (currentRoom != null)
        {
            currentRoom.OpenAllDoor();
        }
        

        gameObject.SetActive(false);
        boss.SetActive(true);

        AudioManager.instance.StopAudioClip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = true;

            if (buttonE != null)
            {
                buttonE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
            if (buttonE != null)
            {
                buttonE.SetActive(false);


                StopAllCoroutines();
                isDialogueActive = false;
                dialogueText.SetText("");
                dialoguePanel.SetActive(false);
            }
        }
    }
}