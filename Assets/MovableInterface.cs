using UnityEngine;

public interface MovableInterface {

    bool isMoving { get; set; }

    void Move(Vector3 direction);
}
