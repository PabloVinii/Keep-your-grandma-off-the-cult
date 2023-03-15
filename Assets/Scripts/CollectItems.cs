using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CollectItems : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string node;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            dialogueRunner.VariableStorage.SetValue(node, true);
            Destroy(this.gameObject);
        }
    }
}
