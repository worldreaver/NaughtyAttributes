# NaughtyAttributes
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://github.com/worldreaver/NaughtyAttributes/blob/master/LICENSE.txt)

NaughtyAttributes is an extension for the Unity Inspector.

It expands the range of attributes that Unity provides so that you can create powerful inspectors without the need of custom editors or property drawers. It also provides attributes that can be applied to non-serialized fields or functions.

Most of the attributes are implemented using Unity's `CustomPropertyDrawer`, so they will work in your custom editors. If you want all of the attributes to work in your custom editors, however, you must inherit from `NaughtyInspector` and use the `NaughtyEditorGUI.PropertyField_Layout` function instead of `EditorGUILayout.PropertyField`.

## System Requirements
[![Unity 2018.3+](https://img.shields.io/badge/unity-2018.3+-brightgreen.svg?style=flat&logo=unity&cacheSeconds=2592000)](https://unity3d.com/get-unity/download/archive)
[![.Net 2.0 Scripting Runtime](https://img.shields.io/badge/.NET-2.0-blueviolet.svg?style=flat&cacheSeconds=2592000)](https://docs.unity3d.com/2019.1/Documentation/Manual/ScriptingRuntimeUpgrade.html)

## Installation
You can also install via git url by adding this entry in your **manifest.json**
```
"com.worldreaver.naughtyattributes": "git+https://github.com/worldreaver/NaughtyAttributes#upm",
```
## Documentation
- [Documentation](https://dbrizov.github.io/na-docs/)
- [Documentation Repo](https://github.com/dbrizov/na-docs)

# Overview

## Drawer Attributes
Provide special draw options to serialized fields.
A field can have only one DrawerAttribute. If a field has more than one, only the bottom one will be used.

### Button
A method can be marked as a button. A button appears in the inspector and executes the method if clicked.
Works both with instance and static methods.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Button]
	private void MethodOne() { }

	[Button("Button Text")]
	private void MethodTwo() { }
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/Button_Inspector.png)

### Dropdown
Provides an interface for dropdown value selection.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Dropdown("intValues")]
	public int intValue;

	[Dropdown("StringValues")]
	public string stringValue;

	[Dropdown("GetVectorValues")]
	public Vector3 vectorValue;

	private int[] intValues = new int[] { 1, 2, 3, 4, 5 };

	private List<string> StringValues { get { return new List<string>() { "A", "B", "C", "D", "E" }; } }

	private DropdownList<Vector3> GetVectorValues()
	{
		return new DropdownList<Vector3>()
		{
			{ "Right",   Vector3.right },
			{ "Left",    Vector3.left },
			{ "Up",      Vector3.up },
			{ "Down",    Vector3.down },
			{ "Forward", Vector3.forward },
			{ "Back",    Vector3.back }
		};
	}
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/Dropdown_Inspector.gif)

### EnumFlags
Provides dropdown interface for setting enum flags.

```csharp
public enum Direction
{
	None = 0,
	Right = 1 << 0,
	Left = 1 << 1,
	Up = 1 << 2,
	Down = 1 << 3
}

public class NaughtyComponent : MonoBehaviour
{
	[EnumFlags]
	public Direction flags;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/EnumFlags_Inspector.png)

### HorizontalLine

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[HorizontalLine(color: EColor.Red)]
	public int red;

	[HorizontalLine(color: EColor.Green)]
	public int green;

	[HorizontalLine(color: EColor.Blue)]
	public int blue;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/HorizontalLine_Inspector.png)

### InfoBox
Used for providing additional information.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[InfoBox("This is my int", EInfoBoxType.Normal)]
	public int myInt;

	[InfoBox("This is my float", EInfoBoxType.Warning)]
	public float myFloat;

	[InfoBox("This is my vector", EInfoBoxType.Error)]
	public Vector3 myVector;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/InfoBox_Inspector.png)

### InputAxis
Select an input axis via dropdown interface.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[InputAxis]
	public string inputAxis;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/InputAxis_Inspector.png)

### MinMaxSlider
A double slider. The **min value** is saved to the **X** property, and the **max value** is saved to the **Y** property of a **Vector2** field.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[MinMaxSlider(0.0f, 100.0f)]
	public Vector2 minMaxSlider;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/MinMaxSlider_Inspector.png)

### ProgressBar
```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ProgressBar("Health", 300, EColor.Red)]
	public int health = 250;

	[ProgressBar("Mana", 100, EColor.Blue)]
	public int mana = 25;

	[ProgressBar("Stamina", 200, EColor.Green)]
	public int stamina = 150;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ProgressBar_Inspector.png)

### ReorderableList
Provides array type fields with an interface for easy reordering of elements.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ReorderableList]
	public int[] intArray;

	[ReorderableList]
	public List<float> floatArray;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ReorderableList_Inspector.gif)

### ReadOnly
Makes a field read only.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ReadOnly]
	public Vector3 forwardVector = Vector3.forward;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ReadOnly_Inspector.png)

### ResizableTextArea
A resizable text area where you can see the whole text.
Unlike Unity's **Multiline** and **TextArea** attributes where you can see only 3 rows of a given text, and in order to see it or modify it you have to manually scroll down to the desired row.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ResizableTextArea]
	public string resizableTextArea;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ResizableTextArea_Inspector.gif)

### Scene
Select a scene from the build settings via dropdown interface.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Scene]
	public string bootScene; // scene name

	[Scene]
	public int tutorialScene; // scene index
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/Scene_Inspector.png)

