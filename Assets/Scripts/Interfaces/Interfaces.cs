using System;

public interface IInteractable
{
    void OnInteractStart(Action<bool> extraBehaviour);
    void OnInteractEnd();
}