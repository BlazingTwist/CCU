﻿using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using BepInEx.Logging;
using System.Reflection;

namespace CCU.Content
{
	public static class LevelEditorUtilities
	{
		private static readonly ManualLogSource logger = CCULogger.GetLogger();
		public static GameController GC => GameController.gameController;

		// LevelEditor.inputFieldList.isFocused
		// InputField.ActivateInputField() & possibly DeadctivateInputField() at the end

		// levelEditor.floors2Button.transform.Find("ButtonEdges").GetComponent<Image>().color = Color.white;
		// White is for currently click-activated, but might use another color to show which is tab-active, pending player confirmation

		// __instance.inputFieldList

		// UnityEngine.UI.InputField.ActivateInputField()

		public static List<InputField> fieldsAgent;
		public static List<InputField> fieldsFloor;
		public static List<InputField> fieldsItem;
		public static List<InputField> fieldsLight;
		public static List<InputField> fieldsObject;
		public static List<InputField> fieldsPatrolPoint;
		public static List<InputField> fieldsWall = new List<InputField>()
		{
			
		};
		public static Dictionary<string, List<InputField>> fieldLists = new Dictionary<string, List<InputField>>()
		{
			// TODO: Double-check these strings
			{ LEInterfaces_Agents, fieldsAgent },
			{ LEInterfaces_Floors, fieldsFloor },
			{ LEInterfaces_Floors2, fieldsFloor },
			{ LEInterfaces_Floors3, fieldsFloor },
			{ LEInterfaces_Items, fieldsItem },
			{ LEInterfaces_Lights, fieldsLight },
			{ LEInterfaces_Objects, fieldsObject },
			{ LEInterfaces_PatrolPoints, fieldsPatrolPoint },
			{ LEInterfaces_Walls, fieldsWall },
		};
		public const string
			LEInterfaces_Agents = "Agents",
			LEInterfaces_Floors = "Floors",
			LEInterfaces_Floors2 = "Floors2",
			LEInterfaces_Floors3 = "Floors3",
			LEInterfaces_Items = "Items",
			LEInterfaces_Level = "Level",
			LEInterfaces_Lights = "Lights",
			LEInterfaces_Objects = "Objects",
			LEInterfaces_PatrolPoints = "PatrolPoints",
			LEInterfaces_Walls = "Walls"
			;

