using FirstFractalPet.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace FirstFractalPet.Projectiles
{
    public class FirstFractalPetProjectile : ModProjectile
    {
        private int clock;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.friendly = true;
            Projectile.timeLeft *= 5;
            Projectile.penetrate = -1;
            Projectile.scale = 0.18f;
            DrawOriginOffsetY = -22;
            AIType = -1;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            int Yoffset = -22;
            float lerpPercent = 0.2f;
            float rotateAmmount = 0.15f;
            if (player.direction == 1)
            {
                Projectile.position = new Vector2(MathHelper.Lerp(Projectile.position.X, player.position.X - 90f, lerpPercent), player.position.Y + (float)Yoffset);
            }
            else
            {
                Projectile.position = new Vector2(MathHelper.Lerp(Projectile.position.X, player.position.X - 30f, lerpPercent), player.position.Y + (float)Yoffset);
            }
            Projectile.spriteDirection = player.direction;
            if (Projectile.oldPosition != Projectile.position)
            {
                if (Projectile.position.X - Projectile.oldPosition.X > 0f)
                {
                    Projectile.rotation = rotateAmmount;
                }
                else if (Projectile.position.X - Projectile.oldPosition.X < 0f)
                {
                    Projectile.rotation = 0f - rotateAmmount;
                }
                else
                {
                    Projectile.rotation = MathHelper.Lerp(Projectile.rotation, 0f, lerpPercent);
                }
            }
            else
            {
                Projectile.rotation = MathHelper.Lerp(Projectile.rotation, 0f, lerpPercent);
            }
            if (!player.dead && player.HasBuff(ModContent.BuffType<FirstFractalPetBuff>()))
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}