using System.Collections.Generic;
using UnityEngine;
using System;
using IMDB4Unity;
using UnityExtensions;

namespace ExtraPlayerPref
{
	[Serializable]
	public sealed partial class ExtraPlayerPrefRepository : RepositoryBase<ExtraPlayerPrefEntity, ExtraPlayerPrefRepository>, IDatabase
	{
		[SerializeField] private List<ExtraPlayerPrefEntity> data = new List<ExtraPlayerPrefEntity>();

		protected override List<ExtraPlayerPrefEntity> EntityList => data;

		public override void Insert(ExtraPlayerPrefEntity entity) {
			throw new NotSupportedException("Insert function is not supported.");
		}

		public string Schema => "PlayerPref";

		/// <summary>
		/// Gets int value by key.
		/// </summary>
		/// <returns>int value</returns>
		/// <param name="key"></param>
		public int GetIntOrDefault(string key, int defaultValue = 0) {
			int result = defaultValue;

			if (TryFindByKey(key, out ExtraPlayerPrefEntity entity)) {
				if (int.TryParse(entity.Value, out int i)) {
					result = i;
				}
			}

			return result;
		}

		/// <summary>
		/// Gets string value by key.
		/// </summary>
		/// <returns>string value</returns>
		/// <param name="key"></param>
		public string GetStringOrDefault(string key, string defaultValue = "") {
			string result = defaultValue;

			if (TryFindByKey(key, out ExtraPlayerPrefEntity entity)) {
				result = entity.Value;
			}

			return result;
		}

		/// <summary>
		/// Gets float value by key.
		/// </summary>
		/// <returns>float value</returns>
		/// <param name="key"></param>
		public float GetFloatOrDefault(string key, float defaultValue = 0f) {
			float result = defaultValue;

			if (TryFindByKey(key, out ExtraPlayerPrefEntity entity)) {
				if (float.TryParse(entity.Value, out float value)) {
					result = value;
				}
			}

			return result;
		}

		/// <summary>
		/// Gets bool value by key.
		/// </summary>
		/// <returns>bool value</returns>
		/// <param name="key"></param>
		public bool GetBoolOrDefault(string key, bool defaultValue = false) {
			bool result = defaultValue;

			if (TryFindByKey(key, out ExtraPlayerPrefEntity entity)) {
				if (bool.TryParse(entity.Value, out bool value)) {
					result = value;
				}
			}

			return result;
		}

		/// <summary>
		/// Gets class value by key.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <typeparam name="T">T is serialzable class.</typeparam>
		/// <returns></returns>
		public T GetClassOrDefault<T>(string key, T defaultValue) where T : class {
			T result = defaultValue;

			if (TryFindByKey(key, out ExtraPlayerPrefEntity entity)) {
				result = JsonUtility.FromJson<T>(entity.Value);
			}

			return result;
		}

		/// <summary>
		/// Gets vector2 value by key.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public Vector2 GetVector2OrDefault(string key, Vector2? defaultValue = null) {
			Vector2? result = defaultValue ?? Vector2.zero;

			if (TryFindByKey(key, out ExtraPlayerPrefEntity entity)) {
				result = JsonUtility.FromJson<Vector2>(entity.Value);
			}

			return result.Value;
		}

		/// <summary>
		/// Gets vector3 value by key.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public Vector3 GetVector3OrDefault(string key, Vector3? defaultValue = null) {
			Vector2? result = defaultValue ?? Vector3.zero;

			if (TryFindByKey(key, out ExtraPlayerPrefEntity entity)) {
				result = JsonUtility.FromJson<Vector3>(entity.Value);
			}

			return result.Value;
		}

		/// <summary>
		/// Gets PlayerPrefEntity List by category.
		/// </summary>
		/// <returns>List<PlayerPrefEntity></returns>
		/// <param name="category"></param>
		public List<ExtraPlayerPrefEntity> FindAllByCategory(string category) {
			List<ExtraPlayerPrefEntity> list = Instance.FindAllBy(x => x.Category == category);
			if (list.IsNullOrEmpty()) {
				return new List<ExtraPlayerPrefEntity>();
			}

			return list;
		}

		/// <summary>
		/// Sets the int value.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="category"></param>
		public void SetInt(string key, int value, string category = "") {
			SetString(key, value.ToString(), category);
		}

		/// <summary>
		/// Sets the float value.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="category"></param>
		public void SetFloat(string key, float value, string category = "") {
			SetString(key, value.ToString(), category);
		}

		/// <summary>
		/// Sets the bool value.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="category"></param>
		public void SetBool(string key, bool value, string category = "") {
			SetString(key, value.ToString(), category);
		}

		/// <summary>
		/// Sets the vector2 value.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="category"></param>
		public void SetVector2(string key, Vector2 value, string category = "") {
			SetString(key, JsonUtility.ToJson(value), category);
		}

		/// <summary>
		/// Sets the vector3 value.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="category"></param>
		public void SetVector3(string key, Vector3 value, string category = "") {
			SetString(key, JsonUtility.ToJson(value), category);
		}

		/// <summary>
		/// Sets the class value.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="category"></param>
		/// <typeparam name="T">T is serializable class.</typeparam>
		public void SetClass<T>(string key, T value, string category = "") where T : class {
			Type cls = typeof(T);
			if (!Attribute.IsDefined(cls, typeof(SerializableAttribute))) {
				throw new ArgumentException($"{cls} has not SerializableAttribute.");
			}

			SetString(key, JsonUtility.ToJson(value), category);
		}

		/// <summary>
		/// Sets the value.
		/// </summary>
		/// <param name="key">Key</param>
		/// <param name="value">Value</param>
		/// <param name="category">Category</param>
		public void SetString(string key, string value, string category = "") {

			if (string.IsNullOrEmpty(key)) {
				throw new ArgumentNullException("A key is necessary for PlayerPref");
			}

			if (TryFindByKey(key, out ExtraPlayerPrefEntity entity)) {
				entity.SetKey(key);
				entity.SetValue(value);
				entity.SetCategory(category);
				return;
			}

			ExtraPlayerPrefEntity newEntity = new ExtraPlayerPrefEntity(key, value, category);
			Instance.EntityList.Add(newEntity);
		}

		/// <summary>
		/// Delete all by category.
		/// </summary>
		/// <param name="category"></param>
		public void DeleteAllByCategory(string category) {
			DeleteAllBy(x => x.Category == category);
		}

		bool TryFindByKey(string key, out ExtraPlayerPrefEntity entity) {
			entity = null;

			if (string.IsNullOrEmpty(key)) {
				ExDebug.LogError("key is null or empty.");
				return false;
			}

			entity = EntityList.Find(x => x.Key == key);
			return entity != null;
		}
	}
}