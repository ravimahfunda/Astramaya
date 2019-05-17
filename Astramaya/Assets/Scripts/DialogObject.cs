using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class DialogObject : ScriptableObject
{
    public List<CharacterObject> charaters;

    public List<string> sequence;
   
}
