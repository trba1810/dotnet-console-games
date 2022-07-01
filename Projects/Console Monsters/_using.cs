﻿global using System;
global using System.Linq;
global using System.Text;
global using System.Threading;
global using static Console_Monsters._using;
global using Console_Monsters.Maps;
global using Console_Monsters.Monsters;
global using System.Collections.Generic;

namespace Console_Monsters;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA2211

public static class _using
{
	#region Options
	public static bool DisableMovementAnimation = false;
	public static bool DisableBattle = false;
	public static bool DisableBattleTransition = false;
	public static bool FirstTimeLaunching = true;
	#endregion

	public static Character character = new();
	public static Map map = new PaletTown();
	public static DateTime previoiusRender = DateTime.Now;
	public static int maxPartySize = 6;
	public static bool gameRunning = true;
	public static bool startMenu = true;
	public static bool inventoryOpen = false;
	public static List<MonsterBase> ownedMonsters = new();
	public static List<MonsterBase> activeMonsters = new();

	public static readonly string[] maptext = new[]
	{
		"Move: [← ↑ → ↓] / [W A S D]",
		"Interact: [E]",
		"Monster Status: [Enter]",
		"Inventory: [Backspace]",
		"Pause: [Escape]",
	};

	public static readonly string[] battletext = new[]
	{
		"Battles are still in development.",
		"Press [enter] to continue...",
	};

	public static readonly Dictionary<Items, (string Name, string Description, string Sprite)> ItemDetails = new()
	{
		{ Items.CaptureDevice, ("A Monster Capture Device", "Used to trap and store monsters", Sprites.CaptureDevice)},
		{ Items.HealthPotion,  ("A Health Potion", "Used to restore hp to monsters", Sprites.HealthPotion)},
	};

	static _using()
	{
		map = new PaletTown();
		var (i, j) = Map.FindTileInMap(map, 'X')!.Value;
		character = new()
		{
			I = i * Sprites.Width,
			J = j * Sprites.Height,
			Animation = Sprites.IdlePlayer,
		};
	}

	public static void PressEnterToContiue()
	{
	GetInput:
		ConsoleKey key = Console.ReadKey(true).Key;
		switch (key)
		{
			case ConsoleKey.Enter: return;
			case ConsoleKey.Escape: gameRunning = false; return;
			default: goto GetInput;
		}
	}
}

#pragma warning restore CA2211
#pragma warning restore IDE1006 // Naming Styles
