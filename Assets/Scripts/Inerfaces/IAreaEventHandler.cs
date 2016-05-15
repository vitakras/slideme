using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// I area event handler.
/// </summary>
public interface IAreaEventHandler : IEventSystemHandler {

	/// <summary>
	/// Raises the area enter event.
	/// </summary>
	/// <param name="gameObject">Game object.</param>
	void OnAreaEnter(GameObject gameObject);

	/// <summary>
	/// Raises the area exit event.
	/// </summary>
	/// <param name="gameObject">Game object.</param>
	void OnAreaExit(GameObject gameObject);
}
