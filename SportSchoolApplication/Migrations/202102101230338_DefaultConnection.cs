namespace SportSchoolApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultConnection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "Patronymic", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "Dicription", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "Contacts", c => c.String(nullable: false));
            AlterColumn("dbo.DayOfWeeks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Gyms", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Gyms", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gyms", "Number", c => c.String());
            AlterColumn("dbo.Gyms", "Address", c => c.String());
            AlterColumn("dbo.DayOfWeeks", "Name", c => c.String());
            AlterColumn("dbo.Applications", "Contacts", c => c.String());
            AlterColumn("dbo.Applications", "Dicription", c => c.String());
            AlterColumn("dbo.Applications", "Patronymic", c => c.String());
            AlterColumn("dbo.Applications", "Surname", c => c.String());
            AlterColumn("dbo.Applications", "Name", c => c.String());
        }
    }
}
