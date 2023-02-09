﻿#nullable enable
using Terraria;
using Terraria.DataStructures;

#if TML_144
using OnPlayer = Terraria.On_Player;
#else
using OnPlayer = On.Terraria.Player;
#endif

namespace MagicStorage.Edits;

public class CatchExtraCraftsDetour : Edit
{
	public override void LoadEdits()
	{
		OnPlayer.QuickSpawnItem_IEntitySource_int_int += OnPlayerQuickSpawnItem_IEntitySource_int_int;
	}

	public override void UnloadEdits()
	{
		OnPlayer.QuickSpawnItem_IEntitySource_int_int -= OnPlayerQuickSpawnItem_IEntitySource_int_int;
	}

	private int OnPlayerQuickSpawnItem_IEntitySource_int_int(OnPlayer.orig_QuickSpawnItem_IEntitySource_int_int orig,
		Player self, IEntitySource source, int type, int stack)
	{
		if (!CraftingGUI.CatchDroppedItems)
			return orig(self, source, type, stack);

		Item item = new(type, stack);
		CraftingGUI.DroppedItems.Add(item);
		return -1; // return invalid value since this should never be used
	}
}
