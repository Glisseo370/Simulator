using DialogueEditor;
using System;
using System.Collections;
using UnityEngine;

public class StartDialogue : BaseInteract
{
    [SerializeField] private GameObject cameraPlace;
    [SerializeField] private Player player;
    [SerializeField] private GameObject interactImage;
    [SerializeField] private GameObject dialogueWindow;

    [SerializeField] private CharacteristicNPC characteristicNPC;

    public override void Interact(Player player)
    {
        cameraPlace.SetActive(true);
        player.enabled = false;
        interactImage.SetActive(false);
        dialogueWindow.SetActive(true);

        ConversationManager.Instance.StartConversation(characteristicNPC.conversation);
    }

    public void hid()
    {
        dialogueWindow.SetActive(false);
    }
}
