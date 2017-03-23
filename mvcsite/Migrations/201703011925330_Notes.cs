namespace mvcsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastUpdated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        ContactId = c.Int(),
                        OrganizationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.ContactId)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Notes", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Notes", new[] { "OrganizationId" });
            DropIndex("dbo.Notes", new[] { "ContactId" });
            DropTable("dbo.Notes");
        }
    }
}
