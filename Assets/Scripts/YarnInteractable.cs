using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnInteractable : MonoBehaviour
{
    private DialogueRunner dialogueRunner;

    [SerializeField] private string conversationStartNode;
    [SerializeField] private Transform icon;

    private bool interactable = true;
    private bool isCurrentConversation = false;
    private bool playerInside;

    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (interactable && !dialogueRunner.IsDialogueRunning)
            {
                StartConversation();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true; //player dentro da area de colisão

            if (icon != null)
            {
                icon.gameObject.SetActive(true);
            }
        }
    }


    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInside = false; //player fora da area de colisão

            if (icon != null)
            {
                icon.gameObject.SetActive(false);
            }
        } 
    }

    private void StartConversation() {
        Debug.Log($"Started conversation with {name}.");
        isCurrentConversation = true;

        dialogueRunner.StartDialogue(conversationStartNode);
    }

    private void EndConversation() {
        if (isCurrentConversation) {
            isCurrentConversation = false;
            Debug.Log($"Ended conversation with {name}.");
        }
    }

    //Comandos personalizados do Yarn
    [YarnCommand("leap")]
    public void Leap() {
        Debug.Log($"{name} is leaping!");
    }

    [YarnCommand("startNode")]
    public void StartNode(string startNode) {
       conversationStartNode = startNode;
    }

    [YarnCommand("spawn")]
    public void Spawn(GameObject obj, bool spawn = false) {
        // spawn item
        if (spawn) {
            Debug.Log("spawno");
            Instantiate(obj, Vector3.zero, Quaternion.identity);
        }else {
            Debug.Log("nao spawno");
        }

    }
}
