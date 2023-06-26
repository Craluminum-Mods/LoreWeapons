using Vintagestory.API.Common;

[assembly: ModInfo("Lore Weapons")]

namespace LoreWeapons;

class Core : ModSystem
{
    public override void Start(ICoreAPI api)
    {
        base.Start(api);
        api.RegisterCollectibleBehaviorClass("LoreWeapons.CbName", typeof(CollectibleBehaviorName));
        api.World.Logger.Event("started 'Lore Weapons' mod");
    }
}