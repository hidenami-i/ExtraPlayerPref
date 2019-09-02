using System;
using System.Text;
using UnityEngine;
using IMDB4Unity;

namespace ExtraPlayerPref
{
	[Serializable]
	public sealed class ExtraPlayerPrefEntity : EntityBase
												// ISerializationCallbackReceiver
	{
		/// <summary>
		/// Key is an identifier.
		/// </summary>
		[SerializeField] string key;

		[SerializeField] string value;
		[SerializeField] string category;

		public string Key => key;

		public string Value => value;

		public string Category => category;

		public void SetKey(string key) {
			this.key = key;
		}

		public void SetValue(string value) {
			this.value = value;
		}

		public void SetCategory(string category) {
			this.category = category;
		}

		public ExtraPlayerPrefEntity() { }

		public ExtraPlayerPrefEntity(string key, string value, string category) {
			this.key = key;
			this.value = value;
			this.category = category;
		}

		// void ISerializationCallbackReceiver.OnBeforeSerialize() { }
		//
		// void ISerializationCallbackReceiver.OnAfterDeserialize() {
		// 	category = string.IsNullOrEmpty(category) ? "" : string.Intern(category);
		// }

		public override string ToString() {
			StringBuilder builder = new StringBuilder();
			builder.AppendLine().AppendLine($"<b>[ClassName] {nameof(ExtraPlayerPrefEntity)}</b>");
			builder.AppendLine($"[{nameof(key)}] {key}");
			builder.AppendLine($"[{nameof(Value)}] {Value}");
			builder.AppendLine($"[{nameof(Category)}] {Category}");
			return builder.ToString();
		}
	}
}