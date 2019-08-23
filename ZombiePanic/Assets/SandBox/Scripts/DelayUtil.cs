/*
 * DelayWrapperClass
 * 
 * Example:

	Coroutine coroutine = DelayUtil.Delay (1.0f, () => {
		Debug.Log ("DelayedCall");
	});
	DelayUtil.Stop(coroutine);

 * 
 */

using UnityEngine;
using System.Collections;
using System;

public class DelayUtil: MonoBehaviour {

	private static readonly DelayUtil self;

	static DelayUtil()
	{
		GameObject go = new GameObject("DelayUtil");
		self = go.AddComponent<DelayUtil>();
		GameObject.DontDestroyOnLoad(go);
	}

	public static Coroutine Delay(float waitTime, Action action)
	{
		return self.StartCoroutine(DelayMethod(waitTime, action));
	}
	public static Coroutine Delay<T>(float waitTime, Action<T> action, T t)
	{
		return self.StartCoroutine(DelayMethod(waitTime, action, t));
	}

	private static IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds (waitTime);
		action ();
	}
	private static IEnumerator DelayMethod<T>(float waitTime, Action<T> action, T t)
	{
		yield return new WaitForSeconds(waitTime);
		action(t);
	}

	public static void Stop(Coroutine coroutine)
	{
		self.StopCoroutine(coroutine);
	}

}
