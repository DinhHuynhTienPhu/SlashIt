using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
  CharacterSlash character = null;

  private void Start()
  {
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    character = other.gameObject.GetComponent<CharacterSlash>();
    StartCoroutine(DamageCoroutine());

  }

  private void OnTriggerExit2D(Collider2D other)
  {
    character = null;
  }
  IEnumerator DamageCoroutine()
  {
    while (character != null)
    {
      if (character != null && character.isSlashing == false) character.TakeDamage(1);
      yield return new WaitForSeconds(3);
    }
    yield return null;
  }
}
