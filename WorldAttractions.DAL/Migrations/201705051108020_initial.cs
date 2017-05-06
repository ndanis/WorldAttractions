namespace WorldAttractions.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DistrictId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IdCity = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.IdCity)
                .Index(t => t.IdCity);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        MonumentID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monuments", t => t.MonumentID)
                .Index(t => t.MonumentID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Telephone = c.String(),
                        Skype = c.String(),
                        Gender = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Pictures", "MonumentID", "dbo.Monuments");
            DropForeignKey("dbo.Monuments", "IdCity", "dbo.Cities");
            DropForeignKey("dbo.Cities", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Pictures", new[] { "MonumentID" });
            DropIndex("dbo.Monuments", new[] { "IdCity" });
            DropIndex("dbo.Cities", new[] { "DistrictId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Pictures");
            DropTable("dbo.Monuments");
            DropTable("dbo.Districts");
            DropTable("dbo.Cities");
        }
    }
}