		public static InputField ActiveInputField(LevelEditor levelEditor)
		{
			foreach (InputField field in levelEditor.inputFieldList)
				if (field.isFocused)
					return field;

			return null;
		}
		public static InputField GetDirectionInputField(LevelEditor levelEditor)
		{
			string curInt = levelEditor.currentInterface;

			FieldInfo field =
				curInt == LEInterfaces_Floors ? AccessTools.Field(typeof(LevelEditor), "directionFloor") :
				curInt == LEInterfaces_Agents ? AccessTools.Field(typeof(LevelEditor), "directionAgent") :
				curInt == LEInterfaces_Objects ? AccessTools.Field(typeof(LevelEditor), "directionFloor") :
				null;

			try
			{
				return (InputField)field.GetValue(levelEditor);
			}
			catch
			{
				return null;
			}
		}
		public static void IncrementPatrolPoint(LevelEditor levelEditor, KeyCode input)
		{
			Core.LogMethodCall();
			logger.LogDebug("\tInput: " + input.ToString());

			FieldInfo inputField = AccessTools.Field(typeof(LevelEditor), "pointNumPatrolPoint");
			InputField inputFieldField = (InputField)inputField.GetValue(levelEditor);

			if (inputFieldField.text == "")
				inputFieldField.text = "1";
			else
			{
				int curVal = int.Parse(inputFieldField.text);
				inputFieldField.text =
					input == KeyCode.E ? (Math.Min(99, curVal + 1).ToString()) :
					input == KeyCode.Q ? (Math.Max(1, curVal - 1).ToString()) :
					"1";
			}

			logger.LogDebug("\tNew value: " + inputFieldField.text);

			levelEditor.SetPointNum();
		}
		public static void OrientObject(LevelEditor levelEditor, KeyCode input)
		{
			Core.LogMethodCall();
			logger.LogDebug("\tinput: " + input.ToString());

			InputField inputField = GetDirectionInputField(levelEditor);
			string curDir = inputField.text;
			string newDir =
				input == KeyCode.UpArrow	? "N" :
				input == KeyCode.DownArrow	? "S" :
				input == KeyCode.LeftArrow	? "W" :
				input == KeyCode.RightArrow ? "E" :
				"None"; // This line unreachable but prettier this way

			if (curDir == newDir)
				newDir = ""; // "" instead of "None" for levelEditorTile.direction

			logger.LogDebug("\tnewDir: " + newDir);

			if (!(inputField is null))
				inputField.text = newDir;

			logger.LogDebug("\tinputField: " + inputField.name);
			logger.LogDebug("\tits value: " + inputField.text);

			FieldInfo directionObject = AccessTools.Field(typeof(LevelEditor), "directionObject");
			InputField directionObjectField = (InputField)directionObject.GetValue(levelEditor);
			directionObjectField.text = newDir;

			logger.LogDebug("\tdirectionObjectField: " + directionObjectField.name);
			logger.LogDebug("\tits value: " + directionObjectField.text);

			if (levelEditor.selectedTiles.Count() > 0)
				foreach (LevelEditorTile levelEditorTile in levelEditor.selectedTiles)
					levelEditorTile.direction = newDir;

			levelEditor.UpdateInterface(false);
		}
		public static void RotateObject(LevelEditor levelEditor, KeyCode input)
		{
			Core.LogMethodCall();
			logger.LogDebug("\tinput: " + input.ToString());

			InputField inputField = GetDirectionInputField(levelEditor);
			string curDir = inputField.text;
			string newDir = "None";

			if (input == KeyCode.E)
				newDir =
					curDir == "N" ? "E" :
					curDir == "E" ? "S" :
					curDir == "S" ? "W" :
					curDir == "W" ? "N" :
					"E";
			else if (input == KeyCode.Q)
				newDir =
					curDir == "N" ? "W" :
					curDir == "W" ? "S" :
					curDir == "S" ? "E" :
					curDir == "E" ? "N" :
					"W";

			if (!(inputField is null))
				inputField.text = newDir;

			logger.LogDebug("\tinputField: " + inputField.name);
			logger.LogDebug("\tits value: " + inputField.text);

			FieldInfo directionObject = AccessTools.Field(typeof(LevelEditor), "directionObject");
			InputField directionObjectField = (InputField)directionObject.GetValue(levelEditor);
			directionObjectField.text = newDir;

			logger.LogDebug("\tdirectionObjectField: " + directionObjectField.name);
			logger.LogDebug("\tits value: " + directionObjectField.text);

			if (levelEditor.selectedTiles.Count() > 0)
				foreach (LevelEditorTile levelEditorTile in levelEditor.selectedTiles)
					levelEditorTile.direction = newDir;

			levelEditor.UpdateInterface(false);
		}
		public static void Tab(LevelEditor levelEditor, bool reverse)
		{
			Core.LogMethodCall();

			List<InputField> fieldList = fieldLists[levelEditor.currentLayer]; // Can't use yet: 1. Your own lists aren't filled out yet; 2. Not sure how to access the stuff that goes on those lists; 3. Need to test with vanilla stuff anyway.
			InputField oldFocus;

			try
			{
				oldFocus = ActiveInputField(levelEditor); // May cause NullRef
				logger.LogDebug("Active Field: " + oldFocus.name);

				if (!reverse)
					levelEditor.inputFieldList[levelEditor.inputFieldList.IndexOf(oldFocus) + 1].ActivateInputField();
				else
					levelEditor.inputFieldList[levelEditor.inputFieldList.IndexOf(oldFocus) - 1].ActivateInputField();
			}
			catch
			{
				levelEditor.inputFieldList[0].ActivateInputField();
			}

			logger.LogDebug("ActiveInputField: " + ActiveInputField(levelEditor));
		}
		public static void ToggleSelectAll(LevelEditor levelEditor, bool limitToLayer)
		{
			List<LevelEditorTile> list = null;
			string layer = levelEditor.currentLayer;

			#region
			if (layer == LEInterfaces_Walls)
				list = levelEditor.wallTiles;
			else if (layer == LEInterfaces_Floors)
				list = levelEditor.floorTiles;
			else if (layer == LEInterfaces_Floors2)
				list = levelEditor.floorTiles2;
			else if (layer == LEInterfaces_Floors3)
				list = levelEditor.floorTiles3;
			else if (layer == LEInterfaces_Objects)
				list = levelEditor.objectTiles;
			else if (layer == LEInterfaces_Items)
				list = levelEditor.itemTiles;
			else if (layer == LEInterfaces_Agents)
				list = levelEditor.agentTiles;
			else if (layer == LEInterfaces_Lights)
				list = levelEditor.lightTiles;
			else if (layer == LEInterfaces_PatrolPoints)
				list = levelEditor.patrolPointTiles;
			else if (layer == LEInterfaces_Level)
				list = levelEditor.chunkTiles;
			#endregion

			bool SelectingAll = false;

			foreach (LevelEditorTile levelEditorTile in list)
				if (!levelEditor.selectedTiles.Contains(levelEditorTile))
				{
					levelEditor.SelectTile(levelEditorTile, false);
					SelectingAll = true;
				}

			if (!SelectingAll)
				levelEditor.ClearSelections(true);

			levelEditor.UpdateInterface(false);
		}
		public static void ZoomInFully(LevelEditor levelEditor) =>
			GC.cameraScript.zoomLevel = 1f;
		public static void ZoomOutFully(LevelEditor levelEditor)
		{
			if (levelEditor.levelMode)
				GC.cameraScript.zoomLevel = 0.1f;
			else if (!levelEditor.levelMode)
				GC.cameraScript.zoomLevel = 0.4f;
		}
	}
}
