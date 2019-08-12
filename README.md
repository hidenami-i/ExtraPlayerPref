# ExtraPlayerPref
Extra Unity's PlayerPref.

# Usage
## Install
Add the following line on manifest.json file.
```json
"com.hidenami-i.extraplayerpref": "https://github.com/hidenami-i/IMDB4Unity.git",
"com.hidenami-i.imdb4unity": "https://github.com/hidenami-i/IMDB4Unity.git",
"com.hidenami-i.unityextensions": "https://github.com/hidenami-i/UnityExtensions.git#1.0.0",
```

## Basic
```csharp
using System;
using IMDB4Unity;
using UnityEngine;
using UnityEngine.UI;

ExtraPlayerPrefRepository.Instance.Load();

// gets the value
ExtraPlayerPrefRepository.Instance.GetStringOrDefault("string");
ExtraPlayerPrefRepository.Instance.GetIntOrDefault("int");
ExtraPlayerPrefRepository.Instance.GetFloatOrDefault("float");
ExtraPlayerPrefRepository.Instance.GetBoolOrDefault("bool");
ExtraPlayerPrefRepository.Instance.GetVector2OrDefault("vector2");
ExtraPlayerPrefRepository.Instance.GetVector3OrDefault("vector3");
ExtraPlayerPrefRepository.Instance.GetClassOrDefault("class", Player.Default());

// sets the value
ExtraPlayerPrefRepository.Instance.SetString("string", "animal", "category");
ExtraPlayerPrefRepository.Instance.SetInt("int", int.MaxValue, "category");
ExtraPlayerPrefRepository.Instance.SetFloat("float", float.MaxValue, "category");
ExtraPlayerPrefRepository.Instance.SetBool("bool", true, "category");
ExtraPlayerPrefRepository.Instance.SetClass("class", new Player(1, "animal", DateTime.Now), "category");
ExtraPlayerPrefRepository.Instance.SetVector2("vector2", Vector2.up);
ExtraPlayerPrefRepository.Instance.SetVector3("vector3", Vector3.up);

ExtraPlayerPrefRepository.Instance.Save();ExtraPlayerPrefRepository.Instance.Load();

// gets the value
ExtraPlayerPrefRepository.Instance.GetStringOrDefault("string");
ExtraPlayerPrefRepository.Instance.GetIntOrDefault("int");
ExtraPlayerPrefRepository.Instance.GetFloatOrDefault("float");
ExtraPlayerPrefRepository.Instance.GetBoolOrDefault("bool");
ExtraPlayerPrefRepository.Instance.GetVector2OrDefault("vector2");
ExtraPlayerPrefRepository.Instance.GetVector3OrDefault("vector3");
ExtraPlayerPrefRepository.Instance.GetClassOrDefault("class", Player.Default());

// sets the value
ExtraPlayerPrefRepository.Instance.SetString("string", "animal", "category");
ExtraPlayerPrefRepository.Instance.SetInt("int", int.MaxValue, "category");
ExtraPlayerPrefRepository.Instance.SetFloat("float", float.MaxValue, "category");
ExtraPlayerPrefRepository.Instance.SetBool("bool", true, "category");
ExtraPlayerPrefRepository.Instance.SetClass("class", new Player(1, "animal", DateTime.Now), "category");
ExtraPlayerPrefRepository.Instance.SetVector2("vector2", Vector2.up);
ExtraPlayerPrefRepository.Instance.SetVector3("vector3", Vector3.up);

ExtraPlayerPrefRepository.Instance.Save();

[Serializable]
class Player
{
	[SerializeField] private int id;
	[SerializeField] private string name;
	[SerializeField] private string loginDate;

	public Player(int id, string name, DateTime loginDate) {
        this.id = id;
        this.name = name;
        this.loginDate = loginDate.ToString();
	}

	public static Player Default() {
        return new Player(1, "player1", DateTime.Now);
	}
}
```

