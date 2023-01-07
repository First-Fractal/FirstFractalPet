using FirstFractalPet.Buffs;
using FirstFractalPet.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace FirstFractalPet.Items
{
    public class FirstFractalPetItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(Language.GetTextValue("Mods.FirstFractalPet.ItemTooltip.FirstFractalPetToolTip"));
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
        }

        public override void SetDefaults()
        {
            base.Item.shoot = ModContent.ProjectileType<FirstFractalPetProjectile>();
            base.Item.buffType = ModContent.BuffType<FirstFractalPetBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(base.Item.buffType, 3600);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
