﻿#			How to read this
If you wandered in here out of curiosity, this is my working notes file, and completed/planned feature list. It's a markdown file, but best viewed in raw form since a lot of its organization has to do with text characters' alignment.

Listed in order of Parent tier summary symbol priority:
	C, T = Code this, Test this
	H = Hold, usually pending resolution of a separate or grouped issue
	√ = Fully implemented feature or group of features

#			Scope
##		P	Bugs
Except crickets. Crickets are fine.
###				C	Ammo Cap Bug
Still reducing on pickup
###				H	Equipment noise spam
Still occuring, even with vanillas.
For now, just disabling the noise if they switch to Fist.
###				H	Dismissed Perm Hire prevents Temp Hire
Can't temp hire after dismissing perm hire. 
This is MINOR, I don't care.
###				H	CCU Trait section in Load Character screen
Shows outdated traits when choosing
Don't really care yet.
###				H	Johnny Stabbs
Hold - Unable to replicate

Has Fac Blahd Aligned (replaced by Legacy)

On attempt Load from stored chars list, get error and no load:

	[Debug  :CCU_Legacy] Caught Legacy trait: Faction_Blahd_Aligned
	[Error  : Unity Log] NullReferenceException: Object reference not set to an instance of an object
	Stack trace:
	MenuGUI.TextChangedCharacterDescription () (at <3d326b8e9c744e5faf3a706691682c89>:0)
	UnityEngine.Events.InvokableCall.Invoke () (at <a5d0703505154901897ebf80e8784beb>:0)
	UnityEngine.Events.UnityEvent`1[T0].Invoke (T0 arg0) (at <a5d0703505154901897ebf80e8784beb>:0)
	UnityEngine.UI.InputField.SendOnValueChanged () (at <d5bb9c19c2a7429db6c6658c41074b11>:0)
	UnityEngine.UI.InputField.SetText (System.String value, System.Boolean sendCallback) (at <d5bb9c19c2a7429db6c6658c41074b11>:0)
	UnityEngine.UI.InputField.set_text (System.String value) (at <d5bb9c19c2a7429db6c6658c41074b11>:0)
	CharacterCreation.LoadCharacter2 (System.String characterName, System.Boolean secondTry, System.Boolean foundFile, System.Object mySaveObject) (at <3d326b8e9c744e5faf3a706691682c89>:0) 
	...
###				H	Clone changing appearance
Shelving this because I simply don't care enough to fix it yet. This is super-niche.
Buddy Cop Loneliness killer
The one that showed up on level 2 was identical to me
The one that came from level 1 rerolled appearance
###				H	Eyes Strings error
Between Accessory & Body Type, current logs are uninterrupted
Shelved - no apparent effect for this error.
###				H	Loadout error
Consistently, the Crepe Heavy has this error.
	[Info   : Unity Log] SETUPMORE4_7
	[Debug  :CCU_LoadoutTools] Custom Loadout: Custom(Crepe Heavy)
	[Error  : Unity Log] Couldn't do ChooseWeapon etc. for agent Custom (1132) (Agent)

This error is from LoadLevel.SetupMore.
But since there doesn't appear to be any actual repercussion on gameplay, I'm shelving it until it is an issue.
###				H	Upper Crusty Busybody 
Polices pickup and destruction of 0-Owner ID items and objects, and no others.
After reloading, was unable to replicate this.
###				H	Jukebox Hacks
Possibly RogueLibs, wait for confirmation.

Mambo:
	[Error  : Unity Log] NullReferenceException: Object reference not set to an instance of an object
	Stack trace:
	Turntables.PlayBadMusic () (at <7fd7dd1709b64c98aabccc051a37ae28>:0)
	RogueLibsCore.VanillaInteractions+<>c.<Patch_Turntables>b__68_2 (RogueLibsCore.InteractionModel`1[T] m) (at <ac95cf0d3a8543748b4a19536e8724e6>:0)
	RogueLibsCore.SimpleInteraction`1[T].OnPressed () (at <ac95cf0d3a8543748b4a19536e8724e6>:0)
	RogueLibsCore.InteractionModel.OnPressedButton2 (System.String buttonName) (at <ac95cf0d3a8543748b4a19536e8724e6>:0)
	RogueLibsCore.InteractionModel.OnPressedButton (System.String buttonName) (at <ac95cf0d3a8543748b4a19536e8724e6>:0)
	RogueLibsCore.RogueLibsPlugin.PressedButtonHook (PlayfieldObject __instance, System.String buttonText) (at <ac95cf0d3a8543748b4a19536e8724e6>:0)
	Turntables.PressedButton (System.String buttonText, System.Int32 buttonPrice) (at <7fd7dd1709b64c98aabccc051a37ae28>:0)
	ObjectReal.PressedButton (System.String buttonText) (at <7fd7dd1709b64c98aabccc051a37ae28>:0)
	WorldSpaceGUI.PressedButton (System.Int32 buttonNum) (at <7fd7dd1709b64c98aabccc051a37ae28>:0)
	ButtonHelper.PushButton () (at <7fd7dd1709b64c98aabccc051a37ae28>:0) 
	ButtonHelper.DoUpdate (System.Boolean onlySetImages) (at <7fd7dd1709b64c98aabccc051a37ae28>:0)
	ButtonHelper.Update () (at <7fd7dd1709b64c98aabccc051a37ae28>:0)
Bladder:  
	[Error  : Unity Log] NullReferenceException: Object reference not set to an instance of an object
	Stack trace:
	Turntables+<BadMusicPlayTime>d__31.MoveNext () (at <7fd7dd1709b64c98aabccc051a37ae28>:0)
	UnityEngine.SetupCoroutine.InvokeMoveNext (System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress) (at <a5d0703505154901897ebf80e8784beb>:0)
###				H	$0 in container
https://discord.com/channels/187414758536773632/1003391847902740561/1007975536607383574
Maxior - Shelf w/ $0 as container, but not Trash Can
So far, unable to replicate
#		CT	Projects
##			C	Enclave System
It's best to work on these piecemeal: mutators, traits, agents. Then combine them when the parts are complete.
###				C	Currency Changing
If you want different currencies, you'll need new ways for players to change it.
####				C	Trait: Behavior - Moneychanger
Cost Scaled
###				C	Enclave: Concrete Jungle
####				C	Agent: Bananamonger
Human vendor, speaks English and Goryllian, spawns with a Vendor cart. Sells bananas at a good price. Great place to change your currency.
####				C	Agent: Cheeky Monkey
Hides in the bushes, pickpockets. Like thieves but even more fucking annoying.
####				C	Currency: Banana
Yeah
####				C	Feature: Banana Vendor
One of the only vendors who takes cash. Sells at a good price. Great place to change money.
####				C	Floor Type: Grass
Yeah
####				C	Laws: Only Bitch Crimes are Illegal
Theft
Vandalism
etc.
Ritual Combat is respected as your right.
####				C	Wall Type: Concrete
Yeah
###				C	Enclave: District 69
####				C	Agent: Nordic
####				C	Agent: Reptilian
####				C	Agent: Small Grey
####				C	Agent: Glorbrax
Secretes alcohol in exchange for raw Moneys
####				C	Currency: Booze
####				C	Floor Type: Steel
####				C	Laws: 
Highly cosmopolitan, no tolerance of slavery...? 
Or maybe factionalized, with highly varying rules according to the chunk
Or maybe their laws are configured to treat you like a test subject.
####				C	Law Enforcers
Apprehension Ray is hard to hit, but teleports you immediately to jail
###				C	Enclave: Necropolis
####				C	Agent: Bloodslave
They don't even complain anymore
####				C	Agent: Necromancer
Expert hire, Can revive any dead agent for hire
####				C	Agent: Ghoul
Feral, eat corpses, hostile but cowardly
####				C	Agent: Sangrist
Currency Changer
####				C	Agent: Z-Rancher
Sells trained zombies, but that's way too OP
####				C	Currency: Blood
####				C	Feature: Canals
Catacomb vibe?
####				C	Floor Type: Dungeony stone
####				C	Wall Type: Brick
###				C	Enclave: Little Foreignia
The most normal of the Enclaves. Nearly identical to vanilla, but people speak Foreign.
###				C	Enclave: Werewales
Um
###				C	Enclave: Haywood & Mt. Blair 
This enclave's special challenge is that it's almost fully dominated by a single powerful faction, the Union.
The mob has a presence here, but the Union is generally not dirty. Generally.
Union refugees were the last group let inside the City before it completely sealed itself off from the outside world. They had missed the deadline, but brought so much important cargo that an exception was made. The shipping containers brought in in that refugee influx are still in use as small buildings. Their trucks ("Rigs") were broken down for parts, but the district retains the name.
####				C	Law: Seniority
Agents with the Old trait start out Friendly with the Law. They paid their dues.
####				C	Faction: Union
A French Vanilla faction, where members generally have Class Solidarity, No In-Fighting, and Confident in Crowds. 
They generally carry tools, power tools, and protective equipment. They don't carry the big guns, but make up for it in solidarity.
Outside Union Town, the Union is still pretty powerful. 
Cops and Firefighters are Union-Aligned, but not vice-versa.
####				C	Agent: Scab
New
####				C	Agent: Fink
Pinkertons
##			C	Language (Overhaul)
###			C	00 Mutator: Our Town
- NPCs have a chance to speak a foreign language
  - If a shopkeeper or bartender speaks a second language, generate a Neon Sign in front of their business in that language (we can dream, right?)
- NPCs have a chance to have Vocally Challenged
  - If they do, they always have at least one foreign language
- Some people become Friendly if you interact in a non-English language. Chance is higher if they don't speak English.
- Enables Polyglot trait choice
- Gives the Translator an actual reason to exist
- All hired agents can act as translators
- Every District has a set of Our Town mutators (below) that may trigger on level 2 of the district.
###			C	00 Our Town Non-Disasters
Gated behind Language System Mutator
Shifts the population so that about 66% are speakers, and one third - 1 half of those don't speak English.
Or you know what, make an overhaul mutator mapped to each class. That's what this is turning into.
- Concrete Jungle (Monkese)
- District 69 (ErSdtAdt)
- Little Faraway (Foreign)
- Meltingpot District (Even distribution of all language groups)
- Werewales (Werewelsh)
- Brainard (Lang Zonbi)
##			H	Config Files
###				Custom Flag list
Allow player to name booleans uniquely.
These should be grouped by Campaign, since that's the only place they're valid.
The config file should match the name of the campaign, if they allow the same characters.
###				Custom Level Tag List?
Not so sure about the utility of this. I don't think players should need more than 4 level tags.
- Whenever you have enough in the campaign to make it playable, test it in Player Edition and see if the experience is the same.
##			C	Relationship Refactor
###				C	Create SetRelationship(agent, otherAgent, VRelationship)
Current state is embarrassing 
##			C	Explosion Trait Refactor
Current Setup:
	Explode on Death
Proposal:
	Event Type
		Align
		Cry
		Die
		Drop Items
		Explosion (All existing types)
		Flee Level
		Hostile
		Path to Panic Room
		Random Teleport
		Reset Releationships
		Ruckus
	Event Delay
		Existing Explode on Death "Fuse" traits
		From Mac:
			[random] trigger only occurs 25% of the time. multiplicative with other [random]s
			[random] trigger only occurs 50% of the time. multiplicative with other [random]s
			[random] trigger only occurs 75% of the time. multiplicative with other [random]s
			[random] include duds for limits: failed random rolls count towards [limits]
			[random] only rolled once: the random roll is only cast once, at the start of the level, and the NPC will consistently always fail or succeed depending on that one roll.
			[limits] Only Once: Can only trigger once.
			[limits] Only Player: Only triggers if the triggerer was a player
			[limits] Only NPC: reversed Only Player
			[Special Interact Button] Only Aligned: Only available to aligned/hire-er agents.
			[Special Interact Button] Costs Money: The interaction costs money. All money- related traits apply.
			[Special Interact Button] Goto Agent/Object: Allows you to target an NPC or object. The Agent will then travel to there and trigger the event
			Apply to triggerer: apply all event effects to the triggerer instead of you
	Event Trigger
		Align
		Combat
		Committed Crime
		Damage Dealt
		Damage Taken
		Death
		Exit Level
		Interact
		Interact Option (named after Event Type)
		Join Party
		Out of Ammo
		Search
		Spawn
##			C	Door System
###				C	Keycard System
Red, Blue, Green, Yellow
Work only on Keycard Doors and Keycard Safes
####				C	Access Scope
Determines how far the keycard will work. Doesn't have to use every tier of this, just being expansive.
	Chunk
	Chunk Type
	Level
	District
	City
	Mayor Village
	All
####				C	Access Level
Configurable in Keycard and Keycard Door
####				C	RFID Flipping
If someone is holding a Keycard, you can grab their card's RFID signal to add it to your keyring. 
This can be done in the manner of a normal hack, or with a Signal Grabber passive inventory item - no interaction required, but shorter range. Good tool for the undercover.
####				C	Keycard Doors
#####					C	Hack
- Admit Owners*
- Admit Non-Owners
- Admit No One
- Admit All
- Something Mischievous
- Trigger Alarm
- Turn Off/On
#####					C	Tamper
- Disconnect (a la Security Camera)
#####					C	Automatic Door option
This would be neato
###				C	Key Ring System
Keys are specific to an object. One door, one chest, etc. so chunks may generate with multiple. 
Desk is a lockable container.
####				C	Keyring
Keyring stores all keys in one slot
##			H	Stash System
On hold: Complete the Key/SafeCombo aspect of Containers first.
Locked + Keycoded really only apply to Desk. They might easily be left out of this system.
Variable field in editor, maybe with some basic setting variations (destructible, Investigateable, etc.)
Locks access to the object as a Chest unless the player holds the matching Stash Hint.
You don't know the object holds an item until you find the Stash Hint item somewhere. This could be in an Agent's inventory, or hidden elsewhere in the chunk. 
###				C	Item: Stash Hint
Generates on NPC inventory or in a container in their chunk 
Acts like a key, but when activated the agent will read text out loud that's specific to a Container type
This will be EXTREMELY annoying with Gravestones, which is kinda funny
##			C	Sugar System
Merchant Type: Sugar Shack √
Passive: Keep Moving (Acts like Stinger, but doesn't betray you. Red herring)
Passive: Stinger (Calls cops and flees level if you sell or buy contraband)
And also the entire Drug Dealer mod series.  
##			√	Legacy Name Updater
CharacterCreation.LoadCharacter2
###				H	Challenges
This needs testing but I don't think anyone really used those mutators yet
###				√	Traits
####				√	Designer Side
P_Unlocks.GetUnlock_Prefix
####				√	Player Side 
P_StatusEffects.AddTrait_Prefix
##		H	Trait Utilities 
###			!	Collapsible Groups
The BunnyMod content has been found and integrated into the attempts. No need to go back to it.
After numerous attempts I'm shelving this for 1.1.0, though it remains a top UI priority.
###			C	Reactive coloration
Color 1 - Group headers 
Color 2a,b,c - Group contents, HC1 HC2 HC3 etc. 
Color 3 - Select All toggle for group
Ideally, right-clicking a group header would toggle un/select all but that's a stretch
###			C	Flexible Descriptions
Make a "Flex text" generator that will check DE/PE and return description based on that. Hidden info available to only Designers, where relevant
###			C	Reactive Descriptions
Hopefully there's a way to live-update descriptions. It would be cool to see a chart of loadout chances, for example.
###			H	Free Real Estate
Freeze text size in TallyText
Enable Scrollbar
This got a nullref:
	Scrollbar scrollbar = CC.pointTally.Find("Scrollbar").GetComponent<Scrollbar>();

So success may depend on our ability to make a new prefab from just code. Probably not possible.
#		C	Agent Goals 
##			CT	Default Goals
###				C	Ambush
Hide behind object on same tile, if possible
###				C	Commit Arson
New
###				C	Frozen
###				C	Frozen (Permanent)
###				C	Robot Clean
DW
###				C	Teleport (Private)
New
###				C	Teleport (Anywhere)
New
###				√	Arrested
Complete
###				√	Burned
Complete
###				√	Dead
Complete
###				√	Gibbed
Complete
###				√	Knocked Out
Complete
###				√	Random Teleport
Complete
#		√H	Items
##				√H	Class-A-Ware
It might be cool for these two bars to be *left* of the readout data.
###				H	ScrollBar
These didn't work:
            Owner.mainGUI.scrollingMenuPersonalScript.scrollBarDetails.gameObject.SetActive(true);
            Owner.mainGUI.scrollingMenuPersonalScript.scrollBarPersonalDetails.gameObject.SetActive(true);
###				H	Battery Readout
Power bar with warning "Replace Battery"
If you do three rows you could make it look like a battery but you don't have that kind of space
###				H	Memory Readout
Also a bar 
#		C	Level Editor Interface
##		C	Item Groups
Transpile List creation in LevelEditor.CreateExtraVarsStringChestList
Get list of groups from FillItems
#		C	Traits
##		C	Accent Color
Combine w/ Accent Effect traits
##		C	Accent Effect
Apply Accent Color trait to target effect
###			C	Agent Glow
Killer Robot has this
###			C	Monocolor Agent
E.g., if White is selected, they should look like a Greek Statue or whatever.
###			C	Nametag (Space/hover)
###			C	Vision Beam
New
##		C	Agent Group
However this is implemented, there's a danger of subscribed content doing this in an unwanted way. How to control it?
###			C	Slum NPCs (Pilot)
New
###			C	Affect Campaign
Pending pilot
###			C	Affect Vanilla 
Pending pilot
###			C	Roamer Level Feature
New
##		C	Appearance
###			C	Sprite sizers
Wide/narrow, tall/short body
Long/short legs
Big/small head
Big/small eyes
Big/small hands
###			C	Cloneliness Killer
Loneliness Killer spawns should vary in appearance
This would be a Free Trait, in a category of their own. No limit, 0 points. A subcategory of Player Traits
###			C	GC1 - Glove Color
Never know until you try! This might just be as simple as a Glove trait that matches them to body color. This shouldn't be a big elaborate category.
###			H	General Traits
####			C	Cloneliness Killer
Clones roll appearance
####			H	Static Preview
New
###			√	AC1 - Accessory
####			√	No Accessory 50%
Complete
####			√	No Accessory 75%
Complete
###			√	BC1 - Body Color
Complete
###			√	BC3 - Body Color Special
####			√	Shirtless
Complete
####			√	Shirtsome
Complete
###			√	BT1 - Body Type
Complete
###			√	BT2 - Body Type Greyscale
Complete
###			√	EC1 - Eye Color
Complete
###			√	EC3 - Eye Color Special
####			√	Beady-Eyed
###			√	ET1 - Eye Type
####			√	Normal Eyes 50%
Complete
####			√	Normal Eyes 75%
Complete
###			√	FH1 - Facial Hair
####			√	No Facial Hair 50%
Complete
####			√	No Facial Hair 75%
Complete
###			√	HC1 - Hair Color
Complete
###			√	HC2 - Hair Color Grouped
Complete
###			√	HC3 - Hair Color Special
####			√	Melanin Mashup
Complete
####			√	Matched Masks
Complete
####			√	Uncolored Masks
Complete
###			√	HS1 - Hairstyle
Complete
###			√	HS2 - Hairstyle Grouped
Complete
###			√	HS3 - Hairstyle Special
####			H	General Mask/Accessory compatibility
Might need to make a Dict<string, string[]> of these two sets, since compatibility seems to vary for each.
####			√	Mask Override (Rename)
Complete
####			√	Masks 50%
Complete
###			√	LC1 - Legs Color
Complete
###			√	LC3 - Legs Color Special
####			√	Pantiful
Complete
####			√	Pantsless
Complete
####			√	Pantsuit
Complete
###			√	SC1 - Skin Color
Complete
###			√	SC3 - Skin Color Grouped
Complete
##		C	Behavior
###			C	Absconder
Once hostile to a player, flees to exit elevator
###			C	Ambush
Clearer way to present "Secretly Hostile" relationship, especially since it's not even a relationship
How a Bounty Ambusher is set up:
	agent.bountyHunter
	agent.bountyHunterProjectileWeapon
	Relationships.SetSecretHate
		You should remove this from the Player Relationship algo, since it would interfere with this behavior opaquely
	Relationship.SecretHate
		Note that it's on Relationship (singular), meaning you'll have to find the particular rel
###			C	Hide & Ambush
Always attacks player when near
###			C	Hide & Wait
Hides in bush but does default. Will ambush only if hostile.
###			C	Arsonist
Arsonist behavior
###			C	Bio-Terrorist
Poison a random vent or pump
###			C	Clean Trash
New
###			C	Consumer
Visits vending machines and merchants
###			C	Corpse Destroyer
Gibs enemies' corpses
###			C	Curious
Investigate noises like cop & shopkeeper
###			C	Fight Fires
Agent.firefighter
Agent.fightsFires
###			C	First Aider
Revives Aligned if they can within a certain timer
###			C	Grab Weapons
New
###			C	Grab Contraband
New
###			C	Heister
Picks a chest on the level, and tries to fight their way to loot it. 
If successful, deactivates behavior.
###			C	Hobo Beg (Custom)
Maybe just implement the whole Hey, You! overhaul here
###			C	Hog Turntables
Allow paid Musician behavior
###			C	La Migra / Deportable
Should also spawn Deportation Center (See SORCE)
###			C	Mad Bomber
Place a Time Bomb in a public toilet
###			C	Mutinous
Agent.mutinous
###			C	Needy
Will seek out Musician need objects and operate them
###			C	Neer-do-well
Intentionally breaks laws (vandalism, etc.)
###			C	Outlaw
Ignores Law mutators
###			C	Panic Room User
Uppercruster?
###			C	Paranoid
Constant search state
###			C	SecretHate
Agent.secretHate
Agent.choseSecretHate
I think this is Bounty behavior
Didn't work but if you get it working it should be under Behavior - Ambush, since that will make more sense to users.
###			C	Shakedown Player (Mobster)
New
Use this on leader w/ Wander Level
Use "Follow" behavior on agents placed behind them
No need for "Roaming Gang" Trait itself###			C	Sleepyhead
Will default to finding a bed to sleep in, returning even after combat.
###			C	Slowpoke
Takes a longer time to react to everything
###			C	Solicitor
Knocks on non-restricted locked doors, tells a joke that automatically annoys whoever answers the door moves on after a pause
###			C	Stop & Frisk
Should also spawn Confiscation Center (See SORCE)
###			C	Suicidal
Walks into hazards, only those they can see
###			C	Tattletale (Upper Cruster)
New
###			C	Vandal
Destroys public objects or Windows on a whim
###			C	Vigilante
See if there's any use for Agents who enforce laws but aren't agent.enforcer
###			C	Works for Tips
Will "mug" you for a tip after any transaction
###			√C	Accident-Prone
Works for: Crusher, Fire Spewer, Saw Blade
####			C	Slime, Floor Trigger, ??
New
###			H	Concealed Carrier
Main feature complete
Will be affected by Laws & Outlaw
###			√	Brainless
Complete
###			√	Eat Corpse
Complete
###			√	Grab Alcohol
Complete
###			√	Grab Drugs
Complete
###			√	Grab Everything
Complete
###			√	Grab Food
Complete
###			√	Grab Money
Complete
###			√	Pickpocket
Complete
###			√	Seek & Destroy (Killer Robot)
Complete
####			√	Blinks on Death
Complete
##		C	Campaign Flags
Might need to limit this to a single flag, since having multiple true at the same time would complicate things
###			C	If Paid then Flag A/B/C/D True
New
###			C	If Killed then Flag A/B/C/D True
Etc.
##		H	Combat
###			C	Ca-Caw!
Crepe/Blahd call all nearby of same class
Do this, for same class/superclass, and for faction
###			C	Taunt
Exaggerate threat for hostiles
###			H	Nth Wind
Refreshes Drug Warrior & Backed Up bools after combat ends.
P_GoalCombatEngage.
	Terminate_Postfix
P_StatusEffects.
	Resurrect	
###			H	Backed Up
P_GoalBattle.
	Process_StartCombatActions
	DoCombatActions
Test: 
	[Error  : Unity Log] AI Update Error: Custom (1124) (Agent)
	Repeated on loop.
IIRC this error comes from a try-catch chain that can be sort of a pain to break open. For that reason I'm shelving this.
###			H	Gloater
Will dance on corpses and make loud noise if they win a combat
This one's kinda hard... Probably on hold for now.
###			H	Lockdowner
Apparently Lockdown walls are broken in custom levels.
###			√	Coward
Complete
###			√	Fearless
Complete
##		C	Combat Patterns
###			C	Airstriker
Constant airstrike on enemy during combat
###			C	Chaaaaarge! 
Doable without special?
###			C	Fireworks Show
Random rockets, maybe sped up
###			C	Rocket Barrage
##		C	Combat Pattern Modifiers
For Boss-style multi-attacking NPCs
###			C	Choose Cycled Pattern
Repeats selected pattersn in a cirlce
###			C	Choose Random Pattern
Selects a random different pattern from all added
###			C	Pattern Interval 1
###			C	Pattern Interval 2
###			C	Pattern Interval 3
###			C	Pattern Interval 4
###			C	Pattern Trigger Allies Killed
###			C	Pattern Trigger Damage Taken
###			C	Pattern Trigger Health Threshold
##		C	Cost Currency
###			C	00 Button ExtraCost Display
Bananas & alcohol are hardcoded
To display them correctly, prefix WorldSpaceGUI.ShowObjectButtons (interprets magic numbers)
###			C	Banana
Test
###			C	Barter
Stretch goal, obv complicated
###			C	Blood
Blood Bags always an option
If Vampirism, allow drink
###			C	Booze
A la Bouncer
###			C	Flesh
Require Cannibalism? Maybe not
##		C	Drug Warrior
###			C	Feature: Werewolf Transformation compatibility
Not a bug, sorry
###			C	Feature: Apply multiple effects at once
This will be a little harder than expected. 
Try a prefix to GoalBattle.Process, but still use the vanilla flags to prevent redundancy.
###			C	Extendo-Wheels
Gain Roller Skates
###			C	Suicide Bomber
Initiate a 15s timer, then detonate a Huge explosion
Interface with Timer traits and Explosion traits to allow player to customize
###			C	Sweaty
Gain Wet, lmao
##		CT	Drug Warrior Modifiers
GoalBattle.Process is where the effect is applied.
###			√	Suppress Syringe AV
Complete
###			C	Extended Release
This might have differing effects on status effects. E.g., Fainting Goat Warrior might never trigger.
###			C	Eternal Release
New
###			C	One for the Road
Effect triggers when they would flee instead of at beginning of combat
####			C	Extended Release interaction
When paired with ER, the effect lasts until they would no longer be intimidated. 
###			C	Post Warrior
Effect triggers on end of threat (Regenerate, smoke, invisible)
###			C	High on Pain
Effect gains 1s of duration on taking damage
###			C	Take the Thrill Kill Pill
Effect gains 1s of duration on dealing damage, extra on kill
##		C	Explode On Death
System still works after minor refactor.
###			H	00 Doesn't trigger when exploded
Rocket launcher kill just gibbed them
This is vanilla behavior (See StatusEffects.ExplodeAfterDeathChecks). Only fix if there's an uproar.
###			H	Oil Spill
Shelved
Explosion.SetupExplosion ~373
DW:
	[Info   : Unity Log] ADDRELHATE: Custom (1134) (Agent) - Playerr (Agent)
	[Info   : Unity Log] SpawnExplosion -1
		No error message, but that's not a good thing
###			C	Monke Parasites
Explodes into Monke (barrel style)
###			C	Thoughts & Prayers
Fireworks
###			C	Oil Spill
This doesn't exist but should follow water logic. Plus there are many other uses.
###			C	Ooze
Only did particle effect
###			C	Ridiculous
Only did particle effect, didn't end slow-mo, no kills.
This is the Bomb disaster one, so it will need special attention.
###			C	Slime
Does particle effect and poisons
Do the sprite later.
###			C	Stomp
Did particle effect
Pushed body away
Didn't stun anyone
###			H	00 Does not explode when killed with Cyanide
There's no vanilla precedent for this particular situation, so let's see what users prefer.
###			H	00 Explodes when Arrested
Not too concerned, considering this is vanilla for Slaves.
###			√	Big
Complete
###			√	Dizzy
Complete
###			√	EMP
Complete
###			√	Firebomb
Complete
###			√	Huge
Complete
###			√	Noise Only
Complete
###			√	Normal
Complete
###			√	Warp
Complete
###			√	Water 
Complete
###			√	Cop Bot not Exploding
Complete
###			√	Certain explosion types don't delete body
P_StatusEffects_ExplodeBody.DisappearBody
###			√	Gib body
P_StatusEffects_ExplodeBody.GibItAShot
##		C	Explosion AV
###			C	Suppress Red Blink
No red blink before explosion
P_StatusEffects.ExplodeAfterDeathChecks transpiler for this.agent.objectSprite.FlashingRepeatedly
###			H	Cinematic Timer
Pending Ridiculous Explosion
##		C	Explosion Timer
Vanilla for EOD is 1.5 seconds
###			H	Cinematic Fuse
Pending creation of Ridiculous explosion.
###			√	Long Fuse
2x
###			√	Longer Fuse
3x
###			√	Longest Fuse
4x
###			√	Short Fuse
0.66x
###			√	Shorter Fuse
0.33x
###			√	Shortest Fuse
0.00x
##		C	Explosion Trigger
###			C	Combat Start
New
###			C	Death
New
###			C	Low Health
New
###			C	Spawn
This is more of a utility, to allow designers to explode or burn things at level start.
##		H	Gib Type
###			C	Robot Gibs
Need sprites :(
###			C	Wood
For use with Leaves, once they can combine into one
###			√	Ectoplasm
Complete
###			√	Gibless
Complete
###			√	Glass Shards
Complete
###			√	Golemite
Complete
###			√	Ice Shards
Complete
###			√	Leaves
Complete
###			√	Meat Chunks
Complete
##		C	Hack
###			C	00 Interrupts
Works with Electronic, but hacking bar is interrupted
###			C	Align
New
###			C	Explode
New
###			C	Free Transactions
New
###			C	Give Inventory To Player
New
###			C	Give Single Order
As if they were follower
This includes Expert actions, like Lockpick, etc... but maybe not Hack, since chaining hacks might be a can of worms
###			T	Go Haywire
Attempted
###			C	Increase Odds of Winning
For gambling bots
###			C	Increase Buyer Prices
For Buyer traits
###			C	Join Party
New
###			C	Make Noise
A la arcade machine
###			C	Play Bad Music
Busker?
###			C	Reduce Prices
New
###			C	Security Cam/Turret Options
New
###			C	Security Core
All Security Hack options
###			C	Spit Out Money
A la ATM
###			T	Tamper With Aim
Attempted
###			C	Triangulate
Head towards hacker when interactFar starts
AgentInteractions.HackSomething in CopBot block
###			C	Triangulate for Network

###			C	Unlock Safes & Doors
Maybe set it so they all unlock on death too, or make a separate Unlock All On Death trait.
###			C	Buy Round for Allied
Buy a round for a patron and anyone with the same owner ID in the chunk.
No drink for that guy in the corner. Fuck that guy.
###			C	Buy Slave
Pending actual assignment of owned slaves 
###			C	Clone (Group)
####			C	Clone Player
####			C	Clone Random Character (Separate from Hack function)
####			C	Clone Item
####			C	Clone Target Character
###			H	Cybernetics (Group)
This would be an overhaul
Get Eric's cybernetic traits as a start
####			H	Implant
New
####			H	Remove
Some are simply negatives, acquired or from spawn
####			H	Repair
New
###			C	Deactivation Protocol
Try to hack an Electronic agent in-person via vocal injection attack
###			C	Faction (Group)
####			C	Pay respects to Faction
Costs $1,000 to bump reputation up one level (Hostile → Annoyed etc)
"Improve Faction Relations"
Should only allow for 1 of these to simplify algorithm
But this means you'll need further faction traits
####			C	Sell Intel to Faction 
The idea is, if you were really on their side you wouldn't charge for information. 
Reverse of buying into faction. Just a way to get cash in exchange for slightly reducing your relation. Friendly or better.
###			C	Gamble
####			C	All-In
High risk, high reward
####			C	Bluff
Uses your social skill isntead of luck?
####			C	Cheat
Uses your stealth skill instead of luck
####			C	Play it Close
####			C	Risky Bet
####			C	Safe Bet
####			C	Sore Loser
###			C	Heal (Group)
####			C	All
Like Doctor heal, but all in party with calculated price
####			C	Other
Like Doctor heal, but activates reticle so you can select a party member or other.
####			C	Partial
Like Doctor heal, but at a Blood Bag level.
####			C	Mouseover Price
Show price to heal targeted agent before selection
###			C	Item Storage
A la ATM
"Smuggler?"
###			C	Quest Giver
New
###			C	Real Estate Agent
####			C	Buy Property
($500): Next level, one chunk (Bar, nightclub, Shop, etc.) will have its owners Submissive to you. You gain a $100 passive income that may be reduced if the chunk is damaged.
####			C	Pump & Dump
($250): Boost up a local business, only to pull the rug out from under the suckers! Next level, one chunk (above types) will be Hostile to you. You get a single payment of up to $375, depending on how much the chunk is damaged. Doing this three times will give you Ideological Clash.
####			C	Sell Property
Lose your smallest owned property income. Immediately gain twice its return amount. Rant about taxes.
###			C	Refill/Repair (Group)
####			C	Refill Guns
New
####			C	Repair Armor
New
####			C	Repair Weapons
New
###			C	Sell Mystery Item
A la Goodie Dispenser
###			C	Start Election
New
###			C	Summon Professional
New
Pay a fee for him to teleport a Hacker, Thief, Doctor or Soldier to you. You still have to pay them to hire them.
###			C	Train (Group)
New
####			C	HP Gain
####			C	Stat Gain
New
####			C	Trait Gain
Sell traits for double their Upgrade Machine cost
#####				C	Defense
New
#####				C	Guns
New
#####				C	Melee
New
#####				C	Movement
New
#####				C	Social
New
#####				C	Stealth
New
#####				C	Trade
New
####			C	Trait Removal
New
####			C	Trait Swap
New
####			C	Trait Upgrade
New
###			√	Administer Blood Bag
Complete
###			√	Borrow Money
Complete
###			√	Borrow Money (Moocher)
Complete
###			√	Bribe Cops
Complete
###			√	Bribe For Entry (Alcohol)
Complete
###			√	Buy Round
Complete
###			√	Give Blood
Complete
###			√	Heal (Player)
Complete 
###			√	Identify
Complete
###			√	Influence Election
Complete
###			√	Leave Weapons Behind
Complete
###			√	Manage Chunk
####			√	Arena
Complete
####			√	Deportation Center
Complete
####			√	Hotel
Complete
###			√	Offer Motivation
Complete
###			√	Pay Debt
Complete
###			√	Pay Entry Fee
Complete
###			√	Play Bad Music
Complete
###			√	Use Blood Bag
Complete
##		C	Hire Damage Tolerance
###			C	Anyweather
Hiree will leave if a Hostile sees them
###			C	Fairweather
Hiree will leave if they're damaged in combat
"I didn't sign up for this! You're nuts!"
###			C	Foulweather
Hiree will never leave due to damage
###			C	Weather or Not
Use Mutiny timer for abandonment
###			C	Too Cool To Die
Agent can only be Knocked out, and can be revived
##		√	Hire Duration
###			√	Homesickless
Complete
###			√	Homesickness Enjoyer
Complete
###			√	Permanent Hire
Complete
###			√	Permanent Hire Only
Complete
##		C	Hire Trigger
###			C	On Use Altar
"Activate Servants"
###			C	On Use Podium
"Who's With Me?!"
###			C	On Release
"Damn, I loved prison"
###			C	On Sight
"Another Survivor!"
###			C	On Start
"They told me to meet you at the station."
##		C	Hire Type
###			C!	Loot
This should be for all followers period. This would un-softlock Bulky characters.
###			C	Interact
Any interaction option, target object.
Interaction choices are limited to theirs, not yours. This makes hired skills more useful (tech expert tampering, e.g.)
###			C	Chloroform
New
###			C	Cyber-Intruder (Up-Close)
No remote hack
###			C	Devour Corpse
New
###			C	Disarm Trap
New
###			C	Drink Blood
New
###			C	Hack
####			C	Cyber Nuke
Giving character Cyber Nuke allows Blow Up option, but it doesn't work
###			C	Handcuff
New
###			C	Mug
One-time use, mug target NPC
###			C	Pickpocket
New
###			C	Poison
New 
###			C	Safecrack
- Reticle does not activate 
	[Info   :  CCU_Core] DetermineButtons_Prefix: Hire
	[Info   :  CCU_Core] DetermineButtons_Prefix: Hire Order
	[Info   :  CCU_Core] PressedButton_Prefix: Method Call
	[Debug  :CCU_P_AgentInteractions]       buttonText: [CCU] Job - SafecrackSafe

Here's what comes up for Lockpick job:
	Agent
√		.GetCodeFromJob
√		.GetJobCode					Need to extend jobType enum
√		.ObjectAction
	AgentInteractions
√		.DetermineButtons
√		.LockpickDoor				
√		.PressedButton	
	GoalDoJob
√		.Activate					Check out 
√		.Terminate
	GoalDetails						E_GoalDetails
√		.LockpickDoorReal
	GoalLockpickDoor				GoalSafecrackSafe
√		.Activate
√		.Process
√		.Terminate
	GoalLockpickDoorReal			GoalSafecrackSafeReal
√		.Activate
√		.Process
√		.Terminate
	InvInterface
√		.ShowTarget					
√		.ShowTarget2
	ObjectMult
		.ObjectAction				Not sure yet - are these just logging messages, or are they important?
	PlayfieldObjectInteractions
√		.TargetObject

Objects to Analyze/track:
	Agent
		job
		jobCode
		target.targetType

In P_AgentInteractions.SafecrackSafe, I used JobType.GetSupplies as a placeholder until I figure out how to add to enums.
###			C	Set Explosive
On door or Safe: Plants door detonator
Elsewhere: Remote bomb
Gives you detonator when planted
###			C	Set Time Bomb
Based on and consumes Time Bombs in inventory. NPC starts with one.
###			C	Tamper
- Interface works but reticle is green for non-tamperable items.
  - Log message "Not implemented yet", fair enough
###			√	Muscle
Complete
###			√	Intruder
Complete
###			√	Decoy
Complete
###			√	Cyber-Intruder
Complete
##		C	Interaction
###			C	I'm Looking For...
Spooctus' idea: 
	Speaking to a front desk person or something, asking for an employee by name. Allows you to point at an NPC and summon them there. Doing this repeatedly will Annoy people.
###			C	Insider
Sell Key/SafeCombo/MayorBadge
Do as Interaction instead of shop,. 
###			C	Shitbird
Runs off with your money when you try to pay them for something, lol
###			C	Buy Slave
Pending actual assignment of owned slaves 
###			C	Cybernetic Surgery
Curated Trait-seller
###			C	Heal All
Like Doctor heal, but all in party with calculated price
###			C	Heal Other
Like Doctor heal, but activates reticle so you can select a party member or other.
###			C	Heal Partial
Like Doctor heal, but at a Blood Bag level.
####			C	Mouseover Price
Show price to heal targeted agent before selection
###			C	Quest Giver
New
###			C	Refill Guns
New
###			C	Repair Armor
New
###			C	Repair Weapons
New
###			C	Pay respects to Faction
Costs $1,000 to bump reputation up one level (Hostile → Annoyed etc)
"Improve Faction Relations"
Should only allow for 1 of these to simplify algorithm
But this means you'll need further faction traits
###			C	Sell Intel to Faction 
Reverse of buying into faction. Just a way to get cash in exchange for slightly reducing your relation. Friendly or better.
###			C	Start Election
New
###			C	Summon Professional
New
Pay a fee for him to teleport a Hacker, Thief, Doctor or Soldier to you. You still have to pay them to hire them.
###			C	This One's On Me
Buy a round for a patron and anyone with the same owner ID in the chunk.
No drink for that guy in the corner. Fuck that guy.
###			C	Train Attributes (Split to each)
New
###			C	Defense
New
Sell traits for double their Upgrade Machine cost
###			C	Guns
New
###			C	Melee
New
###			C	Movement
New
###			C	Social
New
###			C	Stealth
New
###			C	Trade
New
###			C	Visitor's Badge
Set Bribe options on separate traits
###			√	Administer Blood Bag
Complete
###			√	Borrow Money
Complete
###			√	Borrow Money (Moocher)
Complete
###			√	Bribe Cops
Complete
###			√	Bribe For Entry (Alcohol)
Complete
###			√	Buy Round
Complete
###			√	Give Blood
Complete
###			√	Heal (Player)
Complete
###			√	Identify
Complete
###			√	Influence Election
Complete
###			√	Leave Weapons Behind
Complete
###			√	Manage Chunk
####			√	Arena
Complete
####			√	Deportation Center
Complete
####			√	Hotel
Complete
###			√	Offer Motivation
Complete
###			√	Pay Debt
Complete
###			√	Pay Entry Fee
Complete
###			√	Play Bad Music
Complete
###			√	Use Blood Bag
Complete
##		C	Interaction Gate
###			C	Expansion request
Map Untrustings across Hire/Merchant/Service
There would only be nine, so this isn't TOO bad
###			C	Insular
Requires Faction Friendly
###			C	Insularer
Requires Faction Loyal
###			C	Insularest
Requires Faction Aligned
###			√	Untrusting
Complete
###			√	Untrustinger
Complete
###			√	Untrustingest
Complete
##		√	Inventory
###			√	Infinite Ammo
Complete
###			√	Infinite Armor
Complete
###			√	Infinite Melee
Complete
##		C	Language
###				C	Deaf
When deafness trait is added, add an ASL language. People with Vocally challenged automatically speak it. 
This will also slightly diversify Polyglot's progression.
###				C	French Vanilla Gibberish
Make Goryllian say Ook Ook if you don't understand it 
Agent.SayDialogue:
	string text = this.gc.nameDB.GetName(this.agentName + "_NonEnglish", "Dialogue");

transpile agentName value to custom agentName method that returns appropriate gibberish.
	If agent has multiple, have them pick a random one to speak gibberish from.
###			H	Mute (Rename)
No interactions under any circumstances, even with Translator
###			C	Polyglot
Gain 2 languages on trait gain, and an additional one every two levels.
If put on an NPC, those are randomly chosen.
####			C	Polyglot as Speaker +
Set as Upgrade for all Speaker traits
Also gives 2 languages on upgrade, not just 1. This is for consistency and so that it's actually worth upgrading.
####			C	Polyglot as Polyglot +
This is an interesting pattern that might be mirrored in other meta-traits. 
If they generally represent knowledge, then turn all knowledge skills into meta-traits. 
E.g. Medical Professional is split up into competencies with various healing items that have unique bonuses rather than just a flat HP gain.
####			C	Chance for Relationship Gain
Chance to make someone Friendly if they speak that language and not English
###			C	Telepathic (rename)
Can talk to all languages, even Mutes, unless they have some anti-telepathy trait or something
This could belong in a different category, since it has broad applications.
###			√	Speaks Chthonic
Complete
###			√	Speaks ErSdtAdt
Complete
###			√	Speaks Foreign
Complete
###			√	Speaks High Goryllian
Complete
###			√	Speaks Werewelsh
Complete
##		√H	Loadout
###			H	Chunk Items
####			C	Chunk Mayor Badge
Set Bribe options on separate traits
This might just need to be an item rather than a trait
####			C	Chunk Stash Hint
New
####			√	Chunk Key
Complete
####			√	Chunk Safe Combo
Complete
###			√	Gun Nut 
####			√	Silencer
Complete
####			√	Trigger Mod
Complete
####			√	Accuracy Mod
Complete
####			√	Ammo Mod
Complete
###			√	Loader
####			√	Flat Distribution
Complete
####			√	Scaled Distribution
Complete
####			√	Upscaled Distribution
Complete
###			√	Money
####			√	No Money 25%
New
####			√	No Money 50%
New
####			√	No Money 75%
New
###			√	Pockets
####			√	Have
Complete
####			√	Have Mostly
Complete
####			√	Have Not
Complete
####			√	FunnyPack
Complete
####			√	FunnyPack Extreme
Complete
###			√	Slots
####			√	Equipment Chad
Complete
####			√	Equipment Enjoyer
Complete
####			√	Equipment Virgin
Complete
####			√	Sidearmed
Complete
####			√	Sidearmed to the Teeth
Complete
##		√	Loot Drop
###			√	Blurse of Midas
Complete
###			√	Blurse of Softlock
Complete
###			√	Blurse of the Pharoah
Complete
###			√	Blurse of Valhalla
Complete
##		C	Merchant Buyer Modifiers
###				C	Buyer Cap
Total amount of money the trader will dispense when buying player goods
Vanilla For Sellomatic: 250-300 per level
####				C	$50
New
####				C	$150
New
####				C	$500
New
####				C	$1000
New
####				C	Unlimited
New
###				C	Buyer Type
A shorter list of broader categories than Merchant Type. Depends on how it feels while you write it.
###				C	Buyer Type - Match Merchant Types
Mirror shop inventory
##		C	Merchant Stock
###			C	Replenisher
Replace stock with same item
###			C	Restocker
Replace stock with random
###			√	Clearancer
Allows repeats of items
###			√	Masterworker
2x Durability
###			√	Masterworkerer
3x Durability
###			√	Masterworkerest
4x Durability
###			√	Shiddy Goods
1/3 Durability
###			√	Shoddy Goods
2/3 Durability
###			√	Stocker
2x Qty
###			√	Stockerer
3x Qty
###			√	Stockerest
4x Qty
##		C	Merchant Type
###			C	00 Refactor
New
###			C	00 Custom quantity in refactor
Allows to sell shitty items in junk dealer, for instance
###			H	Insider
Test: MT Drug dealer & all 3 insiders
	1 Sugar, 3 insider items and a blank
	None of the insider items were purchaseable (greyed out). Alignment didn't affect it
	Multiples of agent sold multiples of items. 
####			C	Key
Sold in shop
Preferential addition to inventory
####			C	Mayor Badge
Sold in shop
Preferential addition to inventory
####			C	Safe Combo
Sold in shop
Preferential addition to inventory
####			H	Stash Hint
Sold in shop
Preferential addition to inventory
Stash Hint Notes:
	Trait: Instinct Searcher - Know where stash is even without hint
	On gaining Stash Hint, empty stash objects become un-interactable and full one glows for object Type
	Generally, this should motivate people to either:
		Track down the stash hint to find it stealthily
		Smash everything in sight to find it quicker
###			C	NPC Loadout
Since Character Creator inventory isn't by default carried to spawn, use it as a shop inventory.
###			C	Player Loadout 
As in, the inventory you'd see in a Loadout-o-matic as a shop inventory
##		CT	Passive
###			C	Always Gib / Gibbous
New
###			C	Fearsome
Everyone terrified, Killer Robot
###			C	Focus Stealer
Camera focuses on them when in range. For bosses
###			C	Elector
NPC has 2x effect on Electability
###			C	Explodevious
agent.canExplosiveStimulate
###			C	Holographic
Ghostlike, not necessarily gibbable (Use Supernatural for that)
##		C	Ice Grip
Player 0-pt trait
Agent.AgentLateUpdate():
			if (this.curTileData.ice && !this.onIce && !this.ghost && !this.teleporting)
Could also do an opposite called Cold Feet
###			C	Last Stander
Only spawns once all NPCs without Last Stander or better are neutralized
###			C	Last Standest
|| But more
###			C	Menace 2 Society
When neutralized, witnesses Friendly
###			C	Menace 3 Society
When neutralized, witnesses Loyal
###			C	Menace 4 Society
When neutralized, witnesses Aligned
###			C	Menace -1 Society
When neutralized, witnesses Annoyed
###			C	Menace -2 Society
When neutralized, witnesses Hostile
###			C	Mute Dialogue
Cancels possible immersion-breaking dialogue tailored to vanilla NPCs
###			C	Oblivious
Doesn't care about destroyed property, dead teammates, or noises in restricted areas. 
But will enter combat if their teammates do.
###			C	Psychic Shield
Wiki: "The Alien is unaffected by mind altering items such as a Hypnotizer or Haterator, but can be affected by items like Rage Poison or the Satellite's Happy Waves."
###			C	Reviveable (Infinite)
Instead of dying, agent will be Injured instead. Player can revive them or hire someone to do it unlimited times.
###			C	Reviveable (One)
Instead of dying, agent will be Injured instead. Player can revive them or hire someone to do it once.
###			C	Reviver
If hired and surviving, will revive the player once
###			C	Supernaturally Aware
- TheShadowHat#1437
Detect Shapeshifters and Werewolves
Retains relationship after de-transformation or re-possession
###			C	Tight Grip
Immune to Butterfingerer
###			C	Trigger Happy
Like Killer Robot
###			C	Spidey-Sensitive
When alerted, immediately enters combat with perp (no search necessary)
###			H	Statue
Remove colors
Tint white
Make stationary, Invincible, non-reactive
This should probably not be one trait, but many combined
###			C	Stinky Aura
Werewolf A-were-ness works on this character
###			C	Supernatural
Ghost Gibber works
###			C	Tattletale
Reports ALL crimes to alarm button
###			C	Translucent
Ghost visual effect
###			C	Unappetizing
Can't be bitten/cannibalized
###			C	Unchallenging
No XP for neutralization
###			C	Underclass
Cops won't protect them
###			C	Unspecial
Disables:
	Possession
	Secret werewolf
	Arsonist
###			C	Vision Beams (Cop Bot)
DW
###			C	Zombified
NOT Z-infected. But you might want to just Z-infect and kill, since it might be simplest.
Agent.zombified
Agent.customZombified
###			√H	Guilty
agent.KillForQuest to see where those poor apartment dwellers are declared collateral damage
####			H	Cascade to Employees
SetRelationshipOriginal, under Drug Dealer
Extended this to agent.employee but I doubt that's ever actually assigned anyway.
###			√	Brainless
Complete
###			√	Crusty
Complete
###			√	Extortable
Complete
###			√	Immovable
Complete
###			√	Indestructible
Complete
###			√	Innocent
Complete
###			√	Not Vincible
Complete
###			√	Possessed
Complete
###			√	Status Effect Immune
Complete
###			√	Z-Infected
Complete
##		√	Player
###			√	Ammo
####			√	Ammo Amateur
Complete
####			√	Ammo Artiste
Complete
####			√	Ammo Auteur
Complete
###			√	Armor
####			√	Blinker
Complete
####			√	Myrmicapo
Complete
####			√	Myrmidon
Complete
###			√	Melee Combat
####			√	Melee Maniac
Complete
####			√	Melee Maniac +
Complete
###			√	Ranged Combat
####			√	Pants on Autofire
Complete
####			√	Trigger Happy
Complete
####			√	Trigger Junkie
Complete
###			√	Miscellaneous
####			√	Blinker
Complete
##		C	Relationships - Faction
###			C	Make Agent relationship traits Player Traits?
Would also resolve foldering issue
###			C	Import Relationship traits
From BunnyMod & RHR (Polarizing et al.)
###			C	Refactor Concept
Friendly to faction doesn't align you. You do not inherit the faction's relationships.
Loyal causes you to inherit its relationships, but negative ones are moderated:
	Hostile → Annoyed
	Annoyed → Neutral
		The net effect of this one is that Loyalists are less likely to initate conflict on behalf of their faction.
Aligned means you fully inherit any faction-mandated relationships.
###			C	Config Files for unique player-defined factions
Generate traits based on these names
Allow multiple faction list files in a folder, to increase ease of compatibility.
##		C	Relationships - General
###			C	All-Annoyed
New
###			C	All-Friendly
New
###			C	All-Hostile
New
###			C	Never Aligned
For all Never traits, 
###			C	Never Annoyed
###			C	Never Friendly
###			C	Never Hostile
###			C	Never Loyal
###			C	Never Aligned
###			C	Never Submissive
###			C	Forgetful
Returns to neutral after a timer
###			C	Imposterous
After a long delay, goes hostile to any they're aligned to
###			C	Long Fuse
Hostile at 12 strikes, Annoyed at 6
###			C	Longer Fuse
Hostile at 8 strikes, Annoyed at 4
###			C	Longest Fuse
Goes annoyed only when damaged. Goes hostile only when annoyed and damaged.
###			C	Protect at Aligned
Inner circle only
###			C	Protect at Friendly
Indeed
###			C	Protect at Neutral
Cosmopolitan
###			C	Protect at Annoyed
What a good guy
###			C	Protect never
Well okay damn dude
###			C	Remorseful
Will do something shitty, but then regret it and go Annoyed at employer.
###			C	Remorsefuler 
As above but hostile
###			C	Short Fuse
Hostile at 4 strikes, Annoyed at 1
###			C	Shorter Fuse
Hostile at 2 strikes, Annoyed at 1
###			C	Shortest Fuse
So annoyed they go straight to hostile at 1 strike
###			√	Hostile to Cannibal
Complete
###			√	Hostile to Soldier
Complete
###			√	Hostile to Vampire
Complete
###			√	Hostile to Werewolf
Complete
###			√	Relationless
Complete
##		C	Senses - Hearing
###			C	Deaf
Already a status effect, you might even overlap the trait name as a cool trick
##		C	Senses - Vision
###			C	Scanline
Show NPC vision cone like Cop bot, minus the audio (that can be modularized elsewhere)
###			C	Short-sighted
Short vision
###			C	Far-sighted
Camera-style blindspot
###			C	Eye of the Hawk
Long vision
###			C	Eye of the Duck
Wide peripheral vision
###			C	Eye of the Worm
Narrow peripheral vision
##		C	Spawn
###			C	Enslaved
New
###			C	Hide In Object
Detect Bush/Manhole on same tile
###			C	Respawn
Never-ending waves of enemies
####			C	Respawn Delay
0, 3, 15, 30, 60, 120, 180 seconds
####			C	Respawn Quantity
1, 3, 10, Infinite
###			C	Roaming Gang
New
###			C	Slave Owner
NEw			
###			C	Spawn on Object Destruction
Set matching Owner ID to spawn like Ghost from Gravestone
##		C	Spawn - Bodyguarded
New
- There are a few other hits that came up in a string search (possibly "Musician"):
  - LoadLevel.SpawnStartingFollowers
  - ObjectMult.StartWithFollowersBodyguardA
	- Ignore this one, it's for the Player Bodyguard trait
- Check out ObjectMult.StartWithFollowers, there are something like 4 similarly named methods in there
###			C	Pilot Trait
No errors, but no effect.
###			C	Bodyguard Quantity Traits?
One / few / many, that's it
###			C	Bodyguarded - Cop
New
###			C	Bodyguarded - Blahd
New
###			C	Bodyguarded - Crepe
New
###			C	Bodyguarded - Goon
New
###			C	Bodyguarded - Gorilla
New
###			C	Bodyguarded - Mafia
New
###			C	Bodyguarded - Soldier
New
###			C	Bodyguarded - Supercop
New
###			C	Bodyguarded - Supergoon
New
##		C	Subclass / Superclass / Parent Class (Not sure which is clearest)
One trait for each vanilla agent (32 is a lot)
Designed to make Class Solidarity worth taking for custom characters
##		C	Tethers
###			C	Types depend on vanilla variable
##		C	Trait Gates
See the Gate Vendor/Gate Hire ones too. Those were requested, and they make sense.
###			C	Crust Enjoyer
If you have Upper Crusty, this character is Loyal
I think this is actually automatic with Enforcer
###			C	Gate Vendor
Won't sell unless you have appropriate trait
###			C	Gate Hire
Won't hire unless you have appropriate trait
###			C	Thief Network Traits (Trait Gate / Faction)
####			C	Honorable Thief
This now just means membership in the network, not necessarily Friendliness. Add it to vanilla thieves.
####			C	Tweaks to vanilla Honor Among Thieves
The relationship improvement is now scaled to the particular NPC. 
####			C	Honored Among Thieves + (Player Trait)
Those in the Network are Loyal.
####			C	Honored Among Thieves ++ (Player Trait)
Those in the Network are Aligned.
####			C	Dishonorable Thief (Player Trait)
Still pickpockets other thieves in the network
Gets access to shops in the network
CCU idea: The Secret Thief Faction
Ok not a faction, but linking Honor Among Thieves 
####			C	Ali Baba (Player Trait)
Those in the Network are mutually Annoyed
###			C	Goody Two-Shoes
Won't interact with Wanted (Shopkeeper vanilla)
###			√	Cool Cannibal
Complete
###			√	Bashable
Complete
###			√	Common Folk
Complete
###			√	Crushable
Complete
###			√	Cop	Access
Complete
###			√	Family Friend
Complete
###			√	Scumbag
Complete
###			√	Slayable
Complete
###			√	Suspecter
Complete
#		C	Mutators
Setting: Force Big Quest completion - If set to yes, you will need to complete your big quest before leaving the floor, if there is one. You will not be able to exit the floor until the BQ is done, even after completing all the missions on the floor. If the quest is failed (floor only fails dont count) you will spontaneously combust and die.

Setting: Exit on Death - If set to yes, you will be forced to exit the floor when you die. On the next floor, you will be revived and you will be healed to maximum HP.

Mutator: Exit Timer - Similar to Time Limit, except that the elevator is locked until the timer reaches zero. Missions will not open the elevator.

Mutator: Exit Timer EXTREME - Similar to Time Limit EXTREME, except that the timer is LONGER, and the elevator is locked until the timer reaches zero. Missions will not open the elevator.

Mutator: Exit Timer LITE - Similar to Time Limit, except that the timer is SHORTER, and the elevator is locked until the timer reaches zero. Missions will not open the elevator. 
##		C	Laws
Add malus to social stuff when breaking various laws, unless talking to scumbags or outlaws
###			H	No Open Carry
Out of scope for now 
##		C	Disaster Mutators
Simply allows them to be mixed
##		C	Election Mutators
###			C	Vary starting election point
###			C	Vary vote value
And traits that affect vote power
##		C	00 Mutator List Population
###			C	00 Hide from Non-Editor access
- CreateMutatorListCampaign
###			√	General Mutator List
- Show up in LevelEditor UI, may be a manually constructed list
- LoadLevel.loadStuff2 @ 171
##		C	Branching
Basically allows options at Exit Elevator to choose the next level, and/or skipping levels on the level list

CampaignData
	levelNameList		List of strings
	levelList			List of LevelData
	mutatorList			List of strings
GC.sessionDataBig.curLevelEndless - 1
	Seems to be the main int counter of what level you're on

- LoadLevel
  - loadStuff2 @ 199
	- this.customLevel = this.customCampaign.levelList[n];

663:
	if (this.customCampaign.levelList[n].levelName == this.customCampaign.levelNameList[this.gc.sessionDataBig.curLevelEndless - 1])
		Transpile-replace the right side of this assignment to a custom method call that determines the new target level's int ID in the campaign level list

###			C	00 Usage Guide
This one will be complicated to explain, so it's best to go overboard on documentation and provide examples.
###			C	Level Label
Labels a level ABCD
Mutually exclusive
###			C	Those bottom three buttons
Why do Agents have a different Item interface than Objects? Maybe those buttons could be repurposed.
###			C	Important Button
This stores an Int. That might be useful. Maybe this could be toggled between Off, On, and A-B to assign it to a Gate.
I think it ends up sending to LevelEditor.FillSpawner, which turns it into a bool. So a patch to that method or soon thereafter might find a spot to store the Gate number/letter on the newly spawned object. SpawnerBasic.important is read by all the specialized spawners so you might need to patch all of those.

The box isn't available for Items, maybe it could be.
###			C	Elevator Extravars
####			C	Level +2, 3, 4
Skip in list
####			C	Level ABCD
Target level by tag
Still subject to Flags
###			C	Level Entry Gates
Apply to a destination level to determine how its tags are evaluated.
####			C	Flags AND
####			C	Flags NOT
####			C	Flags OR
####			C	Flags XOR
###			C	TRAITS for Level Branching
####			C	Flag ABCD
Allow multiple. Nonspecific, to be linked to below.
####			C	Flag on Evacuated
####			C	Flag on Neutralized
####			C	Flag on Paid
##		C	Disasters
###			C	Random Disaster
Random Disasters and/or Disasters Every Level aren't offered in the editor
##		√	Followers
###			√	Homesickness Disabled
Complete
###			√	Homesickness Mandatory
Complete
##		C	Gameplay
###			C	Pursuers Follow
When you use exit elevator, anyone chasing you follows you to the next level.
###			C	Infinite Continues
###			C	Random Start Location
###			C	No Funny Business
For town levels. Ensures no one will be killed.
You will need to eliminate spontaneous hostiles for this to work, though.
##		C	Interface
In PlayerControl.Update there's a hidden keystroke for pressedInterfaceOff
###			C	No Map/Minimap
##		C	Presets
Curated configurations of challenges that can serve as a shortcut.
E.g., "Interlude:" No funny business, pause big quests, etc.
##		C	Progression
###			C	Missions Optional
Unlock elevator
###			C	Manual Missions Only
No randos
###			C	Force Mission Type
All Neutralize, Steal, etc., but random
###			C	Hide Missions
For diegetic storytelling
###			C	Exit Timer
For Survival Levels, elevator is locked until timer elapses.
###			C	Delay Trait Gain
Count and put off trait choices until this challenge isn't present
###			C	Reset Player Character
###			C	Empty Inventory on Exit
###			C	Wipe Statistics on Exit
##		C	Quests
###			C	Big Quest Exempt
Deactivate Big Quest for level, freeze mark counts
###			C	Big Quest Mandatory
Complete quest to exit level
Die if you fail quest
Possibly modified by Mark-based
###			C	Big Quest Stopping Point
Equivalent to Mayor's Village, where super special abilities activate if you completed the Big Quest
###			C	Major Contract
Main quest rewards are multiplied by 10
##		C	Utility
###			C	Sort active Mutators by Name
- ScrollingMenu.PushedButton @ 0006
  - Pretty much has exactly what you need.
#		CT	Objects
##			C	Traps
Chest, Door, Window
Dart, Taser, Flame, Explosion, Slime, etc.
##
##			C	Slime Barrel
###				C	Barrel of Monke
New
###				C	Big Explosion
New
###				C	Blood and Gore
Super mutant food stash
###				C	Cyanide
Use alien blood sprite?
###				C	Dizzy
New
###				C	EMP
New
###				C	Fire Bomb
Mostly black with bright warning yellow stripes, diagonal on upper and bottom thirds
Label is a white diamond, red edges with a flame in the middle
###				C	Huge Explosion
New
###				C	Normal
Even if redundant, gives sprite variety
###				C	Oil
Not a vanilla explosion type, so just do the spill
Black barrel. 
Label is a white diamond, red edges with a black teardrop shape in it.
###				C	Ooze
New
###				C	Ridiculous Explosion
New
###				C	Slime
Default value, default sprite
###				C	Stomp
New
###				C	Warp
New
###				C	Water
Blue Barrel, middle stripe white. No label.
###				C	Sprites
Coloring and distinct warning label specific to Status Effect
If label too small, use barrel color and pattern
###				C	Status Effect (ExtraVarString)
This will be important since this list will be used for several objects.
###				C	Durability (ExtraVarString2)
This can also be reused, e.g. for security cam
####				C	Bombproof
New
####				C	Reinforced
Requires 2-3 hits to explode rather than 1
(Normal for most objects, generally only useful for barrels)
####				C	Steel-Cased
Requires an explosion to destroy
####				C	Volatile
Destroyed if you bump into it, maybe could add Overclocked effects to it
##			C	Turret
Recs by Mac
###				C	Projectile
        Banana Peel
        Beartrap
        Bullet
        Ray (payloadable) (slower than bullet, it's basically just freeze ray projectile)
        Tazer (payloadable)
        Dart (payloadable)
        Tazer
        Ghost Gibber 
        Grenade (payloadable)
        Flamethrower
        Rock
        Paralizer trap (payloadable)
        Rocket (payloadable)
        Landmine (payloadable)
        Lazer
        Leafblower
###				C	Payload
		Default
        None
        Dizzy
        Freezing
        E.M.P
        Warp
        Poision
        Confuse
        Slow
        Rage Poision
        Cyanide
        Sulfuric Acid
        Tranq
        Taze
        Ressurection
        Fast
        Regeneration
        Nicotine
        Perfume
        Antidote
        Invincible
        Invisible
        Zombiisim
###				C	Element
        Default
        Normal
        Harmless (always deals 1 damage)
        Bullet (for vs. bulletproof)
        Pyrotechnic (for vs. fireproof skin. Also sets stuff on fire when it hits things, and explodes like molotov)
        Electric (for vs. wet)
        Aquatechnic (for vs. Electronic. Does 0 damage to everyone else)
        Monster Bane (Ghost Gibber)
        Normie Killer (Reverse Ghost Gibber)
        Plot Armor Pericing (deals extra damage to players and recruits)
        Safety Bullet (Bullet, but it deals 0 damage to everyone the turret wasn't targeting)
        
        Bananium (Heals anyone with Banana Lover)
        Distilled (Heals anyone who can drink alcohol)
        Essential Oils (Heals anyone who has any kind of restriction on meele weapons.)
        Actual Oil (Heals anyone who can drink(?) oil. So basically mech and robots.)
###				C	Ammo
    Unlimited
    30-second recharge
    15-second recharge
    random recharge
    Limited to 10
    Limited to 50
##			C	Custom Decal
I put a Custom Floor Decal item in the Editor Object List. Nothing else. See what kind of errors pop up to determine what to patch.
##			H	Ambusher
Bathtub (Need sprite)
Bush
Elevator
Gravestone
Manhole
Toilet
Tube
Well
###			C	Cannibal
###			C	Thief
##			H	Fire Status
Barbecue
Flaming Barrel
Fireplace
###			C	Lit
###			C	Unlit
##		C	Containers
###			H	Containervestigateables 
Disabling the overlap resolved all the rest of the bugs here. 
####			C	Can't remove items
Containervestigateables, once given an item, can't have it removed
####			C	Cross-Contamination
Investigateable text is displayed erroneously when selecting a containervestigateable after any investigateable. It either copies the text over or displays the old stuff.
Next attempt:
	LevelEditor.
		CloseLongDescription
		OpenLongDescription
###			C	EVS1
####			C	Keycoded
This will be my term for the Safe's lock, since it's hackable and uses a combo.
####			H	Locked
Only Desk seems eligible, but that's enough to go for it. Use stringvar1 or something as a Locked variable
Maybe generate a Desk Key item, specific to the Desk
####			C	Stashed
Stash is inaccessible (except with Object destruction) until Stash Hint is found. 
It will have almost everything in common with Key, so it should be easy research.
####			C	Stashed + Keycoded
If you keep it modular, this should be easy
####			C	Stashed + Keycoded + Locked
Why the fuck not, let's go nuts
####			C	Stashed + Locked
If you keep it modular, this should be easy
###			C	EVS2
Durability?
###			√	EVS3
Item
##			C	Object Special Actions
###				C	Alarm
###				C	Explode
###				C	Raise Dead (Chunk)
###				C	Raise Dead (Level)
###				C	Set Level Flag ABCD
This one would likely need to coexist with another OSA so...
##			C	Object Special Action Triggers
For use with Variables
###				C	On Destroy
###				C	On Investigate
When text is *closed*
###				C	On Loot
##			C	Air Conditioner
Enable "Fumigating" w/ staff in gas masks as option
GasVent.fumigationSelected
##			C	Fire Hydrant
Ability to be already shooting water according to direction
##			C	Investigateables
###				C	Limit Window Investigation to one side
Shouldn't be accessible from both sides
That code is more likely in Door than Window
###			C	French Vanilla Strings
Default strings per object type
####				C	Computer
#####					C	Zone Security
Blue, Red, and Green variants
Use a varstring on security objects to determine their levelwide zone
#####
####				C	Gravestone
Yeah Gravestone jokes are soooo funny and fresh
###			C	One-Time Read
For stuff that might not apply later, like peeking into windows
###			C	Movie Screen
Didn't work yet: https://discord.com/channels/187414758536773632/433748059172896769/1000014921305706567
Should be ready with next RL release
###			C	Custom Sprites when readable text present
Will need a visual indicator to the player. This is an extra, if RL correctly toggles interactability conditional on valid interactions.
####				C	Computer
"Unread Mail" icon on screen
###			√	Input field Display
P_LevelEditor.UpdateInterface
###			√	Input field Edit
P_LevelEditor.PressedLoadExtraVarStringList
###			√	Setup object
P_BasicObject.Spawn
###			√	Interaction
Readables.Setup
##			C	Explosive Barrel
###				C	Sprite Warning Label
Specific to Status Effect
If label too small, use barrel color and pattern
###				C	Explosion Type (ExtraVarString)
This will be important since this list will be used for several objects.
###				C	Durability (ExtraVarString2)
This can also be reused, e.g. for security cam
####				C	Bombproof
Not useful for barrels, but since this list will be reused
####				C	Reinforced
Requires 2-3 hits to explode rather than 1
(Normal for most objects, generally only useful for barrels)
####				C	Steel-Cased
Requires an explosion to destroy
####				C	Volatile
Destroyed if you bump into it
##			C	Laser Emitter
###				C	Mode: Metal Detector
This would really only make sense with a Stop & Frisk mod.
##			C	Turret
###				C	Gun Type (ExtraVarString)
####				C	Flamethrower
####				C	Freeze Ray
####				C	Ghost Gibber
####				C	Grenade Launcher
####				C	Machine Gun
####				C	Minigun
####				C	Rail Gun
####				C	Rocket
####				C	Shrink Ray
####				C	Sniper
Extends vision range
Combat.distOffset is current range from agent to shooting target
####				C	Tranquilizer
####				H	Request - Custom Dart
Streets of Cheese suggested darts with choosable status effect
Doing entries for each type would be prohibitive, but if one ExtraVarString looks sparse you could use that for the status effect. And that'd likely be reusable code since other objects might use statuses.
###				C	Sensors (ExtraVarString2)
####				C	Built-In Camera (Rotating)
####				C	Built-In Camera (Stationary)
###				C	Durability (ExtraVarString3)
####				C	Armored
####				C	Fragile
####				C	Indestructible
###				C	Other (ExtraVarString4)
####				C	Explode on Death
#		√	Bug Archive
##			√	Fast or Rollerskates won't fall in Hole
###				√	Fix
Vanilla bug
##				H	Suicide doesn't gib
###				H	Fix
Hook Regeneration
##			H	Relationships not Loaded
###				H	Fix
Hook Regeneration
#		√	Trait Archive
##			√	Cost Scale
###				√	Less
Complete
###				√	More
Complete
###				√	Much More
Complete
###				√	Zero
Complete
##			√	Relationships - Player
###				√	Player Aligned
Complete
###				√	Player Annoyed
Complete
###				√	Player Friendly
Complete
###				√	Player Hostile
Complete
###				√	Player Loyal
Complete
###				√	Player Secret Hate
Moved to Behavior - Ambush (more transparent to user)
###				√	Player Submissive 
Complete