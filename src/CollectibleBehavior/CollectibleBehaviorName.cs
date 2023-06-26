using System.Text;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;

namespace LoreWeapons;

public class CollectibleBehaviorName : CollectibleBehavior
{
    private string translationName;
    private string translationPart;
    private string newName;

    public CollectibleBehaviorName(CollectibleObject collObj) : base(collObj) { }

    public override void Initialize(JsonObject properties)
    {
        base.Initialize(properties);

        translationName = properties["translationName"].AsString();
        translationPart = properties["translationPart"].AsString();

        newName = Lang.Get(translationName) + " (" + Lang.Get(translationPart) + ")";
        newName = Lang.Get(newName);
    }

    public override void GetHeldItemName(StringBuilder sb, ItemStack itemStack)
    {
        sb.Clear();
        sb.Append(newName);
    }

    public override void GetHeldItemInfo(ItemSlot inSlot, StringBuilder dsc, IWorldAccessor world, bool withDebugInfo)
    {
        base.GetHeldItemInfo(inSlot, dsc, world, withDebugInfo);
        if (inSlot.Itemstack.Collectible.Code.FirstCodePart() == "club")
        {
            dsc.AppendLine("<font color=\"#ff8484\">CURRENTLY THERE IS NO DIFFERENCE BETWEEN METAL VARIANTS, NO BALANCE ADDED</font>");
            dsc.AppendLine();
        }
    }
}