### ShowAssetPreview
Shows the texture preview of a given asset (Sprite, Prefab...).

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ShowAssetPreview]
	public Sprite sprite;

	[ShowAssetPreview(128, 128)]
	public GameObject prefab;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ShowAssetPreview_Inspector.png)

### ShowNativeProperty
Shows native C# properties in the inspector.
All native properties are displayed at the bottom of the inspector after the non-serialized fields and before the method buttons.
It supports only certain types **(bool, int, long, float, double, string, Vector2, Vector3, Vector4, Color, Bounds, Rect, UnityEngine.Object)**.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public List<Transform> transforms;

	[ShowNativeProperty]
	public int TransformsCount => transforms.Count;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ShowNativeProperty_Inspector.png)

### ShowNonSerializedField
Shows non-serialized fields in the inspector.
All non-serialized fields are displayed at the bottom of the inspector before the method buttons.
Keep in mind that if you change a non-static non-serialized field in the code - the value in the inspector will be updated after you press **Play** in the editor.
There is no such issue with static non-serialized fields because their values are updated at compile time.
It supports only certain types **(bool, int, long, float, double, string, Vector2, Vector3, Vector4, Color, Bounds, Rect, UnityEngine.Object)**.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[ShowNonSerializedField]
	private int myInt = 10;

	[ShowNonSerializedField]
	private const float PI = 3.14159f;

	[ShowNonSerializedField]
	private static readonly Vector3 CONST_VECTOR = Vector3.one;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ShowNonSerializedField_Inspector.png)

### Tag
Select a tag via dropdown interface.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Tag]
	public string tagField;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/Tag_Inspector.png)

## Meta Attributes
Give the fields meta data. A field can have more than one meta attributes.

### BoxGroup
Surrounds grouped fields with a box.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[BoxGroup("Integers")]
	public int firstInt;
	[BoxGroup("Integers")]
	public int secondInt;

	[BoxGroup("Floats")]
	public float firstFloat;
	[BoxGroup("Floats")]
	public float secondFloat;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/BoxGroup_Inspector.png)

### EnableIf / DisableIf
```csharp
public class NaughtyComponent : MonoBehaviour
{
	public bool enableMyInt;

	[EnableIf("enableMyInt")]
	public int myInt;

	[EnableIf("Enabled")]
	public float myFloat;

	[EnableIf("NotEnabled")]
	public Vector3 myVector;

	public bool Enabled() { return true; }

	public bool NotEnabled => false;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/EnableIf_Inspector.gif)

You can have more than one condition.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public bool flag0;
	public bool flag1;

	[EnableIf(EConditionOperator.And, "flag0", "flag1")]
	public int enabledIfAll;

	[EnableIf(EConditionOperator.Or, "flag0", "flag1")]
	public int enabledIfAny;
}
```

### ShowIf / HideIf
```csharp
public class NaughtyComponent : MonoBehaviour
{
	public bool showInt;

	[ShowIf("showInt")]
	public int myInt;

	[ShowIf("AlwaysShow")]
	public float myFloat;

	[ShowIf("NeverShow")]
	public Vector3 myVector;

	public bool AlwaysShow() { return true; }

	public bool NeverShow => false;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ShowIf_Inspector.gif)

You can have more than one condition.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	public bool flag0;
	public bool flag1;

	[ShowIf(EConditionOperator.And, "flag0", "flag1")]
	public int showIfAll;

	[ShowIf(EConditionOperator.Or, "flag0", "flag1")]
	public int showIfAny;
}
```

### Label
Override default field label.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Label("Short Name")]
	public string veryVeryLongName;

	[Label("RGB")]
	public Vector3 vectorXYZ;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/Label_Inspector.png)

### OnValueChanged
Detects a value change and executes a callback.
Keep in mind that the event is detected only when the value is changed from the inspector.
If you want a runtime event, you should probably use an event/delegate and subscribe to it.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[OnValueChanged("OnValueChangedCallback")]
	public int myInt;

	private void OnValueChangedCallback(int oldValue, int newValue)
	{
		Debug.Log(myInt == newValue); // prints true
	}
}
```

## Validator Attributes
Used for validating the fields. A field can have infinite number of validator attributes.

### MinValue / MaxValue
Clamps integer and float fields.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[MinValue(0), MaxValue(10)]
	public int myInt;

	[MinValue(0.0f)]
	public float myFloat;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/MinValueMaxValue_Inspector.gif)

### Required
Used to remind the developer that a given reference type field is required.

```csharp
public class NaughtyComponent : MonoBehaviour
{
	[Required]
	public Transform myTransform;

	[Required("Custom required text")]
	public GameObject myGameObject;
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/Required_Inspector.png)

### ValidateInput
The most powerful ValidatorAttribute.

```csharp
public class _NaughtyComponent : MonoBehaviour
{
	[ValidateInput("IsNotNull")]
	public Transform myTransform;

	[ValidateInput("IsGreaterThanZero", "myInteger must be greater than zero")]
	public int myInt;

	private bool IsNotNull(Transform tr)
	{
		return tr != null;
	}

	private bool IsGreaterThanZero(int value)
	{
		return value > 0;
	}
}
```

![inspector](https://github.com/dbrizov/NaughtyAttributes/blob/master/Assets/NaughtyAttributes/Documentation~/ValidateInput_Inspector.png)