using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

namespace ZRFramework {
	public abstract class ZRSingleton<T> where T : ZRSingleton<T> {

		protected static T instance = null;

		protected ZRSingleton() {
		
		}

		public T Instance() {
			if (instance == null) {
				ConstructorInfo[] ctors = typeof(T).GetConstructors (BindingFlags.Instance | BindingFlags.NonPublic);
				ConstructorInfo ctor = Array.Find (ctors, c => c.GetParameters ().Length == 0);
				if (ctor == null)
					throw new Exception ("Non-public ctor not Found!");
				instance = ctor.Invoke (null) as T;
			}
			return instance;
		}
	}
}
