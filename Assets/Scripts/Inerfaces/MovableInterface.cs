using UnityEngine;

public interface MovableInterface {

    bool isMoving { get; }

    void Move(Vector3 direction);
}
