using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoxColider : MonoBehaviour
{
    private Character _character;

    public CharacterBoxColider(Character character)
    {
        _character = character;
    }

    void Start()
    {
        _character = GetComponent<Character>();
    }

    public void BaseBox()
    {
        _character.GetComponent<BoxCollider2D>().size = new Vector2(0.75f, 3f);
        _character.GetComponent<BoxCollider2D>().offset = new Vector2(-0.4f, 0.4f);
    }

    public void IdleBox()
    {
        _character.GetComponent<BoxCollider2D>().size = new Vector2(1.1f, 3.06f);
        _character.GetComponent<BoxCollider2D>().offset = new Vector2(0.19f, 0.37f);

    }

    public void JumpBox()
    {
        _character.GetComponent<BoxCollider2D>().size = new Vector2(2.48f, 2.8f);
        _character.GetComponent<BoxCollider2D>().offset = new Vector2(-0.17f, 1.14f);
       
    }

    public void CrawlBox()
    {
        _character.GetComponent<BoxCollider2D>().size = new Vector2(2.3f, 1.15f);
        _character.GetComponent<BoxCollider2D>().offset = new Vector2(-0.36f, -0.55f);
    }

}
