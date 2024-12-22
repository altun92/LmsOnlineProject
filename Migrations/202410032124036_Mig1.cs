namespace LmsOnlineProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(),
                        KullaniciParola = c.String(),
                    })
                .PrimaryKey(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Branslars",
                c => new
                    {
                        BransId = c.Int(nullable: false, identity: true),
                        BransAd = c.String(),
                    })
                .PrimaryKey(t => t.BransId);
            
            CreateTable(
                "dbo.Egitmenlers",
                c => new
                    {
                        EgitmenId = c.Int(nullable: false, identity: true),
                        EgitmenAd = c.String(),
                        EgitmenSoyad = c.String(),
                        EgitmenEmail = c.String(),
                        EgitmenImage = c.String(),
                        BransId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EgitmenId)
                .ForeignKey("dbo.Branslars", t => t.BransId, cascadeDelete: true)
                .Index(t => t.BransId);
            
            CreateTable(
                "dbo.Kurslars",
                c => new
                    {
                        KursId = c.Int(nullable: false, identity: true),
                        KursAd = c.String(),
                        KursAciklama = c.String(),
                        KursImage = c.String(),
                        KursBaslangicTarih = c.DateTime(nullable: false),
                        KursBitisTarih = c.DateTime(nullable: false),
                        KursFiyat = c.Double(nullable: false),
                        KursKapasite = c.Int(nullable: false),
                        EgitmenId = c.Int(nullable: false),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KursId)
                .ForeignKey("dbo.Egitmenlers", t => t.EgitmenId, cascadeDelete: true)
                .ForeignKey("dbo.Kategorilers", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.EgitmenId)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kategorilers",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Ogrencilers",
                c => new
                    {
                        OgrenciId = c.Int(nullable: false, identity: true),
                        OgrenciAd = c.String(),
                        OgrenciSoyad = c.String(),
                        OgrenciEmail = c.String(),
                        OgrenciImage = c.String(),
                        KursId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OgrenciId)
                .ForeignKey("dbo.Kurslars", t => t.KursId, cascadeDelete: true)
                .Index(t => t.KursId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrencilers", "KursId", "dbo.Kurslars");
            DropForeignKey("dbo.Kurslars", "KategoriId", "dbo.Kategorilers");
            DropForeignKey("dbo.Kurslars", "EgitmenId", "dbo.Egitmenlers");
            DropForeignKey("dbo.Egitmenlers", "BransId", "dbo.Branslars");
            DropIndex("dbo.Ogrencilers", new[] { "KursId" });
            DropIndex("dbo.Kurslars", new[] { "KategoriId" });
            DropIndex("dbo.Kurslars", new[] { "EgitmenId" });
            DropIndex("dbo.Egitmenlers", new[] { "BransId" });
            DropTable("dbo.Ogrencilers");
            DropTable("dbo.Kategorilers");
            DropTable("dbo.Kurslars");
            DropTable("dbo.Egitmenlers");
            DropTable("dbo.Branslars");
            DropTable("dbo.Admins");
        }
    }
}
