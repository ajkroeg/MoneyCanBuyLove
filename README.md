# MoneyCanBuyLove
Purchase faction rep in shops!

Mod adds the ability for store items to increase reputation. Each reputation "item" will alter faction rep by the amount defined in the mod.json settings. Reputation changes take place at the end of the current day, and reputation items are removed from inventory at this time.

Faction rep changes are based on the current star system ownerID (actually `CurSystem.Def.OwnerValue.FriendlyName`), NOT the shop owner ID.

```
"Settings": {
		"RepItemDefTypeAndID": "Item.HeatSinkDef.Gear_HeatSink_Generic_Standard",
		"excludedFactions": [
			"ClanJadeFalcon",
			"ClanWolf",
			"ClanGhostBear"
			],
		"RepModifier": 15,
		"MaxRepLimit": 20
		},
  ```  
`RepItemDefTypeAndID` defines the (custom, user-created) item which modifies reputation. User is responsible for creating said item and adding it to shops.

`excludedFactions` define faction(s) for which the player is unable to purchase reputation <i>even if the item appears in their store</i>. Players can purchase the items, but they will have no effect.

`RepModifier` defines the reputation change per-item purchased. Using the above settings, purchasing 2 `Item.HeatSinkDef.Gear_HeatSink_Generic_Standard` would result in a reputation increase of 30.

`MaxRepLimit` defines an upper limit for purchasable rep. Using the above settings, faction rep can increase to a max of 20 from the purchase of rep items. Players can continue to purchase rep items, but they will have no effect.
