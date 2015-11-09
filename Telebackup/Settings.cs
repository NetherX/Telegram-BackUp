/** Made by Lonami Exo
 * (C) LonamiWebs 2015
 * Created: 24/05/2015
 * LastMod: 03/06/2015
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;

/// <summary>
/// An improved (both on performance and error handling) Settings class
/// </summary>
public static class Settings
{
	#region Private variables and consts
	
	// The application name. It can be "Domain\\Name"
	static string AppName;
	// Where the settings file is located
	static string SettingsFile;
	
	// The stored values for the current settings
	static Dictionary<string, dynamic> Values = new Dictionary<string, dynamic>();
	// The default values to be used
	static Dictionary<string, dynamic> DefaultValues;
	
	// Has been Settings initialized?
	static bool Initialized;
	
	// Error messages
	const string NotImplemented = "The type {0} has not been implemented";
	const string NotInitialized = "You must call Settings.Init() before calling Settings.Load()";
	const string CharNotSupported = "A setting name cannot contain the NUL character";
	
	#endregion
	
	#region Supported types
	
	// The list of supported types
	static readonly Dictionary<Type, Func<dynamic>> SupportedTypes = new Dictionary<Type, Func<dynamic>>
	{
		{ typeof(bool), () => DefaultBoolValue },
		{ typeof(int), () => DefaultIntValue },
	    { typeof(float), () => DefaultFloatValue },
	    { typeof(string), () => DefaultStringValue },
	    { typeof(string[]), () => DefaultStringArrayValue },
	    { typeof(Color), () => DefaultColorValue },
	};
	// A dictionary for converting Type -> Type name
	static readonly Dictionary<Type, Func<dynamic>> TypeToName = new Dictionary<Type, Func<dynamic>>
	{
		{ typeof(bool), () => "bool" },
		{ typeof(int), () => "int" },
	    { typeof(float), () => "float" },
	    { typeof(string), () => "string" },
	    { typeof(string[]), () => "string[]" },
	    { typeof(Color), () => "color" },
	};
	// A dictionary for converting Type name -> Type
	static readonly Dictionary<string, Func<dynamic>> NameToType = new Dictionary<string, Func<dynamic>>
	{
		{ "bool", () => typeof(bool) },
		{ "int", () => typeof(int) },
	    { "float", () => typeof(float) },
	    { "string", () => typeof(string) },
	    { "string[]", () => typeof(string[]) },
	    { "color", () => typeof(Color) },
	};
	
	#endregion
	
	#region Public variables and consts
	
	/// <summary>
	/// Should the settings be saved automatically?
	/// </summary>
	public static bool Autosave = true;

	/// <summary>
	/// Default value for booleans
	/// </summary>
	public const bool DefaultBoolValue = false;
	/// <summary>
	/// Default value for int
	/// </summary>
	public const int DefaultIntValue = int.MinValue;
	/// <summary>
	/// Default value for floats
	/// </summary>
	public const float DefaultFloatValue = float.NegativeInfinity;
	/// <summary>
	/// Default value for strings
	/// </summary>
	public const string DefaultStringValue = null;
	/// <summary>
	/// Default value for strings array
	/// </summary>
	public const string DefaultStringArrayValue = null;
	/// <summary>
	/// Default value for colors
	/// </summary>
	public static readonly Color DefaultColorValue = Color.Transparent;
	
	#endregion
	
	/// <summary>
	/// Initializes the Settings instance. This must be called once
	/// </summary>
	/// <param name="appName">The name of the current application. You may use "Domain\\AppName"</param>
	public static void Init(string appName)
	{ Init(appName, new Dictionary<string, dynamic>()); }
	
	/// <summary>
	/// Initializes the Settings instance. This must be called once
	/// </summary>
	/// <param name="appName">The name of the current application. You may use "Domain\\AppName"</param>
	/// <param name="defaultValues">The value pairs for the default values if they're not found or corrupted</param>
	public static void Init(string appName, Dictionary<string, dynamic> defaultValues)
	{
		if (Initialized)
			return;
		Initialized = true;
		
		foreach (var value in defaultValues)
			CheckType(value.Value.GetType());
		
		AppName = appName;
		DefaultValues = defaultValues;
		
		var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppName);
		SettingsFile = Path.Combine(dir, "settings");
		
		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
			File.WriteAllText(SettingsFile, "", Encoding.UTF8);
		}
		else if (!File.Exists(SettingsFile))
			File.WriteAllText(SettingsFile, "", Encoding.UTF8);
		
		Load(false);
	}
	
	/// <summary>
	/// Loads the settings. Default values will be used if they're corrupted. 
	/// This is automatically called once after calling <seealso cref="Init">Settings.Init()</seealso>
	/// </summary>
	public static void Load()
	{ Load(false); }
	
	/// <summary>
	/// Saves the settings. 
	/// This is automatically called if Autosave is enabled
	/// </summary>
	public static void Save()
	{
		CheckInitialized();
		
		var sb = new StringBuilder();
		foreach (var kvp in Values)
		{
			if (kvp.Value == null)
			{
				Debug.WriteLine("[WARNING] Cannot save the value " + kvp.Key + " due to it's NUL");
				continue;
			}
			
			sb.Append(GetNameFromType(kvp.Value.GetType()));
			sb.Append('\0');
			sb.Append(kvp.Key);
			sb.Append('\0');
			// disable all OperatorIsCanBeUsed
			if (kvp.Value.GetType() == typeof(Color))
				sb.AppendLine(ColorTranslator.ToHtml(kvp.Value));
			else if (kvp.Value.GetType() == typeof(string[]))
				sb.AppendLine(String.Join("\0", kvp.Value));
	        else
				sb.AppendLine(kvp.Value.ToString());
		}
		File.WriteAllText(SettingsFile, sb.ToString());
	}
	
	/// <summary>
	/// Resets the current settings to it's default values, and saves them if Autosave is true
	/// </summary>
	public static void Reset()
	{
		CheckInitialized();
		
		Load(true);
		if (Autosave) File.WriteAllText(SettingsFile, "");
	}
	
	#region Get and set value
	
	/// <summary>
	/// Gets a value for the given setting name. If it doesn't exist, it is created
	/// </summary>
	/// <param name="settingName">The name of the setting</param>
	/// <returns>The value of the setting</returns>
	public static T GetValue<T>(string settingName)
	{
		CheckType(typeof(T));
		
		if (!Values.ContainsKey(settingName))
			SetValue<T>(settingName, GetDefault(typeof(T)));
		
		return Values[settingName];
	}
	
	/// <summary>
	/// Sets a value for the given setting name
	/// </summary>
	/// <param name="settingName">The name of the setting</param>
	/// <param name="value">The value of the setting</param>
	public static void SetValue<T>(string settingName, T value)
	{
		if (settingName.IndexOf('\0') >= 0)
			throw new ArgumentException(CharNotSupported);
		
		CheckType(typeof(T));
		
		if (!Values.ContainsKey(settingName))
			Values.Add(settingName, value);
		else
			Values[settingName] = value;
		
		if (Autosave)
			Save();
	}
	
	#endregion
	
	#region Private methods
	
	// Load
	static void Load(bool onlyDefault)
	{
		CheckInitialized();
		
		Values = DefaultValues;
		
		if (onlyDefault)
			return;
		
		Type type;
		string[] spl;
		string name = "", value = "";
		
		var @switch = new Dictionary<Type, Func<dynamic>>
		{
			{ typeof(bool), () => bool.Parse(value) },
			{ typeof(int), () => int.Parse(value) },
			{ typeof(float), () => float.Parse(value) },
			{ typeof(string), () => value },
			{ typeof(string[]), () =>  value.Split('\0') },
			{ typeof(Color), () => ColorTranslator.FromHtml(value) },
		};
		
		foreach (var line in File.ReadAllLines(SettingsFile))
		{
			if (string.IsNullOrWhiteSpace(line))
				continue;
			
			try
			{
				spl = line.Split('\0');
				type = GetTypeFromName(spl[0]);
				name = spl[1];
				value = string.Join("\0", spl.Skip(2));
				
				if (Values.ContainsKey(name))
					Values[name] = @switch[type]();
				else
					Values.Add(name, @switch[type]());
			}
			catch { Debug.WriteLine("[WARNING] Cannot load settings for line: " + line + "\r\n"); }
		}
	}
	
	// Get default value for type
	static dynamic GetDefault(Type type)
	{
		CheckType(type);
		return SupportedTypes[type]();
	}
	// Get Type <-> Name
	static Type GetTypeFromName(string typeName)
	{
		CheckType(typeName);
		return NameToType[typeName]();
	}
	static string GetNameFromType(Type type)
	{
		CheckType(type);
		return TypeToName[type]();
	}
	
	// Checks
	static void CheckInitialized()
	{
		if (!Initialized)
			throw new NullReferenceException(NotInitialized);
	}
	static void CheckType(Type type)
	{
		if (!SupportedTypes.ContainsKey(type))
			throw new NotImplementedException(string.Format(NotImplemented, type));
	}
	static void CheckType(string typeName)
	{
		if (!NameToType.ContainsKey(typeName))
			throw new NotImplementedException(string.Format(NotImplemented, typeName));
	}
	
	#endregion
}
