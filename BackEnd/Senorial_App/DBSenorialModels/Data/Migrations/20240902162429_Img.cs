using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBSenorialModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class Img : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 1,
                columns: new[] { "nombre", "url" },
                values: new object[] { "Hamburguesa-clasica", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-clasica_ggudid.png" });

            migrationBuilder.InsertData(
                schema: "Generico",
                table: "imagenes",
                columns: new[] { "id_img", "nombre", "url" },
                values: new object[,]
                {
                    { 2, "Hamburguesa-queso-tocino", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-queso-tocino_li42kl.png" },
                    { 3, "Hamburguesa-senorial", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Hamburguesa-senorial_qw9pko.png" },
                    { 4, "1-4-de-pollo-a-la-brasa", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258861/Pollo-a-la-brasa-1-4_kh0xna.png" },
                    { 5, "1-4-de-pollo-broaster", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258863/Pollo-broaster-1-4_bvqfwh.png" },
                    { 6, "Parrilla-de-pollo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo_mqiwcu.png" },
                    { 7, "Parrilla-de-pollo-al-ajo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo-al-ajo_zyzrtw.png" },
                    { 8, "Parrilla-de-pollo-dietetica", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258857/Parrilla-de-pollo-dietetico_ym2r5n.png" },
                    { 9, "Parrilla-mixta", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258858/Parrilla-mixta_ehhq5k.png" },
                    { 10, "Brochetas-de-pollo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258870/Brochetas-de-pollo_jmqtvn.png" },
                    { 11, "Pollo-a-la-pizzarola", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pollo-a-la-pizzarola_orxsc5.png" },
                    { 12, "Bisteck-a-la-parrilla", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258870/Bisteck-a-la-parrilla_r9iclg.png" },
                    { 13, "Chorizo-a-la-parrilla", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Chorizo-a-la-parrilla_dgpnvt.png" },
                    { 14, "Chicharron-senorial", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chicharron-senorial_p50hre.png" },
                    { 15, "Lonjitas", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258849/Lonjitas_xdukaq.png" },
                    { 16, "Chaufa-especial", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258877/Chaufa-especial_alryv8.png" },
                    { 17, "Chaufa-mixto", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chaufa-mixto_ysfysw.png" },
                    { 18, "Spaguetti-a-lo-alfredo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Spaguetti-a-lo-alfredo_pyobkl.png" },
                    { 19, "Cafe-pasado", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Cafe-pasado_fks93h.png" },
                    { 20, "Chocolate-con-panetón", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Chocolate-con-paneton_nbteel.png" },
                    { 21, "Leche-fresca", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258846/Leche-fresca_tpj7mm.png" },
                    { 22, "Milo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258852/Milo_yii8m1.png" },
                    { 23, "Cafe-con-leche", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Cafe-con-leche_rrxkzt.png" },
                    { 24, "Mates", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Mates_wcsite.png" },
                    { 25, "Gaseosa-3lts", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-3lts_el2kgx.png" },
                    { 26, "Gaseosa-2.25lts", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Gaseosa-de-2.25lts_r780yp.png" },
                    { 27, "Gaseosa-1.5lts", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Gaseosa-de-1.5lts_ajne1a.png" },
                    { 28, "Gaseosa-1lts", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-1lts_axqqpe.png" },
                    { 29, "Gaseosa-1-2lt", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-de-500ml_m2rgju.png" },
                    { 30, "Gaseosa-personal", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-personal_hnkmlf.png" },
                    { 31, "Gaseosa-piranita", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258840/Gaseosa-piranita_jv3ord.png" },
                    { 32, "Refresco-de-maracuya-jarra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258863/Refresco-de-maracuya-Jarra_aeakzt.png" },
                    { 33, "Chicha-morada-jarra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258878/Chicha-morada-Jarra_xsjncx.png" },
                    { 34, "Limonada-Frozen-jarra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258848/Limonada-frozen-Jarra_xftmfy.png" },
                    { 35, "Limonada-Americana-jarra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258848/Limona-americana-Jarra_esgczd.png" },
                    { 36, "Caliente-de-pisco", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Caliente-de-pisco_sjalzc.png" },
                    { 37, "Caliente-de-vino", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258874/Caliente-de-vino_kwaift.png" },
                    { 38, "Caliente-de-ron", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258872/Caliente-de-ron_pg2g1m.png" },
                    { 39, "Caliente-de-whisky", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Caliente-de-whisky_gpmkst.png" },
                    { 40, "Cerveza-en-lata", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Cerveza-en-lata_qozyqi.png" },
                    { 41, "Cerveza-negra", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258877/Cerveza-negra_kk7eux.png" },
                    { 42, "Cerveza-de-trigo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258875/Cerveza-de-trigo_yabm3n.png" },
                    { 43, "Vino-queirolo-vaso", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258867/Vino-queirolo-Vaso_kj8sbq.png" },
                    { 44, "Whisky-vaso", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258867/Wisky-Vaso_qnwn1m.png" },
                    { 45, "Pisco-Vargas-vaso", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pisco-vargas-Vaso_t8y3oz.png" },
                    { 46, "Mojito", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258854/Mojito_ubvhpc.png" },
                    { 47, "Machu-Picchu", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258849/Machu-picchu_sosb2h.png" },
                    { 48, "Daikiri", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Daikiri_scg5iq.png" },
                    { 49, "Pina-colada", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pina-colada_qoav6s.png" },
                    { 50, "Pisco-sour", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258860/Pisco-sour_xhrnzd.png" },
                    { 51, "Naranjita", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258856/Naranjita_jrm3qr.png" },
                    { 52, "Alitas-en-salsa-BBQ", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258869/Alitas-en-salsa-BBQ_itujfe.png" },
                    { 53, "Alitas-broaster", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258869/Alitas-broaster_e0wdiv.png" },
                    { 54, "Tequenos-especiales", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Tequenos-especiales_q4topa.png" },
                    { 55, "Durazno-en-almíbar", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Durazno-en-almibar_yfzewe.png" },
                    { 56, "Helado-02-bolas", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Helado-02-bolas_n7g79i.png" },
                    { 57, "Helado-03-bolas", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Helado-03-bolas_ct5qkk.png" },
                    { 58, "Gelatina", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258842/Gelatina_lirwco.png" },
                    { 59, "Flan", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258839/Flan_mygmdv.png" },
                    { 60, "Jugo-de-papaya", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-papaya_miqnbk.png" },
                    { 61, "Jugo-de-fresa-con-leche", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-fresa_abese7.png" },
                    { 62, "Jugo-de-platano", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-de-platano_yrsmee.png" },
                    { 63, "Jugo-surtido", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258845/Jugo-surtido_fjl9jf.png" },
                    { 64, "Ensalada-de-frutas", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258881/Ensalada-de-frutas_jybwbc.png" },
                    { 65, "Milkshake-de-Oreo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-oreo_crwp9x.png" },
                    { 66, "Milkshake-de-durazno", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-durazno_p1ltvm.png" },
                    { 67, "Milkshake-de-fresa", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258851/Milkshake-de-fresa_btvt9f.png" },
                    { 68, "Salchipapa-clasica", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258864/Salchipapa-clasica_umbxrb.png" },
                    { 69, "Salchipapa-ayacuchana", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258864/Salchipapa-ayacuchana_vzk1h3.png" },
                    { 70, "Salchipiernita", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258866/Salchipiernita_wxckli.png" },
                    { 71, "Mounstruo", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258855/Mounstruo_bgqfgs.png" },
                    { 72, "Mounstrito", "https://res.cloudinary.com/dilxrtdwx/image/upload/v1725258854/Mounstrito_vjfxho.png" }
                });

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 9, 2, 11, 24, 27, 94, DateTimeKind.Local).AddTicks(7009));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 9, 2, 11, 24, 27, 94, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 2,
                column: "id_img",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 3,
                column: "id_img",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 4,
                column: "id_img",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 5,
                column: "id_img",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 6,
                column: "id_img",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 7,
                column: "id_img",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 8,
                column: "id_img",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 9,
                column: "id_img",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 10,
                column: "id_img",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 11,
                column: "id_img",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 12,
                column: "id_img",
                value: 12);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 13,
                column: "id_img",
                value: 13);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 14,
                column: "id_img",
                value: 14);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 15,
                column: "id_img",
                value: 15);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 16,
                column: "id_img",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 17,
                column: "id_img",
                value: 17);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 18,
                column: "id_img",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 19,
                column: "id_img",
                value: 19);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 20,
                column: "id_img",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 21,
                column: "id_img",
                value: 21);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 22,
                column: "id_img",
                value: 22);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 23,
                column: "id_img",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 24,
                column: "id_img",
                value: 24);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 25,
                column: "id_img",
                value: 25);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 26,
                column: "id_img",
                value: 26);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 27,
                column: "id_img",
                value: 27);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 28,
                column: "id_img",
                value: 28);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 29,
                column: "id_img",
                value: 29);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 30,
                column: "id_img",
                value: 30);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 31,
                column: "id_img",
                value: 31);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 32,
                column: "id_img",
                value: 32);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 33,
                column: "id_img",
                value: 33);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 34,
                column: "id_img",
                value: 34);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 35,
                column: "id_img",
                value: 35);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 36,
                column: "id_img",
                value: 36);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 37,
                column: "id_img",
                value: 37);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 38,
                column: "id_img",
                value: 38);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 39,
                column: "id_img",
                value: 39);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 40,
                column: "id_img",
                value: 40);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 41,
                column: "id_img",
                value: 41);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 42,
                column: "id_img",
                value: 42);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 43,
                column: "id_img",
                value: 43);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 44,
                column: "id_img",
                value: 44);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 45,
                column: "id_img",
                value: 45);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 46,
                column: "id_img",
                value: 46);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 47,
                column: "id_img",
                value: 47);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 48,
                column: "id_img",
                value: 48);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 49,
                column: "id_img",
                value: 49);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 50,
                column: "id_img",
                value: 50);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 51,
                column: "id_img",
                value: 51);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 52,
                column: "id_img",
                value: 52);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 53,
                column: "id_img",
                value: 53);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 54,
                column: "id_img",
                value: 54);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 55,
                column: "id_img",
                value: 55);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 56,
                column: "id_img",
                value: 56);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 57,
                column: "id_img",
                value: 57);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 58,
                column: "id_img",
                value: 58);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 59,
                column: "id_img",
                value: 59);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 60,
                column: "id_img",
                value: 60);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 61,
                column: "id_img",
                value: 61);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 62,
                column: "id_img",
                value: 62);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 63,
                column: "id_img",
                value: 63);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 64,
                column: "id_img",
                value: 64);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 65,
                column: "id_img",
                value: 65);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 66,
                column: "id_img",
                value: 66);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 67,
                column: "id_img",
                value: 67);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 68,
                column: "id_img",
                value: 68);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 69,
                column: "id_img",
                value: 69);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 70,
                column: "id_img",
                value: 70);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 71,
                column: "id_img",
                value: 71);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 72,
                column: "id_img",
                value: 72);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 9, 2, 11, 24, 27, 99, DateTimeKind.Local).AddTicks(8222));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 72);

            migrationBuilder.UpdateData(
                schema: "Generico",
                table: "imagenes",
                keyColumn: "id_img",
                keyValue: 1,
                columns: new[] { "nombre", "url" },
                values: new object[] { "test", "https://th.bing.com/th/id/OIP.TpPLUJnbBx_WleAW68PhvQHaFF?rs=1&pid=ImgDetMain" });

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 1,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 31, 0, 52, 15, 214, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                schema: "Almacen",
                table: "inventario",
                keyColumn: "id_inventario",
                keyValue: 2,
                column: "fecha_actualizacion",
                value: new DateTime(2024, 8, 31, 0, 52, 15, 214, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 2,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 3,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 4,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 5,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 6,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 7,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 8,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 9,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 10,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 11,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 12,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 13,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 14,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 15,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 16,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 17,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 18,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 19,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 20,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 21,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 22,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 23,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 24,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 25,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 26,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 27,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 28,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 29,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 30,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 31,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 32,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 33,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 34,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 35,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 36,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 37,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 38,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 39,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 40,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 41,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 42,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 43,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 44,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 45,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 46,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 47,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 48,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 49,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 50,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 51,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 52,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 53,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 54,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 55,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 56,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 57,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 58,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 59,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 60,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 61,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 62,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 63,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 64,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 65,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 66,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 67,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 68,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 69,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 70,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 71,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Ventas",
                table: "productos",
                keyColumn: "id_producto",
                keyValue: 72,
                column: "id_img",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "Usuarios",
                table: "usuario",
                keyColumn: "id_usuario",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 8, 31, 0, 52, 15, 218, DateTimeKind.Local).AddTicks(5427));
        }
    }
}
