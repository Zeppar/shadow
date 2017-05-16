using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace ZRFramework {
	public abstract class ZRMonoSingleton<T> : MonoBehaviour where T : ZRMonoSingleton<T> {

		protected static T instance = null;

		public static T Instance() {
			if (instance == null) {
				instance = FindObjectOfType<T> ();
				if (FindObjectsOfType<T> ().Length > 1) {
					print ("More than 1 Object");
					return instance;
				}
				if (instance == null) {
					string instanceName = typeof(T).Name;
					print ("Instance Name : " + instanceName);
					GameObject instanceGo = GameObject.Find (instanceName);
					if (instanceGo == null)
						instanceGo = new GameObject (instanceName);
					instance = instanceGo.AddComponent<T> ();
					DontDestroyOnLoad (instanceGo);
					print ("Add new singleton " + instance.name + " in Game!");
				} else {
					print ("Already exists : " + instance.name);
				}
			}
			return instance;
		}

		protected virtual void OnDestory() {
			instance = null;
		}
	}
}
