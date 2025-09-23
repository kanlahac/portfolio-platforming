using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InternalEvent", menuName = "Scriptable Objects/Events/InternalEvent")]
public class InternalEvent : ScriptableObject
{
    public Action Event;
}
