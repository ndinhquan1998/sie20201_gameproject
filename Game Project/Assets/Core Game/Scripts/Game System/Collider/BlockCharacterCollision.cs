using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollision : MonoBehaviour
{
    public CapsuleCollider characterCollider;
    public CapsuleCollider characterBlockerCollider;

    void Update()
    {
        Physics.IgnoreCollision(characterCollider, characterBlockerCollider, true);
    }
}
