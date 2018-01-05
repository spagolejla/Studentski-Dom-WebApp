using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiDom.Data.Migrations
{
    public partial class inic3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AkademskeGodine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkademskeGodine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fakulteti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakulteti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pojsjetioci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojsjetioci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CijenaPoSatu = table.Column<double>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoviSoba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviSoba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoviUplata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviUplata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VesMasine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kapacitet = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Susilica = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesMasine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrsteZaposlenika",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IznosSatnice = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteZaposlenika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    _DrzavaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regije_Drzave__DrzavaId",
                        column: x => x._DrzavaId,
                        principalTable: "Drzave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojKreveta = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Sprat = table.Column<int>(nullable: false),
                    _TipSobeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sobe_TipoviSoba__TipSobeId",
                        column: x => x._TipSobeId,
                        principalTable: "TipoviSoba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    _RegijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gradovi_Regije__RegijaId",
                        column: x => x._RegijaId,
                        principalTable: "Regije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false),
                    Mail = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    _FakultetId = table.Column<int>(nullable: true),
                    _GradId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studenti_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studenti_Fakulteti__FakultetId",
                        column: x => x._FakultetId,
                        principalTable: "Fakulteti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Studenti_Gradovi__GradId",
                        column: x => x._GradId,
                        principalTable: "Gradovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false),
                    Mail = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    _GradId = table.Column<int>(nullable: true),
                    _VrstaZaposlenikaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposlenici_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenici_Gradovi__GradId",
                        column: x => x._GradId,
                        principalTable: "Gradovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zaposlenici_VrsteZaposlenika__VrstaZaposlenikaId",
                        column: x => x._VrstaZaposlenikaId,
                        principalTable: "VrsteZaposlenika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijeSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojSati = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    UkupnaCijena = table.Column<double>(nullable: false),
                    _PosjetilacId = table.Column<int>(nullable: false),
                    _SalaId = table.Column<int>(nullable: false),
                    _ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijeSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervacijeSale_Pojsjetioci__PosjetilacId",
                        column: x => x._PosjetilacId,
                        principalTable: "Pojsjetioci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijeSale_Sale__SalaId",
                        column: x => x._SalaId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijeSale_Zaposlenici__ZaposlenikId",
                        column: x => x._ZaposlenikId,
                        principalTable: "Zaposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentiSobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumDodjele = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    _AkademskaGodinaId = table.Column<int>(nullable: false),
                    _SobaId = table.Column<int>(nullable: false),
                    _StudentId = table.Column<int>(nullable: false),
                    _ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentiSobe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentiSobe_AkademskeGodine__AkademskaGodinaId",
                        column: x => x._AkademskaGodinaId,
                        principalTable: "AkademskeGodine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentiSobe_Sobe__SobaId",
                        column: x => x._SobaId,
                        principalTable: "Sobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentiSobe_Studenti__StudentId",
                        column: x => x._StudentId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentiSobe_Zaposlenici__ZaposlenikId",
                        column: x => x._ZaposlenikId,
                        principalTable: "Zaposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerminiVeseraja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumKoristenja = table.Column<DateTime>(nullable: false),
                    VrijemeKoristenja = table.Column<int>(nullable: false),
                    _StudentSobaId = table.Column<int>(nullable: false),
                    _VesMasinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminiVeseraja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerminiVeseraja_StudentiSobe__StudentSobaId",
                        column: x => x._StudentSobaId,
                        principalTable: "StudentiSobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerminiVeseraja_VesMasine__VesMasinaId",
                        column: x => x._VesMasinaId,
                        principalTable: "VesMasine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<double>(nullable: false),
                    _StudentSobaId = table.Column<int>(nullable: false),
                    _TipUplateId = table.Column<int>(nullable: false),
                    _ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplate_StudentiSobe__StudentSobaId",
                        column: x => x._StudentSobaId,
                        principalTable: "StudentiSobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uplate_TipoviUplata__TipUplateId",
                        column: x => x._TipUplateId,
                        principalTable: "TipoviUplata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uplate_Zaposlenici__ZaposlenikId",
                        column: x => x._ZaposlenikId,
                        principalTable: "Zaposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gradovi__RegijaId",
                table: "Gradovi",
                column: "_RegijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Regije__DrzavaId",
                table: "Regije",
                column: "_DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijeSale__PosjetilacId",
                table: "RezervacijeSale",
                column: "_PosjetilacId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijeSale__SalaId",
                table: "RezervacijeSale",
                column: "_SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijeSale__ZaposlenikId",
                table: "RezervacijeSale",
                column: "_ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Sobe__TipSobeId",
                table: "Sobe",
                column: "_TipSobeId");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_KorisnikId",
                table: "Studenti",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti__FakultetId",
                table: "Studenti",
                column: "_FakultetId");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti__GradId",
                table: "Studenti",
                column: "_GradId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiSobe__AkademskaGodinaId",
                table: "StudentiSobe",
                column: "_AkademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiSobe__SobaId",
                table: "StudentiSobe",
                column: "_SobaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiSobe__StudentId",
                table: "StudentiSobe",
                column: "_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiSobe__ZaposlenikId",
                table: "StudentiSobe",
                column: "_ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminiVeseraja__StudentSobaId",
                table: "TerminiVeseraja",
                column: "_StudentSobaId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminiVeseraja__VesMasinaId",
                table: "TerminiVeseraja",
                column: "_VesMasinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate__StudentSobaId",
                table: "Uplate",
                column: "_StudentSobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate__TipUplateId",
                table: "Uplate",
                column: "_TipUplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate__ZaposlenikId",
                table: "Uplate",
                column: "_ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenici_KorisnikId",
                table: "Zaposlenici",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenici__GradId",
                table: "Zaposlenici",
                column: "_GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenici__VrstaZaposlenikaId",
                table: "Zaposlenici",
                column: "_VrstaZaposlenikaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezervacijeSale");

            migrationBuilder.DropTable(
                name: "TerminiVeseraja");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropTable(
                name: "Pojsjetioci");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "VesMasine");

            migrationBuilder.DropTable(
                name: "StudentiSobe");

            migrationBuilder.DropTable(
                name: "TipoviUplata");

            migrationBuilder.DropTable(
                name: "AkademskeGodine");

            migrationBuilder.DropTable(
                name: "Sobe");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Zaposlenici");

            migrationBuilder.DropTable(
                name: "TipoviSoba");

            migrationBuilder.DropTable(
                name: "Fakulteti");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Gradovi");

            migrationBuilder.DropTable(
                name: "VrsteZaposlenika");

            migrationBuilder.DropTable(
                name: "Regije");

            migrationBuilder.DropTable(
                name: "Drzave");
        }
    }
}
