using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StajyerTakip.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeceriKategorileri",
                columns: table => new
                {
                    BeceriKategoriId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KategoriAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeceriKategorileri", x => x.BeceriKategoriId);
                });

            migrationBuilder.CreateTable(
                name: "DegerlendirmeKriterleri",
                columns: table => new
                {
                    KriterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KriterAdi = table.Column<string>(type: "text", nullable: false),
                    Aciklama = table.Column<string>(type: "text", nullable: true),
                    AktifMi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegerlendirmeKriterleri", x => x.KriterId);
                });

            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmanAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "DosyaKategorileri",
                columns: table => new
                {
                    DosyaKategoriId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KategoriAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaKategorileri", x => x.DosyaKategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Moduller",
                columns: table => new
                {
                    ModulId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SiraNo = table.Column<int>(type: "integer", nullable: false),
                    ModulAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moduller", x => x.ModulId);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Beceriler",
                columns: table => new
                {
                    BeceriId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeceriAdi = table.Column<string>(type: "text", nullable: false),
                    BeceriKategoriId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beceriler", x => x.BeceriId);
                    table.ForeignKey(
                        name: "FK_Beceriler_BeceriKategorileri_BeceriKategoriId",
                        column: x => x.BeceriKategoriId,
                        principalTable: "BeceriKategorileri",
                        principalColumn: "BeceriKategoriId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    Eposta = table.Column<string>(type: "text", nullable: true),
                    SifreHash = table.Column<string>(type: "text", nullable: true),
                    AktifMi = table.Column<bool>(type: "boolean", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RolId = table.Column<int>(type: "integer", nullable: false),
                    DepartmanId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciId);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolModulYetkileri",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "integer", nullable: false),
                    ModulId = table.Column<int>(type: "integer", nullable: false),
                    Yetki = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolModulYetkileri", x => new { x.RolId, x.ModulId });
                    table.ForeignKey(
                        name: "FK_RolModulYetkileri_Moduller_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduller",
                        principalColumn: "ModulId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolModulYetkileri_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stajyerler",
                columns: table => new
                {
                    StajyerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    DogumTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    Cinsiyet = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    Eposta = table.Column<string>(type: "text", nullable: true),
                    YasadigiSehir = table.Column<string>(type: "text", nullable: true),
                    DaimiAdres = table.Column<string>(type: "text", nullable: true),
                    StajDonemiKaldigiYer = table.Column<string>(type: "text", nullable: true),
                    FotografYolu = table.Column<string>(type: "text", nullable: true),
                    Universite = table.Column<string>(type: "text", nullable: true),
                    Bolum = table.Column<string>(type: "text", nullable: true),
                    Sinif = table.Column<string>(type: "text", nullable: true),
                    GenelOrtalama = table.Column<decimal>(type: "numeric", nullable: true),
                    KacinciStaj = table.Column<short>(type: "smallint", nullable: true),
                    StajBaslangic = table.Column<DateOnly>(type: "date", nullable: true),
                    StajBitis = table.Column<DateOnly>(type: "date", nullable: true),
                    StajKonusu = table.Column<string>(type: "text", nullable: true),
                    ReferanslaMiGeldi = table.Column<bool>(type: "boolean", nullable: true),
                    TekrarCalisilirMi = table.Column<bool>(type: "boolean", nullable: true),
                    Durum = table.Column<string>(type: "text", nullable: false),
                    AktifMi = table.Column<bool>(type: "boolean", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DepartmanId = table.Column<int>(type: "integer", nullable: true),
                    MentorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stajyerler", x => x.StajyerId);
                    table.ForeignKey(
                        name: "FK_Stajyerler_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stajyerler_Kullanicilar_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Degerlendirmeler",
                columns: table => new
                {
                    DegerlendirmeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Puan = table.Column<short>(type: "smallint", nullable: false),
                    Tarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DegerlendirenId = table.Column<int>(type: "integer", nullable: false),
                    KriterId = table.Column<int>(type: "integer", nullable: false),
                    StajyerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degerlendirmeler", x => x.DegerlendirmeId);
                    table.ForeignKey(
                        name: "FK_Degerlendirmeler_DegerlendirmeKriterleri_KriterId",
                        column: x => x.KriterId,
                        principalTable: "DegerlendirmeKriterleri",
                        principalColumn: "KriterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Degerlendirmeler_Kullanicilar_DegerlendirenId",
                        column: x => x.DegerlendirenId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Degerlendirmeler_Stajyerler_StajyerId",
                        column: x => x.StajyerId,
                        principalTable: "Stajyerler",
                        principalColumn: "StajyerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dosyalar",
                columns: table => new
                {
                    DosyaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DosyaAdi = table.Column<string>(type: "text", nullable: false),
                    DosyaYolu = table.Column<string>(type: "text", nullable: false),
                    Uzanti = table.Column<string>(type: "text", nullable: true),
                    BoyutKb = table.Column<int>(type: "integer", nullable: true),
                    YuklemeTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DosyaKategoriId = table.Column<int>(type: "integer", nullable: false),
                    StajyerId = table.Column<int>(type: "integer", nullable: false),
                    YukleyenId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyalar", x => x.DosyaId);
                    table.ForeignKey(
                        name: "FK_Dosyalar_DosyaKategorileri_DosyaKategoriId",
                        column: x => x.DosyaKategoriId,
                        principalTable: "DosyaKategorileri",
                        principalColumn: "DosyaKategoriId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dosyalar_Kullanicilar_YukleyenId",
                        column: x => x.YukleyenId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dosyalar_Stajyerler_StajyerId",
                        column: x => x.StajyerId,
                        principalTable: "Stajyerler",
                        principalColumn: "StajyerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Linkler",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LinkTuru = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    StajyerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linkler", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Linkler_Stajyerler_StajyerId",
                        column: x => x.StajyerId,
                        principalTable: "Stajyerler",
                        principalColumn: "StajyerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projeler",
                columns: table => new
                {
                    ProjeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Baslik = table.Column<string>(type: "text", nullable: false),
                    Aciklama = table.Column<string>(type: "text", nullable: true),
                    StajyerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.ProjeId);
                    table.ForeignKey(
                        name: "FK_Projeler_Stajyerler_StajyerId",
                        column: x => x.StajyerId,
                        principalTable: "Stajyerler",
                        principalColumn: "StajyerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referanslar",
                columns: table => new
                {
                    ReferansId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdSoyad = table.Column<string>(type: "text", nullable: false),
                    Yakinlik = table.Column<string>(type: "text", nullable: true),
                    Unvan = table.Column<string>(type: "text", nullable: true),
                    Sirket = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true),
                    Eposta = table.Column<string>(type: "text", nullable: true),
                    StajyerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referanslar", x => x.ReferansId);
                    table.ForeignKey(
                        name: "FK_Referanslar_Stajyerler_StajyerId",
                        column: x => x.StajyerId,
                        principalTable: "Stajyerler",
                        principalColumn: "StajyerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StajyerBecerileri",
                columns: table => new
                {
                    StajyerId = table.Column<int>(type: "integer", nullable: false),
                    BeceriId = table.Column<int>(type: "integer", nullable: false),
                    Seviye = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StajyerBecerileri", x => new { x.StajyerId, x.BeceriId });
                    table.ForeignKey(
                        name: "FK_StajyerBecerileri_Beceriler_BeceriId",
                        column: x => x.BeceriId,
                        principalTable: "Beceriler",
                        principalColumn: "BeceriId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StajyerBecerileri_Stajyerler_StajyerId",
                        column: x => x.StajyerId,
                        principalTable: "Stajyerler",
                        principalColumn: "StajyerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YorumMetni = table.Column<string>(type: "text", nullable: false),
                    Tarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StajyerId = table.Column<int>(type: "integer", nullable: false),
                    YazanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kullanicilar_YazanId",
                        column: x => x.YazanId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Stajyerler_StajyerId",
                        column: x => x.StajyerId,
                        principalTable: "Stajyerler",
                        principalColumn: "StajyerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beceriler_BeceriKategoriId",
                table: "Beceriler",
                column: "BeceriKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_DegerlendirenId",
                table: "Degerlendirmeler",
                column: "DegerlendirenId");

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_KriterId",
                table: "Degerlendirmeler",
                column: "KriterId");

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_StajyerId",
                table: "Degerlendirmeler",
                column: "StajyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosyalar_DosyaKategoriId",
                table: "Dosyalar",
                column: "DosyaKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosyalar_StajyerId",
                table: "Dosyalar",
                column: "StajyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosyalar_YukleyenId",
                table: "Dosyalar",
                column: "YukleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_DepartmanId",
                table: "Kullanicilar",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_RolId",
                table: "Kullanicilar",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Linkler_StajyerId",
                table: "Linkler",
                column: "StajyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_StajyerId",
                table: "Projeler",
                column: "StajyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Referanslar_StajyerId",
                table: "Referanslar",
                column: "StajyerId");

            migrationBuilder.CreateIndex(
                name: "IX_RolModulYetkileri_ModulId",
                table: "RolModulYetkileri",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_StajyerBecerileri_BeceriId",
                table: "StajyerBecerileri",
                column: "BeceriId");

            migrationBuilder.CreateIndex(
                name: "IX_Stajyerler_DepartmanId",
                table: "Stajyerler",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Stajyerler_MentorId",
                table: "Stajyerler",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_StajyerId",
                table: "Yorumlar",
                column: "StajyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_YazanId",
                table: "Yorumlar",
                column: "YazanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degerlendirmeler");

            migrationBuilder.DropTable(
                name: "Dosyalar");

            migrationBuilder.DropTable(
                name: "Linkler");

            migrationBuilder.DropTable(
                name: "Projeler");

            migrationBuilder.DropTable(
                name: "Referanslar");

            migrationBuilder.DropTable(
                name: "RolModulYetkileri");

            migrationBuilder.DropTable(
                name: "StajyerBecerileri");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "DegerlendirmeKriterleri");

            migrationBuilder.DropTable(
                name: "DosyaKategorileri");

            migrationBuilder.DropTable(
                name: "Moduller");

            migrationBuilder.DropTable(
                name: "Beceriler");

            migrationBuilder.DropTable(
                name: "Stajyerler");

            migrationBuilder.DropTable(
                name: "BeceriKategorileri");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Departmanlar");

            migrationBuilder.DropTable(
                name: "Roller");
        }
    }
}
