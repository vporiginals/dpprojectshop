namespace Shopee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntergradeAspnetIdentity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationRoles", newName: "IdentityRoles");
            RenameTable(name: "dbo.ApplicationUserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.ApplicationUserClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.ApplicationUserLogins", newName: "IdentityUserLogins");
            DropForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.ApplicationRoles");
            DropForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.ApplicationUsers");
            DropIndex("dbo.ApplicationRoleGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "RoleId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "GroupId" });
            DropPrimaryKey("dbo.IdentityUserClaims");
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserClaims", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.IdentityUserClaims", "Id");
            DropTable("dbo.ApplicationGroups");
            DropTable("dbo.ApplicationRoleGroups");
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.Feedbacks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Message = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 250),
                        Website = c.String(maxLength: 250),
                        Address = c.String(maxLength: 250),
                        Other = c.String(),
                        Lat = c.Double(),
                        Lng = c.Double(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId });
            
            CreateTable(
                "dbo.ApplicationRoleGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RoleId });
            
            CreateTable(
                "dbo.ApplicationGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            DropPrimaryKey("dbo.IdentityUserClaims");
            AlterColumn("dbo.IdentityUserClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.IdentityUserClaims", "UserId");
            CreateIndex("dbo.ApplicationUserGroups", "GroupId");
            CreateIndex("dbo.ApplicationUserGroups", "UserId");
            CreateIndex("dbo.ApplicationRoleGroups", "RoleId");
            CreateIndex("dbo.ApplicationRoleGroups", "GroupId");
            AddForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.ApplicationGroups", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.ApplicationRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.ApplicationGroups", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.IdentityUserLogins", newName: "ApplicationUserLogins");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "ApplicationUserClaims");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "ApplicationUserRoles");
            RenameTable(name: "dbo.IdentityRoles", newName: "ApplicationRoles");
        }
    }
}
