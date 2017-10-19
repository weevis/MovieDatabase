namespace MovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "userID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "userID", c => c.Int(nullable: false));
        }
    }
}
