namespace MovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(),
                        IMDBurl = c.String(),
                        rating = c.String(),
                        director = c.String(),
                        releaseYear = c.Int(nullable: false),
                        plot = c.String(),
                        thumbnail = c.String(),
                        trailer = c.String(),
                        userID = c.Int(nullable: false),
                        watched = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
